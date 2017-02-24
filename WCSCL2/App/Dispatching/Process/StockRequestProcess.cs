using System;
using System.Collections.Generic;
using System.Text;
using MCP;
using System.Data;
using Util;

namespace App.Dispatching.Process
{
    public class StockRequestProcess : AbstractProcess
    {
        BLL.BLLBase bll = new BLL.BLLBase();
        int Instation = 1;

        protected override void StateChanged(StateItem stateItem,IProcessDispatcher dispatcher) 
        {
            object obj = ObjectUtil.GetObject(stateItem.State);

            string TaskFinish = obj.ToString();

            if (TaskFinish.Equals("True") || TaskFinish.Equals("1"))
            {
                try
                {
                    string AreaCode = "002";
                    string taskNo = Util.ConvertStringChar.BytesToString(ObjectUtil.GetObjects(WriteToService(stateItem.Name, stateItem.ItemName)));
                    //string taskNo = Util.ConvertStringChar.BytesToString(ObjectUtil.GetObjects(WriteToService(stateItem.Name, "BarCode")));
                    sbyte[] staskNo = new sbyte[20];
                   
                    int SlideNum = 2;
                    string StationNo = "02";
                    DataParameter[] param = new DataParameter[] { new DataParameter("{0}", string.Format("(TaskNo='{0}' and ((WCS_TASK.TaskType in  ('11','16') and  WCS_TASK.State='1') or (WCS_TASK.TaskType='14' and  WCS_TASK.State='11'))) and AreaCode='002'", taskNo)) };
                    DataTable dt = bll.FillDataTable("WCS.SelectTask", param);
                    if (dt.Rows.Count > 0)
                    {
                        taskNo = dt.Rows[0]["TaskNo"].ToString();
                        //如果是盘点任务,因为盘点回原库位，所以按照库位指定入库站台
                        if (dt.Rows[0]["TaskType"].ToString() == "14" && dt.Rows[0]["State"].ToString() == "11")
                        {
                            string CellCode = dt.Rows[0]["CellCode"].ToString();
                            if (CellCode.Length > 0)
                            {
                                if (CellCode.Substring(3,1)=="1" || CellCode.Substring(3,1)=="2")
                                {
                                    StationNo = "01";
                                    SlideNum = 1;
                                }
                                else if (CellCode.Substring(3, 1) == "3" || CellCode.Substring(3, 1) == "4") 
                                {
                                    StationNo = "02";
                                    SlideNum = 2;
                                }
                                else if (CellCode.Substring(3, 1) == "5" || CellCode.Substring(3, 1) == "6")
                                {
                                    StationNo = "03";
                                    SlideNum = 3;
                                }
                                else 
                                {
                                    StationNo = "04";
                                    SlideNum = 4;
                                }
                            }
                            else
                            {
                                Logger.Error("盘点任务货位丢失，请核对");
                                return;
                            }
                        }
                        else
                        {
                            //判断此条码有没有在库位上存在或在途
                            if (BarcodeIsExist(taskNo, staskNo))
                                return;
                            //判断有没有可用货位
                            //dt = bll.FillDataTable("WCS.SelectHasCell", new DataParameter[] { new DataParameter("@AreaCode", AreaCode) });
                            //if (int.Parse(dt.Rows[0][0].ToString()) == 0)
                            //{
                            //    Util.ConvertStringChar.stringToBytes("", 20).CopyTo(staskNo, 0);
                            //    WriteToService("TranLine", "Barcode", staskNo);
                            //    WriteToService("TranLine", "SlideNum", 98);
                            //    Logger.Error("没有空余的货位可以入库!");
                            //    return;
                            //}

                        }
                    }
                    else
                    {
                        if (BarcodeIsExist(taskNo, staskNo))
                            return;
                        //产生空周转箱入库任务
                        
                    }

                    Util.ConvertStringChar.stringToBytes(taskNo , 20).CopyTo(staskNo, 0);
                    SlideNum = int.Parse(dt.Rows[0]["AisleNo"].ToString());
                    StationNo = dt.Rows[0]["StationNo"].ToString();
                    WriteToService("TranLine", "Barcode", staskNo);
                    WriteToService("TranLine", "SlideNum", SlideNum);

                    //更新状态
                    param = new DataParameter[] { new DataParameter("@StationNo", StationNo), new DataParameter("@TaskNo", taskNo) };
                    bll.ExecNonQuery("WCS.UpdateTaskInStockRequest", param);
                    Logger.Info("任务号:" + taskNo + " 托盘:" + " 开始入库,到达入库口:" + StationNo);
                }
                catch(Exception ex)
                {
                    Logger.Error("入库请求出错,错误内容:" + ex.Message);
                }
            }
        }

        private bool BarcodeIsExist(string Barcode, sbyte[] staskNo)
        {
            //判断此条码有没有在库位上存在或在途
            DataTable dt = bll.FillDataTable("WCS.PalletBarcodeExist", new DataParameter[] { new DataParameter("@Barcode", Barcode) });
            if (dt.Rows.Count > 0)
            {
                Util.ConvertStringChar.stringToBytes("", 20).CopyTo(staskNo, 0);
                WriteToService("TranLine", "Barcode", staskNo);
                WriteToService("TranLine", "SlideNum", 99);
                Logger.Error("此条码已经入库，请确认条码!");
                return true;
            }
            return false;
        }
    }
}

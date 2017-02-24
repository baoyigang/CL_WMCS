using System;
using System.Collections.Generic;
using System.Text;
using MCP;
using System.Data;
using Util;

namespace App.Dispatching.Process
{
    public class OutStockFinishProcess : AbstractProcess
    {
        protected override void StateChanged(StateItem stateItem, IProcessDispatcher dispatcher)
        {
            object obj = ObjectUtil.GetObject(stateItem.State);
            if (obj == null)
                return;

            BLL.BLLBase bll = new BLL.BLLBase();
            string Request = obj.ToString();
            if (Request.Equals("True") || Request.Equals("1"))
            {
                try
                {
                    string taskNo = Util.ConvertStringChar.BytesToString(ObjectUtil.GetObjects(WriteToService(stateItem.Name, stateItem.ItemName)));
                    if (taskNo.Trim().Length > 0)
                    {
                        

                        DataTable dt = bll.FillDataTable("WCS.SelectReadTaskByTaskNo", new DataParameter[] { new DataParameter("@TaskNo", taskNo) });
                        if (dt.Rows.Count > 0)
                        {
                            string TaskType = dt.Rows[0]["TaskType"].ToString();
                            string strState = dt.Rows[0]["State"].ToString();
                            if (TaskType == "12" || TaskType == "15" || TaskType == "14") //出库,托盘出库,盘点
                            {
                                DataParameter[] param = new DataParameter[] { new DataParameter("@TaskNo", taskNo) };
                                DataTable dtXml = bll.FillDataTable("WCS.Sp_TaskProcess", param);
                                Logger.Info("出库任务完成,任务号:" + taskNo );

                  
                                string Flag = "";

                                if (TaskType == "12")
                                        Flag = "BatchOutStock";
                         
                                if (dtXml.Rows.Count > 0)
                                {
                                    string BillNo = dtXml.Rows[0][0].ToString();
                                    if (BillNo.Trim().Length > 0)
                                    {

                                        string xml = Util.ConvertObj.ConvertDataTableToXmlOperation(dtXml, Flag);
                                        WriteToService("ERP", "ACK", xml);
                                        Logger.Info("单号" + dtXml.Rows[0][0].ToString() + "已完成，开始上报ERP系统");
                                    }
                                }
                                //string strValue = "";
                                //string[] str = new string[3];
                                //if (TaskType == "12" || TaskType == "14")//显示拣货信息.
                                //{
                                //    str[0] = "1";
                                //    if (TaskType == "14")
                                //        str[0] = "2";

                                //    while ((strValue = FormDialog.ShowDialog(str, dt)) != "")
                                //    {
                                //        break;
                                //    }
                                //}
                            }
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("到达出库口,错误讯息:" + ex.Message);
                }
            }
        }
    }
}

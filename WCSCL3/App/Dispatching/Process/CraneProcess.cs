using System;
using System.Collections.Generic;
using System.Text;
using MCP;
using System.Data;
using Util;
using System.Timers;
using System.Diagnostics;

namespace App.Dispatching.Process
{
    public class CraneProcess : AbstractProcess
    {
        private class rCrnStatus
        {
            public string TaskNo { get; set; }
            public int Status { get; set; }
            public int Action { get; set; }
            public int ErrCode { get; set; }
            public int TaskStatus { get; set; }
            public int io_flag { get; set; }
            public rCrnStatus()
            {
                TaskNo = "";
                Status = 0;
                Action = 0;
                ErrCode = 0;
                TaskStatus = 0;
                io_flag = 0;
            }
        }

        // 记录堆垛机当前状态及任务相关信息
        BLL.BLLBase bll = new BLL.BLLBase();
        private Dictionary<int, rCrnStatus> dCrnStatus = new Dictionary<int, rCrnStatus>();
        private System.Timers.Timer tmWorkTimer = new System.Timers.Timer();
        private bool blRun = false;
        private string AreaCode;
        private DataTable dtCraneErr;
        DataTable dta = new DataTable();

        public override void Initialize(Context context)
        {
            try
            {
                dtCraneErr = bll.FillDataTable("WCS.SelectCraneError");
                AreaCode = BLL.Server.GetAreaCode();
                //获取堆垛机信息
                DataTable dt = bll.FillDataTable("CMD.SelectCrane", new DataParameter[] { new DataParameter("{0}", "CraneNo='04'") });
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!dCrnStatus.ContainsKey(i))
                    {
                        rCrnStatus crnsta = new rCrnStatus();
                        dCrnStatus.Add(i, crnsta);

                        dCrnStatus[i].TaskNo = "";
                        dCrnStatus[i].Status = int.Parse(dt.Rows[i]["State"].ToString());
                        dCrnStatus[i].TaskStatus = 0;
                        dCrnStatus[i].ErrCode = 0;
                        dCrnStatus[i].Action = 0;
                    }
                }

                tmWorkTimer.Interval = 2001;
                tmWorkTimer.Elapsed += new ElapsedEventHandler(tmWorker);
                

                base.Initialize(context);
            }
            catch (Exception ex)
            {
                Logger.Error("CraneProcess堆垛机初始化出错，原因：" + ex.Message);
            }
        }
        protected override void StateChanged(StateItem stateItem, IProcessDispatcher dispatcher)
        {
            //object obj = ObjectUtil.GetObject(stateItem.State);
            //if (obj == null)
            //    return;

            switch (stateItem.ItemName)
            {
                case "CraneTaskFinished":
                    try
                    {
                        object obj = ObjectUtil.GetObject(stateItem.State);
                        string TaskFinish = obj.ToString();
                        if (TaskFinish.Equals("True") || TaskFinish.Equals("1"))
                        {
                            string TaskNo = ObjectUtil.GetObject(Context.ProcessDispatcher.WriteToService(stateItem.Name, "CraneTaskNo")).ToString();

                            if (TaskNo == "0")
                                return;
                            object[] objRow = ObjectUtil.GetObjects(Context.ProcessDispatcher.WriteToService(stateItem.Name, "CraneAlarmCode"));
                            int Column = int.Parse(objRow[2].ToString());
                            int Height = int.Parse(objRow[3].ToString());
                            int Row = int.Parse(objRow[4].ToString());
                           
                            //更新任务状态
                            DataParameter[] param = new DataParameter[] { new DataParameter("@TaskNo", TaskNo) };
                            //bll.ExecNonQueryTran("WCS.Sp_TaskProcess", param);
                            DataTable dtXml = bll.FillDataTable("WCS.Sp_TaskProcess1", param);

                            //判断任务号是什么类型，如果是盘点另外处理
                            param = new DataParameter[] { new DataParameter("{0}", string.Format("WCS_Task.TaskNo='{0}'", TaskNo)) };
                            DataTable dt = bll.FillDataTable("WCS.SelectTask", param);

                            string Flag = "BatchInStock";
                            string TaskType = "";
                            string CellCode = "";
                            string strState = "";
                            string stationNo = "";
                            if (dt.Rows.Count > 0)
                            {
                                TaskType = dt.Rows[0]["TaskType"].ToString();
                                CellCode = dt.Rows[0]["CellCode"].ToString();
                                strState = dt.Rows[0]["State"].ToString();
                                stationNo = dt.Rows[0]["StationNo"].ToString();
                                if (TaskType == "12")
                                    Flag = "BatchOutStock";
                                else if (TaskType == "14")
                                    Flag = "BatchCheckStock";
                            }
                            //if (dtXml.Rows.Count > 0)
                            //{
                            //    string BillNo = dtXml.Rows[0][0].ToString();
                            //    if (BillNo.Trim().Length > 0)
                            //    {

                            //        string xml = Util.ConvertObj.ConvertDataTableToXmlOperation(dtXml, Flag);
                            //        WriteToService("ERP", "ACK", xml);
                            //        Logger.Info("单号" + dtXml.Rows[0][0].ToString() + "已完成，开始上报ERP系统");
                            //    }
                            //}

                            string[] str = new string[3];
                            str[0] = "6";
                            string strValue = "";
                            if (TaskType == "14" && strState == "4")
                            {
                                while ((strValue = FormDialog.ShowDialog(str, dt)) != "")
                                {
                                    if (strValue != "1")
                                    {
                                        //更新货位信息
                                        bll.ExecNonQuery("WCS.UpdateErrCell", new DataParameter[] { new DataParameter("@CellCode", CellCode) });
                                    }
                                    bll.ExecNonQuery("WCS.UpdateTaskStateByTaskNo", new DataParameter[] { new DataParameter("@State", 13), new DataParameter("@TaskNo", TaskNo) });

                                    param = new DataParameter[] { new DataParameter("{0}", string.Format("WCS_TASK.TaskNo={0}", TaskNo)) };
                                    dt = bll.FillDataTable("WCS.SelectTask", param);
                                    strState = dt.Rows[0]["State"].ToString();
                                    //线程继续。
                                    break;
                                }
                            }

                            if (strState == "13")
                            {

                                bll.ExecNonQuery("WCS.UpdateTaskStateByTaskNo", new DataParameter[] { new DataParameter("@State", 10), new DataParameter("@TaskNo", TaskNo) });
                            }

                            if (TaskType == "11" && strState == "7")
                            {
                                int ToRow = int.Parse(CellCode.Substring(3,1));
                                if (ToRow<3)
                                {
                                    ToRow = 201;
                                }
                                else if(ToRow<5)
                                {
                                    ToRow = 202;
                                }
                                else if (ToRow<7)
                                {
                                    ToRow = 203;
                                }
                                else
                                {
                                    ToRow = 204;
                                }
                                int[] cellAddr = new int[9];
                                cellAddr[0] = 0;
                                cellAddr[1] = 0;
                                cellAddr[2] = 0;
                                cellAddr[3] = 1;
                                cellAddr[4] = 1;
                                cellAddr[5] = 1;
                                cellAddr[6] = ToRow;
                                cellAddr[7] = ToRow;
                                cellAddr[8] = ToRow;
                                Context.ProcessDispatcher.WriteToService(stateItem.Name, "ReciveFinish", 1);
                                Context.ProcessDispatcher.WriteToService("CranePLC4", "TaskNo", 0);
                                Context.ProcessDispatcher.WriteToService("CranePLC4", "TaskAddress", cellAddr);
                                Context.ProcessDispatcher.WriteToService("CranePLC4", "WriteFinished", 2);
                                Logger.Info(stateItem.ItemName + "完成标志,任务号:" + TaskNo);
                                return;
                            }
                            else
                            {
                                WriteToService(stateItem.Name, "TaskNo", 0);
                                WriteToService(stateItem.Name, "ReciveFinish", 1);
                                Logger.Info(stateItem.ItemName + "完成标志,任务号:" + TaskNo);
                            }
                           
                           
                        }
                    }
                    catch (Exception ex1)
                    {
                        Logger.Info("CraneProcess中CraneTaskFinished出错：" + ex1.Message);
                    }
                    break;
                case "Run":
                    blRun = (int)stateItem.State == 1;
                    if (blRun)
                    {
                        tmWorkTimer.Start();
                        Logger.Info("堆垛机联机");
                    }
                    else
                    {
                        tmWorkTimer.Stop();
                        Logger.Info("堆垛机脱机");
                    }
                    break;
                default:
                    break;
            }
            
            
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmWorker(object sender, ElapsedEventArgs e)
        {
            try
            {
                tmWorkTimer.Stop();


                DataTable dt = bll.FillDataTable("CMD.SelectCrane", new DataParameter[] { new DataParameter("{0}", "CraneNo='04'") });
              
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dCrnStatus.ContainsKey(i))
                    {
                        dCrnStatus[i].Status = int.Parse(dt.Rows[i]["State"].ToString());
                    }
                }

                for (int i = 4; i <= 4; i++)
                {
                    if (dCrnStatus[i-4].Status != 1)
                        continue;
                    if (dCrnStatus[i-4].io_flag == 0)
                    {
                        CraneOut(i);
                    }
                    else
                    {
                        CraneIn(i);
                    }
                }
                
            }

            finally
            {
                tmWorkTimer.Start();
            }
        }
        /// <summary>
        /// 检查堆垛机入库状态
        /// </summary>
        /// <param name="piCrnNo"></param>
        /// <returns></returns>
        private bool Check_Crane_Status_IsOk(int craneNo)
        {
            try
            {
                string serviceName = "CranePLC" + craneNo;
                
                string plcTaskNo = ObjectUtil.GetObject(Context.ProcessDispatcher.WriteToService(serviceName, "CraneTaskNo")).ToString();

                string craneMode = ObjectUtil.GetObject(Context.ProcessDispatcher.WriteToService(serviceName, "CraneMode")).ToString();
                object[] obj = ObjectUtil.GetObjects(Context.ProcessDispatcher.WriteToService(serviceName, "CraneAlarmCode"));
                int CraneState = int.Parse(obj[1].ToString());
                int CraneAlarmCode = int.Parse(obj[0].ToString());

                if (plcTaskNo == "0" && craneMode == "1" && CraneAlarmCode == 0 && CraneState == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }            
        }        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="craneNo"></param>
        private void CraneOut(int craneNo)
        {
            // 判断堆垛机的状态 自动  空闲
            //Logger.Debug("判断堆垛机" + piCrnNo.ToString() + "能否出库");
            try
            {
                
                //判断堆垛机
                if (!Check_Crane_Status_IsOk(craneNo))
                {
                    //Logger.Info("堆垛机状态不符合出库");
                    return;
                }
                //切换入库优先
                dCrnStatus[craneNo-4].io_flag = 1;
            }
            catch (Exception e)
            {
                Logger.Debug("Crane out 状态检查错误:" + e.Message.ToString());
                return;
            }

            string serviceName = "CranePLC" + craneNo;


            string CraneNo = "0" + craneNo.ToString();

            //获取任务，排序优先等级、任务时间
            DataTable dtState;

            dtState = bll.FillDataTable("WCS.SelcetWcsState",new DataParameter[]{new DataParameter("{0}",CraneNo),new DataParameter("{1}",2),new DataParameter("{2}","WCS_TASK.State=1 or WCS_TASK.State=12")});

              
                DataParameter[] parameter;
                if (dtState.Rows.Count == 0)
                {
                    parameter = new DataParameter[] { new DataParameter("{0}", string.Format("WCS_Task.TaskType in ('12','13','14','15') and WCS_Task.State='0' and                                                     WCS_Task.CellCode!='' and WCS_Task.CraneNo='{0}' and WCS_TASK.AreaCode='{1}'", CraneNo, AreaCode)) };
                }
                else
                {
                    parameter = new DataParameter[] { new DataParameter("{0}", string.Format("WCS_Task.TaskType in ('12','13','14','15') and WCS_Task.State='0' and                                                     WCS_Task.CellCode!='' and WCS_Task.CraneNo='{0}' and WCS_TASK.AreaCode='{1}' and taskNo=null", CraneNo, AreaCode)) };
                }
            DataTable dt = bll.FillDataTable("WCS.SelectOutTask", parameter);

            //出库
            if (dt.Rows.Count>0)
            {


                DataRow dr = dt.Rows[0];
                string TaskNo = dr["TaskNo"].ToString();
                string BillID = dr["BillID"].ToString();
                byte taskType = byte.Parse(dt.Rows[0]["TaskType"].ToString().Substring(1, 1));

                string fromStation = dt.Rows[0]["FromStation"].ToString().Substring(1);
                string toStation = dt.Rows[0]["ToStation"].ToString().Substring(1);
                string stationNo = dt.Rows[0]["StationNo"].ToString();

                //if (taskType != 3 && stationNo!="02")
                //{
                //    string StationLoad = ObjectUtil.GetObject(Context.ProcessDispatcher.WriteToService("TranLine", "StationLoad" + stationNo)).ToString();
                //    //判断出库站台无货
                //    if (StationLoad.Equals("True") || StationLoad.Equals("1"))
                //    {
                //        Logger.Info("站台状态不符合堆垛机出库");
                //        return;
                //    }
                //}
                
                int[] cellAddr = new int[9];
                cellAddr[0] = 0;
                cellAddr[1] = 0;
                cellAddr[2] = 0;
                
                cellAddr[3] = byte.Parse(fromStation.Substring(3, 3));
                cellAddr[4] = byte.Parse(fromStation.Substring(6, 3));
                cellAddr[5] = byte.Parse(fromStation.Substring(0, 3));                
                cellAddr[6] = byte.Parse(toStation.Substring(3, 3));
                cellAddr[7] = byte.Parse(toStation.Substring(6, 3));
                cellAddr[8] = byte.Parse(toStation.Substring(0, 3));

                WriteToService(serviceName, "TaskAddress", cellAddr);
                WriteToService(serviceName, "TaskNo", TaskNo);
                if (WriteToService(serviceName, "WriteFinished", 1))
                {
                    //更新任务状态为执行中
                    bll.ExecNonQuery("WCS.UpdateTaskTimeByTaskNo", new DataParameter[] { new DataParameter("@State", 3), new DataParameter("@TaskNo", TaskNo) });
                    bll.ExecNonQuery("WCS.UpdateBillStateByBillID", new DataParameter[] { new DataParameter("@State", 3), new DataParameter("@BillID", BillID) });


                    DataParameter[] param1 = new DataParameter[] { new DataParameter("{0}", string.Format("WCS_Task.TaskNo='{0}'", TaskNo)) };
                    DataTable dt1 = bll.FillDataTable("WCS.SelectTask", param1);

                    string TaskType = "";
                    string strState = "";
                    string stationNo1 = "";
                    string AisleNo = "";
                    if (dt1.Rows.Count > 0)
                    {
                        TaskType = dt1.Rows[0]["TaskType"].ToString();
                        strState = dt1.Rows[0]["State"].ToString();
                        stationNo1 = dt1.Rows[0]["StationNo"].ToString();
                        AisleNo = dt1.Rows[0]["AisleNo"].ToString().Substring(1);
                    }
                    try
                    {
                        int aisleNo = int.Parse(AisleNo);


                        WriteToService("TranLine", "TaskType", 2);
                        WriteToService("TranLine", "TaskNo", TaskNo);
                        WriteToService("TranLine", "SlideNum", AisleNo);
                        WriteToService("TranLine", "Height", 1);
                        WriteToService("TranLine", "NewTask", 1);
           
         
                    }
                    catch (Exception ex)
                    {

                        Logger.Error(ex.Message);
                    }
                       
                }
                Logger.Info("任务:" + dr["TaskNo"].ToString() + "已下发给" + craneNo + "堆垛机;起始地址:" + fromStation + ",目标地址:" + toStation);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="craneNo"></param>
        private void CraneIn(int craneNo)
        {
            // 判断堆垛机的状态 自动  空闲
            try
            {
                //判断堆垛机
                if (!Check_Crane_Status_IsOk(craneNo))
                    return;

                //切换出库优先
                dCrnStatus[craneNo-4].io_flag = 0;
            }
            catch (Exception e)
            {
                //Logger.Debug("Crane out 状态检查错误:" + e.Message.ToString());
                return;
            }

            string serviceName = "CranePLC" + craneNo;

            object[] obj = ObjectUtil.GetObjects(Context.ProcessDispatcher.WriteToService(serviceName, "CraneTaskNo"));
            string plcTaskNo = Util.ConvertStringChar.BytesToString(obj);

            string CraneNo = "0" + craneNo.ToString();
            //获取任务，排序优先等级、任务时间
           
            DataParameter[] parameter;
            
                parameter = new DataParameter[] { new DataParameter("{0}", string.Format("((WCS_Task.TaskType='11' and WCS_Task.State='12') or (WCS_Task.TaskType='14' and WCS_Task.State='12'))                  and WCS_Task.CraneNo='{0}' and WCS_TASK.AreaCode='{1}' and WCS_TASK.CellCode!=''", CraneNo, AreaCode)) };
          
            DataTable dt = bll.FillDataTable("WCS.SelectTask", parameter);
            //入库
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                string TaskNo = dr["TaskNo"].ToString();

                string BillID = dr["BillID"].ToString();
                byte taskType = byte.Parse(dt.Rows[0]["TaskType"].ToString().Substring(1, 1));
                string fromStation = dt.Rows[0]["FromStation"].ToString().Substring(1);
                string toStation = dt.Rows[0]["ToStation"].ToString().Substring(1);
                string TaskID = dr["taskid"].ToString();

                int[] cellAddr = new int[9];
                cellAddr[0] = 0;
                cellAddr[1] = 0;
                cellAddr[2] = 0;

                cellAddr[3] = byte.Parse(fromStation.Substring(3, 3));
                cellAddr[4] = byte.Parse(fromStation.Substring(6, 3));
                cellAddr[5] = byte.Parse(fromStation.Substring(0, 3));
                cellAddr[6] = byte.Parse(toStation.Substring(3, 3));
                cellAddr[7] = byte.Parse(toStation.Substring(6, 3));
                cellAddr[8] = byte.Parse(toStation.Substring(0, 3));

                int taskNo = int.Parse(dr["TaskNo"].ToString());
                WriteToService(serviceName, "TaskAddress", cellAddr);
                WriteToService(serviceName, "TaskNo", taskNo);
                if (WriteToService(serviceName, "WriteFinished", 1))
                {
                    string State = "3";
                    if (taskType == 4)
                        State = "6";
                    //更新任务状态为执行中
                    bll.ExecNonQuery("WCS.UpdateTaskTimeByTaskID", new DataParameter[] { new DataParameter("@State", State), new DataParameter("@TaskID", TaskID) });
                    bll.ExecNonQuery("WCS.UpdateBillStateByBillID", new DataParameter[] { new DataParameter("@State", 3), new DataParameter("@BillID", BillID) });

                    

                            
                }
                Logger.Info("任务:" + dr["TaskNo"].ToString() + "已下发给" + craneNo + "堆垛机;起始地址:" + fromStation + ",目标地址:" + toStation);
            }
        }
    }
}
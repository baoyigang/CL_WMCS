using System;
using System.Collections.Generic;
using System.Text;
using MCP;
using System.Data;
using Util;

namespace App.Dispatching.Process
{
   public class InStockToStationProcess : AbstractProcess
    {
        protected override void StateChanged(StateItem stateItem, IProcessDispatcher dispatcher)
        {
            object obj = ObjectUtil.GetObject(stateItem.State);
            if (obj == null)
                return;
            string TaskFinish = obj.ToString();
            if (TaskFinish.Equals("True") || TaskFinish.Equals("1"))
            {
                string ReadName = "";
                int SlideNum = 0;
                string StationNo = "";
                switch (stateItem.ItemName)
                {
                    case "InFinish1":
                        ReadName = "InTaskNo1";
                        SlideNum = 1;
                        StationNo = "01";
                        break;
                    case "InFinish2":
                        ReadName = "InTaskNo2";
                        SlideNum = 2;
                        StationNo = "02";
                        break;
                    case "InFinish3":
                        ReadName = "InTaskNo3";
                        SlideNum = 3;
                        StationNo = "03";
                        break;
                    case "InFinish4":
                        ReadName = "InTaskNo4";
                        SlideNum = 4;
                        StationNo = "04";
                        break;
                }

                try
                {
                    string TaskInfo = ObjectUtil.GetObject(WriteToService(stateItem.Name, ReadName)).ToString();
                    if (TaskInfo == "0")
                        return;
                    string TaskNo = TaskInfo.Trim();
                    string TaskID = "";             
                    BLL.BLLBase bll = new BLL.BLLBase();
                    DataTable dt = bll.FillDataTable("WCS.SelectWcsTaskByTaskNo", new DataParameter("{0}", TaskNo));
                    if (dt.Rows.Count>0)
                    {
                        TaskID = dt.Rows[0]["taskid"].ToString();
                        if (dt.Rows[0]["TaskType"].ToString() == "12" || (dt.Rows[0]["TaskType"].ToString() == "14" && dt.Rows[0]["State"].ToString() != "2") || dt.Rows[0]["State"].ToString() == "7")
                        {
                            return;
                        }
                  
                    }
                    
                    DataParameter[] param = new DataParameter[] {  new DataParameter("@TaskID", TaskID) };
                    bll.ExecNonQueryTran("WCS.UpdateInStockStation", param);

                    Logger.Info("任务号:" + TaskNo + ",到达入库站台:" + StationNo);
                }
                catch (Exception ex)
                {
                    Logger.Error("InStockToStationProcess出错，原因：" + ex.Message);
                }
            }
        }
    }
}

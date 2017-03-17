using System;
using System.Collections.Generic;
using System.Text;
using MCP;
using System.Data;
using Util;

namespace App.Dispatching.Process
{
    public class OutFinishProcess : AbstractProcess
    {
        protected override void StateChanged(StateItem stateItem, IProcessDispatcher dispatcher)
        {
            object obj = ObjectUtil.GetObject(stateItem.State);
            if (obj == null)
                return;
            BLL.BLLBase bll=new BLL.BLLBase();
            string taskNo = obj.ToString();
            DataTable dt = bll.FillDataTable("WCS.SelectTask", new DataParameter("{0}", string.Format("TaskNo={0} and WCS_TASK.State=10", taskNo)));
            if (dt.Rows.Count>0)
            {
                string TaskType = dt.Rows[0]["TaskType"].ToString();
                if (TaskType=="12" || TaskType=="14" )
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
                }
            }
        }
    }
}

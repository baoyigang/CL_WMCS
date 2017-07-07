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
            if (obj == null || obj.ToString() == "0")
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
                                DataTable dtXml = bll.FillDataTable("WCS.Sp_TaskProcess1", param);
                                Logger.Info("出库任务完成,任务号:" + taskNo );


                }
            }
        }
    }
}

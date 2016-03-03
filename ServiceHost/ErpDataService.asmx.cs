using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Xml;
using System.IO;
using Util;
using IServices;

namespace ServiceHost
{
    /// <summary>
    /// ErpDataService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ErpDataService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool transBatchInStock(string BillID,out string MSG)
        {
            MSG = "成功";
            bool bln = true;
            BLL.BLLBase bll = new BLL.BLLBase();

            DataTable dt = bll.FillDataTable("WMSServices.SelectBillSource", new DataParameter[] { new DataParameter("@BillID", BillID) });
            if (dt.Rows.Count > 0)
            {

                string strXML1 = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>" + Environment.NewLine + "<DATASETS>" + Environment.NewLine + "<DATASET>" + Environment.NewLine;

                string strXML2 = Environment.NewLine + "</DATASET>" + Environment.NewLine + "</DATASETS>" + Environment.NewLine;

                string strBillNo = "<BillNo>" + dt.Rows[0]["SourceBillNo"].ToString() + "</BillNo>" + Environment.NewLine;
                string strStatus = "<Status>1</Status>" + Environment.NewLine + "<ErrDesc></ErrDesc>" + Environment.NewLine;
                string strAmount = "<Amount>" + dt.Rows[0]["Amount"].ToString() + "</Amount>" + Environment.NewLine;

                string XML = strXML1 + strBillNo + strStatus + strAmount + strXML2;

                //调用Socket 

                


                string strResult = "";
                string IsUpErp = "1";

                DataSet xmlDS = Util.ConvertObj.XmlStringToDataSet(strResult);

                if (xmlDS.Tables[0].Rows.Count > 0)
                {
                    string strMsg = xmlDS.Tables[0].Rows[0][0].ToString();
                    if (strMsg.StartsWith("Y"))
                    {
                        IsUpErp = "1";
                    }
                    else
                    {
                        bln = false;
                        MSG = strMsg.Replace("N,", "");
                        IsUpErp = "0";
                    }

                }
                else
                {
                    bln = false;
                    MSG = "调用ERP服务，无返回值。";
                    IsUpErp = "0";
                }
                bll.ExecNonQuery("WMSServices.UpdateBillERP", new DataParameter[] { new DataParameter("@IsUpERP", IsUpErp),
                                                                                    new DataParameter("@ErpMSG", MSG),
                                                                                    new DataParameter("@BillID",  BillID)
                                                                                   });
            }
            else
            {
                bln = false;
                MSG = "WMS中不存在传入的单号" + BillID;
            }
            return bln;
        }

        [WebMethod]
        public bool transBatchOutStock(string BillID, out string MSG)
        {
            MSG = "成功";
            bool bln = true;
            BLL.BLLBase bll = new BLL.BLLBase();

            DataTable dt = bll.FillDataTable("WMSServices.SelectBillSource", new DataParameter[] { new DataParameter("@BillID", BillID) });
            if (dt.Rows.Count > 0)
            {

                string strXML1 = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>" + Environment.NewLine + "<DATASETS>" + Environment.NewLine + "<DATASET>" + Environment.NewLine;

                string strXML2 = Environment.NewLine + "</DATASET>" + Environment.NewLine + "</DATASETS>" + Environment.NewLine;

                string strBillNo = "<BillNo>" + dt.Rows[0]["SourceBillNo"].ToString() + "</BillNo>" + Environment.NewLine;
                string strStatus = "<Status>1</Status>" + Environment.NewLine + "<ErrDesc></ErrDesc>" + Environment.NewLine;
                string strAmount = "<Amount>" + dt.Rows[0]["Amount"].ToString() + "</Amount>" + Environment.NewLine;

                string XML = strXML1 + strBillNo + strStatus + strAmount + strXML2;
                
                //调用ERP
               
                string strResult = "";
                string IsUpErp = "1";

                DataSet xmlDS = Util.ConvertObj.XmlStringToDataSet(strResult);

                if (xmlDS.Tables[0].Rows.Count > 0)
                {
                    string strMsg = xmlDS.Tables[0].Rows[0][0].ToString();
                    if (strMsg.StartsWith("Y"))
                    {
                        IsUpErp = "1";
                    }
                    else
                    {
                        bln = false;
                        MSG = strMsg.Replace("N,", "");
                        IsUpErp = "0";
                    }

                }
                else
                {
                    bln = false;
                    MSG = "调用ERP服务，无返回值。";
                    IsUpErp = "0";
                }
                bll.ExecNonQuery("WMSServices.UpdateBillERP", new DataParameter[] { new DataParameter("@IsUpERP", IsUpErp),
                                                                                    new DataParameter("@ErpMSG", MSG),
                                                                                    new DataParameter("@BillID",  BillID)
                                                                                   });
            }
            else
            {
                bln = false;
                MSG = "WMS中不存在传入的单号" + BillID;
            }
            return bln;
        }

        [WebMethod]
        public bool transBatchCheckStock(string BillID,out string MSG)
        {
            MSG = "成功";
            bool bln = true;
            BLL.BLLBase bll = new BLL.BLLBase();

            DataTable dt = bll.FillDataTable("WMSServices.SelectBillSource", new DataParameter[] { new DataParameter("@BillID", BillID) });
            if (dt.Rows.Count > 0)
            {

                string strXML1 = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>" + Environment.NewLine + "<DATASETS>" + Environment.NewLine + "<DATASET>" + Environment.NewLine;

                string strXML2 = Environment.NewLine + "</DATASET>" + Environment.NewLine + "</DATASETS>" + Environment.NewLine;

                string strBillNo = "<BillNo>" + dt.Rows[0]["SourceBillNo"].ToString() + "</BillNo>" + Environment.NewLine;
                string strStatus = "<Status>1</Status>" + Environment.NewLine + "<ErrDesc></ErrDesc>" + Environment.NewLine;
                string strAmount = "<Amount>" + dt.Rows[0]["Amount"].ToString() + "</Amount>" + Environment.NewLine;

                string XML = strXML1 + strBillNo + strStatus + strAmount + strXML2;

                //调用ERP
                string strResult = "";
                string IsUpErp = "1";

                DataSet xmlDS = Util.ConvertObj.XmlStringToDataSet(strResult);

                if (xmlDS.Tables[0].Rows.Count > 0)
                {
                    string strMsg = xmlDS.Tables[0].Rows[0][0].ToString();
                    if (strMsg.StartsWith("Y"))
                    {
                        IsUpErp = "1";
                    }
                    else
                    {
                        bln = false;
                        MSG = strMsg.Replace("N,", "");
                        IsUpErp = "0";
                    }

                }
                else
                {
                    bln = false;
                    MSG = "调用ERP服务，无返回值。";
                    IsUpErp = "0";
                }
                bll.ExecNonQuery("WMSServices.UpdateBillERP", new DataParameter[] { new DataParameter("@IsUpERP", IsUpErp),
                                                                                    new DataParameter("@ErpMSG", MSG),
                                                                                    new DataParameter("@BillID",  BillID)
                                                                                   });
            }
            else
            {
                bln = false;
                MSG = "WMS中不存在传入的单号" + BillID;
            }
            return bln;
        }
    }
}

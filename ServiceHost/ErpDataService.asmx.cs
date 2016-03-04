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

                dt.DataSet.DataSetName = "DATASETS";
                dt.TableName = "DATASET";
                string XML = Util.ConvertObj.ConvertDataTableToXml(dt);

                ERP.ErpDataService erp = new ERP.ErpDataService();
                string strResult = erp.transBatchInStock(XML);

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

                dt.DataSet.DataSetName = "DATASETS";
                dt.TableName = "DATASET";
                string XML = Util.ConvertObj.ConvertDataTableToXml(dt);

                ERP.ErpDataService erp = new ERP.ErpDataService();
                string strResult = erp.transBatchOutStock(XML);
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

                dt.DataSet.DataSetName = "DATASETS";
                dt.TableName = "DATASET";
                string XML = Util.ConvertObj.ConvertDataTableToXml(dt);

                ERP.ErpDataService erp = new ERP.ErpDataService();
                string strResult = erp.transBatchCheckStock(XML);

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

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
    /// WMSDataService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class WMSDataService : System.Web.Services.WebService
    {
        /// <summary>
        /// WMS系统提供接收ERP系统下发物料信息的接口
        /// </summary>
        /// <param name="wmsProductObject"></param>
        /// <returns></returns>
        [WebMethod]
        public string transWmsProduct(string wmsProductObject)
        {
            DataSet xmlDS = Util.ConvertObj.XmlStringToDataSet(wmsProductObject);

            DataTable dt = xmlDS.Tables[0];

            string[] Comds = new string[dt.Rows.Count];
            List<DataParameter[]> paras = new List<DataParameter[]>();
            BLL.BLLBase bll = new BLL.BLLBase();
            string strProductCode = bll.GetNewID("CMD_Product", "ProductCode", "1=1");


            for (int i = 0; i < dt.Rows.Count; i++)
            { 
                DataRow dr = dt.Rows[i];

                int HasCount = bll.GetRowCount("CMD_Product", string.Format("ProductNo='{0}' and Spec='{1}'", dr["ProductOldCode"].ToString().Replace("'", "''"), dr["OldSize"].ToString().Replace("'", "''")));
               
                DataParameter[] para;
                if (HasCount > 0)
                {
                    Comds[i] = "WMSServices.UpdateProduct";

                    para = new DataParameter[] {    new DataParameter("@ProductCode",dr["ProductCode"].ToString()), 
                                                    new DataParameter("@ProductName",dr["ProductName"].ToString()),
                                                    new DataParameter("@ProductEName",dr["ProductEName"].ToString()),
                                                    new DataParameter("@Size",dr["Size"].ToString()),
                                                    new DataParameter("@AlloyTemper",dr["AlloyTemper"].ToString()),
                                                    new DataParameter("@Weight",dr["Weight"].ToString()),
                                                    new DataParameter("@ProductType",dr["ProductType"].ToString()),
                                                    new DataParameter("@StandardNo",dr["StandardNo"].ToString()),
                                                    new DataParameter("@PartNo",dr["PartNo"].ToString()),
                                                    new DataParameter("@Memo",dr["Memo"].ToString()),
                                                    new DataParameter("@ProductOldCode",dr["ProductOldCode"].ToString()),
                                                    new DataParameter("@OldSize",dr["OldSize"].ToString())
                                                };

                }
                else
                {
                    Comds[i] = "WMSServices.InsertProduct";
                    string strWmsProductCode =Util.Utility.NewID(strProductCode);
                    strProductCode = strWmsProductCode;
                    para = new DataParameter[] {    new DataParameter("@ProductWMSCode",strWmsProductCode),
                                                    new DataParameter("@ProductCode",dr["ProductCode"].ToString()), 
                                                    new DataParameter("@ProductName",dr["ProductName"].ToString()),
                                                    new DataParameter("@ProductEName",dr["ProductEName"].ToString()),
                                                    new DataParameter("@Size",dr["Size"].ToString()),
                                                    new DataParameter("@AlloyTemper",dr["AlloyTemper"].ToString()),
                                                    new DataParameter("@Weight",dr["Weight"].ToString()),
                                                    new DataParameter("@ProductType",dr["ProductType"].ToString()),
                                                    new DataParameter("@StandardNo",dr["StandardNo"].ToString()),
                                                    new DataParameter("@PartNo",dr["PartNo"].ToString()),
                                                    new DataParameter("@Memo",dr["Memo"].ToString())
                                               };

                }
                paras.Add(para);
            }
            string Msg = "成功";
            string bln = "Y";
          
            try
            {
                bll.ExecTran(Comds, paras);
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                bln = "N";
            }
            string result = bln + "," + Msg;
            string strXML = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>" + Environment.NewLine;
            strXML += "<DATASETS>" + Environment.NewLine;
            strXML += "<DATASET>" + Environment.NewLine;
            strXML += "<RESULT>" + result + "</RESULT>" + Environment.NewLine;
            strXML += "</DATASET>" +Environment.NewLine;
            strXML += "</DATASETS>" + Environment.NewLine;
            return strXML;
        }
        /// <summary>
        /// ERP系统为WMS提供批次入库信息
        /// </summary>
        /// <param name="wmsProductObject"></param>
        /// <returns></returns>
        [WebMethod]
        public string transInStock(string wmsInStockObject)
        {
            DataSet xmlDS = Util.ConvertObj.XmlStringToDataSet(wmsInStockObject);
            DataTable dt = xmlDS.Tables[0];

            string Msg = "成功";
            string bln = "Y";

            string result = bln + "," + Msg;
            string strXML1 = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>" + Environment.NewLine + "<DATASETS>" + Environment.NewLine + "<DATASET>" + Environment.NewLine;

            string strXML2 = Environment.NewLine + "</DATASET>" + Environment.NewLine + "</DATASETS>" + Environment.NewLine;

            string strResult = "<RESULT>" + result + "</RESULT>";
            BLL.BLLBase bll = new BLL.BLLBase();


            DataTable dtCode = dt.DefaultView.ToTable(true, "BillNo");
            if (dtCode.Rows.Count > 1)
            {
                bln = "N";
                Msg = "系统一次只能传送一个单号！";
                result = bln + "," + Msg;
                strResult = "<RESULT>" + result + "</RESULT>";
                return strXML1 + strResult + strXML2;
            }
            else if (dtCode.Rows.Count == 0)
            {
                bln = "N";
                Msg = "内容不能为空！";
                result = bln + "," + Msg;
                strResult = "<RESULT>" + result + "</RESULT>";
                return strXML1 + strResult + strXML2;
            }
            else
            {

                int HasCount = bll.GetRowCount("WMS_BillMaster", string.Format("SourceBillNo='{0}' and BillID like 'IS%'", dtCode.Rows[0]["BillNo"].ToString().Replace("'", "''")));
                if (HasCount > 0)
                {
                    bln = "N";
                    Msg = "单号" + dtCode.Rows[0]["BillNo"].ToString() + "已经传入WMS，不能再次传递！";
                    result = bln + "," + Msg;
                    strResult = "<RESULT>" + result + "</RESULT>";
                    return strXML1 + strResult + strXML2;
                }
            }

            int RowCount = dt.Rows.Count;

            string[] Comds = new string[RowCount + 4];
            List<DataParameter[]> paras = new List<DataParameter[]>();
            DataParameter[] para;
            Comds[0] = "WMSServices.DeleteBillTemp";
            para = new DataParameter[] { new DataParameter("@BillType","IS"),
                                         new DataParameter("@BillNo",dtCode.Rows[0][0].ToString())
                                        };



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Comds[i + 1] = "WMSServices.InsertBillTemp";
                para = new DataParameter[] { new DataParameter("@BillType","IS"), 
                                            new DataParameter("@BillNo",dr["BillNo"]),
                                            new DataParameter("@BillDate",dr["BillDate"]),
                                            new DataParameter("@BatchNo",dr["BatchNo"]),
                                            new DataParameter("@ProductCode",dr["ProductCode"]),
                                            new DataParameter("@Size",dr["Size"]),
                                            new DataParameter("@Weight",dr["Weight"]),
                                            new DataParameter("@Quantity",dr["Quantity"]),
                                            new DataParameter("@Memo",dr["Memo"]) 
                                                             
                                         };

                paras.Add(para);
            }
            string BillID = bll.GetAutoCodeByTableName("IS", "WMS_BillMaster", DateTime.Now, "1=1");

            Comds[RowCount + 1] = "WMSServices.InsertInStock";//插入主表
            para = new DataParameter[] { new DataParameter("@BillID", BillID), new DataParameter("@BillNo", dtCode.Rows[0][0].ToString()) };
            paras.Add(para);


            Comds[dt.Rows.Count + 2] = "WMSServices.InsertInStockDetail"; //从表
            para = new DataParameter[] { new DataParameter("@BillID", BillID), new DataParameter("@BillNo", dtCode.Rows[0][0].ToString()) };
            paras.Add(para);

            Comds[RowCount + 3] = "WMSServices.SpInstockTask";//入库作业
            para = new DataParameter[] { new DataParameter("@strWhere", "'" + BillID + "'"), new DataParameter("@UserName", "WebServices") };
            paras.Add(para);

            try
            {
                bll.ExecTran(Comds, paras);
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                bln = "N";
            }

            result = bln + "," + Msg;
            strResult = "<RESULT>" + result + "</RESULT>";
            return strXML1 + strResult + strXML2;

        }

        /// <summary>
        /// ERP系统为WMS提供批次出库信息
        /// </summary>
        /// <param name="wmsProductObject"></param>
        /// <returns></returns>
        [WebMethod]
        public string transOutStock(string wmsOutStockObject)
        {
            DataSet xmlDS = Util.ConvertObj.XmlStringToDataSet(wmsOutStockObject);
            DataTable dt = xmlDS.Tables[0];

            string Msg = "成功";
            string bln = "Y";

            string result = bln + "," + Msg;
            string strXML1 = "<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>" + Environment.NewLine + "<DATASETS>" + Environment.NewLine + "<DATASET>" + Environment.NewLine;

            string strXML2 = Environment.NewLine + "</DATASET>" + Environment.NewLine + "</DATASETS>" + Environment.NewLine;

            string strResult = "<RESULT>" + result + "</RESULT>";
            BLL.BLLBase bll = new BLL.BLLBase();


            DataTable dtCode = dt.DefaultView.ToTable(true, "BillNo");
            if (dtCode.Rows.Count > 1)
            {
                bln = "N";
                Msg = "系统一次只能传送一个单号！";
                result = bln + "," + Msg;
                strResult = "<RESULT>" + result + "</RESULT>";
                return strXML1 + strResult + strXML2;
            }
            else if (dtCode.Rows.Count == 0)
            {
                bln = "N";
                Msg = "内容不能为空！";
                result = bln + "," + Msg;
                strResult = "<RESULT>" + result + "</RESULT>";
                return strXML1 + strResult + strXML2;
            }
            else
            {

                int HasCount = bll.GetRowCount("WMS_BillMaster", string.Format("SourceBillNo='{0}' and BillID like 'OS%'", dtCode.Rows[0]["BillNo"].ToString().Replace("'", "''")));
                if (HasCount > 0)
                {
                    bln = "N";
                    Msg = "单号" + dtCode.Rows[0]["BillNo"].ToString() + "已经传入WMS，不能再次传递！";
                    result = bln + "," + Msg;
                    strResult = "<RESULT>" + result + "</RESULT>";
                    return strXML1 + strResult + strXML2;
                }
            }

            int RowCount = dt.Rows.Count;

            string[] Comds = new string[RowCount + 4];
            List<DataParameter[]> paras = new List<DataParameter[]>();
            DataParameter[] para;
            Comds[0] = "WMSServices.DeleteBillTemp";
            para = new DataParameter[] { new DataParameter("@BillType","OS"),
                                         new DataParameter("@BillNo",dtCode.Rows[0][0].ToString())
                                        };



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Comds[i + 1] = "WMSServices.InsertBillTemp";
                para = new DataParameter[] { new DataParameter("@BillType","OS"), 
                                            new DataParameter("@BillNo",dr["BillNo"]),
                                            new DataParameter("@BillDate",dr["BillDate"]),
                                            new DataParameter("@BatchNo",dr["BatchNo"]),
                                            new DataParameter("@ProductCode",dr["ProductCode"]),
                                            new DataParameter("@Size",dr["Size"]),
                                            new DataParameter("@Weight",dr["Weight"]),
                                            new DataParameter("@Quantity",dr["Quantity"]),
                                            new DataParameter("@Memo",dr["Memo"]) 
                                                             
                                         };

                paras.Add(para);
            }
            string BillID = bll.GetAutoCodeByTableName("OS", "WMS_BillMaster", DateTime.Now, "1=1");

            Comds[RowCount + 1] = "WMSServices.InsertOutStock";//插入主表
            para = new DataParameter[] { new DataParameter("@BillID", BillID), new DataParameter("@BillNo", dtCode.Rows[0][0].ToString()) };
            paras.Add(para);


            Comds[dt.Rows.Count + 2] = "WMSServices.InsertOutStockDetail"; //从表
            para = new DataParameter[] { new DataParameter("@BillID", BillID), new DataParameter("@BillNo", dtCode.Rows[0][0].ToString()) };
            paras.Add(para);

            Comds[RowCount + 3] = "WMSServices.SpOutStockTask";//入库作业
            para = new DataParameter[] { new DataParameter("@strWhere", "'" + BillID + "'"), new DataParameter("@UserName", "WebServices") };
            paras.Add(para);

            try
            {
                bll.ExecTran(Comds, paras);
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                bln = "N";
            }

            result = bln + "," + Msg;
            strResult = "<RESULT>" + result + "</RESULT>";
            return strXML1 + strResult + strXML2;
        }



    }
}

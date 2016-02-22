using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Xml;
using System.IO;

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
            DataSet xmlDS = new DataSet();
            StringReader stream = new StringReader(wmsProductObject);
            XmlTextReader reader = new XmlTextReader(stream);
            xmlDS.ReadXml(reader);


            



            return "";
 
        }
        /// <summary>
        /// ERP系统为WMS提供批次入库信息
        /// </summary>
        /// <param name="wmsProductObject"></param>
        /// <returns></returns>
        [WebMethod]
        public string transInStock(string wmsInStockObject)
        {
            DataSet xmlDS = new DataSet();
            StringReader stream = new StringReader(wmsInStockObject);
            XmlTextReader reader = new XmlTextReader(stream);
            xmlDS.ReadXml(reader);





            return "";

        }

        /// <summary>
        /// ERP系统为WMS提供批次出库信息
        /// </summary>
        /// <param name="wmsProductObject"></param>
        /// <returns></returns>
        [WebMethod]
        public string transOutStock(string wmsOutStockObject)
        {
            DataSet xmlDS = new DataSet();
            StringReader stream = new StringReader(wmsOutStockObject);
            XmlTextReader reader = new XmlTextReader(stream);
            xmlDS.ReadXml(reader);





            return "";

        }



    }
}

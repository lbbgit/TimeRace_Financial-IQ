using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Xml;
namespace TimeRace_Financial_IQ
{
    /// <summary>
    /// HandlerFactory 的摘要说明
    /// </summary>
    public class HandlerFactory : IHttpHandler
    {
        DataBase.SqlServer_DBHelper sqlserver_DbHelper = new DataBase.SqlServer_DBHelper();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain"; 
            string action = context.Request.QueryString["action"];  
            string result = string.Empty;
            if (string.IsNullOrEmpty(action)) 
                return; 

            switch (action)
            {
                case "test": result = test(); break;
                case "sql": result = sql(context); break;
            }
            context.Response.Write(result);
        }

        //测试方法,随时变更
        private string test()
        {
            DataTable dt = sqlserver_DbHelper.GetDataTable("select * from dual");
            string result = Convert.ToString(dt.Rows[0][0]);
            return "alert('" + result + "')";
        }

        private string sql(HttpContext context)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(context.Request.InputStream);
            string sql = "";
            DataTable dt=sqlserver_DbHelper.GetDataTable(sql);
            //System.IO.Stream stream = new System.IO.Stream();
            //dt.WriteXml(stream, false);
            return "";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
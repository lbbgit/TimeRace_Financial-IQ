using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace TimeRace_Financial_IQ.app
{
    /// <summary>
    /// GetDataTable 的摘要说明
    /// </summary>
    public class GetDataTable : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string strResult = "";
            string action = context.Request.QueryString["action"];
            switch (action)
            {
                case "GetDataTable": strResult = DataTable2String(ExecuteSql_GetDataTable(context)); break;
            }

            context.Response.Write(strResult);
        }

        DataTable ExecuteSql_GetDataTable(HttpContext context)
        {
            string sql = context.Request.QueryString["sql"];
            DataSet ds = new DataSet();

            return ds.Tables[0];
        }

        string DataTable2String(DataTable dt)
        {
            char c=',' , spliter=';';
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn dc in dt.Columns)
                sb.Append(dc.ColumnName).Append(c);
            sb.Append(spliter);

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                    sb.Append(dr[dc.ColumnName]).Append(c);
                sb.Append(spliter);
            }
            return sb.ToString();
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
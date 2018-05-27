using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using InitSeed.Common.Tools;
namespace InitSeed.test
{
    /// <summary>
    /// GetData 的摘要说明
    /// </summary>
    public class TestAshx : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            string strAction = context.Request["action"];
            string result = "";
            switch (strAction)
            {
                case "test1":
                    result = GetTable();
                    break;
                case "testL":
                    result=testL();
                    break;
            }
            context.Response.Write(strAction + "|" + result);
        }

        private string GetTable()
        {
             
            DataSet ds = new DataSet();
            ds.Tables.Add("tab"); 

            string result= ds.GetXml();
            return result;
        }


        /// <summary>
        /// xml:2048  json:47,差距为47倍呢！
        /// </summary>
        /// <returns></returns>
        public static string testL()
        {
            DataSet ds = new DataSet();
            //DataTable dt1 = DataTableTools.DataTable32();
            //DataTable dt2 = DataTableTools.DataTable32("tb2", 2, 2);
            //DataTable dt3 = DataTableTools.DataTable32("tb3", 3, 3);
            //ds.Tables.Add(dt1);
            //ds.Tables.Add(dt2);
            //ds.Tables.Add(dt3);
            ds.Tables.Add("dt1");
            ds.Tables[0].Columns.Add("a");
            ds.Tables[0].Columns.Add("b");
            ds.Tables[0].Rows.Add(new object[] { 1, "2" });
            ds.Tables[0].Rows.Add(new object[] { null, DBNull.Value });
            ds.AcceptChanges();
            byte[] xml = SerializeTools.SerializeObject(ds);
            int ixml = xml.Length;
            DataSet ds2 = (DataSet)SerializeTools.DeserializeObject(xml);

            string json = JsonTools.ToJSON(ds);
            int ijson = json.Length;//{"dt1":[{"a":"1","b":"2"},{"a":null,"b":null}]}
            DataSet ds3 = JsonTools.FromJSON<DataSet>(json);

            return "xml:" + ixml + "  json:" + ijson
                + "\r\n" + xml + "\r\n" + json;
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
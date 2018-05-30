using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDTek.Oracle;
namespace InitSeed
{
    /// <summary>
    /// GetData 的摘要说明
    /// </summary>
    public class GetData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            string strAction = context.Request["action"];
            string result = "";
            switch (strAction)
            {
                case "test1":
                    result = GetTable();
                    break;

                case "GetHtmls":
                    result = GetHtmls(context);
                    break;
            }
            //context.Response.Write(strAction + "|" + result);
            context.Response.Write(result);
        }

        private string GetTable()
        {
            string connectionString = "Data Source=Orcl154;User Id=TDM_TC;Password=sa;Integrated Security=no;";
            connectionString = "Host=192.168.2.154;Port=1521;User ID=tdm_tc;Password=sa; Service Name=ORCL;Alternate Servers=(Host=192.168.2.154;Port=1521;Service Name=ORCL)";
            connectionString = "Host=192.168.2.154;Port=1521;User ID=TDM_TC;Password=sa;Service Name=ORCL";
            DDTek.Oracle.OracleConnection ocon = new OracleConnection(connectionString);
            OracleCommand ocmd = new OracleCommand("select * from dps_user", ocon);
            OracleDataAdapter oAdp = new OracleDataAdapter(ocmd);
            ocon.Open();
            DataSet ds = new DataSet();
            oAdp.Fill(ds);
            ocon.Close();

            string result= ds.GetXml();
            return result;
        }

        private string GetHtmls(HttpContext context)
        {
            string root = context.Server.MapPath("/");
            string[] files=System.IO.Directory.GetFiles(root,"*.htm*",System.IO.SearchOption.AllDirectories);

            StringBuilder sb = new StringBuilder();
            string t;
            int begin=root.Length;
            foreach (string file in files)
            {
                t = file.Substring(begin).Replace("\\","/");
                sb.Append('/').Append(t).Append("|");
            }
            return sb.ToString(0, sb.Length - 1);
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
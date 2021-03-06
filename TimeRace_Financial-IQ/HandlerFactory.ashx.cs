﻿using System;
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
                case "UnNullFolder": result = UnNullFolder(context); break;
                case "UnNullFolderView": result = UnNullFolder_View(context); break;
                case "UnNullFilesFolder": result = UnNullFilesFolder(context); break;
                case "UnNullFilesFolderView": result = UnNullFilesFolder_View(context); break;
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

        private string UnNullFolder_View(HttpContext context)
        {
            string folder = context.Request.QueryString["Folder"];
            return ListToString(FolderUnNull.NuNull(folder, false)); 
        }

        private string UnNullFolder(HttpContext context)
        {
            string folder = context.Request.QueryString["Folder"];
            return ListToString(FolderUnNull.NuNull(folder));
        }
        private string UnNullFilesFolder_View(HttpContext context)
        {
            string folder = context.Request.QueryString["Folder"];
            return ListToString(FolderUnNull.NuNullFiles(folder, false));
        }

        private string UnNullFilesFolder(HttpContext context)
        {
            string folder = context.Request.QueryString["Folder"];
            return ListToString(FolderUnNull.NuNullFiles(folder));
        }
        private string ListToString(List<string> a)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in a)
            {
                sb.Append(a).Append(',');
            }
            return sb.ToString();
        }
        private string sql(HttpContext context)
        {
            XmlDocument doc = new XmlDocument();
            string sql = "";
            try
            {
                doc.Load(context.Request.InputStream);
                string strSQL = doc.DocumentElement.GetAttribute("SQL").Trim();
                string rtype = doc.DocumentElement.GetAttribute("rtype");
                DataTable dt = sqlserver_DbHelper.GetDataTable(sql);
                //System.IO.Stream stream = new System.IO.Stream();
                //dt.WriteXml(stream, false);
                return "u run sql";
            }
            catch (Exception e)
            {
                return e.Message;
            }
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
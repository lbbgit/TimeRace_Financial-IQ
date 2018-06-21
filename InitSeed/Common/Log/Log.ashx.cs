using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Xml;

namespace InitSeed.Common.Log
{
    /// <summary>
    /// Log的摘要说明,分工这么明确,反而无法开发了,额.
    /// </summary>
    public class Log : IHttpHandler 
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //init static parameters
            if (RootPath == null)
                RootPath = context.Request.MapPath("/Log");
            if (XmlRootPath == null)
                XmlRootPath = context.Request.MapPath("/Log/xml/");


            string action = context.Request.QueryString["action"];
            string result ="";
            switch (action)
            {
                case "SaveXml":
                    SaveXml(context.Request.InputStream);
                    break;
            } 
            context.Response.Write(result);
            context.Response.End();
        }

        public static string RootPath = null;
        public static string XmlRootPath = null; 

        

        void SaveXml(Stream stream)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(stream);
            SaveXmlString(xDoc.OuterXml);
        }


        static Random rd = new Random();
        //static string xmlPath;
        static string AsmxFileName = "[Common][Log][Log.ashx]";
        //保存xml报文信息
        void SaveXmlString(string xml, string method="", string condition="",
            string _asmxFileName = "")
        {
            if (string.IsNullOrWhiteSpace(xml))
                return;
            if (string.IsNullOrWhiteSpace(_asmxFileName))
                _asmxFileName = AsmxFileName;
            if (!System.IO.Directory.Exists(XmlRootPath))
                System.IO.Directory.CreateDirectory(XmlRootPath);

            string fileFullName = XmlRootPath + "\\" + condition + "_" + method + "_"
                + System.DateTime.Now.ToString("yyyyMMddhhmiss")
                + rd.Next(Int32.MaxValue) + "_" + _asmxFileName + ".xml";
            System.IO.File.AppendAllText(fileFullName, xml, Encoding.Default);
        }
         
    }


}


public class AshxCommon
{
    //public override bool useContent = false;
    public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.QueryString["action"];
            string result = Case(action);
            //如果上面的不处理,或返回空,则走处理HttpContext的方法
            if (string.IsNullOrWhiteSpace(result))
                result = Case(action, context);
           
            context.Response.Write(result);
            context.Response.End();
        }

    public override string Case(string action)
    {
        return string.Empty;
    }
    public override string Case(string action, HttpContext context)
    {
        return string.Empty;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}

public class StaticString
{

}
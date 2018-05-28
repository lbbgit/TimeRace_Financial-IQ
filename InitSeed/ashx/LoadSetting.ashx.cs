using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InitSeed.ashx
{
    /// <summary>
    /// 加载设置，去除注释，短小精悍xml/json片段
    /// </summary>
    public class LoadSetting : IHttpHandler
    {
        static Dictionary<string, string> KeySetting = new Dictionary<string, string>();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }


        static void RefreshSetting(string key)
        {
            KeySetting.Remove(key);
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
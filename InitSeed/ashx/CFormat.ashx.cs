using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InitSeed.ashx
{
    /// <summary>
    /// CFormat 的摘要说明
    /// </summary>
    public class CFormat : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = "";
            context.Response.Write(result);
        }

        string Format(string[] strs, string format,bool ignoreNoneRows=true, char splitChars  =',')
        {
            string[] results = strs;
            for (int i = 0; i < strs.Length; i++)
            {
                bool isNul=string.IsNullOrWhiteSpace(strs[i]);
                if (isNul && ignoreNoneRows)
                {
                    results[i] = "";
                }

            }
            return null;
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
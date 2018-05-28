using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InitSeed.ashx
{
    /// <summary>
    /// 依据模型，生成类模型getset；查询sql，更新sql。
    /// 代码批量生成器，简易版v0.0
    /// </summary>
    public class GetCSFromModel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TimeRace_Financial_IQ.asmx
{
    /// <summary>
    /// _2 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class _2 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        ///<summary>
        /// MES从TDM获取产品测试任务详情
        /// </summary>
        [WebMethod(Description = "MES从TDM获取产品测试任务详情")]
        public string getTestTaskDetail(string productProjectCode, string step1, string[] testTaskID, string step2)
        {
            string str = (testTaskID != null && testTaskID.Length > 0) ? testTaskID[0] : productProjectCode;
            return str;  
        }
    }
}

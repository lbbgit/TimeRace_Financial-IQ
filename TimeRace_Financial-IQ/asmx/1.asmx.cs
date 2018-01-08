using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Common;
using System.Collections;
using System.Collections.Generic;
namespace TimeRace_Financial_IQ.asmx
{
    /// <summary>
    /// _11 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class _11 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string TestSoap1()
        {

            return ""; 
        }

        [WebMethod]
        public string TestSoap2()
        {

            return "";
        }

        /// <summary>
        /// MES从TDM获取产品测试任务列表
        /// </summary>
        [WebMethod(Description = "MES从TDM获取产品测试任务列表")]
        public string getTestTaskList(string productProjectCode,string step1, string[] testTaskID, string step2)
        {
            string str = (testTaskID != null && testTaskID.Length > 0) ? testTaskID[0] : productProjectCode;
            return str; 
        }



        [WebMethod(Description = "test1cs")]
        public string test1cs(string method = "getTestTaskDetail", string url = @"http://localhost:15981/asmx/2.asmx")
        {
            if (string.IsNullOrWhiteSpace(method))
                method = "getTestTaskDetail";
            if (string.IsNullOrWhiteSpace(url))
                url = @"http://localhost:15981/asmx/2.asmx";

            //注意引用自定义代码
            //拼接的xml字符串，根据需求自行拼接
            string xmlRequest = "<root>" +
                                              "<SystemId>" + "2333" + "</SystemId>" +
                                              "<ServiceType>N02</ServiceType>" +
                                              "<CardNo></CardNo>" +
                                              "<IDCardNo>" + "id001" + "</IDCardNo>" +
                                              "</root>";
            string[] strs = new string[] { "_1_", "2", "3" };
            //转换字符为hash
            Hashtable htParms = new Hashtable
                {
                    //多个参数可定义多个{}，中间用'，'隔开
                    { "p1", xmlRequest },
                    { "p2", strs }
                };

            string result = "";
            try
            {
                //调用soap，返回字符串
                result = WdFuncWsCaller.SoapWebServiceString( url , method, htParms);
                return result;
            }
            catch (Exception e)
            {
                //这里返回错误信息，根据需求自行修改
                return "请求出错！" + e.Message; ;
            }
        }
    }
}

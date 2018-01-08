using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.CSharp;

namespace Common//Wonders.InterfaceGuiYang.Services.
{
    /// <summary>
    /// 利用WebRequest/WebResponse进行WebService调用的类
    /// </summary>
    public class WdFuncWsCaller
    {
        //缓存xmlNamespace，避免重复调用GetNamespace
        private static readonly Hashtable XmlNamespace = new Hashtable();

        #region SOAP动态调用

        /// <summary>
        /// 通过SOAP协议动态调用webservice 
        /// </summary>
        /// <param name="url"> webservice地址</param>
        /// <param name="methodName"> 调用方法名</param>
        /// <param name="pars"> 参数表</param>
        /// <returns> 结果集xml的String格式</returns>
        public static String SoapWebServiceString(String url, String methodName, Hashtable pars)
        {
            XmlDocument doc = SoapWebService(url, methodName, pars);
            return doc.InnerText;
        }
        /// <summary>
        /// 通过SOAP协议动态调用webservice 
        /// </summary>
        /// <param name="url"> webservice地址</param>
        /// <param name="methodName"> 调用方法名</param>
        /// <param name="pars"> 参数表</param>
        /// <returns> 结果集转换的DataSet</returns>
        public static DataSet SoapWebServiceDataSet(String url, String methodName, Hashtable pars)
        {
            XmlDocument doc = SoapWebService(url, methodName, pars);
            System.Data.DataSet ds = new System.Data.DataSet();
            using (XmlNodeReader reader = new XmlNodeReader(doc))
            {
                ds.ReadXml(reader);
            }
            return ds;
        }
        /// <summary>
        /// 通过SOAP协议动态调用webservice 
        /// </summary>
        /// <param name="url"> webservice地址</param>
        /// <param name="methodName"> 调用方法名</param>
        /// <param name="pars"> 参数表</param>
        /// <returns> 结果集XmlDocument</returns>
        public static XmlDocument SoapWebService(String url, String methodName, Hashtable pars)
        {
            if (XmlNamespace.ContainsKey(url))
            {   // 名字空间在缓存中存在时，读取缓存，然后执行调用
                return QuerySoapWebService(url, methodName, pars, XmlNamespace[url].ToString());
            }
            // 名字空间不存在时直接从wsdl的请求中读取名字空间，然后执行调用
            return QuerySoapWebService(url, methodName, pars, GetNamespace(url));
        }
        /// <summary>
        /// 通过SOAP协议动态调用webservice  
        /// </summary>
        /// <param name="url"> webservice地址</param>
        /// <param name="methodName"> 调用方法名</param>
        /// <param name="pars"> 参数表</param>
        /// <param name="xmlNs"> 名字空间</param>
        /// <returns> 结果集</returns>
        private static XmlDocument QuerySoapWebService(String url, String methodName, Hashtable pars, string xmlNs)
        {
            XmlNamespace[url] = xmlNs;//加入缓存，提高效率
            // 获取请求对象
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // 设置请求head
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.Headers.Add("SOAPAction", "\"" + xmlNs + (xmlNs.EndsWith("/") ? "" : "/") + methodName + "\"");
            // 设置请求身份
            SetWebRequest(request);
            // 获取soap协议
            byte[] data = EncodeParsToSoap(pars, xmlNs, methodName);
            // 将soap协议写入请求
            WriteRequestData(request, data);
            XmlDocument returnDoc = new XmlDocument();
            XmlDocument returnValueDoc = new XmlDocument();
            // 读取服务端响应
            returnDoc = ReadXmlResponse(request.GetResponse());

            XmlNamespaceManager mgr = new XmlNamespaceManager(returnDoc.NameTable);
            mgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            // 返回结果
            string retXml = returnDoc.SelectSingleNode("//soap:Body/*/*", mgr).InnerXml;

            returnValueDoc.LoadXml("<root>" + retXml + "</root>");
            AddDelaration(returnValueDoc);

            /*  System.Data.DataSet ds = new System.Data.DataSet();
              XmlNodeReader reader = new XmlNodeReader(returnValueDoc);
              ds.ReadXml(reader);*/

            // return returnValueDoc.OuterXml;

            return returnValueDoc;
        }
        /// <summary>
        /// 获取wsdl中的名字空间
        /// </summary>
        /// <param name="url"> wsdl地址</param>
        /// <returns> 名字空间</returns>
        private static string GetNamespace(String url)
        {
            // 创建wsdl请求对象，并从中读取名字空间
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?WSDL");
            SetWebRequest(request);
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sr.ReadToEnd());
            sr.Close();
            return doc.SelectSingleNode("//@targetNamespace").Value;
        }
        /// <summary>
        /// 加入soapheader节点
        /// </summary>
        /// <param name="doc"> soap文档</param>
        private static void InitSoapHeader(XmlDocument doc)
        {
            // 添加soapheader节点
            XmlElement soapHeader = doc.CreateElement("soap", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            ////如需使用soapheader把下面代码注释取消，根据配置自行修改
            //XmlElement soapId = doc.CreateElement("userid");
            //soapId.InnerText = ID;
            //XmlElement soapPwd = doc.CreateElement("userpwd");
            //soapPwd.InnerText = PWD;
            //soapHeader.AppendChild(soapId);
            //soapHeader.AppendChild(soapPwd);
            doc.ChildNodes[0].AppendChild(soapHeader);
        }
        /// <summary>
        /// 将以字节数组的形式返回soap协议
        /// </summary>
        /// <param name="pars"> 参数表</param>
        /// <param name="xmlNs"> 名字空间</param>
        /// <param name="methodName"> 方法名</param>
        /// <returns> 字节数组</returns>
        private static byte[] EncodeParsToSoap(Hashtable pars, String xmlNs, String methodName)
        {
            XmlDocument doc = new XmlDocument();
            // 构建soap文档
            doc.LoadXml("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"></soap:Envelope>");

            // 加入soapbody节点
            InitSoapHeader(doc);

            // 创建soapbody节点
            XmlElement soapBody = doc.CreateElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            // 根据要调用的方法创建一个方法节点
            XmlElement soapMethod = doc.CreateElement(methodName);
            soapMethod.SetAttribute("xmlns", xmlNs);
            // 遍历参数表中的参数键
            foreach (string key in pars.Keys)
            {
                // 根据参数表中的键值对，生成一个参数节点，并加入方法节点内
                XmlElement soapPar = doc.CreateElement(key);
                soapPar.InnerXml = ObjectToSoapXml(pars[key]);
                soapMethod.AppendChild(soapPar);
            }

            // soapbody节点中加入方法节点
            soapBody.AppendChild(soapMethod);

            // soap文档中加入soapbody节点
            doc.DocumentElement.AppendChild(soapBody);

            // 添加声明
            AddDelaration(doc);

            // 传入的参数有DataSet类型，必须在序列化后的XML中的diffgr:diffgram/NewDataSet节点加xmlns='' 否则无法取到每行的记录。
            XmlNode node = doc.DocumentElement.SelectSingleNode("//NewDataSet");
            if (node != null)
            {
                XmlAttribute attr = doc.CreateAttribute("xmlns");
                attr.InnerText = "";
                node.Attributes.Append(attr);
            }
            // 以字节数组的形式返回soap文档
            return Encoding.UTF8.GetBytes(doc.OuterXml);
        }
        /// <summary>
        /// 将参数对象中的内容取出
        /// </summary>
        /// <param name="o">参数值对象</param>
        /// <returns>字符型值对象</returns>
        private static string ObjectToSoapXml(object o)
        {
            XmlSerializer mySerializer = new XmlSerializer(o.GetType());
            MemoryStream ms = new MemoryStream();
            mySerializer.Serialize(ms, o);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
            if (doc.DocumentElement != null)
            {
                return doc.DocumentElement.InnerXml;
            }
            return o.ToString();
        }
        /// <summary>
        /// 设置请求身份
        /// </summary>
        /// <param name="request"> 请求</param>
        private static void SetWebRequest(HttpWebRequest request)
        {
            request.Credentials = CredentialCache.DefaultCredentials;
            //request.Timeout = 10000;
        }
        /// <summary>
        /// 将soap协议写入请求
        /// </summary>
        /// <param name="request"> 请求</param>
        /// <param name="data"> soap协议</param>
        private static void WriteRequestData(HttpWebRequest request, byte[] data)
        {
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
        }
        /// <summary>
        /// 将响应对象读取为xml对象
        /// </summary>
        /// <param name="response"> 响应对象</param>
        /// <returns> xml对象</returns>
        private static XmlDocument ReadXmlResponse(WebResponse response)
        {
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            sr.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(retXml);
            return doc;
        }
        /// <summary>
        /// 给xml文档添加声明
        /// </summary>
        /// <param name="doc"> xml文档</param>
        private static void AddDelaration(XmlDocument doc)
        {
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.InsertBefore(decl, doc.DocumentElement);
        }

        #endregion

        #region 普通方法调用

        /// <summary>
        /// 获取WebService类型
        /// </summary>
        /// <param name="wsUrl">WebService地址</param>
        /// <returns></returns>
        private static string GetClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');
            return pps[0];
        }
        /// <summary>
        /// 调用WebService
        /// </summary>
        /// <param name="wsUrl">WebService地址</param>
        /// <param name="methodName">方法名称</param>
        /// <param name="hashtable">参数列表</param>
        /// <returns></returns>
        public static object InvokeWebService(string wsUrl, string methodName, Hashtable hashtable)
        {
            return InvokeWebService(wsUrl, null, methodName, hashtable);
        }
        /// <summary>
        /// 调用WebService
        /// </summary>
        /// <param name="wsUrl">WebService地址</param>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名称</param>
        /// <param name="hashtable">参数列表</param>
        /// <returns></returns>
        public static object InvokeWebService(string wsUrl, string className, string methodName, Hashtable hashtable)
        {
            object[] args = Hashtable2Object(hashtable);
            const string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
            if (string.IsNullOrEmpty(className))
            {
                className = GetClassName(wsUrl);
            }
            try
            {
                //获取WSDL
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(wsUrl + "?wsdl");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);
                //生成客户端代理类代码
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                // ReSharper disable once CSharpWarnings::CS0618
                ICodeCompiler icc = csc.CreateCompiler();
                //设定编译参数
                CompilerParameters cplist = new CompilerParameters { GenerateExecutable = false, GenerateInMemory = true };
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");
                //编译代理类
                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                if (cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce);
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
                //生成代理实例，并调用方法
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + className, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(methodName);
                return mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }
        /// <summary>
        /// Hashtable转对象数组
        /// </summary>
        /// <param name="hashtable"></param>
        /// <returns></returns>
        private static object[] Hashtable2Object(Hashtable hashtable)
        {
            object[] args = new object[hashtable.Count];
            int i = 0;
            foreach (DictionaryEntry dictionary in hashtable)
            {
                args[i] = dictionary.Value.ToString();
                i++;
            }
            return args;
        }

        #endregion

    }
}
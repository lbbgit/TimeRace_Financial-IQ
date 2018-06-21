using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Xml;
using log4net;
using log4net.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InitSeed.Common.Log
{
    /// <summary>
    /// Log的摘要说明,分工这么明确,反而无法开发了,额.
    /// </summary>
    public class FastLog : IHttpHandler 
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


    /*
     需要在程序启动时注册，如asp.net 程序中在Global.asax中的Application_Start注册。 
     */
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            FlashLogger.Instance().Register();
        }

        public static void Use()
        {
            FlashLogger.Debug("Debug");
            FlashLogger.Debug("Debug", new Exception("testexception"));
            FlashLogger.Info("Info");
            FlashLogger.Fatal("Fatal");
            FlashLogger.Error("Error");
            FlashLogger.Warn("Warn", new Exception("testexception"));
        }
    }


    //速度缓存写日志
    public sealed class FlashLogger
    {
        /// <summary>
        /// 记录消息Queue
        /// </summary>
        private readonly ConcurrentQueue<FlashLogMessage> _que;

        /// <summary>
        /// 信号
        /// </summary>
        private readonly ManualResetEvent _mre;

        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// 日志
        /// </summary>
        private static FlashLogger _flashLog = new FlashLogger();


        private FlashLogger()
        {
            var configFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config"));
            if (!configFile.Exists)
            {
                throw new Exception("未配置log4net配置文件！");
            }

            // 设置日志配置文件路径
            XmlConfigurator.Configure(configFile);

            _que = new ConcurrentQueue<FlashLogMessage>();
            _mre = new ManualResetEvent(false);
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// 实现单例
        /// </summary>
        /// <returns></returns>
        public static FlashLogger Instance()
        {
            return _flashLog;
        }

        /// <summary>
        /// 另一个线程记录日志，只在程序初始化时调用一次
        /// </summary>
        public void Register()
        {
            Thread t = new Thread(new ThreadStart(WriteLog));
            t.IsBackground = false;
            t.Start();
        }

        /// <summary>
        /// 从队列中写日志至磁盘
        /// </summary>
        private void WriteLog()
        {
            while (true)
            {
                // 等待信号通知
                _mre.WaitOne();

                FlashLogMessage msg;
                // 判断是否有内容需要如磁盘 从列队中获取内容，并删除列队中的内容
                while (_que.Count > 0 && _que.TryDequeue(out msg))
                {
                    // 判断日志等级，然后写日志
                    switch (msg.Level)
                    {
                        case FlashLogLevel.Debug:
                            _log.Debug(msg.Message, msg.Exception);
                            break;
                        case FlashLogLevel.Info:
                            _log.Info(msg.Message, msg.Exception);
                            break;
                        case FlashLogLevel.Error:
                            _log.Error(msg.Message, msg.Exception);
                            break;
                        case FlashLogLevel.Warn:
                            _log.Warn(msg.Message, msg.Exception);
                            break;
                        case FlashLogLevel.Fatal:
                            _log.Fatal(msg.Message, msg.Exception);
                            break;
                    }
                }

                // 重新设置信号
                _mre.Reset();
                Thread.Sleep(1);
            }
        }


        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志文本</param>
        /// <param name="level">等级</param>
        /// <param name="ex">Exception</param>
        public void EnqueueMessage(string message, FlashLogLevel level, Exception ex = null)
        {
            if ((level == FlashLogLevel.Debug && _log.IsDebugEnabled)
             || (level == FlashLogLevel.Error && _log.IsErrorEnabled)
             || (level == FlashLogLevel.Fatal && _log.IsFatalEnabled)
             || (level == FlashLogLevel.Info && _log.IsInfoEnabled)
             || (level == FlashLogLevel.Warn && _log.IsWarnEnabled))
            {
                _que.Enqueue(new FlashLogMessage
                {
                    Message = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + "]\r\n" + message,
                    Level = level,
                    Exception = ex
                });

                // 通知线程往磁盘中写日志
                _mre.Set();
            }
        }

        public static void Debug(string msg, Exception ex = null)
        {
            Instance().EnqueueMessage(msg, FlashLogLevel.Debug, ex);
        }

        public static void Error(string msg, Exception ex = null)
        {
            Instance().EnqueueMessage(msg, FlashLogLevel.Error, ex);
        }

        public static void Fatal(string msg, Exception ex = null)
        {
            Instance().EnqueueMessage(msg, FlashLogLevel.Fatal, ex);
        }

        public static void Info(string msg, Exception ex = null)
        {
            Instance().EnqueueMessage(msg, FlashLogLevel.Info, ex);
        }

        public static void Warn(string msg, Exception ex = null)
        {
            Instance().EnqueueMessage(msg, FlashLogLevel.Warn, ex);
        }

    }

    /// <summary>
    /// 日志等级
    /// </summary>
    public enum FlashLogLevel
    {
        Debug,
        Info,
        Error,
        Warn,
        Fatal
    }


    /// <summary>
    /// 日志内容
    /// </summary>
    public class FlashLogMessage
    {
        public string Message { get; set; }
        public FlashLogLevel Level { get; set; }
        public Exception Exception { get; set; }

    }





}
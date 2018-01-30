using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace TimeRace_Financial_IQ
{
    class Telnet1
    {
        public static NetworkStream stream;
        public static TcpClient tcpclient;
        public static string ip;
        public static int port;
       
        static public void RunTelnet()
        {
            tcpclient = new TcpClient(ip, port);  // 连接服务器
            stream = tcpclient.GetStream();   // 获取网络数据流对象
            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(stream);
            while (true)
            {
                //Read Echo
                //Set ReadEcho Timeout
                stream.ReadTimeout = 10;
                try
                {
                    while (true)
                    {                        
                            char c = (char)sr.Read();
                            if (c < 256)
                            {
                                if (c == 27)
                                {
                                    while (sr.Read() != 109) { }
                                }
                                else
                                {
                                    Console.Write(c);
                                }
                            }
                    }
                }
                catch
                {
                    
                }
                //Send CMD
                sw.Write("{0}\r\n", Console.ReadLine());
                sw.Flush();
            }
        }

    }
}
 
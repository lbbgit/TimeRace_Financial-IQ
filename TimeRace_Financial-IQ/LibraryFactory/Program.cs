using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            test4.t1();
            TryDic.t1();
            string bd = getReuest.GetHttp("http://www.baidu.com/");
            bd = getReuest.GetHttp("http://www.google.com/", true, "192.168.230.130", 1080);
            CodeFile3 cf3 = new CodeFile3();
            cf3.load(); return;
            CodeFile2 cf2 = new CodeFile2();
            cf2.load();

            
        }
    }
}

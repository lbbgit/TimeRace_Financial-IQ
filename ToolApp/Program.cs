using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ToolApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 多人聊天程序Client端.Form2());
            //Application.Run(new TxtCombine());

            return;
            _Xml.test1();
        }
    }
}

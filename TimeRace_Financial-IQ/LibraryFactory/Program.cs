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
            CodeFile3 cf3 = new CodeFile3();
            cf3.load(); return;
            CodeFile2 cf2 = new CodeFile2();
            cf2.load();
        }
    }
}

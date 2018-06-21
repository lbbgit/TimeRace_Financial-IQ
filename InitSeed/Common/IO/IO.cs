using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
namespace InitSeed.Common.IO
{
    public class IO
    {
        public static void CheckAndCreateDirectory(string path)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
        }
        public static void CheckAndReCreateText(string path,  string contents=null)
        {
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            if (contents == null)
                System.IO.File.CreateText(path);
            else
                System.IO.File.WriteAllText(path, contents, Encoding.Default);
        }
    }
}
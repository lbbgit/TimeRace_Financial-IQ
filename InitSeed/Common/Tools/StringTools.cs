using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace InitSeed.Common.Tools
{
    public static class StringTools
    {
        public static bool IsNullOrEmpty(string s)
        {
            return ((s + "").Length == 0);
        }
        public static bool IsNullOrWhiteSpace(string s)
        {
            return ((s + "").Trim().Length == 0); 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InitSeed.Common.Tools
{
    public class RandomTools
    {
        private static Random _rd;
        public static Random rd 
        {
            get {
                if (_rd == null)
                    _rd = new Random();
                return _rd;
            } 
        }
    }
}
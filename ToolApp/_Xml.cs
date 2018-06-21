using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;
namespace ToolApp
{
    public partial class _Xml : Form
    {
        string filexml = @"D:\WorkSpace-old\NewWorkVs10\TimeRace_Financial-IQ\1\trunk\ToolApp\Properties\t.xml";
        XmlDocument xdoc = new XmlDocument();
        public _Xml()
        {
            InitializeComponent();

            xdoc.Load(filexml);

            //XmlReader xread1 = new XmlReader();
        }

        public static string xml = @"
<a>
  <b>2b</b>
  <c>c1
   <c1>c11</c1>
  </c>
  <c>c2
   <c1>c111</c1>
   <c1>c112</c1>
  </c>
  <c>c3</c>
  <d d1='d111' d2='d222'>dtxt
    <e e1='e111'>e</e>
  </d>
  <f>
    <g>
      <h></h>
    </g>
  </f>
</a>";
        public static void test1()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);
            // XmlReader xRead = xdoc;
            XmlNodeList xNodeListd = xdoc.SelectNodes("a/b/d");
            XmlNodeList xNodeListc = xdoc.SelectNodes("a/b/c");
            XmlNodeList _xNodeListc = xdoc.SelectNodes("/a/b/c");
            XmlNodeList xNodeListc1 = xdoc.SelectNodes("a/b/c/c1");

            string aaaaa = new string('c', 1);
            String bbbb = new String('d',2);
            

            aaaaa = bbbb;

        }
    }
}

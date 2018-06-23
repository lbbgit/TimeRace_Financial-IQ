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


        private string ConvertDataTableToXML(DataTable xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UTF8Encoding utf = new UTF8Encoding();
                return utf.GetString(arr).Trim();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        public static void testXml2Dt()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
+ "<InsertInfo>"
+ "<TuHao>产品图号</TuHao>"
+ "<DaiHao>产品代号</DaiHao>"
+ "</InsertInfo>";
            DataSet ds = ConvertXMLToDataSet(xml);

            //2
            xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
+ "<rootNd>"
+ "<InsertInfo>"
+ "<TuHao>产品图号</TuHao>"
+ "<DaiHao>产品代号</DaiHao>"
+ "</InsertInfo>"
 + "<InsertInfo>"
 + "<TuHao>产品图号2</TuHao>"
 + "<DaiHao>产品代号2</DaiHao>"
 + "</InsertInfo>"
+ "</rootNd>";
            ds = ConvertXMLToDataSet(xml);

            //3
            xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
+ "<rootNd>"
+ "<InsertInfo>"
+ "<TuHao>产品图号</TuHao>"
+ "<DaiHao>产品代号</DaiHao>"
+ "<UserList><i>i1</i><i>i2</i></UserList>"
+ "</InsertInfo>"
+ "<InsertInfo>"
+ "<TuHao>产品图号2</TuHao>"
+ "<DaiHao>产品代号2</DaiHao>"
+ "</InsertInfo>"
+ "</rootNd>";
            ds = ConvertXMLToDataSet(xml);

            //3
            xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
+ "<rootNd>"
+ "<InsertInfo>"
+ "<TuHao>产品图号</TuHao>"
+ "<DaiHao>产品代号</DaiHao>"
+ "<UserList><i>i1</i><i>i2</i></UserList>"
+ "</InsertInfo>"
+ "<InsertInfo>"
+ "<TuHao>产品图号2</TuHao>"
+ "<DaiHao>产品代号2</DaiHao>"
+ "<line2>linsl2222</line2>"
+ "</InsertInfo>"
+ "</rootNd>";
            ds = ConvertXMLToDataSet(xml);


        }
        public static DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}

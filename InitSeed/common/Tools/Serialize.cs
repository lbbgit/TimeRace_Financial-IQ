using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;


using System.IO;
using System.Runtime.Serialization.Formatters.Binary;  
namespace InitSeed.Common.Tools
{
    /// <summary>
    /// 序列化,需要序列化的类定要使用[Serializable]进行标记.
    /// </summary>
    public class Serialize
    {
        /// <summary>
        /// object的序列化 
        /// </summary>
        public static byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            //内存实例
            MemoryStream ms = new MemoryStream();
            //创建序列化的实例
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);//序列化对象，写入ms流中  
            byte[] bytes = ms.GetBuffer();
            return bytes;
        }

        /// <summary>
        /// object的反序列化
        /// </summary>
        public static object DeserializeObject(byte[] bytes)
        {
            object obj = null;
            if (bytes == null)
                return obj;
            //利用传来的byte[]创建一个内存流
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms);//把内存流反序列成对象  
            ms.Close();
            return obj;
        }

        /// <summary>
        /// test 
        /// </summary>
        public static void SerializeDicTest()
        {

            Dictionary<string, int> test = new Dictionary<string, int>();

            test.Add("1", 1);
            test.Add("2", 2);
            test.Add("3", 4);

            byte[] testbyte = SerializeObject(test);

            Dictionary<string, int> testdic = (Dictionary<string, int>)DeserializeObject(testbyte);

            //Debug.Log("[SerializeDicTest]  : " + testdic["3"]);
        }  
    }
}
using System;
using System.IO;
using System.Text;
using System.Collections;

using System.Web;
using System.Xml;
using System.Data;
using System.Data.Common;

using System.Collections.Generic;
using System.Diagnostics;//stop Watch
public class codeFile1
{
    public void test1()
    {
        ArrayList al = new ArrayList();
        Array arr = null; 
        BitArray ba = new BitArray(new bool[] { true, false, true });
        BitArray ba2 = new BitArray(new int[] { 0, 1, 2, 3, 44 });
        //BitArray ba3 = new BitArray(new byte[]{'a','c','x'});
        BitArray ba4 = new BitArray(new byte[]{0,1,2});  
    }


    /*
     * 在System.Collections.Generic命名空间中，与ArrayList相对应的泛型集合是List<T>，与 HashTable相对应的泛型集合是Dictionary<K,V>
     * 其存储数据的方式与哈希表相似，通过键/值来保存元素，并具有泛型的全部特征
     * 编译时检查类型约束，读取时无须类型转换
     * 区别：Dictionary<K,V>不需要装箱、拆箱操作，HashTable添加时装箱，读取时拆箱。
     */
    IList<codeFile1> list111;
    List<structClass> list11=new List<structClass>();
    private IDictionary<string, string> idir;
    private Dictionary<String, String> dir = new Dictionary<String, String>();
    private Dictionary<Int32, Int32> dirInt = new Dictionary<Int32, Int32>();
    private Dictionary<Array, Char> dirBit = new Dictionary<Array, char>();
    Dictionary<String, String[]> dic1d = new Dictionary<String, String[]>();
    Dictionary<structClass, codeFile1> dic2sc = new Dictionary<structClass, codeFile1>();
    public void testIDictionary()
    {
        string[] results = null;
        dir.Add("1", "10086");
        dir.Add("0", "10000");
        dir.Values.CopyTo(results, 1);
        idir = dir;
        //dirBit = dir;
        //dir = dirInt;

        String[] ZheJiang = { "Huzhou", "HangZhou", "TaiZhou" };
        String[] ShangHai = { "Budong", "Buxi" };
        dic1d.Add("ZJ", ZheJiang);
        dic1d.Add("SH", ShangHai);
        Console.WriteLine("Output :" + dic1d["ZJ"][0]);

        structClass sc = new structClass();
        codeFile1 cf1 = new codeFile1();
        dic2sc.Add(sc, cf1);

        //Dictionary<int, String> dict = new Dictionary<int, String>();
        //DictionaryExtensionMethodClass.TryAdd(dict, 1, "ZhangSan"); 
        //DictionaryExtensionMethodClass.AddOrPeplace(dict, 3, "WangWu"); 

      
    }

    //pack:unpack 5.7 : 1
    public void PackUnPack()
    {
        Stopwatch watch = new Stopwatch();

        #region  cost time size rate： 6238 6232 29 33 == 67 79 3 4 == 57:10
        watch.Start();
        int count = 10000;
        string s = "测试数据";
        for (int i = 0; i < count; i++)
        {
            s = s + i;
        }
        watch.Stop();
        Console.WriteLine("----直接添加---会执行装箱过程---" + watch.ElapsedMilliseconds);
        watch.Restart();
        string s1 = "测试数据";
        for (int i = 0; i < count; i++)
        {
            s1 = s1 + i.ToString();
        }
        watch.Stop();
        Console.WriteLine("----ToString()添加---不会执行装箱---" + watch.ElapsedMilliseconds);


        watch.Restart();
        StringBuilder sb = new StringBuilder("测试数据");
        for (int i = 0; i < count; i++)
        {
            sb.Append(i.ToString());
        }
        watch.Stop();
        Console.WriteLine("----Sbstring添加---不会执行装箱---" + watch.ElapsedMilliseconds);

        watch.Restart();
        StringBuilder sb2 = new StringBuilder("测试数据");
        for (int i = 0; i < count; i++)
        {
            sb2.Append(i);
        }
        watch.Stop();
        Console.WriteLine("----Sbstring添加---会执行装箱---" + watch.ElapsedMilliseconds);
        #endregion

        watch.Restart();
        object obj;
        int j;
        for (int i = 0; i < count*100; i++)
        {
            obj = i;
        }
        watch.Stop();
        Console.WriteLine(" 会执行装箱---" + watch.ElapsedMilliseconds);
        watch.Restart(); 
        for (int i = 0; i < count*100; i++)
        {
            j =  i ;
        }
        watch.Stop();
        Console.WriteLine(" no执行装箱---" + watch.ElapsedMilliseconds);
        Console.ReadLine();
    }

    public void test_charbyteint()
    {
        byte b = new byte();
        //b = new byte(56);
        //b = new byte('a');
        char c = new char();
        //c = new char('x');
        //c = new char(44);
        c = 'x';
        b = Convert.ToByte(c);
    }


    public struct structClass
    {
        public string id, name;
        public List<object> values ;//= new List<object>();
        public Dictionary<string, string> attr ;//= new Dictionary<string, string>();
        public structClass[] sons ;//= null;
    }


    /// <summary>
    /// 扩展方法
    /// </summary>  
    //public static class DictionaryExtensionMethodClass <TKey, TValue>   : Dictionary<TKey, TValue>
    //{
    //    /// <summary>
    //    /// 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常
    //    /// </summary>
    //    public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
    //    {
    //        if (dict.ContainsKey(key) == false)
    //            dict.Add(key, value);
    //        return dict;
    //    }

    //    /// <summary>
    //    /// 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换
    //    /// </summary>
    //    public static Dictionary<TKey, TValue> AddOrPeplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
    //    {
    //        dict[key] = value;
    //        return dict;
    //    }

    //    /// <summary>
    //    /// 获取与指定的键相关联的值，如果没有则返回输入的默认值
    //    /// </summary>
    //    public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
    //    {
    //        return dict.ContainsKey(key) ? dict[key] : defaultValue;
    //    }

    //    /// <summary>
    //    /// 向字典中批量添加键值对
    //    /// </summary>
    //    /// <param name="replaceExisted">如果已存在，是否替换</param>
    //    public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
    //    {
    //        foreach (var item in values)
    //        {
    //            if (dict.ContainsKey(item.Key) == false || replaceExisted)
    //                dict[item.Key] = item.Value;
    //        }
    //        return dict;
    //    } 
    //} 
}
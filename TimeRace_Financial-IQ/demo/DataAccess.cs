using System;
using System.Reflection;

using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public interface IBase{}
public sealed class DataAccess<T> //where T : Object //IBase
{
    private static readonly string dcPath = "";
    private static readonly string nameSpace = "";


    private static object lockHelper = new object();
    private static T obj = default(T);

    public static T CreateInstance( )  //Config.Databasetype type
    {
        string className = nameSpace + "." + typeof(T).Name.Substring(1);
        if (obj == null)
        {
            //make sure that 'Static Instace' is only
            lock (lockHelper)
            {
                if (obj == null)
                {
                    obj = (T)Assembly.Load(dcPath).CreateInstance(className);
                }
            }
        }
        return obj;
    }
     
    /// <summary>
    /// String.Split()
    /// </summary> 
    public List<string> StringSplit(string str,char split_char=',')
    {
        List<string> devs = new List<string>();

        int start = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == split_char)
            {
                devs.Add(str.Substring(start, i));
                start = i + 1;
            }
        }

        return devs;
    }

    public static string ToString(T obj)  // .ToString() Convert.ToString()
    {
        if (obj == null)
            return "";
        return obj.ToString(); 
    }    
}
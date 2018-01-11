using System;
using System.Data;
using System.Text; 
using System.Collections.Generic;
using System.EnterpriseServices;
//using System.ComponentModel;
using System.Reflection;

 
 
namespace n1
{
    //Enum.GetValues(typeof(MemberLevel))
    //Enum.GetName(typeof(MemberLevel))
    [Description("会员等级")]
    enum MemberLevel
    {
        [Description("金牌会员")]
        gold = 1,
        [Description("银牌会员")]
        silver = 2,
        [Description("铜牌会员")]
        copper = 3
    }

    //not just int
    enum MemberLevell : long
    {
        gold = 2147483648L,
        silver = 232L,
        copper = 10L
    }

    class t
    {
        void t1()
        {
            string s = Enum.GetName(typeof(MemberLevel), 3);
            Console.WriteLine(s);

            Console.WriteLine("MemberLevel中的值:");
            foreach (int i in Enum.GetValues(typeof(MemberLevel)))
                Console.WriteLine(i);

            Console.WriteLine("MemberLevel中的值(注意类型):");
            foreach (MemberLevel i in Enum.GetValues(typeof(MemberLevel)))
                Console.WriteLine(i);

            Console.WriteLine("MemberLevel中的变量:");
            foreach (string str in Enum.GetNames(typeof(MemberLevel)))
                Console.WriteLine(str);


            MemberLevel111 options = MemberLevel111.gold | MemberLevel111.silver;
        }
    }

 
    [Flags]
    enum MemberLevel111
    {
        [Description("二进制表示为1----0001")]
        gold = 0x1,
        [Description("二进制表示为4----0010")]
        silver = 0x04,
        [Description("二进制表示为16----0100")]
        copper = 0x10
    }
}

namespace test
{

    [Flags]
    enum MemberLeve
    {
        [Description("二进制表示为1----0001")]
        gold = 0x1,
        [Description("二进制表示为4----0010")]
        silver = 0x04,
        [Description("二进制表示为16----0100")]
        copper = 0x10
    }


    public static class EnumHelper
    {
        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项。</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription(this Enum value, bool isTop = false)
        {
            Type enumType = value.GetType();
            DescriptionAttribute attr = null;
            if (isTop)
            {
                attr = (DescriptionAttribute)Attribute.GetCustomAttribute(enumType, typeof(DescriptionAttribute));
            }
            else
            {
                // 获取枚举常数名称。
                string name = Enum.GetName(enumType, value);
                if (name != null)
                {
                    // 获取枚举字段。
                    FieldInfo fieldInfo = enumType.GetField(name);
                    if (fieldInfo != null)
                    {
                        // 获取描述的属性。
                        attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    }
                }
            }

             
            if (attr != null && !string.IsNullOrEmpty(attr.ToString()))//.Description;  //Exception
                return attr.ToString();//.Description;
            else
                return string.Empty;

        }
    }
    class s
    {
        void a()
        {
            MemberLeve gold = MemberLeve.gold;
            Console.WriteLine(gold.GetDescription());
            System.Console.Read();
        }
    }
}

/// <summary>
/// C#泛型单例模式
/// </summary> 
namespace TSingleDistince
{
    
    public class TSingleton<T> where T : class
    {
        static object SyncRoot = new object();
        static T instance;
        public static readonly Type[] EmptyTypes = new Type[0];
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            ConstructorInfo ci = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, EmptyTypes, null);
                            if (ci == null) { throw new InvalidOperationException("class must contain a private constructor"); }
                            instance = (T)ci.Invoke(null);  //instance = Activator.CreateInstance(typeof(T)) as T;
                        }
                    }
                }
                return instance;
            }
        }
    }

    public sealed class Singleton<T> where T : new()
    {
        public static T Instance
        {
            get { return SingletonCreator.instance; }
        }
        class SingletonCreator
        {
            internal static readonly T instance = new T();
        }
    }
    //即可

}
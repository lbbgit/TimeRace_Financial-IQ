#define no_local
using System;
using System.Text;
using System.Reflection;
 
using System.Collections.Generic;
using System.Linq; 

public class CodeFile2
{
    //@"D:\123\mydll\mydll\bin\Debug\mydll.dll"
    public string load(string path = @"D:\WorkSpace-old\NewWorkVs10\TimeRace_Financial-IQ\1\trunk\TimeRace_Financial-IQ\LibraryFactory\mydll.dll")
    { 
        //Byte[] byte1 = System.IO.File.ReadAllBytes(path);//也是可以的
        //Assembly assem = Assembly.Load(byte1); 
        Assembly assem = Assembly.LoadFile(path);


        //string t_class = "mydll.Class1";//理论上已经加载了dll文件，可以通过命名空间加上类名获取类的类型，这里应该修改为如下： 
        //string t_class = "mydll.Class1,mydll";//如果你想要得到的是被本工程内部的类，可以“命名空间.父类……类名”;
        //如果是外部的，需要在后面加上“,链接库名”; 
        //Type ty = Type.GetType(t_class);//这儿在调试的时候ty=null，一直不理解，望有高人可以解惑 
        try
        {
            string t_class = "mydll.Class1";
            t_class = "mydll.Class1,mydll";
            Type ty = Type.GetType(t_class);
        }
        catch (Exception) { }
        Type[] tys = assem.GetTypes();//只好得到所有的类型名，然后遍历，通过类型名字来区别了
        foreach (Type ty in tys)//huoquleiming
        {
            if (ty.Name == "Class1")
            {
                ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);//获取不带参数的构造函数
                object magicClassObject = magicConstructor.Invoke(new object[] { });//这里是获取一个类似于类的实例的东东 
                //object magicClassObject = Activator.CreateInstance(ty);//获取无参数的构造实例还可以通过这样
                object __magicClassObject = Activator.CreateInstance(ty);
                MethodInfo mi = ty.GetMethod("sayhello");
                object aa = mi.Invoke(magicClassObject, null);
                return aa.ToString();//这儿是执行类class1的sayhello方法
            }
            if (ty.Name == "Class2")
            {
                ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);//获取不带参数的构造函数，如果有构造函数且没有不带参数的构造函数时，这儿就不能这样子啦
                object magicClassObject = magicConstructor.Invoke(new object[] { });
                MethodInfo mi = ty.GetMethod("saybeautiful");
                object aa = mi.Invoke(magicClassObject, null);//方法有参数时，需要把null替换为参数的集合
                return aa.ToString();
            }

        }

        //AppDomain pluginDomain = (pluginInstanceContainer[key] as PluginEntity).PluginDomain;
        //if (pluginDomain != null)
        //{
        //  AppDomain.Unload(pluginDomain);
        // } 
        return string.Empty;
    }
}

#if local

namespace mydll
{
  public class Class1
  {
    public Class1()  { }
    public string sayhello()
    {
      return "hello,word!";
    }
  }

  public class Class2
  {
    public Class2() { } 
    public string saybeautiful()
    {
      return "beautiful,very good!";
    }
  } 
}

#endif
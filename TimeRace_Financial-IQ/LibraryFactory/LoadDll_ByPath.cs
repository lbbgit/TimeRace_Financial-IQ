using System;
 
using System.Text;
using System.Reflection; 
using System.Collections.Generic;
using System.Linq; 

public class currentPath
{
    public static string GetCurrentPath()
    {
        return System.IO.Path.GetFullPath("../..");
        return AppDomain.CurrentDomain.BaseDirectory;
        return Environment.CurrentDirectory;
    } 
}

public class LoadInstance<T>
{
    public static T CreateInstance(string path)
    {  
        Assembly assem = Assembly.LoadFile(path);  
        Type[] tys = assem.GetTypes();
        foreach (Type ty in tys) 
        {
            if (ty.FullName == typeof(T).FullName)
            {
                ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);
                object magicClassObject = magicConstructor.Invoke(new object[] { });
                if (magicClassObject is T)
                    return (T)magicClassObject;
                else
                    return default(T);
            }
        }
        return default(T);
    }

    //2
    private static T objNew = default(T);
    public static T CreateNewInstance(string path)
    {
        Assembly assem = Assembly.LoadFile(path);
        Type[] tys = assem.GetTypes();
        if (objNew != null)
            return objNew;
        foreach (Type ty in tys) 
        {
            if (ty.FullName == typeof(T).FullName)
            {
                ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);
                object magicClassObject = magicConstructor.Invoke(new object[] { });
                objNew = (T)magicClassObject;
                return objNew;
            }
        } 
        return default(T);
    }


    //3
    private static object lockHelper = new object();
    private static T obj = default(T); 
    public static T CreateInstance(string nameSpace,string dcPath)  //Config.Databasetype type
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
}
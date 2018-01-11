using System;
using System.Text;
using System.Data;

namespace 设计模式之工厂方法模式 //简单工厂模式,1菜1法，左右修改
{
    /// <summary>
    /// 菜抽象类
    /// </summary>
    public abstract class Food
    {
        // 输出点了什么菜
        public abstract void Print();
    }

    /// <summary>
    /// 西红柿炒鸡蛋这道菜
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("西红柿炒蛋好了！");
        }
    }

    /// <summary>
    /// 土豆肉丝这道菜
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("土豆肉丝好了");
        }
    }

    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Creator
    {
        // 工厂方法
        public abstract Food CreateFoddFactory();
    }

    /// <summary>
    /// 西红柿炒蛋工厂类
    /// </summary>
    public class TomatoScrambledEggsFactory : Creator
    {
        /// <summary>
        /// 负责创建西红柿炒蛋这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoddFactory()
        {
            return new TomatoScrambledEggs();
        }
    }

    /// <summary>
    /// 土豆肉丝工厂类
    /// </summary>
    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        /// <summary>
        /// 负责创建土豆肉丝这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoddFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }

    /// <summary>
    /// 客户端调用
    /// </summary>
    class Client
    {
        static void _Main(string[] args)
        {
            // 初始化做菜的两个工厂（）
            Creator shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            Creator tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();

            // 开始做西红柿炒蛋
            Food tomatoScrambleEggs = tomatoScrambledEggsFactory.CreateFoddFactory();
            tomatoScrambleEggs.Print();

            //开始做土豆肉丝
            Food shreddedPorkWithPotatoes = shreddedPorkWithPotatoesFactory.CreateFoddFactory();
            shreddedPorkWithPotatoes.Print();

            Console.Read();
        }
    }
}
/*
  请求*.aspx的文件时，此时会映射到System.Web.UI.PageHandlerFactory类上进行处理
  而对*.ashx的文件时，此时会映射到System.Web.UI.SimpleHandlerFactory类 
（这两个类都是继承于IHttpHandlerFactory接口的）
 关于这点说明我们可以在“C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\Web.Config”文件中找到相关定义，具体定义如下：
<httpHandlers>
            <add path="*.axd" verb="*" type="System.Web.HttpNotFoundHandler" validate="True" />
            <add path="*.aspx" verb="*" type="System.Web.UI.PageHandlerFactory" validate="True" />
            <add path="*.ashx" verb="*" type="System.Web.UI.SimpleHandlerFactory" validate="True" />
</httpHandlers>
 * 
 */


/// <summary>
/// 顾客充当客户端，负责调用简单工厂来生产对象
/// 即客户点菜，厨师（相当于简单工厂）负责烧菜(生产的对象)
/// </summary>
class Customer
{
    static void __Main(string[] args)
    {
        // 客户想点一个西红柿炒蛋        
        Food food1 = FoodSimpleFactory.CreateFood("西红柿炒蛋");
        food1.Print();

        // 客户想点一个土豆肉丝
        Food food2 = FoodSimpleFactory.CreateFood("土豆肉丝");
        food2.Print();

        Console.Read();
    }
}

/// <summary>
/// 菜抽象类
/// </summary>
public abstract class Food
{
    // 输出点了什么菜
    public abstract void Print();
}

/// <summary>
/// 西红柿炒鸡蛋这道菜
/// </summary>
public class TomatoScrambledEggs : Food
{
    public override void Print()
    {
        Console.WriteLine("一份西红柿炒蛋！");
    }
}

/// <summary>
/// 土豆肉丝这道菜
/// </summary>
public class ShreddedPorkWithPotatoes : Food
{
    public override void Print()
    {
        Console.WriteLine("一份土豆肉丝");
    }
}

/// <summary>
/// 简单工厂类, 负责 炒菜
/// </summary>
public class FoodSimpleFactory//根据一个名词，返回其他细节完成封装
{
    public static Food CreateFood(string type)
    {
        Food food = null;
        if (type.Equals("土豆肉丝"))
        {
            food = new ShreddedPorkWithPotatoes();
        }
        else if (type.Equals("西红柿炒蛋"))
        {
            food = new TomatoScrambledEggs();
        }

        return food;
    }
}
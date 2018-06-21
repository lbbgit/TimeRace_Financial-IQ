using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;
namespace ToolApp
{
    public partial class Default : Form
    {
        public Default()
        {
            InitializeComponent();

            InitApp();
        }

        void InitApp()
        {
            //如果是当前下的。用Assembly.GetExecutingAssembly().GetTypes();
            //如果是外部DLL，用Assembly.Load("namespace").GetTypes();
            //原理是反射，所以上面一定要加上using System.Reflection;
            //如果查看的对象是外部的DLL，一定要把DLL复制到项目的调试文件夹Debug下。

            var classes = Assembly.Load("ToolApp").GetTypes();
            foreach (var item in classes)
            {
                Button bt = CreateBtn(item.Name, item.FullName);
                bt.Click += StartClass; 
                this.flowLayoutPanel1.Controls.Add(bt);
            }


        }

        Button CreateBtn(string name,string className)
        {
            Button btn = new Button();

            //btn.Location = new System.Drawing.Point(3, 3);
            btn.Name = name;
            btn.Size = new System.Drawing.Size(75, 23);
            btn.TabIndex = 0;
            btn.Text = name;
            btn.UseVisualStyleBackColor = true; 
            btn.Tag = className; 

            return btn;

        

        }

        void StartClass(object sender,EventArgs e)
        {
            Button bt = sender as Button;
            if (bt == null)
                return;
            string className = Convert.ToString(bt.Tag);

            try
            {
                Type type = Type.GetType(className);//"类的完全限定名"
                dynamic obj2 = type.Assembly.CreateInstance(className);
                Form fm = obj2 as Form;
                if (fm!=null)
                {
                    fm.Show();
                    //fm.ShowDialog();
                    //Application.Run(obj2 as Form);
                }
                else if (obj2 is ApplicationContext)
                {
                    //Application.Run(obj2 as ApplicationContext);
                }

            }catch(Exception){}

            return;

            Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
            dynamic obj = assembly.CreateInstance("类的完全限定名（即包括命名空间）"); // 创建类的实例，返回为 object 类型，需要强制类型转换

            Type _type = Type.GetType(className);//"类的完全限定名"
            dynamic _obj2 = _type.Assembly.CreateInstance(className); 
            //System.Type.GetType("").Assembly.CreateInstance(

            //4、不同程序集的话，则要装载调用，代码如下:
            //System.Reflection.Assembly.Load("程序集名称（不含文件后缀名）").CreateInstance("命名空间.类名", false); 
            dynamic o = System.Reflection.Assembly.Load("MyDll").CreateInstance("MyNameSpace.A", false);
        }
    }
}

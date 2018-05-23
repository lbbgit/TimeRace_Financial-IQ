using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;


using System.Security.Cryptography;
namespace ToolApp
{
    public partial class TxtCombine : Form
    {
        public TxtCombine()
        {
            InitializeComponent();
        }

        static string filename = "c:\\Combine.txt";
        private void button1_Click(object sender, EventArgs e)
        {
            string folder = this.textBox1.Text;
            string filter = this.textBox2.Text;// "*.txt"
            FileInfo finfo;
            Hashtable ht = new Hashtable();
            bool checkMD5 = this.checkBox1.Checked; 
            MD5 md5 = new MD5CryptoServiceProvider();
            if (Directory.Exists(folder))
            {
                string[] files=Directory.GetFiles(folder,filter, SearchOption.AllDirectories);

                //System.IO.File.Create(filename, 0); 
                System.IO.File.AppendAllText(filename, "");
                int count = 0;
                foreach (string file in files)
                {
                    finfo = new FileInfo(file);
                    string strContent=System.IO.File.ReadAllText(file, Encoding.Default);
                    bool needToAdd = true;
                    if (checkMD5)
                    {
                        //byte[] data =  System.Text.Encoding.Default.GetBytes(strPwd);//将字符编码为一个字节序列
                        //byte[] md5data = md5.ComputeHash(data);//计算data字节数组的哈希值
                        //md5.ComputeHash(strContent);

                        FileStream fileStream = new FileStream(file, FileMode.Open);
                        byte[] retVal = md5.ComputeHash(fileStream); 
                        fileStream.Close();

                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < retVal.Length; i++)
                        {
                            sb.Append(retVal[i].ToString("x2"));
                        }
                        string md5str= sb.ToString();
                        if (ht.Contains(md5str))
                            needToAdd = false;
                        else
                            ht.Add(md5str, '1');
                    }
                    if (needToAdd)
                    {
                        System.IO.File.AppendAllText(filename, "第一章，第" + count + "节[][][]" + finfo.Name + "\r\n");
                        System.IO.File.AppendAllText(filename, strContent);
                        count++;
                    }
                } 
            }
            else
                showStr("folder did't exist!");
        }
        private void showStr(string s)
        {
            MessageBox.Show(s);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)  {  }
    }
}

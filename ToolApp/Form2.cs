using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;



namespace 多人聊天程序Client端
{
    public partial class Form2 : System.Windows.Forms.Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtSendMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox txtRecvMsg;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button button5;
        private System.ComponentModel.Container components = null;
        byte[] m_dataBuffer = new byte[10];
        IAsyncResult result;
        public AsyncCallback pfnCallBack;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label5;
        public Socket clientSocket;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSendMsg = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.txtRecvMsg = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // label1 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP:";
            // txtIP 
            this.txtIP.Location = new System.Drawing.Point(80, 24);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(160, 21);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "";
            // label2 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口:";
            // txtPort 
            this.txtPort.Location = new System.Drawing.Point(80, 56);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(40, 21);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "";
            // label3 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "发送信息给服务器:";
            // txtSendMsg 
            this.txtSendMsg.Location = new System.Drawing.Point(16, 120);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(224, 88);
            this.txtSendMsg.TabIndex = 5;
            this.txtSendMsg.Text = "";
            // label4 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "连接状态:";
            // status 
            this.status.Location = new System.Drawing.Point(80, 248);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(192, 23);
            this.status.TabIndex = 7;
            // txtRecvMsg 
            this.txtRecvMsg.Location = new System.Drawing.Point(264, 80);
            this.txtRecvMsg.Name = "txtRecvMsg";
            this.txtRecvMsg.ReadOnly = true;
            this.txtRecvMsg.Size = new System.Drawing.Size(224, 144);
            this.txtRecvMsg.TabIndex = 8;
            this.txtRecvMsg.Text = "";
            // button1 
            this.button1.Location = new System.Drawing.Point(280, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "连接";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // button2 
            this.button2.Location = new System.Drawing.Point(384, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "断开";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // button3 
            this.button3.Location = new System.Drawing.Point(280, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 32);
            this.button3.TabIndex = 11;
            this.button3.Text = "清空信息";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // button4 
            this.button4.Location = new System.Drawing.Point(384, 232);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 32);
            this.button4.TabIndex = 12;
            this.button4.Text = "关闭";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // label5 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "收到服务器发来的信息:";
            // button5 
            this.button5.Location = new System.Drawing.Point(16, 208);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(224, 32);
            this.button5.TabIndex = 14;
            this.button5.Text = "发送信息";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // Form1 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(512, 277);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRecvMsg);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "多人聊天程序Client端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        //#endregion 

        //[STAThread]
        //static void Main()
        //{
        //    Application.Run(new Form2());
        //}


        // 连接按钮 
        private void button1_Click(object sender, System.EventArgs e)
        {
            // IP地址和端口号不能为空 
            if (txtIP.Text == "" || txtPort.Text == "")
            {
                MessageBox.Show("请先完整填写服务器IP地址和端口号!", "提示");
                return;
            }
            try
            {
                // 创建Socket实例 
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 得到服务器的IP地址 
                IPAddress ipAddress = IPAddress.Parse(txtIP.Text);
                Int32 port = Int32.Parse(txtPort.Text);
                // 创建远程终结点 
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                // 连接到远程服务器 
                clientSocket.Connect(remoteEP);
                if (clientSocket.Connected)
                {
                    UpdateControls(true);
                    WaitForData(); // 异步等待数据 
                }
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "提示");
                UpdateControls(false);
            }
        }
        // 等待数据 
        public void WaitForData()
        {
            try
            {
                if (pfnCallBack == null)
                {
                    // 当连接上的客户有写的操作的时候，调用回调函数 
                    pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket socketPacket = new SocketPacket();
                socketPacket.thisSocket = clientSocket;
                result = clientSocket.BeginReceive(socketPacket.dataBuffer, 0, socketPacket.dataBuffer.Length,
                SocketFlags.None, pfnCallBack, socketPacket);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "提示");
            }
        }
        // 该类保存Socket以及发送给服务器的数据 
        public class SocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1024]; // 发给服务器的数据 
        }
        // 接收数据 
        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                // EndReceive完成BeginReceive异步调用，返回服务器写入流的字节数 
                int iRx = theSockId.thisSocket.EndReceive(asyn);
                // 加 1 是因为字符串以 ‘\0’ 作为结束标志符 
                char[] chars = new char[iRx + 1];
                // 用UTF8格式来将string信息转化成byte数组形式 
                System.Text.Decoder decoder = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = decoder.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                // 将收到的信息显示在信息列表中 
                txtRecvMsg.Text = txtRecvMsg.Text + szData;
                // 等待数据 
                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket已经关闭!\n");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054)
                {
                    string msg = "服务器" + "停止服务!" + "\n";
                    txtRecvMsg.Text = txtRecvMsg.Text + msg;
                    clientSocket.Close();
                    clientSocket = null;
                    UpdateControls(false);
                }
                else
                {
                    MessageBox.Show(se.Message, "提示");
                }
            }
        }
        // 更新控件。连接和断开（发送信息）按钮的状态是互斥的 
        private void UpdateControls(bool connected)
        {
            button1.Enabled = !connected;
            button2.Enabled = connected;
            button5.Enabled = connected;
            if (connected)
            {
                status.Text = "已连接";
            }
            else
            {
                status.Text = "无连接";
            }
        }
        // 断开按钮 
        private void button2_Click(object sender, System.EventArgs e)
        {
            // 关闭Socket 
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
                UpdateControls(false);
            }
        }
        // 发送信息按钮 
        private void button5_Click(object sender, System.EventArgs e)
        {
            try
            {
                // 如果客户与服务器有连接，则允许发送信息 
                if (clientSocket.Connected)
                {
                    string msg = txtSendMsg.Text + "\n";
                    // 用UTF8格式来将string信息转化成byte数组形式 
                    byte[] byData = System.Text.Encoding.UTF8.GetBytes(msg);
                    if (clientSocket != null)
                    {
                        // 发送数据 
                        clientSocket.Send(byData);
                    }
                }
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message, "提示");
            }
        }
        // 清空按钮 
        private void button3_Click(object sender, System.EventArgs e)
        {
            txtRecvMsg.Clear(); // 清空信息列表 
        }
        // 关闭按钮 
        private void button4_Click(object sender, System.EventArgs e)
        {
            // 关闭Socket 
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }
            Close(); // 关闭窗体 
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            UpdateControls(false); // 初始化时，只有连接按钮可用 
        }
    }
}

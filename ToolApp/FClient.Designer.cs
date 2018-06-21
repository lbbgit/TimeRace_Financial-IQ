namespace ToolApp
{
    partial class FClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBeginListern = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtCMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBeginListern
            // 
            this.btnBeginListern.Location = new System.Drawing.Point(187, 41);
            this.btnBeginListern.Name = "btnBeginListern";
            this.btnBeginListern.Size = new System.Drawing.Size(48, 23);
            this.btnBeginListern.TabIndex = 0;
            this.btnBeginListern.Text = "button1";
            this.btnBeginListern.UseVisualStyleBackColor = true;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(12, 41);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(118, 41);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(50, 21);
            this.txtPort.TabIndex = 2;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(39, 158);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(100, 21);
            this.txtAuthor.TabIndex = 4;
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(39, 121);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(214, 21);
            this.txtMsg.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(37, 221);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "button2";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // txtCMsg
            // 
            this.txtCMsg.Location = new System.Drawing.Point(37, 194);
            this.txtCMsg.Name = "txtCMsg";
            this.txtCMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCMsg.Size = new System.Drawing.Size(214, 21);
            this.txtCMsg.TabIndex = 6;
            // 
            // FClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtCMsg);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnBeginListern);
            this.Name = "FClient";
            this.Text = "FServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginListern;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtCMsg;
    }
}
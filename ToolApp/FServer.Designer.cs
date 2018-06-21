namespace ToolApp
{
    partial class FServer
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
            this.txtPORT = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
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
            // txtPORT
            // 
            this.txtPORT.Location = new System.Drawing.Point(118, 41);
            this.txtPORT.Name = "txtPORT";
            this.txtPORT.Size = new System.Drawing.Size(50, 21);
            this.txtPORT.TabIndex = 2;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(37, 167);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(100, 21);
            this.txtAuthor.TabIndex = 4;
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(39, 121);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSendMsg.Size = new System.Drawing.Size(214, 21);
            this.txtSendMsg.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(37, 211);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "button2";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // FServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtSendMsg);
            this.Controls.Add(this.txtPORT);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnBeginListern);
            this.Name = "FServer";
            this.Text = "FServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginListern;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPORT;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.Button btnSend;
    }
}
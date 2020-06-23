namespace KW_Project
{
    partial class ChatServerForm
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
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.txt_all = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(253, 401);
            this.btn_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(74, 93);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "▲";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btnSend_Click);
            this.btn_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(10, 401);
            this.txt_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_send.Multiline = true;
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(238, 94);
            this.txt_send.TabIndex = 7;
            // 
            // txt_all
            // 
            this.txt_all.Location = new System.Drawing.Point(10, 15);
            this.txt_all.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_all.Multiline = true;
            this.txt_all.Name = "txt_all";
            this.txt_all.Size = new System.Drawing.Size(316, 350);
            this.txt_all.TabIndex = 6;
            // 
            // ChatServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(337, 518);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.txt_all);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChatServerForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatServerForms_FormClosing);
            this.Load += new System.EventHandler(this.ChatServerForms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.TextBox txt_all;
    }
}
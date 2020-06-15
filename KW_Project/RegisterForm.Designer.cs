namespace KW_Project
{
    partial class RegisterForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRegisterConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.R_txtPwd1 = new System.Windows.Forms.TextBox();
            this.R_txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.R_txtPwd2 = new System.Windows.Forms.TextBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("휴먼둥근헤드라인", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBack.Location = new System.Drawing.Point(405, 295);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(87, 40);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "뒤로가기";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRegisterConfirm
            // 
            this.btnRegisterConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegisterConfirm.Font = new System.Drawing.Font("휴먼둥근헤드라인", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegisterConfirm.Location = new System.Drawing.Point(311, 295);
            this.btnRegisterConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegisterConfirm.Name = "btnRegisterConfirm";
            this.btnRegisterConfirm.Size = new System.Drawing.Size(87, 40);
            this.btnRegisterConfirm.TabIndex = 13;
            this.btnRegisterConfirm.Text = "회원가입";
            this.btnRegisterConfirm.UseVisualStyleBackColor = true;
            this.btnRegisterConfirm.Click += new System.EventHandler(this.btnRegisterConfirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F);
            this.label2.Location = new System.Drawing.Point(306, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "학번";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10F);
            this.label1.Location = new System.Drawing.Point(305, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "비밀번호";
            // 
            // R_txtPwd1
            // 
            this.R_txtPwd1.Location = new System.Drawing.Point(307, 211);
            this.R_txtPwd1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R_txtPwd1.Name = "R_txtPwd1";
            this.R_txtPwd1.PasswordChar = '*';
            this.R_txtPwd1.Size = new System.Drawing.Size(193, 25);
            this.R_txtPwd1.TabIndex = 10;
            // 
            // R_txtId
            // 
            this.R_txtId.Location = new System.Drawing.Point(307, 96);
            this.R_txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R_txtId.Name = "R_txtId";
            this.R_txtId.Size = new System.Drawing.Size(193, 25);
            this.R_txtId.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(197, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 38);
            this.label3.TabIndex = 15;
            this.label3.Text = "Register";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KW_Project.Properties.Resources.heart;
            this.pictureBox1.Location = new System.Drawing.Point(27, 79);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("휴먼둥근헤드라인", 10F);
            this.label4.Location = new System.Drawing.Point(306, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "비밀번호 확인";
            // 
            // R_txtPwd2
            // 
            this.R_txtPwd2.Location = new System.Drawing.Point(307, 262);
            this.R_txtPwd2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R_txtPwd2.Name = "R_txtPwd2";
            this.R_txtPwd2.PasswordChar = '*';
            this.R_txtPwd2.Size = new System.Drawing.Size(193, 25);
            this.R_txtPwd2.TabIndex = 17;
            // 
            // cmbSex
            // 
            this.cmbSex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "남자",
            "여자"});
            this.cmbSex.Location = new System.Drawing.Point(307, 155);
            this.cmbSex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(74, 23);
            this.cmbSex.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F);
            this.label5.Location = new System.Drawing.Point(307, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "성별";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(552, 345);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.R_txtPwd2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRegisterConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.R_txtPwd1);
            this.Controls.Add(this.R_txtId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRegisterConfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox R_txtPwd1;
        private System.Windows.Forms.TextBox R_txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox R_txtPwd2;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.Label label5;
    }
}
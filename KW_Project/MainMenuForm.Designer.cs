namespace KW_Project
{
    partial class MainMenuForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.lblIdealProfile1 = new System.Windows.Forms.Label();
            this.lblIdealProfile2 = new System.Windows.Forms.Label();
            this.lblProfile1 = new System.Windows.Forms.Label();
            this.lblProfile2 = new System.Windows.Forms.Label();
            this.btnDislike = new System.Windows.Forms.Button();
            this.btnLike = new System.Windows.Forms.Button();
            this.idealPic = new System.Windows.Forms.PictureBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnBoard = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btn_GotChat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.idealPic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExit.Location = new System.Drawing.Point(332, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 25);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblIdealProfile1
            // 
            this.lblIdealProfile1.AutoSize = true;
            this.lblIdealProfile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIdealProfile1.Location = new System.Drawing.Point(86, 256);
            this.lblIdealProfile1.Name = "lblIdealProfile1";
            this.lblIdealProfile1.Size = new System.Drawing.Size(0, 20);
            this.lblIdealProfile1.TabIndex = 6;
            // 
            // lblIdealProfile2
            // 
            this.lblIdealProfile2.AutoSize = true;
            this.lblIdealProfile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIdealProfile2.Location = new System.Drawing.Point(86, 282);
            this.lblIdealProfile2.Name = "lblIdealProfile2";
            this.lblIdealProfile2.Size = new System.Drawing.Size(0, 24);
            this.lblIdealProfile2.TabIndex = 7;
            // 
            // lblProfile1
            // 
            this.lblProfile1.AutoSize = true;
            this.lblProfile1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProfile1.ForeColor = System.Drawing.Color.White;
            this.lblProfile1.Location = new System.Drawing.Point(5, 281);
            this.lblProfile1.Name = "lblProfile1";
            this.lblProfile1.Size = new System.Drawing.Size(80, 19);
            this.lblProfile1.TabIndex = 8;
            this.lblProfile1.Text = "label1";
            // 
            // lblProfile2
            // 
            this.lblProfile2.AutoSize = true;
            this.lblProfile2.Font = new System.Drawing.Font("휴먼둥근헤드라인", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProfile2.ForeColor = System.Drawing.Color.White;
            this.lblProfile2.Location = new System.Drawing.Point(5, 241);
            this.lblProfile2.Name = "lblProfile2";
            this.lblProfile2.Size = new System.Drawing.Size(109, 28);
            this.lblProfile2.TabIndex = 9;
            this.lblProfile2.Text = "label2";
            // 
            // btnDislike
            // 
            this.btnDislike.BackgroundImage = global::KW_Project.Properties.Resources.dislike;
            this.btnDislike.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDislike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDislike.FlatAppearance.BorderSize = 0;
            this.btnDislike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDislike.Location = new System.Drawing.Point(97, 366);
            this.btnDislike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDislike.Name = "btnDislike";
            this.btnDislike.Size = new System.Drawing.Size(57, 52);
            this.btnDislike.TabIndex = 11;
            this.btnDislike.UseVisualStyleBackColor = true;
            this.btnDislike.Click += new System.EventHandler(this.btnDislike_Click);
            // 
            // btnLike
            // 
            this.btnLike.AutoSize = true;
            this.btnLike.BackColor = System.Drawing.Color.Transparent;
            this.btnLike.BackgroundImage = global::KW_Project.Properties.Resources.like;
            this.btnLike.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLike.FlatAppearance.BorderSize = 0;
            this.btnLike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLike.Location = new System.Drawing.Point(225, 366);
            this.btnLike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(59, 52);
            this.btnLike.TabIndex = 10;
            this.btnLike.UseVisualStyleBackColor = false;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // idealPic
            // 
            this.idealPic.Location = new System.Drawing.Point(23, 34);
            this.idealPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idealPic.Name = "idealPic";
            this.idealPic.Size = new System.Drawing.Size(342, 318);
            this.idealPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.idealPic.TabIndex = 5;
            this.idealPic.TabStop = false;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnProfile.BackgroundImage = global::KW_Project.Properties.Resources._007_menu;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnProfile.Location = new System.Drawing.Point(322, 464);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(53, 46);
            this.btnProfile.TabIndex = 3;
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnBoard
            // 
            this.btnBoard.BackColor = System.Drawing.Color.Transparent;
            this.btnBoard.BackgroundImage = global::KW_Project.Properties.Resources._004_photo;
            this.btnBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoard.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnBoard.FlatAppearance.BorderSize = 0;
            this.btnBoard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBoard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnBoard.Location = new System.Drawing.Point(230, 461);
            this.btnBoard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(70, 53);
            this.btnBoard.TabIndex = 2;
            this.btnBoard.UseVisualStyleBackColor = false;
            this.btnBoard.Click += new System.EventHandler(this.btnBoard_Click);
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.Transparent;
            this.btnChat.BackgroundImage = global::KW_Project.Properties.Resources._008_mailbox;
            this.btnChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnChat.Location = new System.Drawing.Point(85, 458);
            this.btnChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(66, 54);
            this.btnChat.TabIndex = 1;
            this.btnChat.UseVisualStyleBackColor = false;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImage = global::KW_Project.Properties.Resources._003_reload;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnHome.Location = new System.Drawing.Point(12, 458);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(66, 57);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // btn_GotChat
            // 
            this.btn_GotChat.Location = new System.Drawing.Point(156, 462);
            this.btn_GotChat.Name = "btn_GotChat";
            this.btn_GotChat.Size = new System.Drawing.Size(66, 54);
            this.btn_GotChat.TabIndex = 12;
            this.btn_GotChat.Text = "나를좋아해주는사람";
            this.btn_GotChat.UseVisualStyleBackColor = true;
            this.btn_GotChat.Click += new System.EventHandler(this.btn_GotChat_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(390, 526);
            this.Controls.Add(this.btn_GotChat);
            this.Controls.Add(this.btnDislike);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.lblProfile2);
            this.Controls.Add(this.lblProfile1);
            this.Controls.Add(this.lblIdealProfile2);
            this.Controls.Add(this.lblIdealProfile1);
            this.Controls.Add(this.idealPic);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnBoard);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.btnHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenuForm_FormClosed);
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idealPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnBoard;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblIdealProfile1;
        private System.Windows.Forms.Label lblIdealProfile2;
        private System.Windows.Forms.PictureBox idealPic;
        private System.Windows.Forms.Label lblProfile1;
        private System.Windows.Forms.Label lblProfile2;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnDislike;
        private System.Windows.Forms.Button btn_GotChat;
    }
}
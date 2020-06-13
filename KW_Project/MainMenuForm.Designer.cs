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
            this.idealPic = new System.Windows.Forms.PictureBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnBoard = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.idealPic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExit.Location = new System.Drawing.Point(477, 12);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 31);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblIdealProfile1
            // 
            this.lblIdealProfile1.AutoSize = true;
            this.lblIdealProfile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIdealProfile1.Location = new System.Drawing.Point(98, 320);
            this.lblIdealProfile1.Name = "lblIdealProfile1";
            this.lblIdealProfile1.Size = new System.Drawing.Size(0, 25);
            this.lblIdealProfile1.TabIndex = 6;
            // 
            // lblIdealProfile2
            // 
            this.lblIdealProfile2.AutoSize = true;
            this.lblIdealProfile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIdealProfile2.Location = new System.Drawing.Point(98, 352);
            this.lblIdealProfile2.Name = "lblIdealProfile2";
            this.lblIdealProfile2.Size = new System.Drawing.Size(0, 29);
            this.lblIdealProfile2.TabIndex = 7;
            // 
            // lblProfile1
            // 
            this.lblProfile1.AutoSize = true;
            this.lblProfile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProfile1.ForeColor = System.Drawing.Color.White;
            this.lblProfile1.Location = new System.Drawing.Point(6, 351);
            this.lblProfile1.Name = "lblProfile1";
            this.lblProfile1.Size = new System.Drawing.Size(79, 29);
            this.lblProfile1.TabIndex = 8;
            this.lblProfile1.Text = "label1";
            // 
            // lblProfile2
            // 
            this.lblProfile2.AutoSize = true;
            this.lblProfile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProfile2.ForeColor = System.Drawing.Color.White;
            this.lblProfile2.Location = new System.Drawing.Point(6, 301);
            this.lblProfile2.Name = "lblProfile2";
            this.lblProfile2.Size = new System.Drawing.Size(103, 38);
            this.lblProfile2.TabIndex = 9;
            this.lblProfile2.Text = "label2";
            // 
            // idealPic
            // 
            this.idealPic.Location = new System.Drawing.Point(68, 33);
            this.idealPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idealPic.Name = "idealPic";
            this.idealPic.Size = new System.Drawing.Size(391, 398);
            this.idealPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.idealPic.TabIndex = 5;
            this.idealPic.TabStop = false;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.White;
            this.btnProfile.BackgroundImage = global::KW_Project.Properties.Resources.instaiconpro;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnProfile.Location = new System.Drawing.Point(399, 572);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(115, 72);
            this.btnProfile.TabIndex = 3;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnBoard
            // 
            this.btnBoard.BackColor = System.Drawing.Color.White;
            this.btnBoard.BackgroundImage = global::KW_Project.Properties.Resources.instafeed;
            this.btnBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoard.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnBoard.FlatAppearance.BorderSize = 0;
            this.btnBoard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnBoard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnBoard.Location = new System.Drawing.Point(271, 572);
            this.btnBoard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(115, 72);
            this.btnBoard.TabIndex = 2;
            this.btnBoard.UseVisualStyleBackColor = false;
            this.btnBoard.Click += new System.EventHandler(this.BtnBoard_Click);
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.White;
            this.btnChat.BackgroundImage = global::KW_Project.Properties.Resources.instaiconchat;
            this.btnChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChat.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnChat.Location = new System.Drawing.Point(141, 572);
            this.btnChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(115, 72);
            this.btnChat.TabIndex = 1;
            this.btnChat.UseVisualStyleBackColor = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.BackgroundImage = global::KW_Project.Properties.Resources.instaiconhome;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnHome.Location = new System.Drawing.Point(11, 572);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(115, 72);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 658);
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
    }
}
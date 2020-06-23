namespace KW_Project
{
    partial class GotChat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAgeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDptCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDhatCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvDelCol = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(506, 21);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "이상형을 최대 10명까지 저장할 수 있습니다";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvNameCol,
            this.dgvAgeCol,
            this.dgvDptCol,
            this.dgvDhatCol,
            this.dgvDelCol});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(506, 423);
            this.dataGridView1.TabIndex = 5;
            // 
            // dgvNameCol
            // 
            this.dgvNameCol.HeaderText = "이름";
            this.dgvNameCol.MinimumWidth = 6;
            this.dgvNameCol.Name = "dgvNameCol";
            this.dgvNameCol.ReadOnly = true;
            this.dgvNameCol.Width = 125;
            // 
            // dgvAgeCol
            // 
            this.dgvAgeCol.HeaderText = "나이";
            this.dgvAgeCol.MinimumWidth = 6;
            this.dgvAgeCol.Name = "dgvAgeCol";
            this.dgvAgeCol.ReadOnly = true;
            this.dgvAgeCol.Width = 60;
            // 
            // dgvDptCol
            // 
            this.dgvDptCol.HeaderText = "학과";
            this.dgvDptCol.MinimumWidth = 6;
            this.dgvDptCol.Name = "dgvDptCol";
            this.dgvDptCol.ReadOnly = true;
            this.dgvDptCol.Width = 130;
            // 
            // dgvDhatCol
            // 
            this.dgvDhatCol.HeaderText = "채팅";
            this.dgvDhatCol.MinimumWidth = 6;
            this.dgvDhatCol.Name = "dgvDhatCol";
            this.dgvDhatCol.ReadOnly = true;
            this.dgvDhatCol.Width = 40;
            // 
            // dgvDelCol
            // 
            this.dgvDelCol.HeaderText = "삭제";
            this.dgvDelCol.MinimumWidth = 6;
            this.dgvDelCol.Name = "dgvDelCol";
            this.dgvDelCol.ReadOnly = true;
            this.dgvDelCol.Width = 40;
            // 
            // GotChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GotChat";
            this.Text = "GotChat";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAgeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDptCol;
        private System.Windows.Forms.DataGridViewButtonColumn dgvDhatCol;
        private System.Windows.Forms.DataGridViewButtonColumn dgvDelCol;
    }
}
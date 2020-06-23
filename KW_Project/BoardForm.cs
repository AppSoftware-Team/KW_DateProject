using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;
using MySql.Data.MySqlClient;

namespace KW_Project
{
    public partial class BoardForm : Form
    {
        private string currentUserId;
        private string currentUserGender;
        private Point mousePoint;

        private const int CS_DROPSHADOW = 0x00020000;

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        public BoardForm(string id,string gender)
        {
            currentUserId = id;
            currentUserGender = gender;
        
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                    , int nTopRect
                                                    , int nRightRect
                                                    , int nBottomRect
                                                    , int nWidthEllipse
                                                    , int nHeightEllipse);

        private void BoardForm_Load(object sender, EventArgs e)
        {
            //테두리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            DataGridViewImageColumn img1 = new DataGridViewImageColumn();
            img1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img1.Width = 198;
            DataGridViewImageColumn img2 = new DataGridViewImageColumn();
            img2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img2.Width = 198;
            DataGridViewImageColumn img3 = new DataGridViewImageColumn();
            img3.ImageLayout = DataGridViewImageCellLayout.Stretch;
            img3.Width = 198;

            dataGridView1.Columns.Add(img1);
            dataGridView1.Columns.Add(img2);
            dataGridView1.Columns.Add(img3);
            dataGridView1.RowTemplate.Height = 198;

            connectData(); //그 아이디에 해당하는 사진들을 모두 불러온다.
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void connectData()
        {
            MySqlCommand query = connection.CreateCommand();

            if (currentUserGender == "남자")
                  query.CommandText = "SELECT file from board_data_f";
            else if (currentUserGender == "여자") 
                   query.CommandText = "SELECT file from board_data_m ";

            Bitmap[] row = new Bitmap[3];
            try
            {
                connection.Open();
                int count=0;
                MySqlDataReader reader = query.ExecuteReader();
                byte[] Image = null;

                while (reader.Read())
                {
                    Image = (byte[])reader[0];
                    
                    row[count] = new Bitmap(new MemoryStream(Image));
                    count++;

                    if (count == 3) // 이미지 3개 받으면 Grid에 넣기
                    {
                        dataGridView1.Rows.Add(row);
                        row = new Bitmap[3];
                        count = 0;
                    }
                }

                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
     
        private void BtnShare_Click(object sender, EventArgs e)
        {
            btnBoardShare bbs = new btnBoardShare(currentUserId,currentUserGender);
            bbs.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
    

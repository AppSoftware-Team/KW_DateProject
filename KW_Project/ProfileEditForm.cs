using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient; // Mysql 사용
using System.IO;

namespace KW_Project
{
    public partial class ProfileEditForm : Form
    {
        private string currentUserId;
        private string currentUserGender;
        private int genderFlag;
        public string filepath = null;// 받아온 파일 경로
        private const int CS_DROPSHADOW = 0x00020000;
        private Point mousePoint;

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");

        public ProfileEditForm(string id,string gender)
        {
            currentUserId = id;
            currentUserGender = gender;
            InitializeComponent();
            loadProfilePhoto(); // 현재 프로필 불러오기

            if (currentUserGender == "남자")
                genderFlag = 0;
            else if (currentUserGender == "여자")
                genderFlag = 1;
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                      , int nTopRect
                                                      , int nRightRect
                                                      , int nBottomRect
                                                      , int nWidthEllipse
                                                      , int nHeightEllipse);
        // 폼 그림자 설정;
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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void profilePic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    profilePic.Image = Image.FromFile(openFileDialog1.FileName);
                    profilePic.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (filepath == null)
            {
                this.Close(); // 사진 변경 안 했을 경우 
                return;
            }

            UInt32 fileSize;
            BinaryReader br;
            FileStream fs;
            byte[] ImageData;
            fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            fileSize = (UInt32)fs.Length;
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);

            connection.Open();

            // 프로필 사진 업데이트
            string insertQuery = "";
            if(currentUserGender == "남자")
                insertQuery = "UPDATE profile_photo_data_m SET fileSize=@fileSize,file=@file WHERE id = @id";
            else if (currentUserGender=="여자")
                insertQuery = "UPDATE profile_photo_data_f SET fileSize=@fileSize,file=@file WHERE id = @id";

            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@id", currentUserId);
            command.Parameters.Add("@file", MySqlDbType.Blob);
            command.Parameters.AddWithValue("@fileSize", fileSize);
            command.Parameters["@file"].Value = ImageData;

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("저장 완료!");
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("비정상 전송");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            br.Close();
            fs.Close();
            connection.Close();
            
            //프로필 수정 창 닫기
            this.Close();
        }

        // mysql에서 프로필 사진 불러오기
        private void loadProfilePhoto()
        {
            string insertQuery="";
            byte[] Image = null;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();

            if (currentUserGender == "남자")
                insertQuery = "SELECT file from profile_photo_data_m WHERE id=@id";
            else if (currentUserGender == "여자")
                insertQuery = "SELECT file from profile_photo_data_f WHERE id=@id";
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@id", currentUserId);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Image = (byte[])reader[0];
                    profilePic.Image = new Bitmap(new MemoryStream(Image));
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }


        private void btnFirstSet_Click(object sender, EventArgs e)
        {
            FirstSettingForm settingform = new FirstSettingForm(currentUserId, genderFlag, true);
            DialogResult result = settingform.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("수정 완료!");
            }
        }

        private void btnSecondSet_Click(object sender, EventArgs e)
        {
            SecondSettingForm settingform = new SecondSettingForm(currentUserId, genderFlag, true);
            DialogResult result = settingform.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("수정 완료!");
            }
        }
    }
}

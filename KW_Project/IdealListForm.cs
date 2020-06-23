using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient; // Mysql 사용
using System.IO;

namespace KW_Project
{
    public partial class IdealListForm : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        private string currentUserId;
        private string currentUserGender;
        private string[] myIdealList;


        public IdealListForm(string myId, string myGender)
        {
            InitializeComponent();
            currentUserId = myId;
            currentUserGender = myGender;
        }


        private void IdealListForm_Load(object sender, EventArgs e)
        {
            // Image Col 추가 
            DataGridViewImageColumn ImageCol = new DataGridViewImageColumn();
            ImageCol.Name = "사진";
            ImageCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            ImageCol.Width = 180;

            dataGridView1.Columns.Add(ImageCol);

            dataGridView1.Columns["사진"].DisplayIndex = 0;

            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 95;
            dataGridView1.Columns[3].Width = 45;
            dataGridView1.Columns[4].Width = 45;

            dataGridView1.RowTemplate.Height = 180;



            GetData(currentUserId); // 이상형 ID 불러오기

            SetData(); // 불러온 ID로 리스트 만들기
        }
        
        private void SetData()
        {

            for (int i = 0; i < myIdealList.Length-1; i++)
            { 
                object[] dr = new object[6];
                byte[] Image = null;

                try
                {
                    string ReadQuery = "";
                    
                    //
                    //
                    //사진 불러오기
                    if (currentUserGender == "남자")
                        ReadQuery = "SELECT file from profile_photo_data_f WHERE id=" + myIdealList[i];
                    else if (currentUserGender == "여자")
                        ReadQuery = "SELECT file from profile_photo_data_m WHERE id=" + myIdealList[i];
                                        
                    connection.Open();
                    MySqlCommand cmd1 = new MySqlCommand(ReadQuery, connection);
                    MySqlDataReader table1 = cmd1.ExecuteReader();
                    if (table1.Read())
                    {
                        Image = (byte[])table1[0];
                    }
                    table1.Close();
                    connection.Close();


                    //
                    //
                    //나머지 정보 불러오기
                    if (currentUserGender == "남자")
                        ReadQuery = "SELECT * from user_data_f WHERE id=" + myIdealList[i];
                    else if (currentUserGender == "여자")
                        ReadQuery = "SELECT * from user_data_m WHERE id=" + myIdealList[i];

                    connection.Open();
                    MySqlCommand cmd2 = new MySqlCommand(ReadQuery, connection);
                    MySqlDataReader table2 = cmd2.ExecuteReader();

                    if (table2.Read()) {
                        dr[0] = table2["name"];
                        dr[1] = table2["age"];
                        dr[2] = table2["department"];
                        //
                        // 채팅 버튼
                        dr[3] = new Button();
                        dr[4] = new Button();
                        ((Button)dr[3]).MouseDown += btnChat_Click;
                        ((Button)dr[4]).MouseClick += btnDel_Click;
                    }
                     
                    table2.Close();
                    connection.Close();

                    
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], new Bitmap(new MemoryStream(Image)));

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void GetData(string myId)       //mysql에 이상형들이 저장되어있으면 불러오기
        {
            try
            {
                connection.Open();
                // myId로 Mysql에서 가져옴

                string ReadQuery = null;

                if (currentUserGender == "남자")
                    ReadQuery = "SELECT ideal_id from project_data.user_data_m WHERE id=@curID;";
                else if (currentUserGender == "여자")
                    ReadQuery = "SELECT ideal_id from project_data.user_data_f WHERE id=@curID;";

                MySqlCommand command = new MySqlCommand(ReadQuery, connection);
                command.Parameters.AddWithValue("@curID", currentUserId);
                MySqlDataReader reader = command.ExecuteReader();

                /*for (int i = 1; i < 11; i++)
                {
                    string col = "ideal" + i + "_id";
                    if (table.Read()) // 이상형 데이터 읽기
                    {
                        if (table[col].ToString() != "")
                        {
                            ideals[i - 1] = table[col].ToString();
                        }
                        else
                        {
                            break;      //빈 column까지 읽으면 탈출
                        }
                    }
                }*/

                if (reader.Read())
                {
                    string mIdeals = reader["ideal_id"].ToString();
                    // 이상형 ID들 저장
                    myIdealList = mIdeals.Split('_');
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(((Button)sender).Controls.ToString());
           /* ChatServerForms chat = new ChatServerForms();
            chat.Show();*/
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi!");
        }

        private void btnStartChat_Click(object sender, EventArgs e)
        {
            ChatServerForms chat = new ChatServerForms();
            chat.Show();
        }

        private void btnReceiveChat_Click(object sender, EventArgs e)
        {
            ChatClientForm chat = new ChatClientForm(this);
            chat.Show();
        }
    }
}

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
    public partial class GotChat : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        private string currentUserId;
        private string currentUserGender;
        private List<string> gotChatList = new List<string>();

        public GotChat(string myId, string myGender)
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



            GetData(); // 나를 좋아요 누른 사람들 ID 불러오기

            SetData(); // 불러온 ID로 리스트 만들기
        }

        private void SetData()
        {

            for (int i = 0; i < gotChatList.Count; i++)
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
                        ReadQuery = "SELECT file from profile_photo_data_f WHERE id=" + gotChatList[i];
                    else if (currentUserGender == "여자")
                        ReadQuery = "SELECT file from profile_photo_data_m WHERE id=" + gotChatList[i];

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
                        ReadQuery = "SELECT * from user_data_f WHERE id=" + gotChatList[i];
                    else if (currentUserGender == "여자")
                        ReadQuery = "SELECT * from user_data_m WHERE id=" + gotChatList[i];

                    connection.Open();
                    MySqlCommand cmd2 = new MySqlCommand(ReadQuery, connection);
                    MySqlDataReader table2 = cmd2.ExecuteReader();

                    if (table2.Read())
                    {
                        dr[0] = table2["name"];
                        dr[1] = table2["age"];
                        dr[2] = table2["department"];
                        //
                        // 채팅 버튼
                        dr[3] = new Button();
                        dr[4] = new Button();
                    }

                    table2.Close();
                    connection.Close();

                    try
                    {
                        dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], new Bitmap(new MemoryStream(Image)));
                    }
                    catch { }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                foreach (DataGridViewRow obj in dataGridView1.Rows)
                {
                    obj.Cells[3].Value = "수락";
                    obj.Cells[4].Value = "거절";
                }
            }
        }

        private void GetData()       //mysql에 나를 좋아요 눌러준 사람이 저장되어있으면 불러오기
        {
            try
            {
                connection.Open();
                // myId로 Mysql에서 가져옴

                string ReadQuery = null;

                if (currentUserGender == "남자")
                    ReadQuery = "SELECT got_chat_id from project_data.user_data_m WHERE id=@curID;";
                else if (currentUserGender == "여자")
                    ReadQuery = "SELECT got_chat_id from project_data.user_data_f WHERE id=@curID;";

                MySqlCommand command = new MySqlCommand(ReadQuery, connection);
                command.Parameters.AddWithValue("@curID", currentUserId);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string[] got_chat = (reader["got_chat_id"].ToString()).Split('_');
                    // 나를 좋아요 누른 사람들 id 저장
                    for (int i = 0; i < got_chat.Length - 1; i++)
                    {
                        gotChatList.Add(got_chat[i]);
                    }
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            int intRow = e.RowIndex;
            int intCol = e.ColumnIndex;

            Type typeObject = grid.Rows[intRow].Cells[intCol].GetType();
            switch (intCol)
            {
                case 3:
                    //채팅 신청버튼 클릭
                    btn_Chat(intRow, intCol);
                    break;
                case 4:
                    //삭제 버튼 클릭
                    btn_Del(intRow);
                    break;
            }
        }
        private void btn_Del(int intRow)
        {
            string readQuery = "";
            string insertQuery = "";
            string old = string.Empty;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();
            MySqlDataReader reader;

            // selected_ideal 초기화
            if (currentUserGender == "남자")
                readQuery = "SELECT got_chat_id from user_data_m where id=@ideal_Id";
            else if (currentUserGender == "여자")
                readQuery = "SELECT got_chat_id from user_data_f where id=@ideal_Id";

            connection.Open();

            command = new MySqlCommand(readQuery, connection);
            command.Parameters.AddWithValue("@ideal_id", gotChatList[intRow]);
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                old = reader["got_chat_id"].ToString();
                string del_id = gotChatList[intRow];

                old.Replace(del_id + "_", "");
                gotChatList.Remove(del_id);
            }
            reader.Close();
            connection.Close();
            dataGridView1.Rows.Remove(dataGridView1.Rows[intRow]);

            string new_got_chat = string.Empty;
            for (int i = 0; i < gotChatList.Count; i++)
            {
                new_got_chat += gotChatList[i] + "_";
            }
            // ideal_id 다시 저장
            if (currentUserGender == "남자")
                insertQuery = "UPDATE user_data_f SET got_chat_id=@got_chat_id WHERE id=@ideal_ID;";
            else if (currentUserGender == "여자")
                insertQuery = "UPDATE user_data_m SET got_chat_id=@got_chat_id WHERE id=@ideal_ID;";

            connection.Open();

            command = new MySqlCommand(insertQuery, connection);
            try
            {
                command.Parameters.AddWithValue("@ideal_ID", gotChatList[intRow]);
                command.Parameters.AddWithValue("@got_chat_id", new_got_chat);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();
        }
        private void btn_Chat(int intRow ,int intCol)
        {
            ChatClientForm chat = new ChatClientForm(this, dataGridView1.Rows[intRow].Cells[0].Value.ToString());
            chat.Show();
        }
    }
}

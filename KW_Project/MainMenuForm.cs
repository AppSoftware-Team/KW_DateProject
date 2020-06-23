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
    public partial class MainMenuForm : Form
    {
        private string currentUserId;
        private string currentUserGender;
        private const int CS_DROPSHADOW = 0x00020000;
        public string idealId = string.Empty; // 현재 화면에 나와있는 이성 ID
        private string[] myIdealAttraction;
        private Dictionary<int, string> idealList = new Dictionary<int, string>(); // 이성 프로필 전부 저장
        private Dictionary<int, int> idealCount = new Dictionary<int, int>(); 
        private Dictionary<int,int> selected_ideal = new Dictionary<int,int>();   //좋아요 or 싫어요 누른 이성 key, 싫어요:0, 좋아요:1 저장
        private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        private Point mousePoint;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                    , int nTopRect
                                                    , int nRightRect
                                                    , int nBottomRect
                                                    , int nWidthEllipse
                                                    , int nHeightEllipse);

        public MainMenuForm(string id,string gender)
        {
            currentUserId = id;
            currentUserGender = gender;
            //btnHome.Enabled = false;

            InitializeComponent();
            lblProfile1.Parent = idealPic;
            lblProfile2.Parent = idealPic;

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
 

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            //테두리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));

            // 매칭 알고리즘
            MatchingAlortithmSetting(); // DB에 있는 이성의 데이터 모두 로컬로 가져오는 용도

            if (currentUserGender == "남자")
                idealId = MatchingAlgorithm();
            else if (currentUserGender == "여자")
                idealId = MatchingAlgorithm();

            //매칭 알고리즘 구현시 31~35줄 수정해서 ideal_id를 매칭된 사람으로 해주면 댈듯?? -->6/16일 추가 : 전역변수로 idealId만들었으니 여기 할당해주면 댐
            //취소버튼 누르면 다시 다른사람 매칭해서 밑에 함수 두개 실행시켜주는식으로
            LoadIdealPhoto();
            LoadIdealProfile();
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

        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileEditForm profileeditform = new ProfileEditForm(currentUserId, currentUserGender);
            profileeditform.ShowDialog();
        }

        // mysql에서 프로필 사진 불러오기
        private void LoadIdealPhoto()
        {
            string insertQuery = "";
            byte[] Image = null;

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();

            if (currentUserGender == "남자")
                insertQuery = "SELECT file from profile_photo_data_f WHERE id=@id";
            else if (currentUserGender == "여자")
                insertQuery = "SELECT file from profile_photo_data_m WHERE id=@id";
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@id", idealId);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Image = (byte[])reader[0];
                    idealPic.Image = new Bitmap(new MemoryStream(Image));
                }

                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadIdealProfile()
        {
            string insertQuery = "";

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();

            if (currentUserGender == "남자")
                insertQuery = "SELECT * from user_data_f WHERE id=@id";
            else if (currentUserGender == "여자")
                insertQuery = "SELECT * from user_data_m WHERE id=@id";
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@id", idealId);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    lblProfile1.BackColor = System.Drawing.Color.Transparent;
                    lblProfile1.Text = reader["department"].ToString();
                    lblProfile1.Text += " ";
                    lblProfile1.Text += reader["age"].ToString();

                    lblProfile2.BackColor = System.Drawing.Color.Transparent;
                    lblProfile2.Text = reader["name"].ToString();
                }

                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }


        private void btnBoard_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            BoardForm boardForm = new BoardForm(currentUserId,currentUserGender);
            DialogResult result = boardForm.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }

        private void MatchingAlortithmSetting()
        {
            string insertQuery = "";

            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
            MySqlCommand command = new MySqlCommand();
            MySqlDataReader reader;

            if (currentUserGender == "남자")
                insertQuery = "SELECT user_data_m.ideal from project_data.user_data_m WHERE id=@curID;";
            else if (currentUserGender == "여자")
                insertQuery = "SELECT user_data_f.ideal from project_data.user_data_f WHERE id=@curID;";

            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@curId", currentUserId);

                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string mIdeal = reader["ideal"].ToString();

                    // 자신의 ideal 저장
                    myIdealAttraction = mIdeal.Split('_');

                }

                reader.Close();
                connection.Close();

                // 이성의 attraction 가져와 자신의 ideal과 비교
                switch (currentUserGender)
                {
                    case "남자":
                        {
                            insertQuery = "SELECT id,user_data_f.attraction from project_data.user_data_f";

                            connection.Open();
                            command.Connection = connection;
                            command.CommandText = insertQuery;

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                // DB에서 모든 이성의 데이터 가져오기
                                if (idealList.ContainsKey(Convert.ToInt32(reader[0])) == false)
                                    idealList.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
                            }

                            reader.Close();
                            connection.Close();

                            break;
                        }
                    case "여자":
                        {
                            insertQuery = "SELECT id,user_data_m.attraction from project_data.user_data_m";

                            connection.Open();
                            command.Connection = connection;
                            command.CommandText = insertQuery;

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                // DB에서 모든 이성의 데이터 가져오기
                                if (idealList.ContainsKey(Convert.ToInt32(reader[0])) == false)
                                    idealList.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
                            }

                            reader.Close();
                            connection.Close();

                            break;
                        }
                }

                // selected_ideal 초기화
                if (currentUserGender == "남자")
                    insertQuery = "SELECT ideal_id from user_data_m where id=@curId";
                else if (currentUserGender == "여자")
                    insertQuery = "SELECT ideal_id from user_data_f where id=@curId";

                connection.Open();

                command = new MySqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@curID", currentUserId);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    tempIdealList = reader["ideal_id"].ToString(); // 일시적으로 저장

                    string[] name = tempIdealList.Split('_');

                    for(int i = 0; i < name.Length-1;i++)
                    {
                        selected_ideal.Add(Int32.Parse(name[i]),1);
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

        private string MatchingAlgorithm()
        {
            int idealCnt = 0; // 일치하는 매력 총 개수
            int idealid = 0;  // 가장 적합한 이성
            bool flag = false; // 이상형 비교시 첫번째 비교할 이상형인지 확인하는 변수
            
            foreach (var pair in idealList)
            {
                if (selected_ideal.Keys.Contains(pair.Key))
                    continue;
                int Cnt = 0;
                
                string[]idealAttraction = pair.Value.Split('_');
                for(int i=0; i < myIdealAttraction.Length-1; i++)
                {
                    if (idealAttraction.Contains(myIdealAttraction[i]))
                        Cnt++;
                }
                if (idealCount.ContainsKey(pair.Key) == false)
                    idealCount.Add(pair.Key, Cnt);
            }
                            
            foreach(var pair in idealCount)
            {
                if (selected_ideal.Keys.Contains(pair.Key))
                    continue;
                if (flag == false) // 첫번째 사람일때 변수 초기화
                {
                    idealid = pair.Key;
                    idealCnt = pair.Value;
                    flag = true;
                }
                else
                {
                    if(pair.Value >= idealCnt)
                    {
                        idealid = pair.Key;
                        idealCnt = pair.Value;
                    }
                }
            }
            if (idealid == 0) {
                for (int i = 0; i < selected_ideal.Count; i++)
                {
                    if (selected_ideal[selected_ideal.Keys.ToArray()[i]] == 0)
                    {
                        selected_ideal.Remove(selected_ideal.Keys.ToArray()[i]);
                    }
                }
                if (selected_ideal.Count == idealList.Count)
                {
                    MessageBox.Show("모든 이성들에게 추파를 던지셨습니다!");
                }
                else
                {
                    idealid = Int32.Parse(MatchingAlgorithm());
                }
            }

            //MessageBox.Show(idealid.ToString());
            // 적합한 이성의 ID Return
            return idealid.ToString();
        }

        private string tempIdealList; // 일시적으로 DB에 ideal_id 값을 저장하는 용도
        private void btnLike_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader;
            MySqlCommand command;
            string insertQuery = null;
            string ReadQuery = null;

            if (currentUserGender == "남자")
                ReadQuery = "SELECT ideal_id from user_data_m where id=@curId";
            else if (currentUserGender == "여자")
                ReadQuery = "SELECT ideal_id from user_data_f where id=@curId";

            connection.Open();

            command = new MySqlCommand(ReadQuery, connection);
            command.Parameters.AddWithValue("@curID", currentUserId);
            reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    tempIdealList = reader["ideal_id"].ToString(); // 일시적으로 저장
                    if (tempIdealList.Contains(idealId + "_")) // 좋아요 중복
                    {
                        MessageBox.Show("이미 '좋아요'를 눌렀습니다.");

                        foreach (var key in idealList.Keys.ToList())
                        {
                            // 좋아요를 누른 이성은 더 이상 화면에 표시되지 않게
                            if (key.ToString() == idealId)
                            {
                                //idealList.Remove(key);
                                //idealCount.Remove(key);
                                selected_ideal.Add(key,1);
                            }
                        }

                        // 다시 매칭 돌린다.
                        idealId = MatchingAlgorithm();

                        LoadIdealPhoto();
                        LoadIdealProfile();

                        reader.Close();
                        connection.Close();

                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            reader.Close();
            connection.Close();

            //
            //
            // ideal_id 다시 저장
            if (currentUserGender == "남자")
                insertQuery = "UPDATE user_data_m SET ideal_id=@ideal_id WHERE id=@curID;";
            else if (currentUserGender == "여자")
                insertQuery = "UPDATE user_data_f SET ideal_id=@ideal_id WHERE id=@curID;";

            connection.Open();

            command = new MySqlCommand(insertQuery, connection);
            try
            {
                command.Parameters.AddWithValue("@curID", currentUserId);
                command.Parameters.AddWithValue("@ideal_id", tempIdealList + idealId + "_");
         
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("'좋아요'"); // 나중에 지움
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();

            //
            //
            foreach(var key in idealList.Keys.ToList())
            {
                // 좋아요를 누른 이성은 더 이상 화면에 표시되지 않게
                if (key.ToString() == idealId)
                {
                    //idealList.Remove(key);
                    //idealCount.Remove(key);
                    selected_ideal.Add(key,1);
                }
            }
            AddToGotChat();

            // 다시 매칭 돌린다.
            idealId = MatchingAlgorithm();

            LoadIdealPhoto();
            LoadIdealProfile();
        }

        private void btnDislike_Click(object sender, EventArgs e)
        {
            //
            //
            foreach (var key in idealList.Keys.ToList())
            {
                // 좋아요를 누른 이성은 더 이상 화면에 표시되지 않게
                if (key.ToString() == idealId)
                {
                    //idealList.Remove(key);
                    //idealCount.Remove(key);
                    selected_ideal.Add(key, 0);
                }
            }

            // 다시 매칭 돌린다.
            idealId = MatchingAlgorithm();

            LoadIdealPhoto();
            LoadIdealProfile();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            IdealListForm idealList = new IdealListForm(currentUserId, currentUserGender);
            idealList.ShowDialog();
        }

        private void btn_GotChat_Click(object sender, EventArgs e)
        {
            GotChat gotChatList = new GotChat(currentUserId, currentUserGender);
            gotChatList.ShowDialog();
        }
        private void AddToGotChat()
        {
            MySqlDataReader reader;
            MySqlCommand command;
            string insertQuery = null;
            string ReadQuery = null;
            string old_got_chat = string.Empty;

            if (currentUserGender == "남자")
                ReadQuery = "SELECT got_chat_id from user_data_f where id=@ideal_Id";
            else if (currentUserGender == "여자")
                ReadQuery = "SELECT got_chat_id from user_data_m where id=@ideal_Id";

            connection.Open();

            command = new MySqlCommand(ReadQuery, connection);
            command.Parameters.AddWithValue("@ideal_ID", idealId);
            reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    old_got_chat = reader["got_chat_id"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            reader.Close();
            connection.Close();

            // got_chat_id 다시 저장
            if (currentUserGender == "남자")
                insertQuery = "UPDATE user_data_f SET got_chat_id=@cur_id WHERE id=@ideal_ID;";
            else if (currentUserGender == "여자")
                insertQuery = "UPDATE user_data_m SET got_chat_id=@cur_id WHERE id=@ideal_ID;";

            connection.Open();

            command = new MySqlCommand(insertQuery, connection);
            try
            {
                command.Parameters.AddWithValue("@cur_id", old_got_chat + currentUserId+"_");
                command.Parameters.AddWithValue("@ideal_id", idealId);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("'Got_Chat등록'"); // 나중에 지움
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();
        }
    }

}


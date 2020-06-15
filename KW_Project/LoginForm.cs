using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient; // Mysql 사용

namespace KW_Project
{
    public partial class loginForm : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");

        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("입력 정보를 확인하세요!");
                return;
            }

            try
            {
                connection.Open();
                // 현재 입력한 학번으로 Mysql에서 가져옴
                
                string ReadQuery = "SELECT * FROM user_data_m where id = " + txtId.Text; 
                
                MySqlCommand cmd = new MySqlCommand(ReadQuery, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                if (table.Read()) // 남자 데이터 먼저 읽기
                {
                    if (txtId.Text == table["id"].ToString() && txtPwd.Text == table["pwd"].ToString())
                    {
                        this.Visible = false; // 로그인 창 닫아놓기
                        string userFlag = table["userFlag"].ToString();

                        // 기존 회원
                        if (userFlag == "1") 
                            existMember(table);
                        // 신규 회원
                        else
                            newMember(0);
                    }
                    else
                    {
                        MessageBox.Show("입력 정보를 확인하세요!");
                    }
                }
                else 
                {
                    table.Close();

                    ReadQuery = "SELECT * FROM user_data_f where id = " + txtId.Text;
                    cmd = new MySqlCommand(ReadQuery, connection);
                    table = cmd.ExecuteReader();

                    if (table.Read()) // 여자 데이터 읽기
                    {
                        if (txtId.Text == table["id"].ToString() && txtPwd.Text == table["pwd"].ToString())
                        {
                            this.Visible = false; // 로그인 창 닫아놓기
                            string userFlag = table["userFlag"].ToString();

                            // 기존 회원
                            if (userFlag == "1")
                                existMember(table);
                            // 신규 회원
                            else
                                newMember(1);
                        }
                        else
                        {
                            MessageBox.Show("입력 정보를 확인하세요!");
                        }
                    }
                   
                }

                table.Close();
                connection.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("DataBase 읽기 실패");
                MessageBox.Show(E.ToString());
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Visible = false; // 로그인 창 닫아놓기

            RegisterForm registerform = new RegisterForm();
            DialogResult result = registerform.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                this.Visible = true;
            }
            else if (result == DialogResult.No) // form을 아예 종료
            {
                this.Close();

            }
        }
        private void existMember(MySqlDataReader table) //기존 회원 로그인 함수      ---사진등록만 안하고 재로그인시 사진등록 없이 메인화면 넘어가는 버그 있음
        {
            // 로딩 창
            LoadingForm loadingform = new LoadingForm();
            DialogResult result = loadingform.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                MainMenuForm mainform = new MainMenuForm(table["id"].ToString(), table["gender"].ToString());
                mainform.Show();
            }
        }
        private void newMember(int genderFlag)    // 신규 회원 로그인 함수 // 0 이면 남자 1이면 여자
        {
            FirstSettingForm settingform = new FirstSettingForm(txtId.Text, genderFlag, false);
            DialogResult result = settingform.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                this.Visible = true;
            }
            else if (result == DialogResult.No)
            {
                //this.Close();    
            }
        }
    }
}

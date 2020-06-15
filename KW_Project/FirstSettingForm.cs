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
using MySql.Data.MySqlClient;

namespace KW_Project
{
    public partial class FirstSettingForm : Form
    {
        private string currentUserId;
        private int genderFlag;
        private bool connectFlag;
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");

        public FirstSettingForm(string id, int gender, bool connectFlag)
        {
            currentUserId = id;
            genderFlag = gender;
            this.connectFlag = connectFlag; // 메인에서 접근한 것인지 로딩창에서 접근한 것인지 확인하는 용도
            InitializeComponent();
            SetBtnEvent();
        }
        private void SetBtnEvent()
        {
            button1.Click += Btn_Click;
            button2.Click += Btn_Click;
            button3.Click += Btn_Click;
            button4.Click += Btn_Click;
            button5.Click += Btn_Click;
            button6.Click += Btn_Click;
            button7.Click += Btn_Click;
            button8.Click += Btn_Click;
            button9.Click += Btn_Click;
            button10.Click += Btn_Click;
            button11.Click += Btn_Click;
            button12.Click += Btn_Click;
            button13.Click += Btn_Click;
            button14.Click += Btn_Click;
            button15.Click += Btn_Click;
            button16.Click += Btn_Click;
        }

        private void FirstSettingForm_Load(object sender, EventArgs e)
        {
            // 테두리 둥글게
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));

        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect
                                                      , int nTopRect
                                                      , int nRightRect
                                                      , int nBottomRect
                                                      , int nWidthEllipse
                                                      , int nHeightEllipse);


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Button[] attList1 = new Button[8];               //본인 성격 버튼 배열
            attList1[0] = button1;
            attList1[1] = button2;
            attList1[2] = button3;
            attList1[3] = button4;
            attList1[4] = button5;
            attList1[5] = button6;
            attList1[6] = button7;
            attList1[7] = button8;

            Button[] attList2 = new Button[8];              //본인 매력포인트 버튼 배열
            attList2[0] = button9;
            attList2[1] = button10;
            attList2[2] = button11;
            attList2[3] = button12;
            attList2[4] = button13;
            attList2[5] = button14;
            attList2[6] = button15;
            attList2[7] = button16;

            if (!IsAttractSelected(attList1, attList2))              //버튼이 3개씩 선택되지 않았을 경우 리턴
                return;

            // 이름, 성별, 학과, 본인어필, 이상형 전송
            string attList = SelectedAttraction(attList1) + SelectedAttraction(attList2);
            string insertQuery = null;
            if(genderFlag == 0)
                insertQuery = "UPDATE user_data_m SET name=@name, age=@age, gender=@gender, department=@department, attraction=@attList WHERE id=@curID;";
            else if(genderFlag == 1)
                insertQuery = "UPDATE user_data_f SET name=@name, age=@age, gender=@gender, department=@department, attraction=@attList WHERE id=@curID;";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                command.Parameters.AddWithValue("@curID", currentUserId);
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@age", cmbAge.SelectedItem);
                switch (genderFlag)
                {
                    case 0:
                        command.Parameters.AddWithValue("@gender", "남자");
                        break;
                    case 1:
                        command.Parameters.AddWithValue("@gender", "여자");
                        break;
                }
                command.Parameters.AddWithValue("@department", departmentList.SelectedItem.ToString());
                command.Parameters.AddWithValue("@attList", attList);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("정상 전송"); // 나중에 지움
                }
                else
                {
                    MessageBox.Show("비정상 전송");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            connection.Close();
            if(connectFlag == false)
            {
                this.Visible = false; // 첫번째 세팅창 닫기

                SecondSettingForm settingform = new SecondSettingForm(currentUserId, genderFlag,false);
                DialogResult result = settingform.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    this.Visible = true;
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
           
        }

        private bool IsAttractSelected(Button[] btns1, Button[] btns2)        //성격, 매력 버튼이 각각 3개 선택되었는지 체크
        {
            Color selected = Color.PaleGreen;     //선택되었을때의 색깔
            int count1 = 0;
            for (int i = 0; i < btns1.Length; i++)
            {
                if (btns1[i].BackColor == selected)
                    count1++;
            }
            int count2 = 0;
            for (int i = 0; i < btns2.Length; i++)
            {
                if (btns2[i].BackColor == selected)
                    count2++;
            }
            if (count1 == 3 && count2 == 3)
                return true;
            else
            {
                string message = null;
                if (count1 != 3)
                    message += "자신의 성격";
                if (count2 != 3)
                    message += "자신의 매력";
                MessageBox.Show(message + "을 3개 선택해 주세요!");
                return false;
            }
        }

        private string SelectedAttraction(Button[] btns)           // 선택된 버튼들 string으로 반환
        {
            string ret = null;
            Color selected = Color.PaleGreen;               // 색 수정시 이부분 수정

            for (int i = 0; i < btns.Length; i++)
            {
                if (btns[i].BackColor == selected)
                    ret += btns[i].Text + "_";
            }
            return ret;
        }

        private void Btn_Click(object sender, EventArgs e)          //버튼들 공통 이벤트 처리
        {
            Color basic = Color.LightCoral;             //   -- 색 수정시 이부분 수정
            Color clicked = Color.PaleGreen;            //   ┘ 
            if ((sender as Button).BackColor.Equals(basic))
            {
                (sender as Button).BackColor = clicked;
                return;
            }
            if ((sender as Button).BackColor.Equals(clicked))
            {
                (sender as Button).BackColor = basic;
                return;
            }
        }
    }

}

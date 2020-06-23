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
    public partial class SecondSettingForm : Form
    {
        private string currentUserId;
        private int genderFlag;
        private bool connectFlag;
        private Point mousePoint;

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=project_data;Uid=root;Pwd=1234");
        private const int CS_DROPSHADOW = 0x00020000;

        public SecondSettingForm(string id, int gender, bool connectFlag)
        {
            currentUserId = id;
            genderFlag = gender;
            this.connectFlag = connectFlag;
            InitializeComponent();
            SetBtnEvent();

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
        private void SecondSetting_Load(object sender, EventArgs e)
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
            Button[] idealList1 = new Button[8];               //본인 성격 버튼 배열
            idealList1[0] = button1;
            idealList1[1] = button2;
            idealList1[2] = button3;
            idealList1[3] = button4;
            idealList1[4] = button5;
            idealList1[5] = button6;
            idealList1[6] = button7;
            idealList1[7] = button8;

            Button[] idealList2 = new Button[8];              //본인 매력포인트 버튼 배열
            idealList2[0] = button9;
            idealList2[1] = button10;
            idealList2[2] = button11;
            idealList2[3] = button12;
            idealList2[4] = button13;
            idealList2[5] = button14;
            idealList2[6] = button15;
            idealList2[7] = button16;

            if (!IsAttractSelected(idealList1, idealList2))              //버튼이 3개씩 선택되지 않았을 경우 리턴
                return;
            // 이름, 성별, 학과, 본인어필, 이상형 전송
            string idealList = SelectedAttraction(idealList1) + SelectedAttraction(idealList2);

            string insertQuery = "";
            if(genderFlag == 0)
                insertQuery = "UPDATE user_data_m SET ideal=@idealList, userFlag='1' WHERE id=@curID;";
            else if(genderFlag == 1)
                insertQuery = "UPDATE user_data_f SET ideal=@idealList, userFlag='1' WHERE id=@curID;";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            try
            {
                command.Parameters.AddWithValue("@curID", currentUserId);
                command.Parameters.AddWithValue("@idealList", idealList);

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
                this.Visible = false; // 두번째 세팅창 받기

                ProfilePhoto ProfilePhotoform = new ProfilePhoto(currentUserId, genderFlag);
                DialogResult result = ProfilePhotoform.ShowDialog();

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
                    message += "이상형의 성격";
                if (count2 != 3)
                    message += "이상형의 매력";
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Mysql 사용
using System.IO;

namespace KW_Project
{
    public partial class MainMenuForm : Form
    {
        private string currentUserId;
        private string currentUserGender;

        public MainMenuForm(string id,string gender)
        {
            currentUserId = id;
            currentUserGender = gender;
            //btnHome.Enabled = false;

            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            string ideal_id = null;
            if (currentUserGender == "남자")
                ideal_id = "201584001";
            else if (currentUserGender == "여자")
                ideal_id = "201619035";

            //매칭 알고리즘 구현시 31~35줄 수정해서 ideal_id를 매칭된 사람으로 해주면 댈듯??
            //취소버튼 누르면 다시 다른사람 매칭해서 밑에 함수 두개 실행시켜주는식으로
            LoadIdealPhoto(ideal_id);
            LoadIdealProfile(ideal_id);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileEditForm profileeditform = new ProfileEditForm(currentUserId, currentUserGender);
            profileeditform.ShowDialog();
        }

        private void MainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // mysql에서 프로필 사진 불러오기
        private void LoadIdealPhoto(string ideal_id)
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
                command.Parameters.AddWithValue("@id", ideal_id);

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
        private void LoadIdealProfile(string ideal_id)
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
                command.Parameters.AddWithValue("@id", ideal_id);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    lblIdealProfile1.Text = reader["department"].ToString();
                    lblIdealProfile1.Text += " ";
                    lblIdealProfile1.Text += reader["age"].ToString();

                    lblIdealProfile2.Text = reader["name"].ToString();
                }

                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }

}


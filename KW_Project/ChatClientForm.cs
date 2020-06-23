using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;

namespace KW_Project
{
    public partial class ChatClientForm : Form
    {
        public NetworkStream net_stream;
        public StreamReader reader;
        public StreamWriter writer;
        const int PORT = 2002;
        private Thread read_thread;
        private string ID;
        private Point mousePoint;

        public bool is_connect = false;
        TcpClient m_Client;

        GotChat ideal_form;

        private const int CS_DROPSHADOW = 0x00020000;

        //loginForm form;
        public ChatClientForm()
        {
            InitializeComponent();
        }

        //public void setID(string id)
        //{
        //    this.id = id;
        //}


        public ChatClientForm(GotChat form, string id) //이상형리스트에서 채팅 클라이언트의 소스를 쓰기위해 정의.
        {
            InitializeComponent();
            ideal_form = form;
            ID = id;

            Connect();
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
        //public ChatClientForm(loginForm form)
        //{
        //    InitializeComponent();
        //    this.form = form;
        //}

        private void ChatClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            Disconnect();
        }

        //private void btnExit_Click(object sender, System.EventArgs e)
        //{
        //    this.Close();
        //}

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


        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                r.AppendText(msg + "\r\n");
                r.Focus();
                r.ScrollToCaret();
                txt_send.Focus();
            }));
        }

        public void Disconnect()
        {
            if (!is_connect)
                return;

            is_connect = false;

            reader.Close();
            writer.Close();

            net_stream.Close();
            read_thread.Abort();

            Message("상대방과 연결 중단");
        }

        public void Connect()
        {
            m_Client = new TcpClient();

            try
            {
                m_Client.Connect("127.0.0.1", PORT);
            }
            catch
            {
                is_connect = false;
                return;
            }
            is_connect = true;
            //MessageBox.Show("서버에 연결");


            net_stream = m_Client.GetStream();

            reader = new StreamReader(net_stream);
            writer = new StreamWriter(net_stream);

            read_thread = new Thread(new ThreadStart(Receive));
            read_thread.Start();
        }

        public void Receive()
        {
            try
            {
                while (is_connect)
                {
                    string szMessage = reader.ReadLine();

                    if (szMessage != null)
                        Message(ID + " : " + szMessage);
                }
            }
            catch
            {
                Message("데이터를 읽는 과정에서 오류가 발생");
            }
            Disconnect();
        }

        void Send()
        {
            try
            {
                writer.WriteLine(txt_send.Text);
                writer.Flush();

                Message("당신 : " + txt_send.Text);
                txt_send.Text = "";
            }
            catch
            {
                Message("데이터 전송 실패");
            }
        }

        //private void btnConnect_Click(object sender, EventArgs e)
        //{
        //    while (btnConnect.Text == "서버 연결")
        //    {
        //        if (btnConnect.Text == "서버 연결")
        //        {
        //            Connect();
        //            if (m_bConnect)
        //            {
        //                btnConnect.Text = "연결 끊기";
        //                btnConnect.ForeColor = Color.Red;
        //            }

        //        }
        //        else
        //        {
        //            Disconnect();
        //            btnConnect.Text = "서버 연결";
        //            btnConnect.ForeColor = Color.Black;
        //        }
        //    }
        //}

        private void btn_send_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void txt_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_send_Click(this, e);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Disconnect();
            this.Close();
        }
    }
}

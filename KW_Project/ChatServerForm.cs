using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
//using System.Net;

namespace KW_Project
{
    public partial class ChatServerForm : Form
    {
        public NetworkStream net_stream;
        public StreamReader reader;
        public StreamWriter writer;
        const int PORT = 2002;
        private Thread read_thread;
        private string id;
        private Point mousePoint;

        public bool is_stop = false;
        private TcpListener listener;
        private Thread server_thread;

        public bool is_connect = false;
        private const int CS_DROPSHADOW = 0x00020000;


        public ChatServerForm()
        {
            InitializeComponent();
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
        private void ChatServerForms_Load(object sender, EventArgs e)
        {
            server_thread = new Thread(new ThreadStart(ServerStart)); //채팅방 입장 동시에 서버 생성.
            server_thread.Start();

            //loginForm form = new loginForm(this);
            //MessageBox.Show(form.getId());

        }

        private void ChatServerForms_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
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
                txt_all.AppendText(msg + "\r\n");
                txt_all.Focus();
                txt_all.ScrollToCaret();
                txt_send.Focus();
            }));
        }

        public void ServerStart()
        {
            try
            {
                listener = new TcpListener(PORT);
                listener.Start();

                is_stop = true;
                Message("상대방에게 채팅을 요청했습니다!");


                while (is_stop)
                {
                    TcpClient hClient = listener.AcceptTcpClient();

                    if (hClient.Connected)
                    {
                        is_connect = true;
                        Message("상대방이 입장했습니다!");

                        net_stream = hClient.GetStream();
                        reader = new StreamReader(net_stream);
                        writer = new StreamWriter(net_stream);

                        read_thread = new Thread(new ThreadStart(Receive));
                        read_thread.Start();
                    }
                }
            }
            catch
            {
                Message("시작 도중에 오류 발생");
                return;
            }
        }

        public void ServerStop()
        {
            if (is_stop)
                return;

            listener.Stop();

            reader.Close();
            writer.Close();

            net_stream.Close();

            read_thread.Abort();
            server_thread.Abort();

            Message("서비스 종료");
        }

        public void Receive()
        {
            try
            {
                while (is_connect)
                {
                    string szMessage = reader.ReadLine();

                    if (szMessage != null)
                        Message("상대방  : " + szMessage);
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

        //private void btnServer_Click(object sender, EventArgs e) //지울듯
        //{
        //    if (btnConnect.Text == "서버 켜기")
        //    {
        //        server_thread = new Thread(new ThreadStart(ServerStart));
        //        server_thread.Start();

        //        btnConnect.Text = "서버 멈춤";
        //        btnConnect.ForeColor = Color.Red;
        //    }
        //    else
        //    {
        //        ServerStop();
        //        btnConnect.Text = "서버 켜기";
        //        btnConnect.ForeColor = Color.Black;
        //    }
        //}

        private void btnSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Send();
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            ServerStop();
            Disconnect();
            this.Close();
        }
    }
}

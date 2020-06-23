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
using System.Threading;

namespace KW_Project
{
    public partial class LoadingForm : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;

        delegate void TestDelegate_Close();
        public LoadingForm()
        {
            InitializeComponent();
            Thread thread = new Thread(loadingThread);
            thread.Start();
        }
        
        private void LoadingForm_Load(object sender, EventArgs e)
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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void formClose()
        {
            this.Close();
        }

        private void loadingThread()
        {
            Thread.Sleep(5550);
            this.DialogResult = DialogResult.Cancel;
            formClose();
          //  this.Invoke(new TestDelegate_Close(formClose));
        }
    }
}

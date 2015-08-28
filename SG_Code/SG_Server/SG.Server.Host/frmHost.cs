using SG.Server.Host.Base;
using SG.Server.Host.Set;
using SG.Server.Host.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SG.Tools.DataOperate;
using SG.Server.DataAccess;
using SG.Server.Host.ExtControl;


namespace SG.Server.Host
{
    public partial class frmHost : Form
    {
        ServiceHost[] sHost = new ServiceHost[1000];
        private int nHostCount = 0;
        public frmHost()
        {
            InitializeComponent();
            this.Load += frmHost_Load;
            this.btStart.Click += btStart_Click;
            btStop.Click += btStop_Click;
            this.FormClosing += frmHost_FormClosing;
            this.SizeChanged += frmHost_SizeChanged;
            this.notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            this.notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;

            menuItem_Show.Click += menuItem_Show_Click;
            menuItem_Hide.Click += menuItem_Hide_Click;
            menuItem_Exit.Click += menuItem_Exit_Click;
        }

        void frmHost_Load(object sender, EventArgs e)
        {
            lbSt.Text = "服务已经停止！";
            SG.Parameters.SGParameter.sAppPath = Application.StartupPath;
            DbAccount.GetDbAccount();

            this.ShowInTaskbar = false;
            //this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon ")));
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "WCF服务";
            this.notifyIcon1.ShowBalloonTip(0, "通知", "WCF服务已经最小化到托盘", notifyIcon1.BalloonTipIcon);
            this.notifyIcon1.Visible = true;
        }

        void frmHost_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.HideCtiServer();
            }
        }

        void frmHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            //this.Hide();
        }

        void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowCtiServer();
            }
        }

        void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowCtiServer();
            }
        }

        private void ShowCtiServer()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void HideCtiServer()
        {
            this.Hide();
        }

        private void CloseCtiServer()
        {
            this.notifyIcon1.Visible = false;
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        void menuItem_Show_Click(object sender, EventArgs e)
        {
            ShowCtiServer();
        }

        void menuItem_Hide_Click(object sender, EventArgs e)
        {
            HideCtiServer();
        }

        void menuItem_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出WCF终端服务程序吗？", "退出提示", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                CloseCtiServer();
            }
        }

        void btStop_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nHostCount; i++)
            {
                if (sHost[i].State == CommunicationState.Opened)
                {
                    sHost[i].Close();
                }
            }
            lbSt.Text = "服务已经停止！";
        }

        void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceHost host1 = new ServiceHost(typeof(SGBaseUser));
                if (host1.State != CommunicationState.Opening)
                {
                    host1.Open();
                    sHost[0] = host1;
                    nHostCount++;
                }
                host1 = new ServiceHost(typeof(CommonService));
                if (host1.State != CommunicationState.Opening)
                {
                    host1.Open();
                    sHost[1] = host1;
                    nHostCount++;
                }
                host1 = new ServiceHost(typeof(SGBaseDict));
                if (host1.State != CommunicationState.Opening)
                {
                    host1.Open();
                    sHost[2] = host1;
                    nHostCount++;
                }
                host1 = new ServiceHost(typeof(SGSetFunSQL));
                if (host1.State != CommunicationState.Opening)
                {
                    host1.Open();
                    sHost[3] = host1;
                    nHostCount++;
                }
                host1 = new ServiceHost(typeof(SGDatabase));
                if (host1.State != CommunicationState.Opening)
                {
                    host1.Open();
                    sHost[4] = host1;
                    nHostCount++;
                }
                host1 = new ServiceHost(typeof(ExtGridControl));
                if (host1.State != CommunicationState.Opening)
                {
                    host1.Open();
                    sHost[5] = host1;
                    nHostCount++;
                }

                lbSt.Text = "服务已经启动！";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

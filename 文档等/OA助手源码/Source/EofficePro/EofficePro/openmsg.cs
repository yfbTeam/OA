namespace EofficePro
{
    using Sunisoft.IrisSkin;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Windows.Forms;

    public class openmsg : Form
    {
        private IContainer components = null;
        public static openmsg f4 = null;
        private MenuStrip menuStrip1;
        public WebBrowser webBrowser1;
        private ToolStripMenuItem 查看全部短消息ToolStripMenuItem;
        private ToolStripMenuItem 查看未阅短消息ToolStripMenuItem;
        private ToolStripMenuItem 查看已阅短消息ToolStripMenuItem;
        private ToolStripMenuItem 发送短消息ToolStripMenuItem;
        private ToolStripMenuItem 全部短消息ToolStripMenuItem;
        private ToolStripMenuItem 删除以下全部消息ToolStripMenuItem;
        private ToolStripMenuItem 删除以下全部消息ToolStripMenuItem1;
        private ToolStripMenuItem 删除以下全部消息ToolStripMenuItem2;
        private ToolStripMenuItem 刷新新短消息ToolStripMenuItem;
        private ToolStripMenuItem 未阅短消息ToolStripMenuItem;
        private ToolStripMenuItem 已阅短消息ToolStripMenuItem;
        private ToolStripMenuItem 已阅以下短消息ToolStripMenuItem;

        public openmsg()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(openmsg));
            this.webBrowser1 = new WebBrowser();
            this.menuStrip1 = new MenuStrip();
            this.刷新新短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.未阅短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.查看未阅短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.已阅以下短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.删除以下全部消息ToolStripMenuItem1 = new ToolStripMenuItem();
            this.已阅短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.查看已阅短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.删除以下全部消息ToolStripMenuItem = new ToolStripMenuItem();
            this.全部短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.查看全部短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.删除以下全部消息ToolStripMenuItem2 = new ToolStripMenuItem();
            this.发送短消息ToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            base.SuspendLayout();
            this.webBrowser1.Dock = DockStyle.Fill;
            this.webBrowser1.Location = new Point(0, 0x18);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new Size(0x19f, 0xe8);
            this.webBrowser1.TabIndex = 0;
            this.menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.刷新新短消息ToolStripMenuItem, this.未阅短消息ToolStripMenuItem, this.已阅短消息ToolStripMenuItem, this.全部短消息ToolStripMenuItem, this.发送短消息ToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0x19f, 0x18);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.刷新新短消息ToolStripMenuItem.Name = "刷新新短消息ToolStripMenuItem";
            this.刷新新短消息ToolStripMenuItem.Size = new Size(0x4d, 20);
            this.刷新新短消息ToolStripMenuItem.Text = "刷新短消息";
            this.刷新新短消息ToolStripMenuItem.Click += new EventHandler(this.刷新新短消息ToolStripMenuItem_Click);
            this.未阅短消息ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.查看未阅短消息ToolStripMenuItem, this.已阅以下短消息ToolStripMenuItem, this.删除以下全部消息ToolStripMenuItem1 });
            this.未阅短消息ToolStripMenuItem.Name = "未阅短消息ToolStripMenuItem";
            this.未阅短消息ToolStripMenuItem.Size = new Size(0x4d, 20);
            this.未阅短消息ToolStripMenuItem.Text = "未阅短消息";
            this.查看未阅短消息ToolStripMenuItem.Name = "查看未阅短消息ToolStripMenuItem";
            this.查看未阅短消息ToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.查看未阅短消息ToolStripMenuItem.Text = "查看未阅短消息";
            this.查看未阅短消息ToolStripMenuItem.Click += new EventHandler(this.查看未阅短消息ToolStripMenuItem_Click);
            this.已阅以下短消息ToolStripMenuItem.Name = "已阅以下短消息ToolStripMenuItem";
            this.已阅以下短消息ToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.已阅以下短消息ToolStripMenuItem.Text = "已阅以下短消息";
            this.已阅以下短消息ToolStripMenuItem.Click += new EventHandler(this.已阅以下短消息ToolStripMenuItem_Click);
            this.删除以下全部消息ToolStripMenuItem1.Name = "删除以下全部消息ToolStripMenuItem1";
            this.删除以下全部消息ToolStripMenuItem1.Size = new Size(0xa6, 0x16);
            this.删除以下全部消息ToolStripMenuItem1.Text = "删除以下全部消息";
            this.删除以下全部消息ToolStripMenuItem1.Click += new EventHandler(this.删除以下全部消息ToolStripMenuItem1_Click);
            this.已阅短消息ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.查看已阅短消息ToolStripMenuItem, this.删除以下全部消息ToolStripMenuItem });
            this.已阅短消息ToolStripMenuItem.Name = "已阅短消息ToolStripMenuItem";
            this.已阅短消息ToolStripMenuItem.Size = new Size(0x4d, 20);
            this.已阅短消息ToolStripMenuItem.Text = "已阅短消息";
            this.查看已阅短消息ToolStripMenuItem.Name = "查看已阅短消息ToolStripMenuItem";
            this.查看已阅短消息ToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.查看已阅短消息ToolStripMenuItem.Text = "查看已阅短消息";
            this.查看已阅短消息ToolStripMenuItem.Click += new EventHandler(this.查看已阅短消息ToolStripMenuItem_Click);
            this.删除以下全部消息ToolStripMenuItem.Name = "删除以下全部消息ToolStripMenuItem";
            this.删除以下全部消息ToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.删除以下全部消息ToolStripMenuItem.Text = "删除以下全部消息";
            this.删除以下全部消息ToolStripMenuItem.Click += new EventHandler(this.删除以下全部消息ToolStripMenuItem_Click);
            this.全部短消息ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.查看全部短消息ToolStripMenuItem, this.删除以下全部消息ToolStripMenuItem2 });
            this.全部短消息ToolStripMenuItem.Name = "全部短消息ToolStripMenuItem";
            this.全部短消息ToolStripMenuItem.Size = new Size(0x4d, 20);
            this.全部短消息ToolStripMenuItem.Text = "全部短消息";
            this.查看全部短消息ToolStripMenuItem.Name = "查看全部短消息ToolStripMenuItem";
            this.查看全部短消息ToolStripMenuItem.Size = new Size(0xa6, 0x16);
            this.查看全部短消息ToolStripMenuItem.Text = "查看全部短消息";
            this.查看全部短消息ToolStripMenuItem.Click += new EventHandler(this.查看全部短消息ToolStripMenuItem_Click);
            this.删除以下全部消息ToolStripMenuItem2.Name = "删除以下全部消息ToolStripMenuItem2";
            this.删除以下全部消息ToolStripMenuItem2.Size = new Size(0xa6, 0x16);
            this.删除以下全部消息ToolStripMenuItem2.Text = "删除以下全部消息";
            this.删除以下全部消息ToolStripMenuItem2.Click += new EventHandler(this.删除以下全部消息ToolStripMenuItem2_Click);
            this.发送短消息ToolStripMenuItem.Name = "发送短消息ToolStripMenuItem";
            this.发送短消息ToolStripMenuItem.Size = new Size(0x4d, 20);
            this.发送短消息ToolStripMenuItem.Text = "发送短消息";
            this.发送短消息ToolStripMenuItem.Click += new EventHandler(this.发送短消息ToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x19f, 0x100);
            base.Controls.Add(this.webBrowser1);
            base.Controls.Add(this.menuStrip1);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MainMenuStrip = this.menuStrip1;
            base.Name = "openmsg";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "短消息(最新50条)";
            base.TopMost = true;
            base.Load += new EventHandler(this.openmsg_Load);
            base.FormClosed += new FormClosedEventHandler(this.openmsg_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void openmsg_FormClosed(object sender, FormClosedEventArgs e)
        {
            f4 = null;
        }

        private void openmsg_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Size.Width - 0x1a7;
            int y = Screen.PrimaryScreen.WorkingArea.Size.Height - 290;
            base.SetDesktopLocation(x, y);
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\" + MainLogin.oacss + "";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
                this.webBrowser1.Url = new Uri("" + MainLogin.oaurl + "/Client/messageurl.aspx?url=/Client/mymessagenew.aspx?pwd=" + MainLogin.oapassword + "&user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 查看全部短消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.webBrowser1.Url = new Uri("" + MainLogin.oaurl + "/Client/messageurl.aspx?url=/Client/mymessageall.aspx?pwd=" + MainLogin.oapassword + "&user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 查看未阅短消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.webBrowser1.Url = new Uri("" + MainLogin.oaurl + "/Client/messageurl.aspx?url=/Client/mymessagenew.aspx?pwd=" + MainLogin.oapassword + "&user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 查看已阅短消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.webBrowser1.Url = new Uri("" + MainLogin.oaurl + "/Client/messageurl.aspx?url=/Client/mymessageold.aspx?pwd=" + MainLogin.oapassword + "&user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 发送短消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            string str = "" + MainLogin.oaurl + "/Client/urlcheck.aspx?url=/InfoManage/messages/Messages_add.aspx&user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "";
            process.StartInfo.FileName = "iexplore.exe";
            process.StartInfo.Arguments = str;
            process.Start();
        }

        private void 全部删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string str = new WebClient().DownloadString("" + MainLogin.oaurl + "/Client/CloseMsg.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "&type=2");
                this.webBrowser1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 全部已阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string str = new WebClient().DownloadString("" + MainLogin.oaurl + "/Client/CloseMsg.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "&type=1");
                this.webBrowser1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 删除以下全部消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string str = new WebClient().DownloadString("" + MainLogin.oaurl + "/Client/CloseMsg.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "&type=3");
                this.webBrowser1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 删除以下全部消息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = new WebClient().DownloadString("" + MainLogin.oaurl + "/Client/CloseMsg.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "&type=2");
                this.webBrowser1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 删除以下全部消息ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                string str = new WebClient().DownloadString("" + MainLogin.oaurl + "/Client/CloseMsg.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "&type=4");
                this.webBrowser1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void 刷新新短消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Refresh();
        }

        private void 已阅以下短消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string str = new WebClient().DownloadString("" + MainLogin.oaurl + "/Client/CloseMsg.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "&type=1");
                this.webBrowser1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}


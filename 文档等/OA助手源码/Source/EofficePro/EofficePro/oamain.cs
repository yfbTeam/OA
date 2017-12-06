namespace EofficePro
{
    using qiupeng.sql;
    using Sunisoft.IrisSkin;
    using System;
    using System.ComponentModel;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.Net;
    using System.Windows.Forms;

    public class oamain : Form
    {
        private IContainer components = null;
        private ContextMenuStrip contextMenuStrip2;
        private Icon icon1 = new Icon("MainIcon.ico");
        private Icon icon2 = new Icon("1.ico");
        private Db List = new Db();
        private MenuStrip menuStrip1;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem oA首页ToolStripMenuItem;
        private ToolStripMenuItem oA主页ToolStripMenuItem;
        private SkinEngine skinEngine1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem vista经典ToolStripMenuItem;
        private WebBrowser webBrowser1;
        private WebBrowser webBrowser2;
        private WebBrowser webBrowser3;
        private WebBrowser webBrowser4;
        private ToolStripMenuItem windows经典ToolStripMenuItem;
        private ToolStripMenuItem 帮助HToolStripMenuItem;
        private ToolStripMenuItem 操作AToolStripMenuItem;
        private ToolStripMenuItem 春天童话ToolStripMenuItem;
        private ToolStripMenuItem 打开助手ToolStripMenuItem;
        private ToolStripMenuItem 风格切换ToolStripMenuItem;
        private ToolStripMenuItem 关于ToolStripMenuItem;
        private ToolStripMenuItem 晶蓝ToolStripMenuItem;
        private ToolStripMenuItem 浪漫情怀ToolStripMenuItem;
        private ToolStripMenuItem 绿色缘情ToolStripMenuItem;
        private ToolStripMenuItem 内部消息ToolStripMenuItem;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem 刷新ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 消息窗口ToolStripMenuItem;

        public oamain()
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
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(oamain));
            this.menuStrip1 = new MenuStrip();
            this.文件ToolStripMenuItem = new ToolStripMenuItem();
            this.oA主页ToolStripMenuItem = new ToolStripMenuItem();
            this.设置ToolStripMenuItem = new ToolStripMenuItem();
            this.退出ToolStripMenuItem = new ToolStripMenuItem();
            this.操作AToolStripMenuItem = new ToolStripMenuItem();
            this.风格切换ToolStripMenuItem = new ToolStripMenuItem();
            this.晶蓝ToolStripMenuItem = new ToolStripMenuItem();
            this.绿色缘情ToolStripMenuItem = new ToolStripMenuItem();
            this.浪漫情怀ToolStripMenuItem = new ToolStripMenuItem();
            this.春天童话ToolStripMenuItem = new ToolStripMenuItem();
            this.windows经典ToolStripMenuItem = new ToolStripMenuItem();
            this.vista经典ToolStripMenuItem = new ToolStripMenuItem();
            this.内部消息ToolStripMenuItem = new ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new ToolStripMenuItem();
            this.关于ToolStripMenuItem = new ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new ToolStripMenuItem();
            this.skinEngine1 = new SkinEngine(this);
            this.notifyIcon1 = new NotifyIcon(this.components);
            this.contextMenuStrip2 = new ContextMenuStrip(this.components);
            this.打开助手ToolStripMenuItem = new ToolStripMenuItem();
            this.oA首页ToolStripMenuItem = new ToolStripMenuItem();
            this.消息窗口ToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripMenuItem();
            this.toolStripMenuItem2 = new ToolStripMenuItem();
            this.toolStripMenuItem3 = new ToolStripMenuItem();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.webBrowser1 = new WebBrowser();
            this.tabPage2 = new TabPage();
            this.webBrowser2 = new WebBrowser();
            this.tabPage3 = new TabPage();
            this.webBrowser3 = new WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.tabPage4 = new TabPage();
            this.webBrowser4 = new WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            base.SuspendLayout();
            this.menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.文件ToolStripMenuItem, this.操作AToolStripMenuItem, this.帮助HToolStripMenuItem, this.刷新ToolStripMenuItem });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(0xf4, 0x18);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.oA主页ToolStripMenuItem, this.设置ToolStripMenuItem, this.退出ToolStripMenuItem });
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new Size(0x29, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            this.oA主页ToolStripMenuItem.Name = "oA主页ToolStripMenuItem";
            this.oA主页ToolStripMenuItem.Size = new Size(0x6a, 0x16);
            this.oA主页ToolStripMenuItem.Text = "OA主页";
            this.oA主页ToolStripMenuItem.Click += new EventHandler(this.oA主页ToolStripMenuItem_Click);
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new Size(0x6a, 0x16);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new EventHandler(this.设置ToolStripMenuItem_Click);
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new Size(0x6a, 0x16);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new EventHandler(this.退出ToolStripMenuItem_Click);
            this.操作AToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.风格切换ToolStripMenuItem, this.内部消息ToolStripMenuItem });
            this.操作AToolStripMenuItem.Name = "操作AToolStripMenuItem";
            this.操作AToolStripMenuItem.Size = new Size(0x29, 20);
            this.操作AToolStripMenuItem.Text = "操作";
            this.风格切换ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.晶蓝ToolStripMenuItem, this.绿色缘情ToolStripMenuItem, this.浪漫情怀ToolStripMenuItem, this.春天童话ToolStripMenuItem, this.windows经典ToolStripMenuItem, this.vista经典ToolStripMenuItem });
            this.风格切换ToolStripMenuItem.Name = "风格切换ToolStripMenuItem";
            this.风格切换ToolStripMenuItem.Size = new Size(0x76, 0x16);
            this.风格切换ToolStripMenuItem.Text = "风格切换";
            this.晶蓝ToolStripMenuItem.Name = "晶蓝ToolStripMenuItem";
            this.晶蓝ToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.晶蓝ToolStripMenuItem.Text = "蓝色经典";
            this.晶蓝ToolStripMenuItem.Click += new EventHandler(this.晶蓝ToolStripMenuItem_Click);
            this.绿色缘情ToolStripMenuItem.Name = "绿色缘情ToolStripMenuItem";
            this.绿色缘情ToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.绿色缘情ToolStripMenuItem.Text = "艳绿缘情";
            this.绿色缘情ToolStripMenuItem.Click += new EventHandler(this.绿色缘情ToolStripMenuItem_Click);
            this.浪漫情怀ToolStripMenuItem.Name = "浪漫情怀ToolStripMenuItem";
            this.浪漫情怀ToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.浪漫情怀ToolStripMenuItem.Text = "典雅温情";
            this.浪漫情怀ToolStripMenuItem.Click += new EventHandler(this.浪漫情怀ToolStripMenuItem_Click);
            this.春天童话ToolStripMenuItem.Name = "春天童话ToolStripMenuItem";
            this.春天童话ToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.春天童话ToolStripMenuItem.Text = "忆春思雨";
            this.春天童话ToolStripMenuItem.Click += new EventHandler(this.春天童话ToolStripMenuItem_Click);
            this.windows经典ToolStripMenuItem.Name = "windows经典ToolStripMenuItem";
            this.windows经典ToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.windows经典ToolStripMenuItem.Text = "XP经典";
            this.windows经典ToolStripMenuItem.Click += new EventHandler(this.windows经典ToolStripMenuItem_Click);
            this.vista经典ToolStripMenuItem.Name = "vista经典ToolStripMenuItem";
            this.vista经典ToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.vista经典ToolStripMenuItem.Text = "Vista经典";
            this.vista经典ToolStripMenuItem.Click += new EventHandler(this.vista经典ToolStripMenuItem_Click);
            this.内部消息ToolStripMenuItem.Name = "内部消息ToolStripMenuItem";
            this.内部消息ToolStripMenuItem.Size = new Size(0x76, 0x16);
            this.内部消息ToolStripMenuItem.Text = "内部消息";
            this.内部消息ToolStripMenuItem.Click += new EventHandler(this.内部消息ToolStripMenuItem_Click);
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.关于ToolStripMenuItem });
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.帮助HToolStripMenuItem.Size = new Size(0x29, 20);
            this.帮助HToolStripMenuItem.Text = "帮助";
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new Size(0x5e, 0x16);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new EventHandler(this.关于ToolStripMenuItem_Click);
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new Size(0x29, 20);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new EventHandler(this.刷新ToolStripMenuItem_Click);
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyIcon1.Icon = (Icon) manager.GetObject("notifyIcon1.Icon");
            this.notifyIcon1.Text = "OA助手";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.contextMenuStrip2.Items.AddRange(new ToolStripItem[] { this.打开助手ToolStripMenuItem, this.oA首页ToolStripMenuItem, this.消息窗口ToolStripMenuItem, this.toolStripMenuItem1, this.toolStripMenuItem2, this.toolStripMenuItem3 });
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new Size(0x77, 0x88);
            this.打开助手ToolStripMenuItem.Name = "打开助手ToolStripMenuItem";
            this.打开助手ToolStripMenuItem.Size = new Size(0x76, 0x16);
            this.打开助手ToolStripMenuItem.Text = "打开助手";
            this.打开助手ToolStripMenuItem.Click += new EventHandler(this.打开助手ToolStripMenuItem_Click);
            this.oA首页ToolStripMenuItem.Name = "oA首页ToolStripMenuItem";
            this.oA首页ToolStripMenuItem.Size = new Size(0x76, 0x16);
            this.oA首页ToolStripMenuItem.Text = "OA首页";
            this.oA首页ToolStripMenuItem.Click += new EventHandler(this.oA首页ToolStripMenuItem_Click);
            this.消息窗口ToolStripMenuItem.Name = "消息窗口ToolStripMenuItem";
            this.消息窗口ToolStripMenuItem.Size = new Size(0x76, 0x16);
            this.消息窗口ToolStripMenuItem.Text = "内部消息";
            this.消息窗口ToolStripMenuItem.Click += new EventHandler(this.消息窗口ToolStripMenuItem_Click);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(0x76, 0x16);
            this.toolStripMenuItem1.Text = "设置";
            this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(0x76, 0x16);
            this.toolStripMenuItem2.Text = "关于";
            this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new Size(0x76, 0x16);
            this.toolStripMenuItem3.Text = "退出";
            this.toolStripMenuItem3.Click += new EventHandler(this.toolStripMenuItem3_Click);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0x18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0xf4, 0x207);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selecting += new TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new Point(4, 0x15);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0xec, 0x1ee);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "功能导航";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.webBrowser1.Dock = DockStyle.Fill;
            this.webBrowser1.Location = new Point(3, 3);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new Size(230, 0x1e8);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new Uri("http://localhost:6620/Client/Login.aspx", UriKind.Absolute);
            this.tabPage2.Controls.Add(this.webBrowser2);
            this.tabPage2.Location = new Point(4, 0x15);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(0xec, 0x1ee);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "内部消息";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.webBrowser2.Dock = DockStyle.Fill;
            this.webBrowser2.Location = new Point(3, 3);
            this.webBrowser2.MinimumSize = new Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new Size(230, 0x1e8);
            this.webBrowser2.TabIndex = 0;
            this.webBrowser2.Url = new Uri("", UriKind.Relative);
            this.tabPage3.Controls.Add(this.webBrowser3);
            this.tabPage3.Location = new Point(4, 0x15);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new Size(0xec, 0x1ee);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "组织信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.webBrowser3.Dock = DockStyle.Fill;
            this.webBrowser3.Location = new Point(0, 0);
            this.webBrowser3.MinimumSize = new Size(20, 20);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.Size = new Size(0xec, 0x1ee);
            this.webBrowser3.TabIndex = 1;
            this.webBrowser3.Url = new Uri("", UriKind.Relative);
            this.timer1.Interval = 0x4e20;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.timer2.Enabled = true;
            this.timer2.Interval = 350;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            this.timer3.Enabled = true;
            this.timer3.Interval = 0x7d0;
            this.timer3.Tick += new EventHandler(this.timer3_Tick);
            this.tabPage4.Controls.Add(this.webBrowser4);
            this.tabPage4.Location = new Point(4, 0x15);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new Size(0xec, 0x1ee);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "讨论组";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.webBrowser4.Dock = DockStyle.Fill;
            this.webBrowser4.Location = new Point(0, 0);
            this.webBrowser4.MinimumSize = new Size(20, 20);
            this.webBrowser4.Name = "webBrowser4";
            this.webBrowser4.Size = new Size(0xec, 0x1ee);
            this.webBrowser4.TabIndex = 2;
            this.webBrowser4.Url = new Uri("", UriKind.Relative);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0xf4, 0x21f);
            base.Controls.Add(this.tabControl1);
            base.Controls.Add(this.menuStrip1);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MainMenuStrip = this.menuStrip1;
            base.Name = "oamain";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "办公助手";
            base.TopMost = true;
            base.Load += new EventHandler(this.oamain_Load);
            base.SizeChanged += new EventHandler(this.oamain_SizeChanged);
            base.FormClosed += new FormClosedEventHandler(this.oamain_FormClosed);
            base.FormClosing += new FormClosingEventHandler(this.oamain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            base.Visible = true;
            base.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.notifyIcon1.Text == "您有新短信息,双击查看")
            {
                if ((openmsg.f4 == null) || openmsg.f4.IsDisposed)
                {
                    openmsg.f4 = new openmsg();
                    openmsg.f4.Show();
                }
                else
                {
                    openmsg.f4.Activate();
                    openmsg.f4.webBrowser1.Refresh();
                    base.Visible = true;
                    base.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                base.Visible = true;
                base.WindowState = FormWindowState.Normal;
            }
        }

        private void oamain_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void oamain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确定要退出OA助手吗？", "OA助手提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void oamain_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new Uri("" + MainLogin.oaurl + "/Client/Login.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "");
            this.webBrowser2.Url = new Uri("" + MainLogin.oaurl + "/Client/mymessage.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "");
            this.webBrowser3.Url = new Uri("" + MainLogin.oaurl + "/Client/useronline.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "");
            this.webBrowser4.Url = new Uri("" + MainLogin.oaurl + "/Client/Taolunzu.aspx?user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "");
            string str = null;
            string sql = "select * from [qiupeng]";
            OleDbDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["cssoa"].ToString();
            }
            list.Close();
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\" + str + "";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            string str3 = new WebClient().DownloadString("" + MainLogin.oaurl + "/Client/GetUser.aspx?user=" + MainLogin.oauserId + "");
            this.Text = "OA助手—" + str3 + "";
        }

        private void oamain_SizeChanged(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.Hide();
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(10, "友情提示", "您可以双击拖盘的小图标打开OA助手~", ToolTipIcon.Info);
            }
        }

        private void oA首页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            string str = "" + MainLogin.oaurl + "/Client/urlcheck.aspx?url=/main.aspx&user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "";
            process.StartInfo.FileName = "iexplore.exe";
            process.StartInfo.Arguments = str;
            process.Start();
        }

        private void oA主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            string str = "" + MainLogin.oaurl + "/Client/urlcheck.aspx?url=/main.aspx&user=" + MainLogin.oauserId + "&pwd=" + MainLogin.oapassword + "";
            process.StartInfo.FileName = "iexplore.exe";
            process.StartInfo.Arguments = str;
            process.Start();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (this.tabControl1.SelectedTab.Text.ToString() == "快捷菜单")
            {
                this.webBrowser1.Refresh();
            }
            if (this.tabControl1.SelectedTab.Text.ToString() == "内部消息")
            {
                this.webBrowser2.Refresh();
            }
            if (this.tabControl1.SelectedTab.Text.ToString() == "组织信息")
            {
                this.webBrowser3.Refresh();
            }
            if (this.tabControl1.SelectedTab.Text.ToString() == "讨论组")
            {
                this.webBrowser4.Refresh();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.notifyIcon1.Text != "OA助手")
            {
                if (this.notifyIcon1.Icon == this.icon1)
                {
                    this.notifyIcon1.Icon = this.icon2;
                }
                else
                {
                    this.notifyIcon1.Icon = this.icon1;
                }
            }
            else
            {
                this.notifyIcon1.Icon = this.icon1;
                this.notifyIcon1.Text = "OA助手";
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            if (client.DownloadString("" + MainLogin.oaurl + "/Client/CountMsg.aspx?username=" + MainLogin.oauserId + "") != "0")
            {
                this.notifyIcon1.Text = "您有新短信息,双击查看";
                if (this.notifyIcon1.Icon == this.icon1)
                {
                    this.notifyIcon1.Icon = this.icon2;
                }
                else
                {
                    this.notifyIcon1.Icon = this.icon1;
                }
                if ((openmsg.f4 == null) || openmsg.f4.IsDisposed)
                {
                    openmsg.f4 = new openmsg();
                    openmsg.f4.Show();
                }
            }
            else
            {
                this.notifyIcon1.Icon = this.icon1;
                this.notifyIcon1.Text = "OA助手";
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new oamainsz().Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new guanyu().Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出OA助手吗？", "OA助手提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                base.Dispose();
                base.Close();
            }
        }

        private void vista经典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\vista1_green.ssk";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            MainLogin.oacss = "vista1_green.ssk";
            string sql = "Update [qiupeng] Set [cssoa]='vista1_green.ssk'";
            this.List.ExeSql(sql);
        }

        private void windows经典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\MacOS.ssk";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            MainLogin.oacss = "MacOS.ssk";
            string sql = "Update [qiupeng] Set [cssoa]='MacOS.ssk'";
            this.List.ExeSql(sql);
        }

        private void 春天童话ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\DeepCyan.ssk";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            MainLogin.oacss = "DeepCyan.ssk";
            string sql = "Update [qiupeng] Set [cssoa]='DeepCyan.ssk'";
            this.List.ExeSql(sql);
        }

        private void 打开助手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Visible = true;
            base.WindowState = FormWindowState.Normal;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new guanyu().Show();
        }

        private void 晶蓝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\DiamondBlue.ssk";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            MainLogin.oacss = "DiamondBlue.ssk";
            string sql = "Update [qiupeng] Set [cssoa]='DiamondBlue.ssk'";
            this.List.ExeSql(sql);
        }

        private void 浪漫情怀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\GlassOrange.ssk";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            MainLogin.oacss = "GlassOrange.ssk";
            string sql = "Update [qiupeng] Set [cssoa]='GlassOrange.ssk'";
            this.List.ExeSql(sql);
        }

        private void 绿色缘情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\DiamondGreen.ssk";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            MainLogin.oacss = "DiamondGreen.ssk";
            string sql = "Update [qiupeng] Set [cssoa]='DiamondGreen.ssk'";
            this.List.ExeSql(sql);
        }

        private void 内部消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((openmsg.f4 == null) || openmsg.f4.IsDisposed)
            {
                openmsg.f4 = new openmsg();
                openmsg.f4.Show();
            }
            else
            {
                openmsg.f4.Activate();
                openmsg.f4.webBrowser1.Refresh();
                base.Visible = true;
                base.WindowState = FormWindowState.Normal;
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new oamainsz().Show();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Text.ToString() == "功能导航")
            {
                this.webBrowser1.Refresh();
            }
            if (this.tabControl1.SelectedTab.Text.ToString() == "内部消息")
            {
                this.webBrowser2.Refresh();
            }
            if (this.tabControl1.SelectedTab.Text.ToString() == "组织信息")
            {
                this.webBrowser3.Refresh();
            }
            if (this.tabControl1.SelectedTab.Text.ToString() == "讨论组")
            {
                this.webBrowser4.Refresh();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出OA助手吗？", "OA助手提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                base.Dispose();
                base.Close();
            }
        }

        private void 消息窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((openmsg.f4 == null) || openmsg.f4.IsDisposed)
            {
                openmsg.f4 = new openmsg();
                openmsg.f4.Show();
            }
            else
            {
                openmsg.f4.Activate();
                openmsg.f4.webBrowser1.Refresh();
                base.Visible = true;
                base.WindowState = FormWindowState.Normal;
            }
        }
    }
}


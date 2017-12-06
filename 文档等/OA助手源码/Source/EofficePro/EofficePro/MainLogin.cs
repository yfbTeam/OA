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
    using System.Text;
    using System.Windows.Forms;

    public class MainLogin : Form
    {
        private CheckBox autoLogin;
        private Button button1;
        private Button button2;
        private Button button3;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Db List = new Db();
        public static string oaautoLogin = null;
        public static string oaautoStart = null;
        public static string oacss = null;
        public static string oapassword = null;
        public static string oaurl = null;
        public static string oauserId = null;
        public TextBox password;
        private TextBox passwordpage;
        private SkinEngine skinEngine1;
        public TextBox url;
        public TextBox username;

        public MainLogin()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.Default;
                if (client.DownloadString("" + this.url.Text + "/Client/checkuser.aspx?user=" + this.List.GetFormatStr(this.username.Text) + "&pwd=" + this.List.GetFormatStr(this.password.Text) + "") == "1")
                {
                    oauserId = this.username.Text;
                    oapassword = this.password.Text;
                    oaurl = this.url.Text;
                    string str2 = null;
                    if (this.autoLogin.Checked)
                    {
                        str2 = "是";
                    }
                    else
                    {
                        str2 = "否";
                    }
                    string sql = "Update [qiupeng] Set [usernameoa]='" + this.List.GetFormatStr(this.username.Text) + "',[passwordoa]='" + this.List.GetFormatStr(this.password.Text) + "',[urloa]='" + this.List.GetFormatStr(this.url.Text) + "',[autoLoginoa]='" + str2 + "'";
                    this.List.ExeSql(sql);
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("登陆失败!(1)请检查用户名,密码是否正确(2)确认帐号未被禁用(3)软件版本问题");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new shezhi().Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = new Process();
                string oaurl = MainLogin.oaurl;
                process.StartInfo.FileName = "iexplore.exe";
                process.StartInfo.Arguments = oaurl;
                process.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(MainLogin));
            this.label1 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.label2 = new Label();
            this.username = new TextBox();
            this.password = new TextBox();
            this.skinEngine1 = new SkinEngine(this);
            this.autoLogin = new CheckBox();
            this.url = new TextBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.passwordpage = new TextBox();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x43, 100);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            this.button1.Location = new Point(0xbd, 0xfc);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 1;
            this.button1.Text = "登陆";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Location = new Point(0x149, 0xfc);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 2;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button3.Location = new Point(0x39, 0xfc);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 3;
            this.button3.Text = "OA首页";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x43, 0x8e);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密  码：";
            this.username.Location = new Point(0x8a, 0x5f);
            this.username.Name = "username";
            this.username.Size = new Size(0x9b, 0x15);
            this.username.TabIndex = 5;
            this.password.Location = new Point(0x8a, 0x89);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new Size(0x9b, 0x15);
            this.password.TabIndex = 6;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            this.autoLogin.AutoSize = true;
            this.autoLogin.Location = new Point(0x135, 140);
            this.autoLogin.Name = "autoLogin";
            this.autoLogin.Size = new Size(0x48, 0x10);
            this.autoLogin.TabIndex = 8;
            this.autoLogin.Text = "自动登陆";
            this.autoLogin.UseVisualStyleBackColor = true;
            this.url.Location = new Point(0x8a, 0xb2);
            this.url.Name = "url";
            this.url.Size = new Size(0xf3, 0x15);
            this.url.TabIndex = 10;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x43, 0xb8);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "OA服务器：";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x88, 0xd3);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0xa1, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "(如：http://192.168.1.101)";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("微软雅黑", 21.75f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label5.ForeColor = SystemColors.ActiveCaptionText;
            this.label5.Location = new Point(160, 0x1c);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x85, 0x27);
            this.label5.TabIndex = 12;
            this.label5.Text = "办公助手";
            this.passwordpage.Location = new Point(0xa7, 4);
            this.passwordpage.Name = "passwordpage";
            this.passwordpage.Size = new Size(100, 0x15);
            this.passwordpage.TabIndex = 13;
            this.passwordpage.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1b4, 0x12b);
            base.Controls.Add(this.passwordpage);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.url);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.autoLogin);
            base.Controls.Add(this.password);
            base.Controls.Add(this.username);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "MainLogin";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "办公助手";
            base.TopMost = true;
            base.Load += new EventHandler(this.MainLogin_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void MainLogin_Load(object sender, EventArgs e)
        {
            Exception exception;
            string sql = "select * from [qiupeng]";
            OleDbDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                oacss = list["cssoa"].ToString();
                oaurl = list["urloa"].ToString();
                oaautoLogin = list["autoLoginoa"].ToString();
                oaautoStart = list["autoStartoa"].ToString();
                this.passwordpage.Text = list["passwordoa"].ToString();
                this.username.Text = list["usernameoa"].ToString();
                this.url.Text = list["urloa"].ToString();
                if (list["autoLoginoa"].ToString() == "是")
                {
                    this.password.Text = list["passwordoa"].ToString();
                    this.autoLogin.Checked = true;
                }
                else
                {
                    this.autoLogin.Checked = false;
                }
            }
            list.Close();
            SkinEngine engine = new SkinEngine();
            engine.SkinFile = Application.StartupPath + @"\css\" + oacss + "";
            try
            {
                Control topLevelControl = base.TopLevelControl;
                if ((topLevelControl != null) && (topLevelControl is Form))
                {
                    engine.RemoveForm(topLevelControl as Form, true);
                    engine.AddForm(topLevelControl as Form);
                }
            }
            catch (Exception exception1)
            {
                exception = exception1;
                MessageBox.Show(exception.Message);
            }
            if (oaautoLogin == "是")
            {
                this.autoLogin.Checked = true;
                try
                {
                    WebClient client = new WebClient();
                    if (client.DownloadString("" + this.url.Text + "/Client/checkuser.aspx?user=" + this.List.GetFormatStr(this.username.Text) + "&pwd=" + this.List.GetFormatStr(this.password.Text) + "") == "1")
                    {
                        oauserId = this.username.Text;
                        oapassword = this.passwordpage.Text;
                        oaurl = this.url.Text;
                        string str3 = "Update [qiupeng] Set [usernameoa]='" + this.List.GetFormatStr(this.username.Text) + "',[passwordoa]='" + this.List.GetFormatStr(this.password.Text) + "',[urloa]='" + this.List.GetFormatStr(this.url.Text) + "'";
                        this.List.ExeSql(str3);
                        base.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("登陆失败!(1)请检查用户名,密码是否正确(2)确认帐号未被禁用");
                    }
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}


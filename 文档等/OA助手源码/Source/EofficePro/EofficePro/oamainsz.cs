namespace EofficePro
{
    using Microsoft.Win32;
    using qiupeng.sql;
    using Sunisoft.IrisSkin;
    using System;
    using System.ComponentModel;
    using System.Data.OleDb;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public class oamainsz : Form
    {
        private CheckBox autoLogin;
        private CheckBox autoStart;
        private Button button1;
        private Button button2;
        private Button button3;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Db List = new Db();
        private TextBox password;
        private TextBox url;
        private TextBox username;

        public oamainsz()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            string str2;
            if (this.autoLogin.Checked)
            {
                str = "是";
            }
            else
            {
                str = "否";
            }
            if (this.autoStart.Checked)
            {
                str2 = "是";
                this.SetAutoRun(Application.ExecutablePath, true);
            }
            else
            {
                str2 = "否";
                this.SetAutoRun(Application.ExecutablePath, false);
            }
            string sql = "Update [qiupeng] Set [usernameoa]='" + this.List.GetFormatStr(this.username.Text) + "',[passwordoa]='" + this.List.GetFormatStr(this.password.Text) + "',[urloa]='" + this.List.GetFormatStr(this.url.Text) + "',[autoLoginoa]='" + str + "',[autoStartoa]='" + str2 + "'";
            this.List.ExeSql(sql);
            MainLogin.oaurl = this.List.GetFormatStr(this.url.Text);
            MainLogin.oaautoLogin = str;
            MainLogin.oaautoStart = str2;
            base.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string str = new WebClient().DownloadString("" + this.url.Text + "/Client/CloseMsg.aspx");
                MessageBox.Show("测试通过！");
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(oamainsz));
            this.button2 = new Button();
            this.button1 = new Button();
            this.groupBox3 = new GroupBox();
            this.button3 = new Button();
            this.url = new TextBox();
            this.label3 = new Label();
            this.label1 = new Label();
            this.groupBox2 = new GroupBox();
            this.autoStart = new CheckBox();
            this.groupBox1 = new GroupBox();
            this.label4 = new Label();
            this.autoLogin = new CheckBox();
            this.username = new TextBox();
            this.password = new TextBox();
            this.label2 = new Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.button2.Location = new Point(0xf3, 0x138);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x17;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button1.Location = new Point(0x6c, 0x138);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0x16;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.url);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new Point(0x1f, 0x73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x182, 0x4c);
            this.groupBox3.TabIndex = 0x15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "服务器设置";
            this.button3.Location = new Point(0x125, 0x16);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x3a, 0x17);
            this.button3.TabIndex = 7;
            this.button3.Text = "测试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.url.Location = new Point(0x4d, 0x16);
            this.url.Name = "url";
            this.url.Size = new Size(210, 0x15);
            this.url.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 0x1b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "OA服务器：";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(90, 0x33);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xa1, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "(如：http://192.168.1.101)";
            this.groupBox2.Controls.Add(this.autoStart);
            this.groupBox2.Location = new Point(0x1f, 0xcd);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x182, 0x4b);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "启动选项";
            this.autoStart.AutoSize = true;
            this.autoStart.Location = new Point(9, 0x26);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new Size(0xa8, 0x10);
            this.autoStart.TabIndex = 3;
            this.autoStart.Text = "启动电脑时自动启动OA助手";
            this.autoStart.UseVisualStyleBackColor = true;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.autoLogin);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new Point(0x1f, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x182, 0x57);
            this.groupBox1.TabIndex = 0x13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登陆设置";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1c, 0x13);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "用户名：";
            this.autoLogin.AutoSize = true;
            this.autoLogin.Location = new Point(0x117, 0x36);
            this.autoLogin.Name = "autoLogin";
            this.autoLogin.Size = new Size(0x48, 0x10);
            this.autoLogin.TabIndex = 13;
            this.autoLogin.Text = "自动登陆";
            this.autoLogin.UseVisualStyleBackColor = true;
            this.username.Location = new Point(0x5c, 0x10);
            this.username.Name = "username";
            this.username.Size = new Size(0x9b, 0x15);
            this.username.TabIndex = 11;
            this.password.Location = new Point(0x5c, 0x33);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new Size(0x9b, 0x15);
            this.password.TabIndex = 12;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x1c, 0x36);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "密  码：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1c0, 0x159);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "oamainsz";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "助手设置";
            base.TopMost = true;
            base.Load += new EventHandler(this.oamainsz_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void oamainsz_Load(object sender, EventArgs e)
        {
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
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            string sql = "select * from [qiupeng]";
            OleDbDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
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
                if (list["autoStartoa"].ToString() == "是")
                {
                    this.autoStart.Checked = true;
                }
                else
                {
                    this.autoStart.Checked = false;
                }
            }
            list.Close();
        }

        public void SetAutoRun(string fileName, bool isAutoRun)
        {
            RegistryKey key = null;
            try
            {
                if (!System.IO.File.Exists(fileName))
                {
                    throw new Exception("该文件不存在!");
                }
                string name = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (key == null)
                {
                    key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                }
                if (isAutoRun)
                {
                    key.SetValue(name, fileName);
                }
                else
                {
                    key.SetValue(name, false);
                }
            }
            catch
            {
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
        }
    }
}


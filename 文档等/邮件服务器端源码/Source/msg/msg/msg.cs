namespace msg
{
    using qiupeng.sql;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Windows.Forms;

    public class msg : Form
    {
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private IContainer components = null;
        private TextBox dizhi;
        private TextBox email;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private Label label1;
        private Label label10;
        private Label label13;
        private Label label14;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Db List = new Db();
        private TextBox mima;
        private TextBox mingcheng;
        private NotifyIcon notifyIcon1;
        private Panel panel1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox smtp;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private ToolTip toolTip1;
        private TextBox yonghuming;
        private TextBox yxmima;
        private TextBox zhanghao;

        public msg()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Update [sqlurl] Set [dizhi]='" + this.List.GetFormatStr(this.dizhi.Text) + "',[mingcheng]='" + this.List.GetFormatStr(this.yonghuming.Text) + "',[yonghuming]='" + this.List.GetFormatStr(this.mima.Text) + "',[mima]='" + this.List.GetFormatStr(this.mingcheng.Text) + "'";
            this.List.ExeSql(sql);
            MessageBox.Show("保存成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str;
            StreamReader reader = new StreamReader("log.txt", Encoding.GetEncoding("GB2312"));
            while ((str = reader.ReadLine()) != null)
            {
                this.textBox1.Text = this.textBox1.Text + "" + str.ToString() + "\r\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select top 1 id from [qp_oa_username]";
                SqlDataReader list = this.GetList(sql);
                if (list.Read())
                {
                    MessageBox.Show("数据库连接成功");
                }
                else
                {
                    MessageBox.Show("数据库连接失败");
                }
                list.Close();
            }
            catch
            {
                MessageBox.Show("数据库连接失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select top 1 id from [qp_oa_username]";
                SqlDataReader list = this.GetList(sql);
                if (list.Read())
                {
                    if (this.button5.Text == "停止")
                    {
                        this.button5.Text = "启动";
                        this.label14.Text = "停止";
                    }
                    else
                    {
                        this.send();
                        this.button5.Text = "停止";
                        this.label14.Text = "启动";
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接失败");
                }
                list.Close();
            }
            catch
            {
                MessageBox.Show("数据库连接失败");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "Update [email] Set [smtp]='" + this.List.GetFormatStr(this.smtp.Text) + "',[email]='" + this.List.GetFormatStr(this.email.Text) + "',[zhanghao]='" + this.List.GetFormatStr(this.zhanghao.Text) + "',[yxmima]='" + this.List.GetFormatStr(this.yxmima.Text) + "'";
            this.List.ExeSql(sql);
            if (this.radioButton1.Checked)
            {
                string str2 = "Update [zhuangtai] Set [zhuangtai]='1'";
                this.List.ExeSql(str2);
            }
            if (this.radioButton2.Checked)
            {
                string str3 = "Update [zhuangtai] Set [zhuangtai]='2'";
                this.List.ExeSql(str3);
            }
            MessageBox.Show("保存成功");
        }

        public string DbPath()
        {
            return ("server=" + this.dizhi.Text + ";database=" + this.mingcheng.Text + ";uid=" + this.yonghuming.Text + ";password=" + this.mima.Text + ";");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public int ExeSql(string Sql)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand(Sql, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return 1;
            }
            catch
            {
                command.Dispose();
                connection.Close();
                return 0;
            }
        }

        public string GetFormatStr(string AStr)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("<", "〈");
            AStr = AStr.Replace(">", "〉");
            AStr = AStr.Replace("'", "’");
            AStr = AStr.Trim();
            return AStr;
        }

        public SqlDataReader GetList(string Sql)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand(Sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            command.Dispose();
            return reader;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(msg));
            this.notifyIcon1 = new NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new GroupBox();
            this.button4 = new Button();
            this.label4 = new Label();
            this.mima = new TextBox();
            this.label3 = new Label();
            this.yonghuming = new TextBox();
            this.label2 = new Label();
            this.mingcheng = new TextBox();
            this.label1 = new Label();
            this.dizhi = new TextBox();
            this.button1 = new Button();
            this.groupBox4 = new GroupBox();
            this.label14 = new Label();
            this.button5 = new Button();
            this.label13 = new Label();
            this.textBox1 = new TextBox();
            this.button3 = new Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new GroupBox();
            this.label5 = new Label();
            this.tabControl1 = new TabControl();
            this.tabPage1 = new TabPage();
            this.tabPage2 = new TabPage();
            this.button6 = new Button();
            this.panel1 = new Panel();
            this.yxmima = new TextBox();
            this.email = new TextBox();
            this.zhanghao = new TextBox();
            this.smtp = new TextBox();
            this.label10 = new Label();
            this.label9 = new Label();
            this.label8 = new Label();
            this.label7 = new Label();
            this.radioButton2 = new RadioButton();
            this.radioButton1 = new RadioButton();
            this.label6 = new Label();
            this.toolTip1 = new ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.notifyIcon1.Icon = (Icon) manager.GetObject("notifyIcon1.Icon");
            this.notifyIcon1.Text = "短信平台";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.timer1.Enabled = true;
            this.timer1.Interval = 0x2710;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mima);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.yonghuming);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mingcheng);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dizhi);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new Point(1, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x24a, 0x6c);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OA数据库连接";
            this.button4.Location = new Point(0x19e, 0x4f);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x4b, 0x17);
            this.button4.TabIndex = 9;
            this.button4.Text = "测试";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0xfc, 0x30);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "密码：";
            this.mima.Location = new Point(0x12b, 0x2d);
            this.mima.Name = "mima";
            this.mima.Size = new Size(0x80, 0x15);
            this.mima.TabIndex = 7;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x1f, 0x33);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户名：";
            this.yonghuming.Location = new Point(90, 0x30);
            this.yonghuming.Name = "yonghuming";
            this.yonghuming.Size = new Size(0x80, 0x15);
            this.yonghuming.TabIndex = 5;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 0x54);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x4d, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "数据库名称：";
            this.mingcheng.Location = new Point(90, 0x51);
            this.mingcheng.Name = "mingcheng";
            this.mingcheng.Size = new Size(0x80, 0x15);
            this.mingcheng.TabIndex = 3;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x13, 0x15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "连接地址：";
            this.dizhi.Location = new Point(90, 0x12);
            this.dizhi.Name = "dizhi";
            this.dizhi.Size = new Size(0x80, 0x15);
            this.dizhi.TabIndex = 1;
            this.button1.Location = new Point(0x1ef, 0x4f);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new Point(7, 0x97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(600, 0x34);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "启动状态";
            this.label14.AutoSize = true;
            this.label14.ForeColor = Color.Red;
            this.label14.Location = new Point(0x44, 0x19);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x1d, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "停止";
            this.button5.Location = new Point(0x1f0, 20);
            this.button5.Name = "button5";
            this.button5.Size = new Size(0x4b, 0x17);
            this.button5.TabIndex = 1;
            this.button5.Text = "启动";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(this.button5_Click);
            this.label13.AutoSize = true;
            this.label13.Location = new Point(8, 0x19);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x41, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "启动状态：";
            this.textBox1.Location = new Point(4, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = ScrollBars.Vertical;
            this.textBox1.Size = new Size(590, 0x8e);
            this.textBox1.TabIndex = 8;
            this.button3.Location = new Point(0x1f0, 0xa6);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 2;
            this.button3.Text = "刷新";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.timer2.Enabled = true;
            this.timer2.Interval = 0x3e8;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new Point(7, 0xd1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(600, 0xc5);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送日志";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(8, 0xb1);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x35, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "当前时间";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new Point(11, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(0x254, 0x8e);
            this.tabControl1.TabIndex = 11;
            this.tabPage1.BackColor = Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new Point(4, 0x15);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0x24c, 0x75);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "OA数据库连接";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage2.BackColor = Color.Transparent;
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.radioButton2);
            this.tabPage2.Controls.Add(this.radioButton1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new Point(4, 0x15);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(0x24c, 0x75);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "邮箱基础配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.button6.Location = new Point(0x1e8, 0x5e);
            this.button6.Name = "button6";
            this.button6.Size = new Size(0x4b, 0x17);
            this.button6.TabIndex = 11;
            this.button6.Text = "保存";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new EventHandler(this.button6_Click);
            this.panel1.Controls.Add(this.yxmima);
            this.panel1.Controls.Add(this.email);
            this.panel1.Controls.Add(this.zhanghao);
            this.panel1.Controls.Add(this.smtp);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x239, 0x40);
            this.panel1.TabIndex = 6;
            this.yxmima.Location = new Point(0x177, 0x27);
            this.yxmima.Name = "yxmima";
            this.yxmima.Size = new Size(0x80, 0x15);
            this.yxmima.TabIndex = 10;
            this.toolTip1.SetToolTip(this.yxmima, "邮箱对应的登录密码");
            this.email.Location = new Point(0x177, 9);
            this.email.Name = "email";
            this.email.Size = new Size(0x80, 0x15);
            this.email.TabIndex = 9;
            this.toolTip1.SetToolTip(this.email, "邮箱名称，如：558888@qq.com");
            this.zhanghao.Location = new Point(0x56, 0x27);
            this.zhanghao.Name = "zhanghao";
            this.zhanghao.Size = new Size(0x80, 0x15);
            this.zhanghao.TabIndex = 8;
            this.toolTip1.SetToolTip(this.zhanghao, "邮箱用户名，如555888@qq.com的用户是：555888");
            this.smtp.Location = new Point(0x56, 9);
            this.smtp.Name = "smtp";
            this.smtp.Size = new Size(0x80, 0x15);
            this.smtp.TabIndex = 7;
            this.toolTip1.SetToolTip(this.smtp, "邮箱对应的SMTP服务，如：smtp.qq.com");
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x135, 12);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x41, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "邮箱名称：";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(3, 0x30);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x4d, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "邮箱用户名：";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x135, 0x30);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "邮箱密码：";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(15, 12);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x41, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "邮箱SMTP：";
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new Point(190, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(0x5f, 0x10);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "固定邮箱发送";
            this.toolTip1.SetToolTip(this.radioButton2, "邮件服务将通过固定邮箱发送");
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new EventHandler(this.radioButton2_Click);
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new Point(0x59, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x5f, 0x10);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "用户邮箱发送";
            this.toolTip1.SetToolTip(this.radioButton1, "邮件服务将通过提交人的邮箱发送");
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new EventHandler(this.radioButton1_Click);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x41, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "发送邮箱：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x267, 0x1ab);
            base.Controls.Add(this.tabControl1);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox4);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "msg";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "OA邮件发送组件";
            base.Load += new EventHandler(this.sms_Load);
            base.SizeChanged += new EventHandler(this.sms_SizeChanged);
            base.FormClosed += new FormClosedEventHandler(this.sms_FormClosed);
            base.FormClosing += new FormClosingEventHandler(this.sms_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        public void InsertMail(string id, string sendemail, string toemail, string Zhuti, string Neirong, string smtp, string user, string password)
        {
            string str;
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = smtp;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(user, password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage message = new MailMessage(sendemail, toemail);
                message.Subject = "" + Zhuti + "";
                message.Body = "" + Neirong + "";
                message.IsBodyHtml = true;
                client.Send(message);
                str = "Update [qp_crm_CustomerLx] Set [edit_flag]='1' where id='" + id + "'";
                this.ExeSql(str);
                this.textBox1.Text = "" + DateTime.Now.ToString() + "，【" + Zhuti + "】，成功。\r\n" + this.textBox1.Text + "";
            }
            catch
            {
                str = "Update [qp_crm_CustomerLx] Set [edit_flag]='2' where id='" + id + "'";
                this.ExeSql(str);
                this.textBox1.Text = "" + DateTime.Now.ToString() + "，【" + Zhuti + "】，失败。\r\n" + this.textBox1.Text + "";
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.Visible = true;
            base.WindowState = FormWindowState.Normal;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            this.setemailVis();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            this.setemailVis();
        }

        public void send()
        {
            string str;
            SqlDataReader list;
            if (this.radioButton2.Checked)
            {
                str = "select top 10 * from qp_crm_CustomerLx where edit_flag='0' and datediff(ss,Settimes,getdate())>5";
                list = this.GetList(str);
                while (list.Read())
                {
                    this.InsertMail(list["id"].ToString(), this.email.Text, list["toemail"].ToString(), list["Title"].ToString(), list["Content"].ToString(), this.smtp.Text, this.zhanghao.Text, this.yxmima.Text);
                }
                list.Close();
            }
            if (this.radioButton1.Checked)
            {
                str = "select top 10 * from qp_crm_CustomerLx where edit_flag='0' and datediff(ss,Settimes,getdate())>5";
                list = this.GetList(str);
                while (list.Read())
                {
                    this.InsertMail(list["id"].ToString(), list["email"].ToString(), list["toemail"].ToString(), list["Title"].ToString(), list["Content"].ToString(), list["smtp"].ToString(), list["zhanghao"].ToString(), list["yxmima"].ToString());
                }
                list.Close();
            }
        }

        public void setemailVis()
        {
            if (this.radioButton1.Checked)
            {
                this.radioButton2.Checked = false;
                this.panel1.Visible = false;
            }
            if (this.radioButton2.Checked)
            {
                this.radioButton1.Checked = false;
                this.panel1.Visible = true;
            }
        }

        private void sms_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void sms_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确定要退出OA邮件发送组件吗？", "OA邮件发送组件", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void sms_Load(object sender, EventArgs e)
        {
            string sql = "select * from [sqlurl]";
            OleDbDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.dizhi.Text = list["dizhi"].ToString();
                this.yonghuming.Text = list["mingcheng"].ToString();
                this.mima.Text = list["yonghuming"].ToString();
                this.mingcheng.Text = list["mima"].ToString();
            }
            list.Close();
            string str2 = "select * from [email]";
            OleDbDataReader reader2 = this.List.GetList(str2);
            if (reader2.Read())
            {
                this.smtp.Text = reader2["smtp"].ToString();
                this.email.Text = reader2["email"].ToString();
                this.zhanghao.Text = reader2["zhanghao"].ToString();
                this.yxmima.Text = reader2["yxmima"].ToString();
            }
            reader2.Close();
            string str3 = "select * from [zhuangtai]";
            OleDbDataReader reader3 = this.List.GetList(str3);
            if (reader3.Read())
            {
                if (reader3["zhuangtai"].ToString() == "1")
                {
                    this.radioButton1.Checked = true;
                }
                if (reader3["zhuangtai"].ToString() == "2")
                {
                    this.radioButton2.Checked = true;
                }
            }
            reader3.Close();
            this.setemailVis();
        }

        private void sms_SizeChanged(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.Hide();
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(10, "友情提示", "您可以双击拖盘的小图标打开OA邮件发送组件", ToolTipIcon.Info);
            }
        }

        public void swtxt()
        {
            string text = this.textBox1.Text;
            FileStream stream = new FileStream("log.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            writer.Close();
            stream.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.label14.Text == "启动")
            {
                this.send();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.label5.Text = "当前时间：" + DateTime.Now.ToString() + " ";
        }

        public string ConnectionString
        {
            get
            {
                return this.DbPath();
            }
        }
    }
}


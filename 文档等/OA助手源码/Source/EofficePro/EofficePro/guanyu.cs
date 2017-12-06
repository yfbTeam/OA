namespace EofficePro
{
    using qiupeng.sql;
    using Sunisoft.IrisSkin;
    using System;
    using System.ComponentModel;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class guanyu : Form
    {
        private Button button1;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Db List = new Db();
        public string ziduan5;

        public guanyu()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void guanyu_Load(object sender, EventArgs e)
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
            string sql = "select * from [qiupengoa]";
            OleDbDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.label1.Text = "" + list["ziduan1"].ToString() + "";
                if (list["ziduan2"].ToString() == "#")
                {
                    this.label2.Text = "";
                }
                else
                {
                    this.label2.Text = "软件供应商：" + list["ziduan2"].ToString() + "";
                }
                if (list["ziduan3"].ToString() == "#")
                {
                    this.label3.Text = "";
                }
                else
                {
                    this.label3.Text = "客服QQ：" + list["ziduan3"].ToString() + "";
                }
                if (list["ziduan4"].ToString() == "#")
                {
                    this.label4.Text = "";
                }
                else
                {
                    this.label4.Text = "联系电话：" + list["ziduan4"].ToString() + "";
                }
                if (list["ziduan5"].ToString() == "#")
                {
                    this.label5.Text = "";
                }
                else
                {
                    this.label5.Text = "网址：" + list["ziduan5"].ToString() + "";
                }
                this.ziduan5 = list["ziduan5"].ToString();
            }
            list.Close();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(guanyu));
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.button1 = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x16, 0x15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0, 12);
            this.label1.TabIndex = 0;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x16, 0x35);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0, 12);
            this.label2.TabIndex = 1;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x16, 0x59);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0, 12);
            this.label3.TabIndex = 2;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x16, 0x80);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0, 12);
            this.label4.TabIndex = 3;
            this.label5.AutoSize = true;
            this.label5.Cursor = Cursors.Hand;
            this.label5.Location = new Point(0x16, 0xa7);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0, 12);
            this.label5.TabIndex = 4;
            this.label5.Click += new EventHandler(this.label5_Click);
            this.button1.Location = new Point(0x12b, 0xca);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 5;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x19e, 0xf5);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "guanyu";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "关于";
            base.TopMost = true;
            base.Load += new EventHandler(this.guanyu_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            string str = this.ziduan5;
            process.StartInfo.FileName = "iexplore.exe";
            process.StartInfo.Arguments = str;
            process.Start();
        }
    }
}


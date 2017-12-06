namespace xyoa.SchTable.JiaoShi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Kecheng : Page
    {
        protected Button Button2;
        protected CheckBox CheckBox1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlButton FONT1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Jieci;
        protected Label Kecheng1_1;
        protected Label Kecheng1_10;
        protected Label Kecheng1_2;
        protected Label Kecheng1_3;
        protected Label Kecheng1_4;
        protected Label Kecheng1_5;
        protected Label Kecheng1_6;
        protected Label Kecheng1_7;
        protected Label Kecheng1_8;
        protected Label Kecheng1_9;
        protected Label Kecheng2_1;
        protected Label Kecheng2_10;
        protected Label Kecheng2_2;
        protected Label Kecheng2_3;
        protected Label Kecheng2_4;
        protected Label Kecheng2_5;
        protected Label Kecheng2_6;
        protected Label Kecheng2_7;
        protected Label Kecheng2_8;
        protected Label Kecheng2_9;
        protected Label Kecheng3_1;
        protected Label Kecheng3_10;
        protected Label Kecheng3_2;
        protected Label Kecheng3_3;
        protected Label Kecheng3_4;
        protected Label Kecheng3_5;
        protected Label Kecheng3_6;
        protected Label Kecheng3_7;
        protected Label Kecheng3_8;
        protected Label Kecheng3_9;
        protected Label Kecheng4_1;
        protected Label Kecheng4_10;
        protected Label Kecheng4_2;
        protected Label Kecheng4_3;
        protected Label Kecheng4_4;
        protected Label Kecheng4_5;
        protected Label Kecheng4_6;
        protected Label Kecheng4_7;
        protected Label Kecheng4_8;
        protected Label Kecheng4_9;
        protected Label Kecheng5_1;
        protected Label Kecheng5_10;
        protected Label Kecheng5_2;
        protected Label Kecheng5_3;
        protected Label Kecheng5_4;
        protected Label Kecheng5_5;
        protected Label Kecheng5_6;
        protected Label Kecheng5_7;
        protected Label Kecheng5_8;
        protected Label Kecheng5_9;
        protected Label Kecheng6_1;
        protected Label Kecheng6_10;
        protected Label Kecheng6_2;
        protected Label Kecheng6_3;
        protected Label Kecheng6_4;
        protected Label Kecheng6_5;
        protected Label Kecheng6_6;
        protected Label Kecheng6_7;
        protected Label Kecheng6_8;
        protected Label Kecheng6_9;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label LsUsername1_1;
        protected Label LsUsername1_10;
        protected Label LsUsername1_2;
        protected Label LsUsername1_3;
        protected Label LsUsername1_4;
        protected Label LsUsername1_5;
        protected Label LsUsername1_6;
        protected Label LsUsername1_7;
        protected Label LsUsername1_8;
        protected Label LsUsername1_9;
        protected Label LsUsername2_1;
        protected Label LsUsername2_10;
        protected Label LsUsername2_2;
        protected Label LsUsername2_3;
        protected Label LsUsername2_4;
        protected Label LsUsername2_5;
        protected Label LsUsername2_6;
        protected Label LsUsername2_7;
        protected Label LsUsername2_8;
        protected Label LsUsername2_9;
        protected Label LsUsername3_1;
        protected Label LsUsername3_10;
        protected Label LsUsername3_2;
        protected Label LsUsername3_3;
        protected Label LsUsername3_4;
        protected Label LsUsername3_5;
        protected Label LsUsername3_6;
        protected Label LsUsername3_7;
        protected Label LsUsername3_8;
        protected Label LsUsername3_9;
        protected Label LsUsername4_1;
        protected Label LsUsername4_10;
        protected Label LsUsername4_2;
        protected Label LsUsername4_3;
        protected Label LsUsername4_4;
        protected Label LsUsername4_5;
        protected Label LsUsername4_6;
        protected Label LsUsername4_7;
        protected Label LsUsername4_8;
        protected Label LsUsername4_9;
        protected Label LsUsername5_1;
        protected Label LsUsername5_10;
        protected Label LsUsername5_2;
        protected Label LsUsername5_3;
        protected Label LsUsername5_4;
        protected Label LsUsername5_5;
        protected Label LsUsername5_6;
        protected Label LsUsername5_7;
        protected Label LsUsername5_8;
        protected Label LsUsername5_9;
        protected Label LsUsername6_1;
        protected Label LsUsername6_10;
        protected Label LsUsername6_2;
        protected Label LsUsername6_3;
        protected Label LsUsername6_4;
        protected Label LsUsername6_5;
        protected Label LsUsername6_6;
        protected Label LsUsername6_7;
        protected Label LsUsername6_8;
        protected Label LsUsername6_9;
        protected Panel P1;
        protected Panel P10;
        protected Panel P11;
        protected Panel P2;
        protected Panel P3;
        protected Panel P4;
        protected Panel P5;
        protected Panel P6;
        protected Panel P7;
        protected Panel P8;
        protected Panel P9;
        protected PlaceHolder PlaceHolder1;
        private publics pulicss = new publics();
        protected TextBox Xingqi;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.pulicss.ToExcelChe(this.PlaceHolder1, "" + this.ViewState["Mingcheng"] + "课程表");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckBoxBind();
        }

        public void CheckBoxBind()
        {
            if (this.CheckBox1.Checked)
            {
                this.LsUsername1_1.Visible = true;
                this.LsUsername2_1.Visible = true;
                this.LsUsername3_1.Visible = true;
                this.LsUsername4_1.Visible = true;
                this.LsUsername5_1.Visible = true;
                this.LsUsername6_1.Visible = true;
                this.LsUsername1_2.Visible = true;
                this.LsUsername2_2.Visible = true;
                this.LsUsername3_2.Visible = true;
                this.LsUsername4_2.Visible = true;
                this.LsUsername5_2.Visible = true;
                this.LsUsername6_2.Visible = true;
                this.LsUsername1_3.Visible = true;
                this.LsUsername2_3.Visible = true;
                this.LsUsername3_3.Visible = true;
                this.LsUsername4_3.Visible = true;
                this.LsUsername5_3.Visible = true;
                this.LsUsername6_3.Visible = true;
                this.LsUsername1_4.Visible = true;
                this.LsUsername2_4.Visible = true;
                this.LsUsername3_4.Visible = true;
                this.LsUsername4_4.Visible = true;
                this.LsUsername5_4.Visible = true;
                this.LsUsername6_4.Visible = true;
                this.LsUsername1_5.Visible = true;
                this.LsUsername2_5.Visible = true;
                this.LsUsername3_5.Visible = true;
                this.LsUsername4_5.Visible = true;
                this.LsUsername5_5.Visible = true;
                this.LsUsername6_5.Visible = true;
                this.LsUsername1_6.Visible = true;
                this.LsUsername2_6.Visible = true;
                this.LsUsername3_6.Visible = true;
                this.LsUsername4_6.Visible = true;
                this.LsUsername5_6.Visible = true;
                this.LsUsername6_6.Visible = true;
                this.LsUsername1_7.Visible = true;
                this.LsUsername2_7.Visible = true;
                this.LsUsername3_7.Visible = true;
                this.LsUsername4_7.Visible = true;
                this.LsUsername5_7.Visible = true;
                this.LsUsername6_7.Visible = true;
                this.LsUsername1_8.Visible = true;
                this.LsUsername2_8.Visible = true;
                this.LsUsername3_8.Visible = true;
                this.LsUsername4_8.Visible = true;
                this.LsUsername5_8.Visible = true;
                this.LsUsername6_8.Visible = true;
                this.LsUsername1_9.Visible = true;
                this.LsUsername2_9.Visible = true;
                this.LsUsername3_9.Visible = true;
                this.LsUsername4_9.Visible = true;
                this.LsUsername5_9.Visible = true;
                this.LsUsername6_9.Visible = true;
                this.LsUsername1_10.Visible = true;
                this.LsUsername2_10.Visible = true;
                this.LsUsername3_10.Visible = true;
                this.LsUsername4_10.Visible = true;
                this.LsUsername5_10.Visible = true;
                this.LsUsername6_10.Visible = true;
            }
            else
            {
                this.LsUsername1_1.Visible = false;
                this.LsUsername2_1.Visible = false;
                this.LsUsername3_1.Visible = false;
                this.LsUsername4_1.Visible = false;
                this.LsUsername5_1.Visible = false;
                this.LsUsername6_1.Visible = false;
                this.LsUsername1_2.Visible = false;
                this.LsUsername2_2.Visible = false;
                this.LsUsername3_2.Visible = false;
                this.LsUsername4_2.Visible = false;
                this.LsUsername5_2.Visible = false;
                this.LsUsername6_2.Visible = false;
                this.LsUsername1_3.Visible = false;
                this.LsUsername2_3.Visible = false;
                this.LsUsername3_3.Visible = false;
                this.LsUsername4_3.Visible = false;
                this.LsUsername5_3.Visible = false;
                this.LsUsername6_3.Visible = false;
                this.LsUsername1_4.Visible = false;
                this.LsUsername2_4.Visible = false;
                this.LsUsername3_4.Visible = false;
                this.LsUsername4_4.Visible = false;
                this.LsUsername5_4.Visible = false;
                this.LsUsername6_4.Visible = false;
                this.LsUsername1_5.Visible = false;
                this.LsUsername2_5.Visible = false;
                this.LsUsername3_5.Visible = false;
                this.LsUsername4_5.Visible = false;
                this.LsUsername5_5.Visible = false;
                this.LsUsername6_5.Visible = false;
                this.LsUsername1_6.Visible = false;
                this.LsUsername2_6.Visible = false;
                this.LsUsername3_6.Visible = false;
                this.LsUsername4_6.Visible = false;
                this.LsUsername5_6.Visible = false;
                this.LsUsername6_6.Visible = false;
                this.LsUsername1_7.Visible = false;
                this.LsUsername2_7.Visible = false;
                this.LsUsername3_7.Visible = false;
                this.LsUsername4_7.Visible = false;
                this.LsUsername5_7.Visible = false;
                this.LsUsername6_7.Visible = false;
                this.LsUsername1_8.Visible = false;
                this.LsUsername2_8.Visible = false;
                this.LsUsername3_8.Visible = false;
                this.LsUsername4_8.Visible = false;
                this.LsUsername5_8.Visible = false;
                this.LsUsername6_8.Visible = false;
                this.LsUsername1_9.Visible = false;
                this.LsUsername2_9.Visible = false;
                this.LsUsername3_9.Visible = false;
                this.LsUsername4_9.Visible = false;
                this.LsUsername5_9.Visible = false;
                this.LsUsername6_9.Visible = false;
                this.LsUsername1_10.Visible = false;
                this.LsUsername2_10.Visible = false;
                this.LsUsername3_10.Visible = false;
                this.LsUsername4_10.Visible = false;
                this.LsUsername5_10.Visible = false;
                this.LsUsername6_10.Visible = false;
            }
        }

        public void DataBindToGridview()
        {
            this.ViewState["Mingcheng"] = this.Session["Realname"].ToString();
            this.Kecheng1_1.Text = "";
            this.LsUsername1_1.Text = "";
            this.Kecheng2_1.Text = "";
            this.LsUsername2_1.Text = "";
            this.Kecheng3_1.Text = "";
            this.LsUsername3_1.Text = "";
            this.Kecheng4_1.Text = "";
            this.LsUsername4_1.Text = "";
            this.Kecheng5_1.Text = "";
            this.LsUsername5_1.Text = "";
            this.Kecheng6_1.Text = "";
            this.LsUsername6_1.Text = "";
            this.Kecheng1_2.Text = "";
            this.LsUsername1_2.Text = "";
            this.Kecheng2_2.Text = "";
            this.LsUsername2_2.Text = "";
            this.Kecheng3_2.Text = "";
            this.LsUsername3_2.Text = "";
            this.Kecheng4_2.Text = "";
            this.LsUsername4_2.Text = "";
            this.Kecheng5_2.Text = "";
            this.LsUsername5_2.Text = "";
            this.Kecheng6_2.Text = "";
            this.LsUsername6_2.Text = "";
            this.Kecheng1_3.Text = "";
            this.LsUsername1_3.Text = "";
            this.Kecheng2_3.Text = "";
            this.LsUsername2_3.Text = "";
            this.Kecheng3_3.Text = "";
            this.LsUsername3_3.Text = "";
            this.Kecheng4_3.Text = "";
            this.LsUsername4_3.Text = "";
            this.Kecheng5_3.Text = "";
            this.LsUsername5_3.Text = "";
            this.Kecheng6_3.Text = "";
            this.LsUsername6_3.Text = "";
            this.Kecheng1_4.Text = "";
            this.LsUsername1_4.Text = "";
            this.Kecheng2_4.Text = "";
            this.LsUsername2_4.Text = "";
            this.Kecheng3_4.Text = "";
            this.LsUsername3_4.Text = "";
            this.Kecheng4_4.Text = "";
            this.LsUsername4_4.Text = "";
            this.Kecheng5_4.Text = "";
            this.LsUsername5_4.Text = "";
            this.Kecheng6_4.Text = "";
            this.LsUsername6_4.Text = "";
            this.Kecheng1_5.Text = "";
            this.LsUsername1_5.Text = "";
            this.Kecheng2_5.Text = "";
            this.LsUsername2_5.Text = "";
            this.Kecheng3_5.Text = "";
            this.LsUsername3_5.Text = "";
            this.Kecheng4_5.Text = "";
            this.LsUsername4_5.Text = "";
            this.Kecheng5_5.Text = "";
            this.LsUsername5_5.Text = "";
            this.Kecheng6_5.Text = "";
            this.LsUsername6_5.Text = "";
            this.Kecheng1_6.Text = "";
            this.LsUsername1_6.Text = "";
            this.Kecheng2_6.Text = "";
            this.LsUsername2_6.Text = "";
            this.Kecheng3_6.Text = "";
            this.LsUsername3_6.Text = "";
            this.Kecheng4_6.Text = "";
            this.LsUsername4_6.Text = "";
            this.Kecheng5_6.Text = "";
            this.LsUsername5_6.Text = "";
            this.Kecheng6_6.Text = "";
            this.LsUsername6_6.Text = "";
            this.Kecheng1_7.Text = "";
            this.LsUsername1_7.Text = "";
            this.Kecheng2_7.Text = "";
            this.LsUsername2_7.Text = "";
            this.Kecheng3_7.Text = "";
            this.LsUsername3_7.Text = "";
            this.Kecheng4_7.Text = "";
            this.LsUsername4_7.Text = "";
            this.Kecheng5_7.Text = "";
            this.LsUsername5_7.Text = "";
            this.Kecheng6_7.Text = "";
            this.LsUsername6_7.Text = "";
            this.Kecheng1_8.Text = "";
            this.LsUsername1_8.Text = "";
            this.Kecheng2_8.Text = "";
            this.LsUsername2_8.Text = "";
            this.Kecheng3_8.Text = "";
            this.LsUsername3_8.Text = "";
            this.Kecheng4_8.Text = "";
            this.LsUsername4_8.Text = "";
            this.Kecheng5_8.Text = "";
            this.LsUsername5_8.Text = "";
            this.Kecheng6_8.Text = "";
            this.LsUsername6_8.Text = "";
            this.Kecheng1_9.Text = "";
            this.LsUsername1_9.Text = "";
            this.Kecheng2_9.Text = "";
            this.LsUsername2_9.Text = "";
            this.Kecheng3_9.Text = "";
            this.LsUsername3_9.Text = "";
            this.Kecheng4_9.Text = "";
            this.LsUsername4_9.Text = "";
            this.Kecheng5_9.Text = "";
            this.LsUsername5_9.Text = "";
            this.Kecheng6_9.Text = "";
            this.LsUsername6_9.Text = "";
            this.Kecheng1_10.Text = "";
            this.LsUsername1_10.Text = "";
            this.Kecheng2_10.Text = "";
            this.LsUsername2_10.Text = "";
            this.Kecheng3_10.Text = "";
            this.LsUsername3_10.Text = "";
            this.Kecheng4_10.Text = "";
            this.LsUsername4_10.Text = "";
            this.Kecheng5_10.Text = "";
            this.LsUsername5_10.Text = "";
            this.Kecheng6_10.Text = "";
            this.LsUsername6_10.Text = "";
            string sql = string.Concat(new object[] { "select A.Jieci,A.Xingqi,A.Kecheng,B.Mingcheng from qp_sch_KechengBiao as [A] inner join [qp_sch_Banji] as [B] on [A].[Banji] = [B].[Id] where A.Xueqi='", this.Xueqi.SelectedValue, "' and A.Xueduan='", this.Xueduan.SelectedValue, "' and A.LsUsername='", this.Session["Username"], "' order by A.id asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                if ((list["Jieci"].ToString() == "1") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_1.Text = list["Kecheng"].ToString();
                    this.LsUsername1_1.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "1") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_1.Text = list["Kecheng"].ToString();
                    this.LsUsername2_1.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "1") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_1.Text = list["Kecheng"].ToString();
                    this.LsUsername3_1.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "1") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_1.Text = list["Kecheng"].ToString();
                    this.LsUsername4_1.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "1") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_1.Text = list["Kecheng"].ToString();
                    this.LsUsername5_1.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "1") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_1.Text = list["Kecheng"].ToString();
                    this.LsUsername6_1.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "2") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_2.Text = list["Kecheng"].ToString();
                    this.LsUsername1_2.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "2") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_2.Text = list["Kecheng"].ToString();
                    this.LsUsername2_2.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "2") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_2.Text = list["Kecheng"].ToString();
                    this.LsUsername3_2.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "2") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_2.Text = list["Kecheng"].ToString();
                    this.LsUsername4_2.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "2") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_2.Text = list["Kecheng"].ToString();
                    this.LsUsername5_2.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "2") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_2.Text = list["Kecheng"].ToString();
                    this.LsUsername6_2.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "3") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_3.Text = list["Kecheng"].ToString();
                    this.LsUsername1_3.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "3") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_3.Text = list["Kecheng"].ToString();
                    this.LsUsername2_3.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "3") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_3.Text = list["Kecheng"].ToString();
                    this.LsUsername3_3.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "3") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_3.Text = list["Kecheng"].ToString();
                    this.LsUsername4_3.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "3") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_3.Text = list["Kecheng"].ToString();
                    this.LsUsername5_3.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "3") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_3.Text = list["Kecheng"].ToString();
                    this.LsUsername6_3.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "4") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_4.Text = list["Kecheng"].ToString();
                    this.LsUsername1_4.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "4") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_4.Text = list["Kecheng"].ToString();
                    this.LsUsername2_4.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "4") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_4.Text = list["Kecheng"].ToString();
                    this.LsUsername3_4.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "4") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_4.Text = list["Kecheng"].ToString();
                    this.LsUsername4_4.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "4") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_4.Text = list["Kecheng"].ToString();
                    this.LsUsername5_4.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "4") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_4.Text = list["Kecheng"].ToString();
                    this.LsUsername6_4.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "5") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_5.Text = list["Kecheng"].ToString();
                    this.LsUsername1_5.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "5") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_5.Text = list["Kecheng"].ToString();
                    this.LsUsername2_5.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "5") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_5.Text = list["Kecheng"].ToString();
                    this.LsUsername3_5.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "5") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_5.Text = list["Kecheng"].ToString();
                    this.LsUsername4_5.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "5") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_5.Text = list["Kecheng"].ToString();
                    this.LsUsername5_5.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "5") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_5.Text = list["Kecheng"].ToString();
                    this.LsUsername6_5.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "6") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_6.Text = list["Kecheng"].ToString();
                    this.LsUsername1_6.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "6") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_6.Text = list["Kecheng"].ToString();
                    this.LsUsername2_6.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "6") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_6.Text = list["Kecheng"].ToString();
                    this.LsUsername3_6.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "6") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_6.Text = list["Kecheng"].ToString();
                    this.LsUsername4_6.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "6") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_6.Text = list["Kecheng"].ToString();
                    this.LsUsername5_6.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "6") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_6.Text = list["Kecheng"].ToString();
                    this.LsUsername6_6.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "7") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_7.Text = list["Kecheng"].ToString();
                    this.LsUsername1_7.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "7") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_7.Text = list["Kecheng"].ToString();
                    this.LsUsername2_7.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "7") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_7.Text = list["Kecheng"].ToString();
                    this.LsUsername3_7.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "7") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_7.Text = list["Kecheng"].ToString();
                    this.LsUsername4_7.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "7") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_7.Text = list["Kecheng"].ToString();
                    this.LsUsername5_7.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "7") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_7.Text = list["Kecheng"].ToString();
                    this.LsUsername6_7.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "8") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_8.Text = list["Kecheng"].ToString();
                    this.LsUsername1_8.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "8") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_8.Text = list["Kecheng"].ToString();
                    this.LsUsername2_8.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "8") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_8.Text = list["Kecheng"].ToString();
                    this.LsUsername3_8.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "8") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_8.Text = list["Kecheng"].ToString();
                    this.LsUsername4_8.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "8") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_8.Text = list["Kecheng"].ToString();
                    this.LsUsername5_8.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "8") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_8.Text = list["Kecheng"].ToString();
                    this.LsUsername6_8.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "9") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_9.Text = list["Kecheng"].ToString();
                    this.LsUsername1_9.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "9") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_9.Text = list["Kecheng"].ToString();
                    this.LsUsername2_9.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "9") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_9.Text = list["Kecheng"].ToString();
                    this.LsUsername3_9.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "9") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_9.Text = list["Kecheng"].ToString();
                    this.LsUsername4_9.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "9") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_9.Text = list["Kecheng"].ToString();
                    this.LsUsername5_9.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "9") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_9.Text = list["Kecheng"].ToString();
                    this.LsUsername6_9.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "10") && (list["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_10.Text = list["Kecheng"].ToString();
                    this.LsUsername1_10.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "10") && (list["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_10.Text = list["Kecheng"].ToString();
                    this.LsUsername2_10.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "10") && (list["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_10.Text = list["Kecheng"].ToString();
                    this.LsUsername3_10.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "10") && (list["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_10.Text = list["Kecheng"].ToString();
                    this.LsUsername4_10.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "10") && (list["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_10.Text = list["Kecheng"].ToString();
                    this.LsUsername5_10.Text = list["Mingcheng"].ToString();
                }
                if ((list["Jieci"].ToString() == "10") && (list["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_10.Text = list["Kecheng"].ToString();
                    this.LsUsername6_10.Text = list["Mingcheng"].ToString();
                }
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                this.CheckBoxBind();
                this.DataBindToGridview();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void Xueduan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }
    }
}


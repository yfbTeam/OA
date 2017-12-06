namespace xyoa.SchTable.Paike
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Chaxun_Pk : Page
    {
        protected Button Button2;
        protected CheckBox CheckBox1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
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
        protected Label Label1;
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
        protected Panel Panel1;
        protected Panel Panel2;
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
            string sql = "select * from qp_sch_Banji where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["Mingcheng"] = list["Mingcheng"].ToString();
                string str2 = "select * from qp_sch_Nianji where Xueqi='" + this.Xueqi.SelectedValue + "' and NianjiMc='" + list["Nianji"].ToString() + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    if (reader2["Richeng1"].ToString() == "1")
                    {
                        this.P1.Visible = true;
                        this.P2.Visible = false;
                        this.P3.Visible = false;
                        this.P4.Visible = false;
                    }
                    else if (reader2["Richeng1"].ToString() == "2")
                    {
                        this.P1.Visible = true;
                        this.P2.Visible = true;
                        this.P3.Visible = false;
                        this.P4.Visible = false;
                    }
                    else if (reader2["Richeng1"].ToString() == "3")
                    {
                        this.P1.Visible = true;
                        this.P2.Visible = true;
                        this.P3.Visible = true;
                        this.P4.Visible = false;
                    }
                    else if (reader2["Richeng1"].ToString() == "4")
                    {
                        this.P1.Visible = true;
                        this.P2.Visible = true;
                        this.P3.Visible = true;
                        this.P4.Visible = true;
                    }
                    if (reader2["Richeng2"].ToString() == "1")
                    {
                        this.P5.Visible = true;
                        this.P6.Visible = false;
                        this.P7.Visible = false;
                        this.P8.Visible = false;
                    }
                    else if (reader2["Richeng2"].ToString() == "2")
                    {
                        this.P5.Visible = true;
                        this.P6.Visible = true;
                        this.P7.Visible = false;
                        this.P8.Visible = false;
                    }
                    else if (reader2["Richeng2"].ToString() == "3")
                    {
                        this.P5.Visible = true;
                        this.P6.Visible = true;
                        this.P7.Visible = true;
                        this.P8.Visible = false;
                    }
                    else if (reader2["Richeng2"].ToString() == "4")
                    {
                        this.P5.Visible = true;
                        this.P6.Visible = true;
                        this.P7.Visible = true;
                        this.P8.Visible = true;
                    }
                    if (reader2["Richeng3"].ToString() == "0")
                    {
                        this.P11.Visible = false;
                        this.P9.Visible = false;
                        this.P10.Visible = false;
                    }
                    else if (reader2["Richeng3"].ToString() == "1")
                    {
                        this.P11.Visible = true;
                        this.P9.Visible = true;
                        this.P10.Visible = false;
                    }
                    else if (reader2["Richeng3"].ToString() == "2")
                    {
                        this.P11.Visible = true;
                        this.P9.Visible = true;
                        this.P10.Visible = true;
                    }
                }
                reader2.Close();
            }
            list.Close();
            string str3 = "select * from qp_sch_KechengBiao where Xueqi='" + this.Xueqi.SelectedValue + "' and Xueduan='" + this.Xueduan.SelectedValue + "' and Banji='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader reader3 = this.List.GetList(str3);
            while (reader3.Read())
            {
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_10.Text = reader3["LsRealname"].ToString();
                }
            }
            reader3.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    if (base.Request.QueryString["id"].ToString() == "0")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                        this.Panel2.Visible = true;
                        string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                        this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                        this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                        this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                        this.CheckBoxBind();
                        this.DataBindToGridview();
                    }
                }
                else
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}


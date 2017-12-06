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

    public class Shoudong_Pk : Page
    {
        protected Button Button1;
        protected Button Button3;
        protected Button Button4;
        protected Button Button5;
        protected CheckBox CheckBox1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected DropDownList DrBanji;
        protected DropDownList DrNianji;
        protected DropDownList DrXueduan;
        protected DropDownList DrXueqi;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Jieci;
        protected DropDownList Kecheng;
        protected LinkButton Kecheng1_1;
        protected LinkButton Kecheng1_10;
        protected LinkButton Kecheng1_2;
        protected LinkButton Kecheng1_3;
        protected LinkButton Kecheng1_4;
        protected LinkButton Kecheng1_5;
        protected LinkButton Kecheng1_6;
        protected LinkButton Kecheng1_7;
        protected LinkButton Kecheng1_8;
        protected LinkButton Kecheng1_9;
        protected LinkButton Kecheng2_1;
        protected LinkButton Kecheng2_10;
        protected LinkButton Kecheng2_2;
        protected LinkButton Kecheng2_3;
        protected LinkButton Kecheng2_4;
        protected LinkButton Kecheng2_5;
        protected LinkButton Kecheng2_6;
        protected LinkButton Kecheng2_7;
        protected LinkButton Kecheng2_8;
        protected LinkButton Kecheng2_9;
        protected LinkButton Kecheng3_1;
        protected LinkButton Kecheng3_10;
        protected LinkButton Kecheng3_2;
        protected LinkButton Kecheng3_3;
        protected LinkButton Kecheng3_4;
        protected LinkButton Kecheng3_5;
        protected LinkButton Kecheng3_6;
        protected LinkButton Kecheng3_7;
        protected LinkButton Kecheng3_8;
        protected LinkButton Kecheng3_9;
        protected LinkButton Kecheng4_1;
        protected LinkButton Kecheng4_10;
        protected LinkButton Kecheng4_2;
        protected LinkButton Kecheng4_3;
        protected LinkButton Kecheng4_4;
        protected LinkButton Kecheng4_5;
        protected LinkButton Kecheng4_6;
        protected LinkButton Kecheng4_7;
        protected LinkButton Kecheng4_8;
        protected LinkButton Kecheng4_9;
        protected LinkButton Kecheng5_1;
        protected LinkButton Kecheng5_10;
        protected LinkButton Kecheng5_2;
        protected LinkButton Kecheng5_3;
        protected LinkButton Kecheng5_4;
        protected LinkButton Kecheng5_5;
        protected LinkButton Kecheng5_6;
        protected LinkButton Kecheng5_7;
        protected LinkButton Kecheng5_8;
        protected LinkButton Kecheng5_9;
        protected LinkButton Kecheng6_1;
        protected LinkButton Kecheng6_10;
        protected LinkButton Kecheng6_2;
        protected LinkButton Kecheng6_3;
        protected LinkButton Kecheng6_4;
        protected LinkButton Kecheng6_5;
        protected LinkButton Kecheng6_6;
        protected LinkButton Kecheng6_7;
        protected LinkButton Kecheng6_8;
        protected LinkButton Kecheng6_9;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList LsUsername;
        protected LinkButton LsUsername1_1;
        protected LinkButton LsUsername1_10;
        protected LinkButton LsUsername1_2;
        protected LinkButton LsUsername1_3;
        protected LinkButton LsUsername1_4;
        protected LinkButton LsUsername1_5;
        protected LinkButton LsUsername1_6;
        protected LinkButton LsUsername1_7;
        protected LinkButton LsUsername1_8;
        protected LinkButton LsUsername1_9;
        protected LinkButton LsUsername2_1;
        protected LinkButton LsUsername2_10;
        protected LinkButton LsUsername2_2;
        protected LinkButton LsUsername2_3;
        protected LinkButton LsUsername2_4;
        protected LinkButton LsUsername2_5;
        protected LinkButton LsUsername2_6;
        protected LinkButton LsUsername2_7;
        protected LinkButton LsUsername2_8;
        protected LinkButton LsUsername2_9;
        protected LinkButton LsUsername3_1;
        protected LinkButton LsUsername3_10;
        protected LinkButton LsUsername3_2;
        protected LinkButton LsUsername3_3;
        protected LinkButton LsUsername3_4;
        protected LinkButton LsUsername3_5;
        protected LinkButton LsUsername3_6;
        protected LinkButton LsUsername3_7;
        protected LinkButton LsUsername3_8;
        protected LinkButton LsUsername3_9;
        protected LinkButton LsUsername4_1;
        protected LinkButton LsUsername4_10;
        protected LinkButton LsUsername4_2;
        protected LinkButton LsUsername4_3;
        protected LinkButton LsUsername4_4;
        protected LinkButton LsUsername4_5;
        protected LinkButton LsUsername4_6;
        protected LinkButton LsUsername4_7;
        protected LinkButton LsUsername4_8;
        protected LinkButton LsUsername4_9;
        protected LinkButton LsUsername5_1;
        protected LinkButton LsUsername5_10;
        protected LinkButton LsUsername5_2;
        protected LinkButton LsUsername5_3;
        protected LinkButton LsUsername5_4;
        protected LinkButton LsUsername5_5;
        protected LinkButton LsUsername5_6;
        protected LinkButton LsUsername5_7;
        protected LinkButton LsUsername5_8;
        protected LinkButton LsUsername5_9;
        protected LinkButton LsUsername6_1;
        protected LinkButton LsUsername6_10;
        protected LinkButton LsUsername6_2;
        protected LinkButton LsUsername6_3;
        protected LinkButton LsUsername6_4;
        protected LinkButton LsUsername6_5;
        protected LinkButton LsUsername6_6;
        protected LinkButton LsUsername6_7;
        protected LinkButton LsUsername6_8;
        protected LinkButton LsUsername6_9;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "  Delete from qp_sch_KechengBiao  where Jieci='" + this.Jieci.Text + "' and Xingqi='" + this.Xingqi.Text + "' and Banji='" + base.Request.QueryString["id"] + "' and Xueqi='" + this.Xueqi.SelectedValue + "' and Xueduan='" + this.Xueduan.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.KechengUpdate();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_sch_KechengBiao where  Banji='" + this.DrBanji.SelectedValue + "' and Xueqi='" + this.DrXueqi.SelectedValue + "' and Xueduan='" + this.DrXueduan.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str2 = string.Concat(new object[] { 
                    "insert into qp_sch_KechengBiao (Xueqi,Xueduan,Banji,Jieci,Xingqi,KechengId,Kecheng,LsUsername,LsRealname) values ('", this.Xueqi.SelectedValue, "','", this.Xueduan.SelectedValue, "','", base.Request.QueryString["id"], "','", list["Jieci"], "','", list["Xingqi"], "','", list["KechengId"], "','", list["Kecheng"], "','", list["LsUsername"], 
                    "','", list["LsRealname"], "')"
                 });
                this.List.ExeSql(str2);
            }
            list.Close();
            base.Response.Redirect("Shoudong_Pk.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sql = "select id from qp_sch_KechengBiao where  Jieci='" + this.Jieci.Text + "' and Xingqi='" + this.Xingqi.Text + "' and Banji='" + base.Request.QueryString["id"] + "' and Xueqi='" + this.Xueqi.SelectedValue + "' and Xueduan='" + this.Xueduan.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "Update qp_sch_KechengBiao  Set KechengId='", this.Kecheng.SelectedValue, "',Kecheng='", this.Kecheng.SelectedItem.Text, "',LsUsername='", this.LsUsername.SelectedValue, "',LsRealname='", this.LsUsername.SelectedItem.Text, "'  where id='", list["id"], "'" });
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = "insert into qp_sch_KechengBiao (Xueqi,Xueduan,Banji,Jieci,Xingqi,KechengId,Kecheng,LsUsername,LsRealname) values ('" + this.Xueqi.SelectedValue + "','" + this.Xueduan.SelectedValue + "','" + base.Request.QueryString["id"] + "','" + this.Jieci.Text + "','" + this.Xingqi.Text + "','" + this.Kecheng.SelectedValue + "','" + this.Kecheng.SelectedItem.Text + "','" + this.LsUsername.SelectedValue + "','" + this.LsUsername.SelectedItem.Text + "')";
                this.List.ExeSql(str3);
            }
            list.Close();
            this.KechengInsert();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string sql = "  Delete from qp_sch_KechengBiao  where Banji='" + base.Request.QueryString["id"] + "' and Xueqi='" + this.Xueqi.SelectedValue + "' and Xueduan='" + this.Xueduan.SelectedValue + "'";
            this.List.ExeSql(sql);
            base.Response.Redirect("Shoudong_Pk.aspx?id=" + base.Request.QueryString["id"] + "");
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
                    this.Kecheng1_1.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_1.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_1.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_1.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_1.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_1.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_1.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_1.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_1.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_1.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "1") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_1.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_1.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_1.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_1.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_2.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_2.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_2.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_2.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_2.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_2.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_2.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_2.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_2.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_2.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "2") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_2.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_2.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_2.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_2.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_3.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_3.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_3.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_3.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_3.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_3.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_3.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_3.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_3.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_3.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "3") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_3.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_3.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_3.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_3.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_4.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_4.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_4.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_4.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_4.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_4.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_4.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_4.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_4.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_4.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "4") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_4.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_4.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_4.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_4.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_5.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_5.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_5.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_5.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_5.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_5.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_5.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_5.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_5.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_5.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "5") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_5.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_5.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_5.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_5.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_6.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_6.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_6.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_6.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_6.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_6.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_6.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_6.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_6.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_6.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "6") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_6.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_6.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_6.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_6.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_7.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_7.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_7.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_7.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_7.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_7.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_7.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_7.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_7.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_7.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "7") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_7.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_7.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_7.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_7.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_8.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_8.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_8.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_8.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_8.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_8.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_8.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_8.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_8.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_8.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "8") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_8.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_8.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_8.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_8.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_9.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_9.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_9.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_9.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_9.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_9.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_9.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_9.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_9.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_9.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "9") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_9.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_9.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_9.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_9.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "1"))
                {
                    this.Kecheng1_10.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng1_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername1_10.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername1_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "2"))
                {
                    this.Kecheng2_10.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng2_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername2_10.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername2_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "3"))
                {
                    this.Kecheng3_10.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng3_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername3_10.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername3_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "4"))
                {
                    this.Kecheng4_10.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng4_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername4_10.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername4_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "5"))
                {
                    this.Kecheng5_10.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng5_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername5_10.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername5_10.Text = reader3["LsRealname"].ToString();
                }
                if ((reader3["Jieci"].ToString() == "10") && (reader3["Xingqi"].ToString() == "6"))
                {
                    this.Kecheng6_10.CommandArgument = reader3["KechengId"].ToString();
                    this.Kecheng6_10.Text = reader3["Kecheng"].ToString();
                    this.LsUsername6_10.CommandArgument = reader3["LsUsername"].ToString();
                    this.LsUsername6_10.Text = reader3["LsRealname"].ToString();
                }
            }
            reader3.Close();
        }

        protected void DrNianji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   Xueqi='" + this.Xueqi.SelectedValue + "' and Nianji='" + this.DrNianji.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_nothing(this.DrBanji, sQL, "id", "Mingcheng");
        }

        protected void DrXueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  Xueqi='" + this.Xueqi.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_nothing(this.DrNianji, sQL, "NianjiMc", "NianjiMc");
            string str2 = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   Xueqi='" + this.Xueqi.SelectedValue + "' and Nianji='" + this.DrNianji.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_nothing(this.DrBanji, str2, "id", "Mingcheng");
        }

        protected void Kecheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Kecheng.SelectedValue != "请选择")
            {
                string sql = "select RkUsername from qp_sch_Kecheng where  id='" + this.Kecheng.SelectedValue + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string sQL = "select Username,Realname from [qp_oa_Username]  where   '%" + list["RkUsername"].ToString() + "%' like '%'+Username+'%' and  ifdel='0' order by paixu asc";
                    this.list.Bind_DropDownList(this.LsUsername, sQL, "Username", "Realname");
                }
                list.Close();
                this.Label2.Text = this.LsUsername.SelectedItem.Text;
            }
        }

        protected void Kecheng1_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_1.Text + " " + this.LsUsername1_1.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_10.Text + " " + this.LsUsername1_10.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_2.Text + " " + this.LsUsername1_2.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_3.Text + " " + this.LsUsername1_3.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_4.Text + " " + this.LsUsername1_4.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_5.Text + " " + this.LsUsername1_5.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_6.Text + " " + this.LsUsername1_6.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_7.Text + " " + this.LsUsername1_7.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_8.Text + " " + this.LsUsername1_8.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng1_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_9.Text + " " + this.LsUsername1_9.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_1.Text + " " + this.LsUsername2_1.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_10.Text + " " + this.LsUsername2_10.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_2.Text + " " + this.LsUsername2_2.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_3.Text + " " + this.LsUsername2_3.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_4.Text + " " + this.LsUsername2_4.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_5.Text + " " + this.LsUsername2_5.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_6.Text + " " + this.LsUsername2_6.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_7.Text + " " + this.LsUsername2_7.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_8.Text + " " + this.LsUsername2_8.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng2_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_9.Text + " " + this.LsUsername2_9.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_1.Text + " " + this.LsUsername3_1.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_10.Text + " " + this.LsUsername3_10.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_2.Text + " " + this.LsUsername3_2.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_3.Text + " " + this.LsUsername3_3.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_4.Text + " " + this.LsUsername3_4.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_5.Text + " " + this.LsUsername3_5.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_6.Text + " " + this.LsUsername3_6.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_7.Text + " " + this.LsUsername3_7.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_8.Text + " " + this.LsUsername3_8.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng3_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_9.Text + " " + this.LsUsername3_9.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_1.Text + " " + this.LsUsername4_1.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_10.Text + " " + this.LsUsername4_10.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_2.Text + " " + this.LsUsername4_2.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_3.Text + " " + this.LsUsername4_3.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_4.Text + " " + this.LsUsername4_4.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_5.Text + " " + this.LsUsername4_5.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_6.Text + " " + this.LsUsername4_6.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_7.Text + " " + this.LsUsername4_7.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_8.Text + " " + this.LsUsername4_8.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng4_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_9.Text + " " + this.LsUsername4_9.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_1.Text + " " + this.LsUsername5_1.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_10.Text + " " + this.LsUsername5_10.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_2.Text + " " + this.LsUsername5_2.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_3.Text + " " + this.LsUsername5_3.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_4.Text + " " + this.LsUsername5_4.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_5.Text + " " + this.LsUsername5_5.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_6.Text + " " + this.LsUsername5_6.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_7.Text + " " + this.LsUsername5_7.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_8.Text + " " + this.LsUsername5_8.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng5_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_9.Text + " " + this.LsUsername5_9.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_1.Text + " " + this.LsUsername6_1.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_10.Text + " " + this.LsUsername6_10.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_2.Text + " " + this.LsUsername6_2.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_3.Text + " " + this.LsUsername6_3.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_4.Text + " " + this.LsUsername6_4.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_5.Text + " " + this.LsUsername6_5.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_6.Text + " " + this.LsUsername6_6.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_7.Text + " " + this.LsUsername6_7.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_8.Text + " " + this.LsUsername6_8.Text + "";
            this.XkRicheng();
        }

        protected void Kecheng6_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_9.Text + " " + this.LsUsername6_9.Text + "";
            this.XkRicheng();
        }

        public void KechengBind()
        {
            string sql = "select * from qp_sch_Nianji where  NianjiMc='" + this.divsch.TypeCode("Nianji", "qp_sch_Banji", base.Request.QueryString["id"].ToString()) + "' and Xueqi='" + this.Xueqi.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2;
                if (this.Xueduan.SelectedValue == "上学期")
                {
                    str2 = "select id,Name  from qp_sch_Kecheng where id in (" + list["Kecheng"].ToString() + ") order by id asc";
                    this.list.Bind_DropDownList(this.Kecheng, str2, "id", "Name");
                }
                else
                {
                    str2 = "select id,Name  from qp_sch_Kecheng where id in (" + list["KechengX"].ToString() + ") order by id asc";
                    this.list.Bind_DropDownList(this.Kecheng, str2, "id", "Name");
                }
            }
            list.Close();
        }

        public void KechengInsert()
        {
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_1.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_1.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_1.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_1.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_1.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_1.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_1.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_1.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_1.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_1.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_1.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_1.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_1.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_1.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_1.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_1.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_1.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_1.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_1.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_1.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_1.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_1.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_1.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_1.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_2.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_2.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_2.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_2.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_2.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_2.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_2.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_2.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_2.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_2.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_2.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_2.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_2.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_2.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_2.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_2.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_2.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_2.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_2.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_2.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_2.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_2.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_2.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_2.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_3.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_3.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_3.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_3.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_3.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_3.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_3.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_3.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_3.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_3.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_3.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_3.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_3.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_3.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_3.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_3.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_3.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_3.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_3.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_3.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_3.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_3.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_3.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_3.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_4.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_4.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_4.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_4.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_4.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_4.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_4.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_4.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_4.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_4.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_4.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_4.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_4.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_4.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_4.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_4.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_4.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_4.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_4.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_4.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_4.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_4.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_4.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_4.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_5.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_5.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_5.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_5.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_5.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_5.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_5.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_5.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_5.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_5.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_5.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_5.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_5.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_5.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_5.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_5.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_5.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_5.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_5.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_5.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_5.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_5.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_5.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_5.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_6.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_6.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_6.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_6.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_6.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_6.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_6.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_6.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_6.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_6.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_6.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_6.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_6.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_6.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_6.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_6.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_6.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_6.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_6.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_6.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_6.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_6.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_6.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_6.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_7.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_7.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_7.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_7.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_7.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_7.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_7.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_7.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_7.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_7.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_7.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_7.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_7.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_7.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_7.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_7.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_7.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_7.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_7.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_7.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_7.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_7.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_7.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_7.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_8.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_8.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_8.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_8.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_8.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_8.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_8.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_8.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_8.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_8.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_8.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_8.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_8.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_8.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_8.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_8.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_8.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_8.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_8.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_8.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_8.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_8.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_8.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_8.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_9.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_9.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_9.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_9.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_9.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_9.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_9.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_9.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_9.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_9.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_9.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_9.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_9.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_9.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_9.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_9.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_9.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_9.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_9.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_9.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_9.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_9.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_9.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_9.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_10.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng1_10.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername1_10.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername1_10.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_10.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng2_10.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername2_10.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername2_10.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_10.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng3_10.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername3_10.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername3_10.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_10.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng4_10.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername4_10.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername4_10.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_10.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng5_10.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername5_10.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername5_10.Text = this.LsUsername.SelectedItem.Text;
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_10.CommandArgument = this.Kecheng.SelectedValue;
                this.Kecheng6_10.Text = this.Kecheng.SelectedItem.Text;
                this.LsUsername6_10.CommandArgument = this.LsUsername.SelectedValue;
                this.LsUsername6_10.Text = this.LsUsername.SelectedItem.Text;
            }
        }

        public void KechengUpdate()
        {
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_1.CommandArgument = "0";
                this.Kecheng1_1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_1.CommandArgument = "0";
                this.LsUsername1_1.Text = "";
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_1.CommandArgument = "0";
                this.Kecheng2_1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_1.CommandArgument = "0";
                this.LsUsername2_1.Text = "";
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_1.CommandArgument = "0";
                this.Kecheng3_1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_1.CommandArgument = "0";
                this.LsUsername3_1.Text = "";
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_1.CommandArgument = "0";
                this.Kecheng4_1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_1.CommandArgument = "0";
                this.LsUsername4_1.Text = "";
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_1.CommandArgument = "0";
                this.Kecheng5_1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_1.CommandArgument = "0";
                this.LsUsername5_1.Text = "";
            }
            if ((this.Jieci.Text == "1") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_1.CommandArgument = "0";
                this.Kecheng6_1.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_1.CommandArgument = "0";
                this.LsUsername6_1.Text = "";
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_2.CommandArgument = "0";
                this.Kecheng1_2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_2.CommandArgument = "0";
                this.LsUsername1_2.Text = "";
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_2.CommandArgument = "0";
                this.Kecheng2_2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_2.CommandArgument = "0";
                this.LsUsername2_2.Text = "";
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_2.CommandArgument = "0";
                this.Kecheng3_2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_2.CommandArgument = "0";
                this.LsUsername3_2.Text = "";
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_2.CommandArgument = "0";
                this.Kecheng4_2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_2.CommandArgument = "0";
                this.LsUsername4_2.Text = "";
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_2.CommandArgument = "0";
                this.Kecheng5_2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_2.CommandArgument = "0";
                this.LsUsername5_2.Text = "";
            }
            if ((this.Jieci.Text == "2") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_2.CommandArgument = "0";
                this.Kecheng6_2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_2.CommandArgument = "0";
                this.LsUsername6_2.Text = "";
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_3.CommandArgument = "0";
                this.Kecheng1_3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_3.CommandArgument = "0";
                this.LsUsername1_3.Text = "";
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_3.CommandArgument = "0";
                this.Kecheng2_3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_3.CommandArgument = "0";
                this.LsUsername2_3.Text = "";
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_3.CommandArgument = "0";
                this.Kecheng3_3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_3.CommandArgument = "0";
                this.LsUsername3_3.Text = "";
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_3.CommandArgument = "0";
                this.Kecheng4_3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_3.CommandArgument = "0";
                this.LsUsername4_3.Text = "";
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_3.CommandArgument = "0";
                this.Kecheng5_3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_3.CommandArgument = "0";
                this.LsUsername5_3.Text = "";
            }
            if ((this.Jieci.Text == "3") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_3.CommandArgument = "0";
                this.Kecheng6_3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_3.CommandArgument = "0";
                this.LsUsername6_3.Text = "";
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_4.CommandArgument = "0";
                this.Kecheng1_4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_4.CommandArgument = "0";
                this.LsUsername1_4.Text = "";
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_4.CommandArgument = "0";
                this.Kecheng2_4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_4.CommandArgument = "0";
                this.LsUsername2_4.Text = "";
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_4.CommandArgument = "0";
                this.Kecheng3_4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_4.CommandArgument = "0";
                this.LsUsername3_4.Text = "";
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_4.CommandArgument = "0";
                this.Kecheng4_4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_4.CommandArgument = "0";
                this.LsUsername4_4.Text = "";
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_4.CommandArgument = "0";
                this.Kecheng5_4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_4.CommandArgument = "0";
                this.LsUsername5_4.Text = "";
            }
            if ((this.Jieci.Text == "4") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_4.CommandArgument = "0";
                this.Kecheng6_4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_4.CommandArgument = "0";
                this.LsUsername6_4.Text = "";
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_5.CommandArgument = "0";
                this.Kecheng1_5.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_5.CommandArgument = "0";
                this.LsUsername1_5.Text = "";
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_5.CommandArgument = "0";
                this.Kecheng2_5.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_5.CommandArgument = "0";
                this.LsUsername2_5.Text = "";
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_5.CommandArgument = "0";
                this.Kecheng3_5.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_5.CommandArgument = "0";
                this.LsUsername3_5.Text = "";
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_5.CommandArgument = "0";
                this.Kecheng4_5.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_5.CommandArgument = "0";
                this.LsUsername4_5.Text = "";
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_5.CommandArgument = "0";
                this.Kecheng5_5.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_5.CommandArgument = "0";
                this.LsUsername5_5.Text = "";
            }
            if ((this.Jieci.Text == "5") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_5.CommandArgument = "0";
                this.Kecheng6_5.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_5.CommandArgument = "0";
                this.LsUsername6_5.Text = "";
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_6.CommandArgument = "0";
                this.Kecheng1_6.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_6.CommandArgument = "0";
                this.LsUsername1_6.Text = "";
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_6.CommandArgument = "0";
                this.Kecheng2_6.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_6.CommandArgument = "0";
                this.LsUsername2_6.Text = "";
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_6.CommandArgument = "0";
                this.Kecheng3_6.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_6.CommandArgument = "0";
                this.LsUsername3_6.Text = "";
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_6.CommandArgument = "0";
                this.Kecheng4_6.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_6.CommandArgument = "0";
                this.LsUsername4_6.Text = "";
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_6.CommandArgument = "0";
                this.Kecheng5_6.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_6.CommandArgument = "0";
                this.LsUsername5_6.Text = "";
            }
            if ((this.Jieci.Text == "6") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_6.CommandArgument = "0";
                this.Kecheng6_6.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_6.CommandArgument = "0";
                this.LsUsername6_6.Text = "";
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_7.CommandArgument = "0";
                this.Kecheng1_7.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_7.CommandArgument = "0";
                this.LsUsername1_7.Text = "";
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_7.CommandArgument = "0";
                this.Kecheng2_7.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_7.CommandArgument = "0";
                this.LsUsername2_7.Text = "";
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_7.CommandArgument = "0";
                this.Kecheng3_7.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_7.CommandArgument = "0";
                this.LsUsername3_7.Text = "";
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_7.CommandArgument = "0";
                this.Kecheng4_7.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_7.CommandArgument = "0";
                this.LsUsername4_7.Text = "";
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_7.CommandArgument = "0";
                this.Kecheng5_7.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_7.CommandArgument = "0";
                this.LsUsername5_7.Text = "";
            }
            if ((this.Jieci.Text == "7") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_7.CommandArgument = "0";
                this.Kecheng6_7.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_7.CommandArgument = "0";
                this.LsUsername6_7.Text = "";
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_8.CommandArgument = "0";
                this.Kecheng1_8.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_8.CommandArgument = "0";
                this.LsUsername1_8.Text = "";
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_8.CommandArgument = "0";
                this.Kecheng2_8.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_8.CommandArgument = "0";
                this.LsUsername2_8.Text = "";
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_8.CommandArgument = "0";
                this.Kecheng3_8.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_8.CommandArgument = "0";
                this.LsUsername3_8.Text = "";
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_8.CommandArgument = "0";
                this.Kecheng4_8.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_8.CommandArgument = "0";
                this.LsUsername4_8.Text = "";
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_8.CommandArgument = "0";
                this.Kecheng5_8.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_8.CommandArgument = "0";
                this.LsUsername5_8.Text = "";
            }
            if ((this.Jieci.Text == "8") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_8.CommandArgument = "0";
                this.Kecheng6_8.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_8.CommandArgument = "0";
                this.LsUsername6_8.Text = "";
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_9.CommandArgument = "0";
                this.Kecheng1_9.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_9.CommandArgument = "0";
                this.LsUsername1_9.Text = "";
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_9.CommandArgument = "0";
                this.Kecheng2_9.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_9.CommandArgument = "0";
                this.LsUsername2_9.Text = "";
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_9.CommandArgument = "0";
                this.Kecheng3_9.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_9.CommandArgument = "0";
                this.LsUsername3_9.Text = "";
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_9.CommandArgument = "0";
                this.Kecheng4_9.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_9.CommandArgument = "0";
                this.LsUsername4_9.Text = "";
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_9.CommandArgument = "0";
                this.Kecheng5_9.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_9.CommandArgument = "0";
                this.LsUsername5_9.Text = "";
            }
            if ((this.Jieci.Text == "9") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_9.CommandArgument = "0";
                this.Kecheng6_9.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_9.CommandArgument = "0";
                this.LsUsername6_9.Text = "";
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "1"))
            {
                this.Kecheng1_10.CommandArgument = "0";
                this.Kecheng1_10.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername1_10.CommandArgument = "0";
                this.LsUsername1_10.Text = "";
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "2"))
            {
                this.Kecheng2_10.CommandArgument = "0";
                this.Kecheng2_10.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername2_10.CommandArgument = "0";
                this.LsUsername2_10.Text = "";
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "3"))
            {
                this.Kecheng3_10.CommandArgument = "0";
                this.Kecheng3_10.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername3_10.CommandArgument = "0";
                this.LsUsername3_10.Text = "";
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "4"))
            {
                this.Kecheng4_10.CommandArgument = "0";
                this.Kecheng4_10.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername4_10.CommandArgument = "0";
                this.LsUsername4_10.Text = "";
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "5"))
            {
                this.Kecheng5_10.CommandArgument = "0";
                this.Kecheng5_10.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername5_10.CommandArgument = "0";
                this.LsUsername5_10.Text = "";
            }
            if ((this.Jieci.Text == "10") && (this.Xingqi.Text == "6"))
            {
                this.Kecheng6_10.CommandArgument = "0";
                this.Kecheng6_10.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                this.LsUsername6_10.CommandArgument = "0";
                this.LsUsername6_10.Text = "";
            }
        }

        protected void LsUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.XkRicheng();
        }

        protected void LsUsername1_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_1.Text + " " + this.LsUsername1_1.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_10.Text + " " + this.LsUsername1_10.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_2.Text + " " + this.LsUsername1_2.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_3.Text + " " + this.LsUsername1_3.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_4.Text + " " + this.LsUsername1_4.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_5.Text + " " + this.LsUsername1_5.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_6.Text + " " + this.LsUsername1_6.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_7.Text + " " + this.LsUsername1_7.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_8.Text + " " + this.LsUsername1_8.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername1_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期一，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "1";
            this.Label5.Text = "  " + this.Kecheng1_9.Text + " " + this.LsUsername1_9.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_1.Text + " " + this.LsUsername2_1.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_10.Text + " " + this.LsUsername2_10.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_2.Text + " " + this.LsUsername2_2.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_3.Text + " " + this.LsUsername2_3.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_4.Text + " " + this.LsUsername2_4.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_5.Text + " " + this.LsUsername2_5.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_6.Text + " " + this.LsUsername2_6.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_7.Text + " " + this.LsUsername2_7.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_8.Text + " " + this.LsUsername2_8.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername2_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期二，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "2";
            this.Label5.Text = "  " + this.Kecheng2_9.Text + " " + this.LsUsername2_9.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_1.Text + " " + this.LsUsername3_1.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_10.Text + " " + this.LsUsername3_10.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_2.Text + " " + this.LsUsername3_2.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_3.Text + " " + this.LsUsername3_3.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_4.Text + " " + this.LsUsername3_4.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_5.Text + " " + this.LsUsername3_5.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_6.Text + " " + this.LsUsername3_6.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_7.Text + " " + this.LsUsername3_7.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_8.Text + " " + this.LsUsername3_8.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername3_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期三，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "3";
            this.Label5.Text = "  " + this.Kecheng3_9.Text + " " + this.LsUsername3_9.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_1.Text + " " + this.LsUsername4_1.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_10.Text + " " + this.LsUsername4_10.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_2.Text + " " + this.LsUsername4_2.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_3.Text + " " + this.LsUsername4_3.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_4.Text + " " + this.LsUsername4_4.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_5.Text + " " + this.LsUsername4_5.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_6.Text + " " + this.LsUsername4_6.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_7.Text + " " + this.LsUsername4_7.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_8.Text + " " + this.LsUsername4_8.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername4_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期四，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "4";
            this.Label5.Text = "  " + this.Kecheng4_9.Text + " " + this.LsUsername4_9.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_1.Text + " " + this.LsUsername5_1.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_10.Text + " " + this.LsUsername5_10.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_2.Text + " " + this.LsUsername5_2.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_3.Text + " " + this.LsUsername5_3.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_4.Text + " " + this.LsUsername5_4.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_5.Text + " " + this.LsUsername5_5.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_6.Text + " " + this.LsUsername5_6.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_7.Text + " " + this.LsUsername5_7.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_8.Text + " " + this.LsUsername5_8.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername5_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期五，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "5";
            this.Label5.Text = "  " + this.Kecheng5_9.Text + " " + this.LsUsername5_9.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_1_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第一节";
            this.Jieci.Text = "1";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_1.Text + " " + this.LsUsername6_1.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_10_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第十节";
            this.Jieci.Text = "10";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_10.Text + " " + this.LsUsername6_10.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_2_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第二节";
            this.Jieci.Text = "2";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_2.Text + " " + this.LsUsername6_2.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_3_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第三节";
            this.Jieci.Text = "3";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_3.Text + " " + this.LsUsername6_3.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_4_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第四节";
            this.Jieci.Text = "4";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_4.Text + " " + this.LsUsername6_4.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_5_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第五节";
            this.Jieci.Text = "5";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_5.Text + " " + this.LsUsername6_5.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_6_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第六节";
            this.Jieci.Text = "6";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_6.Text + " " + this.LsUsername6_6.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_7_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第七节";
            this.Jieci.Text = "7";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_7.Text + " " + this.LsUsername6_7.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_8_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第八节";
            this.Jieci.Text = "8";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_8.Text + " " + this.LsUsername6_8.Text + "";
            this.XkRicheng();
        }

        protected void LsUsername6_9_Click(object sender, EventArgs e)
        {
            this.Label3.Text = "星期六，第九节";
            this.Jieci.Text = "9";
            this.Xingqi.Text = "6";
            this.Label5.Text = "  " + this.Kecheng6_9.Text + " " + this.LsUsername6_9.Text + "";
            this.XkRicheng();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button4.Attributes["onclick"] = "javascript:return chknull();";
                this.Button1.Attributes["onclick"] = "javascript:return yichu();";
                this.Button5.Attributes["onclick"] = "javascript:return ycquanbu();";
                this.Button3.Attributes["onclick"] = "javascript:return Daoru();";
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
                        string str2 = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                        this.list.Bind_DropDownList_nothing(this.DrXueqi, str2, "Mingcheng", "Mingcheng");
                        this.DrXueqi.SelectedValue = this.Xueqi.SelectedValue;
                        this.DrXueduan.SelectedValue = this.Xueduan.SelectedValue;
                        string str3 = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  Xueqi='" + this.Xueqi.SelectedValue + "' order by Num asc";
                        this.list.Bind_DropDownList_nothing(this.DrNianji, str3, "NianjiMc", "NianjiMc");
                        string str4 = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   Xueqi='" + this.Xueqi.SelectedValue + "' and Nianji='" + this.DrNianji.SelectedValue + "' order by Num asc";
                        this.list.Bind_DropDownList_nothing(this.DrBanji, str4, "id", "Mingcheng");
                        this.KechengBind();
                        this.CheckBoxBind();
                        if (this.Kecheng.SelectedValue != "请选择")
                        {
                            string sql = "select RkUsername from qp_sch_Kecheng where  id='" + this.Kecheng.SelectedValue + "'";
                            SqlDataReader list = this.List.GetList(sql);
                            if (list.Read())
                            {
                                string str6 = "select Username,Realname from [qp_oa_Username]  where   '%" + list["RkUsername"].ToString() + "%' like '%'+Username+'%' and  ifdel='0' order by paixu asc";
                                this.list.Bind_DropDownList(this.LsUsername, str6, "Username", "Realname");
                            }
                            list.Close();
                        }
                        this.XkRicheng();
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

        public void XkRicheng()
        {
            if ((this.LsUsername.SelectedValue != "请选择") && (this.Kecheng.SelectedValue != "请选择"))
            {
                object obj2;
                int num = 0;
                this.Label6.Text = "";
                string text = this.Label6.Text;
                this.Label6.Text = text + "<tr><td colspan=\"4\" align=\"center\" bgcolor=\"#cbf1c7\">【<font color=red><b>" + this.LsUsername.SelectedItem.Text + "</b></font>】星期" + this.Xingqi.Text + "  第" + this.Jieci.Text + "节 行课冲突提醒</td></tr>";
                this.Label6.Text = this.Label6.Text + "<tr><td style=\"line-height: 190%\">";
                string sql = "select * from qp_sch_KechengBiao where  Banji!='" + base.Request.QueryString["id"] + "' and Jieci='" + this.Jieci.Text + "' and Xingqi='" + this.Xingqi.Text + "' and LsUsername='" + this.LsUsername.SelectedValue + "' and Xueqi='" + this.Xueqi.SelectedValue + "' and Xueduan='" + this.Xueduan.SelectedValue + "'";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    num++;
                    obj2 = this.Label6.Text;
                    this.Label6.Text = string.Concat(new object[] { obj2, "", num, ".在【", this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", list["Banji"].ToString()), "】星期", list["Xingqi"], " 第", list["Jieci"], "节  存在重复数据<br>" });
                }
                list.Close();
                this.Label6.Text = this.Label6.Text + "</td></tr>";
                this.Label2.Text = "【<b><font color=red>" + this.LsUsername.SelectedItem.Text + "</font></b>】" + this.Xueqi.SelectedValue + " " + this.Xueduan.SelectedValue + " 行课日程";
                this.Label4.Text = "";
                int num2 = 0;
                string str2 = "select * from qp_sch_KechengBiao where  Xueqi='" + this.Xueqi.SelectedValue + "' and Xueduan='" + this.Xueduan.SelectedValue + "' and LsUsername='" + this.LsUsername.SelectedValue + "' order by Xingqi asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    num2++;
                    obj2 = this.Label4.Text;
                    this.Label4.Text = string.Concat(new object[] { obj2, "", num2, ".【", this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", reader2["Banji"].ToString()), "】星期", reader2["Xingqi"], " 第", reader2["Jieci"], "节 <br>" });
                }
                reader2.Close();
            }
        }
    }
}


namespace xyoa.SystemManage.Juese
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Juese_qx : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label remark;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ViewState["s_quanbu"] = string.Empty;
            this.ViewState["s_xinzeng"] = string.Empty;
            this.ViewState["s_chakan"] = string.Empty;
            this.ViewState["s_xiugai"] = string.Empty;
            this.ViewState["s_shanchu"] = string.Empty;
            this.ViewState["s_daochu"] = string.Empty;
            this.ViewState["s_shenpi"] = string.Empty;
            this.ViewState["s_chaxun"] = string.Empty;
            this.ViewState["s_shouquan"] = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                StateBag bag = ViewState;
                object obj2;
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("chaxun");
                Label label = (Label) row.FindControl("chaxunid");
                CheckBox box2 = (CheckBox) row.FindControl("quanbu");
                Label label2 = (Label) row.FindControl("quanbuid");
                CheckBox box3 = (CheckBox) row.FindControl("xinzeng");
                Label label3 = (Label) row.FindControl("xinzengid");
                CheckBox box4 = (CheckBox) row.FindControl("chakan");
                Label label4 = (Label) row.FindControl("chakanid");
                CheckBox box5 = (CheckBox) row.FindControl("xiguai");
                Label label5 = (Label) row.FindControl("xiguaiid");
                CheckBox box6 = (CheckBox) row.FindControl("shanchu");
                Label label6 = (Label) row.FindControl("shanchuid");
                CheckBox box7 = (CheckBox) row.FindControl("daochu");
                Label label7 = (Label) row.FindControl("daochuid");
                CheckBox box8 = (CheckBox) row.FindControl("shenpi");
                Label label8 = (Label) row.FindControl("shenpiid");
                CheckBox box9 = (CheckBox) row.FindControl("shouquan");
                Label label9 = (Label) row.FindControl("shouquanid");
                if (box.Checked)
                {
                    obj2 = bag["s_chaxun"];
                    (bag = this.ViewState)["s_chaxun"] = string.Concat(new object[] { obj2, "|", label.Text, "" });
                }
                if (box2.Checked)
                {
                    obj2 = bag["s_quanbu"];
                    (bag = this.ViewState)["s_quanbu"] = string.Concat(new object[] { obj2, "|", label2.Text, "" });
                }
                if (box3.Checked)
                {
                    obj2 = bag["s_xinzeng"];
                    (bag = this.ViewState)["s_xinzeng"] = string.Concat(new object[] { obj2, "|", label3.Text, "" });
                }
                if (box4.Checked)
                {
                    obj2 = bag["s_chakan"];
                    (bag = this.ViewState)["s_chakan"] = string.Concat(new object[] { obj2, "|", label4.Text, "" });
                }
                if (box5.Checked)
                {
                    obj2 = bag["s_xiugai"];
                    (bag = this.ViewState)["s_xiugai"] = string.Concat(new object[] { obj2, "|", label5.Text, "" });
                }
                if (box6.Checked)
                {
                    obj2 = bag["s_shanchu"];
                    (bag = this.ViewState)["s_shanchu"] = string.Concat(new object[] { obj2, "|", label6.Text, "" });
                }
                if (box7.Checked)
                {
                    obj2 = bag["s_daochu"];
                    (bag = this.ViewState)["s_daochu"] = string.Concat(new object[] { obj2, "|", label7.Text, "" });
                }
                if (box8.Checked)
                {
                    obj2 = bag["s_shenpi"];
                    (bag = this.ViewState)["s_shenpi"] = string.Concat(new object[] { obj2, "|", label8.Text, "" });
                }
                if (box9.Checked)
                {
                    obj2 = bag["s_shouquan"];
                    (bag = this.ViewState)["s_shouquan"] = string.Concat(new object[] { obj2, "|", label9.Text, "" });
                }
            }
            string str = string.Empty;
            str = this.ViewState["s_quanbu"].ToString() + this.ViewState["s_xinzeng"].ToString() + this.ViewState["s_chakan"].ToString() + this.ViewState["s_xiugai"].ToString() + this.ViewState["s_shanchu"].ToString() + this.ViewState["s_daochu"].ToString() + this.ViewState["s_shenpi"].ToString() + this.ViewState["s_shouquan"].ToString() + this.ViewState["s_chaxun"].ToString();
            string sql = string.Concat(new object[] { "Update qp_oa_Juese  Set Perstr='", str, "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            if (this.CheckBox1.Checked)
            {
                string str3 = string.Concat(new object[] { "Update qp_oa_username  Set ResponQx='", str, "' where JueseId='", int.Parse(base.Request.QueryString["id"]), "' and IfResponUpdate='1'" });
                this.List.ExeSql(str3);
            }
            this.pulicss.InsertLog("设置角色权限[" + this.Name.Text + "]", "角色管理");
            base.Response.Write("<script language=javascript>alert('提交成功，您设置的角色，需要重新登陆后才能生效！');window.location.href='Juese.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Juese.aspx");
        }

        public void DataBindToGridview()
        {
            string str;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
          //  if (this.Session["baben"].ToString() == "4")
            {
                str = "select * from qp_oa_ResponQx where ifopen='1' and leixing in (" + ConfigurationManager.AppSettings["addurl"].ToString() + ") order by paixu asc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
         //   if (this.Session["baben"].ToString() == "5")
            {
         //       str = "select * from qp_oa_ResponQx where ifopen='1' and leixing in (" + this.Session["mokuai"].ToString() + ") order by paixu asc";
          //      this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
          //      this.GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("chaxun");
                Label label = (Label) row.FindControl("chaxunid");
                CheckBox box2 = (CheckBox) row.FindControl("quanbu");
                Label label2 = (Label) row.FindControl("quanbuid");
                CheckBox box3 = (CheckBox) row.FindControl("xinzeng");
                Label label3 = (Label) row.FindControl("xinzengid");
                CheckBox box4 = (CheckBox) row.FindControl("chakan");
                Label label4 = (Label) row.FindControl("chakanid");
                CheckBox box5 = (CheckBox) row.FindControl("xiguai");
                Label label5 = (Label) row.FindControl("xiguaiid");
                CheckBox box6 = (CheckBox) row.FindControl("shanchu");
                Label label6 = (Label) row.FindControl("shanchuid");
                CheckBox box7 = (CheckBox) row.FindControl("daochu");
                Label label7 = (Label) row.FindControl("daochuid");
                CheckBox box8 = (CheckBox) row.FindControl("shenpi");
                Label label8 = (Label) row.FindControl("shenpiid");
                CheckBox box9 = (CheckBox) row.FindControl("shouquan");
                Label label9 = (Label) row.FindControl("shouquanid");
                if (label.Text == "0")
                {
                    box.Visible = false;
                }
                else
                {
                    box.Visible = true;
                }
                if (label2.Text == "0")
                {
                    box2.Visible = false;
                }
                else
                {
                    box2.Visible = true;
                }
                if (label3.Text == "0")
                {
                    box3.Visible = false;
                }
                else
                {
                    box3.Visible = true;
                }
                if (label4.Text == "0")
                {
                    box4.Visible = false;
                }
                else
                {
                    box4.Visible = true;
                }
                if (label5.Text == "0")
                {
                    box5.Visible = false;
                }
                else
                {
                    box5.Visible = true;
                }
                if (label6.Text == "0")
                {
                    box6.Visible = false;
                }
                else
                {
                    box6.Visible = true;
                }
                if (label7.Text == "0")
                {
                    box7.Visible = false;
                }
                else
                {
                    box7.Visible = true;
                }
                if (label8.Text == "0")
                {
                    box8.Visible = false;
                }
                else
                {
                    box8.Visible = true;
                }
                if (label9.Text == "0")
                {
                    box9.Visible = false;
                }
                else
                {
                    box9.Visible = true;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                this.DataBindToGridview();
                string sql = "select * from qp_oa_Juese  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["name"].ToString();
                    this.remark.Text = list["remark"].ToString();
                    this.ViewState["PerSessionStr"] = list["Perstr"].ToString();
                }
                list.Close();
                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    GridViewRow row = this.GridView1.Rows[i];
                    CheckBox box = (CheckBox) row.FindControl("chaxun");
                    Label label = (Label) row.FindControl("chaxunid");
                    CheckBox box2 = (CheckBox) row.FindControl("quanbu");
                    Label label2 = (Label) row.FindControl("quanbuid");
                    CheckBox box3 = (CheckBox) row.FindControl("xinzeng");
                    Label label3 = (Label) row.FindControl("xinzengid");
                    CheckBox box4 = (CheckBox) row.FindControl("chakan");
                    Label label4 = (Label) row.FindControl("chakanid");
                    CheckBox box5 = (CheckBox) row.FindControl("xiguai");
                    Label label5 = (Label) row.FindControl("xiguaiid");
                    CheckBox box6 = (CheckBox) row.FindControl("shanchu");
                    Label label6 = (Label) row.FindControl("shanchuid");
                    CheckBox box7 = (CheckBox) row.FindControl("daochu");
                    Label label7 = (Label) row.FindControl("daochuid");
                    CheckBox box8 = (CheckBox) row.FindControl("shenpi");
                    Label label8 = (Label) row.FindControl("shenpiid");
                    CheckBox box9 = (CheckBox) row.FindControl("shouquan");
                    Label label9 = (Label) row.FindControl("shouquanid");
                    if (this.pulicss.StrIFInStr(label2.Text, this.ViewState["PerSessionStr"].ToString()) && (label2.Text != "0"))
                    {
                        box2.Checked = true;
                    }
                    if (this.pulicss.StrIFInStr(label3.Text, this.ViewState["PerSessionStr"].ToString()) && (label3.Text != "0"))
                    {
                        box3.Checked = true;
                    }
                    if (this.pulicss.StrIFInStr(label4.Text, this.ViewState["PerSessionStr"].ToString()) && (label4.Text != "0"))
                    {
                        box4.Checked = true;
                    }
                    if (this.pulicss.StrIFInStr(label5.Text, this.ViewState["PerSessionStr"].ToString()) && (label5.Text != "0"))
                    {
                        box5.Checked = true;
                    }
                    if (this.pulicss.StrIFInStr(label6.Text, this.ViewState["PerSessionStr"].ToString()) && (label6.Text != "0"))
                    {
                        box6.Checked = true;
                    }
                    if (this.pulicss.StrIFInStr(label7.Text, this.ViewState["PerSessionStr"].ToString()) && (label7.Text != "0"))
                    {
                        box7.Checked = true;
                    }
                    if (this.pulicss.StrIFInStr(label8.Text, this.ViewState["PerSessionStr"].ToString()) && (label8.Text != "0"))
                    {
                        box8.Checked = true;
                    }
                    if (this.pulicss.StrIFInStr(label9.Text, this.ViewState["PerSessionStr"].ToString()) && (label9.Text != "0"))
                    {
                        box9.Checked = true;
                    }
                    if (this.pulicss.StrIFInStr(label.Text, this.ViewState["PerSessionStr"].ToString()) && (label.Text != "0"))
                    {
                        box.Checked = true;
                    }
                }
            }
        }
    }
}


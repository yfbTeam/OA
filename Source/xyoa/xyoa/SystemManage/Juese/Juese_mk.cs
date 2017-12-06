namespace xyoa.SystemManage.Juese
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Juese_mk : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        private void BanmianGet()
        {
            this.ViewState["bmstr1"] = "";
            this.ViewState["bmstr2"] = "";
            this.ViewState["bmstr3"] = "";
            this.ViewState["bmstr4"] = "";
            this.ViewState["bmstr5"] = "";
            string sql = "select Banmian1 from qp_oa_Juese  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["bmstr1"] = list["Banmian1"].ToString();
            }
            list.Close();
            string str2 = "select Banmian2 from qp_oa_Juese  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader reader2 = this.List.GetList(str2);
            if (reader2.Read())
            {
                this.ViewState["bmstr2"] = reader2["Banmian2"].ToString();
            }
            reader2.Close();
            string str3 = "select Banmian3 from qp_oa_Juese  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader reader3 = this.List.GetList(str3);
            if (reader3.Read())
            {
                this.ViewState["bmstr3"] = reader3["Banmian3"].ToString();
            }
            reader3.Close();
            string str4 = "select Banmian4 from qp_oa_Juese  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader reader4 = this.List.GetList(str4);
            if (reader4.Read())
            {
                this.ViewState["bmstr4"] = reader4["Banmian4"].ToString();
            }
            reader4.Close();
            string str5 = "select Banmian5 from qp_oa_Juese  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader reader5 = this.List.GetList(str5);
            if (reader5.Read())
            {
                this.ViewState["bmstr5"] = reader5["Banmian5"].ToString();
            }
            reader5.Close();
            this.ViewState["bmstr_other"] = this.ViewState["bmstr2"].ToString() + this.ViewState["bmstr3"].ToString() + this.ViewState["bmstr4"].ToString() + this.ViewState["bmstr5"].ToString();
            this.DataBindToGridview();
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("quanbu");
                Label label = (Label) row.FindControl("quanbuid");
                Label label2 = (Label) row.FindControl("ParentNodesID");
                if (this.pulicss.StrIFInStr("," + label.Text + ",", "," + this.ViewState["bmstr1"].ToString() + ",") && (label2.Text != "0"))
                {
                    box.Checked = true;
                }
            }
        }

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ViewState["s_id"] = "";
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("quanbu");
                Label label = (Label) row.FindControl("quanbuid");
                if (box.Checked)
                {
                    StateBag bag = ViewState;
                    object obj2 = bag["s_id"];
                    (bag = this.ViewState)["s_id"] = string.Concat(new object[] { obj2, "", label.Text, "," });
                }
            }
            string sql = string.Concat(new object[] { "Update qp_oa_Juese   Set Banmian1='", this.ViewState["s_id"].ToString(), "'   where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改角色", "角色管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Juese_mk1.aspx?id=" + int.Parse(base.Request.QueryString["id"]) + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Juese.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "select Banmian1 from qp_oa_Juese  where id='" + this.JueseId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "Update qp_oa_Juese   Set Banmian1='", list["Banmian1"].ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str2);
                this.pulicss.InsertLog("克隆角色", "角色管理");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Juese_mk1.aspx?id=" + int.Parse(base.Request.QueryString["id"]) + "'</script>");
            }
            list.Close();
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select id,ParentNodesID,urlname from qp_oa_AllUrl where (xianshi='1' or ParentNodesID='0') and urlname!='门户中心' and urlname!='扩展应用'  order by paixu asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("ParentNodesID");
                Label label2 = (Label) e.Row.FindControl("Label1");
                CheckBox box = (CheckBox) e.Row.FindControl("quanbu");
                Label label3 = (Label) e.Row.FindControl("quanbuid");
                if (label.Text == "0")
                {
                    box.Visible = false;
                    label2.Text = "<hr color=red>";
                }
                else
                {
                    box.Visible = true;
                    label2.Text = "";
                    string str = "," + this.ViewState["bmstr_other"].ToString() + ",";
                    string str2 = "," + label3.Text + ",";
                    if (str.IndexOf(str2) < 0)
                    {
                        box.Enabled = true;
                    }
                    else
                    {
                        box.Enabled = false;
                        label2.Text = "   <font color=red>其他版面已设置</font>";
                    }
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
                this.BanmianGet();
                string sQL = "select id,name  from qp_oa_Juese where id!='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' order by id asc";
                this.list.Bind_DropDownList_nothing(this.JueseId, sQL, "id", "name");
            }
        }
    }
}


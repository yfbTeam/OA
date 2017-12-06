namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyMenu : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("quanbu");
                Label label = (Label) row.FindControl("quanbuid");
                if (box.Checked)
                {
                    str = str + "|" + label.Text + "";
                }
            }
            string str2 = string.Empty;
            str2 = str;
            string sql = string.Concat(new object[] { "Update qp_oa_Menu  Set content='", str2, "' where username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置我的快捷菜单", "我的快捷菜单");
            base.Response.Write("<script language=javascript>alert('提交成功');</script>");
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select * from qp_oa_MenuQx where CHARINDEX(quanbu,'" + this.Session["perstr"] + "') > 0 and ifopen='1' order by paixu asc";
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
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("quanbu");
                Label label = (Label) row.FindControl("quanbuid");
                if ((((label.Text == "iiii") || (label.Text == "hhhh")) || ((label.Text == "jjjj") || (label.Text == "aaaa"))) || (label.Text == "kkkk"))
                {
                    box.Visible = false;
                }
                else
                {
                    box.Visible = true;
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
                string sql = "select * from qp_oa_Menu   where Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["PerSessionStr"] = list["content"].ToString();
                }
                list.Close();
                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    GridViewRow row = this.GridView1.Rows[i];
                    CheckBox box = (CheckBox) row.FindControl("quanbu");
                    Label label = (Label) row.FindControl("quanbuid");
                    if ((((this.pulicss.StrIFInStr(label.Text, this.ViewState["PerSessionStr"].ToString()) && (label.Text != "iiii")) && ((label.Text != "hhhh") && (label.Text != "jjjj"))) && (label.Text != "aaaa")) && (label.Text != "kkkk"))
                    {
                        box.Checked = true;
                    }
                }
            }
        }
    }
}


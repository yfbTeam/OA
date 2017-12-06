namespace xyoa.SystemManage.anquan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class admin : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox mima;
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.mima.Text == "13002355133")
            {
                if (this.GridView1.Rows.Count > 0)
                {
                    foreach (GridViewRow row in this.GridView1.Rows)
                    {
                        string text = "";
                        text = ((Label) row.FindControl("Lid")).Text;
                        string str2 = "";
                        if (((CheckBox) row.FindControl("quanbu")).Checked)
                        {
                            str2 = "1";
                        }
                        else
                        {
                            str2 = "0";
                        }
                        string sql = "Update qp_oa_ResponQx   Set ifopen='" + str2 + "' where id='" + text + "'";
                        this.List.ExeSql(sql);
                    }
                }
                base.Response.Write("<script language=javascript>alert('提交成功，您设置显示模块以后，需要重新设置各角色的权限才能生效，在用户设置各角色权限的时候将会屏蔽掉设置未使用的模块！');window.location.href='admin.aspx'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('密码错误！');window.location.href='admin.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("/default.aspx");
        }

        public void DataBindToGridview()
        {
            string sql = "select * from qp_oa_ResponQx  order by paixu asc";
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
                Label label = (Label) e.Row.FindControl("quanbuid");
                if (label.Text == "True")
                {
                    ((CheckBox) e.Row.FindControl("quanbu")).Checked = true;
                }
                if (label.Text == "False")
                {
                    ((CheckBox) e.Row.FindControl("quanbu")).Checked = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                this.DataBindToGridview();
            }
        }
    }
}


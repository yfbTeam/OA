namespace xyoa.InfoManage.toupiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class toupiaobt_add_next : Page
    {
        protected Button AddData;
        protected Button Button2;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;

        public void BindAttribute()
        {
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
        }

        public void Bindquanxian()
        {
            this.AddData.Attributes["onclick"] = "javascript:return AddJFJH(" + base.Request.QueryString["bigid"] + ");";
            this.pulicss.QuanXianVis(this.AddData, "aaaa6b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.GridView1, "aaaa6b", this.Session["perstr"].ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("toupiaobt.aspx");
        }

        public void DataBindToGridview(string Sqlsort)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select * from qp_oa_toupiao  where bigId='" + base.Request.QueryString["bigid"] + "' " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DelAdd")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "Delete from qp_oa_toupiao where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview(this.SortText.Value);
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("ChaKan");
                button.Attributes.Add("onclick", "javascript:ShowLxr1(" + button.CommandArgument + ")");
                LinkButton button2 = (LinkButton) e.Row.FindControl("DelAdd");
                button2.Attributes.Add("onclick", "javascript:return confirm('确认删除此选项吗？')");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.DataBindToGridview(this.SortText.Value);
                if (!this.Page.IsPostBack)
                {
                    this.BindAttribute();
                    this.Bindquanxian();
                    string sql = "select title from qp_oa_toupiaobt where id='" + base.Request.QueryString["bigid"] + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.ViewState["title"] = list["title"].ToString();
                    }
                    list.Close();
                }
            }
        }
    }
}


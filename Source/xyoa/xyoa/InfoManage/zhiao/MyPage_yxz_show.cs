namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPage_yxz_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected Label cishu;
        public string Contents;
        public string fjkey;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label LeibieName;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label RealnameXz;
        protected Label Settimes;
        protected TextBox taolun;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyPage_yxz.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('11','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='11'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='11' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.DataBindToGridview();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "Delete from qp_oa_Taolun where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                Label label = (Label) e.Row.FindControl("FTUsername");
                if ((label.Text == this.Session["username"].ToString()) || (this.Session["username"].ToString() == "admin"))
                {
                    button.Visible = true;
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除此条讨论信息吗？')");
                }
                else
                {
                    button.Visible = false;
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
                string sql = string.Concat(new object[] { "select * from qp_oa_Zst_ziliao  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and CHARINDEX(',", this.Session["username"], ",',','+UsernameXz+',')   >0 " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Settimes.Text = list["Settimes"].ToString();
                    this.RealnameXz.Text = list["RealnameXz"].ToString();
                    this.LeibieName.Text = this.pulicss.TypeCode("qp_oa_Zst_leibie_zl", list["Leibie"].ToString());
                    this.Name.Text = list["Name"].ToString();
                    this.ViewState["Filetype"] = list["Filetype"].ToString();
                    this.ViewState["NewNames"] = list["NewName"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.cishu.Text = list["cishu"].ToString();
                }
                list.Close();
                this.DataBindToGridview();
                this.Button2.Attributes["onclick"] = "javascript:return chknull();";
            }
        }
    }
}


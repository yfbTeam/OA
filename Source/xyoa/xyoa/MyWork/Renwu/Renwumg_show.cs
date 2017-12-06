namespace xyoa.MyWork.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Renwumg_show : Page
    {
        protected Button Button2;
        protected Button Button4;
        protected CheckBox CheckBox1;
        protected Label Content;
        protected Label Endtime;
        protected HtmlForm form1;
        protected Label fujian;
        protected GridView GridView1;
        protected Label HbDay;
        protected HtmlHead Head1;
        protected Label JbRealname;
        protected TextBox JbUsername;
        protected Label Jkrealname;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Starttime;
        protected TextBox taolun;
        protected Label titles;
        protected Label ZbRealname;
        protected TextBox ZbUsername;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('5','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Renwumg.aspx");
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='5'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='5' order by id desc";
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
                string sql = "select * from qp_oa_Renwu  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.titles.Text = list["titles"].ToString();
                    this.Starttime.Text = DateTime.Parse(list["Starttime"].ToString()).ToShortDateString();
                    this.Endtime.Text = DateTime.Parse(list["Endtime"].ToString()).ToShortDateString();
                    this.ZbUsername.Text = list["ZbUsername"].ToString();
                    this.ZbRealname.Text = list["ZbRealname"].ToString();
                    this.JbUsername.Text = list["JbUsername"].ToString();
                    this.JbRealname.Text = list["JbRealname"].ToString();
                    this.HbDay.Text = list["HbDay"].ToString();
                    this.Content.Text = list["Content"].ToString();
                    this.Jkrealname.Text = list["Jkrealname"].ToString();
                }
                list.Close();
                this.DataBindToGridview();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                this.pulicss.InsertLog("查看任务", "任务监控");
            }
        }
    }
}


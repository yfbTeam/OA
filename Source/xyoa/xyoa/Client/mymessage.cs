namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class mymessage : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void DataBindToGridview(string Sqlsort)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select  top 30 id,titles,itimes,acceptusername,acceptrealname,sfck,sendusername,sendrealname  from qp_oa_Messages  where  acceptusername='" + this.Session["username"] + "' and tablekey='1' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label1");
                Label label3 = (Label) e.Row.FindControl("Label2");
                string sql = "select  id,titles,itimes,acceptusername,acceptrealname,sfck,url  from qp_oa_Messages  where id='" + label.Text + "' and tablekey='1'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["sfck"].ToString() == "True")
                    {
                        label2.Text = "";
                    }
                    else
                    {
                        label2.Text = "<a href=\"messagedel.aspx?yyid=" + list["id"].ToString() + "&user=" + base.Request.QueryString["user"].ToString() + "&pwd=" + base.Request.QueryString["pwd"].ToString() + "\">已阅</a>&nbsp;";
                    }
                    if (list["url"].ToString() == "#")
                    {
                        label3.Text = "";
                    }
                    else
                    {
                        label3.Text = "<a href=\"urlcheck.aspx?url=" + list["url"].ToString() + "&user=" + base.Request.QueryString["user"].ToString() + "&pwd=" + base.Request.QueryString["pwd"].ToString() + "\" target='_blank'>链接</a>&nbsp;";
                    }
                }
                list.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Session["yangshi"] = this.pulicss.Getyangshi();
                string str = FormsAuthentication.HashPasswordForStoringInConfigFile(base.Request.QueryString["pwd"].ToString(), "MD5");
                string sql = "select Username,ResponQx from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "' and Password='" + str + "'and Iflogin='1'";
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    base.Response.Redirect("LoginMsg.aspx");
                }
                else
                {
                    list.Close();
                    this.Session["username"] = base.Request.QueryString["user"];
                    this.DataBindToGridview("order by id desc");
                }
            }
        }
    }
}


namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class mymessageold : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void DataBindToGridview(string Sqlsort)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select   id,titles,itimes,acceptusername,acceptrealname,sfck,sendusername,sendrealname  from qp_oa_Messages  where  acceptusername='" + this.Session["username"] + "' and sfck='1' and tablekey='1' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label2");
                string sql = "select  id,titles,itimes,acceptusername,acceptrealname,sfck,url  from qp_oa_Messages  where id='" + label.Text + "' and tablekey='1'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["url"].ToString() == "#")
                    {
                        label2.Text = "";
                    }
                    else
                    {
                        label2.Text = string.Concat(new object[] { "<a href=\"urlcheck.aspx?url=", list["url"].ToString(), "&user=", this.Session["username"], "&pwd=", base.Request.QueryString["pwd"].ToString(), "\" target='_blank'>链接</a>&nbsp;" });
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
                if (this.Session["username"] == null)
                {
                    base.Response.Redirect("/");
                }
                else
                {
                    this.DataBindToGridview("order by id desc");
                }
            }
        }
    }
}


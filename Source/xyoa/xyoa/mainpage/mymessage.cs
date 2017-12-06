namespace xyoa.mainpage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
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
            string str;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            if (base.Request.QueryString["type"] != null)
            {
                if (base.Request.QueryString["type"].ToString() == "2")
                {
                    str = "select  top 30 *  from qp_oa_Messages  where  acceptusername='" + this.Session["username"] + "' and tablekey='1' order by id desc";
                    this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                    this.GridView1.DataBind();
                }
                else
                {
                    str = "select  top 30 *  from qp_oa_Messages  where  sfck='0' and acceptusername='" + this.Session["username"] + "' and tablekey='1' order by id desc";
                    this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                    this.GridView1.DataBind();
                }
            }
            else
            {
                str = "select  top 30 *  from qp_oa_Messages  where  acceptusername='" + this.Session["username"] + "' and tablekey='1' order by id desc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label1");
                Label label3 = (Label) e.Row.FindControl("Label2");
                Label label4 = (Label) e.Row.FindControl("Label3");
                string sql = "select  id,titles,itimes,acceptusername,acceptrealname,sfck,url,number  from qp_oa_Messages  where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["sfck"].ToString() == "True")
                    {
                        label2.Text = "";
                    }
                    else
                    {
                        label2.Text = "<a href=\"mymessagedel.aspx?yyid=" + list["id"].ToString() + "&number=" + list["number"].ToString() + "&type=" + base.Request.QueryString["type"].ToString() + "\">已阅</a>&nbsp;";
                    }
                    label4.Text = "<a href=\"mymessagedel.aspx?delid=" + list["id"].ToString() + "&number=" + list["number"].ToString() + "&type=" + base.Request.QueryString["type"].ToString() + "\">删除</a>&nbsp;";
                    if (list["url"].ToString() == "#")
                    {
                        label3.Text = "";
                    }
                    else
                    {
                        label3.Text = "<a href=\"" + list["url"].ToString() + "\" target='rform'>链接</a>&nbsp;";
                    }
                }
                list.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.DataBindToGridview("order by id desc");
            }
        }
    }
}


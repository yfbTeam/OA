namespace xyoa.PublicWork.TupianNew
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TupianNewSc : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label listall;
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = null;
                sql = string.Concat(new object[] { "select id,Titles,photo from qp_oa_TupianNew where ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) and CHARINDEX(',", this.Session["username"], ",',','+ScUsername+',')   >0 order by settime desc" });
                SqlDataReader list = this.List.GetList(sql);
                this.listall.Text = null;
                this.listall.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                this.listall.Text = this.listall.Text + "<tr>";
                int num = 0;
                while (list.Read())
                {
                    object text;
                    if (list["Titles"].ToString().Length > 13)
                    {
                        text = this.listall.Text;
                        this.listall.Text = string.Concat(new object[] { text, "<td height=\"164\" align=\"center\" valign=\"top\"><table width=\"232\" height=\"163\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td height=\"124\" align=\"center\"><div id=\"Pic", list["id"], "\" onmouseover='StartBlink(\"Pic", list["id"], "\")' onmouseout='EndBlink(\"Pic", list["id"], "\")' height=\"124\" width=\"232\"><a href=\"TupianNewList_show.aspx?id=", list["id"].ToString(), "\"><img style=\"filter: alpha(opacity=100); border: 1px solid #E3CBA7\" src=\"/", list["photo"].ToString(), "\" width=\"232\" height=\"124\" border=\"0\"></a></div></td></tr><tr><td align=\"center\"><a href=\"TupianNewList_show.aspx?id=", list["id"].ToString(), "\"><font color=\"#231E18\"><b>", list["Titles"].ToString().Substring(0, 13), "</b></font></a></td></tr></table></td>" });
                    }
                    else
                    {
                        text = this.listall.Text;
                        this.listall.Text = string.Concat(new object[] { text, "<td height=\"164\" align=\"center\" valign=\"top\"><table width=\"232\" height=\"163\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td height=\"124\" align=\"center\"><div id=\"Pic", list["id"], "\" onmouseover='StartBlink(\"Pic", list["id"], "\")' onmouseout='EndBlink(\"Pic", list["id"], "\")' height=\"124\" width=\"232\"><a href=\"TupianNewList_show.aspx?id=", list["id"].ToString(), "\"><img style=\"filter: alpha(opacity=100); border: 1px solid #E3CBA7\" src=\"/", list["photo"].ToString(), "\" width=\"232\" height=\"124\" border=\"0\"></a></div></td></tr><tr><td align=\"center\"><a href=\"TupianNewList_show.aspx?id=", list["id"].ToString(), "\"><font color=\"#231E18\"><b>", list["Titles"].ToString(), "</b></font></a></td></tr></table></td>" });
                    }
                    num++;
                    if (num == 4)
                    {
                        this.listall.Text = this.listall.Text + " <tr></tr>";
                        num = 0;
                    }
                }
                this.listall.Text = this.listall.Text + " </table>";
                list.Close();
            }
        }
    }
}


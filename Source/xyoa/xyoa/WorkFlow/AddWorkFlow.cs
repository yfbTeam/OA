namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (base.Request.QueryString["p"] != null)
                {
                    this.ViewState["tableheigh"] = "80%";
                }
                else
                {
                    this.ViewState["tableheigh"] = "600px";
                }
                this.pulicss.QuanXianBack("mmmm1", this.Session["perstr"].ToString());
                if (!this.Page.IsPostBack)
                {
                    int num;
                    string str2;
                    SqlDataReader reader2;
                    string str3;
                    if (base.Request.QueryString["id"].ToString() == "0")
                    {
                        this.ViewState["tilename"] = "全部表单";
                        this.Label1.Text = null;
                        string sql = string.Concat(new object[] { "select id,name from qp_oa_FormType where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by Paixun asc" });
                        SqlDataReader list = this.List.GetList(sql);
                        while (list.Read())
                        {
                            this.Label1.Text = this.Label1.Text + "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" height=\"30\">";
                            object text = this.Label1.Text;
                            this.Label1.Text = string.Concat(new object[] { text, "<tr><td height=\"100%\"><img src=\"/oaimg/menu/JianTou.gif\" hspace=\"2\"><b><font color=\"#1C5BA0\">", list["name"], "</font></b></td></tr>" });
                            this.Label1.Text = this.Label1.Text + "</table>";
                            this.Label1.Text = this.Label1.Text + "<table align=\"center\" border=\"0\" cellpadding=\"8\" cellspacing=\"1\" width=\"100%\" height=\"50\" class=\"nextpage\"> <tr><td class=\"newtd2\">";
                            this.Label1.Text = this.Label1.Text + "<table  border=\"0\" cellpadding=\"4\" cellspacing=\"0\"><tr>";
                            num = 0;
                            str2 = "select id,FormName from qp_oa_DIYForm  where TypeId='" + list["id"] + "' order by paixu asc";
                            reader2 = this.List.GetList(str2);
                            while (reader2.Read())
                            {
                                str3 = this.Label1.Text;
                                this.Label1.Text = str3 + "<td width=\"200\"><a href=\"javascript:void(0)\" onclick=\"opensclist('" + reader2["id"].ToString() + "')\" title='点击图标收藏/取消收藏'><img src=\"/oaimg/filetype/doc.gif\" hspace=\"2\" border=\"0\"></a><a href=\"javascript:void(0)\" onclick=\"opendoclist('" + reader2["id"].ToString() + "')\"><font color=\"#1C5BA0\">" + reader2["FormName"].ToString() + "</font></a></td>";
                                num++;
                                if (num == 5)
                                {
                                    this.Label1.Text = this.Label1.Text + "</tr><tr>";
                                    num = 0;
                                }
                            }
                            reader2.Close();
                            this.Label1.Text = this.Label1.Text + "</table>";
                            this.Label1.Text = this.Label1.Text + "</td></tr></table> <br>";
                        }
                        list.Close();
                    }
                    else
                    {
                        this.ViewState["tilename"] = "收藏表单";
                        this.Label1.Text = null;
                        this.Label1.Text = this.Label1.Text + "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" height=\"30\">";
                        this.Label1.Text = this.Label1.Text + "<tr><td height=\"100%\"><img src=\"/oaimg/menu/JianTou.gif\" hspace=\"2\"><b><font color=\"#1C5BA0\">收藏表单</font></b></td></tr>";
                        this.Label1.Text = this.Label1.Text + "</table>";
                        this.Label1.Text = this.Label1.Text + "<table align=\"center\" border=\"0\" cellpadding=\"8\" cellspacing=\"1\" width=\"100%\" height=\"50\" class=\"nextpage\"> <tr><td class=\"newtd2\">";
                        this.Label1.Text = this.Label1.Text + "<table  border=\"0\" cellpadding=\"4\" cellspacing=\"0\"><tr>";
                        num = 0;
                        str2 = string.Concat(new object[] { "select A.id,A.FormName from qp_oa_DIYForm as [A] inner join [qp_oa_FormType] as [B] on [A].[TypeId] = [B].[Id]  where (CHARINDEX(',", this.Session["BuMenId"], ",',','+B.ZdBumenId+',') > 0 and B.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+B.ZdUsername+',') > 0 and B.States='3') or (B.States='1') and CHARINDEX(',", this.Session["username"], ",',','+ScUsername+',')   >0 order by A.paixu asc" });
                        reader2 = this.List.GetList(str2);
                        while (reader2.Read())
                        {
                            str3 = this.Label1.Text;
                            this.Label1.Text = str3 + "<td width=\"200\"><a href=\"javascript:void(0)\" onclick=\"opensclist('" + reader2["id"].ToString() + "')\" title='点击图标取消收藏'><img src=\"/oaimg/filetype/doc.gif\" hspace=\"2\" border=\"0\"></a><a href=\"javascript:void(0)\" onclick=\"opendoclist('" + reader2["id"].ToString() + "')\"><font color=\"#1C5BA0\">" + reader2["FormName"].ToString() + "</font></a></td>";
                            num++;
                            if (num == 5)
                            {
                                this.Label1.Text = this.Label1.Text + "</tr><tr>";
                                num = 0;
                            }
                        }
                        reader2.Close();
                        this.Label1.Text = this.Label1.Text + "</table>";
                        this.Label1.Text = this.Label1.Text + "</td></tr></table>";
                    }
                }
            }
        }
    }
}


namespace xyoa.PublicWork.TupianNew
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TupianNewList_show : Page
    {
        protected Label Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        protected Image Photo;
        private publics pulicss = new publics();
        protected Button sc;
        protected Label titles;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select id from qp_oa_TupianNew where id='", base.Request.QueryString["id"], "' and  CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   >0" });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    string str2 = string.Concat(new object[] { "Update qp_oa_TupianNew   Set YdUsername=YdUsername+'", this.Session["username"], ",',YdRealname=YdRealname+'", this.Session["realname"], "(", DateTime.Now.ToString(), "),'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                    this.List.ExeSql(str2);
                }
                list.Close();
                string str3 = string.Concat(new object[] { "select * from qp_oa_TupianNew  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) " });
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    this.Photo.ImageUrl = "/" + reader2["Photo"].ToString() + "";
                    this.titles.Text = reader2["titles"].ToString();
                    this.Content.Text = this.pulicss.GetFormatStrbjq_show(reader2["Content"].ToString());
                    string str4 = "," + reader2["ScUsername"].ToString() + ",";
                    string str5 = "," + this.Session["username"].ToString() + ",";
                    if (str4.IndexOf(str5) < 0)
                    {
                        this.sc.Enabled = true;
                        this.sc.Text = "收 藏";
                    }
                    else
                    {
                        this.sc.Enabled = true;
                        this.sc.Text = "取消收藏";
                    }
                }
                reader2.Close();
            }
        }

        protected void sc_Click(object sender, EventArgs e)
        {
            string str;
            if (this.sc.Text == "收 藏")
            {
                str = string.Concat(new object[] { "Update qp_oa_TupianNew  Set ScUsername=ScUsername+'", this.Session["username"], ",' where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'  " });
                this.List.ExeSql(str);
                this.sc.Text = "取消收藏";
            }
            else
            {
                str = "Update qp_oa_TupianNew  Set ScUsername=replace(ScUsername,'" + this.Session["username"].ToString() + ",','')  where ID='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                this.List.ExeSql(str);
                this.sc.Text = "收 藏";
            }
        }
    }
}


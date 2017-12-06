namespace xyoa.MyWork.Richeng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RichengmyList_show : Page
    {
        protected Label Content;
        protected Button DelData;
        protected Label EndTime;
        protected HtmlForm form1;
        protected Label fujian;
        protected Label Gongkai;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label StartTime;
        protected Label titles;
        protected Button UpdateData;
        protected Label XbRealname;

        protected void DelData_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "  Delete from qp_oa_MyRicheng  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除日程", "我的日程");
            base.Response.Write("<script language=javascript>alert('删除成功！');window.location.href='Richengmy.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_MyRicheng  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.titles.Text = list["titles"].ToString();
                    this.StartTime.Text = list["Starttime"].ToString();
                    this.EndTime.Text = list["Endtime"].ToString();
                    this.Content.Text = list["Content"].ToString();
                    this.Gongkai.Text = list["Gongkai"].ToString();
                    this.XbRealname.Text = list["XbRealname"].ToString();
                    list.Close();
                    this.pulicss.GetFile(this.Number.Text, this.fujian);
                    this.DelData.Attributes.Add("onclick", "javascript:return zx();");
                }
                else
                {
                    list.Close();
                    base.Response.Write("<script language=javascript>alert('无相关信息！');window.location.href='Richengmy.aspx'</script>");
                }
            }
        }

        protected void UpdateData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("RichengmyList_update.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
        }
    }
}


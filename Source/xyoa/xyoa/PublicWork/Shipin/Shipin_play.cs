namespace xyoa.PublicWork.Shipin
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Shipin_play : Page
    {
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select Titles,Content from qp_oa_ShipinMg  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Titles"] = list["Titles"].ToString();
                    this.ViewState["Content"] = list["Content"].ToString();
                }
                list.Close();
                string str2 = string.Concat(new object[] { "select id from qp_oa_ShipinMg where id='", base.Request.QueryString["id"], "' and  CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   >0" });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (!reader2.Read())
                {
                    string str3 = string.Concat(new object[] { "Update qp_oa_ShipinMg   Set YdUsername=YdUsername+'", this.Session["username"], ",',YdRealname=YdRealname+'", this.Session["realname"], ",'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                    this.List.ExeSql(str3);
                }
                reader2.Close();
            }
        }
    }
}


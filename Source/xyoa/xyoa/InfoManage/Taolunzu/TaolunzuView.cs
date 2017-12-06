namespace xyoa.InfoManage.Taolunzu
{
    using Ajax;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using xyoa;

    public class TaolunzuView : Page
    {
        protected CheckBox CheckBox1;
        protected TextBox content;
        protected HtmlForm Form1;
        protected HtmlHead Head1;
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
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
                string sql = "select Name from qp_oa_Taolunzu where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["ChatName"] = list["Name"].ToString();
                }
                list.Close();
                string str2 = string.Concat(new object[] { "Update qp_oa_TaolunzuRy  Set IfTixing='0',Weidu='0' where  KeyId='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", HttpContext.Current.Session["username"], "'" });
                this.List.ExeSql(str2);
                string str3 = string.Concat(new object[] { "select Tixing from qp_oa_TaolunzuRy where Username='", HttpContext.Current.Session["username"], "' and Keyid='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'" });
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    if (reader2["Tixing"].ToString() == "0")
                    {
                        this.CheckBox1.Checked = false;
                    }
                    else
                    {
                        this.CheckBox1.Checked = true;
                    }
                }
                reader2.Close();
            }
        }
    }
}


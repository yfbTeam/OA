namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPage_zl_xz : Page
    {
        protected Label cishu;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Name;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label RealnameXz;
        protected Label Settimes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_Zst_ziliao  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.cishu.Text = list["cishu"].ToString();
                    this.Settimes.Text = list["Settimes"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.RealnameXz.Text = list["RealnameXz"].ToString();
                }
                list.Close();
            }
        }
    }
}


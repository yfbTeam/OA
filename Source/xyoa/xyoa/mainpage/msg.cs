namespace xyoa.mainpage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class msg : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string sql = "select Realname from qp_oa_MyData where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Realname"] = list["Realname"].ToString();
                }
                list.Close();
            }
        }
    }
}


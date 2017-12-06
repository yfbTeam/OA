namespace xyoa.HumanResources.Gongzi.GongziSB
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class gongzi : Page
    {
        protected HtmlForm form1;
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
                this.pulicss.QuanXianBack("eeee7b", this.Session["perstr"].ToString());
                string sql = "select  * from qp_hr_GongziSZ  where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["GzId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    base.Response.Redirect("/HumanResources/Gongzi/GongziSZ/file/" + list["Moban"].ToString() + "");
                    list.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到相关文件');window.close();</script>");
                }
            }
        }
    }
}


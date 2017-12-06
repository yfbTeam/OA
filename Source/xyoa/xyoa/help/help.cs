namespace xyoa.help
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class help : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                base.Response.Write("<!--\n&nbsp; \n-->");
            }
        }
    }
}


namespace xyoa.pda
{
    using System;
    using System.Web.UI;

    public class LogOut : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session.Clear();
            base.Response.Redirect("default.aspx");
        }
    }
}


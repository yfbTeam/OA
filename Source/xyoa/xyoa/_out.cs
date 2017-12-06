namespace xyoa
{
    using System;
    using System.Web.UI;

    public class _out : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session.Clear();
            base.Response.Redirect("default.aspx");
        }
    }
}


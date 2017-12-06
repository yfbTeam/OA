namespace xyoa.InfoManage.Taolunzu
{
    using Ajax;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using xyoa;

    public class SeadChatPeople : Page
    {
        protected HtmlForm Form1;
        protected HtmlHead Head1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(AjaxMethod));
        }
    }
}


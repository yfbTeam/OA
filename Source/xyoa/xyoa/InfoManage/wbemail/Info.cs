﻿namespace xyoa.InfoManage.wbemail
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Info : Page
    {
        protected HtmlButton BUTTON1;
        protected HtmlForm form1;
        protected HtmlHead Head1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["p"] != null)
            {
                this.ViewState["tableheigh"] = "80%";
            }
            else
            {
                this.ViewState["tableheigh"] = "600px";
            }
        }
    }
}

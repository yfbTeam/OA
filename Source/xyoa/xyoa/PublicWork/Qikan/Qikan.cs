﻿namespace xyoa.PublicWork.Qikan
{
    using qiupeng.publiccs;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Qikan : Page
    {
        protected HtmlButton BUTTON1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (base.Request.QueryString["p"] != null)
                {
                    this.ViewState["tableheigh"] = "80%";
                }
                else
                {
                    this.ViewState["tableheigh"] = "600px";
                }
                this.pulicss.QuanXianVis(this.BUTTON1, "jjjj5b", this.Session["perstr"].ToString());
            }
        }
    }
}

﻿namespace xyoa.SchTable.Xueji.Biangeng
{
    using qiupeng.publiccs;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Biangeng : Page
    {
        protected HtmlButton Button1;
        protected HtmlButton FONT1;
        protected HtmlButton FONT2;
        protected HtmlButton FONT3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pulicss.QuanXianVis(this.FONT1, "pppp2c", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.FONT2, "pppp2c", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.FONT3, "pppp2c", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.Button1, "pppp2c", this.Session["perstr"].ToString());
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (base.Request.QueryString["p"] != null)
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

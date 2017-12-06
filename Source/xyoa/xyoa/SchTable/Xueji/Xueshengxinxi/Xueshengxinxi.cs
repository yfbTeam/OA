namespace xyoa.SchTable.Xueji.Xueshengxinxi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Xueshengxinxi : Page
    {
        protected HtmlButton button1;
        protected HtmlButton button10;
        protected HtmlButton button11;
        protected HtmlButton button12;
        protected HtmlButton button2;
        protected HtmlButton button3;
        protected HtmlButton button4;
        protected HtmlButton button5;
        protected HtmlButton button6;
        protected HtmlButton button7;
        protected HtmlButton button8;
        protected HtmlButton button9;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private publics pulicss = new publics();
        public string Xueduan;
        public string Xueqi;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Xueqi = this.divsch.GetXueqi();
            this.Xueduan = this.divsch.GetXueduan();
            this.pulicss.QuanXianVis(this.button1, "pppp2ba", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button2, "pppp2bb", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button3, "pppp2bc", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button4, "pppp2bd", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button5, "pppp2be", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button6, "pppp2bf", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button7, "pppp2bg", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button8, "pppp2bh", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button9, "pppp2bi", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button10, "pppp2bj", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button11, "pppp2bk", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.button12, "pppp2bl", this.Session["perstr"].ToString());
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


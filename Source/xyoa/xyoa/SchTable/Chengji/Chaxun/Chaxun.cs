namespace xyoa.SchTable.Chengji.Chaxun
{
    using qiupeng.publiccs;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Chaxun : Page
    {
        protected HtmlButton FONT1;
        protected HtmlButton FONT2;
        protected HtmlButton FONT3;
        protected HtmlButton FONT4;
        protected HtmlButton FONT5;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pulicss.QuanXianVis(this.FONT1, "pppp3b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.FONT2, "pppp3b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.FONT3, "pppp3b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.FONT4, "pppp3b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.FONT5, "pppp3b", this.Session["perstr"].ToString());
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
                if (base.Request.QueryString["Url"] != null)
                {
                    if (base.Request.QueryString["Url"].ToString() == "1")
                    {
                        this.ViewState["FromUrl_a1"] = "Chaxun_left.aspx?url=1";
                        this.ViewState["FromUrl_a2"] = "Chaxun_List.aspx?id=0";
                    }
                    if (base.Request.QueryString["Url"].ToString() == "2")
                    {
                        this.ViewState["FromUrl_a1"] = "Chaxun_left.aspx?url=2";
                        this.ViewState["FromUrl_a2"] = "Chaxun_ListBj.aspx?id=0";
                    }
                    if (base.Request.QueryString["Url"].ToString() == "3")
                    {
                        this.ViewState["FromUrl_a1"] = "Chaxun_leftNj.aspx?url=2";
                        this.ViewState["FromUrl_a2"] = "Chaxun_ListNj.aspx?id=0";
                    }
                }
                else
                {
                    this.ViewState["FromUrl_a1"] = "Chaxun_left.aspx?url=1";
                    this.ViewState["FromUrl_a2"] = "Chaxun_List.aspx?id=0";
                }
            }
        }
    }
}


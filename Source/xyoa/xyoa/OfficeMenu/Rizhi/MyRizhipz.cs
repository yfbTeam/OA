namespace xyoa.OfficeMenu.Rizhi
{
    using qiupeng.publiccs;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class MyRizhipz : Page
    {
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
                if (base.Request.QueryString["left"] != null)
                {
                    if (base.Request.QueryString["left"].ToString() == "1")
                    {
                        this.ViewState["lefturl"] = "MyRizhipz_left.aspx";
                    }
                    else if (base.Request.QueryString["left"].ToString() == "2")
                    {
                        this.ViewState["lefturl"] = "MyRizhipzBm_left.aspx";
                    }
                    else if (base.Request.QueryString["left"].ToString() == "3")
                    {
                        this.ViewState["lefturl"] = "MyRizhipzSj_left.aspx";
                    }
                    else if (base.Request.QueryString["left"].ToString() == "4")
                    {
                        this.ViewState["lefturl"] = "MyRizhipzFl_left.aspx";
                    }
                    else
                    {
                        this.ViewState["lefturl"] = "MyRizhipz_left.aspx";
                    }
                }
                else
                {
                    this.ViewState["lefturl"] = "MyRizhipz_left.aspx";
                }
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
}


namespace xyoa.OfficeMenu.Renwu
{
    using qiupeng.publiccs;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class RenwuJk : Page
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
                        this.ViewState["lefturl"] = "RenwuJk_left.aspx";
                    }
                    else if (base.Request.QueryString["left"].ToString() == "2")
                    {
                        this.ViewState["lefturl"] = "RenwuJkBm_left.aspx";
                    }
                    else if (base.Request.QueryString["left"].ToString() == "3")
                    {
                        this.ViewState["lefturl"] = "RenwuJkSj_left.aspx";
                    }
                    else if (base.Request.QueryString["left"].ToString() == "4")
                    {
                        this.ViewState["lefturl"] = "RenwuJkFl_left.aspx";
                    }
                    else
                    {
                        this.ViewState["lefturl"] = "RenwuJk_left.aspx";
                    }
                }
                else
                {
                    this.ViewState["lefturl"] = "RenwuJk_left.aspx";
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


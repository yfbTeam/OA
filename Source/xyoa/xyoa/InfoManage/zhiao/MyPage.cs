namespace xyoa.InfoManage.zhiao
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class MyPage : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (base.Request.QueryString["url"] != null)
                {
                    if (base.Request.QueryString["url"].ToString() == "1")
                    {
                        this.ViewState["urlstr"] = "MyPage_ph.aspx";
                    }
                    if (base.Request.QueryString["url"].ToString() == "2")
                    {
                        this.ViewState["urlstr"] = "MyPage_wt.aspx";
                    }
                    if (base.Request.QueryString["url"].ToString() == "3")
                    {
                        this.ViewState["urlstr"] = "MyPage_hd.aspx";
                    }
                    if (base.Request.QueryString["url"].ToString() == "4")
                    {
                        this.ViewState["urlstr"] = "MyPage_zl.aspx";
                    }
                    if (base.Request.QueryString["url"].ToString() == "5")
                    {
                        this.ViewState["urlstr"] = "MyPage_wt_add.aspx";
                    }
                }
                else
                {
                    this.ViewState["urlstr"] = "MyPage_main.aspx";
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


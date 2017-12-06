namespace xyoa.JqMain
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class WorkFlow : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString["p"].ToString() == "1")
            {
                this.ViewState["meun"] = "/menu/MyWorkMenu.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "2")
            {
                this.ViewState["meun"] = "/menu/PublicWorkMenu.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "3")
            {
                this.ViewState["meun"] = "/menu/OfficeMenu.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "4")
            {
                this.ViewState["meun"] = "/menu/InfoMenu.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "5")
            {
                this.ViewState["meun"] = "/menu/ResourcesMenu.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "6")
            {
                this.ViewState["meun"] = "/menu/WorkFlowMenu.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "7")
            {
                this.ViewState["meun"] = "/menu/Projecttable.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "8")
            {
                this.ViewState["meun"] = "/menu/CRMtable.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "9")
            {
                this.ViewState["meun"] = "/menu/HumanResourcestable.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "10")
            {
                this.ViewState["meun"] = "/menu/SystemMenu.aspx";
                this.ViewState["meunr"] = "/SystemManage/User/username.aspx";
            }
            if (base.Request.QueryString["p"].ToString() == "11")
            {
                this.ViewState["meun"] = "/menu/OtherMenu.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "12")
            {
                this.ViewState["meun"] = "/menu/MenhuMenu.aspx";
                this.ViewState["meunr"] = "Mymenhu.aspx?p=" + base.Request.QueryString["p"].ToString() + "&id=0";
            }
            if (base.Request.QueryString["p"].ToString() == "13")
            {
                this.ViewState["meun"] = "/mainpage/jigou.aspx";
                this.ViewState["meunr"] = "menhu.aspx?id=" + base.Request.QueryString["p"].ToString() + "";
            }
            if (base.Request.QueryString["p"].ToString() == "14")
            {
                this.ViewState["meun"] = "/mainpage/mymessage.aspx?type=1";
                this.ViewState["meunr"] = "/InfoManage/messages/Messages.aspx";
            }
            if (base.Request.QueryString["p"].ToString() == "15")
            {
                this.ViewState["meun"] = "/mainpage/mymessage.aspx?type=2";
                this.ViewState["meunr"] = "/InfoManage/messages/Messages.aspx";
            }
            if (base.Request.QueryString["p"].ToString() == "25")
            {
                this.ViewState["meun"] = "/menu/XxMeun.aspx";
                this.ViewState["meunr"] = "/SchTable/Xueji/ZaijiSheng/ZaijiSheng.aspx";
            }
        }
    }
}


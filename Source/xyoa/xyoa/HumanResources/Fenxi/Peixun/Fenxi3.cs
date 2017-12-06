namespace xyoa.HumanResources.Fenxi.Peixun
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Fenxi3 : Page
    {
        protected Button Button2;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected TextBox FqRealname;
        protected TextBox FqUsername;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected TextBox Zhuti;

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Fenxi3List.aspx?Zhuti=" + this.Zhuti.Text + "&UserId=" + this.FqUsername.Text + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
                this.FqRealname.Attributes.Add("readonly", "readonly");
            }
        }
    }
}


namespace xyoa.HumanResources.Fenxi.Kaoping
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Fenxi1 : Page
    {
        protected Button Button2;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList LeixingID;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox RealnameCy;
        protected TextBox Starttime;
        protected TextBox UsernameCy;
        protected TextBox Zhuti;

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("KaoPingCxList.aspx?LeixingID=" + this.LeixingID.SelectedValue + "&Zhuti=" + this.Zhuti.Text + "&UsernameCy=" + this.UsernameCy.Text + "0&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "");
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
                string sQL = "select id,Leixing from qp_hr_KaoPingSz order by id asc";
                this.list.Bind_DropDownListmodle(this.LeixingID, sQL, "id", "Leixing");
                this.RealnameCy.Attributes.Add("readonly", "readonly");
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
            }
        }
    }
}


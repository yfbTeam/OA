namespace xyoa.HumanResources.Fenxi.RenShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Fenxi18 : Page
    {
        protected Button Button2;
        protected DropDownList EMonth;
        protected DropDownList EYear;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList SMonth;
        protected DropDownList SYear;

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Fenxi18List.aspx?SYear=" + this.SYear.SelectedValue + "&SMonth=" + this.SMonth.SelectedValue + "&EYear=" + this.EYear.SelectedValue + "&EMonth=" + this.EMonth.SelectedValue + "");
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
                string sQL = "select DISTINCT ProYear from qp_crm_FenxiMonth";
                this.list.Bind_DropDownList_nothing(this.SYear, sQL, "ProYear", "ProYear");
                string str2 = "select DISTINCT ProMonth from qp_crm_FenxiMonth";
                this.list.Bind_DropDownList_nothing(this.SMonth, str2, "ProMonth", "ProMonth");
                string str3 = "select DISTINCT ProYear from qp_crm_FenxiMonth";
                this.list.Bind_DropDownList_nothing(this.EYear, str3, "ProYear", "ProYear");
                string str4 = "select DISTINCT ProMonth from qp_crm_FenxiMonth";
                this.list.Bind_DropDownList_nothing(this.EMonth, str4, "ProMonth", "ProMonth");
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
                this.SYear.SelectedValue = DateTime.Now.Year.ToString();
                this.SMonth.SelectedValue = DateTime.Now.Month.ToString();
                this.EYear.SelectedValue = DateTime.Now.Year.ToString();
                this.EMonth.SelectedValue = DateTime.Now.Month.ToString();
            }
        }
    }
}


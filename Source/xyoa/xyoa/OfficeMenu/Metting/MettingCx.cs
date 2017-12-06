namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingCx : Page
    {
        protected Button Button2;
        protected TextBox CjRealname;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Introduction;
        protected DropDownList LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MettingName;
        protected TextBox Name;
        protected TextBox NbPeopleName;
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected DropDownList State;
        protected TextBox Username;

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MettingCxList.aspx?Name=" + this.Name.Text + "&Introduction=" + this.Introduction.Text + "&NbPeopleName=" + this.NbPeopleName.Text + "&MettingId=" + this.MettingName.SelectedValue + "&CjRealname=" + this.CjRealname.Text + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "&State=" + this.State.SelectedValue + "&LcZhuangtai=" + this.LcZhuangtai.SelectedValue + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_MettingHouse order by id asc";
                this.list.Bind_DropDownList_kong(this.MettingName, sQL, "id", "name");
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
            }
        }
    }
}


namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarApplyTj : Page
    {
        protected Button Button2;
        protected DropDownList CarId;
        protected TextBox Carpeople;
        protected TextBox CarpeopleUser;
        protected TextBox Destination;
        protected DropDownList Driver;
        protected TextBox Endtime;
        protected TextBox Endtime1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox licheng1;
        protected TextBox licheng2;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox Starttime;
        protected TextBox Starttime1;
        protected TextBox Subject;
        protected DropDownList UnitId;
        protected TextBox Username;

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarApplyTjList.aspx?CarId=" + this.CarId.SelectedValue + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "&UnitId=" + this.UnitId.SelectedValue + "&Driver=" + this.Driver.SelectedValue + "&Starttime1=" + this.Starttime1.Text + "&Endtime1=" + this.Endtime1.Text + "&licheng1=" + this.licheng1.Text + "&licheng2=" + this.licheng2.Text + "&Destination=" + this.Destination.Text + "&Subject=" + this.Subject.Text + "&Username=" + this.Username.Text + "&CarpeopleUser=" + this.CarpeopleUser.Text + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select Realname from qp_oa_DriverManager order by id asc";
                this.list.Bind_DropDownList_kong(this.Driver, sQL, "Realname", "Realname");
                string str2 = "select id,CarName from qp_oa_CarInfo order by id asc";
                this.list.Bind_DropDownList_kong(this.CarId, str2, "id", "CarName");
                this.pulicss.BindListkong("qp_oa_Bumen", this.UnitId, "", "order by Bianhao asc");
                this.Realname.Attributes.Add("readonly", "readonly");
                this.Carpeople.Attributes.Add("readonly", "readonly");
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
            }
        }
    }
}


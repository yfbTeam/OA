namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarCostsTj : Page
    {
        protected DropDownList BuMenId;
        protected Button Button2;
        protected DropDownList CarName;
        protected TextBox CostsName;
        protected DropDownList CostsType;
        protected TextBox Description;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Jine1;
        protected TextBox Jine2;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox PersonName;
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected TextBox Username;

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarCostsTjList.aspx?CarName=" + this.CarName.SelectedValue + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "&BuMenId=" + this.BuMenId.SelectedValue + "&CostsType=" + this.CostsType.SelectedValue + "&CostsName=" + this.CostsName.Text + "&Jine1=" + this.Jine1.Text + "&Jine2=" + this.Jine2.Text + "&Username=" + this.Username.Text + "&Description=" + this.Description.Text + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListkong("qp_oa_Bumen", this.BuMenId, "", "order by Bianhao asc");
                string sQL = "select CarName from  qp_oa_CarInfo";
                this.list.Bind_DropDownList_kong(this.CarName, sQL, "CarName", "CarName");
                string str2 = "select Name from  qp_oa_CarFyType";
                this.list.Bind_DropDownList_kong(this.CostsType, str2, "Name", "Name");
                this.PersonName.Attributes.Add("readonly", "readonly");
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
            }
        }
    }
}


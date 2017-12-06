namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarCosts_add : Page
    {
        protected DropDownList BuMenId;
        protected Button Button1;
        protected Button Button2;
        protected DropDownList CarName;
        protected TextBox CostsMoney;
        protected TextBox CostsName;
        protected TextBox CostsTime;
        protected DropDownList CostsType;
        protected TextBox Description;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox PersonName;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.PersonName.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_CarCosts (CarName,CostsTime,BuMenId,CostsType,CostsName,CostsMoney,PersonName,Description,Username) values ('", this.CarName.SelectedValue, "','", this.pulicss.GetFormatStr(this.CostsTime.Text), "','", this.BuMenId.SelectedValue, "','", this.CostsType.SelectedValue, "','", this.pulicss.GetFormatStr(this.CostsName.Text), "','", this.pulicss.GetFormatStr(this.CostsMoney.Text), "','", this.pulicss.GetFormatStr(this.PersonName.Text), "','", this.pulicss.GetFormatStr(this.Description.Text), 
                "','", this.Session["username"], "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增车辆费用", "车辆费用管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarCosts.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarCosts.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListNothing("qp_oa_Bumen", this.BuMenId, "", "order by Bianhao asc");
                string sQL = "select CarName from  qp_oa_CarInfo";
                this.list.Bind_DropDownList_nothing(this.CarName, sQL, "CarName", "CarName");
                string str2 = "select Name from  qp_oa_CarFyType";
                this.list.Bind_DropDownList_nothing(this.CostsType, str2, "Name", "Name");
                this.BindAttribute();
                this.PersonName.Text = this.Session["realname"].ToString();
                this.CostsTime.Text = DateTime.Now.ToShortDateString();
                this.BuMenId.SelectedValue = this.Session["BuMenId"].ToString();
            }
        }
    }
}


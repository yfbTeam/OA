namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarCosts_update : Page
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
                "Update qp_oa_CarCosts    Set CarName='", this.CarName.SelectedValue, "',CostsTime='", this.pulicss.GetFormatStr(this.CostsTime.Text), "',BuMenId='", this.BuMenId.SelectedValue, "',CostsType='", this.CostsType.SelectedValue, "',CostsName='", this.pulicss.GetFormatStr(this.CostsName.Text), "',CostsMoney='", this.pulicss.GetFormatStr(this.CostsMoney.Text), "',PersonName='", this.pulicss.GetFormatStr(this.PersonName.Text), "',Description='", this.pulicss.GetFormatStr(this.Description.Text), 
                "'  where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改车辆费用", "车辆费用管理");
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
                string sql = "select * from qp_oa_CarCosts where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CarName.SelectedValue = list["CarName"].ToString();
                    this.CostsTime.Text = DateTime.Parse(list["CostsTime"].ToString()).ToShortDateString();
                    this.BuMenId.SelectedValue = list["BuMenId"].ToString();
                    this.CostsType.SelectedValue = list["CostsType"].ToString();
                    this.CostsName.Text = list["CostsName"].ToString();
                    this.CostsMoney.Text = list["CostsMoney"].ToString();
                    this.PersonName.Text = list["PersonName"].ToString();
                    this.Description.Text = list["Description"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


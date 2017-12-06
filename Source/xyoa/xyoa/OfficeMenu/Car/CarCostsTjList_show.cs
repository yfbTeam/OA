namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarCostsTjList_show : Page
    {
        protected Label BuMenId;
        protected Label CarName;
        protected Label CostsMoney;
        protected Label CostsName;
        protected Label CostsTime;
        protected Label CostsType;
        protected Label Description;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label PersonName;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_CarCosts where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CarName.Text = list["CarName"].ToString();
                    this.CostsTime.Text = DateTime.Parse(list["CostsTime"].ToString()).ToShortDateString();
                    this.BuMenId.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BuMenId"].ToString());
                    this.CostsType.Text = list["CostsType"].ToString();
                    this.CostsName.Text = list["CostsName"].ToString();
                    this.CostsMoney.Text = list["CostsMoney"].ToString();
                    this.PersonName.Text = list["PersonName"].ToString();
                    this.Description.Text = list["Description"].ToString();
                }
                list.Close();
                this.pulicss.InsertLog("查看车辆费用", "车辆费用管理");
            }
        }
    }
}


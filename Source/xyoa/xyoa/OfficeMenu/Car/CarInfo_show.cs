namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarInfo_show : Page
    {
        protected Button Button2;
        protected Label BxEndtime;
        protected Label BxStartime;
        protected Label CarModel;
        protected Label CarName;
        protected Label CarNum;
        protected Label CarPrice;
        protected Label CarTime;
        protected Label CarType;
        protected Label Chejiahao;
        protected Label EngineNum;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Nianshen;
        private publics pulicss = new publics();
        protected Label Remark;
        protected Label SyRealname;
        protected Label XcNsShijian;
        protected Label ZjNsShijian;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarInfo.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_CarInfo where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CarName.Text = list["CarName"].ToString();
                    this.CarNum.Text = list["CarNum"].ToString();
                    this.SyRealname.Text = list["SyRealname"].ToString();
                    this.BxStartime.Text = DateTime.Parse(list["BxStartime"].ToString()).ToShortDateString();
                    this.BxEndtime.Text = DateTime.Parse(list["BxEndtime"].ToString()).ToShortDateString();
                    this.Nianshen.Text = list["Nianshen"].ToString();
                    this.ZjNsShijian.Text = DateTime.Parse(list["ZjNsShijian"].ToString()).ToShortDateString();
                    this.XcNsShijian.Text = DateTime.Parse(list["XcNsShijian"].ToString()).ToShortDateString();
                    this.Chejiahao.Text = list["Chejiahao"].ToString();
                    this.CarModel.Text = list["CarModel"].ToString();
                    this.CarType.Text = list["CarType"].ToString();
                    this.CarPrice.Text = list["CarPrice"].ToString();
                    this.CarTime.Text = list["CarTime"].ToString();
                    this.EngineNum.Text = list["EngineNum"].ToString();
                    this.Remark.Text = this.pulicss.TbToLb(list["Remark"].ToString());
                }
                list.Close();
                this.pulicss.InsertLog("查看车辆信息", "车辆信息管理");
                this.BindAttribute();
            }
        }
    }
}


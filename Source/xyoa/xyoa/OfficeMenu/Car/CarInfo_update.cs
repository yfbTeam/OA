namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarInfo_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox BxEndtime;
        protected TextBox BxStartime;
        protected TextBox CarModel;
        protected TextBox CarName;
        protected TextBox CarNum;
        protected TextBox CarPrice;
        protected TextBox CarTime;
        protected DropDownList CarType;
        protected TextBox Chejiahao;
        protected TextBox EngineNum;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Nianshen;
        private publics pulicss = new publics();
        protected TextBox Remark;
        protected TextBox SyRealname;
        protected TextBox SyUsername;
        protected TextBox XcNsShijian;
        protected TextBox ZjNsShijian;

        public void BindAttribute()
        {
            this.SyRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_CarInfo    Set CarName='", this.pulicss.GetFormatStr(this.CarName.Text), "',CarNum='", this.pulicss.GetFormatStr(this.CarNum.Text), "',SyUsername='", this.pulicss.GetFormatStr(this.SyUsername.Text), "',SyRealname='", this.pulicss.GetFormatStr(this.SyRealname.Text), "',BxStartime='", this.pulicss.GetFormatStr(this.BxStartime.Text), "',BxEndtime='", this.pulicss.GetFormatStr(this.BxEndtime.Text), "',Nianshen='", this.pulicss.GetFormatStr(this.Nianshen.Text), "',ZjNsShijian='", this.pulicss.GetFormatStr(this.ZjNsShijian.Text), 
                "',XcNsShijian='", this.pulicss.GetFormatStr(this.XcNsShijian.Text), "',Chejiahao='", this.pulicss.GetFormatStr(this.Chejiahao.Text), "',CarModel='", this.pulicss.GetFormatStr(this.CarModel.Text), "',CarType='", this.CarType.SelectedValue, "',CarPrice='", this.pulicss.GetFormatStr(this.CarPrice.Text), "',CarTime='", this.pulicss.GetFormatStr(this.CarTime.Text), "',EngineNum='", this.pulicss.GetFormatStr(this.EngineNum.Text), "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), 
                "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改车辆信息", "车辆信息管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarInfo.aspx'</script>");
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
                string sQL = "select Name from  qp_oa_CarType";
                this.list.Bind_DropDownList_nothing(this.CarType, sQL, "Name", "Name");
                string sql = "select * from qp_oa_CarInfo where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CarName.Text = list["CarName"].ToString();
                    this.CarNum.Text = list["CarNum"].ToString();
                    this.SyUsername.Text = list["SyUsername"].ToString();
                    this.SyRealname.Text = list["SyRealname"].ToString();
                    this.BxStartime.Text = DateTime.Parse(list["BxStartime"].ToString()).ToShortDateString();
                    this.BxEndtime.Text = DateTime.Parse(list["BxEndtime"].ToString()).ToShortDateString();
                    this.Nianshen.Text = list["Nianshen"].ToString();
                    this.ZjNsShijian.Text = DateTime.Parse(list["ZjNsShijian"].ToString()).ToShortDateString();
                    this.XcNsShijian.Text = DateTime.Parse(list["XcNsShijian"].ToString()).ToShortDateString();
                    this.Chejiahao.Text = list["Chejiahao"].ToString();
                    this.CarModel.Text = list["CarModel"].ToString();
                    this.CarType.SelectedValue = list["CarType"].ToString();
                    this.CarPrice.Text = list["CarPrice"].ToString();
                    this.CarTime.Text = list["CarTime"].ToString();
                    this.EngineNum.Text = list["EngineNum"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


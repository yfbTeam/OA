namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarInfo_add : Page
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
            string sql = "insert into qp_oa_CarInfo  (CarName,CarNum,SyUsername,SyRealname,BxStartime,BxEndtime,Nianshen,ZjNsShijian,XcNsShijian,Chejiahao,CarModel,CarType,CarPrice,CarTime,EngineNum,Remark) values ('" + this.pulicss.GetFormatStr(this.CarName.Text) + "','" + this.pulicss.GetFormatStr(this.CarNum.Text) + "','" + this.pulicss.GetFormatStr(this.SyUsername.Text) + "','" + this.pulicss.GetFormatStr(this.SyRealname.Text) + "','" + this.pulicss.GetFormatStr(this.BxStartime.Text) + "','" + this.pulicss.GetFormatStr(this.BxEndtime.Text) + "','" + this.pulicss.GetFormatStr(this.Nianshen.Text) + "','" + this.pulicss.GetFormatStr(this.ZjNsShijian.Text) + "','" + this.pulicss.GetFormatStr(this.XcNsShijian.Text) + "','" + this.pulicss.GetFormatStr(this.Chejiahao.Text) + "','" + this.pulicss.GetFormatStr(this.CarModel.Text) + "','" + this.CarType.SelectedValue + "','" + this.pulicss.GetFormatStr(this.CarPrice.Text) + "','" + this.pulicss.GetFormatStr(this.CarTime.Text) + "','" + this.pulicss.GetFormatStr(this.EngineNum.Text) + "','" + this.pulicss.GetFormatStr(this.Remark.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增车辆信息", "车辆信息管理");
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
                this.BindAttribute();
            }
        }
    }
}


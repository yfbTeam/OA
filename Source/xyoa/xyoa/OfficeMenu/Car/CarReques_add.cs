namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarReques_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected DropDownList CarName;
        protected HtmlForm form1;
        protected TextBox FsAddress;
        protected TextBox FsTimes;
        protected TextBox Gaiyao;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Peichang;
        protected TextBox PersonName;
        private publics pulicss = new publics();
        protected TextBox Shunhuai;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_CarReques (CarName,FsAddress,FsTimes,PersonName,Gaiyao,Shunhuai,Peichang) values ('" + this.CarName.SelectedValue + "','" + this.pulicss.GetFormatStr(this.FsAddress.Text) + "','" + this.pulicss.GetFormatStr(this.FsTimes.Text) + "','" + this.pulicss.GetFormatStr(this.PersonName.Text) + "','" + this.pulicss.GetFormatStr(this.Gaiyao.Text) + "','" + this.pulicss.GetFormatStr(this.Shunhuai.Text) + "','" + this.pulicss.GetFormatStr(this.Peichang.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增车辆事故", "车辆事故管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarReques.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarReques.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select CarName from  qp_oa_CarInfo";
                this.list.Bind_DropDownList_nothing(this.CarName, sQL, "CarName", "CarName");
                this.BindAttribute();
            }
        }
    }
}


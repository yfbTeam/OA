namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarReques_update : Page
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
            string sql = string.Concat(new object[] { 
                "Update qp_oa_CarReques    Set CarName='", this.CarName.SelectedValue, "',FsAddress='", this.pulicss.GetFormatStr(this.FsAddress.Text), "',FsTimes='", this.pulicss.GetFormatStr(this.FsTimes.Text), "',PersonName='", this.pulicss.GetFormatStr(this.PersonName.Text), "',Gaiyao='", this.pulicss.GetFormatStr(this.Gaiyao.Text), "',Shunhuai='", this.pulicss.GetFormatStr(this.Shunhuai.Text), "',Peichang='", this.pulicss.GetFormatStr(this.Peichang.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), 
                "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改车辆事故", "车辆事故管理");
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
                string sql = "select * from qp_oa_CarReques  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CarName.SelectedValue = list["CarName"].ToString();
                    this.FsAddress.Text = list["FsAddress"].ToString();
                    this.FsTimes.Text = list["FsTimes"].ToString();
                    this.PersonName.Text = list["PersonName"].ToString();
                    this.Gaiyao.Text = list["Gaiyao"].ToString();
                    this.Shunhuai.Text = list["Shunhuai"].ToString();
                    this.Peichang.Text = list["Peichang"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


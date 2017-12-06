namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarReques_show : Page
    {
        protected Button Button2;
        protected Label CarName;
        protected HtmlForm form1;
        protected Label FsAddress;
        protected Label FsTimes;
        protected Label Gaiyao;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Peichang;
        protected Label PersonName;
        private publics pulicss = new publics();
        protected Label Shunhuai;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
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
                string sql = "select * from qp_oa_CarReques  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CarName.Text = list["CarName"].ToString();
                    this.FsAddress.Text = list["FsAddress"].ToString();
                    this.FsTimes.Text = list["FsTimes"].ToString();
                    this.PersonName.Text = list["PersonName"].ToString();
                    this.Gaiyao.Text = this.pulicss.TbToLb(list["Gaiyao"].ToString());
                    this.Shunhuai.Text = this.pulicss.TbToLb(list["Shunhuai"].ToString());
                    this.Peichang.Text = this.pulicss.TbToLb(list["Peichang"].ToString());
                }
                list.Close();
                this.pulicss.InsertLog("查看车辆事故", "车辆事故管理");
                this.BindAttribute();
            }
        }
    }
}


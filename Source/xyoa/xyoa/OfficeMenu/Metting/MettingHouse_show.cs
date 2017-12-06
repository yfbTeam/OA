namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingHouse_show : Page
    {
        protected Label Address;
        protected Button Button2;
        protected Label Equipment;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Introduction;
        private Db List = new Db();
        protected Label Name;
        protected Label PeopleNum;
        private publics pulicss = new publics();
        protected Label Remark;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MettingHouse.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MettingHouse where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.PeopleNum.Text = list["PeopleNum"].ToString();
                    this.Equipment.Text = this.pulicss.TbToLb(list["Equipment"].ToString());
                    this.Introduction.Text = this.pulicss.TbToLb(list["Introduction"].ToString());
                    this.Address.Text = list["Address"].ToString();
                    this.Remark.Text = this.pulicss.TbToLb(list["Remark"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


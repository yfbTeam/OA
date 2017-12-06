namespace xyoa.SystemManage.User
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class username_show : Page
    {
        protected Label BuMenId;
        protected Label Email;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Iflogin;
        protected Label IfResponUpdate;
        protected Label JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label MoveTel;
        protected TextBox Number;
        protected Label paixu;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Remark;
        protected Label Sex;
        protected Label StardType;
        protected Label Username;
        protected Label Zhiweiid;

        public void BindAttribute()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_username where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Username.Text = list["Username"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.BuMenId.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BuMenId"].ToString());
                    this.JueseId.Text = this.pulicss.TypeCode("qp_oa_Juese", list["JueseId"].ToString());
                    this.IfResponUpdate.Text = this.pulicss.CheckInt(list["IfResponUpdate"].ToString());
                    this.Zhiweiid.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["Zhiweiid"].ToString());
                    this.StardType.Text = this.pulicss.CheckInt(list["StardType"].ToString());
                    this.Email.Text = list["Email"].ToString();
                    this.MoveTel.Text = list["MoveTel"].ToString();
                    this.Iflogin.Text = this.pulicss.CheckInt(list["Iflogin"].ToString());
                    this.Sex.Text = list["Sex"].ToString();
                    this.Remark.Text = this.pulicss.TbToLb(list["Remark"].ToString());
                    this.paixu.Text = list["paixu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


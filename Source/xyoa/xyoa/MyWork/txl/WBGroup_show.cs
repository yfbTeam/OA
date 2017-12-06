namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WBGroup_show : Page
    {
        protected Label CAddress;
        protected Label CFax;
        protected Label CName;
        protected Label CTel;
        protected Label CZipCode;
        protected Label Email;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label HMoveTel;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label MsnNum;
        protected Label Name;
        protected TextBox Number;
        protected Label OtherName;
        protected Label Post;
        private publics pulicss = new publics();
        protected Label QQNum;
        protected Label Remark;
        protected Label Sex;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_WBGroup where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Sex.Text = list["Sex"].ToString();
                    this.OtherName.Text = list["OtherName"].ToString();
                    this.Post.Text = list["Post"].ToString();
                    this.CName.Text = list["CName"].ToString();
                    this.CAddress.Text = list["CAddress"].ToString();
                    this.CZipCode.Text = list["CZipCode"].ToString();
                    this.CTel.Text = list["CTel"].ToString();
                    this.CFax.Text = list["CFax"].ToString();
                    this.HMoveTel.Text = list["HMoveTel"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.QQNum.Text = list["QQNum"].ToString();
                    this.MsnNum.Text = list["MsnNum"].ToString();
                    this.Remark.Text = this.pulicss.TbToLb(list["Remark"].ToString());
                }
                list.Close();
            }
        }
    }
}


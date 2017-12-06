namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyGroup_show : Page
    {
        protected Label BothDay;
        protected Button Button2;
        protected Label CAddress;
        protected Label CFax;
        protected Label Children;
        protected Label CName;
        protected Label CTel;
        protected Label CZipCode;
        protected Label Email;
        protected HtmlForm form1;
        protected Label GroupName;
        protected Label HAddress;
        protected HtmlHead Head1;
        protected Label HMoveTel;
        protected Label HTel;
        protected Label HXiaoTel;
        protected Label HZipCode;
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
        protected Label Spouses;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyGroup.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_MyGroup where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.GroupName.Text = this.pulicss.TypeCode("qp_oa_GroupType", list["GroupName"].ToString());
                    this.Sex.Text = list["Sex"].ToString();
                    this.BothDay.Text = list["BothDay"].ToString();
                    this.OtherName.Text = list["OtherName"].ToString();
                    this.Post.Text = list["Post"].ToString();
                    this.Spouses.Text = list["Spouses"].ToString();
                    this.Children.Text = list["Children"].ToString();
                    this.CName.Text = list["CName"].ToString();
                    this.CAddress.Text = list["CAddress"].ToString();
                    this.CZipCode.Text = list["CZipCode"].ToString();
                    this.CTel.Text = list["CTel"].ToString();
                    this.CFax.Text = list["CFax"].ToString();
                    this.HAddress.Text = list["HAddress"].ToString();
                    this.HZipCode.Text = list["HZipCode"].ToString();
                    this.HTel.Text = list["HTel"].ToString();
                    this.HMoveTel.Text = list["HMoveTel"].ToString();
                    this.HXiaoTel.Text = list["HXiaoTel"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.QQNum.Text = list["QQNum"].ToString();
                    this.MsnNum.Text = list["MsnNum"].ToString();
                    this.Remark.Text = this.pulicss.TbToLb(list["Remark"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


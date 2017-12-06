namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class OftenModle_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox ContractContent;
        protected TextBox ContractContentupdate;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList Sharing;
        protected TextBox SharingRealname;
        protected TextBox SharingUsername;
        protected DropDownList typename;

        public void BindAttribute()
        {
            this.SharingRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_OftenModle (Name,Content,Sharing,SharingUsername,SharingRealname,typeid,Username) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.pulicss.GetFormatStrmb(this.ContractContent.Text) + "','" + this.Sharing.SelectedValue + "','" + this.SharingUsername.Text + "','" + this.SharingRealname.Text + "','" + this.typename.SelectedValue + "','" + this.Session["Username"].ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增常用模版", "常用模版设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OftenModle.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OftenModle.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_OftenModleType where username='" + this.Session["username"] + "' order by id asc";
                this.list.Bind_DropDownList(this.typename, sQL, "id", "name");
                this.BindAttribute();
            }
        }
    }
}


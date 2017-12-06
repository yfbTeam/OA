namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class OftenModle_update : Page
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
            string str;
            if (this.Sharing.SelectedValue == "否")
            {
                str = string.Concat(new object[] { "Update qp_oa_OftenModle    Set Name='", this.Name.Text, "',typeid='", this.typename.SelectedValue, "',Sharing='", this.Sharing.SelectedValue, "',SharingUsername='',SharingRealname='',Content='", this.pulicss.GetFormatStrmb(this.ContractContent.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                this.List.ExeSql(str);
            }
            else
            {
                str = string.Concat(new object[] { 
                    "Update qp_oa_OftenModle    Set Name='", this.Name.Text, "',typeid='", this.typename.SelectedValue, "',Sharing='", this.Sharing.SelectedValue, "',SharingUsername='", this.SharingUsername.Text, "',SharingRealname='", this.SharingRealname.Text, "',Content='", this.pulicss.GetFormatStrmb(this.ContractContent.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], 
                    "'"
                 });
                this.List.ExeSql(str);
            }
            this.pulicss.InsertLog("修改常用模版", "常用模版设置");
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
                string sql = string.Concat(new object[] { "select * from qp_oa_OftenModle where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Sharing.SelectedValue = list["Sharing"].ToString();
                    this.SharingUsername.Text = list["SharingUsername"].ToString();
                    this.SharingRealname.Text = list["SharingRealname"].ToString();
                    this.typename.SelectedValue = list["typeid"].ToString();
                    this.ContractContentupdate.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


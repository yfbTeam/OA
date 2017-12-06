namespace xyoa.SystemManage.Juese
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Juese_klqx : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Name;
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select Perstr from qp_oa_Juese  where id='" + this.JueseId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "Update qp_oa_Juese   Set Perstr='", list["Perstr"].ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str2);
                if (this.CheckBox1.Checked)
                {
                    string str3 = string.Concat(new object[] { "Update qp_oa_username  Set ResponQx='", list["Perstr"].ToString(), "' where JueseId='", int.Parse(base.Request.QueryString["id"]), "' and IfResponUpdate='1'" });
                    this.List.ExeSql(str3);
                }
                this.pulicss.InsertLog("克隆角色[" + this.Name.Text + "]", "角色管理");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Juese.aspx'</script>");
            }
            list.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Juese.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_Juese where id!='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' order by id asc";
                this.list.Bind_DropDownList_nothing(this.JueseId, sQL, "id", "name");
                this.BindAttribute();
                string sql = "select * from qp_oa_Juese  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["name"].ToString();
                }
                list.Close();
            }
        }
    }
}


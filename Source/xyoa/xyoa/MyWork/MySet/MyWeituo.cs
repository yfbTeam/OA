namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWeituo : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList States;
        protected TextBox Wtrealname;
        protected TextBox Wtusername;

        public void BindAttribute()
        {
            this.Wtrealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_MyWeituo  Set States='", this.States.SelectedValue, "',Wtusername='", this.Wtusername.Text, "',Wtrealname='", this.Wtrealname.Text, "'  where  Username='", this.Session["username"], "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置工作委托", "工作委托");
            base.Response.Write("<script language=javascript>alert('提交成功！');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MyWeituo where  Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.States.SelectedValue = list["States"].ToString();
                    this.Wtusername.Text = list["Wtusername"].ToString();
                    this.Wtrealname.Text = list["Wtrealname"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


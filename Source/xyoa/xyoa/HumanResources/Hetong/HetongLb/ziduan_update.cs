namespace xyoa.HumanResources.Hetong.HetongLb
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ziduan_update : Page
    {
        protected TextBox Bianhao;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Leixing;
        private Db List = new Db();
        protected TextBox Mingcheng;
        private publics pulicss = new publics();
        protected RadioButtonList Xianshi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_HetongZd  Set Mingcheng='", this.pulicss.GetFormatStr(this.Mingcheng.Text), "',Leixing='", this.Leixing.SelectedValue, "',Xianshi='", this.Xianshi.SelectedValue, "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_hr_HetongZd where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Bianhao.Text = list["Bianhao"].ToString();
                    this.Mingcheng.Text = list["Mingcheng"].ToString();
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                    this.Xianshi.SelectedValue = list["Xianshi"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


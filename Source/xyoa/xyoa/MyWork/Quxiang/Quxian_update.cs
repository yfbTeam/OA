namespace xyoa.MyWork.Quxiang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Quxian_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Nowtimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_Quxian  Set Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',Nowtimes='", this.pulicss.GetFormatStr(this.Nowtimes.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改我的去向", "人员去向");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyQuxiang.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyQuxiang.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_Quxian  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Nowtimes.Text = list["Nowtimes"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


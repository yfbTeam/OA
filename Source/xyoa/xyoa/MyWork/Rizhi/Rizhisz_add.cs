namespace xyoa.MyWork.Rizhi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Rizhisz_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox RyRealname;
        protected TextBox RyUsername;
        protected TextBox ZgRealname;
        protected TextBox ZgUsername;

        public void BindAttribute()
        {
            this.ZgRealname.Attributes.Add("readonly", "readonly");
            this.RyRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_Rizhisz where ZgUsername='" + this.pulicss.GetFormatStr(this.ZgUsername.Text) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('职员领导已存在！');</script>");
            }
            else
            {
                list.Close();
                string str2 = "insert into qp_oa_Rizhisz (ZgUsername,ZgRealname,RyUsername,RyRealname) values ('" + this.pulicss.GetFormatStr(this.ZgUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZgRealname.Text) + "','" + this.pulicss.GetFormatStr(this.RyUsername.Text) + "','" + this.pulicss.GetFormatStr(this.RyRealname.Text) + "')";
                this.List.ExeSql(str2);
                this.pulicss.InsertLog("新增日志设置", "日志设置");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Rizhisz.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Rizhisz.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
            }
        }
    }
}


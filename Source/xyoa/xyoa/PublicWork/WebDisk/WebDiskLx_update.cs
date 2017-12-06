namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WebDiskLx_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_WebDiskLx  Set  Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Paixun='", this.Paixun.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改硬盘目录", "网络硬盘目录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WebDiskLx.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WebDiskLx.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("jjjja1c", this.Session["perstr"].ToString());
                string sql = "select * from qp_oa_WebDiskLx  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


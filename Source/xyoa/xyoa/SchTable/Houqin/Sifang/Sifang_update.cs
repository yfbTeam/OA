namespace xyoa.SchTable.Houqin.Sifang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Sifang_update : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected TextBox Buwei;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Qingkuan;
        protected TextBox Renyuan;
        protected TextBox Shijian;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Sifang     Set Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Buwei='", this.pulicss.GetFormatStr(this.Buwei.Text), "',Qingkuan='", this.pulicss.GetFormatStr(this.Qingkuan.Text), "',Renyuan='", this.pulicss.GetFormatStr(this.Renyuan.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "',UserName='", this.Session["Username"].ToString(), "',RealName='", this.Session["Realname"].ToString(), "' where   id='", int.Parse(base.Request.QueryString["id"]), 
                "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改四防安全检查[" + this.Shijian.Text + "]", "四防安全检查");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Sifang.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Sifang where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Buwei.Text = list["Buwei"].ToString();
                    this.Qingkuan.Text = list["Qingkuan"].ToString();
                    this.Renyuan.Text = list["Renyuan"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


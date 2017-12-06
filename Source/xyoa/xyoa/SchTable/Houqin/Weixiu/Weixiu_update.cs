namespace xyoa.SchTable.Houqin.Weixiu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Weixiu_update : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Renyuan;
        protected TextBox Shijian;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_sch_Weixiu     Set Neirong='", this.pulicss.GetFormatStr(this.Neirong.Text), "',Renyuan='", this.pulicss.GetFormatStr(this.Renyuan.Text), "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "',UserName='", this.Session["Username"].ToString(), "',RealName='", this.Session["Realname"].ToString(), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改维修记录", "维修记录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Weixiu.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Weixiu where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Neirong.Text = list["Neirong"].ToString();
                    this.Renyuan.Text = list["Renyuan"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


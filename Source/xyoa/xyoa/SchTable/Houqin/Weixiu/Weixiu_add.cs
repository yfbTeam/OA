namespace xyoa.SchTable.Houqin.Weixiu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Weixiu_add : Page
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
            string sql = "insert into qp_sch_Weixiu   (Neirong,Renyuan,Shijian,Beizhu,UserName,RealName) values ('" + this.pulicss.GetFormatStr(this.Neirong.Text) + "','" + this.pulicss.GetFormatStr(this.Renyuan.Text) + "','" + this.pulicss.GetFormatStr(this.Shijian.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增维修记录", "维修记录");
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
                this.BindAttribute();
            }
        }
    }
}


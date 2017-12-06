namespace xyoa.MyWork.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRenwu_hb_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox SetTime;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:window.close();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_RenwuHb (dyid,Content,Username,Realname,SetTime) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["id"].ToString()) + "','" + this.pulicss.GetFormatStr(this.content.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增任务汇报", "任务汇报");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.reload();window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Realname.Text = this.Session["realname"].ToString();
                this.SetTime.Text = DateTime.Now.ToString();
                this.BindAttribute();
            }
        }
    }
}


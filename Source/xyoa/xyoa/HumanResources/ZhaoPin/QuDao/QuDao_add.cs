namespace xyoa.HumanResources.ZhaoPin.QuDao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class QuDao_add : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected TextBox Chengshi;
        protected TextBox Dianhua;
        protected TextBox Dizhi;
        protected TextBox Email;
        protected HtmlForm form1;
        protected TextBox Fuzeren;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Mingcheng;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Youbian;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_QuDao  (Mingcheng,Fuzeren,Dianhua,Email,Chengshi,Youbian,Dizhi,Beizhu) values ('" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "','" + this.pulicss.GetFormatStr(this.Fuzeren.Text) + "','" + this.pulicss.GetFormatStr(this.Dianhua.Text) + "','" + this.pulicss.GetFormatStr(this.Email.Text) + "','" + this.pulicss.GetFormatStr(this.Chengshi.Text) + "','" + this.pulicss.GetFormatStr(this.Youbian.Text) + "','" + this.pulicss.GetFormatStr(this.Dizhi.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增招聘渠道", "招聘渠道");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='QuDao.aspx'</script>");
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


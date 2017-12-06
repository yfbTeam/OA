namespace xyoa.HumanResources.KaoPing.YuangongBX
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongBX_add : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Riqi;
        protected TextBox SjRealname;
        protected TextBox SjUsername;

        public void BindAttribute()
        {
            this.SjRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_YuangongBX  (Riqi,SjUsername,SjRealname,Neirong,Username,Realname,SetTimes) values ('" + this.pulicss.GetFormatStr(this.Riqi.Text) + "','" + this.pulicss.GetFormatStr(this.SjUsername.Text) + "','" + this.pulicss.GetFormatStr(this.SjRealname.Text) + "','" + this.pulicss.GetFormatStrbjq(this.Neirong.Value) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增[" + this.pulicss.GetFormatStr(this.SjRealname.Text) + "]员工表现", "员工表现");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongBX.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Riqi.Text = DateTime.Now.ToShortDateString();
                this.BindAttribute();
            }
        }
    }
}


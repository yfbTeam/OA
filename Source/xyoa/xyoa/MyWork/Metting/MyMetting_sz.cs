namespace xyoa.MyWork.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyMetting_sz : Page
    {
        protected Button Button1;
        protected TextBox DlRealname;
        protected TextBox DlUsername;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.DlRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_MettingApply  Set NbPeopleUser=NbPeopleUser+'" + this.DlUsername.Text + ",',  NbPeopleName=NbPeopleName+'" + this.DlRealname.Text + "(代理：" + this.Session["realname"].ToString() + "),' where ID='" + base.Request.QueryString["id"] + "'";
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "insert into qp_oa_MettingApply_Daili (Hyid,Username,Realname,DlUsername,DlRealname) values ('", base.Request.QueryString["id"], "','", this.Session["username"], "','", this.Session["realname"], "','", this.pulicss.GetFormatStr(this.DlUsername.Text), "','", this.pulicss.GetFormatStr(this.DlRealname.Text), "')" });
            this.List.ExeSql(str2);
            this.pulicss.InsertMessage("您有会议需要代理参加，发起人：" + this.Session["realname"] + "", this.DlUsername.Text, this.DlRealname.Text, "/MyWork/Metting/MyMetting.aspx");
            this.pulicss.InsertLog("设置会议代理人", "我的会议");
            base.Response.Write("<script language=javascript>alert('设置成功！');window.dialogArguments.window.location.href='MyMetting.aspx'; window.close()</script>");
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


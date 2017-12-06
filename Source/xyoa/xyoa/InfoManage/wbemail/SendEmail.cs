namespace xyoa.InfoManage.wbemail
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class SendEmail : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected FCKeditor Content;
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Settimes;
        protected TextBox Title;
        protected TextBox toemail;
        protected DropDownList youxiang;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str2;
            string sql = "select * from qp_oa_Emailprv   where id='" + this.youxiang.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str2 = string.Concat(new object[] { 
                    "insert into qp_crm_CustomerLx  (Title,Content,smtp,toemail,email,zhanghao,yxmima,edit_flag,Username,Realname,Settimes) values ('", this.pulicss.GetFormatStr(this.Title.Text), "','", this.pulicss.GetFormatStrbjq(this.Content.Value), "','", list["Smtp"].ToString(), "','", this.pulicss.GetFormatStr(this.toemail.Text), "','", list["EmailAdd"].ToString(), "','", list["EmailUserName"].ToString(), "','", list["EmailPassword"].ToString(), "','0','", this.Session["username"], 
                    "','", this.Session["realname"], "','", this.Settimes.Text, "')"
                 });
                this.List.ExeSql(str2);
            }
            else
            {
                str2 = string.Concat(new object[] { "insert into qp_crm_CustomerLx  (Title,Content,smtp,toemail,email,zhanghao,yxmima,edit_flag,Username,Realname,Settimes) values ('", this.pulicss.GetFormatStr(this.Title.Text), "','", this.pulicss.GetFormatStrbjq(this.Content.Value), "','','", this.pulicss.GetFormatStr(this.toemail.Text), "','','','','0','", this.Session["username"], "','", this.Session["realname"], "','", this.Settimes.Text, "')" });
                this.List.ExeSql(str2);
            }
            list.Close();
            this.pulicss.InsertLog("发送外部邮件", "外部邮件");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OutEmail.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OutEmail.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,EmailName  from qp_oa_Emailprv where Username='" + this.Session["username"] + "' order by id asc";
                this.list.Bind_DropDownList_kong(this.youxiang, sQL, "id", "EmailName");
                this.Settimes.Text = DateTime.Now.ToString();
                this.BindAttribute();
            }
        }
    }
}


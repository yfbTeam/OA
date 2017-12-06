namespace xyoa.InfoManage.messages
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Messages_add : Page
    {
        protected TextBox acceptrealname;
        protected TextBox acceptusername;
        protected Button Button1;
        protected TextBox Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.acceptrealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            str2 = "" + this.acceptusername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + "'" + strArray[i] + "',";
            }
            str = str + "'0'";
            string sql = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str + ") ";
            SqlDataReader reader = this.List.GetList(sql);
            while (reader.Read())
            {
                this.pulicss.InsertMessage(this.Content.Text, reader["username"].ToString(), reader["realname"].ToString(), "/InfoManage/messages/Messages.aspx");
            }
            reader.Close();
            this.pulicss.InsertLog("发送内部消息", "内部消息");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Messages_yf.aspx'</script>");
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
                if (base.Request.QueryString["user"] != null)
                {
                    this.acceptusername.Text = "" + base.Server.UrlDecode(base.Request.QueryString["user"]) + ",";
                    this.acceptrealname.Text = "" + base.Server.UrlDecode(base.Request.QueryString["name"]) + ",";
                }
            }
        }
    }
}


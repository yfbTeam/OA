namespace xyoa.pda.InfoManage.nbemail
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class NbEmail_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button5;
        protected Button Button6;
        protected TextBox Content;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox JsRealname;
        protected TextBox JsUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox titles;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.JsRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
            this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
            this.Button5.Attributes["onclick"] = "javascript:return delfj();";
            this.Button6.Attributes["onclick"] = "javascript:return checkForm();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("NbEmail_sj.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            str2 = "" + this.JsUsername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + "'" + strArray[i] + "',";
            }
            str = str + "'0'";
            string sql = "select username,realname from qp_oa_Username where  username in (" + str + ") ";
            SqlDataReader reader = this.List.GetList(sql);
            while (reader.Read())
            {
                string str4 = string.Concat(new object[] { 
                    "insert into qp_oa_NbEmail_sj  (Number,Titles,Content,JsUsername,JsRealname,IfRead,IfDel,FsUsername,FsRealname,FsTime) values ('", this.Number.Text, "','", this.pulicss.GetFormatStr(this.titles.Text), "','", this.pulicss.GetFormatStr(this.Content.Text), "','", reader["username"], "','", reader["realname"], "','0','0','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(str4);
                this.pulicss.InsertMessage(string.Concat(new object[] { "您有内部邮件需要接收：", this.pulicss.GetFormatStr(this.titles.Text), "，发送人：", this.Session["realname"], "" }), reader["username"].ToString(), reader["realname"].ToString(), "/InfoManage/nbemail/NbEmail_sj.aspx");
            }
            reader.Close();
            string str5 = string.Concat(new object[] { 
                "insert into qp_oa_NbEmail_fj  (Number,Titles,Content,JsUsername,JsRealname,FsUsername,FsRealname,FsTime) values ('", this.Number.Text, "','", this.pulicss.GetFormatStr(this.titles.Text), "','", this.pulicss.GetFormatStr(this.Content.Text), "','", this.JsUsername.Text, "','", this.JsRealname.Text, "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(str5);
            this.pulicss.InsertLog("发送内部邮件", "内部邮件");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NbEmail_fj.aspx'</script>");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string sql = "Delete from qp_oa_fileupload where NewName='" + this.fjlb.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.BindFjlbList();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/InfoManage/nbemail/email/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                Random random = new Random();
                string str6 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str6;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                string filetype = this.pulicss.Getfiletype(extension);
                this.pulicss.Insertfile(fileName, "InfoManage/nbemail/email/" + str2 + "", this.Number.Text, filetype);
                this.pulicss.InsertLog("上传附件[" + fileName + "]", "内部邮件");
                this.BindFjlbList();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                if (base.Request.QueryString["FsUsername"] != null)
                {
                    this.JsUsername.Text = "" + base.Server.UrlDecode(base.Request.QueryString["FsUsername"]) + ",";
                    this.JsRealname.Text = "" + base.Server.UrlDecode(base.Request.QueryString["FsRealname"]) + ",";
                    string sql = string.Concat(new object[] { "select Titles from qp_oa_NbEmail_sj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["backid"]), "' and (JsUsername='", this.Session["username"], "')" });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.titles.Text = "回复：" + list["Titles"] + "";
                    }
                    list.Close();
                }
                this.BindAttribute();
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.ViewState["pdauer"] = this.pulicss.pdauser();
            }
        }
    }
}


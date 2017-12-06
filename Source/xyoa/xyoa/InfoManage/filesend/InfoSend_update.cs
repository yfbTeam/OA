namespace xyoa.InfoManage.filesend
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class InfoSend_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox JsRealname;
        protected TextBox JsUsername;
        private Db List = new Db();
        protected Label Name;
        private publics pulicss = new publics();
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.JsRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str8;
            if (this.CheckBox1.Checked)
            {
                string str = base.Server.MapPath("UpLoad/");
                string str2 = string.Empty;
                string str3 = string.Empty;
                if (this.uploadFile.PostedFile.ContentLength == 0)
                {
                    base.Response.Write("<script language=javascript>alert('请先选择上传的文件！');</script>");
                    return;
                }
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str8 = string.Concat(new object[] { "Update qp_oa_InfoSend  Set  Name='", fileName, "',Filetype='", extension.Replace(".", ""), "',Newname='InfoManage/filesend/UpLoad/", str2, "',JsUsername='", this.pulicss.GetFormatStr(this.JsUsername.Text), "',JsRealname='", this.JsRealname.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  and username='", this.Session["username"], "' " });
                this.List.ExeSql(str8);
            }
            else
            {
                str8 = string.Concat(new object[] { "Update qp_oa_InfoSend  Set  JsUsername='", this.pulicss.GetFormatStr(this.JsUsername.Text), "',JsRealname='", this.JsRealname.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  and username='", this.Session["username"], "' " });
                this.List.ExeSql(str8);
            }
            this.pulicss.InsertLog("修改文件传阅", "文件传阅");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='InfoSend.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InfoSend.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_InfoSend  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'  and username='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.JsUsername.Text = list["JsUsername"].ToString();
                    this.JsRealname.Text = list["JsRealname"].ToString();
                    this.Name.Text = "<img src=\"/oaimg/filetype/" + list["Filetype"].ToString() + ".gif\" /><a href='/" + list["Newname"].ToString() + "' target=_blank>" + list["Name"].ToString() + "</a>";
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


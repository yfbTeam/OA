namespace xyoa.SystemManage.Seal
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class SealManagePb_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox QxRealname;
        protected TextBox QxUsername;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.QxRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return checkForm();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = FormsAuthentication.HashPasswordForStoringInConfigFile("666666", "MD5");
            string str2 = base.Server.MapPath("/seal/");
            string str3 = string.Empty;
            string str4 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                string str8 = this.Session["FjKey"].ToString();
                if (!this.pulicss.scquanstr(extension, str8))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str9 = random.Next(0x2710).ToString();
                str4 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str9;
                this.uploadFile.PostedFile.SaveAs(str2 + str4 + extension);
                str3 = str4 + extension;
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_YinZhangPb  (Number,Name,Oldname,Newname,Password,State,Username,Realname,Nowtimes) values ('", this.Number.Text, "','", this.pulicss.GetFormatStr(this.Name.Text), "','", fileName, "','", str3, "','", str, "','正常','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(sql);
                string str11 = null;
                string str12 = null;
                str12 = "" + this.QxUsername.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = str12.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    str11 = str11 + "'" + strArray[i] + "',";
                }
                str11 = str11 + "'0'";
                string str13 = "select username,realname from qp_oa_Username where  username in (" + str11 + ") ";
                SqlDataReader reader = this.List.GetList(str13);
                while (reader.Read())
                {
                    this.pulicss.InsertMessage("有新的公章[" + this.Name.Text + "]发布，请注意查看！默认密码为：666666，请注意修改密码！", reader["username"].ToString(), reader["realname"].ToString(), "/MyWork/YinZhang/MyYinZhang.aspx");
                    string str14 = string.Concat(new object[] { 
                        "insert into qp_oa_YinZhang  (Number,Name,Oldname,Newname,Password,YxType,State,Username,Realname,Nowtimes) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','", this.pulicss.GetFormatStr(this.Name.Text), "','", fileName, "','", str3, "','", str, "','公章','正常','", reader["username"], "','", reader["realname"], "','", DateTime.Now.ToString(), 
                        "')"
                     });
                    this.List.ExeSql(str14);
                }
                reader.Close();
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请先选择上传的文件！');</script>");
                return;
            }
            this.pulicss.InsertLog("新增我的印章[" + this.Name.Text + "]", "我的印章");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SealManagePb.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SealManagePb.aspx");
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
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                this.BindAttribute();
            }
        }
    }
}


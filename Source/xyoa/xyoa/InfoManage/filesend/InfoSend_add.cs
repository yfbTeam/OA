namespace xyoa.InfoManage.filesend
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class InfoSend_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        protected TextBox JsRealname;
        protected TextBox JsUsername;
        protected Label lblMessage;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.JsRealname.Attributes.Add("readonly", "readonly");
            this.pulicss.QuanXianVis(this.IMG1, ",12,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.CheckBox2, ",12,", this.pulicss.GetSms());
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            this.lblMessage.Visible = false;
            HttpFileCollection files = HttpContext.Current.Request.Files;
            StringBuilder builder = new StringBuilder("");
            if (builder.Length <= 0)
            {
                string path = base.Server.MapPath("UpLoad");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Random random = new Random();
                int num = 1;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fileName = "";
                    string extension = "";
                    string rightName = "";
                    fileName = Path.GetFileName(file.FileName);
                    rightName = Path.GetExtension(file.FileName);
                    string filetype = this.pulicss.Getfiletype(rightName);
                    string str6 = random.Next(100, 0x5f5e100).ToString() + num.ToString();
                    string str7 = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str6;
                    if (fileName.Length > 0)
                    {
                        extension = Path.GetExtension(file.FileName);
                        string filename = path + @"\" + str7 + extension;
                        file.SaveAs(filename);
                        string str9 = string.Concat(new object[] { 
                            "insert into qp_oa_InfoSend (Name,NewName,Filetype,JsUsername,JsRealname,YdUsername,YdRealname,Username,Realname,Settime) values ('", fileName, "','InfoManage/filesend/UpLoad/", str7, "", extension, "','", filetype, "','", this.JsUsername.Text, "','", this.JsRealname.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], 
                            "','", DateTime.Now.ToString(), "')"
                         });
                        this.List.ExeSql(str9);
                    }
                    num++;
                }
                this.pulicss.InsertLog("文件传阅", "文件传阅");
                string str10 = null;
                string str11 = null;
                str11 = "" + this.JsUsername.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = str11.Split(new char[] { ',' });
                for (int j = 0; j < strArray.Length; j++)
                {
                    str10 = str10 + "'" + strArray[j] + "',";
                }
                str10 = str10 + "'0'";
                string sql = "select username,realname,MoveTel from qp_oa_Username where  username in (" + str10 + ") ";
                SqlDataReader reader = this.List.GetList(sql);
                while (reader.Read())
                {
                    if (this.CheckBox1.Checked)
                    {
                        this.pulicss.InsertMessage("您有文件传阅需要接收", reader["username"].ToString(), reader["realname"].ToString(), "/InfoManage/filesend/JsInfoSend.aspx");
                    }
                    if (this.CheckBox2.Checked)
                    {
                        this.pulicss.InsertSmsSjUser(reader["MoveTel"].ToString(), "您有文件传阅需要接收", DateTime.Now.ToString(), this.Session["username"].ToString(), this.Session["realname"].ToString());
                    }
                }
                reader.Close();
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.location = 'InfoSend.aspx'</script>");
            }
            else
            {
                this.lblMessage.Text = builder.ToString();
                this.lblMessage.Visible = true;
            }
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
                this.BindAttribute();
            }
        }
    }
}


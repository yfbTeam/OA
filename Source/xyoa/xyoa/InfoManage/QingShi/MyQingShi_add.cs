namespace xyoa.InfoManage.QingShi
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyQingShi_add : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected CheckBox C1;
        protected CheckBox CheckBox2;
        protected FCKeditor Content;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        protected TextBox JsRealname;
        protected TextBox JsUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Titles;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.CheckBox2, ",11,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG1, ",11,", this.pulicss.GetSms());
            this.JsRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_QingShi (Number,Titles,Content,State,JsUsername,JsRealname,Pizhu,PzTime,TxTime,Username,Realname) values ('" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.pulicss.GetFormatStr(this.Titles.Text) + "','" + this.pulicss.GetFormatStrbjq(this.Content.Value) + "','等待批阅','" + this.pulicss.GetFormatStr(this.JsUsername.Text) + "','" + this.JsRealname.Text + "','','','" + DateTime.Now.ToString() + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增请示报告", "请示报告");
            if (this.C1.Checked)
            {
                this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的请示报告“", this.Titles.Text, "”需要批阅，请示人：", this.Session["realname"], "" }), this.JsUsername.Text, this.JsRealname.Text, "/InfoManage/QingShi/QingShiList.aspx");
            }
            if (this.CheckBox2.Checked)
            {
                string str2 = "select username,MoveTel from qp_oa_Username where  username='" + this.JsUsername.Text + "' ";
                SqlDataReader list = this.List.GetList(str2);
                if (list.Read())
                {
                    this.pulicss.InsertSms(list["MoveTel"].ToString(), string.Concat(new object[] { "您有新的请示报告需要批阅：", this.Titles.Text, "，请示人：", this.Session["realname"], "" }));
                }
                list.Close();
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyQingShi.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyQingShi.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                }
                else if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                }
                else
                {
                    Random random = new Random();
                    string str7 = random.Next(0x2710).ToString();
                    str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                    this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string filetype = this.pulicss.Getfiletype(extension);
                    this.pulicss.Insertfile(fileName, "InfoManage/QingShi/file/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "请示报告");
                    this.BindFjlbList();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    Random random = new Random();
                    string str = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}


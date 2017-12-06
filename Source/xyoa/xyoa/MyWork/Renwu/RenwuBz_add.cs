namespace xyoa.MyWork.Renwu
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RenwuBz_add : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected CheckBox C1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
        protected CheckBox CheckBox5;
        protected FCKeditor Content;
        protected TextBox Endtime;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected DropDownList HbDay;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        protected HtmlImage IMG2;
        protected TextBox JbRealname;
        protected TextBox JbUsername;
        protected TextBox Jkrealname;
        protected TextBox Jkusername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected TextBox titles;
        protected HtmlInputFile uploadFile;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",2,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.CheckBox2, ",2,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG2, ",2,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.CheckBox5, ",2,", this.pulicss.GetSms());
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.JbRealname.Attributes.Add("readonly", "readonly");
            this.Jkrealname.Attributes.Add("readonly", "readonly");
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
            string sql = "insert into qp_oa_Renwu (Jkusername,Jkrealname,Number,titles,Content,Starttime,Endtime,ZbUsername,ZbRealname,JbUsername,JbRealname,HbDay,State,Username,Realname,SetTime) values ('" + this.pulicss.GetFormatStr(this.Jkusername.Text) + "','" + this.pulicss.GetFormatStr(this.Jkrealname.Text) + "','" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.pulicss.GetFormatStr(this.titles.Text) + "','" + this.pulicss.GetFormatStrbjq(this.Content.Value) + "','" + this.pulicss.GetFormatStr(this.Starttime.Text) + "','" + this.pulicss.GetFormatStr(this.Endtime.Text) + "','" + this.pulicss.GetFormatStr(this.ZbUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZbRealname.Text) + "','" + this.pulicss.GetFormatStr(this.JbUsername.Text) + "','" + this.pulicss.GetFormatStr(this.JbRealname.Text) + "','" + this.HbDay.SelectedValue + "','进行中','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增任务", "任务布置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='RenwuBz.aspx'</script>");
            if (this.C1.Checked)
            {
                this.pulicss.InsertMessage("您有新的任务需要参加：" + this.titles.Text + "", this.ZbUsername.Text, this.ZbRealname.Text, "/MyWork/Renwu/MyRenwu.aspx");
            }
            if (this.CheckBox2.Checked)
            {
                string str2 = "select username,MoveTel from qp_oa_Username where  username='" + this.ZbUsername.Text + "' ";
                SqlDataReader reader = this.List.GetList(str2);
                if (reader.Read())
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), "您有新的任务需要参加：" + this.titles.Text + "");
                }
                reader.Close();
            }
            string str3 = null;
            string str4 = null;
            str4 = "" + this.JbUsername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str4.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str3 = str3 + "'" + strArray[i] + "',";
            }
            str3 = str3 + "'0'";
            string str5 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str3 + ") ";
            SqlDataReader reader2 = this.List.GetList(str5);
            while (reader2.Read())
            {
                if (this.CheckBox3.Checked)
                {
                    this.pulicss.InsertMessage("您有新的任务需要参加：" + this.titles.Text + "", reader2["username"].ToString(), reader2["realname"].ToString(), "/MyWork/Renwu/MyRenwuXb.aspx");
                }
                if (this.CheckBox5.Checked)
                {
                    this.pulicss.InsertSms(reader2["MoveTel"].ToString(), "您有新的任务需要参加：" + this.titles.Text + "");
                }
            }
            reader2.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("RenwuBz.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("renwufilie/");
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
                    this.pulicss.Insertfile(fileName, "MyWork/Renwu/renwufilie/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "任务布置");
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


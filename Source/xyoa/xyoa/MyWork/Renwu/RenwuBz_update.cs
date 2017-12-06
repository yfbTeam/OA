namespace xyoa.MyWork.Renwu
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

    public class RenwuBz_update : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected FCKeditor Content;
        protected TextBox Endtime;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected DropDownList HbDay;
        protected HtmlHead Head1;
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
            this.Jkrealname.Attributes.Add("readonly", "readonly");
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.JbRealname.Attributes.Add("readonly", "readonly");
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
            string sql = string.Concat(new object[] { 
                "Update qp_oa_Renwu  Set  Jkusername='", this.pulicss.GetFormatStr(this.Jkusername.Text), "',Jkrealname='", this.pulicss.GetFormatStr(this.Jkrealname.Text), "',titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "',Endtime='", this.pulicss.GetFormatStr(this.Endtime.Text), "',ZbUsername='", this.pulicss.GetFormatStr(this.ZbUsername.Text), "',ZbRealname='", this.pulicss.GetFormatStr(this.ZbRealname.Text), 
                "',JbUsername='", this.pulicss.GetFormatStr(this.JbUsername.Text), "',JbRealname='", this.pulicss.GetFormatStr(this.JbRealname.Text), "',HbDay='", this.HbDay.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  and username='", this.Session["username"], "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改任务", "任务布置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='RenwuBz.aspx'</script>");
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
                    string sql = string.Concat(new object[] { "select * from qp_oa_Renwu  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "' " });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.titles.Text = list["titles"].ToString();
                        this.Starttime.Text = DateTime.Parse(list["Starttime"].ToString()).ToShortDateString();
                        this.Endtime.Text = DateTime.Parse(list["Endtime"].ToString()).ToShortDateString();
                        this.ZbUsername.Text = list["ZbUsername"].ToString();
                        this.ZbRealname.Text = list["ZbRealname"].ToString();
                        this.JbUsername.Text = list["JbUsername"].ToString();
                        this.JbRealname.Text = list["JbRealname"].ToString();
                        this.HbDay.SelectedValue = list["HbDay"].ToString();
                        this.Content.Value = list["Content"].ToString();
                        this.Jkusername.Text = list["Jkusername"].ToString();
                        this.Jkrealname.Text = list["Jkrealname"].ToString();
                    }
                    list.Close();
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}


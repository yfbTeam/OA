namespace xyoa.MyWork.Richeng
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

    public class RichengmyList_update : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button3;
        protected Button Button4;
        protected CheckBox CheckBox1;
        protected FCKeditor Content;
        protected TextBox EndTime;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected DropDownList Gongkai;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox StartTime;
        protected TextBox titles;
        protected TextBox txtime;
        protected DropDownList Types;
        protected HtmlInputFile uploadFile;
        protected TextBox XbRealname;
        protected TextBox XbUsername;

        public void BindAttribute()
        {
            this.XbRealname.Attributes.Add("readonly", "readonly");
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
                "Update qp_oa_MyRicheng  Set  XbUsername='", this.pulicss.GetFormatStr(this.XbUsername.Text), "',XbRealname='", this.pulicss.GetFormatStr(this.XbRealname.Text), "',Gongkai='", this.Gongkai.SelectedValue, "',titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',Starttime='", this.pulicss.GetFormatStr(this.StartTime.Text), "',Endtime='", this.pulicss.GetFormatStr(this.EndTime.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), 
                "'  and username='", this.Session["username"], "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改日程", "我的日程");
            if (this.CheckBox1.Checked)
            {
                this.pulicss.InsertNaoZhong("提醒日程安排：" + this.pulicss.GetFormatStr(this.titles.Text) + "", this.txtime.Text, this.Types.SelectedValue, "1", "0", "/MyWork/Richeng/RichengmyList.aspx");
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='RichengmyList.aspx'</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("richengrile/");
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
                    this.pulicss.Insertfile(fileName, "MyWork/Richeng/richengrile/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "我的日程");
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
                    string sql = string.Concat(new object[] { "select * from qp_oa_MyRicheng  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "' " });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.titles.Text = list["titles"].ToString();
                        this.StartTime.Text = list["Starttime"].ToString();
                        this.EndTime.Text = list["Endtime"].ToString();
                        this.Content.Value = list["Content"].ToString();
                        this.Gongkai.SelectedValue = list["Gongkai"].ToString();
                        this.XbUsername.Text = list["XbUsername"].ToString();
                        this.XbRealname.Text = list["XbRealname"].ToString();
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('无相关信息！');window.location.href='Richengmy.aspx'</script>");
                        return;
                    }
                    list.Close();
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}


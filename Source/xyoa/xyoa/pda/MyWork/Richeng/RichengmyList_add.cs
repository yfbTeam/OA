namespace xyoa.pda.MyWork.Richeng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RichengmyList_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button5;
        protected Button Button6;
        protected TextBox Content;
        protected TextBox EndTime;
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
        protected HtmlInputFile uploadFile;
        protected TextBox XbRealname;
        protected TextBox XbUsername;

        public void BindAttribute()
        {
            this.StartTime.Attributes.Add("readonly", "readonly");
            this.EndTime.Attributes.Add("readonly", "readonly");
            this.XbRealname.Attributes.Add("readonly", "readonly");
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
            base.Response.Redirect("RichengRi.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_MyRicheng (XbUsername,XbRealname,Gongkai,Number,titles,Content,StartTime,EndTime,Username,Realname) values ('" + this.pulicss.GetFormatStr(this.XbUsername.Text) + "','" + this.pulicss.GetFormatStr(this.XbRealname.Text) + "','" + this.Gongkai.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.pulicss.GetFormatStr(this.titles.Text) + "','" + this.pulicss.GetFormatStr(this.Content.Text) + "','" + this.pulicss.GetFormatStr(this.StartTime.Text) + "','" + this.pulicss.GetFormatStr(this.EndTime.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增日程", "我的日程");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='RichengRi.aspx'</script>");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string sql = "Delete from qp_oa_fileupload where NewName='" + this.fjlb.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.BindFjlbList();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/MyWork/Richeng/richengrile/");
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
                this.pulicss.Insertfile(fileName, "MyWork/Richeng/richengrile/" + str2 + "", this.Number.Text, filetype);
                this.pulicss.InsertLog("上传附件[" + fileName + "]", "我的日程");
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
                this.BindAttribute();
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.ViewState["pdauer"] = this.pulicss.pdauser();
            }
        }
    }
}


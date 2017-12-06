namespace xyoa.SystemManage.DocumentModle
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DocumentModle_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected HtmlInputFile uploadFile;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                if ((extension != ".doc") && (extension != ".DOC"))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！只允许上传DOC文件');</script>");
                    return;
                }
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                string sql = "insert into qp_oa_DocumentModle (Name,Newname,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,Paixun) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + str2 + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + this.pulicss.GetFormatStr(this.Paixun.Text) + "')";
                this.List.ExeSql(sql);
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请先选择上传的文件！');</script>");
                return;
            }
            this.pulicss.InsertLog("新增红头文件", "红头文件管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='DocumentModle.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("DocumentModle.aspx");
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


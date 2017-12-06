namespace xyoa.PublicWork.TupianNew
{
    using FredCK.FCKeditorV2;
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TupianNewMg_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected FCKeditor Content;
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected DropDownList States;
        protected TextBox titles;
        protected HtmlInputFile uploadFile;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("tupian/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
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
                    string sql = "insert into qp_oa_TupianNew  (Photo,titles,Content,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,YdUsername,YdRealname,Settime,Username,Realname,ScUsername) values ('PublicWork/TupianNew/tupian/" + str2 + "','" + this.pulicss.GetFormatStr(this.titles.Text) + "','" + this.pulicss.GetFormatStrbjq(this.Content.Value) + "','" + this.States.SelectedValue + "','" + this.ZdBumenId.Text + "','" + this.ZdBumen.Text + "','" + this.ZdUsername.Text + "','" + this.ZdRealname.Text + "','','','" + DateTime.Now.ToString() + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','')";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("新增图片新闻", "图片新闻");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='TupianNewMg.aspx'</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("TupianNewMg.aspx");
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


namespace xyoa.PublicWork.TupianNew
{
    using FredCK.FCKeditorV2;
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TupianNewMg_update : Page
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
        protected Image Photo;
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
            string str8;
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
                    str8 = string.Concat(new object[] { 
                        "Update qp_oa_TupianNew  Set  Photo='PublicWork/TupianNew/tupian/", str2, "',titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, 
                        "',Settime='", DateTime.Now.ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
                     });
                    this.List.ExeSql(str8);
                    this.pulicss.InsertLog("修改图片新闻", "图片新闻");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='TupianNewMg.aspx'</script>");
                }
            }
            else
            {
                str8 = string.Concat(new object[] { 
                    "Update qp_oa_TupianNew  Set  titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',Settime='", DateTime.Now.ToString(), 
                    "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
                 });
                this.List.ExeSql(str8);
                this.pulicss.InsertLog("修改图片新闻", "图片新闻");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='TupianNewMg.aspx'</script>");
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
                string sql = "select * from qp_oa_TupianNew  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Photo.ImageUrl = "/" + list["Photo"].ToString() + "";
                    this.titles.Text = list["titles"].ToString();
                    this.Content.Value = list["Content"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


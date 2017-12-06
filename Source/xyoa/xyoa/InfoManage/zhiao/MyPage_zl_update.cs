namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPage_zl_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        public string Contents;
        public string fjkey;
        protected Label FjtypeLb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Leibie;
        protected TextBox LeibieName;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label RealnameXz;
        protected Label Settimes;
        protected DropDownList States;
        protected HtmlInputFile uploadFile;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyPage_zl.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str9;
            string str = base.Server.MapPath("UpLoad/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                string filetype = this.pulicss.Getfiletype(extension);
                Random random = new Random();
                string str8 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str8;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str9 = string.Concat(new object[] { 
                    "Update qp_oa_Zst_ziliao  Set  Leibie='", this.Leibie.Text, "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "", extension, "',NewName='InfoManage/zhiao/UpLoad/", str2, "',Filetype='", filetype, "',Settimes='", DateTime.Now.ToString(), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, 
                    "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], "'"
                 });
                this.List.ExeSql(str9);
            }
            else
            {
                str9 = string.Concat(new object[] { 
                    "Update qp_oa_Zst_ziliao  Set  Leibie='", this.Leibie.Text, "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "", this.FjtypeLb.Text, "',Settimes='", DateTime.Now.ToString(), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, 
                    "',ZdRealname='", this.ZdRealname.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], "'"
                 });
                this.List.ExeSql(str9);
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyPage_zl.aspx'</script>");
            this.pulicss.InsertLog("修改文件", "硬盘浏览");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_Zst_ziliao  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.Settimes.Text = list["Settimes"].ToString();
                    this.RealnameXz.Text = list["RealnameXz"].ToString();
                    this.LeibieName.Text = this.pulicss.TypeCode("qp_oa_Zst_leibie_zl", list["Leibie"].ToString());
                    this.Leibie.Text = list["Leibie"].ToString();
                    this.ViewState["NewNames"] = list["NewName"].ToString();
                    int length = list["Name"].ToString().LastIndexOf(".");
                    int num2 = list["Name"].ToString().Length - list["Name"].ToString().LastIndexOf(".");
                    this.Name.Text = list["Name"].ToString().Substring(0, length);
                    this.FjtypeLb.Text = list["Name"].ToString().Substring(length, num2);
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


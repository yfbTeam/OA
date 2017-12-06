namespace xyoa.SystemManage.DocumentModle
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DocumentModle_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected HtmlInputFile uploadFile;
        protected Label wenjian;
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
            string str8;
            if (this.CheckBox1.Checked)
            {
                string str = base.Server.MapPath("file/");
                string str2 = string.Empty;
                string str3 = string.Empty;
                if (this.uploadFile.PostedFile.ContentLength == 0)
                {
                    base.Response.Write("<script language=javascript>alert('请先选择上传的文件！');</script>");
                    return;
                }
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
                str8 = string.Concat(new object[] { 
                    "Update qp_oa_DocumentModle  Set  Newname='", str2, "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',Paixun='", this.Paixun.Text, 
                    "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
                 });
                this.List.ExeSql(str8);
            }
            else
            {
                str8 = string.Concat(new object[] { 
                    "Update qp_oa_DocumentModle  Set  Name='", this.pulicss.GetFormatStr(this.Name.Text), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',Paixun='", this.Paixun.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), 
                    "'  "
                 });
                this.List.ExeSql(str8);
            }
            this.pulicss.InsertLog("修改红头文件", "红头文件管理");
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
                string sql = "select * from qp_oa_DocumentModle  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                    this.wenjian.Text = "<a href='/DocumentModledown.aspx?number=" + list["Newname"].ToString() + "' target=_blank>" + list["Name"].ToString() + "</a>";
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


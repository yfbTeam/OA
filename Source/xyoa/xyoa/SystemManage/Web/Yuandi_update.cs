namespace xyoa.SystemManage.Web
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Yuandi_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leibie;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str8;
            string str = base.Server.MapPath("/web/Yuandi/");
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
                    str8 = "Update qp_web_Yuandi  Set Leibie='" + this.Leibie.SelectedValue + "',Titles='" + fileName + "',NewName='" + str2 + "' where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    this.List.ExeSql(str8);
                    this.pulicss.InsertLog("修改学习园地", "门户网站设置");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Yuandi.aspx'</script>");
                }
            }
            else
            {
                str8 = "Update qp_web_Yuandi  Set Leibie='" + this.Leibie.SelectedValue + "' where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                this.List.ExeSql(str8);
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Yuandi.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Yuandi.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_web_YuandiLb order by id asc";
                this.list.Bind_DropDownList_kong(this.Leibie, sQL, "id", "name");
                string sql = "select * from qp_web_Yuandi where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Leibie.SelectedValue = list["Leibie"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


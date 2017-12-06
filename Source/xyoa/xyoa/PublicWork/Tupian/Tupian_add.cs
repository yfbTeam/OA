namespace xyoa.PublicWork.Tupian
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Tupian_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        public string Contents;
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected TextBox PsDidian;
        protected TextBox PsShijian;
        private publics pulicss = new publics();
        protected DropDownList TypeId;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Tupian_show.aspx?id=" + base.Request.QueryString["typeid"] + "");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("tupian/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
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
                double num = Math.Round((double) (double.Parse(this.uploadFile.PostedFile.ContentLength.ToString()) / 1024.0), 2);
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_TupianMg (YdUsername,YdRealname,TypeId,Username,Realname,OldName,NewName,NowTimes,Fjtype,PsShijian,PsDidian,Daxiao) values ('','','", this.TypeId.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "','", fileName, "','PublicWork/Tupian/tupian/", str2, "','", DateTime.Now.ToString(), "','", filetype, "','", this.pulicss.GetFormatStr(this.PsShijian.Text), 
                    "','", this.pulicss.GetFormatStr(this.PsDidian.Text), "','", num, "KB')"
                 });
                this.List.ExeSql(sql);
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请先选择上传的文件！');</script>");
                return;
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Tupian_show.aspx?id=" + this.TypeId.SelectedValue + "'</script>");
            this.pulicss.InsertLog("上传文件", "图片管理");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_TupianLx order by Paixun asc";
                this.list.Bind_DropDownList_nothing(this.TypeId, sQL, "id", "name");
                if (base.Request.QueryString["typeid"] != null)
                {
                    this.TypeId.SelectedValue = base.Request.QueryString["typeid"].ToString();
                }
                this.BindAttribute();
            }
        }
    }
}


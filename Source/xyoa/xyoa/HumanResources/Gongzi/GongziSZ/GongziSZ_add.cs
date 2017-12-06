namespace xyoa.HumanResources.Gongzi.GongziSZ
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class GongziSZ_add : Page
    {
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected HtmlInputFile uploadFile;
        protected RadioButtonList Zhuangtai;

        public void BindAttribute()
        {
            this.Button3.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                if ((extension != ".xls") && (extension != ".xls"))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！只允许上传xls文件');</script>");
                }
                else
                {
                    Random random = new Random();
                    string str7 = random.Next(0x2710).ToString();
                    str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                    this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string sql = "insert into qp_hr_GongziSZ (Name,Zhuangtai,Moban) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.Zhuangtai.SelectedValue + "','" + str2 + "')";
                    this.List.ExeSql(sql);
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='GongziSZ.aspx'</script>");
                    this.pulicss.InsertLog("新增工资设置[" + this.pulicss.GetFormatStr(this.Name.Text) + "]", "工资设置");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请先选择上传的文件！');</script>");
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
                this.pulicss.QuanXianBack("eeee7d", this.Session["perstr"].ToString());
                this.BindAttribute();
            }
        }
    }
}


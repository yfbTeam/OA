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

    public class Jiejiari : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button5;
        protected Image Chunjie;
        protected HtmlInputFile File1;
        protected HtmlInputFile File2;
        protected HtmlInputFile File3;
        protected HtmlInputFile File4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Image Qiyi;
        protected Image Shiyi;
        protected HtmlInputFile uploadFile;
        protected Image Wuyi;
        protected Image Yuandan;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/web/jieri/");
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
                    string sql = "Update qp_web_Jiejiari  Set Chunjie='" + str2 + "'";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("更新节假日设置", "门户网站设置");
                    base.Response.Write("<script language=javascript>alert('更新成功！');window.location.href='Jiejiari.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请浏览更新图片！');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/web/jieri/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.File1.PostedFile.FileName));
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
                    this.File1.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string sql = "Update qp_web_Jiejiari  Set Yuandan='" + str2 + "'";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("更新节假日设置", "门户网站设置");
                    base.Response.Write("<script language=javascript>alert('更新成功！');window.location.href='Jiejiari.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请浏览更新图片！');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/web/jieri/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File2.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.File2.PostedFile.FileName));
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
                    this.File2.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string sql = "Update qp_web_Jiejiari  Set Wuyi='" + str2 + "'";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("更新节假日设置", "门户网站设置");
                    base.Response.Write("<script language=javascript>alert('更新成功！');window.location.href='Jiejiari.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请浏览更新图片！');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/web/jieri/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File3.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.File3.PostedFile.FileName));
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
                    this.File3.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string sql = "Update qp_web_Jiejiari  Set Qiyi='" + str2 + "'";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("更新节假日设置", "门户网站设置");
                    base.Response.Write("<script language=javascript>alert('更新成功！');window.location.href='Jiejiari.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请浏览更新图片！');</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/web/jieri/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File4.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.File4.PostedFile.FileName));
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
                    this.File4.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string sql = "Update qp_web_Jiejiari  Set Shiyi='" + str2 + "'";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("更新节假日设置", "门户网站设置");
                    base.Response.Write("<script language=javascript>alert('更新成功！');window.location.href='Jiejiari.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请浏览更新图片！');</script>");
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
                this.pulicss.QuanXianBack("iiiic7", this.Session["perstr"].ToString());
                string sql = "select * from qp_web_Jiejiari";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Chunjie.ImageUrl = "/web/jieri/" + list["Chunjie"].ToString() + "";
                    this.Yuandan.ImageUrl = "/web/jieri/" + list["Yuandan"].ToString() + "";
                    this.Wuyi.ImageUrl = "/web/jieri/" + list["Wuyi"].ToString() + "";
                    this.Qiyi.ImageUrl = "/web/jieri/" + list["Qiyi"].ToString() + "";
                    this.Shiyi.ImageUrl = "/web/jieri/" + list["Shiyi"].ToString() + "";
                }
                list.Close();
            }
        }
    }
}


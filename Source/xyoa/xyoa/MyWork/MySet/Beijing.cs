namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Beijing : Page
    {
        protected Button Button4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Image JmBg;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected HtmlInputFile uploadFile;

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/Images/skin1/bg/");
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
                    string sql = "select * from qp_oa_Bg where username='" + this.Session["username"] + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        string str9 = string.Concat(new object[] { "Update qp_oa_Bg  Set url='/Images/skin1/bg/", str2, "' where username='", this.Session["username"], "'" });
                        this.List.ExeSql(str9);
                    }
                    else
                    {
                        string str10 = string.Concat(new object[] { "insert into qp_oa_Bg (url,username) values ('/Images/skin1/bg/", str2, "','", this.Session["username"], "')" });
                        this.List.ExeSql(str10);
                    }
                    list.Close();
                    this.pulicss.InsertLog("更新桌面背景", "桌面背景");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.top.location.reload();window.top.winClose('5432185');</script>");
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
                string sql = "select * from qp_oa_Bg where username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.JmBg.ImageUrl = "" + list["url"].ToString() + "";
                }
                else
                {
                    this.JmBg.ImageUrl = "/Images/skin1/bg/blue_glow.jpg";
                }
                list.Close();
            }
        }
    }
}


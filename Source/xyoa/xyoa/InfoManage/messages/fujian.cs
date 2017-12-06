namespace xyoa.InfoManage.messages
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class fujian : Page
    {
        protected Button Button2;
        public string Contents;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string keyField = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                }
                else
                {
                    string str6 = this.Session["FjKey"].ToString();
                    if (!this.pulicss.scquanstr(extension, str6))
                    {
                        base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    }
                    else
                    {
                        string filetype = this.pulicss.Getfiletype(extension);
                        Random random = new Random();
                        string str8 = random.Next(0x2710).ToString();
                        keyField = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str8;
                        this.uploadFile.PostedFile.SaveAs(str + keyField + extension);
                        str2 = keyField + extension;
                        this.pulicss.Insertfile(fileName, "InfoManage/messages/file/" + str2 + "", keyField, filetype);
                        this.pulicss.InsertMessage("<img src=\"/oaimg/filetype/" + filetype + ".gif\" align=\"baseline\" border=0/> <a href=/file_down.aspx?number=InfoManage/messages/file/" + str2 + "  target=_blank>" + fileName + "</a>", base.Request.QueryString["user"].ToString(), this.ViewState["Realname"].ToString(), "/file_down.aspx?number=InfoManage/messages/file/" + str2 + "");
                        base.Response.Write("<script language=javascript>alert('发送成功');window.close();</script>");
                    }
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
                string sql = "select * from qp_oa_MyData where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Realname"] = list["Realname"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


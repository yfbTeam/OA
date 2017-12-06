namespace xyoa.MyWork.wjk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class file_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        public string Contents;
        public static string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Folders_show.aspx?id=" + base.Request.QueryString["FoldersID"].ToString() + "");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                string str7 = this.Session["FjKey"].ToString();
                if (!this.pulicss.scquanstr(extension, str7))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                string sql = "select * from qp_oa_filetype   where name='" + extension + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    str4 = list["name"].ToString().Replace(".", "");
                }
                else
                {
                    str4 = "unknow";
                }
                list.Close();
                Random random = new Random();
                string str9 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str9;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                string str10 = string.Concat(new object[] { "insert into qp_oa_Paper (FoldersID,Username,Realname,OldName,NewName,NowTimes,Fjtype) values ('", this.ParentNodesID.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "','", fileName, "','MyWork/wjk/file/", str2, "','", DateTime.Now.ToString(), "','", str4, "')" });
                this.List.ExeSql(str10);
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请先选择上传的文件！');</script>");
                return;
            }
            base.Response.Write("<script language=javascript>alert('提交成功！'); window.location = 'Folders_show.aspx?id=" + this.ParentNodesID.SelectedValue + "'</script>");
            this.pulicss.InsertLog("上传文件", "个人文件柜");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListNothing("qp_oa_Folders", this.ParentNodesID, " and username='" + this.Session["username"] + "'", "order by id asc");
                if (base.Request.QueryString["FoldersID"] != null)
                {
                    this.ParentNodesID.SelectedValue = base.Request.QueryString["FoldersID"].ToString();
                }
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.pda.MyWork.wjk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Folders_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
            this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Folders.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/MyWork/wjk/file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
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
                string str8 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str8;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                string str9 = string.Concat(new object[] { "insert into qp_oa_Paper (FoldersID,Username,Realname,OldName,NewName,NowTimes,Fjtype) values ('", this.ParentNodesID.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "','", fileName, "','MyWork/wjk/file/", str2, "','", DateTime.Now.ToString(), "','", str4, "')" });
                this.List.ExeSql(str9);
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.location = 'Folders.aspx'</script>");
                this.pulicss.InsertLog("上传文件", "个人文件柜");
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
                this.pulicss.BindListNothing("qp_oa_Folders", this.ParentNodesID, " and username='" + this.Session["username"] + "'", "order by id asc");
                this.BindAttribute();
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
            }
        }
    }
}


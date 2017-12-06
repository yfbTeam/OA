namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        public string Contents;
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label lblMessage;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList TypeId;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyWebDisk_show.aspx?id=" + base.Request.QueryString["typeid"] + "");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  and ((B.[Types]='1' and nameid='1' and BXinzeng='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and BXinzeng='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and BXinzeng='1')  or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and BXinzeng='1')) and A.id='", this.TypeId.SelectedValue, "'  group by A.[Name],A.[id],A.[SetRealname]" });
            SqlDataReader list = this.List.GetList(sql);
            if (!list.Read())
            {
                base.Response.Write("<script language=javascript>alert('不允许在文件夹下新建文件！');</script>");
            }
            else
            {
                list.Close();
                this.lblMessage.Text = "";
                this.lblMessage.Visible = false;
                HttpFileCollection files = HttpContext.Current.Request.Files;
                StringBuilder builder = new StringBuilder("");
                if (builder.Length <= 0)
                {
                    string path = base.Server.MapPath("file");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    Random random = new Random();
                    int num = 1;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string fileName = "";
                        string extension = "";
                        string rightName = "";
                        string filetype = "";
                        fileName = Path.GetFileName(file.FileName);
                        rightName = Path.GetExtension(file.FileName);
                        filetype = this.pulicss.Getfiletype(rightName);
                        string str7 = random.Next(100, 0x5f5e100).ToString() + num.ToString();
                        string str8 = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                        if (fileName.Length > 0)
                        {
                            extension = Path.GetExtension(file.FileName);
                            string filename = path + @"\" + str8 + extension;
                            file.SaveAs(filename);
                            string str10 = string.Concat(new object[] { 
                                "insert into qp_oa_MyWebDiskFile (TypeId,Username,Realname,OldName,NewName,NowTimes,Fjtype) values ('", this.TypeId.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "','", fileName, "','PublicWork/WebDisk/file/", str8, "", extension, "','", DateTime.Now.ToString(), "','", filetype, 
                                "')"
                             });
                            this.List.ExeSql(str10);
                        }
                        num++;
                    }
                    this.pulicss.InsertLog("上传文件", "硬盘浏览");
                }
                else
                {
                    this.lblMessage.Text = builder.ToString();
                    this.lblMessage.Visible = true;
                }
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location = 'MyWebDisk_show.aspx?id=" + this.TypeId.SelectedValue + "'</script>");
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
                this.pulicss.BindListNothingDisk("[qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]", this.TypeId, string.Concat(new object[] { " and ((B.[Types]='1' and nameid='1' and FLiulang='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FLiulang='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FLiulang='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FLiulang='1'))" }), " group by A.[Name],A.[id] order by A.id asc");
                if (base.Request.QueryString["typeid"] != "0")
                {
                    string sql = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  and ((B.[Types]='1' and nameid='1' and BXinzeng='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and BXinzeng='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and BXinzeng='1')  or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and BXinzeng='1')) and A.id='", base.Request.QueryString["typeid"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                    SqlDataReader list = this.List.GetList(sql);
                    if (!list.Read())
                    {
                        base.Response.Write("<script language=javascript>alert('不允许在文件夹下新建文件！');window.location = 'MyWebDisk_show.aspx?id=" + base.Request.QueryString["typeid"].ToString() + "'</script>");
                    }
                    list.Close();
                }
                if (base.Request.QueryString["typeid"] != null)
                {
                    this.TypeId.SelectedValue = base.Request.QueryString["typeid"].ToString();
                }
                this.BindAttribute();
            }
        }
    }
}


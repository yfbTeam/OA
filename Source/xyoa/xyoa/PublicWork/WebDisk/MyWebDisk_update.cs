namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        public string Contents;
        public string fjkey;
        protected Label FjtypeLb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList TypeId;
        protected HtmlInputFile uploadFile;

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
            string str9;
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
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
                str9 = string.Concat(new object[] { "Update qp_oa_MyWebDiskFile  Set  OldName='", this.pulicss.GetFormatStr(this.Name.Text), "", extension, "',TypeId='", this.TypeId.SelectedValue, "',NewName='PublicWork/WebDisk/file/", str2, "',Fjtype='", filetype, "',NowTimes='", DateTime.Now.ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str9);
            }
            else
            {
                str9 = string.Concat(new object[] { "Update qp_oa_MyWebDiskFile  Set  OldName='", this.pulicss.GetFormatStr(this.Name.Text), "", this.FjtypeLb.Text, "',TypeId='", this.TypeId.SelectedValue, "',NowTimes='", DateTime.Now.ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str9);
            }
            string sql = string.Concat(new object[] { "insert into qp_oa_MyWebDiskLog  (KeyId,Username,Realname,SetTime,Contents,BuMenId) values ('", base.Request.QueryString["id"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','修改文件','", this.Session["BuMenId"], "')" });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyWebDisk_show.aspx?id=" + base.Request.QueryString["typeid"] + "'</script>");
            this.pulicss.InsertLog("修改文件", "硬盘浏览");
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
                string sql = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and BXiugai='1') or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and BXiugai='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and BXiugai='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and BXiugai='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and BXiugai='1')) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["NewNames"] = list["NewName"].ToString();
                    int length = list["OldName"].ToString().LastIndexOf(".");
                    int num2 = list["OldName"].ToString().Length - list["OldName"].ToString().LastIndexOf(".");
                    this.Name.Text = list["OldName"].ToString().Substring(0, length);
                    this.FjtypeLb.Text = list["OldName"].ToString().Substring(length, num2);
                    this.TypeId.SelectedValue = list["TypeId"].ToString();
                    list.Close();
                    this.BindAttribute();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('不允许修改此文件！');window.location.href='MyWebDisk_show.aspx?id=" + base.Request.QueryString["typeid"] + "'</script>");
                }
            }
        }
    }
}


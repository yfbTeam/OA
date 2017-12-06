namespace xyoa.PublicWork.BumenPage
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenWz_wh_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected FCKeditor Content;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox titles;
        protected HtmlInputFile uploadFile;
        protected DropDownList WzLeibie;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button6.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_BumenWz  Set  WzLeibie='", this.WzLeibie.SelectedValue, "',titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',Settime='", DateTime.Now.ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改文章", "部门主页");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='BumenWz_wh.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["ZhuyeId"]) + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("BumenWz_wh.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["ZhuyeId"]) + "");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
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
                    string filetype = this.pulicss.Getfiletype(extension);
                    this.pulicss.Insertfile(fileName, "PublicWork/BumenPage/file/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "文章管理");
                    this.BindFjlbList();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    string sQL = "select id,Leixing  from qp_oa_BumenWzLb where  LeibieId='" + this.pulicss.GetFormatStr(base.Request.QueryString["ZhuyeId"]) + "' order by paixun asc";
                    this.list.Bind_DropDownList_kong(this.WzLeibie, sQL, "id", "Leixing");
                    string sql = "select A.id,B.[Name] as BuMenName from [qp_oa_BumenZy] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] where  A.id='" + this.pulicss.GetFormatStr(base.Request.QueryString["ZhuyeId"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.ViewState["BuMenName"] = list["BuMenName"].ToString();
                    }
                    list.Close();
                    string str3 = "select * from qp_oa_BumenWz  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        this.WzLeibie.SelectedValue = reader2["WzLeibie"].ToString();
                        this.Number.Text = reader2["Number"].ToString();
                        this.titles.Text = reader2["titles"].ToString();
                        this.Content.Value = reader2["Content"].ToString();
                    }
                    reader2.Close();
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}


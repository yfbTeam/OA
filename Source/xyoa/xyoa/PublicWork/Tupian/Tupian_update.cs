namespace xyoa.PublicWork.Tupian
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Tupian_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Image Image1;
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
            string str9;
            if (this.CheckBox1.Checked)
            {
                string str = base.Server.MapPath("tupian/");
                string str2 = string.Empty;
                string str3 = string.Empty;
                if (this.uploadFile.PostedFile.ContentLength == 0)
                {
                    base.Response.Write("<script language=javascript>alert('请先选择上传的文件！');</script>");
                    return;
                }
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
                str9 = string.Concat(new object[] { 
                    "Update qp_oa_TupianMg   Set  OldName='", fileName, "',NewName='PublicWork/Tupian/tupian/", str2, "',Fjtype='", filetype, "',TypeId='", this.TypeId.SelectedValue, "',PsShijian='", this.pulicss.GetFormatStr(this.PsShijian.Text), "',PsDidian='", this.pulicss.GetFormatStr(this.PsDidian.Text), "',Daxiao='", num, "',NowTimes='", DateTime.Now.ToString(), 
                    "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
                 });
                this.List.ExeSql(str9);
            }
            else
            {
                str9 = string.Concat(new object[] { "Update qp_oa_TupianMg   Set  TypeId='", this.TypeId.SelectedValue, "',PsShijian='", this.pulicss.GetFormatStr(this.PsShijian.Text), "',PsDidian='", this.pulicss.GetFormatStr(this.PsDidian.Text), "',NowTimes='", DateTime.Now.ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
                this.List.ExeSql(str9);
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Tupian_show.aspx?id=" + this.TypeId.SelectedValue + "'</script>");
            this.pulicss.InsertLog("修改文件", "图片管理");
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
                string sql = "select * from qp_oa_TupianMg  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.PsShijian.Text = list["PsShijian"].ToString();
                    this.PsDidian.Text = list["PsDidian"].ToString();
                    this.TypeId.SelectedValue = list["TypeId"].ToString();
                    this.Image1.ImageUrl = "/" + list["NewName"].ToString() + "";
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


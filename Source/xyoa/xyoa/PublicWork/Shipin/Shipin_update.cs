namespace xyoa.PublicWork.Shipin
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Shipin_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Titles;
        protected DropDownList TypeId;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.pulicss.QuanXianBack("jjjj9bc", this.Session["perstr"].ToString());
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str7;
            if (this.CheckBox1.Checked)
            {
                string str = base.Server.MapPath("shipin/");
                string str2 = string.Empty;
                string str3 = string.Empty;
                if (this.uploadFile.PostedFile.ContentLength != 0)
                {
                    string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                    if ((extension != ".flv") && (extension != ".FLV"))
                    {
                        base.Response.Write("<script language=javascript>alert('只允许上传flv格式的文件！');</script>");
                    }
                    else
                    {
                        Random random = new Random();
                        string str6 = random.Next(0x2710).ToString();
                        str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str6;
                        this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                        str2 = str3 + extension;
                        str7 = string.Concat(new object[] { "Update qp_oa_ShipinMg  Set  TypeId='", this.TypeId.SelectedValue, "',Titles='", this.pulicss.GetFormatStr(this.Titles.Text), "',Content='PublicWork/Shipin/shipin/", str2, "',Settime='", DateTime.Now.ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
                        this.List.ExeSql(str7);
                        this.pulicss.InsertLog("修改视频", "视频管理");
                        base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Shipin_show.aspx?id=" + this.TypeId.SelectedValue + "'</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('上传文件不能为空！');</script>");
                }
            }
            else
            {
                str7 = string.Concat(new object[] { "Update qp_oa_ShipinMg  Set  TypeId='", this.TypeId.SelectedValue, "',Titles='", this.pulicss.GetFormatStr(this.Titles.Text), "',Settime='", DateTime.Now.ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
                this.List.ExeSql(str7);
                this.pulicss.InsertLog("修改视频", "视频管理");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Shipin_show.aspx?id=" + this.TypeId.SelectedValue + "'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Shipin_show.aspx?id=" + base.Request.QueryString["typeid"] + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_ShipinLx order by Paixun asc";
                this.list.Bind_DropDownList_nothing(this.TypeId, sQL, "id", "name");
                string sql = "select * from qp_oa_ShipinMg  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Titles.Text = list["Titles"].ToString();
                    this.TypeId.SelectedValue = list["TypeId"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


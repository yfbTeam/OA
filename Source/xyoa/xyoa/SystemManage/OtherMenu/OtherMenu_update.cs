namespace xyoa.SystemManage.OtherMenu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class OtherMenu_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox name;
        protected TextBox Paixun;
        protected Image pic;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected HtmlInputFile uploadFile;
        protected TextBox urlname;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str8;
            string str = base.Server.MapPath("/images/desktopIOC/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str8 = string.Concat(new object[] { 
                    "Update qp_oa_OtherMenu  Set pic='", str2, "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',name='", this.pulicss.GetFormatStr(this.name.Text), "',urlname='", this.urlname.Text, 
                    "',Paixun='", this.Paixun.Text, "'   where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str8);
            }
            else
            {
                str8 = string.Concat(new object[] { 
                    "Update qp_oa_OtherMenu  Set States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',name='", this.pulicss.GetFormatStr(this.name.Text), "',urlname='", this.urlname.Text, "',Paixun='", this.Paixun.Text, 
                    "'   where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str8);
            }
            this.pulicss.InsertLog("修改扩展应用", "扩展应用");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OtherMenu.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OtherMenu.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_OtherMenu where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.name.Text = list["name"].ToString();
                    this.urlname.Text = list["urlname"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.pic.ImageUrl = "/images/desktopIOC/" + list["pic"].ToString() + "";
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


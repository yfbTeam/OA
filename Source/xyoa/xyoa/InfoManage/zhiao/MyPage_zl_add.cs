namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPage_zl_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        public string Contents;
        public string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label lblMessage;
        protected TextBox Leibie;
        protected TextBox LeibieName;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.LeibieName.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyPage_zl.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            this.lblMessage.Visible = false;
            HttpFileCollection files = HttpContext.Current.Request.Files;
            StringBuilder builder = new StringBuilder("");
            if (builder.Length <= 0)
            {
                string path = base.Server.MapPath("UpLoad");
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
                    fileName = Path.GetFileName(file.FileName);
                    rightName = Path.GetExtension(file.FileName);
                    string filetype = this.pulicss.Getfiletype(rightName);
                    string str6 = random.Next(100, 0x5f5e100).ToString() + num.ToString();
                    string str7 = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str6;
                    if (fileName.Length > 0)
                    {
                        extension = Path.GetExtension(file.FileName);
                        string filename = path + @"\" + str7 + extension;
                        file.SaveAs(filename);
                        string sql = string.Concat(new object[] { 
                            "insert into qp_oa_Zst_ziliao (cishu,Tuijian,Leibie,Name,NewName,Filetype,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,Username,Realname,Settimes,UsernameXz,RealnameXz) values ('0','2','", this.Leibie.Text, "','", fileName, "','InfoManage/zhiao/UpLoad/", str7, "", extension, "','", filetype, "','", this.States.SelectedValue, "','", this.pulicss.GetFormatStr(this.ZdBumenId.Text), "','", this.pulicss.GetFormatStr(this.ZdBumen.Text), 
                            "','", this.pulicss.GetFormatStr(this.ZdUsername.Text), "','", this.pulicss.GetFormatStr(this.ZdRealname.Text), "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "','','')"
                         });
                        this.List.ExeSql(sql);
                        string str10 = string.Concat(new object[] { "Update qp_oa_username  Set jifen=jifen", this.pulicss.JifenGuize("上传共享资料"), "  where username='", this.Session["username"], "'" });
                        this.List.ExeSql(str10);
                    }
                    num++;
                }
                base.Response.Write("<script language=javascript>alert('上传成功！'); window.location = 'MyPage_zl.aspx'</script>");
            }
            else
            {
                this.lblMessage.Text = builder.ToString();
                this.lblMessage.Visible = true;
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
                this.BindAttribute();
            }
        }
    }
}


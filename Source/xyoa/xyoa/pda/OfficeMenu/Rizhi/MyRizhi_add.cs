namespace xyoa.pda.OfficeMenu.Rizhi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRizhi_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button5;
        protected Button Button6;
        protected TextBox Content;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList LeiBie;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox NowTimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox titles;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.NowTimes.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
            this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
            this.Button5.Attributes["onclick"] = "javascript:return delfj();";
            this.Button6.Attributes["onclick"] = "javascript:return checkForm();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyRizhi.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_MyRizhi (YdUsername,YdRealname,NowTimes,Number,titles,Content,Username,Realname,LeiBie) values ('','','" + this.NowTimes.Text + "','" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.pulicss.GetFormatStr(this.titles.Text) + "','" + this.pulicss.GetFormatStr(this.Content.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + this.LeiBie.SelectedValue + "')";
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyRizhi.aspx'</script>");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string sql = "Delete from qp_oa_fileupload where NewName='" + this.fjlb.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.BindFjlbList();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/OfficeMenu/Rizhi/file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                Random random = new Random();
                string str6 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str6;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                string filetype = this.pulicss.Getfiletype(extension);
                this.pulicss.Insertfile(fileName, "OfficeMenu/Rizhi/file/" + str2 + "", this.Number.Text, filetype);
                this.pulicss.InsertLog("上传附件[" + fileName + "]", "我的日志");
                this.BindFjlbList();
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
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                string sQL = "select id,name  from qp_oa_RizhiLx order by id asc";
                this.list.Bind_DropDownList_kong(this.LeiBie, sQL, "id", "name");
                this.BindAttribute();
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
            }
        }
    }
}


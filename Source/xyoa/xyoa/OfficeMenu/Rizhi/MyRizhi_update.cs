namespace xyoa.OfficeMenu.Rizhi
{
    using FredCK.FCKeditorV2;
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRizhi_update : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected FCKeditor Content;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList LeiBie;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox NowTimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox titles;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_MyRizhi  Set  LeiBie='", this.LeiBie.SelectedValue, "',titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',NowTimes='", this.pulicss.GetFormatStr(this.NowTimes.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  and username='", this.Session["username"], "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改我的日志", "我的日志");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyRizhi.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyRizhi.aspx");
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
                    this.pulicss.Insertfile(fileName, "OfficeMenu/Rizhi/file/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "我的日志");
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
                    string sql = string.Concat(new object[] { "select * from qp_oa_MyRizhi  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "' " });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.titles.Text = list["titles"].ToString();
                        this.NowTimes.Text = DateTime.Parse(list["NowTimes"].ToString()).ToShortDateString();
                        this.Content.Value = list["Content"].ToString();
                        this.LeiBie.SelectedValue = list["LeiBie"].ToString();
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('无相关信息！');window.location.href='MyRizhi.aspx'</script>");
                        return;
                    }
                    list.Close();
                    this.BindAttribute();
                    string sQL = "select id,name  from qp_oa_RizhiLx order by id asc";
                    this.list.Bind_DropDownList_nothing1(this.LeiBie, sQL, "id", "name");
                    if (this.LeiBie.Items.Count > 0)
                    {
                        this.LeiBie.Items[0].Selected = true;
                    }
                    if (base.Request.QueryString["day"] != null)
                    {
                        this.NowTimes.Text = "" + base.Request.QueryString["day"] + "";
                    }
                    else
                    {
                        this.NowTimes.Text = DateTime.Now.ToShortDateString();
                    }
                }
                this.BindFjlbList();
            }
        }
    }
}


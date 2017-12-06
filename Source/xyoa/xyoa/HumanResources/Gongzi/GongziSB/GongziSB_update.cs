namespace xyoa.HumanResources.Gongzi.GongziSB
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class GongziSB_update : Page
    {
        protected Button Button1;
        protected TextBox EndTime;
        protected HtmlInputFile fileExcel;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox SpRealname;
        protected TextBox SpUsername;
        protected TextBox StartTime;
        protected DropDownList Zhangtao;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.SpRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str9;
            string str = base.Server.MapPath("/Gongzi/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.fileExcel.PostedFile.ContentLength != 0)
            {
                string sql = "drop table hr_" + this.Number.Text + "";
                this.List.ExeSql(sql);
                string extension = Path.GetExtension(Path.GetFileName(this.fileExcel.PostedFile.FileName));
                if ((extension != ".xls") && (extension != ".XLS"))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！只允许上传xls文件');</script>");
                    return;
                }
                str3 = "hr_" + this.Number.Text + "";
                this.fileExcel.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                string str7 = str + "hr_" + this.Number.Text + "";
                string str8 = "Select * INTO hr_" + this.Number.Text + " FROM  OpenDataSource( 'Microsoft.Jet.OLEDB.4.0','Data Source=" + str7 + ";User ID=Admin;Password=;Extended properties=Excel 5.0')...Sheet1$";
                this.List.ExeSql(str8);
                str9 = string.Concat(new object[] { 
                    "Update qp_hr_GongziSB  Set Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',Zhangtao='", this.Zhangtao.SelectedValue, "',StartTime='", this.pulicss.GetFormatStr(this.StartTime.Text), "',EndTime='", this.pulicss.GetFormatStr(this.EndTime.Text), "',SpUsername='", this.pulicss.GetFormatStr(this.SpUsername.Text), "',SpRealname='", this.pulicss.GetFormatStr(this.SpRealname.Text), "',NowTimes='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), 
                    "' and Username='", this.Session["Username"], "'"
                 });
                this.List.ExeSql(str9);
            }
            else
            {
                str9 = string.Concat(new object[] { 
                    "Update qp_hr_GongziSB  Set Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',Zhangtao='", this.Zhangtao.SelectedValue, "',StartTime='", this.pulicss.GetFormatStr(this.StartTime.Text), "',EndTime='", this.pulicss.GetFormatStr(this.EndTime.Text), "',SpUsername='", this.pulicss.GetFormatStr(this.SpUsername.Text), "',SpRealname='", this.pulicss.GetFormatStr(this.SpRealname.Text), "',NowTimes='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), 
                    "' and Username='", this.Session["Username"], "'"
                 });
                this.List.ExeSql(str9);
            }
            this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的薪资上报需要审批，工资主题：", this.Zhuti.Text, "，申请人：", this.Session["realname"], "" }), this.SpUsername.Text, this.SpRealname.Text, "/HumanResources/Gongzi/GongziMG/GongziMG.aspx?Zhuangtai=1");
            this.pulicss.InsertLog("修改薪资上报", "薪资上报");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='GongziSB.aspx?Zhuangtai=4'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee7b", this.Session["perstr"].ToString());
                string sQL = "select id,Name from qp_hr_GongziSZ order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhangtao, sQL, "id", "Name");
                string sql = string.Concat(new object[] { "select * from qp_hr_GongziSB where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Zhangtao.SelectedValue = list["Zhangtao"].ToString();
                    this.StartTime.Text = DateTime.Parse(list["StartTime"].ToString()).ToShortDateString();
                    this.EndTime.Text = DateTime.Parse(list["EndTime"].ToString()).ToShortDateString();
                    this.SpUsername.Text = list["SpUsername"].ToString();
                    this.SpRealname.Text = list["SpRealname"].ToString();
                    if (list["Zhuangtai"].ToString() != "4")
                    {
                        this.Button1.Enabled = false;
                    }
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


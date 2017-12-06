namespace xyoa.HumanResources.Gongzi.GongziSB
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class GongziSB_add : Page
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
            string str = base.Server.MapPath("/Gongzi/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.fileExcel.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.fileExcel.PostedFile.FileName));
                if ((extension != ".xls") && (extension != ".XLS"))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！只允许上传xls文件');</script>");
                }
                else
                {
                    str3 = "hr_" + this.Number.Text + "";
                    this.fileExcel.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string str6 = str + "hr_" + this.Number.Text + "";
                    string sql = "Select * INTO hr_" + this.Number.Text + " FROM  OpenDataSource( 'Microsoft.Jet.OLEDB.4.0','Data Source=" + str6 + ";User ID=Admin;Password=;Extended properties=Excel 5.0')...Sheet1$";
                    this.List.ExeSql(sql);
                    string str8 = "insert into qp_hr_GongziSB (Number,Zhuti,Zhangtao,StartTime,EndTime,Zhuangtai,SpRemark,SpUsername,SpRealname,Username,Realname,YspUsername,NowTimes) values ('" + this.Number.Text + "','" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "','" + this.Zhangtao.SelectedValue + "','" + this.pulicss.GetFormatStr(this.StartTime.Text) + "','" + this.EndTime.Text + "','4','','" + this.SpUsername.Text + "','" + this.SpRealname.Text + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','','" + DateTime.Now.ToString() + "')";
                    this.List.ExeSql(str8);
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的薪资上报需要审批，工资主题：", this.Zhuti.Text, "，申请人：", this.Session["realname"], "" }), this.SpUsername.Text, this.SpRealname.Text, "/HumanResources/Gongzi/GongziMG/GongziMG.aspx?Zhuangtai=1");
                    this.pulicss.InsertLog("新增薪资上报", "薪资上报");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='GongziSB.aspx?Zhuangtai=4'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('导入文件不能为空！');</script>");
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
                this.pulicss.QuanXianBack("eeee7b", this.Session["perstr"].ToString());
                string sQL = "select id,Name from qp_hr_GongziSZ order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhangtao, sQL, "id", "Name");
                Random random = new Random();
                string str2 = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + str2 + "";
                this.BindAttribute();
            }
        }
    }
}


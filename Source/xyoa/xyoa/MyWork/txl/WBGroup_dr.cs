namespace xyoa.MyWork.txl
{
    using qiupeng.crm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WBGroup_dr : Page
    {
        protected Button Button1;
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        protected HtmlInputFile fileExcel;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/file/");
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
                    str3 = "b1_" + this.Number.Text + "";
                    this.fileExcel.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string str6 = str + "b1_" + this.Number.Text + "" + extension + "";
                    string sql = "Select * INTO b1_" + this.Number.Text + " FROM  OpenDataSource( 'Microsoft.Jet.OLEDB.4.0','Data Source=" + str6 + ";User ID=Admin;Password=;Extended properties=Excel 5.0')...Sheet1$";
                    this.List.ExeSql(sql);
                    string str8 = "select * from b1_" + this.Number.Text + "";
                    SqlDataReader list = this.List.GetList(str8);
                    while (list.Read())
                    {
                        if (this.pulicss.GetFormatStr(list["姓名"].ToString()).Trim() != "")
                        {
                            string str9 = string.Concat(new object[] { 
                                "insert into qp_oa_WBGroup (Name,Sex,OtherName,Post,CName,CAddress,CZipCode,CTel,CFax,HMoveTel,Email,QQNum,MsnNum,Remark,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(list["姓名"].ToString()), "','", this.pulicss.GetFormatStr(list["性别"].ToString()), "','", this.pulicss.GetFormatStr(list["昵称"].ToString()), "','", this.pulicss.GetFormatStr(list["职务"].ToString()), "','", this.pulicss.GetFormatStr(list["单位名称"].ToString()), "','", this.pulicss.GetFormatStr(list["单位地址"].ToString()), "','", this.pulicss.GetFormatStr(list["单位邮编"].ToString()), "','", this.pulicss.GetFormatStr(list["单位电话"].ToString()), 
                                "','", this.pulicss.GetFormatStr(list["单位传真"].ToString()), "','", this.pulicss.GetFormatStr(list["手机"].ToString()), "','", this.pulicss.GetFormatStr(list["电子邮件"].ToString()), "','", this.pulicss.GetFormatStr(list["QQ"].ToString()), "','", this.pulicss.GetFormatStr(list["MSN"].ToString()), "','", this.pulicss.GetFormatStr(list["备注"].ToString()), "','", this.Session["username"], "','", this.Session["Realname"], 
                                "','", DateTime.Now.ToShortDateString(), "')"
                             });
                            this.List.ExeSql(str9);
                        }
                    }
                    list.Close();
                    string str10 = "drop table b1_" + this.Number.Text + "";
                    this.List.ExeSql(str10);
                    File.Delete(base.Server.MapPath("//file//b1_" + this.Number.Text + "" + extension + ""));
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WBGroup.aspx'</script>");
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
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + str + "";
                this.BindAttribute();
            }
        }
    }
}


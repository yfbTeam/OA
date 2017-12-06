namespace xyoa.SchTable.SysMag.Kecheng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Kecheng_add : Page
    {
        protected TextBox Bujige1;
        protected TextBox Bujige2;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Hege1;
        protected TextBox Hege2;
        protected TextBox Jicha1;
        protected TextBox Jicha2;
        protected TextBox Lianghao1;
        protected TextBox Lianghao2;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox RkRealname;
        protected TextBox RkUsername;
        protected TextBox Youxiu1;
        protected TextBox Youxiu2;

        public void BindAttribute()
        {
            this.RkRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_sch_Kecheng where Name='" + this.pulicss.GetFormatStr(this.Name.Text) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('课程名称已存在！');</script>");
                list.Close();
            }
            else
            {
                list.Close();
                string str2 = "insert into qp_sch_Kecheng   (RkUsername,RkRealname,Name,Dengji,Youxiu1,Youxiu2,Lianghao1,Lianghao2,Hege1,Hege2,Bujige1,Bujige2,Jicha1,Jicha2) values ('" + this.pulicss.GetFormatStr(this.RkUsername.Text) + "','" + this.pulicss.GetFormatStr(this.RkRealname.Text) + "','" + this.pulicss.GetFormatStr(this.Name.Text) + "','分数','" + this.pulicss.GetFormatStr(this.Youxiu1.Text) + "','" + this.pulicss.GetFormatStr(this.Youxiu2.Text) + "','" + this.pulicss.GetFormatStr(this.Lianghao1.Text) + "','" + this.pulicss.GetFormatStr(this.Lianghao2.Text) + "','" + this.pulicss.GetFormatStr(this.Hege1.Text) + "','" + this.pulicss.GetFormatStr(this.Hege2.Text) + "','" + this.pulicss.GetFormatStr(this.Bujige1.Text) + "','" + this.pulicss.GetFormatStr(this.Bujige2.Text) + "','" + this.pulicss.GetFormatStr(this.Jicha1.Text) + "','" + this.pulicss.GetFormatStr(this.Jicha2.Text) + "')";
                this.List.ExeSql(str2);
                this.pulicss.InsertLog("新增课程设置[" + this.Name.Text + "]", "课程设置");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Kecheng.aspx'</script>");
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


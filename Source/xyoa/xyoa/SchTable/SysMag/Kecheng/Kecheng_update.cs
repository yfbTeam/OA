namespace xyoa.SchTable.SysMag.Kecheng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Kecheng_update : Page
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
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Kecheng     Set RkUsername='", this.pulicss.GetFormatStr(this.RkUsername.Text), "',RkRealname='", this.pulicss.GetFormatStr(this.RkRealname.Text), "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Youxiu1='", this.pulicss.GetFormatStr(this.Youxiu1.Text), "',Youxiu2='", this.pulicss.GetFormatStr(this.Youxiu2.Text), "',Lianghao1='", this.pulicss.GetFormatStr(this.Lianghao1.Text), "',Lianghao2='", this.pulicss.GetFormatStr(this.Lianghao2.Text), "',Hege1='", this.pulicss.GetFormatStr(this.Hege1.Text), 
                "',Hege2='", this.pulicss.GetFormatStr(this.Hege2.Text), "',Bujige1='", this.pulicss.GetFormatStr(this.Bujige1.Text), "',Bujige2='", this.pulicss.GetFormatStr(this.Bujige2.Text), "',Jicha1='", this.pulicss.GetFormatStr(this.Jicha1.Text), "',Jicha2='", this.pulicss.GetFormatStr(this.Jicha2.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改课程设置[" + this.Name.Text + "]", "课程设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Kecheng.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Kecheng where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Youxiu1.Text = list["Youxiu1"].ToString();
                    this.Youxiu2.Text = list["Youxiu2"].ToString();
                    this.Lianghao1.Text = list["Lianghao1"].ToString();
                    this.Lianghao2.Text = list["Lianghao2"].ToString();
                    this.Hege1.Text = list["Hege1"].ToString();
                    this.Hege2.Text = list["Hege2"].ToString();
                    this.Bujige1.Text = list["Bujige1"].ToString();
                    this.Bujige2.Text = list["Bujige2"].ToString();
                    this.Jicha1.Text = list["Jicha1"].ToString();
                    this.Jicha2.Text = list["Jicha2"].ToString();
                    this.RkUsername.Text = list["RkUsername"].ToString();
                    this.RkRealname.Text = list["RkRealname"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


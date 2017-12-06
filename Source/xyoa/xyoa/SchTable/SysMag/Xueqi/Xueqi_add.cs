namespace xyoa.SchTable.SysMag.Xueqi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueqi_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Mingcheng;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected CheckBoxList QiyongXueduan;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_sch_Xueqi where Mingcheng='" + this.pulicss.GetFormatStr(this.Mingcheng.SelectedValue) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('学期名称已存在！');</script>");
                list.Close();
            }
            else
            {
                list.Close();
                string str2 = "insert into qp_sch_Xueqi   (Mingcheng,QiyongXueduan) values ('" + this.pulicss.GetFormatStr(this.Mingcheng.SelectedValue) + "','" + this.pulicss.GetChecked(this.QiyongXueduan) + "')";
                this.List.ExeSql(str2);
                string str3 = "CREATE TABLE [stu_table_" + this.pulicss.GetFormatStr(this.Mingcheng.SelectedValue) + "_1] ([id] [int] IDENTITY (1, 1) NOT NULL ,[Xueqi] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[BanJi] [int] NULL ,[XsId] [int] NULL ,[Zhiwu] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[XuejiZhuangtai] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ) ON [PRIMARY]";
                this.List.ExeSql(str3);
                string str4 = "CREATE TABLE [stu_table_" + this.pulicss.GetFormatStr(this.Mingcheng.SelectedValue) + "_2] ([id] [int] IDENTITY (1, 1) NOT NULL ,[Xueqi] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[BanJi] [int] NULL ,[XsId] [int] NULL ,[Zhiwu] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,[XuejiZhuangtai] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ) ON [PRIMARY]";
                this.List.ExeSql(str4);
                this.pulicss.InsertLog("新增学期设置[" + this.Mingcheng.Text + "]", "学期设置");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueqi.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Xueqi.aspx");
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


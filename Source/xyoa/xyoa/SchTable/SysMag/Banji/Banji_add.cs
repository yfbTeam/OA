namespace xyoa.SchTable.SysMag.Banji
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Banji_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox BzRealname;
        protected TextBox BzUsername;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Mingcheng;
        protected DropDownList Nianji;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox RkRealname;
        protected TextBox RkUsername;
        protected TextBox Shangkedidian;
        protected TextBox XldRealname;
        protected TextBox XldUsername;
        protected DropDownList Xueqi;

        public void BindAttribute()
        {
            this.BzRealname.Attributes.Add("readonly", "readonly");
            this.RkRealname.Attributes.Add("readonly", "readonly");
            this.XldRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_sch_Banji where Xueqi='" + this.Xueqi.SelectedValue + "' and Nianji='" + this.Nianji.SelectedValue + "' and Mingcheng='" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('班级名称已存在！');</script>");
                list.Close();
            }
            else
            {
                list.Close();
                string str2 = "insert into qp_sch_Banji  (Xueqi,Nianji,Mingcheng,Shangkedidian,BzUsername,BzRealname,RkUsername,RkRealname,XldUsername,XldRealname) values ('" + this.pulicss.GetFormatStr(this.Xueqi.SelectedValue) + "','" + this.Nianji.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "','" + this.pulicss.GetFormatStr(this.Shangkedidian.Text) + "','" + this.pulicss.GetFormatStr(this.BzUsername.Text) + "','" + this.pulicss.GetFormatStr(this.BzRealname.Text) + "','" + this.pulicss.GetFormatStr(this.RkUsername.Text) + "','" + this.pulicss.GetFormatStr(this.RkRealname.Text) + "','" + this.pulicss.GetFormatStr(this.XldUsername.Text) + "','" + this.pulicss.GetFormatStr(this.XldRealname.Text) + "')";
                this.List.ExeSql(str2);
                this.pulicss.InsertLog("新增班级设置[" + this.Mingcheng.Text + "]", "班级设置");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Banji.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Banji.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                string str2 = "select id,NianjiMc  from qp_sch_Nianji where Xueqi='" + this.Xueqi.SelectedValue + "'  order by Xueqi asc";
                this.list.Bind_DropDownList_nothing(this.Nianji, str2, "NianjiMc", "NianjiMc");
                this.Mingcheng.Text = "" + this.Nianji.SelectedValue.Replace("年级", "") + "1班";
                this.BindAttribute();
            }
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select id,NianjiMc  from qp_sch_Nianji where Xueqi='" + this.Xueqi.SelectedValue + "'  order by Xueqi asc";
            this.list.Bind_DropDownList_nothing(this.Nianji, sQL, "NianjiMc", "NianjiMc");
        }
    }
}


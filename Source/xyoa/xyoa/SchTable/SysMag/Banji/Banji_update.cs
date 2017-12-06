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

    public class Banji_update : Page
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
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Banji     Set Xueqi='", this.pulicss.GetFormatStr(this.Xueqi.SelectedValue), "',Nianji='", this.pulicss.GetFormatStr(this.Nianji.SelectedValue), "',Mingcheng='", this.pulicss.GetFormatStr(this.Mingcheng.Text), "',Shangkedidian='", this.pulicss.GetFormatStr(this.Shangkedidian.Text), "',BzUsername='", this.pulicss.GetFormatStr(this.BzUsername.Text), "',BzRealname='", this.pulicss.GetFormatStr(this.BzRealname.Text), "',RkUsername='", this.pulicss.GetFormatStr(this.RkUsername.Text), "',RkRealname='", this.pulicss.GetFormatStr(this.RkRealname.Text), 
                "',XldUsername='", this.pulicss.GetFormatStr(this.XldUsername.Text), "',XldRealname='", this.pulicss.GetFormatStr(this.XldRealname.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改班级设置[" + this.Mingcheng.Text + "]", "班级设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Banji.aspx'</script>");
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
                string sql = "select * from qp_sch_Banji where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    string str3 = "select id,NianjiMc  from qp_sch_Nianji where Xueqi='" + this.Xueqi.SelectedValue + "'  order by Xueqi asc";
                    this.list.Bind_DropDownList_nothing(this.Nianji, str3, "NianjiMc", "NianjiMc");
                    this.Nianji.SelectedValue = list["Nianji"].ToString();
                    this.Mingcheng.Text = list["Mingcheng"].ToString();
                    this.Shangkedidian.Text = list["Shangkedidian"].ToString();
                    this.BzUsername.Text = list["BzUsername"].ToString();
                    this.BzRealname.Text = list["BzRealname"].ToString();
                    this.RkUsername.Text = list["RkUsername"].ToString();
                    this.RkRealname.Text = list["RkRealname"].ToString();
                    this.XldUsername.Text = list["XldUsername"].ToString();
                    this.XldRealname.Text = list["XldRealname"].ToString();
                }
                list.Close();
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


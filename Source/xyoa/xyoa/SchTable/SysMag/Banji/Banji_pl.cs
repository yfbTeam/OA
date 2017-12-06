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

    public class Banji_pl : Page
    {
        protected Button Button1;
        protected Button Button2;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList Xueqi;
        protected DropDownList XueqiC;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_sch_Banji where Xueqi='" + this.XueqiC.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('" + this.XueqiC.SelectedValue + "学期已经存在！');</script>");
                list.Close();
            }
            else
            {
                list.Close();
                string str2 = "select * from qp_sch_Banji where  Xueqi='" + this.Xueqi.SelectedValue + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    string str3 = "insert into qp_sch_Banji  (Xueqi,Nianji,Mingcheng,Shangkedidian,BzUsername,BzRealname,RkUsername,RkRealname,XldUsername,XldRealname) values ('" + this.pulicss.GetFormatStr(this.XueqiC.SelectedValue) + "','" + reader2["Nianji"].ToString() + "','" + reader2["Mingcheng"].ToString() + "','" + reader2["Shangkedidian"].ToString() + "','" + reader2["BzUsername"].ToString() + "','" + reader2["BzRealname"].ToString() + "','" + reader2["RkUsername"].ToString() + "','" + reader2["RkRealname"].ToString() + "','" + reader2["XldUsername"].ToString() + "','" + reader2["XldRealname"].ToString() + "')";
                    this.List.ExeSql(str3);
                }
                reader2.Close();
                this.pulicss.InsertLog("批量新增班级设置", "班级设置");
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
                string str2 = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.XueqiC, str2, "Mingcheng", "Mingcheng");
                this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                this.BindAttribute();
            }
        }
    }
}


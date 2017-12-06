namespace xyoa.SchTable.SysMag.Nianji
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Nianji_pl : Page
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
            string sql = "select * from qp_sch_Nianji where Xueqi='" + this.XueqiC.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('" + this.XueqiC.SelectedValue + "学期已经存在！');</script>");
                list.Close();
            }
            else
            {
                list.Close();
                string str2 = "select * from qp_sch_Nianji where  Xueqi='" + this.Xueqi.SelectedValue + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    string str3 = "insert into qp_sch_Nianji  (Tianshu,Richeng1,Richeng2,Richeng3,Xueqi,NianjiMc,RuxueBiye,Kecheng,KechengX,Kaoshilx) values ('" + reader2["Tianshu"].ToString() + "','" + reader2["Richeng1"].ToString() + "','" + reader2["Richeng2"].ToString() + "','" + reader2["Richeng3"].ToString() + "','" + this.pulicss.GetFormatStr(this.XueqiC.SelectedValue) + "','" + reader2["NianjiMc"].ToString() + "','" + reader2["RuxueBiye"].ToString() + "','" + reader2["Kecheng"].ToString() + "','" + reader2["KechengX"].ToString() + "','" + reader2["Kaoshilx"].ToString() + "')";
                    this.List.ExeSql(str3);
                }
                reader2.Close();
                this.pulicss.InsertLog("批量新增年级设置", "年级设置");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Nianji.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Nianji.aspx");
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


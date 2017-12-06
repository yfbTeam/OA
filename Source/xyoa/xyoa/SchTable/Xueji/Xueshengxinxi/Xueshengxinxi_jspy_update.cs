namespace xyoa.SchTable.Xueji.Xueshengxinxi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueshengxinxi_jspy_update : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Pingyu;
        protected DropDownList PingyuS;
        private publics pulicss = new publics();
        protected Label XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;
        protected DropDownList Zongpin;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_sch_Stu_jspy     Set Xueqi='", this.Xueqi.SelectedValue, "',Xueduan='", this.Xueduan.SelectedValue, "',Zongpin='", this.Zongpin.SelectedValue, "',Pingyu='", this.pulicss.GetFormatStr(this.Pingyu.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改教师评语[" + this.XsId.Text + "]", "教师评语");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_jspy.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_jspy.aspx?id=" + base.Request.QueryString["Banji"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
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
                string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                string str2 = "select id,name  from qp_sch_DataFile where type='21' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_nothing(this.Zongpin, str2, "id", "name");
                string str3 = "select id,name  from qp_sch_DataFile where type='4' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.PingyuS, str3, "name", "name");
                string sql = "select * from qp_sch_Stu_jspy where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    this.Xueduan.SelectedValue = list["Xueduan"].ToString();
                    this.Zongpin.SelectedValue = list["Zongpin"].ToString();
                    this.Pingyu.Text = list["Pingyu"].ToString();
                }
                list.Close();
            }
        }
    }
}


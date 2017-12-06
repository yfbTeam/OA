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

    public class Xueshengxinxi_xxjl_update : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Jieshu;
        protected TextBox Kaishi;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label XsId;
        protected TextBox Xuexiao;
        protected TextBox Zhengmingren;
        protected TextBox Zhiwu;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_sch_Stu_xxjj     Set Kaishi='", this.pulicss.GetFormatStr(this.Kaishi.Text), "',Jieshu='", this.pulicss.GetFormatStr(this.Jieshu.Text), "',Xuexiao='", this.pulicss.GetFormatStr(this.Xuexiao.Text), "',Zhiwu='", this.pulicss.GetFormatStr(this.Zhiwu.Text), "',Zhengmingren='", this.pulicss.GetFormatStr(this.Zhengmingren.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改家庭信息[" + this.XsId.Text + "]", "家庭信息");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_xxjl.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_xxjl.aspx?id=" + base.Request.QueryString["Banji"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
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
                string sql = "select * from qp_sch_Stu_xxjj where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Zhiwu.Text = list["Zhiwu"].ToString();
                    this.Xuexiao.Text = list["Xuexiao"].ToString();
                    this.Kaishi.Text = list["Kaishi"].ToString();
                    this.Jieshu.Text = list["Jieshu"].ToString();
                    this.Zhengmingren.Text = list["Zhengmingren"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
            }
        }
    }
}


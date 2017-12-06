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

    public class Xueshengxinxi_qtxx_update : Page
    {
        protected Button Button1;
        protected TextBox Dabiao;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Leyuan;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Qita;
        protected TextBox Tigaoban;
        protected TextBox Xiaochehao;
        protected Label XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;
        protected TextBox Yanchangban;
        protected TextBox Yixiao;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Stu_qtxx     Set Xueqi='", this.Xueqi.SelectedValue, "',Xueduan='", this.Xueduan.SelectedValue, "',Xiaochehao='", this.pulicss.GetFormatStr(this.Xiaochehao.Text), "',Yanchangban='", this.pulicss.GetFormatStr(this.Yanchangban.Text), "',Tigaoban='", this.pulicss.GetFormatStr(this.Tigaoban.Text), "',Dabiao='", this.pulicss.GetFormatStr(this.Dabiao.Text), "',Yixiao='", this.pulicss.GetFormatStr(this.Yixiao.Text), "',Leyuan='", this.pulicss.GetFormatStr(this.Leyuan.Text), 
                "',Qita='", this.pulicss.GetFormatStr(this.Qita.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改其他信息[" + this.XsId.Text + "]", "其他信息");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_qtxx.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_qtxx.aspx?id=" + base.Request.QueryString["Banji"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
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
                string sql = "select * from qp_sch_Stu_qtxx where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    this.Xueduan.SelectedValue = list["Xueduan"].ToString();
                    this.Xiaochehao.Text = list["Xiaochehao"].ToString();
                    this.Yanchangban.Text = list["Yanchangban"].ToString();
                    this.Tigaoban.Text = list["Tigaoban"].ToString();
                    this.Dabiao.Text = list["Dabiao"].ToString();
                    this.Yixiao.Text = list["Yixiao"].ToString();
                    this.Leyuan.Text = list["Leyuan"].ToString();
                    this.Qita.Text = list["Qita"].ToString();
                }
                list.Close();
            }
        }
    }
}


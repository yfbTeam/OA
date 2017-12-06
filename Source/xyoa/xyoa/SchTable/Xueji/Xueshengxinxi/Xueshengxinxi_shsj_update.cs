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

    public class Xueshengxinxi_shsj_update : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected TextBox Dizhi;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Miaoshu;
        private publics pulicss = new publics();
        protected TextBox Shijian;
        protected TextBox Xiangmu;
        protected Label XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_sch_Stu_shsj     Set Xueqi='", this.Xueqi.SelectedValue, "',Xueduan='", this.Xueduan.SelectedValue, "',Xiangmu='", this.pulicss.GetFormatStr(this.Xiangmu.Text), "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Dizhi='", this.pulicss.GetFormatStr(this.Dizhi.Text), "',Miaoshu='", this.pulicss.GetFormatStr(this.Miaoshu.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改社会实践[" + this.XsId.Text + "]", "社会实践");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_shsj.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_shsj.aspx?id=" + base.Request.QueryString["Banji"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
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
                string sql = "select * from qp_sch_Stu_shsj where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    this.Xueduan.SelectedValue = list["Xueduan"].ToString();
                    this.Xiangmu.Text = list["Xiangmu"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Miaoshu.Text = list["Miaoshu"].ToString();
                }
                list.Close();
            }
        }
    }
}


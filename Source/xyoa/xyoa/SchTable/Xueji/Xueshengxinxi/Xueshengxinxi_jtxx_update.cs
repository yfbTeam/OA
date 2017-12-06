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

    public class Xueshengxinxi_jtxx_update : Page
    {
        protected Button Button1;
        protected TextBox Danwei;
        protected TextBox Dianhua;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected TextBox Dizhi;
        protected TextBox DwDizhi;
        protected HtmlForm form1;
        protected TextBox Guanxi;
        protected HtmlHead Head1;
        protected TextBox Jilu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Techang;
        protected TextBox Xingming;
        protected TextBox Xinxiang;
        protected TextBox Xiuxiri;
        protected Label XsId;
        protected TextBox Yixiang;
        protected TextBox Youzheng;
        protected TextBox Zhiwu;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Stu_jtxx     Set Xingming='", this.pulicss.GetFormatStr(this.Xingming.Text), "',Guanxi='", this.pulicss.GetFormatStr(this.Guanxi.Text), "',Dianhua='", this.pulicss.GetFormatStr(this.Dianhua.Text), "',Youzheng='", this.pulicss.GetFormatStr(this.Youzheng.Text), "',Xinxiang='", this.pulicss.GetFormatStr(this.Xinxiang.Text), "',Dizhi='", this.pulicss.GetFormatStr(this.Dizhi.Text), "',Danwei='", this.pulicss.GetFormatStr(this.Danwei.Text), "',DwDizhi='", this.pulicss.GetFormatStr(this.DwDizhi.Text), 
                "',Zhiwu='", this.pulicss.GetFormatStr(this.Zhiwu.Text), "',Xiuxiri='", this.pulicss.GetFormatStr(this.Xiuxiri.Text), "',Techang='", this.pulicss.GetFormatStr(this.Techang.Text), "',Yixiang='", this.pulicss.GetFormatStr(this.Yixiang.Text), "',Jilu='", this.pulicss.GetFormatStr(this.Jilu.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改家庭信息[" + this.XsId.Text + "]", "家庭信息");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_jtxx.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_jtxx.aspx?id=" + base.Request.QueryString["Banji"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
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
                string sql = "select * from qp_sch_Stu_jtxx where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Guanxi.Text = list["Guanxi"].ToString();
                    this.Dianhua.Text = list["Dianhua"].ToString();
                    this.Youzheng.Text = list["Youzheng"].ToString();
                    this.Xinxiang.Text = list["Xinxiang"].ToString();
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Danwei.Text = list["Danwei"].ToString();
                    this.DwDizhi.Text = list["DwDizhi"].ToString();
                    this.Zhiwu.Text = list["Zhiwu"].ToString();
                    this.Xiuxiri.Text = list["Xiuxiri"].ToString();
                    this.Techang.Text = list["Techang"].ToString();
                    this.Yixiang.Text = list["Yixiang"].ToString();
                    this.Jilu.Text = list["Jilu"].ToString();
                }
                list.Close();
            }
        }
    }
}


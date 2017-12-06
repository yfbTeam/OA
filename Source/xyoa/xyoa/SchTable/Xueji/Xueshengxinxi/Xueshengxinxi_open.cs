namespace xyoa.SchTable.Xueji.Xueshengxinxi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class Xueshengxinxi_open : Page
    {
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        private Db List = new Db();
        private publics pulicss = new publics();
        public string showtitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ViewState["Xueqi"] = this.divsch.GetXueqi();
            this.ViewState["Xueduan"] = this.divsch.GetXueduan();
            if (base.Request.QueryString["url"].ToString() == "1")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_jtxx.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "2")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_xxjl.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "3")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_jspy.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "4")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_hjqk.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "5")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_cfqk.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "6")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_rzqk.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "7")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_jxqk.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "8")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_wthd.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "9")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_shsj.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "10")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_tjxx.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "11")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_jfxx.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "12")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_qtxx.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
            if (base.Request.QueryString["url"].ToString() == "13")
            {
                base.Response.Redirect(string.Concat(new object[] { "Xueshengxinxi_kscj.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "" }));
            }
        }
    }
}


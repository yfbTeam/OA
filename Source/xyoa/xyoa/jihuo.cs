namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class jihuo : Page
    {
        protected Button Button3;
        protected Button Button4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox TextBox1;
        protected TextBox TextBox2;

        protected void Button3_Click1(object sender, EventArgs e)
        {
            try
            {
                string str = null;
                str = this.pulicss.DESDecrypt(this.TextBox1.Text, "5", "6");
                if (this.pulicss.GetMAC() == str)
                {
                    string sql = "Update qp_oa_filemain set reg='0'";
                    this.List.ExeSql(sql);
                    base.Response.Write("<script language=javascript>alert('恭喜您，重新激活成功，您获取30天的软件试用或者进入系统信息填写正版注册码以后成为正式用户！');window.parent.location = '/default.aspx'</script>");
                }
                else
                {
                    base.Response.Write("<script>alert('激活失败，请检查激活码是否有效！');</Script>");
                }
            }
            catch
            {
                base.Response.Write("<script>alert('激活失败，请检查激活码是否有效！');</Script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script language=javascript>window.parent.location = '/default.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.TextBox2.Text = "" + this.pulicss.GetMAC() + "";
            }
            this.Button3.Attributes["onclick"] = "javascript:return CheckForm();";
        }
    }
}


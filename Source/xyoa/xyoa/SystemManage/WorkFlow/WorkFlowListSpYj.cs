namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListSpYj : Page
    {
        protected Button Button1;
        protected TextBox DropDownList1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Write(string.Concat(new object[] { "<script language=javascript>window.opener.setyijian('", base.Request.QueryString["picname"], "','", this.DropDownList1.Text, "(", this.Session["Realname"], " ", DateTime.Now.ToString(), @")\n---------------------------\n');window.close();</script>" }));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}


namespace xyoa.SystemManage.WorkFlow
{
    using Ajax;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using xyoa;

    public class DIYForm_add_jklb : Page
    {
        protected HtmlForm form1;
        private Db List = new Db();
        protected HtmlInputText Name;
        protected HtmlInputText Number;
        private publics pulicss = new publics();
        protected HtmlInputText TextBox2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.Number.Value = base.Request.QueryString["Number"].ToString();
                    if (!base.IsPostBack)
                    {
                        Random random = new Random();
                        string str = random.Next(0x2710).ToString();
                        this.TextBox2.Value = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                    }
                }
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            }
        }
    }
}


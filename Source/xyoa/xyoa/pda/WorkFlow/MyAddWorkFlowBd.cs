namespace xyoa.pda.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAddWorkFlowBd : Page
    {
        protected Label biaodan;
        protected Button Button1;
        public string CbName;
        public string CbUser;
        public string FlowNumber;
        protected HtmlForm form1;
        protected Label fujian;
        protected TextBox GlNum;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Name;
        public string NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        public string Shuxing;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyAddWorkFlow.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.biaodan.Text = list["FileContent"].ToString();
                    this.pulicss.GetFileSj(this.Number.Text, this.fujian);
                    this.ViewState["BDNumber"] = list["FormNumber"].ToString();
                    string str2 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                    this.List.ExeSql(str2);
                    string str3 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    while (reader2.Read())
                    {
                        StateBag bag = ViewState;
                        object obj2 = bag["url"];
                        (bag = this.ViewState)["url"] = string.Concat(new object[] { obj2, "window.L", reader2["Number"], ".location.href='/WorkFlow/AddWorkFlow_spyj.aspx?Number='+num+'&Buzhou=", reader2["sqlstr"], "&key=", this.ViewState["YijianZb"], "';" });
                    }
                    reader2.Close();
                }
                list.Close();
            }
        }
    }
}


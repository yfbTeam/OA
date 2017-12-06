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

    public class WorkFlowListSp_zj_zy : Page
    {
        protected HtmlForm form1;
        protected TextBox GlNum;
        protected TextBox GqUpNodeNumKey;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string str = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(str);
                if (list.Read())
                {
                    this.GqUpNodeNumKey.Text = list["UpNodeNum"].ToString();
                    this.ViewState["FormName"] = list["FormName"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.ViewState["lshid"] = int.Parse(list["Sequence"].ToString());
                    this.ViewState["whname"] = list["Name"].ToString();
                    this.ViewState["FileContent"] = list["FileContent"].ToString();
                    this.ViewState["Number"] = list["Number"].ToString();
                    string str2 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                    this.List.ExeSql(str2);
                    this.ViewState["UpNodeNums"] = list["UpNodeNum"].ToString();
                    string str3 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", list["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "'" });
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        this.ViewState["IfZb"] = reader2["IfZb"].ToString();
                    }
                    reader2.Close();
                }
            }
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  State='正在办理', UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), "自由流程", "办理工作" + this.ViewState["whname"].ToString() + "", this.ViewState["IfZb"].ToString());
            base.Response.Redirect("WorkFlowListSp_Next_zy.aspx?UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "&tmp=" + base.Request.QueryString["tmp"] + "");
        }
    }
}


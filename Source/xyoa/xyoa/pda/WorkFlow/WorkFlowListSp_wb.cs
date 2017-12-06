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

    public class WorkFlowListSp_wb : Page
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
                string str = "select * from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                SqlDataReader list = this.List.GetList(str);
                if (list.Read())
                {
                    this.ViewState["NodeSite"] = list["NodeSite"].ToString();
                    this.ViewState["YijianZb"] = list["YijianZb"].ToString();
                    this.ViewState["NodeName"] = list["NodeName"].ToString();
                    this.ViewState["UpNodeNum"] = list["UpNodeNum"].ToString();
                    this.ViewState["UpNodeNumKey"] = list["UpNodeNum"].ToString();
                    this.ViewState["NodeId"] = list["id"].ToString();
                    this.ViewState["WriteFileID"] = "" + list["WriteFileID"].ToString() + "0";
                    this.ViewState["SecFileID"] = "" + list["SecFileID"].ToString() + "0";
                    this.ViewState["HongFileID"] = "" + list["HongFileID"].ToString() + "0";
                    this.GqUpNodeNumKey.Text = list["UpNodeNum"].ToString();
                    string str2 = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.ViewState["FormName"] = reader2["FormName"].ToString();
                        this.Number.Text = reader2["Number"].ToString();
                        this.GlNum.Text = reader2["GlNum"].ToString();
                        this.ViewState["lshid"] = int.Parse(reader2["Sequence"].ToString());
                        this.ViewState["whname"] = reader2["Name"].ToString();
                        this.ViewState["FileContent"] = reader2["FileContent"].ToString();
                        this.ViewState["Number"] = reader2["Number"].ToString();
                        string str3 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", reader2["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", reader2["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                        this.List.ExeSql(str3);
                        this.ViewState["UpNodeNums"] = reader2["UpNodeNum"].ToString();
                        string str4 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", reader2["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", reader2["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "'" });
                        SqlDataReader reader3 = this.List.GetList(str4);
                        if (reader3.Read())
                        {
                            this.ViewState["IfZb"] = reader3["IfZb"].ToString();
                        }
                        reader3.Close();
                    }
                }
                list.Close();
            }
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.ViewState["Number"].ToString(), "','", int.Parse(this.ViewState["lshid"].ToString()), "','", this.ViewState["whname"].ToString(), "','", this.pulicss.GetFormatStrbjq(this.ViewState["FileContent"].ToString()), "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(sql);
            string str6 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(str6);
            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "办理工作" + this.ViewState["whname"].ToString() + "", this.ViewState["IfZb"].ToString());
            string str7 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.ViewState["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNums"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
            this.List.ExeSql(str7);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkFlowListAll.aspx'</script>");
        }
    }
}


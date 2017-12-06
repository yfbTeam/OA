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

    public class WorkFlowListSp_zj : Page
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
                SqlDataReader reader = this.List.GetList(str);
                if (reader.Read())
                {
                    this.ViewState["ZbZhuanjiao"] = reader["ZbZhuanjiao"].ToString();
                    this.ViewState["NodeSite"] = reader["NodeSite"].ToString();
                    this.ViewState["YijianZb"] = reader["YijianZb"].ToString();
                    this.ViewState["NodeName"] = reader["NodeName"].ToString();
                    this.ViewState["UpNodeNum"] = reader["UpNodeNum"].ToString();
                    this.ViewState["UpNodeNumKey"] = reader["UpNodeNum"].ToString();
                    this.ViewState["NodeId"] = reader["id"].ToString();
                    this.ViewState["WriteFileID"] = "" + reader["WriteFileID"].ToString() + "0";
                    this.ViewState["SecFileID"] = "" + reader["SecFileID"].ToString() + "0";
                    this.ViewState["HongFileID"] = "" + reader["HongFileID"].ToString() + "0";
                    this.GqUpNodeNumKey.Text = reader["UpNodeNum"].ToString();
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
                reader.Close();
            }
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.ViewState["Number"].ToString(), "','", int.Parse(this.ViewState["lshid"].ToString()), "','", this.ViewState["whname"].ToString(), "','", this.pulicss.GetFormatStrbjq(this.ViewState["FileContent"].ToString()), "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(sql);
            string str6 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(str6);
            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "办理工作" + this.ViewState["whname"].ToString() + "", this.ViewState["IfZb"].ToString());
            string str7 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
            SqlDataReader list = this.List.GetList(str7);
            if (list.Read())
            {
                string str8 = string.Concat(new object[] { "select id from qp_oa_AddWorkFlowGc where Keyid='", list["id"], "' and GlNum='", list["GlNum"], "' and username='", this.Session["username"], "'" });
                SqlDataReader reader5 = this.List.GetList(str8);
                if (reader5.Read())
                {
                    string str9 = string.Concat(new object[] { 
                        "Update qp_oa_AddWorkFlowGc  Set JinJiChengDu='", list["JinJiChengDu"], "',Shuxing='", list["Shuxing"], "',UpNodeName='", list["UpNodeName"], "',NowTimes='", DateTime.Now.ToString(), "',FormName='", list["FormName"], "',Number='", list["Number"], "',Sequence='", list["Sequence"], "',Name='", list["Name"], 
                        "',FileContent='", list["FileContent"], "'  where Keyid='", list["id"], "' and GlNum='", list["GlNum"], "' and username='", this.Session["username"], "'"
                     });
                    this.List.ExeSql(str9);
                }
                else
                {
                    string str10 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlowGc (GlNum,JinJiChengDu,Shuxing,UpNodeName,Keyid,FormId,FormName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,Username,Realname,NowTimes) values ('", list["GlNum"], "','", list["JinJiChengDu"], "','", list["Shuxing"], "','", list["UpNodeName"], "','", list["id"], "','", list["FormId"], "','", list["FormName"], "','", list["Number"], 
                        "','", list["Sequence"], "','", list["Name"], "','", list["FileContent"], "','", list["FqUsername"], "','", list["FqRealname"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                        "')"
                     });
                    this.List.ExeSql(str10);
                }
                reader5.Close();
            }
            list.Close();
            if (this.ViewState["NodeSite"].ToString() == "结束")
            {
                base.Response.Redirect("WorkFlowListSp_NextJs.aspx?UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "&tmp=" + base.Request.QueryString["tmp"] + "");
            }
            else
            {
                base.Response.Redirect("WorkFlowListSp_Next.aspx?UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "&tmp=" + base.Request.QueryString["tmp"] + "");
            }
        }
    }
}


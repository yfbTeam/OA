namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListJk_show : Page
    {
        protected HtmlInputButton Button10;
        protected HtmlInputButton Button14;
        protected HtmlInputButton Button16;
        protected HtmlInputButton Button5;
        protected HtmlInputButton Button7;
        protected TextBox ContractContent;
        public string ddstr;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        public string FormName;
        public string FormNumber;
        protected TextBox GqUpNodeNumKey;
        protected GridView GridView1;
        protected HtmlHead Head1;
        public string IfZb;
        public string JbHuitui;
        public string JbQuanxian;
        public string JcZhuanjiao;
        protected Label JinJiChengDu;
        public int LcNameId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        public int lshid;
        public string NodeId;
        public string NodeName;
        protected TextBox Number;
        public string Numbers;
        private publics pulicss = new publics();
        public string SecFileID;
        private divform showform = new divform();
        public string ShuXing;
        protected TextBox TextBox1;
        public string UpNodeNum;
        public string UpNodeNumKey;
        public string UpNodeNums;
        protected TextBox whendname;
        protected TextBox whname;
        protected Label whname1;
        protected TextBox whstartname;
        public string WriteFileID;
        public string YijianJb;
        public string YijianZb;
        public string YzSealNumber;
        public string ZbHuitui;
        public string ZbQuanxian;
        public string ZbZhuanjiao;

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        public void DataBindToGridview()
        {
            string sql = "select * from qp_oa_AddWorkFlowMessage  where Number='" + this.Number.Text + "' order by id asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sql = "select * from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ZbQuanxian = list["ZbQuanxian"].ToString();
                    this.JbQuanxian = list["JbQuanxian"].ToString();
                    this.YijianZb = list["YijianZb"].ToString();
                    this.YijianJb = list["YijianJb"].ToString();
                    this.ZbHuitui = list["ZbHuitui"].ToString();
                    this.JbHuitui = list["JbHuitui"].ToString();
                    this.JcZhuanjiao = list["JcZhuanjiao"].ToString();
                    this.ZbZhuanjiao = list["ZbZhuanjiao"].ToString();
                    this.NodeName = list["NodeName"].ToString();
                    this.UpNodeNum = list["UpNodeNum"].ToString();
                    this.UpNodeNumKey = list["UpNodeNum"].ToString();
                    this.GqUpNodeNumKey.Text = list["UpNodeNum"].ToString();
                    this.NodeId = list["id"].ToString();
                    this.WriteFileID = "" + list["WriteFileID"].ToString() + "0";
                    this.SecFileID = "" + list["SecFileID"].ToString() + "0";
                    string str2 = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.ViewState["BDNumber"] = reader2["FormNumber"].ToString();
                        this.JinJiChengDu.Text = this.pulicss.SystemCode("10", reader2["JinJiChengDu"].ToString());
                        string str3 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                        SqlDataReader reader3 = this.List.GetList(str3);
                        while (reader3.Read())
                        {
                            StateBag bag = ViewState;
                            object obj2 = bag["url"];
                            (bag = this.ViewState)["url"] = string.Concat(new object[] { obj2, "try{window.L", reader3["Number"], ".location.href='AddWorkFlow_spyj.aspx?Number='+num+'&Buzhou=", reader3["sqlstr"], "&key=1';}catch(err){}" });
                        }
                        reader3.Close();
                        this.IfZb = "主办";
                        this.whname1.Text = reader2["Name"].ToString();
                        this.whname.Text = reader2["Name"].ToString();
                        this.ShuXing = reader2["ShuXing"].ToString();
                        this.lshid = int.Parse(reader2["Sequence"].ToString());
                        this.Number.Text = reader2["Number"].ToString();
                        this.Numbers = reader2["Number"].ToString();
                        this.UpNodeNums = reader2["UpNodeNum"].ToString();
                        if (this.IfZb == "主办")
                        {
                            this.whname1.Visible = true;
                            this.whname.Visible = false;
                            this.whstartname.Visible = false;
                            this.whendname.Visible = false;
                            this.FormName = reader2["FormName"].ToString();
                            this.FormNumber = reader2["FormNumber"].ToString();
                            this.ContractContent.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                            this.TextBox1.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                        }
                        this.showform.AddWorkFlowLog("110", this.Number.Text, this.FormName, this.NodeName, "查看工作" + this.whstartname.Text + "" + this.whname.Text + "" + this.whendname.Text + "", this.IfZb);
                        string str4 = "select * from qp_oa_FormFile where  KeyFile='" + this.ViewState["BDNumber"] + "' and Type!='[印章域]'";
                        SqlDataReader reader4 = this.List.GetList(str4);
                        while (reader4.Read())
                        {
                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader4["Number"].ToString() + "", "name=" + reader4["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader4["Number"].ToString() + "\"", "name=" + reader4["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                            this.TextBox1.Text = this.ContractContent.Text;
                        }
                        reader4.Close();
                    }
                    reader2.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到此流程，有可能此流程已被删除！');window.close();</script>");
                    return;
                }
                list.Close();
                this.YzSealNumber = this.Number.Text;
                this.DataBindToGridview();
                this.BindFjlbList();
            }
        }
    }
}


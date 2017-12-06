namespace xyoa.pda.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListSp_NextJs : Page
    {
        protected Button Button1;
        protected Button Button5;
        protected CheckBox C3;
        protected CheckBox C4;
        protected CheckBox C5;
        protected CheckBox C6;
        protected HtmlForm form1;
        protected RadioButtonList FormName;
        protected TextBox GlNum1;
        protected HtmlHead Head1;
        protected ImageButton ImageButton4;
        protected HtmlImage IMG2;
        protected HtmlImage IMG3;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox txtSmsContent;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListAll.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.ViewState["WfNumber"], "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' and States!='已委托'" });
            this.List.ExeSql(sql);
            string str2 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "' and States!='已委托'";
            this.List.ExeSql(str2);
            if (this.C3.Checked)
            {
                this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已结束，结束时间", DateTime.Now.ToString(), "" }), this.ViewState["FqUsername"].ToString(), this.ViewState["FqRealname"].ToString(), "#");
            }
            if (this.C4.Checked)
            {
                string str3 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"].ToString() + "' ";
                SqlDataReader reader = this.List.GetList(str3);
                if (reader.Read())
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已结束，结束时间", DateTime.Now.ToString(), "" }));
                }
                reader.Close();
            }
            string str4 = null;
            string str5 = null;
            str5 = "" + this.ViewState["JbObjectId"] + "";
            ArrayList list = new ArrayList();
            string[] strArray = str5.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str4 = str4 + "'" + strArray[i] + "',";
            }
            str4 = str4 + "'0'";
            string str6 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str4 + ") ";
            SqlDataReader reader2 = this.List.GetList(str6);
            while (reader2.Read())
            {
                if (this.C5.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "等待您办理的工作[", this.ViewState["Name"], "]已结束，结束时间", DateTime.Now.ToString(), "" }), reader2["username"].ToString(), reader2["realname"].ToString(), "#");
                }
                if (this.C6.Checked)
                {
                    this.pulicss.InsertSms(reader2["MoveTel"].ToString(), string.Concat(new object[] { "等待您办理的工作[", this.ViewState["Name"], "]已结束，结束时间", DateTime.Now.ToString(), "" }));
                }
            }
            reader2.Close();
            string str7 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and id='", base.Request.QueryString["id"], "'" });
            SqlDataReader reader3 = this.List.GetList(str7);
            if (!reader3.Read())
            {
                string str8 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                this.List.ExeSql(str8);
            }
            reader3.Close();
            string str9 = "Update qp_oa_AddWorkFlow  Set State='正常结束',NodeName='正常结束',UpNodeName='正常结束'  where id='" + base.Request.QueryString["id"] + "'";
            this.List.ExeSql(str9);
            string str10 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
            SqlDataReader reader4 = this.List.GetList(str10);
            if (reader4.Read())
            {
                string str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowGd (JinJiChengDu,Keyid,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,Username,Realname,NowTimes,Shuxing,GdId) values ('", reader4["JinJiChengDu"], "','", reader4["id"], "','", reader4["FormId"], "','", reader4["FormNumber"], "','", reader4["FormName"], "','", reader4["FlowId"], "','", reader4["FlowNumber"], "','", reader4["FlowName"], 
                    "','", reader4["Number"], "','", reader4["Sequence"], "','", reader4["Name"], "','", reader4["FileContent"], "','", reader4["FqUsername"], "','", reader4["FqRealname"], "','", reader4["YJBObjectId"], "','", reader4["YJBObjecName"], 
                    "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','", reader4["Shuxing"], "','", this.ViewState["OverSetConId"], "')"
                 });
                this.List.ExeSql(str11);
            }
            reader4.Close();
            base.Response.Write("<script language=javascript>alert('结束成功！');window.location.href='WorkFlowListAll.aspx'</script>");
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
                string sql = "select * from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["FormNames"] = list["FormName"].ToString();
                    this.ViewState["Sequence"] = list["Sequence"].ToString();
                    this.ViewState["Name"] = list["Name"].ToString();
                    this.ViewState["NodeName"] = list["UpNodeName"].ToString();
                    this.ViewState["UpNodeNum"] = list["UpNodeNum"].ToString();
                    this.txtSmsContent.Text = "工作流结束提醒：" + list["Name"].ToString() + "";
                    this.ViewState["FqUsername"] = list["FqUsername"].ToString();
                    this.ViewState["FqRealname"] = list["FqRealname"].ToString();
                    this.ViewState["JbObjectId"] = list["JbObjectId"].ToString();
                    this.ViewState["JbObjectName"] = list["JbObjectName"].ToString();
                    this.ViewState["FlowNumber"] = list["FlowNumber"].ToString();
                    this.ViewState["WfNumber"] = list["Number"].ToString();
                    string str2 = "select OverSetConId from qp_oa_WorkFlowName where  id='" + list["FlowId"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.ViewState["OverSetConId"] = reader2["OverSetConId"].ToString();
                    }
                    reader2.Close();
                    this.GlNum1.Text = list["GlNum"].ToString();
                }
                list.Close();
                this.ViewState["ZjBLrealname"] = "";
                string str3 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' order by id asc" });
                SqlDataReader reader3 = this.List.GetList(str3);
                while (reader3.Read())
                {
                    StateBag bag = ViewState;
                    object obj2 = bag["ZjBLrealname"];
                    (bag = this.ViewState)["ZjBLrealname"] = string.Concat(new object[] { obj2, "", reader3["BLrealname"], "(", reader3["States"], ")，" });
                }
                reader3.Close();
                string str4 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' order by id asc" });
                SqlDataReader reader4 = this.List.GetList(str4);
                while (reader4.Read())
                {
                    this.ViewState["IfZb"] = reader4["BLrealname"].ToString();
                }
                reader4.Close();
            }
        }
    }
}


namespace xyoa.pda.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListYj : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected TextBox GlNum;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label JinJiChengDu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox SpContent;
        protected TextBox whendname;
        protected DropDownList Yinzhang;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListAll.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = "";
            if (this.Yinzhang.SelectedValue != "请选择")
            {
                str = "<img src=\"/seal/" + this.Yinzhang.SelectedValue + "\" width=\"140px\" height=\"100px\"  hspace=\"10\">";
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowSeal (YzNum,MkName,Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('", this.Number.Text, "','", this.ViewState["NodeName"], "','", this.ViewState["YzSealNumber"], "','", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Page.Request.UserHostAddress, 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(sql);
                string str3 = string.Concat(new object[] { "insert into qp_oa_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["NodeName"], "','", DateTime.Now.ToString(), "','", this.Page.Request.UserHostAddress, "')" });
                this.List.ExeSql(str3);
            }
            if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                string str4 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str4);
            }
            this.pulicss.InsertLog("新增办理意见", "手机平台");
            this.SpContent.Text = "";
            this.DataBindToGridview();
        }

        public void DataBindToGridview()
        {
            string str;
            if (this.ViewState["YijianZb"].ToString() == "1")
            {
                str = "select * from qp_oa_AddWorkFlowMessage  where Number='" + this.Number.Text + "' order by id asc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
            else if (this.ViewState["YijianZb"].ToString() == "2")
            {
                str = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowMessage  where Number='", this.Number.Text, "' and Buzhou='", this.ViewState["NodeName"], "' order by id asc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
            else
            {
                str = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowMessage  where Number='", this.Number.Text, "' and username='", this.Session["Username"], "' order by id asc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select Newname,Name+'('+YxType+')' as Name  from qp_oa_YinZhang where Username='" + this.Session["Username"] + "' and  State='正常' ";
                this.list.Bind_DropDownList(this.Yinzhang, sQL, "Newname", "Name");
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button2.Attributes["onclick"] = "javascript:return chknull();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = "select * from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["NodeNum"] = list["NodeNum"].ToString();
                    this.ViewState["YijianZb"] = list["YijianZb"].ToString();
                    this.ViewState["NodeName"] = list["NodeName"].ToString();
                    this.ViewState["UpNodeNum"] = list["UpNodeNum"].ToString();
                    this.ViewState["UpNodeNumKey"] = list["UpNodeNum"].ToString();
                    this.ViewState["NodeId"] = list["id"].ToString();
                    this.ViewState["WriteFileID"] = "" + list["WriteFileID"].ToString() + "0";
                    this.ViewState["SecFileID"] = "" + list["SecFileID"].ToString() + "0";
                    this.ViewState["HongFileID"] = "" + list["HongFileID"].ToString() + "0";
                    string str3 = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        this.JinJiChengDu.Text = this.pulicss.SystemCode("10", reader2["JinJiChengDu"].ToString());
                        this.Number.Text = reader2["Number"].ToString();
                        this.GlNum.Text = reader2["GlNum"].ToString();
                        this.ViewState["lshid"] = int.Parse(reader2["Sequence"].ToString());
                        this.ViewState["whname"] = reader2["Name"].ToString();
                        string str4 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", reader2["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", reader2["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                        this.List.ExeSql(str4);
                        string str5 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", reader2["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", reader2["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "'" });
                        SqlDataReader reader3 = this.List.GetList(str5);
                        if (reader3.Read())
                        {
                            this.ViewState["IfZb"] = reader3["IfZb"].ToString();
                        }
                        reader3.Close();
                    }
                }
                list.Close();
                this.ViewState["YzSealNumber"] = this.Number.Text;
                this.DataBindToGridview();
            }
        }
    }
}


namespace xyoa.pda.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListYj_zy : Page
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
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','自由流程','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(str4);
            }
            this.pulicss.InsertLog("新增办理意见", "手机平台");
            this.SpContent.Text = "";
            this.DataBindToGridview();
        }

        public void DataBindToGridview()
        {
            string sql = "select * from qp_oa_AddWorkFlowMessage  where Number='" + this.Number.Text + "' order by id asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
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
                string sql = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.JinJiChengDu.Text = this.pulicss.SystemCode("10", list["JinJiChengDu"].ToString());
                    this.Number.Text = list["Number"].ToString();
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.ViewState["lshid"] = int.Parse(list["Sequence"].ToString());
                    this.ViewState["whname"] = list["Name"].ToString();
                    string str3 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                    this.List.ExeSql(str3);
                    string str4 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", list["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "'" });
                    SqlDataReader reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        this.ViewState["IfZb"] = reader2["IfZb"].ToString();
                    }
                    reader2.Close();
                }
                this.ViewState["YzSealNumber"] = this.Number.Text;
                this.DataBindToGridview();
            }
        }
    }
}


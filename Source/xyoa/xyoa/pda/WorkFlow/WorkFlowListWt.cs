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

    public class WorkFlowListWt : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected CheckBox C1;
        protected CheckBox C2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Realname;
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected DropDownList Wtrealname;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListAll.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            string sql = "select Number,UpNodeNum,UpNodeName,FormName,Name,GlNum,JbObjectId,JbObjectName from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "select id,IfZb,LcNum,GlNum from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and GlNum='", list["GlNum"], "'" });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    string str3;
                    if (reader2["IfZb"].ToString() == "主办")
                    {
                        str3 = "Update qp_oa_AddWorkFlow  Set ZbObjectId='" + this.Wtrealname.SelectedValue + "',ZbObjectName='" + this.Wtrealname.SelectedItem.Text + "'  where id='" + base.Request.QueryString["id"] + "'";
                        this.List.ExeSql(str3);
                    }
                    else
                    {
                        string str4 = "" + list["JbObjectId"].ToString().Replace("" + this.Session["username"].ToString() + ",", "" + this.Wtrealname.SelectedValue + ",") + "";
                        string str5 = "" + list["JbObjectName"].ToString().Replace("" + this.Session["realname"].ToString() + ",", "" + this.Wtrealname.SelectedValue + ",") + "";
                        str3 = "Update qp_oa_AddWorkFlow  Set JbObjectId='" + str4 + "',JbObjectName='" + str5 + "'  where id='" + base.Request.QueryString["id"] + "'";
                        this.List.ExeSql(str3);
                    }
                    string str6 = "Update qp_oa_AddWorkFlowPicRy  Set States='已委托',EndTime='" + DateTime.Now.ToString() + "',WtUsername='" + this.Wtrealname.SelectedValue + "',WtRealname='" + this.Wtrealname.SelectedItem.Text + "'  where id='" + reader2["id"].ToString() + "'";
                    this.List.ExeSql(str6);
                    string str7 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlowPicRy (XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb,GlNum) values ('", list["UpNodeNum"], "','", reader2["LcNum"], "','", list["Number"], "','", this.Wtrealname.SelectedValue, "','", this.Wtrealname.SelectedItem.Text, "','", DateTime.Now.ToString(), "','','未接收','", reader2["IfZb"].ToString(), "','", reader2["GlNum"].ToString(), 
                        "')"
                     });
                    this.List.ExeSql(str7);
                    this.showform.AddWorkFlowLog("110", list["Number"].ToString(), list["FormName"].ToString(), list["UpNodeName"].ToString(), "委托工作［" + list["Name"].ToString() + "］予" + this.Wtrealname.SelectedItem.Text + "", reader2["IfZb"].ToString());
                }
                reader2.Close();
            }
            list.Close();
            if (this.C1.Checked)
            {
                this.pulicss.InsertMessage(this.txtSmsContent.Text, this.Wtrealname.SelectedValue, this.Wtrealname.SelectedItem.Text, "/WorkFlow/WorkFlowList.aspx");
            }
            if (this.C2.Checked)
            {
                string str8 = "select username,realname,MoveTel from qp_oa_Username where  username='" + this.Wtrealname.SelectedValue + "' ";
                SqlDataReader reader3 = this.List.GetList(str8);
                if (reader3.Read())
                {
                    this.pulicss.InsertSms(reader3["MoveTel"].ToString(), this.txtSmsContent.Text);
                }
                reader3.Close();
            }
            this.pulicss.InsertLog("设置工作委托", "待办工作");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkFlowListAll.aspx'</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = "";
            if (this.Realname.Text != "")
            {
                str = str + " and A.Realname like '%" + this.pulicss.GetFormatStr(this.Realname.Text) + "%'";
            }
            string sQL = string.Concat(new object[] { "select A.id,A.Username, A.Realname from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0' and  Username!='", this.Session["username"], "'  ", str, " order by A.paixu asc" });
            this.list.Bind_DropDownList_nothing(this.Wtrealname, sQL, "Username", "Realname");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select A.id,A.Username, A.Realname from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0' and  Username!='" + this.Session["username"] + "'  order by A.paixu asc";
                this.list.Bind_DropDownList_nothing(this.Wtrealname, sQL, "Username", "Realname");
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button2.Attributes["onclick"] = "javascript:return chknull();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = "select Name from qp_oa_AddWorkFlow where  id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.txtSmsContent.Text = string.Concat(new object[] { "您有工作委托需要办理，工作名称：", list["Name"].ToString(), "，委托人：", this.Session["realname"], "" });
                }
                list.Close();
            }
        }
    }
}


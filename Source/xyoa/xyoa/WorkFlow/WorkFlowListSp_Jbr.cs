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

    public class WorkFlowListSp_Jbr : Page
    {
        protected Button Button1;
        protected CheckBox C1;
        protected CheckBox C2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        private Db List = new Db();
        protected Label Name;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected TextBox Wtrealname;
        protected TextBox Wtusername;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C2, ",14,", this.pulicss.GetSms());
            this.Wtrealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.Wtusername.Text == ("" + this.Session["username"] + ""))
            {
                base.Response.Write("<script language=javascript>alert('增加失败！不能新增自己！');</script>");
            }
            else
            {
                string sql = "select Number,UpNodeNum,UpNodeName,FormName,Name from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = string.Concat(new object[] { "select id,IfZb,LcNum,GlNum from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "'" });
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        string str3 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", reader2["GlNum"], "','", list["UpNodeNum"], "','", reader2["LcNum"], "','", list["Number"], "','", this.Wtusername.Text, "','", this.Wtrealname.Text, "','", DateTime.Now.ToString(), "','','未接收','经办')" });
                        this.List.ExeSql(str3);
                        this.showform.AddWorkFlowLog("110", list["Number"].ToString(), list["FormName"].ToString(), list["UpNodeName"].ToString(), "新增经办人" + this.Wtrealname.Text + "", reader2["IfZb"].ToString());
                    }
                    reader2.Close();
                }
                list.Close();
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage(this.txtSmsContent.Text, this.Wtusername.Text, this.Wtrealname.Text, "/WorkFlow/WorkFlowList.aspx");
                }
                if (this.C2.Checked)
                {
                    string str4 = "select username,realname,MoveTel from qp_oa_Username where  username='" + this.Wtusername.Text + "' ";
                    SqlDataReader reader3 = this.List.GetList(str4);
                    if (reader3.Read())
                    {
                        this.pulicss.InsertSms(reader3["MoveTel"].ToString(), this.txtSmsContent.Text);
                    }
                    reader3.Close();
                }
                this.pulicss.InsertLog("新增经办人", "待办工作");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_AddWorkFlow where  id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.txtSmsContent.Text = "您有新的工作需要办理，工作名称：" + list["Name"].ToString() + "";
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


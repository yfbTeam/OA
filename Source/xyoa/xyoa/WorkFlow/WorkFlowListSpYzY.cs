namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListSpYzY : Page
    {
        protected Button Button1;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected TextBox Password;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Password.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button1.click(); return false;}";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
            string sql = "select * from qp_oa_YinZhang where Newname='" + this.DropDownList1.SelectedValue + "' and Password='" + str + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.pulicss.InsertLog("使用印章[" + this.DropDownList1.SelectedItem.Text + "]", "待办工作");
                string str3 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowSeal (YzNum,MkName,Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('", this.Number.Text, "','", base.Request.QueryString["NodeName"], "','", base.Request.QueryString["Number"], "','", this.DropDownList1.SelectedItem.Text, "','", this.DropDownList1.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Page.Request.UserHostAddress, 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str3);
                string str4 = string.Concat(new object[] { "insert into qp_oa_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('", this.DropDownList1.SelectedItem.Text, "','", this.DropDownList1.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", base.Request.QueryString["NodeName"], "','", DateTime.Now.ToString(), "','", this.Page.Request.UserHostAddress, "')" });
                this.List.ExeSql(str4);
                base.Response.Write(string.Concat(new object[] { 
                    "<script language=javascript>if (window.opener != undefined) {window.opener.returnValue =\"", base.Request.QueryString["picname"], "|", this.DropDownList1.SelectedValue, "|使用人：", this.Session["realname"], "，使用时间：", DateTime.Now.ToString(), "，使用步骤：", base.Request.QueryString["NodeName"], "\";}else {window.returnValue=\"", base.Request.QueryString["picname"], "|", this.DropDownList1.SelectedValue, "|使用人：", this.Session["realname"], 
                    "，使用时间：", DateTime.Now.ToString(), "，使用步骤：", base.Request.QueryString["NodeName"], "\";}window.close();</script>"
                 }));
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('密码错误');</script>");
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select  *  from qp_oa_WorkFlowNameYz where Formid='", this.pulicss.GetFormatStr(base.Request.QueryString["Formid"]), "' and YzNumber='", this.pulicss.GetFormatStr(base.Request.QueryString["picname"]), "' and ((CHARINDEX(',", this.Session["username"], ",',','+SyUsername+',') > 0 ) or SyUsername='全部人员')" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if ((list["NodeName"].ToString() != "全部步骤") && (list["NodeName"].ToString() != base.Request.QueryString["NodeName"].ToString()))
                    {
                        base.Response.Write("<script language=javascript>alert('只允许在【" + list["NodeName"].ToString() + "】使用印章');window.close()</script>");
                        list.Close();
                        return;
                    }
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('您没有权限操作此印章');window.close()</script>");
                    return;
                }
                list.Close();
                string sQL = "select Newname,Name+'('+YxType+')' as Name  from qp_oa_YinZhang where Username='" + this.Session["Username"] + "' and  State='正常' ";
                if (!base.IsPostBack)
                {
                    this.list.Bind_DropDownList(this.DropDownList1, sQL, "Newname", "Name");
                    Random random = new Random();
                    string str3 = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str3 + "";
                }
                this.BindAttribute();
            }
        }
    }
}


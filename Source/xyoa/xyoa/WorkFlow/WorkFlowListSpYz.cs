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

    public class WorkFlowListSpYz : Page
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
                base.Response.Write("<script language=javascript>window.opener.OpenSealToWeb('" + this.DropDownList1.SelectedValue + "');window.close();</script>");
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
                string sQL = "select Newname,Name+'('+YxType+')' as Name  from qp_oa_YinZhang where Username='" + this.Session["Username"] + "' and  State='正常' ";
                if (!base.IsPostBack)
                {
                    this.list.Bind_DropDownList(this.DropDownList1, sQL, "Newname", "Name");
                    Random random = new Random();
                    string str2 = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str2 + "";
                }
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            }
        }
    }
}


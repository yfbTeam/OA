namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowSearch_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected TextBox Endtime;
        protected DropDownList Fangwei;
        protected DropDownList FlowId;
        protected HtmlForm form1;
        protected TextBox FqRealname;
        protected TextBox FqUsername;
        protected TextBox Fujian;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected DropDownList State;

        public void BindAttribute()
        {
            this.FqRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.CheckBox1.Checked)
            {
                string sql = "select  * from qp_oa_DIYForm where id='" + base.Request.QueryString["id"].ToString() + "' ";
                SqlDataReader list = this.List.GetList(sql);
                string str2 = null;
                str2 = str2 + "(1!=1)";
                if (list.Read())
                {
                    string str3 = "select  * from qp_oa_FormFile where KeyFile='" + list["Number"].ToString() + "' and (type='[常规型]' or type='[数字型]')   order by id asc";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    while (reader2.Read())
                    {
                        if (base.Request.Form["" + reader2["Number"] + ""] != "")
                        {
                            object obj2 = str2;
                            str2 = string.Concat(new object[] { obj2, " or ([A].[Number] = [B].AddNumber and [B].Content like '%", base.Request.Form["" + reader2["Number"] + ""], "%' and [B].number='", reader2["Number"], "')" });
                        }
                    }
                    reader2.Close();
                }
                list.Close();
                this.Session["searchurl"] = str2;
            }
            else
            {
                this.Session["searchurl"] = "";
            }
            base.Response.Write("<script language=javascript>window.parent.location.href='WorkFlowSearch_SearchList.aspx?FlowId=" + this.FlowId.SelectedValue + "&State=" + this.State.SelectedValue + "&Fangwei=" + this.Fangwei.SelectedValue + "&FqUsername=" + this.FqUsername.Text + "&Name=" + this.Name.Text + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "&Fujian=" + this.Fujian.Text + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (this.CheckBox1.Checked)
            {
                string sql = "select  * from qp_oa_DIYForm where id='" + base.Request.QueryString["id"].ToString() + "' ";
                SqlDataReader list = this.List.GetList(sql);
                string str2 = null;
                str2 = str2 + "(1!=1)";
                if (list.Read())
                {
                    string str3 = "select  * from qp_oa_FormFile where KeyFile='" + list["Number"].ToString() + "' and (type='[常规型]' or type='[数字型]')   order by id asc";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    while (reader2.Read())
                    {
                        if (base.Request.Form["" + reader2["Number"] + ""] != "")
                        {
                            object obj2 = str2;
                            str2 = string.Concat(new object[] { obj2, " or ([A].[Number] = [B].AddNumber and [B].Content like '%", base.Request.Form["" + reader2["Number"] + ""], "%' and [B].number='", reader2["Number"], "')" });
                        }
                    }
                    reader2.Close();
                }
                list.Close();
                this.Session["searchurl"] = str2;
            }
            else
            {
                this.Session["searchurl"] = "";
            }
            base.Response.Write("<script language=javascript>window.parent.location.href='WorkFlowSearch_SearchListTj.aspx?id=" + base.Request.QueryString["id"] + "&FlowId=" + this.FlowId.SelectedValue + "&State=" + this.State.SelectedValue + "&Fangwei=" + this.Fangwei.SelectedValue + "&FqUsername=" + this.FqUsername.Text + "&Name=" + this.Name.Text + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "&Fujian=" + this.Fujian.Text + "'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string str;
                if (base.Request.QueryString["id"].ToString() == "0")
                {
                    str = "select *  from qp_oa_WorkFlowName where (CHARINDEX('," + this.Session["username"] + ",',','+CxUsername+',') > 0  or CxUsername='0') order by Paixun asc";
                    this.list.Bind_DropDownListLiuCheng(this.FlowId, str, "id", "FlowName");
                    this.Panel1.Visible = false;
                    this.Button2.Visible = false;
                }
                else
                {
                    str = string.Concat(new object[] { "select *  from qp_oa_WorkFlowName where (CHARINDEX(',", this.Session["username"], ",',','+CxUsername+',') > 0  or CxUsername='0') and FormId='", base.Request.QueryString["id"].ToString(), "' order by Paixun asc" });
                    this.list.Bind_DropDownList_nothing(this.FlowId, str, "id", "FlowName");
                    this.Panel1.Visible = true;
                    this.Button2.Visible = true;
                }
                this.BindAttribute();
                string sql = "select  * from qp_oa_DIYForm where id='" + base.Request.QueryString["id"].ToString() + "' ";
                SqlDataReader list = this.List.GetList(sql);
                this.Label1.Text = null;
                if (list.Read())
                {
                    this.Label1.Text = this.Label1.Text + "<table align=\"center\" border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                    string str3 = "select  * from qp_oa_FormFile where KeyFile='" + list["Number"].ToString() + "' and (type='[常规型]' or type='[数字型]')   order by id asc";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    while (reader2.Read())
                    {
                        object text = this.Label1.Text;
                        this.Label1.Text = string.Concat(new object[] { text, " <tr><td align=right class=newtd1 width=17%>", reader2["Name"], "：</td><td  class=newtd2 height=17 width=83% colspan=3><input id=\"", reader2["Number"], "\"  name=\"", reader2["Number"], "\" type=\"text\" size=\"50\" /></td></tr>" });
                    }
                    reader2.Close();
                    this.Label1.Text = this.Label1.Text + "</table>";
                }
                list.Close();
            }
        }
    }
}


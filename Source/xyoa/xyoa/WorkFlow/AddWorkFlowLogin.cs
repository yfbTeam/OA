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

    public class AddWorkFlowLogin : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected RadioButtonList liucheng;
        private publics pulicss = new publics();
        private divform showform = new divform();

        public void BindList()
        {
            switch (this.liucheng.Items.Count)
            {
                case 0:
                    base.Response.Write("<script language=javascript>alert('未找到流程！');window.close();</script>");
                    break;

                case 1:
                    this.GoBindList();
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.GoBindList();
        }

        public void GoBindList()
        {
            string sql = "select ShuXing,FlowNumber from qp_oa_WorkFlowName where FlowNumber='" + this.liucheng.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["ShuXing"].ToString() == "自由流程")
                {
                    base.Response.Redirect("AddWorkFlow_add_zy.aspx?tmp=" + base.Request.QueryString["tmp"] + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + base.Request.QueryString["Id"] + "");
                }
                else
                {
                    base.Response.Redirect("AddWorkFlow_add.aspx?tmp=" + base.Request.QueryString["tmp"] + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + base.Request.QueryString["Id"] + "");
                }
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
                string sql = "select FormName from qp_oa_DIYForm where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["FormName"] = list["FormName"].ToString();
                }
                list.Close();
                string sQL = string.Concat(new object[] { "select FlowNumber,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+FlowName+'［<a href=\"javascript:void(0)\" onclick=lcopen(\"'+FlowNumber+'\")>查看流程结构</a>］' as FlowName from qp_oa_WorkFlowName  where FlowType='正常' and FormId='", base.Request.QueryString["id"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                this.list.Bind_DropDownList_nothing1(this.liucheng, sQL, "FlowNumber", "FlowName");
                if (this.liucheng.Items.Count > 0)
                {
                    this.liucheng.Items[0].Selected = true;
                }
                this.BindList();
            }
        }
    }
}


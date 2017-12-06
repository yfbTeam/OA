namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class FlowMg_list_update : Page
    {
        protected TextBox BianhaoJs;
        protected TextBox BianhaoWs;
        protected Button Button5;
        protected Button Button8;
        protected TextBox CxRealname;
        protected TextBox CxUsername;
        protected TextBox FlowName;
        protected TextBox FlowNumber;
        protected DropDownList FlowType;
        protected HtmlForm form1;
        protected DropDownList FormId;
        protected DropDownList GlZiduan;
        protected DropDownList Guanlian;
        protected HtmlHead Head1;
        protected TextBox JkRealname;
        protected TextBox JkUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected RadioButtonList Muban;
        protected DropDownList OverSetCon;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected DropDownList ShuXing;
        protected DropDownList States;
        protected TextBox Wenhao;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.CxRealname.Attributes.Add("readonly", "readonly");
            this.JkRealname.Attributes.Add("readonly", "readonly");
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button5.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindDroList()
        {
            string sQL = "select id,FormName  from qp_oa_DIYForm order by id desc";
            this.list.Bind_DropDownList_nothing(this.FormId, sQL, "id", "FormName");
            this.pulicss.BindListGd("qp_oa_WorkFlowNodeGD", this.OverSetCon, "", "order by Paixun asc");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_WorkFlowName    Set Muban='", this.Muban.SelectedValue, "',Guanlian='", this.Guanlian.SelectedValue, "',GlZiduan='", this.GlZiduan.SelectedValue, "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, 
                "',CxUsername='", this.pulicss.GetFormatStr(this.CxUsername.Text), "',CxRealname='", this.pulicss.GetFormatStr(this.CxRealname.Text), "',FormId='", this.FormId.SelectedValue, "',FlowNumber='", this.FlowNumber.Text, "',FlowType='", this.FlowType.SelectedValue, "',FlowName='", this.pulicss.GetFormatStr(this.FlowName.Text), "',JkUsername='", this.pulicss.GetFormatStr(this.JkUsername.Text), "',JkRealname='", this.pulicss.GetFormatStr(this.JkRealname.Text), 
                "',OverSetConId='", this.pulicss.GetFormatStr(this.OverSetCon.SelectedValue), "',ShuXing='", this.ShuXing.SelectedValue, "',Paixun='", this.Paixun.Text, "',Wenhao='", this.Wenhao.Text, "',BianhaoJs='", this.BianhaoJs.Text, "',BianhaoWs='", this.BianhaoWs.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "' "
             });
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set JkUsername='", this.pulicss.GetFormatStr(this.JkUsername.Text), "',JkRealname='", this.pulicss.GetFormatStr(this.JkRealname.Text), "'  where FlowId='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(str2);
            string str3 = string.Concat(new object[] { "Update qp_oa_WorkFlowNode  Set FlowName='", this.pulicss.GetFormatStr(this.FlowName.Text), "' where FlowId='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(str3);
            this.pulicss.InsertLog("修改流程名称[" + this.FlowName.Text + "]", "流程设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='FlowMg_list.aspx?FormId=" + this.FormId.SelectedValue + "';window.close();</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("FlowMg_list.aspx?FormId=" + this.ViewState["FormId"] + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindDroList();
                this.BindAttribute();
                string sql = "select * from qp_oa_WorkFlowName where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.FormId.SelectedValue = list["FormId"].ToString();
                    this.FlowNumber.Text = list["FlowNumber"].ToString();
                    this.FlowType.SelectedValue = list["FlowType"].ToString();
                    this.FlowName.Text = list["FlowName"].ToString();
                    this.JkUsername.Text = list["JkUsername"].ToString();
                    this.JkRealname.Text = list["JkRealname"].ToString();
                    this.OverSetCon.SelectedValue = list["OverSetConId"].ToString();
                    this.ShuXing.SelectedValue = list["ShuXing"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                    this.Wenhao.Text = list["Wenhao"].ToString();
                    this.BianhaoJs.Text = list["BianhaoJs"].ToString();
                    this.BianhaoWs.Text = list["BianhaoWs"].ToString();
                    this.CxUsername.Text = list["CxUsername"].ToString();
                    this.CxRealname.Text = list["CxRealname"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.Muban.SelectedValue = list["Muban"].ToString();
                    string str2 = "select Number from qp_oa_DIYForm where id='" + this.FormId.SelectedValue + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        string sQL = "select Number,Name from qp_oa_FormFile where KeyFile='" + reader2["Number"] + "' order by id asc";
                        this.list.Bind_DropDownList_kong(this.GlZiduan, sQL, "Number", "Name");
                    }
                    reader2.Close();
                    this.Guanlian.SelectedValue = list["Guanlian"].ToString();
                    this.GlZiduan.SelectedValue = list["GlZiduan"].ToString();
                }
                list.Close();
            }
        }
    }
}


namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class FlowMg_list_add : Page
    {
        protected TextBox BianhaoJs;
        protected TextBox BianhaoWs;
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
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
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.JkRealname.Attributes.Add("readonly", "readonly");
            this.CxRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button4.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindDroList()
        {
            string sQL = "select id,FormName  from qp_oa_DIYForm order by id desc";
            this.list.Bind_DropDownList_nothing(this.FormId, sQL, "id", "FormName");
            this.pulicss.BindListGd("qp_oa_WorkFlowNodeGD", this.OverSetCon, "", "order by Paixun asc");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_WorkFlowName (Muban,Guanlian,GlZiduan,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,CxUsername,CxRealname,FormId,FlowNumber,FlowType,FlowName,JkUsername,JkRealname,OverSetConId,ShuXing,Paixun,Wenhao,BianhaoJs,BianhaoWs) values ('" + this.Muban.SelectedValue + "','" + this.Guanlian.SelectedValue + "','" + this.GlZiduan.SelectedValue + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + this.CxUsername.Text + "','" + this.CxRealname.Text + "','" + this.FormId.SelectedValue + "','" + this.FlowNumber.Text + "','" + this.FlowType.SelectedValue + "','" + this.pulicss.GetFormatStr(this.FlowName.Text) + "','" + this.pulicss.GetFormatStr(this.JkUsername.Text) + "','" + this.pulicss.GetFormatStr(this.JkRealname.Text) + "','" + this.OverSetCon.SelectedValue + "','" + this.ShuXing.SelectedValue + "','" + this.Paixun.Text + "','" + this.Wenhao.Text + "','" + this.BianhaoJs.Text + "','" + this.BianhaoWs.Text + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增流程名称[" + this.FlowName.Text + "]", "流程设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='FlowMg_list.aspx?FormId=" + this.FormId.SelectedValue + "';</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_WorkFlowName (Muban,Guanlian,GlZiduan,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,CxUsername,CxRealname,FormId,FlowNumber,FlowType,FlowName,JkUsername,JkRealname,OverSetConId,ShuXing,Paixun,Wenhao,BianhaoJs,BianhaoWs) values ('" + this.Muban.SelectedValue + "','" + this.Guanlian.SelectedValue + "','" + this.GlZiduan.SelectedValue + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + this.CxUsername.Text + "','" + this.CxRealname.Text + "','" + this.FormId.SelectedValue + "','" + this.FlowNumber.Text + "','" + this.FlowType.SelectedValue + "','" + this.pulicss.GetFormatStr(this.FlowName.Text) + "','" + this.pulicss.GetFormatStr(this.JkUsername.Text) + "','" + this.pulicss.GetFormatStr(this.JkRealname.Text) + "','" + this.OverSetCon.SelectedValue + "','" + this.ShuXing.SelectedValue + "','" + this.Paixun.Text + "','" + this.Wenhao.Text + "','" + this.BianhaoJs.Text + "','" + this.BianhaoWs.Text + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增流程名称[" + this.FlowName.Text + "]", "流程设置");
            base.Response.Redirect("WorkFlowName_show_copy.aspx?FlowNumber=" + this.FlowNumber.Text + "&FormId=" + this.FormId.SelectedValue + "");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_WorkFlowName (Muban,Guanlian,GlZiduan,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,CxUsername,CxRealname,FormId,FlowNumber,FlowType,FlowName,JkUsername,JkRealname,OverSetConId,ShuXing,Paixun,Wenhao,BianhaoJs,BianhaoWs) values ('" + this.Muban.SelectedValue + "','" + this.Guanlian.SelectedValue + "','" + this.GlZiduan.SelectedValue + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + this.CxUsername.Text + "','" + this.CxRealname.Text + "','" + this.FormId.SelectedValue + "','" + this.FlowNumber.Text + "','" + this.FlowType.SelectedValue + "','" + this.pulicss.GetFormatStr(this.FlowName.Text) + "','" + this.pulicss.GetFormatStr(this.JkUsername.Text) + "','" + this.pulicss.GetFormatStr(this.JkRealname.Text) + "','" + this.OverSetCon.SelectedValue + "','" + this.ShuXing.SelectedValue + "','" + this.Paixun.Text + "','" + this.Wenhao.Text + "','" + this.BianhaoJs.Text + "','" + this.BianhaoWs.Text + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增流程名称[" + this.FlowName.Text + "]", "流程设置");
            base.Response.Redirect("WorkFlowName_show_add_node.aspx?FlowNumber=" + this.FlowNumber.Text + "");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("FlowMg_list.aspx?FormId=" + base.Request.QueryString["FormId"] + "");
        }

        protected void FormId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select Number from qp_oa_DIYForm where id='" + this.FormId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string sQL = "select Number,Name from qp_oa_FormFile where KeyFile='" + list["Number"] + "' order by id asc";
                this.list.Bind_DropDownList_kong(this.GlZiduan, sQL, "Number", "Name");
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
                this.BindDroList();
                try
                {
                    this.FormId.SelectedValue = base.Request.QueryString["FormId"].ToString();
                }
                catch
                {
                }
                this.BindAttribute();
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.FlowNumber.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                string sql = "select Number from qp_oa_DIYForm where id='" + this.FormId.SelectedValue + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string sQL = "select Number,Name from qp_oa_FormFile where KeyFile='" + list["Number"] + "' order by id asc";
                    this.list.Bind_DropDownList_kong(this.GlZiduan, sQL, "Number", "Name");
                }
                list.Close();
            }
        }
    }
}


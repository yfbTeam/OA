namespace xyoa.WorkFlowSysMag
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlow_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_pro_WorkFlow (Name,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,FormId) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + base.Request.QueryString["FormId"] + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增工作流", this.ViewState["LeixingName"].ToString());
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkFlow.aspx?FormId=" + base.Request.QueryString["FormId"] + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlow.aspx?FormId=" + base.Request.QueryString["FormId"] + "");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_pro_WorkFlow (Name,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,FormId) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + base.Request.QueryString["FormId"] + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增工作流", this.ViewState["LeixingName"].ToString());
            string str2 = "select top 1 id from qp_pro_WorkFlow  where FormId='" + base.Request.QueryString["FormId"] + "' order by id desc";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                this.ViewState["FormId"] = list["id"].ToString();
            }
            list.Close();
            base.Response.Redirect("GongZuoLiu.aspx?FormId=" + this.ViewState["FormId"] + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ViewState["LeixingName"] = this.pulicss.GetGongZuoLiu(base.Request.QueryString["FormId"].ToString());
                this.BindAttribute();
            }
        }
    }
}


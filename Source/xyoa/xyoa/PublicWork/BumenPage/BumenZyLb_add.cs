namespace xyoa.PublicWork.BumenPage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenZyLb_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Leixing;
        private Db List = new Db();
        protected TextBox paixun;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected DropDownList States1;
        protected TextBox ZdBumen;
        protected TextBox ZdBumen1;
        protected TextBox ZdBumenId;
        protected TextBox ZdBumenId1;
        protected TextBox ZdRealname;
        protected TextBox ZdRealname1;
        protected TextBox ZdUsername;
        protected TextBox ZdUsername1;

        public void BindAttribute()
        {
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.ZdBumen1.Attributes.Add("readonly", "readonly");
            this.ZdRealname1.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_BumenZyLb (Leixing,paixun,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,States1,ZdBumenId1,ZdBumen1,ZdUsername1,ZdRealname1) values ('" + this.pulicss.GetFormatStr(this.Leixing.Text) + "','" + this.pulicss.GetFormatStr(this.paixun.Text) + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + this.States1.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId1.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen1.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername1.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname1.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增部门主页类别[" + this.pulicss.GetFormatStr(this.Leixing.Text) + "]", "部门主页类别");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='BumenZyLb.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("BumenZyLb.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
            }
        }
    }
}


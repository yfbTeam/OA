namespace xyoa.PublicWork.BumenPage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenZyLb_update : Page
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
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_BumenZyLb  Set Leixing='", this.pulicss.GetFormatStr(this.Leixing.Text), "',paixun='", this.pulicss.GetFormatStr(this.paixun.Text), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.pulicss.GetFormatStr(this.ZdBumenId.Text), "',ZdBumen='", this.pulicss.GetFormatStr(this.ZdBumen.Text), "',ZdUsername='", this.pulicss.GetFormatStr(this.ZdUsername.Text), "',ZdRealname='", this.pulicss.GetFormatStr(this.ZdRealname.Text), "',States1='", this.States1.SelectedValue, 
                "',ZdBumenId1='", this.pulicss.GetFormatStr(this.ZdBumenId1.Text), "',ZdBumen1='", this.pulicss.GetFormatStr(this.ZdBumen1.Text), "',ZdUsername1='", this.pulicss.GetFormatStr(this.ZdUsername1.Text), "',ZdRealname1='", this.pulicss.GetFormatStr(this.ZdRealname1.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改部门主页类别[" + this.pulicss.GetFormatStr(this.Leixing.Text) + "]", "部门主页类别");
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
                string sql = "select * from qp_oa_BumenZyLb where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Leixing.Text = list["Leixing"].ToString();
                    this.paixun.Text = list["paixun"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.States1.SelectedValue = list["States1"].ToString();
                    this.ZdBumenId1.Text = list["ZdBumenId1"].ToString();
                    this.ZdBumen1.Text = list["ZdBumen1"].ToString();
                    this.ZdUsername1.Text = list["ZdUsername1"].ToString();
                    this.ZdRealname1.Text = list["ZdRealname1"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


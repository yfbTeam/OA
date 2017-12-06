namespace xyoa.PublicWork.Hetong
{
    using qiupeng.crm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class eTong_zt : Page
    {
        protected Button Button1;
        protected TextBox CgId;
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected RadioButtonList Zhuangtai;
        protected Label Zhuti;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_HeTong   Set Zhuangtai='", this.Zhuangtai.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功，重新打开页面或刷新页面可显示！');window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                string sql = "select * from qp_oa_HeTong  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                }
                list.Close();
            }
        }
    }
}


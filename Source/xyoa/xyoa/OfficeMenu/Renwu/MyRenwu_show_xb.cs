namespace xyoa.OfficeMenu.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRenwu_show_xb : Page
    {
        protected TextBox Baifenbi;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Neirong;
        private publics pulicss = new publics();
        protected DropDownList Zhuangtai;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_RenwuXb  Set Zhuangtai='", this.Zhuangtai.SelectedValue, "',Neirong='", this.Neirong.Text, "',Baifenbi='", this.Baifenbi.Text, "' where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_RenwuXb where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                    this.Neirong.Text = list["Neirong"].ToString();
                    this.Baifenbi.Text = list["Baifenbi"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


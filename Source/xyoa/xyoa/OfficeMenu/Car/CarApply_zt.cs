namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarApply_zt : Page
    {
        protected Button Button2;
        protected Label CarId;
        protected Label Endtime;
        protected HtmlForm form1;
        protected TextBox GhBeizhu;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Miles;
        private publics pulicss = new publics();
        protected Label Starttime;
        protected DropDownList State;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_CarApply  Set State='", this.State.SelectedValue, "',Miles='", this.Miles.Text, "',GhBeizhu='", this.GhBeizhu.Text, "',GhShijian='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('设置成功！');window.dialogArguments.window.location.href='CarApply.aspx'; window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_CarApply where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.State.SelectedValue = list["State"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.CarId.Text = this.pulicss.TypeCodeAll("CarName", "qp_oa_CarInfo", list["CarId"].ToString());
                    this.Miles.Text = list["Miles"].ToString();
                    this.GhBeizhu.Text = list["GhBeizhu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


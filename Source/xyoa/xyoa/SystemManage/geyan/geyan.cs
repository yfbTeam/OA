namespace xyoa.SystemManage.geyan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class geyan : Page
    {
        protected Button Button1;
        protected TextBox Content;
        public static string fjkey;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_FaceMade  Set  Geyan='" + this.pulicss.GetFormatStr(this.Content.Text) + "'";
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='geyan.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_FaceMade";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Content.Text = list["Geyan"].ToString();
                }
                list.Close();
            }
        }
    }
}


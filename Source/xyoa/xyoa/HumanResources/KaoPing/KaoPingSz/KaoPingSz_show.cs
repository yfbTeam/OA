namespace xyoa.HumanResources.KaoPing.KaoPingSz
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoPingSz_show : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Jishu;
        protected Label Jishu1;
        protected Label Leixing;
        private Db List = new Db();
        protected Label Name1;
        protected Label Name2;
        protected Label Name3;
        protected Label Name4;
        protected Label Name5;
        protected Label Neirong;
        private publics pulicss = new publics();
        protected Label Quanzhong1;
        protected Label Quanzhong2;
        protected Label Quanzhong3;
        protected Label Quanzhong4;
        protected Label Quanzhong5;
        protected Label QuanzhongMy;
        protected TextBox User1;
        protected TextBox User2;
        protected TextBox User3;
        protected TextBox User4;
        protected TextBox User5;
        protected Label Zongfen;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                string sql = "select * from qp_hr_KaoPingSz where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Leixing.Text = list["Leixing"].ToString();
                    this.Zongfen.Text = list["Zongfen"].ToString();
                    this.Jishu.Text = list["Jishu"].ToString();
                    this.Jishu1.Text = list["Jishu"].ToString();
                    this.Neirong.Text = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                    this.QuanzhongMy.Text = list["QuanzhongMy"].ToString();
                    this.User1.Text = list["User1"].ToString();
                    this.Name1.Text = list["Name1"].ToString();
                    this.Quanzhong1.Text = list["Quanzhong1"].ToString();
                    this.User2.Text = list["User2"].ToString();
                    this.Name2.Text = list["Name2"].ToString();
                    this.Quanzhong2.Text = list["Quanzhong2"].ToString();
                    this.User3.Text = list["User3"].ToString();
                    this.Name3.Text = list["Name3"].ToString();
                    this.Quanzhong3.Text = list["Quanzhong3"].ToString();
                    this.User4.Text = list["User4"].ToString();
                    this.Name4.Text = list["Name4"].ToString();
                    this.Quanzhong4.Text = list["Quanzhong4"].ToString();
                    this.User5.Text = list["User5"].ToString();
                    this.Name5.Text = list["Name5"].ToString();
                    this.Quanzhong5.Text = list["Quanzhong5"].ToString();
                }
                list.Close();
            }
        }
    }
}


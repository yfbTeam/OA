namespace xyoa.MyWork.YinZhang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyYinZhang_show : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Name;
        protected Image Newname;
        protected Label Nowtimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label State;
        protected Label YxType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_YinZhang where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Newname.ImageUrl = "/seal/" + list["Newname"].ToString() + "";
                    this.Name.Text = list["Name"].ToString();
                    this.YxType.Text = list["YxType"].ToString();
                    this.State.Text = list["State"].ToString();
                    this.Nowtimes.Text = list["Nowtimes"].ToString();
                }
                list.Close();
            }
        }
    }
}


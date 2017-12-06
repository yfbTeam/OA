namespace xyoa.MyWork.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class NetMetting_show : Page
    {
        protected Label CjRealname;
        protected Label Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Introduction;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label MettingHeader;
        protected TextBox MettingHeaderUser;
        protected Label MettingIp;
        protected Label Name;
        protected Label NbPeopleName;
        protected TextBox NbPeopleUser;
        private publics pulicss = new publics();
        protected Label Remark;
        protected Label Starttime;
        protected Label State;
        protected Label Titles;
        protected Label WbPeople;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_NetMetting where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Titles.Text = list["Title"].ToString();
                    this.CjRealname.Text = list["CjRealname"].ToString();
                    this.Introduction.Text = this.pulicss.TbToLb(list["Introduction"].ToString());
                    this.WbPeople.Text = list["WbPeople"].ToString();
                    this.NbPeopleUser.Text = list["NbPeopleUser"].ToString();
                    this.NbPeopleName.Text = list["NbPeopleName"].ToString();
                    this.MettingHeaderUser.Text = list["MettingHeaderUser"].ToString();
                    this.MettingHeader.Text = list["MettingHeader"].ToString();
                    this.MettingIp.Text = list["MettingIp"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.State.Text = this.pulicss.SystemCode("8", list["State"].ToString());
                    this.Remark.Text = list["Remark"].ToString();
                }
                list.Close();
                this.pulicss.InsertLog("查看网络会议[" + this.Name.Text + "]", "网络会议");
            }
        }
    }
}


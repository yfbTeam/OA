namespace qpoa.HumanResources
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkTime_show : Page
    {
        protected Label DjTime_1;
        protected Label DjTime_2;
        protected Label DjTime_3;
        protected Label DjTime_4;
        protected Label DjTime_5;
        protected Label DjTime_6;
        protected Label DjType_1;
        protected Label DjType_2;
        protected Label DjType_3;
        protected Label DjType_4;
        protected Label DjType_5;
        protected Label DjType_6;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected Label PbType;
        private publics pulicss = new publics();
        protected Label QyType;
        protected Label Riqi;
        protected Label SyRealname;
        protected Label Xingqi;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_WorkTime   where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.SyRealname.Text = list["SyRealname"].ToString();
                    this.PbType.Text = list["PbType"].ToString();
                    this.QyType.Text = list["QyType"].ToString();
                    this.DjType_1.Text = list["DjType_1"].ToString();
                    this.DjType_2.Text = list["DjType_2"].ToString();
                    this.DjType_3.Text = list["DjType_3"].ToString();
                    this.DjType_4.Text = list["DjType_4"].ToString();
                    this.DjType_5.Text = list["DjType_5"].ToString();
                    this.DjType_6.Text = list["DjType_6"].ToString();
                    this.DjTime_1.Text = list["DjTime_1"].ToString();
                    this.DjTime_2.Text = list["DjTime_2"].ToString();
                    this.DjTime_3.Text = list["DjTime_3"].ToString();
                    this.DjTime_4.Text = list["DjTime_4"].ToString();
                    this.DjTime_5.Text = list["DjTime_5"].ToString();
                    this.DjTime_6.Text = list["DjTime_6"].ToString();
                    this.Xingqi.Text = list["Xingqi"].ToString().Replace(",0", "");
                    this.Riqi.Text = list["Riqi"].ToString();
                }
                list.Close();
            }
        }
    }
}


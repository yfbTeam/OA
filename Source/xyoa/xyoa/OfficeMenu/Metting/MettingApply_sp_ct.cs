namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingApply_sp_ct : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["MettingId"] != "0")
            {
                str = str + " and MettingId = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["MettingId"])) + "'";
            }
            if (base.Request.QueryString["Starttime"] != "")
            {
                str = str + " and convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Starttime"])) + "' as datetime),120) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort)
        {
            string sql = "select  * from qp_oa_MettingApply where id='" + base.Request.QueryString["id"] + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "select  * from qp_oa_MettingApply where id!='", base.Request.QueryString["id"], "' and (State!='4' and State!='5') and  (MettingId='", list["MettingId"], "')  and   ((Starttime >= '", list["Starttime"], "' and Endtime < '", list["Endtime"], "') or (Endtime > '", list["Starttime"], "' and Starttime <= '", list["Endtime"], "'))" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                this.GridView1.DataBind();
            }
            list.Close();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.DataBindToGridview("order by id desc");
            }
        }
    }
}


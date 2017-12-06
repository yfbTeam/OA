namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarApply_sp_ct : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        public void DataBindToGridview(string str)
        {
            string sql = "select  CarId,Starttime,Endtime from qp_oa_CarApply where id='" + base.Request.QueryString["id"] + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["CarName"] = this.pulicss.TypeCodeAll("CarName", "qp_oa_CarInfo", list["CarId"].ToString());
                string str3 = string.Concat(new object[] { "select  State,LcZhuangtai,CarId,Drivers,Starttime,Endtime,Username,Realname from qp_oa_CarApply where id!='", base.Request.QueryString["id"], "' and (State!='5' and State!='3' ) and  (CarId='", list["CarId"], "')  and   ((Starttime >= '", list["Starttime"], "' and Endtime < '", list["Endtime"], "') or (Endtime > '", list["Starttime"], "' and Starttime <= '", list["Endtime"], "'))" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                this.GridView1.DataBind();
            }
            list.Close();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataBind();
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
                this.DataBindToGridview("");
            }
        }
    }
}


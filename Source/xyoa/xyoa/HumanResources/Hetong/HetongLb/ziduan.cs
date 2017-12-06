namespace xyoa.HumanResources.Hetong.HetongLb
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ziduan : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected LinkButton LinkButton1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void DataBindToGridview()
        {
            string sql = "select * from [qp_hr_HetongZd]  where LeibieID='" + base.Request.QueryString["LeibieID"] + "'";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "delete from qp_hr_HetongZd   where ID='" + num + "'";
                this.List.ExeSql(sql);
            }
            this.DataBindToGridview();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("ShanChu");
                button.Attributes.Add("onclick", "javascript:return confirm('确定删除吗？')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("XiuGai");
                button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('ziduan_update.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "','window','dialogWidth:680px;DialogHeight=280px;status:no;help=no;scroll=no');window.location='#'");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.LinkButton1.Attributes["onclick"] = "javascript:return AddZiduan();";
                }
                this.DataBindToGridview();
            }
        }
    }
}


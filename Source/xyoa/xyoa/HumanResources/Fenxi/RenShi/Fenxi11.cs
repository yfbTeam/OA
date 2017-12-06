namespace xyoa.HumanResources.Fenxi.RenShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Fenxi11 : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void Bindquanxian()
        {
            this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
        }

        public void DataBindToGridview()
        {
            string sql = "select * from [qp_oa_Bumen] order by QxString asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label1");
                Label label3 = (Label) e.Row.FindControl("Label2");
                string sql = "select count(A.id) from  [qp_hr_Yuangong] as [A] where A.Bumen='" + label.Text + "' and Zaizhi='1'";
                string str2 = "" + this.List.GetCount(sql) + "";
                string str3 = "select count(A.id) from  [qp_hr_Yuangong] as [A] where A.Bumen='" + label.Text + "' and Zaizhi='2'";
                string str4 = "" + this.List.GetCount(str3) + "";
                label2.Text = "<a href='javascript:void(0)' onclick='var num=Math.random();loc_x=(screen.availWidth-877)/2;loc_y=(screen.availHeight-600)/2;window.open (\"YuangongList.aspx?tmp=\"+num+\"&Key=11&Bumen=" + label.Text + "\", \"_blank\", \"height=600, width=877,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\"+loc_y+\",left=\"+loc_x+\"\")'>" + str2 + "</a>";
                label3.Text = "<a href='javascript:void(0)' onclick='var num=Math.random();loc_x=(screen.availWidth-877)/2;loc_y=(screen.availHeight-600)/2;window.open (\"YuangongList.aspx?tmp=\"+num+\"&Key=21&Bumen=" + label.Text + "\", \"_blank\", \"height=600, width=877,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\"+loc_y+\",left=\"+loc_x+\"\")'>" + str4 + "</a>";
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
                this.DataBindToGridview();
                this.Bindquanxian();
            }
        }
    }
}


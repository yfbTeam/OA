namespace xyoa.OfficeMenu.WorkPlan
{
    using qiupeng.crm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPlanJk_lb_show : Page
    {
        protected Label Biaoti;
        protected Button Button2;
        protected Button Button4;
        protected CheckBox CheckBox1;
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        protected Label DqState;
        protected Label EndTime;
        protected HtmlForm form1;
        protected Label fujian;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Sharing;
        protected Label SharingNameKx;
        protected Label SharingNameZd;
        protected Label StartTime;
        protected TextBox taolun;
        protected Label YdRealname;
        protected Label Youxian;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('9','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyPlanJk_lb.aspx");
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='9'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='9' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.DataBindToGridview();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "Delete from qp_oa_Taolun where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                Label label = (Label) e.Row.FindControl("FTUsername");
                if ((label.Text == this.Session["username"].ToString()) || (this.Session["username"].ToString() == "admin"))
                {
                    button.Visible = true;
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除此条讨论信息吗？')");
                }
                else
                {
                    button.Visible = false;
                }
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
                string sql = string.Concat(new object[] { "select * from qp_oa_MyPlan  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_MyPlanSz where ZgUsername='", this.Session["username"], "')+',') > 0 " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = "," + this.Session["Username"].ToString() + ",";
                    if (("," + list["YdUsername"].ToString() + ",").IndexOf(str2) < 0)
                    {
                        string str4 = string.Concat(new object[] { "Update qp_oa_MyPlan   Set YdUsername=YdUsername+'", this.Session["username"], ",',YdRealname=YdRealname+'", this.Session["realname"], "(", DateTime.Now.ToString(), "),'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                        this.List.ExeSql(str4);
                    }
                    this.Number.Text = list["Number"].ToString();
                    this.Biaoti.Text = list["Biaoti"].ToString();
                    this.Leixing.Text = this.divcrm.TypeCode("Leixing", "qp_oa_MyPlanLx", list["Leixing"].ToString());
                    this.Neirong.Text = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                    this.StartTime.Text = list["StartTime"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.EndTime.Text = list["EndTime"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Youxian.Text = list["Youxian"].ToString().Replace("1", "高").Replace("2", "中").Replace("3", "低");
                    this.DqState.Text = list["DqState"].ToString().Replace("1", "未处理").Replace("2", "进行中").Replace("3", "已办结").Replace("4", "已暂停");
                    this.Sharing.Text = list["Sharing"].ToString().Replace("1", "未共享").Replace("2", "已共享");
                    this.SharingNameZd.Text = list["SharingNameZd"].ToString();
                    this.SharingNameKx.Text = list["SharingNameKx"].ToString();
                    this.YdRealname.Text = list["YdRealname"].ToString();
                    if (list["Sharing"].ToString() == "1")
                    {
                        this.ViewState["Sharing"] = "display: none";
                    }
                }
                list.Close();
                this.DataBindToGridview();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
            }
        }
    }
}


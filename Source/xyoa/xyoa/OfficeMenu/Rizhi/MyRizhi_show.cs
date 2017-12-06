namespace xyoa.OfficeMenu.Rizhi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRizhi_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected Label Content;
        protected Button DelData;
        protected HtmlForm form1;
        protected Label fujian;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label LeiBie;
        private Db List = new Db();
        protected Label NowTimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox taolun;
        protected Label titles;
        protected Button UpdateData;
        protected Label YdRealname;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.UpdateData, "kkkk6ac", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.DelData, "kkkk6ad", this.Session["perstr"].ToString());
            this.DelData.Attributes["onclick"] = "javascript:return zx();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('7','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["key"].ToString() == "1")
            {
                base.Response.Redirect("MyRizhi.aspx");
            }
            else
            {
                base.Response.Redirect("MyRizhiList.aspx");
            }
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='7'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='7' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView1.DataBind();
        }

        protected void DelData_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "  Delete from qp_oa_MyRizhi  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除日志", "我的日志");
            base.Response.Write("<script language=javascript>alert('删除成功！');window.location.href='MyRizhi.aspx'</script>");
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
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除此条批注吗？')");
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
                string sql = string.Concat(new object[] { "select * from qp_oa_MyRizhi  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.titles.Text = list["titles"].ToString();
                    this.NowTimes.Text = DateTime.Parse(list["NowTimes"].ToString()).ToShortDateString();
                    this.Content.Text = list["Content"].ToString();
                    this.LeiBie.Text = this.pulicss.TypeCode("qp_oa_RizhiLx", list["LeiBie"].ToString());
                    this.YdRealname.Text = list["YdRealname"].ToString();
                    list.Close();
                    this.BindAttribute();
                    this.pulicss.GetFile(this.Number.Text, this.fujian);
                    this.DataBindToGridview();
                }
                else
                {
                    list.Close();
                    base.Response.Write("<script language=javascript>alert('无相关信息！');window.location.href='MyRizhi.aspx'</script>");
                }
            }
        }

        protected void UpdateData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyRizhi_update.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
        }
    }
}


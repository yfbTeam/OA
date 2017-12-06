namespace xyoa.HumanResources.Gongzi.GongziSB
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class GongziSB_show : Page
    {
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label EndTime;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label NowTimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label SpRealname;
        protected Label SpRemark;
        protected TextBox SpUsername;
        protected Label StartTime;
        protected Label Zhangtao;
        protected Label Zhuangtai;
        protected Label Zhuti;

        public void DataBindToGridview()
        {
            string sql = "select * from hr_" + this.Number.Text + "";
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee7b", this.Session["perstr"].ToString());
                string sql = string.Concat(new object[] { "select * from qp_hr_GongziSB where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Zhangtao.Text = this.divhr.TypeCode("Name", "qp_hr_GongziSZ", list["Zhangtao"].ToString());
                    this.StartTime.Text = DateTime.Parse(list["StartTime"].ToString()).ToShortDateString();
                    this.EndTime.Text = DateTime.Parse(list["EndTime"].ToString()).ToShortDateString();
                    this.SpUsername.Text = list["SpUsername"].ToString();
                    this.SpRemark.Text = list["SpRemark"].ToString();
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正在审批").Replace("2", "通过审批").Replace("3", "拒绝审批").Replace("4", "等待审批");
                    this.NowTimes.Text = list["NowTimes"].ToString();
                    this.SpRealname.Text = list["SpRealname"].ToString();
                }
                list.Close();
                this.DataBindToGridview();
                try
                {
                    string str2 = "select   count(a.name)   from   syscolumns   a,sysobjects   b     where   a.id=b.id     and   b.name='hr_" + this.Number.Text + "'";
                    int num = this.List.GetCount(str2) + 1;
                    for (int i = 0; i < num; i++)
                    {
                        this.GridView1.HeaderRow.Cells[i].Text = this.GridView1.HeaderRow.Cells[i].Text.ToString().Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("(", "").Replace(")", "");
                    }
                }
                catch
                {
                }
            }
        }
    }
}


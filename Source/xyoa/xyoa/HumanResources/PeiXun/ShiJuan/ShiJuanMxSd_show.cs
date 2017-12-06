namespace xyoa.HumanResources.PeiXun.ShiJuan
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ShiJuanMxSd_show : Page
    {
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Fenzhi1;
        protected Label Fenzhi2;
        protected Label Fenzhi3;
        protected Label Fenzhi4;
        protected Label Fenzhi5;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected GridView GridView2;
        protected GridView GridView3;
        protected GridView GridView4;
        protected GridView GridView5;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label MingchengID;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label ShijuanID;

        public void DataBindToGridview()
        {
            string sql = "select A.id,B.Titles as TitlesC from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_DanXuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + base.Request.QueryString["ShijuanID"] + "' and Leixing=1";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str2 = "select A.id,B.Titles as TitlesC from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_DuoXuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + base.Request.QueryString["ShijuanID"] + "' and Leixing=2";
            this.GridView2.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView2.DataBind();
            string str3 = "select A.id,B.Titles as TitlesC from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_PanDuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + base.Request.QueryString["ShijuanID"] + "' and Leixing=3";
            this.GridView3.DataSource = this.List.GetGrid_Pages_not(str3);
            this.GridView3.DataBind();
            string str4 = "select A.id,B.FrontTitle,B.BackTitle,B.Answer from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_TianKongTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + base.Request.QueryString["ShijuanID"] + "' and Leixing=4";
            this.GridView4.DataSource = this.List.GetGrid_Pages_not(str4);
            this.GridView4.DataBind();
            string str5 = "select A.id,B.Titles as TitlesC from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_WenDaTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + base.Request.QueryString["ShijuanID"] + "' and Leixing=5";
            this.GridView5.DataSource = this.List.GetGrid_Pages_not(str5);
            this.GridView5.DataBind();
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
            else
            {
                if (!this.Page.IsPostBack)
                {
                    string sql = "select * from qp_hr_ShiJuan where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.MingchengID.Text = this.divhr.TypeCode("Mingcheng", "qp_hr_TikuLb", list["MingchengID"].ToString());
                        this.ShijuanID.Text = this.divhr.TypeCode("Titles", "qp_hr_ShiJuan", list["id"].ToString());
                    }
                    list.Close();
                    string str2 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "' and Leixing=1";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.Fenzhi1.Text = reader2["Fenshu"].ToString();
                    }
                    reader2.Close();
                    string str3 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "' and Leixing=2";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    if (reader3.Read())
                    {
                        this.Fenzhi2.Text = reader3["Fenshu"].ToString();
                    }
                    reader3.Close();
                    string str4 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "' and Leixing=3";
                    SqlDataReader reader4 = this.List.GetList(str4);
                    if (reader4.Read())
                    {
                        this.Fenzhi3.Text = reader4["Fenshu"].ToString();
                    }
                    reader4.Close();
                    string str5 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "' and Leixing=4";
                    SqlDataReader reader5 = this.List.GetList(str5);
                    if (reader5.Read())
                    {
                        this.Fenzhi4.Text = reader5["Fenshu"].ToString();
                    }
                    reader5.Close();
                    string str6 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "' and Leixing=5";
                    SqlDataReader reader6 = this.List.GetList(str6);
                    if (reader6.Read())
                    {
                        this.Fenzhi5.Text = reader6["Fenshu"].ToString();
                    }
                    reader6.Close();
                }
                this.DataBindToGridview();
            }
        }
    }
}


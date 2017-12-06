namespace xyoa.PublicWork.Hetong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongCxList : Page
    {
        protected Label AllMoney;
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;

        public void BindAttribute()
        {
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "jjjj8c", this.Session["perstr"].ToString());
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (this.GoPage.Text.Trim().ToString() == "")
                {
                    base.Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
                }
                else if ((this.GoPage.Text.Trim().ToString() == "0") || (Convert.ToInt32(this.GoPage.Text.Trim().ToString()) > this.GridView1.PageCount))
                {
                    base.Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
                }
                else if (this.GoPage.Text.Trim() != "")
                {
                    int num = int.Parse(this.GoPage.Text.Trim()) - 1;
                    if ((num >= 0) && (num < this.GridView1.PageCount))
                    {
                        this.GridView1.PageIndex = num;
                    }
                }
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            catch
            {
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                base.Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["fangwei"].ToString() != "0")
            {
                if (base.Request.QueryString["fangwei"].ToString() == "1")
                {
                    str = string.Concat(new object[] { str, " and A.Username = '", this.Session["username"], "'" });
                }
                if (base.Request.QueryString["fangwei"].ToString() == "2")
                {
                    if (base.Request.QueryString["Username"].ToString() != "")
                    {
                        str = str + " and CHARINDEX(','+A.Username+',','," + base.Request.QueryString["Username"].ToString() + ",')   >   0 ";
                    }
                    else
                    {
                        str = string.Concat(new object[] { str, " and CHARINDEX(','+A.Username+',',','+(select RyUsername from qp_oa_HetongSz where ZgUsername='", this.Session["username"], "')+',') > 0" });
                    }
                }
            }
            if (base.Request.QueryString["Zhuti"].ToString() != "")
            {
                str = str + " and A.Zhuti like '%" + base.Request.QueryString["Zhuti"].ToString() + "%'";
            }
            if (base.Request.QueryString["Hetonghao"].ToString() != "")
            {
                str = str + " and A.Hetonghao like '%" + base.Request.QueryString["Hetonghao"].ToString() + "%'";
            }
            if (base.Request.QueryString["Zhuangtai"].ToString() != "")
            {
                str = str + " and A.Zhuangtai = '" + base.Request.QueryString["Zhuangtai"].ToString() + "'";
            }
            if (base.Request.QueryString["Fenlei"].ToString() != "0")
            {
                str = str + " and A.Fenlei = '" + base.Request.QueryString["Fenlei"].ToString() + "'";
            }
            if ((base.Request.QueryString["Jine1"].ToString() != "") && (base.Request.QueryString["Jine2"].ToString() != ""))
            {
                str = str + " and jine>=" + base.Request.QueryString["Jine1"].ToString() + " and jine<=" + base.Request.QueryString["Jine2"].ToString() + "";
            }
            if (base.Request.QueryString["Danwei"].ToString() != "")
            {
                str = str + " and A.Danwei like '%" + base.Request.QueryString["Danwei"].ToString() + "%'";
            }
            if (base.Request.QueryString["LcZhuangtai"].ToString() != "")
            {
                str = str + " and A.LcZhuangtai = '" + base.Request.QueryString["LcZhuangtai"].ToString() + "'";
            }
            if ((base.Request.QueryString["Starttime"].ToString() != "") && (base.Request.QueryString["Endtime"].ToString() != ""))
            {
                str = str + " and (A.Qianyue between '" + base.Request.QueryString["Starttime"].ToString() + "'and  '" + base.Request.QueryString["Endtime"].ToString() + "' or convert(char(10),cast(A.Qianyue as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Starttime"].ToString() + "' as datetime),120) or convert(char(10),cast(A.Qianyue as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Endtime"].ToString() + "' as datetime),120) ) ";
            }
            if (base.Request.QueryString["Qixian"].ToString() != "0")
            {
                str = str + " and A.Qixian = '" + base.Request.QueryString["Qixian"].ToString() + "'";
            }
            if ((base.Request.QueryString["DaoqiS"].ToString() != "") && (base.Request.QueryString["DaoqiE"].ToString() != ""))
            {
                str = str + " and (A.Daoqi between '" + base.Request.QueryString["DaoqiS"].ToString() + "'and  '" + base.Request.QueryString["DaoqiE"].ToString() + "' or convert(char(10),cast(A.Daoqi as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["DaoqiS"].ToString() + "' as datetime),120) or convert(char(10),cast(A.Daoqi as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["DaoqiE"].ToString() + "' as datetime),120) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.Username as AUsername,A.Realname as ARealname,A.id,A.LcZhuangtai,A.DqBlXinming,A.DqBlUsername,A.Zhuti,A.Hetonghao,A.Fenlei,A.Zhuangtai,A.Danwei,A.Jine,B.Name as FenleiName from [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where 1=1";
            string str2 = str + SqlCreate;
            string sql = "select sum(A.Jine) as AllShuliang from  [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where 1=1 " + SqlCreate + " ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["AllShuliang"].ToString() == "")
                {
                    this.AllMoney.Text = "0.00";
                }
                else
                {
                    this.AllMoney.Text = string.Format("{0:N}", list["AllShuliang"]);
                }
            }
            else
            {
                this.AllMoney.Text = "0.00";
            }
            list.Close();
            string str4 = "" + str2 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
            this.GridView1.DataBind();
            string str5 = "select count(A.id) from [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where 1=1";
            string str6 = str5 + SqlCreate;
            this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
            this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
            this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pulicss.addfenye(this.DropDownList1.SelectedValue);
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sqlsort = "";
            if ((this.ViewState["SortDirection"] == null) || (this.ViewState["SortDirection"].ToString().CompareTo("") == 0))
            {
                this.ViewState["SortDirection"] = " desc";
            }
            else
            {
                this.ViewState["SortDirection"] = "";
            }
            sqlsort = " order by " + e.SortExpression + this.ViewState["SortDirection"];
            this.DataBindToGridview(sqlsort, this.CreateMidSql());
            this.SortText.Value = sqlsort;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
            }
        }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((LinkButton) sender).CommandName) - 1;
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }
    }
}


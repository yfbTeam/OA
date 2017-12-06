namespace xyoa.InfoManage.toupiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class toupiao_tp : Page
    {
        protected Button Button2;
        protected Button DelData;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox TextBox1;

        public void Bindquanxian()
        {
            this.DelData.Attributes["onclick"] = "javascript:return tpcheck();";
            this.pulicss.QuanXianVis(this.GridView1, "aaaa6a", this.Session["perstr"].ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("toupiao.aspx");
        }

        private string CheckCbxDel()
        {
            string str = "0";
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort)
        {
            string sql = "select * from qp_oa_toupiao  where bigId='" + base.Request.QueryString["id"] + "'  " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void DelData_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = string.Concat(new object[] { "select  * from qp_oa_toupiao where  CHARINDEX(',", this.Session["Username"], ",',','+TpUsername+',')   >   0  and  bigId ='", base.Request.QueryString["id"], "' " });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('已参与，请勿重复投票！');</script>");
            }
            else
            {
                string str3;
                list.Close();
                if (this.DropDownList1.SelectedValue == "1")
                {
                    str3 = string.Concat(new object[] { "  update  qp_oa_toupiao set piaoshu=piaoshu+1,TpUsername=TpUsername+'", this.Session["username"], ",',TpRealname=TpRealname+'匿名,' where ID in (", str, ")" });
                    this.List.ExeSql(str3);
                }
                else
                {
                    str3 = string.Concat(new object[] { "  update  qp_oa_toupiao set piaoshu=piaoshu+1,TpUsername=TpUsername+'", this.Session["username"], ",',TpRealname=TpRealname+'", this.Session["realname"], ",' where ID in (", str, ")" });
                    this.List.ExeSql(str3);
                }
                this.pulicss.InsertLog("参加投票", "投票浏览");
                this.DataBindToGridview("order by id desc");
            }
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
            this.DataBindToGridview(sqlsort);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_toupiaobt where id='", int.Parse(base.Request.QueryString["id"].ToString()), "' and (ifopen='1' or ifopen='2') and  (CHARINDEX(',", this.Session["Username"], ",',','+Gkusername+',')   >   0 or Gkusername='0')" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["title"] = list["title"].ToString();
                    this.ViewState["contents"] = this.pulicss.TbToLb(list["contents"].ToString());
                    this.TextBox1.Text = list["xuanze"].ToString();
                    if (list["ifopen"].ToString() == "1")
                    {
                        this.DropDownList1.Enabled = true;
                    }
                    else
                    {
                        this.DropDownList1.Enabled = false;
                    }
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('无投票主题！');window.location.href='toupiao.aspx'</script>");
                }
                list.Close();
                this.DataBindToGridview("order by id desc");
                this.Bindquanxian();
            }
        }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((LinkButton) sender).CommandName) - 1;
                this.DataBindToGridview("order by id desc");
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }
    }
}


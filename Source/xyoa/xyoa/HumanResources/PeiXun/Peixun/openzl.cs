namespace xyoa.HumanResources.PeiXun.Peixun
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class openzl : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MingchengID;
        protected TextBox Name;
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Name.Text = "";
            this.MingchengID.SelectedValue = "";
            this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "select id from qp_hr_PeixunZl where  id in (" + this.CheckCbxDel() + ") ";
            SqlDataReader list = this.List.GetList(sql);
            if (!list.Read())
            {
                base.Response.Write("<script language=javascript>alert('未找到需要导入的文件！');</script>");
            }
            else
            {
                list.Close();
                string str2 = "select Name,Newname from qp_hr_PeixunZl where  id in (" + this.CheckCbxDel() + ")";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    string str3 = "insert into qp_hr_PeixunFile (Name,NewName,KeyField) values ('" + reader2["Name"].ToString() + "','" + reader2["Newname"].ToString() + "','" + base.Request.QueryString["number"].ToString() + "')";
                    this.List.ExeSql(str3);
                }
                reader2.Close();
                base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
            }
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
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

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Name.Text != "")
            {
                str = str + " and Name like '%" + this.pulicss.GetFormatStr(this.Name.Text) + "%'";
            }
            if (this.MingchengID.SelectedValue != "")
            {
                str = str + " and MingchengID = '" + this.MingchengID.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str = "select A.*,D.[Mingcheng] as Mingcheng from [qp_hr_PeixunZl] as [A]  inner join [qp_hr_PeixunLb] as [D] on [A].[MingchengID] = [D].[Id] where 1=1";
            string str2 = "select count(A.id) from qp_hr_PeixunZl as [A] where 1=1";
            string str3 = str + SqlCreate;
            string str4 = str2 + SqlCreate;
            string sql = "" + str3 + " " + Sqlsort + "";
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng from qp_hr_PeixunLb order by id asc";
                this.list.Bind_DropDownList_kong(this.MingchengID, sQL, "id", "Mingcheng");
                this.MingchengID.SelectedValue = base.Request.QueryString["Leibie"].ToString();
                this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
            }
        }
    }
}


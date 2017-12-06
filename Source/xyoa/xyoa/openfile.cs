namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class openfile : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected DropDownList Folder;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox OldName;
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.OldName.Text = "";
            this.Folder.SelectedValue = "";
            this.DataBindToGridview("order by id desc", this.CreateMidSql());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "select OldName,NewName,Fjtype from qp_oa_Paper where  id in (" + this.CheckCbxDel() + ") ";
            SqlDataReader list = this.List.GetList(sql);
            if (!list.Read())
            {
                base.Response.Write("<script language=javascript>alert('未找到需要导入的文件！');</script>");
            }
            else
            {
                list.Close();
                string str2 = "select OldName,NewName,Fjtype from qp_oa_Paper where  id in (" + this.CheckCbxDel() + ") ";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    this.pulicss.Insertfile(reader2["OldName"].ToString(), reader2["NewName"].ToString(), base.Request.QueryString["number"].ToString(), reader2["Fjtype"].ToString());
                }
                reader2.Close();
                base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
            }
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by id desc", this.CreateMidSql());
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
            if (this.OldName.Text != "")
            {
                str = str + " and OldName like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.OldName.Text)) + "%'";
            }
            if (this.Folder.SelectedValue != "")
            {
                str = str + " and FoldersID = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.Folder.SelectedValue)) + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str = "select * from qp_oa_Paper where 1=1 and Username='" + this.Session["username"] + "' ";
            string str2 = "select count(id) from qp_oa_Paper where 1=1 and Username='" + this.Session["username"] + "' ";
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
                this.pulicss.BindListkong("qp_oa_Folders", this.Folder, " and username='" + this.Session["username"] + "'", "order by id asc");
                this.DataBindToGridview("order by id desc", this.CreateMidSql());
            }
        }
    }
}


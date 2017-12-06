namespace xyoa.SystemManage.User
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class usernameys : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected DropDownList BuMenId;
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected Button DelData;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Usernames;
        protected DropDownList Zhiweiid;

        public void BindAttribute()
        {
            this.Realname.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.DelData.Attributes["onclick"] = "javascript:return hycheck();";
            this.Button3.Attributes["onclick"] = "javascript:return delcheck();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("usernameys.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "select username from qp_oa_username where ID in (" + str + ")";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str3 = "  Delete from qp_oa_yangshi  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str3);
                string str4 = "  Delete from qp_oa_MyReminded  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str4);
                string str5 = "  Delete from qp_oa_MyState  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str5);
                string str6 = "  Delete from qp_oa_MyWeituo  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str6);
                string str7 = "  Delete from qp_oa_Menu  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str7);
                string str8 = "  Delete from qp_oa_MyData  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str8);
                string str9 = "  Delete from qp_oa_OpenMenu  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str9);
                string str10 = "  Delete from qp_oa_DIYMould  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str10);
                string str11 = "  Delete from qp_oa_MakeTing  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str11);
                string str12 = "  Delete from qp_hr_Yuangong  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str12);
                string str13 = "  Delete from qp_oa_MyUserList  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str13);
                string str14 = "  Delete from qp_oa_SpBeiZhu  where Username='" + list["username"] + "' and username!='admin'";
                this.List.ExeSql(str14);
            }
            list.Close();
            string str15 = "  Delete from qp_oa_username  where ID in (" + str + ") and username!='admin'";
            this.List.ExeSql(str15);
            this.pulicss.InsertLog("删除用户[" + this.CheckCbxNameDel() + "]", "用户管理");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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

        private string CheckCbxNameDel()
        {
            string str = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabNameVisible");
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

        private string CheckCbxUpdate()
        {
            string str = string.Empty;
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
            if (this.Realname.Text != "")
            {
                str = str + " and Realname like '%" + this.pulicss.GetFormatStr(this.Realname.Text) + "%'";
            }
            if (this.Usernames.Text != "")
            {
                str = str + " and Username like '%" + this.pulicss.GetFormatStr(this.Usernames.Text) + "%'";
            }
            if (this.JueseId.SelectedValue != "")
            {
                str = str + " and JueseId = '" + this.JueseId.SelectedValue + "'";
            }
            if (this.Zhiweiid.SelectedValue != "")
            {
                str = str + " and Zhiweiid = '" + this.Zhiweiid.SelectedValue + "'";
            }
            if (this.BuMenId.SelectedValue != "")
            {
                str = str + " and BuMenId = '" + this.BuMenId.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.Iflogin,A.id,A.Username, A.QxString, A.Realname, B.[Name] as BuMenName, C.[Name] as JueseName , D.[Name] as ZhiweiName from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='1'";
            string str2 = "select count(id) from qp_oa_username as [A] where 1=1 and  ifdel='1'";
            string str3 = str + SqlCreate;
            string str4 = str2 + SqlCreate;
            string sql = "" + str3 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str6 = str4;
            this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
            this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
            this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void DelData_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "Update qp_oa_username  Set ifdel='0' where ID in (" + str + ") and username!='admin'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("还原用户[" + this.CheckCbxNameDel() + "]", "用户管理");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
                this.pulicss.BindListkong("qp_oa_Bumen", this.BuMenId, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiweiid, sQL, "id", "name");
                string str2 = "select id,name  from qp_oa_Juese order by id asc";
                this.list.Bind_DropDownList_kong(this.JueseId, str2, "id", "name");
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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

        protected void SearchData_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }
    }
}


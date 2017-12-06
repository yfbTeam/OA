namespace xyoa.HumanResources.Hetong.HetongCZ
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongCZ_show : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList LeibieID;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox QyRealname;
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Username;

        public void BindAttribute()
        {
            this.Button3.Attributes["onclick"] = "javascript:return addcheck();";
            this.Button4.Attributes["onclick"] = "javascript:return addcheck();";
            this.Button5.Attributes["onclick"] = "javascript:return addcheck();";
            this.Button6.Attributes["onclick"] = "javascript:return addcheck();";
            this.QyRealname.Attributes.Add("readonly", "readonly");
            this.QyRealname.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "eeee3c", this.Session["perstr"].ToString());
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
            base.Response.Redirect("HetongCZ_show.aspx?bmid=" + base.Request.QueryString["bmid"] + "");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (this.CheckCbxDel() == "0")
            {
                base.Response.Write("<script language='javascript'>alert('请选择需要操作的合同');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'>updatefrom1('" + this.CheckCbxDel() + "');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.CheckCbxDel() == "0")
            {
                base.Response.Write("<script language='javascript'>alert('请选择需要操作的合同');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'>updatefrom2('" + this.CheckCbxDel() + "');</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (this.CheckCbxDel() == "0")
            {
                base.Response.Write("<script language='javascript'>alert('请选择需要操作的合同');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'>updatefrom3('" + this.CheckCbxDel() + "');</script>");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (this.CheckCbxDel() == "0")
            {
                base.Response.Write("<script language='javascript'>alert('请选择需要操作的合同');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'>updatefrom4('" + this.CheckCbxDel() + "');</script>");
            }
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
                        str = str + "," + label.Text.ToString() + "";
                    }
                }
            }
            return str;
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.QyRealname.Text != "")
            {
                str = str + " and A.QyUsername='" + this.pulicss.GetFormatStr(this.Username.Text) + "'";
            }
            if (this.LeibieID.SelectedValue != "")
            {
                str = str + " and A.LeibieID = '" + this.LeibieID.SelectedValue + "'";
            }
            if (base.Request.QueryString["bmid"] != "0")
            {
                str = str + " and [B].id='" + base.Request.QueryString["bmid"] + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.Qixian,A.QdTime,A.id,A.LeibieID,A.QyUsername,A.QyRealname,A.Starttime,A.Endtime,A.Zhuangtai,D.[Mingcheng] as LeibieName from [qp_hr_HetongMg] as [A]  inner join [qp_hr_HetongMB] as [D] on [A].[LeibieID] = [D].[Id] inner join [qp_oa_username] as [C] on [A].[QyUsername] = [C].[Username] inner join [qp_oa_Bumen] as [B] on [B].[id] = [C].[BuMenId] where (A.Zhuangtai=1 or A.Zhuangtai=2)";
            string str2 = "select count(A.id) from [qp_hr_HetongMg] as [A]  inner join [qp_hr_HetongMB] as [D] on [A].[LeibieID] = [D].[Id] inner join [qp_oa_username] as [C] on [A].[QyUsername] = [C].[Username] inner join [qp_oa_Bumen] as [B] on [B].[id] = [C].[BuMenId]  where (A.Zhuangtai=1 or A.Zhuangtai=2)";
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label3");
                Label label2 = (Label) e.Row.FindControl("EndtimeT");
                Label label3 = (Label) e.Row.FindControl("QixianS");
                Label label4 = (Label) e.Row.FindControl("EndtimeS");
                if ((label.Text == "1") || (label.Text == "2"))
                {
                    ((CheckBox) e.Row.FindControl("CheckSelect")).Enabled = true;
                }
                else
                {
                    ((CheckBox) e.Row.FindControl("CheckSelect")).Enabled = false;
                }
                if (label3.Text == "1")
                {
                    label2.Text = label4.Text;
                }
                else
                {
                    label2.Text = "无固定期限";
                }
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
                string sql = "select id from qp_hr_HetongMg where datediff(dd,Endtime,getdate())>0 and Zhuangtai=1 and Qixian=1";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    string str2 = "Update qp_hr_HetongMg  Set Zhuangtai='2' where id='" + list["id"].ToString() + "'";
                    this.List.ExeSql(str2);
                    this.divhr.Insertlsz(list["id"].ToString(), "7", "HumanResources/Hetong/HetongMg/HetongMg_show_lsz.aspx?id=" + list["id"].ToString() + "");
                }
                list.Close();
                string sQL = "select id,Mingcheng from qp_hr_HetongMB where Zhuangtai=1 order by id asc";
                this.list.Bind_DropDownList_kong(this.LeibieID, sQL, "id", "Mingcheng");
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

        protected void SearchData_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }
    }
}


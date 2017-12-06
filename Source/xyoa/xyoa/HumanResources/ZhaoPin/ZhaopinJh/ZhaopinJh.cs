namespace xyoa.HumanResources.ZhaoPin.ZhaopinJh
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZhaopinJh : Page
    {
        protected Button AddData;
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected DropDownList Bumen;
        protected Button Button1;
        protected Button Button2;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected Button DelData;
        protected DropDownList DropDownList1;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Button Jieshu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Starttime;
        protected Button UpdateData;
        protected DropDownList Zhiwei;
        protected TextBox Zhuti;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ZhaopinJh_add.aspx");
        }

        public void BindAttribute()
        {
            this.Zhuti.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
            this.UpdateData.Attributes["onclick"] = "javascript:return updatecheck();";
            this.DelData.Attributes["onclick"] = "javascript:return delcheck();";
            this.Jieshu.Attributes["onclick"] = "javascript:return jieshucheck();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.AddData, "eeee1a", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.UpdateData, "eeee1a", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.DelData, "eeee1a", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.Jieshu, "eeee1a", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.GridView1, "eeee1a", this.Session["perstr"].ToString());
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
            base.Response.Redirect("ZhaopinJh.aspx?Zhuangtai=" + base.Request.QueryString["Zhuangtai"] + "");
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
            if (this.Zhuti.Text != "")
            {
                str = str + " and Zhuti like '%" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "%'";
            }
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and ((Qixian between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(Qixian as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(Qixian as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)))";
            }
            if (this.Bumen.SelectedValue != "")
            {
                str = str + " and Bumen = '" + this.Bumen.SelectedValue + "'";
            }
            if (this.Zhiwei.SelectedValue != "")
            {
                str = str + " and Zhiwei = '" + this.Zhiwei.SelectedValue + "'";
            }
            if (base.Request.QueryString["Zhuangtai"].ToString() != "0")
            {
                str = str + " and Zhuangtai = '" + base.Request.QueryString["Zhuangtai"].ToString() + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.SpUsername,A.SpRealname,A.Jieshu,A.id,A.Zhuti,A.Bumen,A.Zhiwei,A.Renshu,A.Qixian,A.Zhuangtai,A.Username,A.Realname, B.[Name] as BuMenName,  D.[Name] as ZhiweiName from [qp_hr_ZhaopinJh] as [A] inner join [qp_oa_Bumen] as [B] on [A].[Bumen] = [B].[Id]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id] where A.Username='" + this.Session["Username"] + "'";
            string str2 = "select count(id) from qp_hr_ZhaopinJh as [A] where A.Username='" + this.Session["Username"] + "'";
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
            string sql = "  Delete from qp_hr_ZhaopinJh  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除用人申请", "用人申请");
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
            if ((base.Request.QueryString["Zhuangtai"].ToString() == "2") && (e.Row.RowType == DataControlRowType.DataRow))
            {
                Label label = (Label) e.Row.FindControl("Label3");
                if (label.Text == "2")
                {
                    ((CheckBox) e.Row.FindControl("CheckSelect")).Enabled = false;
                }
                else
                {
                    ((CheckBox) e.Row.FindControl("CheckSelect")).Enabled = true;
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

        protected void Jieshu_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "update qp_hr_ZhaopinJh set Jieshu='2' where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("结束用人申请", "用人申请");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListkong("qp_oa_Bumen", this.Bumen, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
                if (base.Request.QueryString["Zhuangtai"].ToString() == "4")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4on";
                    this.Jieshu.Visible = false;
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "1")
                {
                    this.ViewState["btncss1"] = "btn4on";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4off";
                    this.UpdateData.Visible = false;
                    this.DelData.Visible = false;
                    this.Jieshu.Visible = false;
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "2")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4on";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4off";
                    this.UpdateData.Visible = false;
                    this.DelData.Visible = false;
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "3")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4on";
                    this.ViewState["btncss4"] = "btn4off";
                    this.UpdateData.Visible = false;
                    this.Jieshu.Visible = false;
                }
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

        protected void UpdateData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ZhaopinJh_update.aspx?id=" + this.CheckCbxUpdate() + "");
        }
    }
}


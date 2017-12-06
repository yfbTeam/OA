﻿namespace xyoa.OfficeMenu.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RenwuJk_lb : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected CheckBoxList CheckBoxList1;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Pizhu;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected TextBox SetTime;
        protected HtmlInputHidden SortText;
        protected DropDownList State;
        protected TextBox titles;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.titles.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SetTime.Attributes.Add("readonly", "readonly");
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "kkkk7c", this.Session["perstr"].ToString());
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
            base.Response.Redirect("RenwuJk_lb.aspx");
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
            if (this.titles.Text != "")
            {
                str = str + " and titles like '%" + this.pulicss.GetFormatStr(this.titles.Text) + "%'";
            }
            if (this.CheckBoxList1.Items.Count > 0)
            {
                int num = 0;
                for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
                {
                    if (this.CheckBoxList1.Items[i].Selected)
                    {
                        num++;
                    }
                }
                if (num > 0)
                {
                    str = str + " and (CHARINDEX(','+ZbUsername+',','," + this.pulicss.GetChecked(this.CheckBoxList1) + ",') > 0)";
                }
            }
            if (this.State.SelectedValue != "")
            {
                str = str + " and State = '" + this.State.SelectedValue + "'";
            }
            if (this.SetTime.Text != "")
            {
                str = str + " and convert(char(10),cast(SetTime as datetime),120)=convert(char(10),cast('" + this.SetTime.Text + "' as datetime),120) ";
            }
            if (this.Leixing.SelectedValue != "")
            {
                str = str + " and Leixing = '" + this.Leixing.SelectedValue + "'";
            }
            if (!(this.Pizhu.SelectedValue != ""))
            {
                return str;
            }
            if (this.Pizhu.SelectedValue == "未阅读")
            {
                return string.Concat(new object[] { str, " and CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   =0" });
            }
            return string.Concat(new object[] { str, " and CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   >0" });
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str2 = string.Concat(new object[] { "select A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime, B.[name] as LeiBieName from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id] left join [qp_oa_RenwuXb] as [C] on [A].[id] = [C].[Keyid]  where ((CHARINDEX(','+A.ZbUsername+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='", this.Session["username"], "')+',') > 0) or (CHARINDEX(','+C.Username+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='", this.Session["username"], "')+',') > 0))" }) + SqlCreate + " group by  A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime,B.[name]";
            string sql = "" + str2 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            int num = 0;
            string str4 = string.Concat(new object[] { "select A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime, B.[name] as LeiBieName from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id] left join [qp_oa_RenwuXb] as [C] on [A].[id] = [C].[Keyid]  where ((CHARINDEX(','+A.ZbUsername+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='", HttpContext.Current.Session["username"], "')+',') > 0) or (CHARINDEX(','+C.Username+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='", HttpContext.Current.Session["username"], "')+',') > 0)) ", SqlCreate, " group by  A.WcTime,A.Benbi,A.id,A.titles,A.Starttime,A.Endtime,A.ZbUsername,A.ZbRealname,A.Leixing,A.Benbi,A.State,A.Username,A.Realname,A.SetTime,B.[name] " });
            SqlDataReader list = this.List.GetList(str4);
            while (list.Read())
            {
                num++;
            }
            list.Close();
            this.CountsLabel.Text = "" + num + "";
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
                string sQL = "select username, Realname  from qp_oa_username  where 1=1 and ifdel='0' and CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_Renwusz where ZgUsername='" + this.Session["username"] + "')+',') > 0";
                this.list.Bind_DropDownList_CheckBoxList(this.CheckBoxList1, sQL, "username", "Realname");
                string str2 = "select id,name  from qp_oa_RenwuLx order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, str2, "id", "name");
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


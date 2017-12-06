﻿namespace xyoa.MyWork.wjk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Folders_show : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected DropDownList Folder;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected LinkButton LinkButton3;
        protected LinkButton LinkButton4;
        protected LinkButton LinkButton5;
        protected LinkButton LinkButton6;
        protected LinkButton LinkButton7;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Namefile;
        protected TextBox OldName;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;

        public void BindAttribute()
        {
            this.OldName.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
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
            base.Response.Redirect("Folders_show.aspx?id=" + base.Request.QueryString["id"] + "");
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
            if (this.OldName.Text != "")
            {
                str = str + " and OldName like '%" + this.pulicss.GetFormatStr(this.OldName.Text) + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str;
            string str2;
            string str3;
            string str4;
            string str5;
            string str6;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            if (base.Request.QueryString["id"].ToString() == "0")
            {
                str = "select * from qp_oa_Paper where 1=1 and Username='" + this.Session["username"] + "' ";
                str2 = "select count(id) from qp_oa_Paper where 1=1 and Username='" + this.Session["username"] + "' ";
                str3 = str + SqlCreate;
                str4 = str2 + SqlCreate;
                str5 = "" + str3 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str5);
                this.GridView1.DataBind();
                str6 = str4;
                this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
                this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
                this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
            }
            else
            {
                str = string.Concat(new object[] { "select * from qp_oa_Paper where 1=1 and FoldersID='", base.Request.QueryString["id"], "' and Username='", this.Session["username"], "' " });
                str2 = string.Concat(new object[] { "select count(id) from qp_oa_Paper where 1=1 and FoldersID='", base.Request.QueryString["id"], "' and Username='", this.Session["username"], "' " });
                str3 = str + SqlCreate;
                str4 = str2 + SqlCreate;
                str5 = "" + str3 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str5);
                this.GridView1.DataBind();
                str6 = str4;
                this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
                this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
                this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
            }
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        private void DelNode(string IDStr, string PID)
        {
            string sql = "  Delete from qp_oa_Folders  where id='" + IDStr + "'";
            this.List.ExeSql(sql);
            string str2 = "select * from qp_oa_Folders where (ParentNodesID=" + IDStr.ToString() + ")  order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                string str3 = "  Delete from qp_oa_Folders  where id='" + list["ID"].ToString() + "'";
                this.List.ExeSql(str3);
                string str4 = "select * from qp_oa_Folders where ParentNodesID=" + list["id"] + " ";
                SqlDataReader reader2 = this.List.GetList(str4);
                if (reader2.Read())
                {
                    string iDStr = list["ID"].ToString();
                    string pID = list["ParentNodesID"].ToString();
                    this.DelNode(iDStr, pID);
                }
                reader2.Close();
            }
            list.Close();
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "  Delete from qp_oa_Paper  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除文件[" + this.CheckCbxNameDel() + "]", "个人文件柜");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("file_add.aspx?FoldersID=" + base.Request.QueryString["id"] + "");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Folders_add.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"].ToString() == "0")
            {
                base.Response.Write("<script language=javascript>alert('没有找到此文件夹！');</script>");
            }
            else
            {
                base.Response.Redirect("Folders_update.aspx?id=" + base.Request.QueryString["id"] + "");
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"].ToString() == "0")
            {
                base.Response.Write("<script language=javascript>alert('没有找到此文件夹！');</script>");
            }
            else
            {
                this.DelNode(base.Request.QueryString["id"], base.Request.QueryString["id"]);
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'Folders.aspx'</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string str = random.Next(0x2710).ToString();
            string str2 = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
            base.Response.Redirect("SeadFile.aspx?id=" + this.CheckCbxDel() + "&Number=" + str2 + "");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "Update qp_oa_Paper  Set FoldersID='" + this.Folder.SelectedValue + "' where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("转移文件[" + this.CheckCbxNameDel() + "]", "个人文件柜");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
                    this.BindAttribute();
                    this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                    this.LinkButton1.Attributes["onclick"] = "javascript:return delcheck();";
                    this.LinkButton7.Attributes["onclick"] = "javascript:return FolderMovecheck();";
                    this.LinkButton5.Attributes["onclick"] = "javascript:return delf();";
                    this.LinkButton6.Attributes["onclick"] = "javascript:return sendfile();";
                    string sql = string.Concat(new object[] { "select * from qp_oa_Folders   where id='", int.Parse(base.Request.QueryString["id"]), "'  and username='", this.Session["username"], "'" });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Namefile.Text = list["name"].ToString();
                    }
                    else
                    {
                        this.Namefile.Text = "请选择文件夹";
                    }
                    list.Close();
                }
                if (!base.IsPostBack)
                {
                    this.pulicss.BindListNothing("qp_oa_Folders", this.Folder, " and username='" + this.Session["username"] + "'", "order by id asc");
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
    }
}


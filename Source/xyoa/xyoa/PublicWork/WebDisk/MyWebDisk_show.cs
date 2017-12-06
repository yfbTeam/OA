namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_show : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Label CjName;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected DropDownList Folder;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton10;
        protected LinkButton LinkButton2;
        protected LinkButton LinkButton3;
        protected LinkButton LinkButton4;
        protected LinkButton LinkButton5;
        protected LinkButton LinkButton6;
        protected LinkButton LinkButton8;
        protected LinkButton LinkButton9;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Namefile;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox TextBox1;
        protected TextBox Titles;

        public void BindAttribute()
        {
            this.Titles.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.LinkButton1.Attributes["onclick"] = "javascript:return delcheck();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.LinkButton2, "jjjja1b", this.Session["perstr"].ToString());
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
            base.Response.Redirect("MyWebDisk_show.aspx?id=" + base.Request.QueryString["id"] + "");
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
            if (this.Titles.Text.Trim() != "")
            {
                str = str + " and OldName like '%" + this.pulicss.GetFormatStr(this.Titles.Text) + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.[NowTimes],A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[Realname],A.[TypeId],A.[Username] from [qp_oa_MyWebDiskFile] as [A] where TypeId='" + base.Request.QueryString["id"] + "' ";
            string str2 = "select count(A.id) from [qp_oa_MyWebDiskFile] as [A] where TypeId='" + base.Request.QueryString["id"] + "' ";
            string str3 = str + SqlCreate + "";
            string str4 = str2 + SqlCreate + "";
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

        private void DelNode(string IDStr, string PID)
        {
            string sql = "  Delete from qp_oa_WebDiskLx  where id='" + IDStr + "'";
            this.List.ExeSql(sql);
            string str2 = "select * from qp_oa_WebDiskLx where (ParentNodesID=" + IDStr.ToString() + ")  order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                string str3 = "  Delete from qp_oa_WebDiskLx  where id='" + list["ID"].ToString() + "'";
                this.List.ExeSql(str3);
                string str4 = "select * from qp_oa_WebDiskLx where ParentNodesID=" + list["id"] + " ";
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str2;
                Label label = (Label) e.Row.FindControl("Name");
                Label label2 = (Label) e.Row.FindControl("OldName");
                Label label3 = (Label) e.Row.FindControl("Fjtype");
                Label label4 = (Label) e.Row.FindControl("Caidan");
                Label label5 = (Label) e.Row.FindControl("Lid");
                Label label6 = (Label) e.Row.FindControl("NewName");
                Label label7 = (Label) e.Row.FindControl("NewName");
                string str = null;
                if (((label3.Text == "doc") || (label3.Text == "xls")) || (label3.Text == "ppt"))
                {
                    label2.Text = "<a href=\"javascript:void(0)\" onclick=\"OpenDisk('" + label5.Text + "');\">" + label.Text + "</a>";
                    str = str + "<a href=\"javascript:void(0)\" onclick=\"OpenDisk('" + label5.Text + "');\">阅读</a><br>";
                    if (this.TextBox1.Text == "1")
                    {
                        str = str + "<a href=\"/MyWebDiskdown.aspx?number=" + label6.Text + "\">下载</a><br>";
                    }
                    if (this.TextBox1.Text == "1")
                    {
                        str2 = str;
                        str = str2 + "<a href=\"MyWebDisk_update.aspx?id=" + label5.Text + "&typeid=" + label7.Text + "\">修改</a><br>";
                    }
                    str = ((str + "<a href=\"javascript:void(0)\" onclick=\"OpenSpyj(" + label5.Text + ");\">批注</a><br>") + "<a href=\"javascript:void(0)\" onclick=\"OpenSpyj(" + label5.Text + ");\">日志</a><br>") + "<a href=\"javascript:hideOperatorWin('div');\">关闭菜单</a>";
                }
                else
                {
                    if (this.TextBox1.Text == "1")
                    {
                        label2.Text = "<a href=\"/MyWebDiskdown.aspx?number=" + label6.Text + "\">" + label.Text + "</a>";
                    }
                    else
                    {
                        label2.Text = "" + label.Text + "";
                    }
                    if (this.TextBox1.Text == "1")
                    {
                        str = str + "<a href=\"/MyWebDiskdown.aspx?number=" + label6.Text + "\">下载</a><br>";
                    }
                    if (this.TextBox1.Text == "1")
                    {
                        str2 = str;
                        str = str2 + "<a href=\"MyWebDisk_update.aspx?id=" + label5.Text + "&typeid=" + label7.Text + "\">修改</a><br>";
                    }
                    str = ((str + "<a href=\"javascript:void(0)\" onclick=\"OpenSpyj(" + label5.Text + ");\">批注</a><br>") + "<a href=\"javascript:void(0)\" onclick=\"OpenSpyj(" + label5.Text + ");\">日志</a><br>") + "<a href=\"javascript:hideOperatorWin('div');\">关闭菜单</a>";
                }
                label4.Text = "<a href=\"javascript:void(0)\" onclick=\"showOperatorWin('div','" + label5.Text + "',85)\">操作</a><div class=\"caozuo\" id=\"div" + label5.Text + "\" style=\"left: 5px;width: 70px; top: 200px\"><div><div class=\"Operation\">" + str + "</div>/div></div>";
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
            string sql = "  Delete from qp_oa_MyWebDiskFile  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除文件[" + this.CheckCbxNameDel() + "]", "硬盘浏览");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyWebDisk_update.aspx?id=" + this.CheckCbxUpdate() + "&typeid=" + base.Request.QueryString["id"] + "");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyWebDisk_add.aspx?typeid=" + base.Request.QueryString["id"] + "");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyWebDisk_show_add.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string sql = "select ParentNodesID from qp_oa_WebDiskLx where (id=" + base.Request.QueryString["id"].ToString() + ")";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Redirect("MyWebDisk_show_update.aspx?id=" + base.Request.QueryString["id"] + "");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('没有找到此文件夹！');</script>");
                return;
            }
            list.Close();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            this.DelNode(base.Request.QueryString["id"], base.Request.QueryString["id"]);
            base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'MyWebDisk.aspx'</script>");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            string sql = "select ParentNodesID from qp_oa_WebDiskLx where (id=" + base.Request.QueryString["id"].ToString() + ")";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Redirect("MyWebDisk_show_qx.aspx?id=" + base.Request.QueryString["id"] + "");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('没有找到此文件夹！');</script>");
                return;
            }
            list.Close();
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            if (this.Folder.SelectedValue != "")
            {
                string str = this.CheckCbxDel();
                string sql = "select A.[OldName],A.[NewName],A.[Fjtype],A.[id] from [qp_oa_MyWebDiskFile] as [A] where A.ID in (" + str + ")";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    string str3 = string.Concat(new object[] { "insert into qp_oa_MyWebDiskLog  (KeyId,Username,Realname,SetTime,Contents,BuMenId) values ('", list["id"].ToString(), "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','转移文件','", this.Session["BuMenId"], "')" });
                    this.List.ExeSql(str3);
                    string str4 = "Update qp_oa_MyWebDiskFile  Set TypeId='" + this.Folder.SelectedValue + "' where ID ='" + list["id"].ToString() + "'";
                    this.List.ExeSql(str4);
                }
                list.Close();
                this.pulicss.InsertLog("转移文件[" + this.CheckCbxNameDel() + "]", "硬盘浏览");
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请选择对应文件夹！');</script>");
            }
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string str = random.Next(0x2710).ToString();
            string str2 = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
            base.Response.Redirect("SeadFile.aspx?id=" + this.CheckCbxDel() + "&Number=" + str2 + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListNothingDisk("[qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]", this.Folder, string.Concat(new object[] { " and ((B.[Types]='1' and nameid='1' and FLiulang='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FLiulang='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FLiulang='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FLiulang='1'))" }), " group by A.[Name],A.[id] order by A.id asc");
                this.BindAttribute();
                this.LinkButton8.Attributes["onclick"] = "javascript:return FolderMovecheck();";
                this.LinkButton5.Attributes["onclick"] = "javascript:return delf();";
                this.LinkButton9.Attributes["onclick"] = "javascript:return sendfile();";
                this.LinkButton10.Attributes["onclick"] = "javascript:return updatecheck();";
                string sql = "select name,SetRealname from qp_oa_WebDiskLx  where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Namefile.Text = list["name"].ToString();
                    this.CjName.Text = list["SetRealname"].ToString();
                }
                else
                {
                    this.Namefile.Text = "请点击左边目录";
                    this.CjName.Text = "请点击左边目录";
                }
                list.Close();
                this.Bindquanxian();
                string str2 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  where ((B.[Types]='1' and nameid='1' and BLiulang='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and BLiulang='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and BLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and BLiulang='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and BLiulang='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.GridView1.Visible = true;
                }
                else
                {
                    this.GridView1.Visible = false;
                }
                reader2.Close();
                string str3 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  where ((B.[Types]='1' and nameid='1' and BXinzeng='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and BXinzeng='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and BXinzeng='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and BXinzeng='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and BXinzeng='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader reader3 = this.List.GetList(str3);
                if (reader3.Read())
                {
                    this.LinkButton2.Visible = true;
                }
                else
                {
                    this.LinkButton2.Visible = false;
                }
                reader3.Close();
                string str4 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  where ((B.[Types]='1' and nameid='1' and BXiugai='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and BXiugai='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and BXiugai='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and BXiugai='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and BXiugai='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader reader4 = this.List.GetList(str4);
                if (reader4.Read())
                {
                    this.LinkButton10.Visible = true;
                    this.LinkButton8.Visible = true;
                    this.LinkButton9.Visible = true;
                    this.Label1.Visible = true;
                    this.Folder.Visible = true;
                    this.TextBox1.Text = "1";
                }
                else
                {
                    this.LinkButton10.Visible = false;
                    this.LinkButton8.Visible = false;
                    this.LinkButton9.Visible = false;
                    this.Label1.Visible = false;
                    this.Folder.Visible = false;
                    this.TextBox1.Text = "0";
                }
                reader4.Close();
                string str5 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  where ((B.[Types]='1' and nameid='1' and BShanchu='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and BShanchu='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and BShanchu='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and BShanchu='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and BShanchu='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader reader5 = this.List.GetList(str5);
                if (reader5.Read())
                {
                    this.LinkButton1.Visible = true;
                }
                else
                {
                    this.LinkButton1.Visible = false;
                }
                reader5.Close();
                string str6 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  where ((B.[Types]='1' and nameid='1' and FXinzeng='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FXinzeng='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FXinzeng='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FXinzeng='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FXinzeng='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader reader6 = this.List.GetList(str6);
                if (reader6.Read())
                {
                    this.LinkButton3.Visible = true;
                }
                else
                {
                    this.LinkButton3.Visible = false;
                }
                reader6.Close();
                string str7 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  where ((B.[Types]='1' and nameid='1' and FXiugai='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FXiugai='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FXiugai='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FXiugai='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FXiugai='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader reader7 = this.List.GetList(str7);
                if (reader7.Read())
                {
                    this.LinkButton4.Visible = true;
                }
                else
                {
                    this.LinkButton4.Visible = false;
                }
                reader7.Close();
                string str8 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  where ((B.[Types]='1' and nameid='1' and FShanchu='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FShanchu='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FShanchu='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FShanchu='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FShanchu='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader reader8 = this.List.GetList(str8);
                if (reader8.Read())
                {
                    this.LinkButton5.Visible = true;
                }
                else
                {
                    this.LinkButton5.Visible = false;
                }
                reader8.Close();
                string str9 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  where ((B.[Types]='1' and nameid='1' and FQuanXian='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FQuanXian='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FQuanXian='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FQuanXian='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FQuanXian='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader reader9 = this.List.GetList(str9);
                if (reader9.Read())
                {
                    this.LinkButton6.Visible = true;
                }
                else
                {
                    this.LinkButton6.Visible = false;
                }
                reader9.Close();
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


namespace xyoa.OfficeMenu.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRenwu_show : Page
    {
        protected Label Benbi;
        protected TextBox BenbiXg;
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Button Button6;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected Label Content;
        protected Label Endtime;
        protected HtmlForm form1;
        protected Label fujian;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected Label Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected Label Realname1;
        protected Label SetTime;
        protected Label Starttime;
        protected Label State;
        protected TextBox taolun;
        protected Label titles;
        protected TextBox Username;
        protected Label WcTime;
        protected GridView XieBanUser;
        protected Label YdRealname;
        protected Label ZbRealname;
        protected DropDownList ZhuangtaiXg;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('5','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyRenwu.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_Renwu  Set WcTime='", DateTime.Now.ToString(), "',State='", this.ZhuangtaiXg.SelectedValue, "',Benbi='", this.BenbiXg.Text, "' where id='", int.Parse(base.Request.QueryString["id"]), "' and ZbUsername='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "select * from qp_oa_Renwu  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (ZbUsername='", this.Session["username"], "' or (CHARINDEX(',", this.Session["username"], ",',','+JbUsername+',')   >   0 ))" });
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                this.WcTime.Text = list["WcTime"].ToString().ToString().Replace("2000-01-01", "--").Replace("2000-1-1", "--").Replace("0:00:00", "");
                this.Number.Text = list["Number"].ToString();
                this.titles.Text = list["titles"].ToString();
                this.Starttime.Text = list["Starttime"].ToString();
                this.Endtime.Text = list["Endtime"].ToString();
                this.ZbRealname.Text = list["ZbRealname"].ToString();
                this.ViewState["ZbUsername"] = list["ZbUsername"].ToString();
                this.Leixing.Text = this.pulicss.TypeCode("qp_oa_RenwuLx", list["Leixing"].ToString());
                this.Content.Text = list["Content"].ToString();
                this.Realname1.Text = list["Realname"].ToString();
                this.SetTime.Text = list["SetTime"].ToString();
                this.Benbi.Text = list["Benbi"].ToString();
                this.State.Text = list["State"].ToString().Replace("1", "进行中").Replace("2", "已暂停").Replace("3", "强行停止").Replace("4", "已完成");
                this.BenbiXg.Text = list["Benbi"].ToString();
                this.ZhuangtaiXg.SelectedValue = list["State"].ToString();
            }
            list.Close();
            this.pulicss.GetFile(this.Number.Text, this.fujian);
            this.DataBindToGridview();
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button3.Attributes["onclick"] = "javascript:return chknullxg();";
            if (this.ViewState["ZbUsername"].ToString() == this.Session["username"].ToString())
            {
                this.Panel1.Visible = true;
                this.CheckBox2.Visible = true;
            }
            else
            {
                this.Panel1.Visible = false;
                this.CheckBox2.Visible = false;
            }
            if (this.State.Text == "已完成")
            {
                try
                {
                    TimeSpan span = (TimeSpan) (DateTime.Parse(this.Endtime.Text) - DateTime.Parse(this.WcTime.Text));
                    string str3 = "" + span.TotalSeconds + "";
                    if (span.TotalSeconds >= 0.0)
                    {
                        this.Label1.Text = "提前： " + this.pulicss.ShowDateTime(double.Parse(str3.Replace("-", ""))) + "";
                    }
                    else
                    {
                        this.Label1.Text = "超时： " + this.pulicss.ShowDateTime(double.Parse(str3.Replace("-", ""))) + "";
                    }
                }
                catch
                {
                }
                this.Panel1.Visible = false;
                this.CheckBox2.Visible = false;
            }
            this.CheckBox2.Checked = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (this.Username.Text == "")
            {
                base.Response.Write("<script language=javascript>alert('添加协办人不能为空！');</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select id from qp_oa_RenwuXb where Keyid='", int.Parse(base.Request.QueryString["id"]), "' and Username='", this.Username.Text, "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    base.Response.Write("<script language=javascript>alert('任务中已经存在此协办人人！');</script>");
                }
                else
                {
                    list.Close();
                    string str2 = string.Concat(new object[] { "insert into qp_oa_RenwuXb (Keyid,Username,Realname,Zhuangtai,Neirong,Baifenbi) values ('", int.Parse(base.Request.QueryString["id"]), "','", this.Username.Text, "','", this.Realname.Text, "','1','','0')" });
                    this.List.ExeSql(str2);
                    string str3 = string.Concat(new object[] { "Update qp_oa_Renwu  Set  JbUsername=JbUsername+'", this.Username.Text, ",',JbRealname=JbRealname+'", this.Realname.Text, ",'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                    this.List.ExeSql(str3);
                    this.DataBindToGridviewXb();
                }
            }
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='5'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='5' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView1.DataBind();
        }

        public void DataBindToGridviewXb()
        {
            this.XieBanUser.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select * from qp_oa_RenwuXb where Keyid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.XieBanUser.DataSource = this.List.GetGrid_Pages_not(sql);
            this.XieBanUser.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.DataBindToGridview();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "Delete from qp_oa_Taolun where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                Label label = (Label) e.Row.FindControl("FTUsername");
                if ((label.Text == this.Session["username"].ToString()) || (this.Session["username"].ToString() == "admin"))
                {
                    button.Visible = true;
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除此条讨论记录吗？')");
                }
                else
                {
                    button.Visible = false;
                }
            }
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
                    string sql = string.Concat(new object[] { "select * from qp_oa_Renwu  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (ZbUsername='", this.Session["username"], "' or (CHARINDEX(',", this.Session["username"], ",',','+JbUsername+',')   >   0 ))" });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.WcTime.Text = list["WcTime"].ToString().ToString().Replace("2000-01-01", "--").Replace("2000-1-1", "--").Replace("0:00:00", "");
                        this.Number.Text = list["Number"].ToString();
                        this.titles.Text = list["titles"].ToString();
                        this.Starttime.Text = list["Starttime"].ToString();
                        this.Endtime.Text = list["Endtime"].ToString();
                        this.ZbRealname.Text = list["ZbRealname"].ToString();
                        this.ViewState["ZbUsername"] = list["ZbUsername"].ToString();
                        this.Leixing.Text = this.pulicss.TypeCode("qp_oa_RenwuLx", list["Leixing"].ToString());
                        this.Content.Text = list["Content"].ToString();
                        this.Realname1.Text = list["Realname"].ToString();
                        this.SetTime.Text = list["SetTime"].ToString();
                        this.Benbi.Text = list["Benbi"].ToString();
                        this.State.Text = list["State"].ToString().Replace("1", "进行中").Replace("2", "已暂停").Replace("3", "强行停止").Replace("4", "已完成");
                        this.BenbiXg.Text = list["Benbi"].ToString();
                        this.ZhuangtaiXg.SelectedValue = list["State"].ToString();
                        this.YdRealname.Text = list["YdRealname"].ToString();
                    }
                    list.Close();
                    this.pulicss.GetFile(this.Number.Text, this.fujian);
                    this.DataBindToGridview();
                    this.Button1.Attributes["onclick"] = "javascript:return chknull();";
                    this.Button3.Attributes["onclick"] = "javascript:return chknullxg();";
                    if (this.ViewState["ZbUsername"].ToString() == this.Session["username"].ToString())
                    {
                        this.Panel1.Visible = true;
                        this.CheckBox2.Visible = true;
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                        this.CheckBox2.Visible = false;
                    }
                    if (this.State.Text == "已完成")
                    {
                        try
                        {
                            TimeSpan span = (TimeSpan) (DateTime.Parse(this.Endtime.Text) - DateTime.Parse(this.WcTime.Text));
                            string str2 = "" + span.TotalSeconds + "";
                            if (span.TotalSeconds >= 0.0)
                            {
                                this.Label1.Text = "提前： " + this.pulicss.ShowDateTime(double.Parse(str2.Replace("-", ""))) + "";
                            }
                            else
                            {
                                this.Label1.Text = "超时： " + this.pulicss.ShowDateTime(double.Parse(str2.Replace("-", ""))) + "";
                            }
                        }
                        catch
                        {
                        }
                        this.Panel1.Visible = false;
                        this.CheckBox2.Visible = false;
                    }
                }
                this.DataBindToGridviewXb();
            }
        }

        protected void XieBanUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "select Username,Realname from qp_oa_RenwuXb where id='" + num + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = "  Delete from qp_oa_RenwuXb where ID='" + num + "'";
                    this.List.ExeSql(str2);
                    string str3 = string.Concat(new object[] { "Update qp_oa_Renwu  Set  JbUsername=replace(JbUsername,'", list["username"], ",',''),JbRealname=replace(JbRealname,'", list["Realname"], ",','')  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                    this.List.ExeSql(str3);
                }
                list.Close();
                this.DataBindToGridviewXb();
            }
        }

        protected void XieBanUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                if (this.ViewState["ZbUsername"].ToString() == this.Session["username"].ToString())
                {
                    if (this.State.Text == "已完成")
                    {
                        button.Enabled = false;
                    }
                    else
                    {
                        button.Enabled = true;
                        button.Attributes.Add("onclick", "javascript:return confirm('确认删除此协办人[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                    }
                }
                else
                {
                    button.Enabled = false;
                }
                Label label = (Label) e.Row.FindControl("Username");
                LinkButton button2 = (LinkButton) e.Row.FindControl("XiuGai");
                if (label.Text == this.Session["username"].ToString())
                {
                    if (this.State.Text == "已完成")
                    {
                        button2.Enabled = false;
                    }
                    else
                    {
                        button2.Enabled = true;
                        button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('MyRenwu_show_xb.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "','window','dialogWidth:680px;DialogHeight=380px;status:no;help=no;scroll=no');window.location='#'");
                    }
                }
                else
                {
                    button2.Enabled = false;
                }
            }
        }
    }
}


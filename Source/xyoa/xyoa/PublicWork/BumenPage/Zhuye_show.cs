﻿namespace xyoa.PublicWork.BumenPage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Zhuye_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected CheckBox CheckBox1;
        protected Label Contents;
        public string fjkey;
        protected HtmlForm form1;
        protected Label fujian;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Button sc;
        protected Label Settime;
        protected TextBox taolun;
        protected Label titles;
        protected Label WzLeibie;
        protected Label YdRealname;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('10','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["key"] == "1")
            {
                base.Response.Redirect("Zhuye.aspx");
            }
            if (base.Request.QueryString["key"] == "2")
            {
                base.Response.Redirect("Zhuye_list.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["ZhuyeId"]) + "");
            }
            if (base.Request.QueryString["key"] == "3")
            {
                base.Response.Redirect("Zhuye_lb_list.aspx?WzLeibie=" + this.pulicss.GetFormatStr(base.Request.QueryString["WzLeibie"]) + "&ZhuyeId=" + this.pulicss.GetFormatStr(base.Request.QueryString["ZhuyeId"]) + "");
            }
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='10'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='10' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView1.DataBind();
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
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除此条讨论信息吗？')");
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
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select id from qp_oa_BumenWz where id='", base.Request.QueryString["id"], "' and  CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   >0" });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    string str2 = string.Concat(new object[] { "Update qp_oa_BumenWz   Set YdUsername=YdUsername+'", this.Session["username"], ",',YdRealname=YdRealname+'", this.Session["realname"], "(", DateTime.Now.ToString(), "),'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                    this.List.ExeSql(str2);
                }
                list.Close();
                string str3 = string.Concat(new object[] { "select A.*,B.[Name] as BuMenName from [qp_oa_BumenWz] as [A] inner join [qp_oa_BumenZy] as [C] on [A].[ZhuyeId] = [C].[Id] inner join [qp_oa_Bumen] as [B] on [C].[BuMenId] = [B].[Id] where ((CHARINDEX(',", this.Session["BuMenId"], ",',','+C.ZdBumenId1+',') > 0 and C.States1='2') or (CHARINDEX(',", this.Session["username"], ",',','+C.ZdUsername1+',') > 0 and C.States1='3') or (C.States1='1'))  and  A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'  " });
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    this.ViewState["BuMenName"] = reader2["BuMenName"].ToString();
                    this.Number.Text = reader2["Number"].ToString();
                    this.titles.Text = reader2["titles"].ToString();
                    this.Contents.Text = reader2["Content"].ToString();
                    this.Realname.Text = reader2["Realname"].ToString();
                    this.Settime.Text = reader2["Settime"].ToString();
                    this.YdRealname.Text = reader2["YdRealname"].ToString();
                    string str4 = "select Leixing from qp_oa_BumenWzLb  where id='" + reader2["WzLeibie"].ToString() + "'  ";
                    SqlDataReader reader3 = this.List.GetList(str4);
                    if (reader3.Read())
                    {
                        this.WzLeibie.Text = reader3["Leixing"].ToString();
                    }
                    reader3.Close();
                    string str5 = "," + reader2["ScUsername"].ToString() + ",";
                    string str6 = "," + this.Session["username"].ToString() + ",";
                    if (str5.IndexOf(str6) < 0)
                    {
                        this.sc.Enabled = true;
                        this.sc.Text = "收 藏";
                    }
                    else
                    {
                        this.sc.Enabled = false;
                        this.sc.Text = "已收藏";
                    }
                }
                else
                {
                    reader2.Close();
                    base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location.href='Zhuye.aspx'</script>");
                }
                reader2.Close();
                this.DataBindToGridview();
                this.BindAttribute();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                this.pulicss.InsertLog("查看文章", "部门主页");
            }
        }

        protected void sc_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_BumenWz  Set ScUsername=ScUsername+'", this.Session["username"], ",' where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            this.sc.Enabled = false;
            this.sc.Text = "已收藏";
        }
    }
}

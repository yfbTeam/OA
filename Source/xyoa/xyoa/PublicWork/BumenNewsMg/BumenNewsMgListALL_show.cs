﻿namespace xyoa.PublicWork.BumenNewsMg
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenNewsMgListALL_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected Label Contents;
        protected HtmlForm form1;
        protected Label FqBumen;
        protected Label fujian;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox taolun;
        protected Label titles;

        public void BindAttribute()
        {
            this.pulicss.QuanXianBack("jjjj3a", this.Session["perstr"].ToString());
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('1','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("BumenNewsMgListALL.aspx");
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='1'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='1' order by id desc";
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
                string sql = "select * from qp_oa_BumenNewsMg  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.FqBumen.Text = list["FqBumen"].ToString();
                    this.titles.Text = list["titles"].ToString();
                    this.Contents.Text = list["Content"].ToString();
                    string str2 = "," + this.Session["Username"].ToString() + ",";
                    if (("," + list["YdUsername"].ToString() + ",").IndexOf(str2) < 0)
                    {
                        string str4 = string.Concat(new object[] { "Update qp_oa_BumenNewsMg   Set YdUsername=YdUsername+'", this.Session["username"], ",',YdRealname=YdRealname+'", this.Session["realname"], "(", DateTime.Now.ToString(), "),'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                        this.List.ExeSql(str4);
                        string str5 = string.Concat(new object[] { "Update qp_oa_BumenNewsMgYd   Set Yuedu='1',YdTime='", DateTime.Now.ToString(), "'  where Number='", this.Number.Text, "' and Username='", this.Session["Username"], "'" });
                        this.List.ExeSql(str5);
                    }
                }
                list.Close();
                this.DataBindToGridview();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                this.pulicss.InsertLog("查看通知公告", "通知公告");
                this.BindAttribute();
            }
        }
    }
}


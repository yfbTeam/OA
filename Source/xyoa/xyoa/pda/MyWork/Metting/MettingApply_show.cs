﻿namespace xyoa.pda.MyWork.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingApply_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox2;
        protected Label CjRealname;
        protected Label Endtime;
        protected HtmlForm form1;
        protected Label fujian;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Introduction;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label MettingName;
        protected Label Name;
        protected Label NbPeopleName;
        protected TextBox NbPeopleUser;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Remark;
        protected Label Starttime;
        protected Label State;
        protected TextBox taolun;
        protected Label WbPeople;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyMetting.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('6','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='6'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='6' order by id desc";
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
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button2.Attributes["onclick"] = "javascript:return chknull();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = "select * from qp_oa_MettingApply   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CjRealname.Text = list["CjRealname"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.Introduction.Text = this.pulicss.TbToLb(list["Introduction"].ToString());
                    this.WbPeople.Text = list["WbPeople"].ToString();
                    this.NbPeopleUser.Text = list["NbPeopleUser"].ToString();
                    this.NbPeopleName.Text = list["NbPeopleName"].ToString();
                    this.MettingName.Text = list["MettingName"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                    this.pulicss.GetFileSj(this.Number.Text, this.fujian);
                    this.State.Text = list["State"].ToString().Replace("6", "通过审批").Replace("1", "正在审批").Replace("2", "已发起").Replace("3", "进行中").Replace("4", "结束").Replace("5", "终止");
                }
                list.Close();
                this.DataBindToGridview();
            }
        }
    }
}

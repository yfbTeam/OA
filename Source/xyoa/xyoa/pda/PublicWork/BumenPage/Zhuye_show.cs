namespace xyoa.pda.PublicWork.BumenPage
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
        protected CheckBox CheckBox2;
        protected Label Contents;
        protected HtmlForm form1;
        protected Label fujian;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Settime;
        protected TextBox taolun;
        protected Label titles;
        protected Label WzLeibie;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Zhuye.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('10','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
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
                    string str4 = "select Leixing from qp_oa_BumenWzLb  where id='" + reader2["WzLeibie"].ToString() + "'  ";
                    SqlDataReader reader3 = this.List.GetList(str4);
                    if (reader3.Read())
                    {
                        this.WzLeibie.Text = reader3["Leixing"].ToString();
                    }
                    reader3.Close();
                }
                else
                {
                    reader2.Close();
                    base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location.href='Zhuye.aspx'</script>");
                }
                reader2.Close();
                this.pulicss.GetFileSj(this.Number.Text, this.fujian);
                this.DataBindToGridview();
            }
        }
    }
}


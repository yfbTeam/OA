namespace xyoa.pda.InfoManage.filesend
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class JsInfoSend_show : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected ImageButton ImageButton1;
        protected Label JsRealname;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Name;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Settime;
        protected TextBox taolun;
        protected Label Username;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("JsInfoSend.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('12','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='12'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='12' order by id desc";
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("InfoSend_add.aspx?Username=" + this.Username.Text + "&Realname=" + this.Realname.Text + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ImageButton1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button2.Attributes["onclick"] = "javascript:return chknull();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = string.Concat(new object[] { "select * from qp_oa_InfoSend  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and CHARINDEX(',", this.Session["username"], ",',','+JsUsername+',') > 0" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Username.Text = list["Username"].ToString();
                    this.Settime.Text = list["Settime"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.JsRealname.Text = list["JsRealname"].ToString();
                    this.Name.Text = "<img src=\"/oaimg/filetype/" + list["Filetype"].ToString() + ".gif\" /><a href='/" + list["Newname"].ToString() + "' target=_blank>" + list["Name"].ToString() + "</a>";
                }
                list.Close();
                string str2 = string.Concat(new object[] { "select * from qp_oa_InfoSend where id='", base.Request.QueryString["id"], "' and  CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   >0" });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (!reader2.Read())
                {
                    string str3 = string.Concat(new object[] { "Update qp_oa_InfoSend   Set YdUsername=YdUsername+'", this.Session["username"], ",',YdRealname=YdRealname+'", this.Session["realname"], "(", DateTime.Now.ToString(), "),',JsRealname=replace(JsRealname,'", this.Session["realname"].ToString(), "','<font color=\"blue\">", this.Session["realname"].ToString(), "(", DateTime.Now.ToString(), ")</font>')  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                    this.List.ExeSql(str3);
                }
                reader2.Close();
                this.DataBindToGridview();
            }
        }
    }
}


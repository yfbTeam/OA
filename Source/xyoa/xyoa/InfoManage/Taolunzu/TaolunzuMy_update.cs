namespace xyoa.InfoManage.Taolunzu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TaolunzuMy_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected GridView GridView2;
        protected HtmlHead Head1;
        protected RadioButtonList Leixing;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected DropDownList States;
        protected TextBox Username;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;
        protected RadioButtonList Zhuangtai;

        public void BindAttribute()
        {
            this.Realname.Attributes.Add("readonly", "readonly");
            this.Button3.Attributes["onclick"] = "javascript:return chksyr();";
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_Taolunzu  Set  Leixing='", this.Leixing.SelectedValue, "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Zhuangtai='", this.Zhuangtai.SelectedValue, "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, 
                "',Paixun='", this.Paixun.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改讨论组", "讨论组");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='TaolunzuMy.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("TaolunzuMy.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_TaolunzuRy where Keyid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Username='" + this.Username.Text + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('此用户已经存在！');</script>");
            }
            else
            {
                list.Close();
                string str2 = "insert into qp_oa_TaolunzuRy  (Keyid,Username,Realname,Settime,Tixing,IfTixing,Weidu) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.Username.Text + "','" + this.Realname.Text + "','" + DateTime.Now.ToString() + "','1','0','0')";
                this.List.ExeSql(str2);
                this.DataBindToGridview("order by id asc");
            }
        }

        public void DataBindToGridview(string Sqlsort)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select * from qp_oa_TaolunzuRy where Keyid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        public void DataBindToGridview1()
        {
            string sql = "select * from qp_oa_TaolunzuSq where Keyid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.GridView2.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView2.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "  Delete from qp_oa_TaolunzuRy where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview("order by id asc");
            }
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
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                button.Attributes.Add("onclick", "javascript:return confirm('确认删除[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
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
            this.DataBindToGridview(sqlsort);
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int num;
            string str3;
            if (e.CommandName == "Tongyi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                string sql = "select * from qp_oa_TaolunzuSq  where ID='" + num + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = string.Concat(new object[] { "insert into qp_oa_TaolunzuRy  (Keyid,Username,Realname,Settime,Tixing,IfTixing,Weidu) values ('", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "','", list["username"], "','", list["realname"], "','", DateTime.Now.ToString(), "','1','0','0')" });
                    this.List.ExeSql(str2);
                    this.pulicss.InsertMessage("已同意加入讨论组：" + this.Name.Text + "", list["username"].ToString(), list["realname"].ToString(), "/InfoManage/Taolunzu/TaolunzuLogin.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
                }
                list.Close();
                str3 = "  Delete from qp_oa_TaolunzuSq where ID='" + num + "'";
                this.List.ExeSql(str3);
                this.DataBindToGridview1();
                this.DataBindToGridview("order by id asc");
            }
            if (e.CommandName == "Jujue")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str3 = "  Delete from qp_oa_TaolunzuSq where ID='" + num + "'";
                this.List.ExeSql(str3);
                this.DataBindToGridview1();
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("Tongyi");
                button.Attributes.Add("onclick", "javascript:return confirm('确认同意[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("Jujue");
                button2.Attributes.Add("onclick", "javascript:return confirm('确认拒绝[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
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
                string sql = string.Concat(new object[] { "select * from qp_oa_Taolunzu  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                }
                list.Close();
                this.DataBindToGridview("order by id asc");
                this.DataBindToGridview1();
                this.BindAttribute();
            }
        }
    }
}


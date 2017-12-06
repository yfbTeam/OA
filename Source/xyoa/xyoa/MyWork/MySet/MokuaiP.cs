namespace xyoa.MyWork.MySet
{
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MokuaiP : Page
    {
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void DataBindToGridview(string Sqlsort)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = string.Concat(new object[] { "select A.* from [qp_oa_MyUrl] as [A] where Username='", this.Session["username"], "' and A.menhu='", base.Request.QueryString["menhu"], "' ", Sqlsort, "" });
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int num;
            string str;
            SqlDataReader list;
            string str2;
            string str3;
            if (e.CommandName == "shangyi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = string.Concat(new object[] { "select top 1 * from qp_oa_MyUrl where Paixun<", num.ToString(), "  and Username='", this.Session["Username"], "'and menhu='", base.Request.QueryString["menhu"], "' order by paixun desc" });
                list = this.List.GetList(str);
                if (list.Read())
                {
                    str2 = "Update qp_oa_MyUrl  Set Paixun='" + list["PaiXun"].ToString() + "'  where Paixun='" + num.ToString() + "'";
                    this.List.ExeSql(str2);
                    str3 = "Update qp_oa_MyUrl  Set Paixun='" + num.ToString() + "'  where id='" + list["id"].ToString() + "'";
                    this.List.ExeSql(str3);
                }
                else
                {
                    base.Response.Write("<script language='javascript'>alert('已经达到最底部，移动失败！');</script>");
                }
                list.Close();
            }
            if (e.CommandName == "xiayi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = string.Concat(new object[] { "select top 1 * from qp_oa_MyUrl where Paixun>", num.ToString(), "  and Username='", this.Session["Username"], "' and menhu='", base.Request.QueryString["menhu"], "'  order by paixun asc" });
                list = this.List.GetList(str);
                if (list.Read())
                {
                    str2 = "Update qp_oa_MyUrl  Set Paixun='" + list["PaiXun"].ToString() + "'  where Paixun='" + num.ToString() + "'";
                    this.List.ExeSql(str2);
                    str3 = "Update qp_oa_MyUrl  Set Paixun='" + num.ToString() + "'  where id='" + list["id"].ToString() + "'";
                    this.List.ExeSql(str3);
                }
                else
                {
                    base.Response.Write("<script language='javascript'>alert('已经达到最顶部，移动失败！');</script>");
                }
                list.Close();
            }
            this.DataBindToGridview("order by Paixun desc");
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
                button.Attributes.Add("onclick", "javascript:return showwait();");
                LinkButton button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                button2.Attributes.Add("onclick", "javascript:return showwait();");
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("leixing");
                Label label3 = (Label) e.Row.FindControl("lanmu");
                if (label2.Text == "1")
                {
                    string sql = "select B.[urlname] from qp_oa_AllUrl as [B] where  [B].[Id]='" + label.Text + "' and (CHARINDEX(''+B.quanxian+'','" + this.ViewState["qxstr"].ToString() + "')   >   0 )   and B.xianshi='1'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        label3.Text = "" + list["urlname"] + "";
                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                    list.Close();
                }
                else if (label2.Text == "2")
                {
                    string str2 = string.Concat(new object[] { "select B.[name] from qp_oa_OtherMenu as [B] where  [B].[Id]='", label.Text, "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        label3.Text = "" + reader2["name"] + "";
                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                    reader2.Close();
                }
                else if (label2.Text == "3")
                {
                    string str3 = string.Concat(new object[] { "select B.[name] from qp_oa_Menhu as [B] where  [B].[Id]='", label.Text, "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                    SqlDataReader reader3 = this.List.GetList(str3);
                    if (reader3.Read())
                    {
                        label3.Text = "" + reader3["name"] + "";
                    }
                    else
                    {
                        e.Row.Visible = false;
                    }
                    reader3.Close();
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
                this.ViewState["qxstr"] = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
                this.DataBindToGridview("order by Paixun desc");
            }
        }
    }
}


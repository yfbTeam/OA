namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DeskMould : Page
    {
        protected Button AddData;
        protected Button DelData;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("DeskMould_add.aspx");
        }

        public void BindAttribute()
        {
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
            this.DelData.Attributes["onclick"] = "javascript:return delcheck();";
        }

        public void Bindquanxian()
        {
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

        public void DataBindToGridview(string Sqlsort)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = string.Concat(new object[] { "select   * from qp_oa_DIYMould where username='", this.Session["username"], "' and  CHARINDEX((select quanxian from qp_oa_AllUrl where id=qp_oa_DIYMould.KeyId),'", this.Session["perstr"], "') > 0 ", Sqlsort, "" });
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void DelData_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "  Delete from qp_oa_DIYMould  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除工作台模块设置", "工作台模块设置");
            this.DataBindToGridview("order by PaiXun asc");
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
                str = string.Concat(new object[] { "select top 1 * from qp_oa_DIYMould where Paixun<", num.ToString(), "  and Username='", this.Session["Username"], "' and  CHARINDEX((select quanxian from qp_oa_AllUrl where id=qp_oa_DIYMould.KeyId),'", this.Session["perstr"], "') > 0  order by paixun desc" });
                list = this.List.GetList(str);
                if (list.Read())
                {
                    str2 = "Update qp_oa_DIYMould  Set Paixun='" + list["PaiXun"].ToString() + "'  where Paixun='" + num.ToString() + "'";
                    this.List.ExeSql(str2);
                    str3 = "Update qp_oa_DIYMould  Set Paixun='" + num.ToString() + "'  where id='" + list["id"].ToString() + "'";
                    this.List.ExeSql(str3);
                }
                else
                {
                    base.Response.Write("<script language='javascript'>alert('已经达到最顶部，移动失败！');</script>");
                }
                list.Close();
            }
            if (e.CommandName == "xiayi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = string.Concat(new object[] { "select top 1 * from qp_oa_DIYMould where Paixun>", num.ToString(), "  and Username='", this.Session["Username"], "' and  CHARINDEX((select quanxian from qp_oa_AllUrl where id=qp_oa_DIYMould.KeyId),'", this.Session["perstr"], "') > 0  order by paixun asc" });
                list = this.List.GetList(str);
                if (list.Read())
                {
                    str2 = "Update qp_oa_DIYMould  Set Paixun='" + list["PaiXun"].ToString() + "'  where Paixun='" + num.ToString() + "'";
                    this.List.ExeSql(str2);
                    str3 = "Update qp_oa_DIYMould  Set Paixun='" + num.ToString() + "'  where id='" + list["id"].ToString() + "'";
                    this.List.ExeSql(str3);
                }
                else
                {
                    base.Response.Write("<script language='javascript'>alert('已经达到最底部，移动失败！');</script>");
                }
                list.Close();
            }
            this.DataBindToGridview("order by PaiXun asc");
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
                this.BindAttribute();
                this.DataBindToGridview("order by Paixun asc");
                this.Bindquanxian();
            }
        }
    }
}


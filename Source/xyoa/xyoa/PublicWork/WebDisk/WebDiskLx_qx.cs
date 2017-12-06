namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WebDiskLx_qx : Page
    {
        protected Button Button2;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected GridView GridView2;
        protected GridView GridView3;
        protected GridView GridView4;
        protected HtmlHead Head1;
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected LinkButton LinkButton3;
        protected LinkButton LinkButton4;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected TextBox ZdBumenId;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.Name.Attributes.Add("readonly", "readonly");
            this.Paixun.Attributes.Add("readonly", "readonly");
            this.LinkButton1.Attributes["onclick"] = "javascript:return openqx1();";
            this.LinkButton2.Attributes["onclick"] = "javascript:return openqx2();";
            this.LinkButton3.Attributes["onclick"] = "javascript:return openqx3();";
            this.LinkButton4.Attributes["onclick"] = "javascript:return openqx4();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.pulicss.InsertLog("设置硬盘目录权限", "网络硬盘目录");
            base.Response.Write("<script language=javascript>window.location.href='WebDiskLx.aspx'</script>");
        }

        public void DataBindToGridview(string Sqlsort)
        {
            string sql = "select * from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Types='1' " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str2 = "select * from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Types='2' " + Sqlsort + "";
            this.GridView2.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView2.DataBind();
            string str3 = "select * from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Types='3' " + Sqlsort + "";
            this.GridView3.DataSource = this.List.GetGrid_Pages_not(str3);
            this.GridView3.DataBind();
            string str4 = "select * from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Types='4' " + Sqlsort + "";
            this.GridView4.DataSource = this.List.GetGrid_Pages_not(str4);
            this.GridView4.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView2.PageIndex = e.NewPageIndex;
            this.GridView3.PageIndex = e.NewPageIndex;
            this.GridView4.PageIndex = e.NewPageIndex;
            this.DataBindToGridview("order by id desc");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "delete from qp_oa_WebDiskLxQx where id='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview("order by id desc");
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
                LinkButton button;
                LinkButton button2;
                if ((e.Row.Cells[0].Text.ToString() == "系统管理员") || (e.Row.Cells[0].Text.ToString() == "创建人"))
                {
                    button = (LinkButton) e.Row.FindControl("ShanChu");
                    button2 = (LinkButton) e.Row.FindControl("XiuGai");
                    button.Enabled = false;
                    button2.Enabled = false;
                }
                else
                {
                    button = (LinkButton) e.Row.FindControl("ShanChu");
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除[" + e.Row.Cells[0].Text.ToString() + "]吗')");
                    button2 = (LinkButton) e.Row.FindControl("XiuGai");
                    button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('WebDiskLx_qx_update.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "&KeyId=" + base.Request.QueryString["id"] + "','window','dialogWidth:680px;DialogHeight=280px;status:no;help=no;scroll=no');window.location='#'");
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
                    this.pulicss.QuanXianBack("jjjja1c", this.Session["perstr"].ToString());
                    string sql = "select * from qp_oa_WebDiskLx  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Name.Text = list["Name"].ToString();
                        this.Paixun.Text = list["Paixun"].ToString();
                    }
                    list.Close();
                    this.BindAttribute();
                }
                this.DataBindToGridview("order by id desc");
            }
        }
    }
}


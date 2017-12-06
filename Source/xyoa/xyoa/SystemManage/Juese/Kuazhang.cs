namespace xyoa.SystemManage.Juese
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Kuazhang : Page
    {
        protected DropDownList Banmian;
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox ZdBumenId;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.ViewState["s_id"] = "";
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("quanbu");
                Label label = (Label) row.FindControl("quanbuid");
                if (box.Checked)
                {
                    StateBag bag = ViewState;
                    object obj2 = bag["s_id"];
                    (bag = this.ViewState)["s_id"] = string.Concat(new object[] { obj2, "", label.Text, "," });
                }
            }
            string sql = string.Concat(new object[] { "Update qp_oa_Juese  Set Kz='", this.Banmian.SelectedValue, "',KzBanmian='", this.ViewState["s_id"].ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改角色管理", "角色管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Juese.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Juese.aspx");
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select id,name from qp_oa_OtherMenu order by Paixun asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
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
                string sql = "select Kz,KzBanmian from qp_oa_Juese where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Banmian.SelectedValue = list["Kz"].ToString();
                    this.ViewState["PerSessionStr"] = list["KzBanmian"].ToString();
                }
                list.Close();
                this.DataBindToGridview();
                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    GridViewRow row = this.GridView1.Rows[i];
                    CheckBox box = (CheckBox) row.FindControl("quanbu");
                    Label label = (Label) row.FindControl("quanbuid");
                    if (this.pulicss.StrIFInStr("," + label.Text + ",", "," + this.ViewState["PerSessionStr"].ToString() + ","))
                    {
                        box.Checked = true;
                    }
                }
            }
        }
    }
}


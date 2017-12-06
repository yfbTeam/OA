namespace xyoa.SystemManage.Menhu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Menhu_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox name;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StateBag bag = ViewState;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("quanbu");
                Label label = (Label) row.FindControl("quanbuid");
                if (box.Checked)
                {
                    object obj2 = bag["s_id"];
                    (bag = this.ViewState)["s_id"] = string.Concat(new object[] { obj2, "", label.Text, "," });
                }
            }
            (bag = this.ViewState)["s_id"] = bag["s_id"] + "0";
            string sql = string.Concat(new object[] { 
                "Update qp_oa_Menhu  Set Lmid='", this.ViewState["s_id"], "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',name='", this.pulicss.GetFormatStr(this.name.Text), "',Paixun='", this.Paixun.Text, 
                "'   where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改门户中心", "门户中心");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Menhu.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Menhu.aspx");
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select id,ParentNodesID,urlname from qp_oa_AllUrl where menhulm='1'  order by paixu asc";
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("ParentNodesID");
                Label label2 = (Label) e.Row.FindControl("Label1");
                CheckBox box = (CheckBox) e.Row.FindControl("quanbu");
                if (label.Text == "0")
                {
                    box.Visible = false;
                    label2.Text = "<hr color=red>";
                }
                else
                {
                    box.Visible = true;
                    label2.Text = "";
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
                this.BindAttribute();
                string sql = "select * from qp_oa_Menhu where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.name.Text = list["name"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.ViewState["PerSessionStr"] = list["Lmid"].ToString();
                }
                list.Close();
                this.DataBindToGridview();
                for (int i = 0; i < this.GridView1.Rows.Count; i++)
                {
                    GridViewRow row = this.GridView1.Rows[i];
                    CheckBox box = (CheckBox) row.FindControl("quanbu");
                    Label label = (Label) row.FindControl("quanbuid");
                    Label label2 = (Label) row.FindControl("ParentNodesID");
                    if (this.pulicss.StrIFInStr("," + label.Text + ",", "," + this.ViewState["PerSessionStr"].ToString() + ",") && (label2.Text != "0"))
                    {
                        box.Checked = true;
                    }
                }
            }
        }
    }
}


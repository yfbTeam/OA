namespace xyoa.SystemManage.Menhu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Menhu_add : Page
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
                "insert into qp_oa_Menhu (States,pic,Lmid,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,name,Paixun) values ('", this.States.SelectedValue, "','1110.png','", this.ViewState["s_id"], "','", this.pulicss.GetFormatStr(this.ZdBumenId.Text), "','", this.pulicss.GetFormatStr(this.ZdBumen.Text), "','", this.pulicss.GetFormatStr(this.ZdUsername.Text), "','", this.pulicss.GetFormatStr(this.ZdRealname.Text), "','", this.pulicss.GetFormatStr(this.name.Text), "','", this.pulicss.GetFormatStr(this.Paixun.Text), 
                "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增门户中心", "门户中心");
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
                this.DataBindToGridview();
            }
        }
    }
}


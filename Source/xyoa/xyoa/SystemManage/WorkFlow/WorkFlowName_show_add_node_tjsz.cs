namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_node_tjsz : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected DropDownList DropDownList1;
        protected TextBox FlowId;
        protected TextBox FlowName;
        protected TextBox FlowNumber;
        protected HtmlForm form1;
        protected TextBox FormId;
        protected TextBox FormName;
        protected TextBox FormNumber;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox NodeName;
        protected TextBox NodeNum;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.NodeNum.Attributes.Add("readonly", "readonly");
            this.NodeName.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return adddatefile();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        public void DataBindToGridview(string Sqlsort)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select * from qp_oa_FlowFormFile  " + Sqlsort + " order by id asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            this.Label1.Text = null;
            string str2 = "select  *  from qp_oa_FlowFormFile  " + Sqlsort + " order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                string text = this.Label1.Text;
                this.Label1.Text = text + "【" + list["Name"].ToString() + "】" + list["Conditions"].ToString() + "“" + list["JudgeBasis"].ToString() + "”<font color=blue>" + list["JudgeType"].ToString().Replace("&&", "和").Replace("||", "或") + "</font>";
            }
            list.Close();
            this.Label1.Text = this.Label1.Text + "<font color=red>转入</font>" + this.DropDownList1.SelectedItem.Text + "";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "  Delete from qp_oa_FlowFormFile where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview("where KeyID='" + this.DropDownList1.SelectedValue + "' and  NodeId='" + base.Request.QueryString["id"] + "'");
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
                button.Attributes.Add("onclick", "javascript:return confirm('确认删除此字段的条件[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('WorkFlowName_show_add_node_tjsz_update.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "&FlowId=" + base.Request.QueryString["id"] + "','window','dialogWidth:460px;DialogHeight=280px;status:no;help=no;scroll=no');window.location='#'");
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
                    this.BindAttribute();
                    string sql = "select  *  from qp_oa_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.NodeNum.Text = list["NodeNum"].ToString();
                        this.NodeName.Text = list["NodeName"].ToString();
                        this.FlowNumber.Text = list["FlowNumber"].ToString();
                        this.FormNumber.Text = list["FormNumber"].ToString();
                        this.ViewState["strlist"] = "" + list["UpNodeNum"].ToString() + "0";
                    }
                    list.Close();
                }
                string sQL = string.Concat(new object[] { "  select  * from qp_oa_WorkFlowNode   where NodeNum in (", this.ViewState["strlist"], ") and FlowNumber='", this.FlowNumber.Text, "'" });
                if (!this.Page.IsPostBack)
                {
                    this.list.Bind_DropDownList(this.DropDownList1, sQL, "id", "NodeName");
                }
                if (this.DropDownList1.SelectedValue != "请选择")
                {
                    this.DataBindToGridview("where KeyID='" + this.DropDownList1.SelectedValue + "' and  NodeId='" + base.Request.QueryString["id"] + "'");
                }
                else
                {
                    this.DataBindToGridview("where KeyID='0'");
                }
            }
        }
    }
}


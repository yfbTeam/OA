namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_yz : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox FlowId;
        protected HtmlForm form1;
        protected TextBox FormId;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return adddatefile();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        public void DataBindToGridview(string Sqlsort)
        {
            string sql = "select * from qp_oa_WorkFlowNameYz where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "' " + Sqlsort + " ";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "  Delete from qp_oa_WorkFlowNameYz where ID='" + num + "'";
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
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                button.Attributes.Add("onclick", "javascript:return confirm('确认删除此印章域[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('WorkFlowName_show_add_yz_update.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "','window','dialogWidth:460px;DialogHeight=280px;status:no;help=no;scroll=no');window.location='#'");
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
                    string sql = "select  *  from qp_oa_WorkFlowName where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.FormId.Text = list["FormId"].ToString();
                        this.FlowId.Text = list["id"].ToString();
                    }
                    list.Close();
                }
                this.DataBindToGridview("order by id desc");
            }
        }
    }
}


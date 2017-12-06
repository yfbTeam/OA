namespace xyoa.pda.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAddWorkFlowJb : Page
    {
        protected Button btnFirst;
        protected Button btnLast;
        protected Button btnNext;
        protected Button btnPrev;
        protected Button Button1;
        protected Button Button4;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected DropDownList FormName;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox Starttime;

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((Button) sender).CommandName) - 1;
                this.DataBindToGridview();
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("/pda/Main.aspx?leixing=1");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Name.Text != "")
            {
                str = str + " and A.Name like '%" + this.pulicss.GetFormatStr(this.Name.Text) + "%'";
            }
            if (this.FormName.SelectedValue != "")
            {
                str = str + " and A.FormId = '" + this.FormName.SelectedValue + "'";
            }
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and ((NowTimes between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)) ) ";
            }
            return (str + " and A.FqUsername= '" + this.Session["username"].ToString() + "'");
        }

        public void DataBindToGridview()
        {
            string str = "select A.* from [qp_oa_AddWorkFlowGc] as [A]  where 1=1";
            string str2 = str + this.CreateMidSql();
            string sql = "" + str2 + "  order by A.id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
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
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label6");
                Label label3 = (Label) e.Row.FindControl("Label8");
                Label label4 = (Label) e.Row.FindControl("fujian");
                label2.Text = "";
                label3.Text = "";
                string sql = "select id,Number,GlNum from qp_oa_AddWorkFlowGc  where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    label2.Text = "<input id=\"Button1\" type=\"button\" value=\"表单\" onclick=\"LoadingShow();var num = Math.random();location.href='MyAddWorkFlowJbBd.aspx?id=" + list["id"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                    label3.Text = "<input id=\"Button1\" type=\"button\" value=\"流程图\" onclick=\"LoadingShow();var num = Math.random();location.href='MyAddWorkFlowJbLct.aspx?id=" + list["id"].ToString() + "&Number=" + list["Number"].ToString() + "&GlNum=" + list["GlNum"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                    this.pulicss.GetFileSj(list["Number"].ToString(), label4);
                }
                list.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Starttime.Attributes.Add("readonly", "readonly");
                this.Endtime.Attributes.Add("readonly", "readonly");
                string sQL = string.Concat(new object[] { "select A.id,FormName  from qp_oa_DIYForm  as [A] inner join [qp_oa_FormType] as [B] on [A].[TypeId] = [B].[Id] where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')" });
                this.list.Bind_DropDownList_kong(this.FormName, sQL, "id", "FormName");
                this.btnFirst.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnPrev.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnNext.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnLast.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button4.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.DataBindToGridview();
            }
        }
    }
}


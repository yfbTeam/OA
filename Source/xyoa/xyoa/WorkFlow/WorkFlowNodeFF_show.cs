namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowNodeFF_show : Page
    {
        protected Button Button10;
        protected Label Content;
        protected HtmlForm form1;
        protected Label FsRealname;
        protected Label FsTime;
        protected Label FsUsername;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Number;
        public string pageurl;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected HtmlGenericControl tablename;
        protected Label Titles;

        protected void Button10_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=WordFile.doc");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/word";
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            this.tablename.RenderControl(writer2);
            string s = sb.ToString();
            base.Response.Write(s);
            base.Response.End();
            this.Panel1.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowFF where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "')" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["FormNumber"] = list["FormNumber"].ToString();
                    this.ViewState["WfNumber"] = list["WfNumber"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Content.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                    this.FsTime.Text = list["FsTime"].ToString();
                    this.FsRealname.Text = list["FsRealname"].ToString();
                    this.FsUsername.Text = list["FsUsername"].ToString();
                    if (list["IfRead"].ToString() != "True")
                    {
                        string str2 = "Update qp_oa_AddWorkFlowLog Set Contents=replace(Contents,'" + this.Session["realname"].ToString() + "','<font color=\"blue\">" + this.Session["realname"].ToString() + "(" + DateTime.Now.ToString() + ")</font>')  where  Email='" + this.Number.Text + "'";
                        this.List.ExeSql(str2);
                    }
                    string str3 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowFF Set IfRead='1'  where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "')" });
                    this.List.ExeSql(str3);
                    string str4 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + this.ViewState["FormNumber"] + "'";
                    SqlDataReader reader2 = this.List.GetList(str4);
                    while (reader2.Read())
                    {
                        StateBag bag = ViewState;
                        object obj2 = bag["url"];
                        (bag = this.ViewState)["url"] = string.Concat(new object[] { obj2, "try{window.L", reader2["Number"], ".location.href='AddWorkFlow_spyj.aspx?Number=", this.ViewState["WfNumber"], "&Buzhou=", reader2["sqlstr"], "&key=1';}catch(err){}" });
                    }
                    reader2.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location.href='qp_oa_AddWorkFlowFF.aspx'</script>");
                }
                list.Close();
                this.pulicss.InsertLog("查看工作流传阅", "工作流传阅");
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}


namespace xyoa.pda.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAddWorkFlowYj : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected TextBox GlNum;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label JinJiChengDu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox whendname;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyAddWorkFlow.aspx");
        }

        public void DataBindToGridview()
        {
            string sql = "select * from qp_oa_AddWorkFlowMessage  where Number='" + this.Number.Text + "' order by id asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = "select * from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["NodeNum"] = list["NodeNum"].ToString();
                    this.ViewState["YijianZb"] = list["YijianZb"].ToString();
                    this.ViewState["NodeName"] = list["NodeName"].ToString();
                    this.ViewState["UpNodeNum"] = list["UpNodeNum"].ToString();
                    this.ViewState["UpNodeNumKey"] = list["UpNodeNum"].ToString();
                    this.ViewState["NodeId"] = list["id"].ToString();
                    this.ViewState["WriteFileID"] = "" + list["WriteFileID"].ToString() + "0";
                    this.ViewState["SecFileID"] = "" + list["SecFileID"].ToString() + "0";
                    this.ViewState["HongFileID"] = "" + list["HongFileID"].ToString() + "0";
                    string str2 = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.JinJiChengDu.Text = this.pulicss.SystemCode("10", reader2["JinJiChengDu"].ToString());
                        this.Number.Text = reader2["Number"].ToString();
                        this.GlNum.Text = reader2["GlNum"].ToString();
                        this.ViewState["lshid"] = int.Parse(reader2["Sequence"].ToString());
                        this.ViewState["whname"] = reader2["Name"].ToString();
                        string str3 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", reader2["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", reader2["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                        this.List.ExeSql(str3);
                        string str4 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", reader2["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", reader2["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "'" });
                        SqlDataReader reader3 = this.List.GetList(str4);
                        if (reader3.Read())
                        {
                            this.ViewState["IfZb"] = reader3["IfZb"].ToString();
                        }
                        reader3.Close();
                    }
                }
                list.Close();
                this.DataBindToGridview();
            }
        }
    }
}


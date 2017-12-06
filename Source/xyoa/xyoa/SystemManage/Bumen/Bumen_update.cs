namespace xyoa.SystemManage.Bumen
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Bumen_update : Page
    {
        protected TextBox Bianhao;
        protected TextBox BmRealname;
        protected TextBox BmUsername;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public string LineW;
        protected TextBox Linew1;
        public string LineWSta;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        protected TextBox ParentNodes;
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();
        public string QxString;
        protected TextBox QxString1;
        public string QxStringSta;
        protected TextBox remark;

        public void BindAttribute()
        {
            this.BmRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 * from qp_oa_Bumen where id='" + this.ParentNodesID.SelectedValue + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.QxStringSta = list["QxString"].ToString();
                this.LineWSta = list["LineW"].ToString();
            }
            list.Close();
            string str2 = string.Concat(new object[] { "Update qp_oa_Bumen  Set Bianhao='", this.pulicss.GetFormatStr(this.Bianhao.Text), "',BmUsername='", this.pulicss.GetFormatStr(this.BmUsername.Text), "',BmRealname='", this.pulicss.GetFormatStr(this.BmRealname.Text), "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "',remark='", this.pulicss.GetFormatStr(this.remark.Text), "',ParentNodesID='", this.ParentNodesID.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("修改部门[" + this.Name.Text + "]", "部门管理");
            base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.nexthead.location = 'Bumen_left.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Bumen_show.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListBm("qp_oa_Bumen", this.ParentNodesID, "", "order by Bianhao asc");
                this.BindAttribute();
                string sql = "select * from qp_oa_Bumen where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Bianhao.Text = list["Bianhao"].ToString();
                    this.Name.Text = list["name"].ToString();
                    this.remark.Text = list["remark"].ToString();
                    this.ParentNodesID.SelectedValue = list["ParentNodesID"].ToString();
                    this.QxString1.Text = list["QxString"].ToString();
                    this.Linew1.Text = list["Linew"].ToString();
                    this.ParentNodes.Text = list["ParentNodesID"].ToString();
                    this.BmUsername.Text = list["BmUsername"].ToString();
                    this.BmRealname.Text = list["BmRealname"].ToString();
                }
                list.Close();
            }
        }
    }
}


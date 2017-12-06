namespace xyoa.MyWork.wjk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Folders_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected TextBox GxRealname;
        protected TextBox GxUsername;
        protected HtmlHead Head1;
        protected DropDownList IfShare;
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

        public void BindAttribute()
        {
            this.GxRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str;
            if (this.IfShare.SelectedValue == "1")
            {
                str = string.Concat(new object[] { "Update qp_oa_Folders  Set GxUsername='", this.pulicss.GetFormatStr(this.GxUsername.Text), "',GxRealname='", this.pulicss.GetFormatStr(this.GxRealname.Text), "',IfShare='", this.IfShare.SelectedValue, "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "',ParentNodesID='", this.ParentNodesID.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                this.List.ExeSql(str);
            }
            else
            {
                str = string.Concat(new object[] { "Update qp_oa_Folders  Set GxUsername='0',GxRealname='未共享',IfShare='", this.IfShare.SelectedValue, "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "',ParentNodesID='", this.ParentNodesID.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                this.List.ExeSql(str);
            }
            this.pulicss.InsertLog("修改文件夹[" + this.Name.Text + "]", "个人文件夹");
            base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.nexthead.location = 'Folders_left.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Folders_show.aspx?id=" + base.Request.QueryString["id"].ToString() + "");
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
                this.pulicss.BindListBm("qp_oa_Folders", this.ParentNodesID, " and username='" + this.Session["username"] + "'", "order by id asc");
                string sql = string.Concat(new object[] { "select * from qp_oa_Folders where id='", base.Request.QueryString["id"], "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.ParentNodesID.SelectedValue = list["ParentNodesID"].ToString();
                    this.IfShare.SelectedValue = list["IfShare"].ToString();
                    this.GxRealname.Text = list["GxRealname"].ToString();
                    this.GxUsername.Text = list["GxUsername"].ToString();
                    this.ParentNodes.Text = list["ParentNodesID"].ToString();
                    this.QxString1.Text = list["QxString"].ToString();
                    this.Linew1.Text = list["Linew"].ToString();
                }
                list.Close();
            }
        }
    }
}


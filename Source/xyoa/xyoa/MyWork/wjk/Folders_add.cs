namespace xyoa.MyWork.wjk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Folders_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected TextBox GxRealname;
        protected TextBox GxUsername;
        protected HtmlHead Head1;
        protected DropDownList IfShare;
        public string LineW;
        public string LineWSta;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();
        public string QxString;
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
                str = string.Concat(new object[] { "insert into qp_oa_Folders (Name,IfShare,GxUsername,GxRealname,ParentNodesID,Username,Realname) values ('", this.pulicss.GetFormatStr(this.Name.Text), "','", this.IfShare.SelectedValue, "','", this.pulicss.GetFormatStr(this.GxUsername.Text), "','", this.pulicss.GetFormatStr(this.GxRealname.Text), "','", this.pulicss.GetFormatStr(this.ParentNodesID.SelectedValue), "','", this.Session["username"], "','", this.Session["realname"], "')" });
                this.List.ExeSql(str);
            }
            else
            {
                str = string.Concat(new object[] { "insert into qp_oa_Folders (Name,IfShare,GxUsername,GxRealname,ParentNodesID,Username,Realname) values ('", this.pulicss.GetFormatStr(this.Name.Text), "','", this.IfShare.SelectedValue, "','0','未共享','", this.pulicss.GetFormatStr(this.ParentNodesID.SelectedValue), "','", this.Session["username"], "','", this.Session["realname"], "')" });
                this.List.ExeSql(str);
            }
            this.pulicss.InsertLog("新增文件夹[" + this.Name.Text + "]", "个人文件夹");
            if (this.CheckBox1.Checked)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.location = 'Folders_add.aspx?id=" + this.ParentNodesID.SelectedValue + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'Folders.aspx'</script>");
            }
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
                if (base.Request.QueryString["id"] != null)
                {
                    this.ParentNodesID.SelectedValue = base.Request.QueryString["id"].ToString();
                }
            }
        }
    }
}


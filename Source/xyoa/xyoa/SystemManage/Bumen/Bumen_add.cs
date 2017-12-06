namespace xyoa.SystemManage.Bumen
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Bumen_add : Page
    {
        protected TextBox Bianhao;
        protected TextBox BmRealname;
        protected TextBox BmUsername;
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
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
        protected TextBox remark;

        public void BindAttribute()
        {
            this.BmRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Bumen (Bianhao,Name,remark,BmUsername,BmRealname,ParentNodesID) values ('" + this.pulicss.GetFormatStr(this.Bianhao.Text) + "','" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.pulicss.GetFormatStr(this.remark.Text) + "','" + this.pulicss.GetFormatStr(this.BmUsername.Text) + "','" + this.pulicss.GetFormatStr(this.BmRealname.Text) + "','" + this.pulicss.GetFormatStr(this.ParentNodesID.SelectedValue) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增部门[" + this.Name.Text + "]", "部门管理");
            if (this.CheckBox1.Checked)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    base.Response.Write("<script language=javascript>alert('提交成功！'); window.location = 'Bumen_add.aspx?id=" + base.Request.QueryString["id"].ToString() + "'</script>");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('提交成功！'); window.location = 'Bumen_add.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.nexthead.location = 'Bumen_left.aspx'</script>");
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
                this.pulicss.BindListBm("qp_oa_Bumen", this.ParentNodesID, "", "order by Bianhao asc");
                if (base.Request.QueryString["id"] != null)
                {
                    try
                    {
                        this.ParentNodesID.SelectedValue = base.Request.QueryString["id"].ToString();
                    }
                    catch
                    {
                        this.ParentNodesID.SelectedValue = "0";
                    }
                }
            }
        }
    }
}


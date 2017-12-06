namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class leibie_zl_update : Page
    {
        protected Button Button1;
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        protected DropDownList ParentNodesID;
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
            this.Button3.Attributes["onclick"] = "javascript:return deltree();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_Zst_leibie_zl  Set  Name='", this.pulicss.GetFormatStr(this.Name.Text), "',ParentNodesID='", this.ParentNodesID.SelectedValue, "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',Paixun='", this.Paixun.Text, 
                "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改资料分类设置", "资料分类设置");
            base.Response.Write("<script language=javascript>alert('修改成功！'); window.parent.location = 'leibie_zl.aspx'</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "  Delete from qp_oa_Zst_leibie_zl  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(sql);
            string str2 = "  Delete from qp_oa_Zst_leibie_zl  where ParentNodesID='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("删除资料分类设置", "资料分类设置");
            base.Response.Write("<script language=javascript>alert('删除成功！'); window.parent.location = 'leibie_zl.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Name from qp_oa_Zst_leibie_zl where ParentNodesID=0 order by Paixun asc";
                this.list.Bind_DropDownList_unit(this.ParentNodesID, sQL, "id", "Name");
                string sql = "select * from qp_oa_Zst_leibie_zl  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ParentNodesID.SelectedValue = list["ParentNodesID"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


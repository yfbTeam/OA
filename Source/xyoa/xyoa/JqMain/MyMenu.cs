namespace xyoa.JqMain
{
    using qiupeng.crm;
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyMenu : Page
    {
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TreeView TreeView9;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = string.Concat(new object[] { "select * from qp_oa_AllUrl  where (CHARINDEX(''+quanxian+'','", this.ViewState["qxstr"], "')   >   0 ) and id in (", this.ViewState["Lmid"].ToString(), ") and menhulm='1' and ParentNodesID!='0' and ifopen='1' order by paixu asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Text = "<a href='" + list["url"].ToString() + " ' target='rform' onclick='parent.UploadComplete();'>" + list["urlname"].ToString() + "</a>";
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/" + list["pic"].ToString() + "";
                child.Expanded = true;
                Nds.Add(child);
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_Menhu where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["name"] = list["name"].ToString();
                    this.ViewState["Lmid"] = list["Lmid"].ToString();
                    this.ViewState["qxstr"] = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
                }
                list.Close();
                this.BindTree(this.TreeView9.Nodes);
            }
        }
    }
}


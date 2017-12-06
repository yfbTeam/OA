namespace xyoa.menu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class daiban : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TreeView TreeView9;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = "select * from qp_oa_Daibanshiyi  where CHARINDEX(quanxian,'" + this.Session["perstr"] + "') > 0 order by paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                try
                {
                    if (int.Parse(this.pulicss.Daibanshiyi(list["Name"].ToString())) > 0)
                    {
                        child.Text = "<a href='" + list["Url"].ToString() + "' target='rform' onclick='parent.UploadComplete();'><font  color=\"blue\">" + list["Name"].ToString() + "</font></a>（<a href='" + list["Url"].ToString() + "' onclick='parent.UploadComplete();'><font  color=\"blue\">" + this.pulicss.Daibanshiyi(list["Name"].ToString()) + "</font></a>）";
                    }
                    else
                    {
                        child.Text = "<a href='" + list["Url"].ToString() + "' target='rform' onclick='parent.UploadComplete();'><font  color=\"#000000\">" + list["Name"].ToString() + "</font></a>（<a href='" + list["Url"].ToString() + "' onclick='parent.UploadComplete();'><font  color=\"#000000\">" + this.pulicss.Daibanshiyi(list["Name"].ToString()) + "</font></a>）";
                    }
                }
                catch
                {
                    child.Text = "<a href='" + list["Url"].ToString() + "' target='rform' onclick='parent.UploadComplete();'><font  color=\"#000000\">" + list["Name"].ToString() + "</font></a>（<a href='" + list["Url"].ToString() + "' onclick='parent.UploadComplete();'><font  color=\"#000000\">" + this.pulicss.Daibanshiyi(list["Name"].ToString()) + "</font></a>）";
                }
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/Menu36.gif";
                child.Expanded = true;
                Nds.Add(child);
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.BindTree(this.TreeView9.Nodes);
            }
        }
    }
}


namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class leibie_zl_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string sql = "select id,Name,ParentNodesID from qp_oa_Zst_leibie_zl where ParentNodesID=" + IDStr.ToString() + "   order by Paixun asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode node;
                int num;
                if (IDStr == 0)
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/zhu.gif";
                    node.Text = string.Concat(new object[] { " <a href='leibie_zl_update.aspx?id=", num, "' target='nextrform' >", list["Name"].ToString(), "</a>" });
                    node.SelectAction = TreeNodeSelectAction.None;
                    node.Expanded = true;
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                }
                else
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/homepage.gif";
                    node.Text = string.Concat(new object[] { " <a href='leibie_zl_update.aspx?id=", num, "' target='nextrform' >", list["Name"].ToString(), "</a>" });
                    node.SelectAction = TreeNodeSelectAction.None;
                    node.Expanded = false;
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                }
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindTree(this.ListTreeView.Nodes, 0);
            this.pulicss.QuanXianVis(this.ListTreeView, "aaaa1a3", this.Session["perstr"].ToString());
            string sql = "select * from qp_oa_Zst_leibie_zl";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.showtitle = "";
            }
            else
            {
                this.showtitle = "<a href='leibie_zl_add.aspx' target='nextrform'>增加分类</a>";
            }
            list.Close();
        }
    }
}


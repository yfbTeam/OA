namespace xyoa.SystemManage.Bumen
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Bumen_left : Page
    {
        protected HtmlForm form1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string sql = "select id,Name,ParentNodesID from qp_oa_Bumen where ParentNodesID=" + IDStr.ToString() + "   order by Bianhao asc";
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
                    node.Text = string.Concat(new object[] { " <a href='Bumen_show.aspx?id=", num, "' target='nextrform' >", list["Name"].ToString(), "</a>" });
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
                    node.Text = string.Concat(new object[] { " <a href='Bumen_show.aspx?id=", num, "' target='nextrform' >", list["Name"].ToString(), "</a>" });
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
            this.pulicss.QuanXianVis(this.ListTreeView, "iiii7b", this.Session["perstr"].ToString());
            string sql = "select * from qp_oa_Bumen ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.showtitle = "";
            }
            else
            {
                this.showtitle = "<a href='Bumen_show.aspx?id=10000' target='nextrform'>增加单位/部门</a>";
            }
            list.Close();
        }
    }
}


namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Openleibie_zlLeft : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string sql = string.Concat(new object[] { "select id,Name,ParentNodesID from qp_oa_Zst_leibie_zl where ParentNodesID=", IDStr.ToString(), " and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) order by id asc" });
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
                    node.Text = "" + list["Name"].ToString() + "";
                    node.SelectAction = TreeNodeSelectAction.Expand;
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
                    node.Text = "<a href=Openleibie_zlMc.aspx?id=" + list["id"].ToString() + "  target='rform'>" + list["Name"].ToString() + "</a>";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = true;
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                }
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindTree(this.ListTreeView.Nodes, 0);
            string sql = "select id from qp_oa_Zst_leibie_zl";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.showtitle = "";
            }
            else
            {
                this.showtitle = "没有设置资料分类";
            }
            list.Close();
        }
    }
}


namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class OpenZiChangLeft : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = string.Concat(new object[] { "select * from qp_oa_ResourcesCangKu where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by Paixun asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/knowledge2.gif";
                child.Text = " " + list["Name"].ToString() + "";
                child.SelectAction = TreeNodeSelectAction.Expand;
                child.Expanded = false;
                Nds.Add(child);
                string str2 = "select id,ZyName,ZyNum from qp_oa_ResourcesAdd  where Cangku='" + list["id"].ToString() + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    TreeNode node2 = new TreeNode();
                    node2.Value = reader2["ID"].ToString();
                    int num2 = int.Parse(reader2["ID"].ToString());
                    node2.ImageUrl = "/oaimg/menu/Menu68.gif";
                    node2.Text = string.Concat(new object[] { " <a href='OpenZiChangMc.aspx?id=", num2, "' target='rform'>", reader2["ZyName"].ToString(), "(", reader2["ZyNum"].ToString(), ")</a>" });
                    node2.SelectAction = TreeNodeSelectAction.None;
                    node2.Expanded = false;
                    child.ChildNodes.Add(node2);
                }
                reader2.Close();
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindTree(this.ListTreeView.Nodes);
            string sql = string.Concat(new object[] { "select id from qp_oa_ResourcesCangKu where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.showtitle = "";
            }
            else
            {
                this.showtitle = "没有设置仓库";
            }
            list.Close();
        }
    }
}


namespace xyoa.OfficeMenu.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RenwuJkBm_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string sql = "select id,Name,ParentNodesID from qp_oa_Bumen where ParentNodesID=" + IDStr.ToString() + "   order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode node;
                int num;
                string str2;
                SqlDataReader reader2;
                TreeNode node2;
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
                    str2 = string.Concat(new object[] { "select username,realname from qp_oa_Username where  CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_RenwuSz where ZgUsername='", this.Session["username"], "')+',') > 0  and BuMenId='", list["ID"].ToString(), "'   order by paixu asc" });
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        node2 = new TreeNode();
                        node2.Value = reader2["username"].ToString();
                        node2.ImageUrl = "/oaimg/menu/on1.gif";
                        node2.Text = " <a href='RenwuJk_list.aspx?user=" + reader2["username"].ToString() + "' target='nextrform'>" + reader2["realname"].ToString() + "</a>";
                        node2.SelectAction = TreeNodeSelectAction.Expand;
                        node2.Expanded = true;
                        node.ChildNodes.Add(node2);
                    }
                    reader2.Close();
                }
                else
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/homepage.gif";
                    node.Text = " " + list["Name"].ToString() + "";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = false;
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                    str2 = string.Concat(new object[] { "select username,realname from qp_oa_Username where  CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_RenwuSz where ZgUsername='", this.Session["username"], "')+',') > 0 and BuMenId='", list["ID"].ToString(), "'   order by paixu asc" });
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        node2 = new TreeNode();
                        node2.Value = reader2["username"].ToString();
                        node2.ImageUrl = "/oaimg/menu/on1.gif";
                        node2.Text = " <a href='RenwuJk_list.aspx?user=" + reader2["username"].ToString() + "' target='nextrform'>" + reader2["realname"].ToString() + "</a>";
                        node2.SelectAction = TreeNodeSelectAction.Expand;
                        node2.Expanded = true;
                        node.ChildNodes.Add(node2);
                    }
                    reader2.Close();
                }
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindTree(this.ListTreeView.Nodes, 0);
            string sql = "select username,realname from qp_oa_Username where  CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_RenwuSz where ZgUsername='" + this.Session["username"] + "')+',') > 0   order by paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.showtitle = "";
            }
            else
            {
                this.showtitle = "未找到可以监控的人员";
            }
            list.Close();
        }
    }
}


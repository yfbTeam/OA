namespace xyoa.MyWork.wjk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Folders_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string sql = string.Concat(new object[] { "select id,Name,ParentNodesID,IfShare from qp_oa_Folders where ParentNodesID=", IDStr.ToString(), "  and  username='", this.Session["username"], "'  order by id asc" });
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
                    if (list["IfShare"].ToString() == "1")
                    {
                        node.ImageUrl = "/oaimg/menu/shareFolder.gif";
                    }
                    else
                    {
                        node.ImageUrl = "/oaimg/menu/folder.gif";
                    }
                    node.Text = string.Concat(new object[] { " <a href='Folders_show.aspx?id=", num, "' target='nextrform' >", list["Name"].ToString(), "</a>" });
                    node.SelectAction = TreeNodeSelectAction.None;
                    node.Expanded = false;
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                }
                else
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    if (list["IfShare"].ToString() == "1")
                    {
                        node.ImageUrl = "/oaimg/menu/shareFolder.gif";
                    }
                    else
                    {
                        node.ImageUrl = "/oaimg/menu/folder.gif";
                    }
                    node.Text = string.Concat(new object[] { " <a href='Folders_show.aspx?id=", num, "' target='nextrform' >", list["Name"].ToString(), "</a>" });
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
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.BindTree(this.ListTreeView.Nodes, 0);
                this.pulicss.QuanXianVis(this.ListTreeView, "hhhh6a", this.Session["perstr"].ToString());
                string sql = "select * from qp_oa_Folders where username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.showtitle = "";
                }
                else
                {
                    this.showtitle = "<a href='Folders_add.aspx?id=0' target='nextrform'>增加文件夹</a>";
                }
                list.Close();
            }
        }
    }
}


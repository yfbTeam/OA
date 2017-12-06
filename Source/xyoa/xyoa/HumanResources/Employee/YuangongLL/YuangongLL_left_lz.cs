namespace xyoa.HumanResources.Employee.YuangongLL
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongLL_left_lz : Page
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
                string str2;
                string str3;
                TreeNode node;
                int num;
                string str4;
                SqlDataReader reader2;
                TreeNode node2;
                int num2;
                if (IDStr == 0)
                {
                    str2 = "select count(A.id) from  [qp_hr_Yuangong] as [A] where A.Bumen='" + list["id"] + "' and Zaizhi='2'";
                    str3 = "" + this.List.GetCount(str2) + "";
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/zhu.gif";
                    node.Text = "" + list["Name"].ToString() + "(" + str3 + ")";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = true;
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                    str4 = "select id,Xingming  from [qp_hr_Yuangong] where Bumen='" + list["ID"].ToString() + "' and Zaizhi='2' order by A.id asc";
                    reader2 = this.List.GetList(str4);
                    while (reader2.Read())
                    {
                        node2 = new TreeNode();
                        node2.Value = reader2["ID"].ToString();
                        num2 = int.Parse(reader2["ID"].ToString());
                        node2.Text = string.Concat(new object[] { " <a href='javascript:void(0)' onclick=\"showfrom1('", num2, "')\"><img src=\"/oaimg/menu/on1.gif\" border=\"0\"/>", reader2["Xingming"].ToString(), "</a>" });
                        node2.SelectAction = TreeNodeSelectAction.Expand;
                        node2.Expanded = true;
                        node.ChildNodes.Add(node2);
                    }
                    reader2.Close();
                }
                else
                {
                    str2 = "select count(A.id) from  [qp_hr_Yuangong] as [A] where A.Bumen='" + list["id"] + "' and Zaizhi='2'";
                    str3 = "" + this.List.GetCount(str2) + "";
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/homepage.gif";
                    node.Text = " " + list["Name"].ToString() + "(" + str3 + ")";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = false;
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                    str4 = "select id,Xingming  from [qp_hr_Yuangong] where Bumen='" + list["ID"].ToString() + "' and Zaizhi='2' order by A.id asc";
                    reader2 = this.List.GetList(str4);
                    while (reader2.Read())
                    {
                        node2 = new TreeNode();
                        node2.Value = reader2["ID"].ToString();
                        num2 = int.Parse(reader2["ID"].ToString());
                        node2.Text = string.Concat(new object[] { " <a href='javascript:void(0)' onclick=\"showfrom1('", num2, "')\"><img src=\"/oaimg/menu/on1.gif\" border=\"0\"/>", reader2["Xingming"].ToString(), "</a>" });
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
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.BindTree(this.ListTreeView.Nodes, 0);
                this.pulicss.QuanXianVis(this.ListTreeView, "eeee4g", this.Session["perstr"].ToString());
            }
        }
    }
}


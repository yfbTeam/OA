namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = string.Concat(new object[] { "select id,name from qp_oa_FormType where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by Paixun asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/knowledge2.gif";
                child.Text = "" + list["Name"].ToString() + "";
                child.SelectAction = TreeNodeSelectAction.Expand;
                child.Expanded = false;
                Nds.Add(child);
                string str2 = "select id,FormName from qp_oa_DIYForm  where TypeId='" + list["id"].ToString() + "' order by paixu asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    TreeNode node2 = new TreeNode();
                    node2.Value = reader2["ID"].ToString();
                    int num2 = int.Parse(reader2["ID"].ToString());
                    node2.ImageUrl = "/oaimg/menu/Menu68.gif";
                    node2.Text = string.Concat(new object[] { " <a href='AddWorkFlow_show.aspx?id=", num2, "' target='nextrform'>", reader2["FormName"].ToString(), "</a>" });
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
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.BindTree(this.ListTreeView.Nodes);
                this.pulicss.QuanXianVis(this.ListTreeView, "mmmm1", this.Session["perstr"].ToString());
            }
        }
    }
}


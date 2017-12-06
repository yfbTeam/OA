namespace xyoa.menu
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class OtherMenu : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView TreeView9;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = string.Concat(new object[] { "select * from qp_oa_OtherMenu where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')  order by Paixun asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Text = "<a href='" + list["urlname"].ToString() + " ' target='rform'>" + list["name"].ToString() + "</a>";
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/Menu8.gif";
                child.Expanded = true;
                Nds.Add(child);
            }
            list.Close();
        }

        private void BindTree1(TreeNodeCollection Nds)
        {
            string sql = string.Concat(new object[] { "select * from qp_oa_Menhu  where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by Paixun asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Text = "<a href='/JqMain/Mymenhu.aspx?p=12&id=" + list["id"].ToString() + "' target='rform' onclick='parent.UploadComplete();'>" + list["name"].ToString() + "</a>";
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/Menu8.gif";
                child.Expanded = true;
                Nds.Add(child);
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.BindTree1(this.TreeView9.Nodes);
                this.BindTree(this.TreeView9.Nodes);
            }
        }
    }
}


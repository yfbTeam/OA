namespace xyoa.SchTable.Xueji.Richang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Richang_xn : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/Choose32.gif";
                child.Text = " <a href='Richang_Rz.aspx?Xueqi=" + list["Mingcheng"].ToString() + "' target='nextrform'>" + list["Mingcheng"].ToString() + "</a>";
                child.SelectAction = TreeNodeSelectAction.None;
                child.Expanded = false;
                Nds.Add(child);
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
                TreeNode child = new TreeNode();
                child.ImageUrl = "/oaimg/menu/zhu.gif";
                child.Text = "<a href='Richang_Rz.aspx?Xueqi=all' target='nextrform'>全部学期</a>";
                child.SelectAction = TreeNodeSelectAction.None;
                child.Expanded = false;
                this.ListTreeView.Nodes.Add(child);
                this.BindTree(this.ListTreeView.Nodes);
            }
        }
    }
}


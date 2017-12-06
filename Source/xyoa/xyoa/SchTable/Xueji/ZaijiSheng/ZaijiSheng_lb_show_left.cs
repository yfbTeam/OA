namespace xyoa.SchTable.Xueji.ZaijiSheng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZaijiSheng_lb_show_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TreeView TreeView9;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = "select * from qp_sch_XueshengUrl  where CHARINDEX(quanxian,'" + this.Session["perstr"] + "') > 0 order by paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Text = "<a href='" + list["Url"].ToString() + "?XsId=" + base.Request.QueryString["id"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "' target='nextrform'>" + list["Name"].ToString() + "</a>";
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/Menu36.gif";
                child.SelectAction = TreeNodeSelectAction.Expand;
                child.Expanded = false;
                Nds.Add(child);
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindTree(this.TreeView9.Nodes);
        }
    }
}


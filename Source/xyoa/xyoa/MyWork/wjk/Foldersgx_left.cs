namespace xyoa.MyWork.wjk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Foldersgx_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds, string Share, string IDStr, string PID)
        {
            string sql = "select * from qp_oa_Folders where (CHARINDEX('," + this.Session["Username"] + ",',','+GxUsername+',')   >   0 or GxUsername='全部用户')  and  IfShare='1' order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/shareFolder.gif";
                child.Text = string.Concat(new object[] { " <a href='FoldersGx_show.aspx?id=", num, "' target='nextrform'>", list["Name"].ToString(), "(", list["realname"].ToString(), ")</a>" });
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
                this.BindTree(this.ListTreeView.Nodes, "", "0", "0");
                this.pulicss.QuanXianVis(this.ListTreeView, "hhhh6b", this.Session["perstr"].ToString());
            }
        }
    }
}


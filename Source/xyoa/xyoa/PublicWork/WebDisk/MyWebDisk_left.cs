namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string sql = string.Concat(new object[] { "select A.[Name],A.[id] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  and ((B.[Types]='1' and nameid='1' and FLiulang='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FLiulang='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FLiulang='1')   or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FLiulang='1')) and A.ParentNodesID=", IDStr.ToString(), "  group by A.[Name],A.[id],A.[Paixun] order by A.Paixun asc" });
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
                    node.ImageUrl = "/oaimg/menu/Choose32.gif";
                    node.Text = string.Concat(new object[] { " <a href='MyWebDisk_show.aspx?id=", num, "' target='nextrform'>", list["Name"].ToString(), "</a>" });
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
                    node.ImageUrl = "/oaimg/menu/Choose32.gif";
                    node.Text = string.Concat(new object[] { " <a href='MyWebDisk_show.aspx?id=", num, "' target='nextrform'>", list["Name"].ToString(), "</a>" });
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
                this.pulicss.QuanXianVis(this.ListTreeView, "jjjja1b", this.Session["perstr"].ToString());
                string sql = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  and ((B.[Types]='1' and nameid='1' and FLiulang='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FLiulang='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FLiulang='1')  or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FLiulang='1'))" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.showtitle = "";
                }
                else
                {
                    this.showtitle = "没有对应目录";
                }
                list.Close();
            }
        }
    }
}


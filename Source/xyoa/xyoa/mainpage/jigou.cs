namespace xyoa.mainpage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class jigou : Page
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
                int num2;
                DateTime time;
                DateTime time2;
                TimeSpan span;
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
                    str2 = "select A.id,A.username, A.realname,A.lasttime,  C.[States], C.[Shuoming]  from [qp_oa_username] as [A]  inner join [qp_oa_MyState] as [C] on [A].[username] = [C].[username] and [A].[BuMenId]='" + list["ID"].ToString() + "'  and A.Iflogin='1' and A.StardType='1' and A.ifdel='0'  order by A.paixu asc";
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        node2 = new TreeNode();
                        node2.Value = reader2["ID"].ToString();
                        num2 = int.Parse(reader2["ID"].ToString());
                        time = Convert.ToDateTime(DateTime.Now.ToString());
                        time2 = Convert.ToDateTime(reader2["lasttime"].ToString());
                        span = (TimeSpan) (time - time2);
                        if (span.TotalSeconds < 100.0)
                        {
                            node2.ImageUrl = "/oaimg/menu/on1.gif";
                        }
                        else
                        {
                            node2.ImageUrl = "/oaimg/menu/on2.gif";
                        }
                        node2.Text = "<a href='/Client/UserInfo.aspx?user=" + reader2["username"].ToString() + "' target='rform' >" + reader2["realname"].ToString() + "</a>[<a href=\"javascript:void(0)\" onclick=openwindows(\"" + reader2["username"].ToString() + "\")>消息</a>][<a href=\"javascript:void(0)\" onclick=\"openemail('" + reader2["username"].ToString() + "')\" title='" + reader2["States"].ToString() + "：" + reader2["Shuoming"].ToString() + "' target='rform'>邮件</a>]";
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
                    str2 = "select A.id,A.username, A.realname,A.lasttime,  C.[States], C.[Shuoming]  from [qp_oa_username] as [A]  inner join [qp_oa_MyState] as [C] on [A].[username] = [C].[username] and [A].[BuMenId]='" + list["ID"].ToString() + "'  and A.Iflogin='1' and A.StardType='1' and A.ifdel='0'  order by A.paixu asc";
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        node2 = new TreeNode();
                        node2.Value = reader2["ID"].ToString();
                        num2 = int.Parse(reader2["ID"].ToString());
                        time = Convert.ToDateTime(DateTime.Now.ToString());
                        time2 = Convert.ToDateTime(reader2["lasttime"].ToString());
                        span = (TimeSpan) (time - time2);
                        if (span.TotalSeconds < 100.0)
                        {
                            node2.ImageUrl = "/oaimg/menu/on1.gif";
                        }
                        else
                        {
                            node2.ImageUrl = "/oaimg/menu/on2.gif";
                        }
                        node2.Text = "<a href='/Client/UserInfo.aspx?user=" + reader2["username"].ToString() + "' target='rform'>" + reader2["realname"].ToString() + "</a>[<a href=\"javascript:void(0)\" onclick=openwindows(\"" + reader2["username"].ToString() + "\")>消息</a>][<a href=\"javascript:void(0)\" onclick=\"openemail('" + reader2["username"].ToString() + "')\" title='" + reader2["States"].ToString() + "：" + reader2["Shuoming"].ToString() + "' target='rform'>邮件</a>]";
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
            string sql = "select * from qp_oa_Bumen ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.showtitle = "";
            }
            else
            {
                this.showtitle = "没有设置部门";
            }
            list.Close();
        }
    }
}


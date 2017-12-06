namespace xyoa.SchTable.Paike
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Jiaoshi_left : Page
    {
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = "select Name,RkUsername from qp_sch_Kecheng order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["Name"].ToString();
                child.ImageUrl = "/oaimg/menu/organise.gif";
                child.Text = "" + list["Name"].ToString() + "";
                child.SelectAction = TreeNodeSelectAction.Expand;
                child.Expanded = false;
                Nds.Add(child);
                string str2 = "select Username,Realname from [qp_oa_Username]  where   '%" + list["RkUsername"].ToString() + "%' like '%'+Username+'%'  and  ifdel='0' order by paixu asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    TreeNode node2 = new TreeNode();
                    node2.Value = reader2["Username"].ToString();
                    node2.ImageUrl = "/oaimg/menu/Menu37.gif";
                    node2.Text = "<a href='Jiaoshi_Pk.aspx?LsUsername=" + reader2["Username"].ToString() + "&LsRealname=" + reader2["Realname"].ToString() + "' target='nextrform'><font color=blue>" + reader2["Realname"].ToString() + "</font></a>";
                    node2.SelectAction = TreeNodeSelectAction.Expand;
                    node2.Expanded = true;
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
                this.Label1.Text = this.divsch.GetXueqi();
                this.BindTree(this.ListTreeView.Nodes);
            }
        }
    }
}


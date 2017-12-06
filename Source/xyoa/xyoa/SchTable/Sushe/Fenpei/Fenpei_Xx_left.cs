namespace xyoa.SchTable.Sushe.Fenpei
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Fenpei_Xx_left : Page
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
            string sql = "select NianjiMc from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Label1.Text + "' order by Num asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["NianjiMc"].ToString();
                child.ImageUrl = "/oaimg/menu/Menu35.gif";
                child.Text = "" + list["NianjiMc"].ToString() + "";
                child.SelectAction = TreeNodeSelectAction.Expand;
                child.Expanded = true;
                Nds.Add(child);
                string str2 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Label1.Text, "' and Nianji='", list["NianjiMc"], "' order by Mingcheng asc" });
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    TreeNode node2 = new TreeNode();
                    node2.Value = reader2["ID"].ToString();
                    int num = int.Parse(reader2["ID"].ToString());
                    node2.ImageUrl = "/oaimg/menu/Menu37.gif";
                    if (base.Request.QueryString["url"].ToString() == "1")
                    {
                        node2.Text = string.Concat(new object[] { "<a href='Fenpei_Xx_Wfp.aspx?id=", num, "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                    }
                    if (base.Request.QueryString["url"].ToString() == "2")
                    {
                        node2.Text = string.Concat(new object[] { "<a href='Fenpei_Xx_Yfp.aspx?id=", num, "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                    }
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
                TreeNode child = new TreeNode();
                child.ImageUrl = "/oaimg/menu/zhu.gif";
                if (base.Request.QueryString["url"].ToString() == "1")
                {
                    child.Text = "<a href='Fenpei_Xx_Wfp.aspx?id=all' target='nextrform'><font color=blue>全部班级</font></a>";
                }
                if (base.Request.QueryString["url"].ToString() == "2")
                {
                    child.Text = "<a href='Fenpei_Xx_Yfp.aspx?id=all' target='nextrform'><font color=blue>全部班级</font></a>";
                }
                child.SelectAction = TreeNodeSelectAction.None;
                child.Expanded = false;
                this.ListTreeView.Nodes.Add(child);
                this.BindTree(this.ListTreeView.Nodes);
            }
        }
    }
}


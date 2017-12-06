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

    public class Fenpei_Ss_left : Page
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
            string sql = "select id,Mingcheng,Loucheng from qp_sch_Gongyu as [A]  order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["Mingcheng"].ToString();
                child.ImageUrl = "/oaimg/menu/organise.gif";
                child.Text = "" + list["Mingcheng"].ToString() + "";
                child.SelectAction = TreeNodeSelectAction.Expand;
                child.Expanded = false;
                Nds.Add(child);
                for (int i = 1; i <= int.Parse(list["Loucheng"].ToString()); i++)
                {
                    TreeNode node2 = new TreeNode();
                    node2.Value = "" + i + "";
                    node2.ImageUrl = "/oaimg/menu/Menu35.gif";
                    node2.Text = "" + i + "楼";
                    node2.SelectAction = TreeNodeSelectAction.Expand;
                    node2.Expanded = false;
                    child.ChildNodes.Add(node2);
                    string str2 = string.Concat(new object[] { "select A.id,Bianhao+'(剩'+convert(varchar(10),Zuowei-Yiyong)+')' as Bianhao,Zuowei,Yiyong  from [qp_sch_Sushe] as [A] where  A.JianzhuId='", list["id"], "' and Louceng='", i, "' order by id asc" });
                    SqlDataReader reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        TreeNode node3 = new TreeNode();
                        node3.Value = reader2["ID"].ToString();
                        int num2 = int.Parse(reader2["ID"].ToString());
                        node3.ImageUrl = "/oaimg/menu/Menu37.gif";
                        if (base.Request.QueryString["url"].ToString() == "1")
                        {
                            node3.Text = string.Concat(new object[] { "<a href='Fenpei_Ss_Wfp.aspx?id=", num2, "' target='nextrform'><font color=blue>", reader2["Bianhao"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "2")
                        {
                            node3.Text = string.Concat(new object[] { "<a href='Fenpei_Ss_Yfp.aspx?id=", num2, "' target='nextrform'><font color=blue>", reader2["Bianhao"].ToString(), "</font></a>" });
                        }
                        node3.SelectAction = TreeNodeSelectAction.Expand;
                        node3.Expanded = true;
                        node2.ChildNodes.Add(node3);
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
                this.BindTree(this.ListTreeView.Nodes);
            }
        }
    }
}


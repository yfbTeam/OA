namespace xyoa.SchTable.Xueji.Richang
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Richang_left : Page
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
            string sql = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Label1.Text + "' order by Num asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode node;
                string str2;
                SqlDataReader reader2;
                TreeNode node2;
                int num;
                string str3;
                string str4;
                string str5;
                if (base.Request.QueryString["url"].ToString() == "3")
                {
                    if (list["RuxueBiye"].ToString() == "毕业")
                    {
                        node = new TreeNode();
                        node.Value = list["NianjiMc"].ToString();
                        node.ImageUrl = "/oaimg/menu/Menu35.gif";
                        node.Text = "" + list["NianjiMc"].ToString() + "";
                        node.SelectAction = TreeNodeSelectAction.Expand;
                        node.Expanded = true;
                        Nds.Add(node);
                        str2 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Label1.Text, "' and Nianji='", list["NianjiMc"], "' order by Mingcheng asc" });
                        reader2 = this.List.GetList(str2);
                        while (reader2.Read())
                        {
                            node2 = new TreeNode();
                            node2.Value = reader2["ID"].ToString();
                            num = int.Parse(reader2["ID"].ToString());
                            node2.ImageUrl = "/oaimg/menu/Menu37.gif";
                            str3 = reader2["BzUsername"].ToString();
                            str4 = "," + reader2["RkUsername"].ToString() + ",";
                            str5 = "," + reader2["XldUsername"].ToString() + ",";
                            if (((str4.IndexOf("," + this.Session["Username"] + ",") >= 0) || (str5.IndexOf("," + this.Session["Username"] + ",") >= 0)) || (str3 == ("" + this.Session["Username"] + "")))
                            {
                                if (base.Request.QueryString["url"].ToString() == "1")
                                {
                                    node2.Text = string.Concat(new object[] { "<a href='Richang_Sdlt.aspx?id=", num, "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                                }
                                if (base.Request.QueryString["url"].ToString() == "2")
                                {
                                    node2.Text = string.Concat(new object[] { "<a href='Richang_PlSdlt.aspx?id=", num, "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                                }
                                if (base.Request.QueryString["url"].ToString() == "3")
                                {
                                    node2.Text = string.Concat(new object[] { "<a href='Richang_By.aspx?id=", num, "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                                }
                            }
                            else
                            {
                                node2.Text = "<font color=#999999>" + reader2["Mingcheng"].ToString() + "</font>";
                            }
                            node2.SelectAction = TreeNodeSelectAction.Expand;
                            node2.Expanded = true;
                            node.ChildNodes.Add(node2);
                        }
                        reader2.Close();
                    }
                }
                else
                {
                    node = new TreeNode();
                    node.Value = list["NianjiMc"].ToString();
                    node.ImageUrl = "/oaimg/menu/Menu35.gif";
                    node.Text = "" + list["NianjiMc"].ToString() + "";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = true;
                    Nds.Add(node);
                    str2 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Label1.Text, "' and Nianji='", list["NianjiMc"], "' order by Mingcheng asc" });
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        node2 = new TreeNode();
                        node2.Value = reader2["ID"].ToString();
                        num = int.Parse(reader2["ID"].ToString());
                        node2.ImageUrl = "/oaimg/menu/Menu37.gif";
                        str3 = reader2["BzUsername"].ToString();
                        str4 = "," + reader2["RkUsername"].ToString() + ",";
                        str5 = "," + reader2["XldUsername"].ToString() + ",";
                        if (((str4.IndexOf("," + this.Session["Username"] + ",") >= 0) || (str5.IndexOf("," + this.Session["Username"] + ",") >= 0)) || (str3 == ("" + this.Session["Username"] + "")))
                        {
                            if (base.Request.QueryString["url"].ToString() == "1")
                            {
                                node2.Text = string.Concat(new object[] { "<a href='Richang_Sdlt.aspx?id=", num, "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                            }
                            if (base.Request.QueryString["url"].ToString() == "2")
                            {
                                node2.Text = string.Concat(new object[] { "<a href='Richang_PlSdlt.aspx?id=", num, "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                            }
                            if (base.Request.QueryString["url"].ToString() == "3")
                            {
                                node2.Text = string.Concat(new object[] { "<a href='Richang_By.aspx?id=", num, "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                            }
                        }
                        else
                        {
                            node2.Text = "<font color=#999999>" + reader2["Mingcheng"].ToString() + "</font>";
                        }
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


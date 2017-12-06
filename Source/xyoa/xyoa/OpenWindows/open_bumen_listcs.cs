namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_bumen_listcs : Page
    {
        protected Button bbb1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        protected Label Message;
        protected Label Message1;
        private publics pulicss = new publics();

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string sql = "select id,Name,ParentNodesID from qp_oa_Bumen where ParentNodesID=" + IDStr.ToString() + " order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode node;
                int num;
                string str2;
                string str3;
                if (IDStr == 0)
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/Menu49.gif";
                    node.Text = "" + list["Name"].ToString() + "";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = false;
                    node.ShowCheckBox = true;
                    str2 = "," + base.Request.QueryString["requeststr"].ToString() + ",";
                    str3 = "," + node.Value + ",";
                    if (str2.IndexOf(str3) < 0)
                    {
                        node.Checked = false;
                    }
                    else
                    {
                        node.Checked = true;
                    }
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                }
                else
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/Menu49.gif";
                    node.Text = "" + list["Name"].ToString() + "";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = false;
                    node.ShowCheckBox = true;
                    str2 = "," + base.Request.QueryString["requeststr"].ToString() + ",";
                    str3 = "," + node.Value + ",";
                    if (str2.IndexOf(str3) < 0)
                    {
                        node.Checked = false;
                    }
                    else
                    {
                        node.Checked = true;
                    }
                    Nds.Add(node);
                    this.BindTree(Nds[Nds.Count - 1].ChildNodes, num);
                }
            }
            list.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.ListTreeView.CheckedNodes.Count > 0)
            {
                this.Message.Text = "";
                this.Message1.Text = "";
                foreach (TreeNode node in this.ListTreeView.CheckedNodes)
                {
                    this.Message.Text = this.Message.Text + node.Value + ",";
                    this.Message1.Text = this.Message1.Text + node.Text + ",";
                }
            }
            else
            {
                this.Message.Text = "";
                this.Message1.Text = "";
            }
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'>sendFromChild('" + this.Message.Text + "','" + this.Message1.Text + "');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.BindTree(this.ListTreeView.Nodes, 0);
                string sql = "select id from qp_oa_Bumen ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Label1.Text = "";
                }
                else
                {
                    this.Label1.Text = "无相关部门";
                }
                list.Close();
                this.ListTreeView.Attributes.Add("OnClick", "OnTreeNodeChecked()");
            }
        }
    }
}


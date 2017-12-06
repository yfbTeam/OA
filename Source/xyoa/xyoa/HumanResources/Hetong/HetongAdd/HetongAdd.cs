namespace xyoa.HumanResources.Hetong.HetongAdd
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongAdd : Page
    {
        protected Button Button1;
        protected TextBox ContractContent;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox HetongZdId;
        protected Label Label1;
        protected DropDownList LeibieID;
        protected LinkButton LinkButton2;
        protected LinkButton LinkButton3;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        protected TextBox QdTime;
        protected DropDownList Qixian;
        protected TextBox Starttime;
        protected TextBox TextBox1;

        private void BindStrhtm(string IDStr)
        {
            this.TextBox1.Text = null;
            string sql = "select * from qp_hr_HetongMB where  id='" + IDStr + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.TextBox1.Text = list["Neirong"].ToString().Replace("disabled=\"disabled\"", "").Replace("disabled", "");
            }
            list.Close();
        }

        private void BindTree2(TreeNodeCollection Nds, int IDStr)
        {
            this.LinkButton2.ForeColor = Color.Blue;
            this.LinkButton3.ForeColor = Color.Black;
            string sql = "select id,Name,ParentNodesID from qp_oa_Bumen where ParentNodesID=" + IDStr.ToString() + "   order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode node;
                int num;
                string str2;
                SqlDataReader reader2;
                string str3;
                SqlDataReader reader3;
                TreeNode node2;
                if (IDStr == 0)
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/zhu.gif";
                    node.Text = "<font color=#000000>" + list["Name"].ToString() + "</font>";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = true;
                    Nds.Add(node);
                    this.BindTree2(Nds[Nds.Count - 1].ChildNodes, num);
                    str2 = "select A.id,A.username, A.realname,A.lasttime  from [qp_oa_username] as [A]  where [A].[BuMenId]='" + list["ID"].ToString() + "' and  ifdel='0' and StardType='1' order by A.id asc";
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        str3 = "select id from [qp_hr_HetongMg] as [A] where [A].[LeibieID]='" + this.LeibieID.SelectedValue + "' and QyUsername='" + reader2["username"].ToString() + "' and Zhuangtai=1";
                        reader3 = this.List.GetList(str3);
                        if (reader3.Read())
                        {
                            node2 = new TreeNode();
                            node2.Value = reader2["username"].ToString();
                            node2.ImageUrl = "/oaimg/menu/on1.gif";
                            node2.Text = "" + reader2["realname"].ToString() + "";
                            node2.SelectAction = TreeNodeSelectAction.Expand;
                            node2.Expanded = true;
                            node.ChildNodes.Add(node2);
                            node2.ShowCheckBox = false;
                        }
                        reader3.Close();
                    }
                    reader2.Close();
                }
                else
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/homepage.gif";
                    node.Text = "<font color=#000000>" + list["Name"].ToString() + "</font>";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = true;
                    Nds.Add(node);
                    this.BindTree2(Nds[Nds.Count - 1].ChildNodes, num);
                    str2 = "select A.id,A.username, A.realname,A.lasttime  from [qp_oa_username] as [A] where [A].[BuMenId]='" + list["ID"].ToString() + "' and  ifdel='0' and StardType='1' order by A.id asc";
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        str3 = "select id from [qp_hr_HetongMg] as [A] where [A].[LeibieID]='" + this.LeibieID.SelectedValue + "' and QyUsername='" + reader2["username"].ToString() + "' and Zhuangtai=1";
                        reader3 = this.List.GetList(str3);
                        if (reader3.Read())
                        {
                            node2 = new TreeNode();
                            node2.Value = reader2["username"].ToString();
                            node2.ImageUrl = "/oaimg/menu/on1.gif";
                            node2.Text = "" + reader2["realname"].ToString() + "";
                            node2.SelectAction = TreeNodeSelectAction.Expand;
                            node2.Expanded = true;
                            node.ChildNodes.Add(node2);
                            node2.ShowCheckBox = false;
                        }
                        reader3.Close();
                    }
                    reader2.Close();
                }
            }
            list.Close();
        }

        private void BindTree3(TreeNodeCollection Nds, int IDStr)
        {
            this.LinkButton2.ForeColor = Color.Black;
            this.LinkButton3.ForeColor = Color.Blue;
            string sql = "select id,Name,ParentNodesID from qp_oa_Bumen where ParentNodesID=" + IDStr.ToString() + "   order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode node;
                int num;
                string str2;
                SqlDataReader reader2;
                string str3;
                SqlDataReader reader3;
                TreeNode node2;
                if (IDStr == 0)
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/zhu.gif";
                    node.Text = "<font color=#000000>" + list["Name"].ToString() + "</font>";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = true;
                    Nds.Add(node);
                    this.BindTree3(Nds[Nds.Count - 1].ChildNodes, num);
                    str2 = "select A.id,A.username, A.realname,A.lasttime  from [qp_oa_username] as [A]  where [A].[BuMenId]='" + list["ID"].ToString() + "' and  ifdel='0' and StardType='1' order by A.id asc";
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        str3 = "select id from [qp_hr_HetongMg] as [A] where [A].[LeibieID]='" + this.LeibieID.SelectedValue + "' and QyUsername='" + reader2["username"].ToString() + "' and Zhuangtai=1";
                        reader3 = this.List.GetList(str3);
                        if (!reader3.Read())
                        {
                            node2 = new TreeNode();
                            node2.Value = reader2["username"].ToString();
                            node2.Text = "" + reader2["realname"].ToString() + "";
                            node2.SelectAction = TreeNodeSelectAction.Expand;
                            node2.Expanded = true;
                            node.ChildNodes.Add(node2);
                            node2.ShowCheckBox = true;
                        }
                        reader3.Close();
                    }
                    reader2.Close();
                }
                else
                {
                    node = new TreeNode();
                    node.Value = list["ID"].ToString();
                    num = int.Parse(list["ID"].ToString());
                    node.ImageUrl = "/oaimg/menu/homepage.gif";
                    node.Text = "<font color=#000000>" + list["Name"].ToString() + "</font>";
                    node.SelectAction = TreeNodeSelectAction.Expand;
                    node.Expanded = true;
                    Nds.Add(node);
                    this.BindTree3(Nds[Nds.Count - 1].ChildNodes, num);
                    str2 = "select A.id,A.username, A.realname,A.lasttime  from [qp_oa_username] as [A] where [A].[BuMenId]='" + list["ID"].ToString() + "' and  ifdel='0' and StardType='1' order by A.id asc";
                    reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        str3 = "select id from [qp_hr_HetongMg] as [A] where [A].[LeibieID]='" + this.LeibieID.SelectedValue + "' and QyUsername='" + reader2["username"].ToString() + "' and Zhuangtai=1";
                        reader3 = this.List.GetList(str3);
                        if (!reader3.Read())
                        {
                            node2 = new TreeNode();
                            node2.Value = reader2["username"].ToString();
                            node2.Text = "" + reader2["realname"].ToString() + "";
                            node2.SelectAction = TreeNodeSelectAction.Expand;
                            node2.Expanded = true;
                            node.ChildNodes.Add(node2);
                            node2.ShowCheckBox = true;
                        }
                        reader3.Close();
                    }
                    reader2.Close();
                }
            }
            list.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.ListTreeView.CheckedNodes.Count > 0)
            {
                foreach (TreeNode node in this.ListTreeView.CheckedNodes)
                {
                    string sql = "insert into qp_hr_HetongMg  (Qixian,QdTime,LeibieID,QyUsername,QyRealname,Neirong,Starttime,Endtime,Zhuangtai) values ('" + this.Qixian.SelectedValue + "','" + this.QdTime.Text + "','" + this.LeibieID.SelectedValue + "','" + node.Value + "','" + node.Text + "','" + this.pulicss.GetFormatStrbjq(this.ContractContent.Text) + "','" + this.pulicss.GetFormatStr(this.Starttime.Text) + "','" + this.pulicss.GetFormatStr(this.Endtime.Text) + "','1')";
                    this.List.ExeSql(sql);
                    string str2 = "select top 1 id from qp_hr_HetongMg where  LeibieID='" + this.LeibieID.SelectedValue + "' order by id desc";
                    SqlDataReader list = this.List.GetList(str2);
                    if (list.Read())
                    {
                        this.divhr.Insertlsz(list["id"].ToString(), "1", "HumanResources/Hetong/HetongMg/HetongMg_show_lsz.aspx?id=" + list["id"].ToString() + "");
                        string str3 = "select  * from qp_hr_HetongZd where LeibieID='" + this.HetongZdId.Text + "' order by id asc";
                        SqlDataReader reader2 = this.List.GetList(str3);
                        while (reader2.Read())
                        {
                            string str4 = string.Concat(new object[] { "insert into qp_hr_HetongMgFile (HetongID,ZdBianhao,Neirong) values ('", list["id"], "','", reader2["Bianhao"], "','", base.Request.Form["" + reader2["Bianhao"] + ""], "')" });
                            this.List.ExeSql(str4);
                        }
                        reader2.Close();
                    }
                    list.Close();
                    this.pulicss.InsertLog("[" + node.Text + "]新签[" + this.LeibieID.SelectedItem.Text + "]", "合同新签");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='HetongAdd.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请选择需要签约的人员！');</script>");
            }
        }

        protected void LeibieID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LeibieID.SelectedValue == "")
            {
                this.ListTreeView.Visible = false;
                this.Label1.Text = "请选择右边的“签约合同”";
            }
            else
            {
                this.ListTreeView.Visible = true;
                this.Label1.Text = "";
            }
            this.ListTreeView.Nodes.Clear();
            this.BindTree3(this.ListTreeView.Nodes, 0);
            this.BindStrhtm(this.LeibieID.SelectedValue);
            string sql = "select LeibieID from qp_hr_HetongMB where  id='" + this.LeibieID.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.HetongZdId.Text = list["LeibieID"].ToString();
            }
            list.Close();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            this.ListTreeView.Nodes.Clear();
            this.BindTree2(this.ListTreeView.Nodes, 0);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            this.ListTreeView.Nodes.Clear();
            this.BindTree3(this.ListTreeView.Nodes, 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
                string sQL = "select id,Mingcheng from qp_hr_HetongMB where Zhuangtai=1 order by id asc";
                this.list.Bind_DropDownList_kong(this.LeibieID, sQL, "id", "Mingcheng");
                this.BindTree3(this.ListTreeView.Nodes, 0);
                this.BindStrhtm("0");
                this.QdTime.Text = DateTime.Now.ToShortDateString();
                if (this.LeibieID.SelectedValue == "")
                {
                    this.ListTreeView.Visible = false;
                    this.Label1.Text = "请选择右边的“签约合同”";
                }
                else
                {
                    this.ListTreeView.Visible = true;
                    this.Label1.Text = "";
                }
            }
        }
    }
}


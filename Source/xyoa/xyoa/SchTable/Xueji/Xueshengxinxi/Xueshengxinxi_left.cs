namespace xyoa.SchTable.Xueji.Xueshengxinxi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueshengxinxi_left : Page
    {
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = "select NianjiMc from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.divsch.GetXueqi() + "' order by Num asc";
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
                string str2 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.divsch.GetXueqi(), "' and Nianji='", list["NianjiMc"], "' order by Mingcheng asc" });
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    TreeNode node2 = new TreeNode();
                    node2.Value = reader2["ID"].ToString();
                    int num = int.Parse(reader2["ID"].ToString());
                    node2.ImageUrl = "/oaimg/menu/Menu37.gif";
                    string str3 = reader2["BzUsername"].ToString();
                    string str4 = "," + reader2["RkUsername"].ToString() + ",";
                    string str5 = "," + reader2["XldUsername"].ToString() + ",";
                    if (((str4.IndexOf("," + this.Session["Username"] + ",") >= 0) || (str5.IndexOf("," + this.Session["Username"] + ",") >= 0)) || (str3 == ("" + this.Session["Username"] + "")))
                    {
                        if (base.Request.QueryString["url"].ToString() == "1")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_jtxx.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "2")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_xxjl.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "3")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_jspy.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "4")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_hjqk.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "5")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_cfqk.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "6")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_rzqk.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "7")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_jxqk.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "8")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_wthd.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "9")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_shsj.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "10")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_tjxx.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "11")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_jfxx.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "12")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_qtxx.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                        if (base.Request.QueryString["url"].ToString() == "13")
                        {
                            node2.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_kscj.aspx?id=", num, "&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>", reader2["Mingcheng"].ToString(), "</font></a>" });
                        }
                    }
                    else
                    {
                        node2.Text = "<font color=#999999>" + reader2["Mingcheng"].ToString() + "</font>";
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
                this.ViewState["Xueqi"] = this.divsch.GetXueqi();
                this.ViewState["Xueduan"] = this.divsch.GetXueduan();
                TreeNode child = new TreeNode();
                child.ImageUrl = "/oaimg/menu/zhu.gif";
                if (base.Request.QueryString["url"].ToString() == "1")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_jtxx.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "2")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_xxjl.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "3")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_jspy.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "4")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_hjqk.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "5")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_cfqk.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "6")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_rzqk.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "7")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_jxqk.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "8")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_wthd.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "9")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_shsj.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "10")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_tjxx.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "11")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_jfxx.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "12")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_qtxx.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                if (base.Request.QueryString["url"].ToString() == "13")
                {
                    child.Text = string.Concat(new object[] { "<a href='Xueshengxinxi_kscj.aspx?id=all&Xueqi=", this.ViewState["Xueqi"], "&Xueduan=", this.ViewState["Xueduan"], "' target='nextrform'><font color=blue>全部班级</font></a>" });
                }
                child.SelectAction = TreeNodeSelectAction.None;
                child.Expanded = false;
                this.ListTreeView.Nodes.Add(child);
                this.BindTree(this.ListTreeView.Nodes);
            }
        }
    }
}


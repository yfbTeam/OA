namespace xyoa.SchTable.Chengji.Chaxun
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Chaxun_leftNj : Page
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
                TreeNode child = new TreeNode();
                child.Value = list["NianjiMc"].ToString();
                child.ImageUrl = "/oaimg/menu/Menu35.gif";
                child.Text = "<a href='Chaxun_ListNj.aspx?id=" + list["NianjiMc"].ToString() + "' target='nextrform'><font color=blue>" + list["NianjiMc"].ToString() + "</font></a>";
                child.SelectAction = TreeNodeSelectAction.Expand;
                child.Expanded = true;
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
                this.Label1.Text = this.divsch.GetXueqi();
                this.BindTree(this.ListTreeView.Nodes);
            }
        }
    }
}


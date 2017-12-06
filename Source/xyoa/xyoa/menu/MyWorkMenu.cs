namespace xyoa.menu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWorkMenu : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TreeView TreeView9;

        protected void BindTheTree(TreeNodeCollection Nds, string UserPerStr)
        {
            for (int i = 0; i < Nds.Count; i++)
            {
                if (!this.StrIFInStr(Nds[i].Value.ToString(), UserPerStr))
                {
                    Nds.Remove(Nds[i]);
                    i--;
                }
                else
                {
                    this.BindTheTree(Nds[i].ChildNodes, UserPerStr);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string userPerStr = this.Session["perstr"].ToString();
            this.BindTheTree(this.TreeView9.Nodes, userPerStr);
            base.Response.Write("<!--\n当前合法使用单位：[" + this.Session["cdk1"] + "]，若使用单位名称与您所在单位名称不符合有可能为盗版软件，请立即联系开发商，以免给您和您单位带来不必要的损失。\n-->");
        }

        private bool StrIFInStr(string Str1, string Str2)
        {
            if (Str2.IndexOf(Str1) < 0)
            {
                return false;
            }
            return true;
        }
    }
}


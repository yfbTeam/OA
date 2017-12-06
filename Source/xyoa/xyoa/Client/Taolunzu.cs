namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Taolunzu : Page
    {
        public static string cssstr;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = string.Concat(new object[] { "select * from qp_oa_Taolunzu  where Zhuangtai='1' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", base.Request.QueryString["user"].ToString(), ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))  order by Paixun asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/Choose32.gif";
                string str2 = string.Concat(new object[] { "select Weidu from qp_oa_TaolunzuRy  where Keyid='", list["id"], "' and Username='", this.Session["username"], "' " });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    child.Text = "<a href=\"javascript:void(0)\" onclick=openwindows(\"/InfoManage/Taolunzu/TaolunzuLogin.aspx?id=" + list["id"].ToString() + "\")><font color=#000000>" + list["Name"].ToString() + "</font>(" + reader2["Weidu"].ToString() + ")</a>";
                }
                else
                {
                    child.Text = "<a href=\"javascript:void(0)\" onclick=openwindows(\"/InfoManage/Taolunzu/TaolunzuLogin.aspx?id=" + list["id"].ToString() + "\")><font color=#000000>" + list["Name"].ToString() + "</font>(0)</a>";
                }
                reader2.Close();
                child.SelectAction = TreeNodeSelectAction.None;
                child.Expanded = false;
                Nds.Add(child);
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Session["yangshi"] = this.pulicss.Getyangshi();
                string str = FormsAuthentication.HashPasswordForStoringInConfigFile(base.Request.QueryString["pwd"].ToString(), "MD5");
                string sql = "select BuMenId from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "' and Password='" + str + "'and Iflogin='1'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Session["BuMenId"] = list["BuMenId"].ToString();
                    list.Close();
                    this.BindTree(this.ListTreeView.Nodes);
                }
                else
                {
                    list.Close();
                    base.Response.Redirect("LoginMenu.aspx");
                }
            }
        }
    }
}


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

    public class mymeunclient : Page
    {
        public static string cssstr;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TreeView TreeView9;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = string.Concat(new object[] { "select * from qp_oa_MenuQx  where ifmenu=1  and CHARINDEX(quanbu,(select content from qp_oa_Menu where Username='", this.Session["username"], "')) > 0 and  (CHARINDEX(quanbu,'", this.Session["perstr"], "') > 0 and ifopen='1') order by paixu asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Text = "<a href='javascript:void(0)'  onclick=openwindows('" + list["urlname"].ToString() + "')>" + list["name"].ToString() + "</a>";
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/" + list["picname"].ToString() + "";
                child.Expanded = true;
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
                string sql = "select Username,ResponQx from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "' and Password='" + str + "'and Iflogin='1'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Session["Username"] = list["Username"].ToString();
                    this.Session["perstr"] = list["ResponQx"].ToString();
                    list.Close();
                    this.BindTree(this.TreeView9.Nodes);
                }
                else
                {
                    base.Response.Redirect("LoginMenu.aspx");
                }
            }
        }
    }
}


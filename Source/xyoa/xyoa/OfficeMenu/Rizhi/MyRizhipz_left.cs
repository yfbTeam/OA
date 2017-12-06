namespace xyoa.OfficeMenu.Rizhi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRizhipz_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = "select username,realname from qp_oa_Username where  CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_Rizhisz where ZgUsername='" + this.Session["username"] + "')+',') > 0    order by paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["username"].ToString();
                child.ImageUrl = "/oaimg/menu/on1.gif";
                child.Text = " <a href='MyRizhipz_list.aspx?user=" + list["username"].ToString() + "' target='nextrform'>" + list["realname"].ToString() + "</a>";
                child.SelectAction = TreeNodeSelectAction.None;
                child.Expanded = false;
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
                this.BindTree(this.ListTreeView.Nodes);
                string sql = "select username,realname from qp_oa_Username where  CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_MyPlanSz where ZgUsername='" + this.Session["username"] + "')+',') > 0   order by paixu asc";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.showtitle = "";
                }
                else
                {
                    this.showtitle = "未找到可以监控的人员";
                }
                list.Close();
            }
        }
    }
}


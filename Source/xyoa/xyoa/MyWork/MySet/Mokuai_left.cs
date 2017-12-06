namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Mokuai_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = "select leixing,urlname from qp_oa_AllUrl where ParentNodesID='0' and  (CHARINDEX(quanxian,'" + this.Session["perstr"] + "') > 0 and ifopen='1') order by paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["leixing"].ToString();
                int num = int.Parse(list["leixing"].ToString());
                child.ImageUrl = "/oaimg/menu/Choose32.gif";
                if (list["leixing"].ToString() == "11")
                {
                    child.Text = " <a href='MokuaiKz_show.aspx?menhu=" + base.Request.QueryString["menhu"] + "&leixing=2' target='nextrform'>" + list["urlname"].ToString() + "</a>";
                }
                else if (list["leixing"].ToString() == "12")
                {
                    child.Text = " <a href='MokuaiMh_show.aspx?menhu=" + base.Request.QueryString["menhu"] + "&leixing=3' target='nextrform'>" + list["urlname"].ToString() + "</a>";
                }
                else
                {
                    child.Text = string.Concat(new object[] { " <a href='Mokuai_show.aspx?id=", num, "&menhu=", base.Request.QueryString["menhu"], "&leixing=1' target='nextrform'>", list["urlname"].ToString(), "</a>" });
                }
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
                string sql = "select * from qp_oa_AllUrl";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.showtitle = "";
                }
                else
                {
                    this.showtitle = "没有对应栏目";
                }
                list.Close();
            }
        }
    }
}


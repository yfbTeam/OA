﻿namespace xyoa.PublicWork.Zhidu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Zhidu_left : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();
        public string showtitle;

        private void BindTree(TreeNodeCollection Nds)
        {
            string sql = "select * from qp_oa_ZhiduLx  order by Paixun asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/Choose32.gif";
                child.Text = string.Concat(new object[] { " <a href='Zhidu_show.aspx?id=", num, "' target='nextrform'>", list["Name"].ToString(), "</a>" });
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
                this.pulicss.QuanXianVis(this.ListTreeView, "jjjj6b", this.Session["perstr"].ToString());
                string sql = "select * from qp_oa_ZhiduLx";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.showtitle = "";
                }
                else
                {
                    this.showtitle = "请先在“制度目录”中增加";
                }
                list.Close();
            }
        }
    }
}


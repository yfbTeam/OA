﻿namespace xyoa.Resources.ResReport
{
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Info_left : Page
    {
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TreeView ListTreeView;
        private publics pulicss = new publics();

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string sql = "select id,urlname,url,pic,quanxian,SelectAction from qp_oa_AllUrl where (CHARINDEX(''+quanxian+'','" + this.ViewState["qxstr"] + "')   >   0 ) and ParentNodesID='199' order by Paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                TreeNode child = new TreeNode();
                child.Value = list["ID"].ToString();
                int num = int.Parse(list["ID"].ToString());
                child.ImageUrl = "/oaimg/menu/" + list["pic"].ToString() + "";
                if (list["SelectAction"].ToString() == "Expand")
                {
                    child.Text = "" + list["urlname"].ToString() + "";
                }
                else
                {
                    child.Text = " <a href='" + list["url"].ToString() + "' target='nextrform'>" + list["urlname"].ToString() + "</a>";
                }
                child.SelectAction = TreeNodeSelectAction.Expand;
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
                this.ViewState["qxstr"] = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
                this.BindTree(this.ListTreeView.Nodes, 0xc7);
                this.pulicss.QuanXianVis(this.ListTreeView, "bbbb3", this.Session["perstr"].ToString());
            }
        }
    }
}


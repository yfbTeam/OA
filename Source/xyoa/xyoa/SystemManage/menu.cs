﻿namespace xyoa.SystemManage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class menu : Page
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

        public string GetInterIDList(string strfile)
        {
            string str = "";
            if (!File.Exists(HttpContext.Current.Server.MapPath(strfile)))
            {
                return str;
            }
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(strfile), Encoding.Default);
            string str2 = reader.ReadToEnd();
            reader.Close();
            return str2;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string userPerStr = this.Session["perstr"].ToString();
            this.BindTheTree(this.TreeView9.Nodes, userPerStr);
            if (!this.Page.IsPostBack)
            {
            }
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

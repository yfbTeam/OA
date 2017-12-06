namespace xyoa.Client
{
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class treelist : Page
    {
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
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
            if (!this.Page.IsPostBack)
            {
                this.Session["yangshi"] = this.pulicss.Getyangshi();
                string str = FormsAuthentication.HashPasswordForStoringInConfigFile(base.Request.QueryString["pwd"].ToString(), "MD5");
                string sql = "select Username,ResponQx from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "' and Password='" + str + "'and Iflogin='1'  ";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    this.Session["Username"] = reader["Username"].ToString();
                    this.Session["perstr"] = reader["ResponQx"].ToString();
                }
                else
                {
                    base.Response.Redirect("Login.aspx");
                    return;
                }
                reader.Close();
            }
            string userPerStr = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
            this.BindTheTree(this.TreeView9.Nodes, userPerStr);
            if (!this.Page.IsPostBack)
            {
             //   string str4 = "select * from qp_oa_filemain where reg='0' or reg='1' or reg='2'";
             //   SqlDataReader reader2 = this.List.GetList(str4);
              //  if (reader2.Read())
                {
               //     try
                    {
                //        string str5 = null;
                 //       str5 = this.pulicss.DESDecrypt(reader2["cdkstr"].ToString(), "5", "6");
                  //      ArrayList list = new ArrayList();
                  //      string[] strArray = str5.Split(new char[] { '^' });
                  //      for (int i = 0; i < strArray.Length; i++)
                        {
                 //           this.ViewState["cdk5"] = strArray[4];
                  //          this.Session["cdk8"] = strArray[8];
                        }
                    }
               //     catch
                    {
                 //       return;
                    }
                 //   reader2.Close();
                    TreeNode child = new TreeNode();
                    child.ImageUrl = "/oaimg/menu/Menu3.gif";
                    child.Text = string.Concat(new object[] { "<a href=\"javascript:;;\" onclick=\"openwindowshelp()\">OA使用帮助</a>" });
                    child.SelectAction = TreeNodeSelectAction.None;
                    child.Expanded = false;
                    this.TreeView9.Nodes.Add(child);
              //      if (this.Session["cdk8"].ToString() == "1")
                    {
                        this.TreeView9.Visible = true;
                        this.Label1.Text = null;
                    }
              //      else
                    {
                 //       this.TreeView9.Visible = false;
                  //      this.Label1.Text = "OA助手未开通";
                    }
                }
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


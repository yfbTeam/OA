namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Document_online : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.ViewState["realname"] = this.Session["realname"].ToString();
                if (!base.IsPostBack)
                {
                    string sql = "select * from qp_oa_MyWebDiskFile  where id='" + base.Request.QueryString["id"] + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.ViewState["forname"] = list["OldName"].ToString();
                        this.ViewState["forfile"] = list["NewName"].ToString();
                    }
                    list.Close();
                    string str2 = string.Concat(new object[] { "insert into qp_oa_MyWebDiskLog  (KeyId,Username,Realname,SetTime,Contents,BuMenId) values ('", base.Request.QueryString["id"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','阅读文件','", this.Session["BuMenId"], "')" });
                    this.List.ExeSql(str2);
                }
            }
        }
    }
}


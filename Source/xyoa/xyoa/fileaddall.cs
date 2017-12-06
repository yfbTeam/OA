namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class fileaddall : Page
    {
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected TextBox OldName;
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string extension = Path.GetExtension(base.Request.QueryString["NewName"].ToString());
            string sql = "select * from qp_oa_filetype   where name='" + extension + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["name"].ToString().Replace(".", "");
            }
            else
            {
                str = "unknow";
            }
            list.Close();
            string str4 = string.Concat(new object[] { "insert into qp_oa_Paper (FoldersID,Username,Realname,OldName,NewName,NowTimes,Fjtype) values ('", this.ParentNodesID.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "','", this.OldName.Text, "','", base.Request.QueryString["NewName"], "','", DateTime.Now.ToString(), "','", str, "')" });
            this.List.ExeSql(str4);
            base.Response.Write("<script language=javascript>alert('提交成功！'); window.close();</script>");
            this.pulicss.InsertLog("转存文件" + this.OldName.Text + "", "转存文件");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if (base.Request.QueryString["NewName"] == null)
                {
                    base.Response.Write("<script language=javascript>alert('未找到文件！'); window.close();</script>");
                }
                else if (base.Request.QueryString["NewName"] == "")
                {
                    base.Response.Write("<script language=javascript>alert('未找到文件！'); window.close();</script>");
                }
                else
                {
                    this.pulicss.BindListBm("qp_oa_Folders", this.ParentNodesID, " and username='" + this.Session["username"] + "'", "order by id asc");
                    string sql = "select * from qp_oa_fileupload  where NewName='" + base.Request.QueryString["NewName"] + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.OldName.Text = list["Name"].ToString();
                        list.Close();
                        this.BindAttribute();
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('未找到文件！'); window.close();</script>");
                    }
                }
            }
        }
    }
}


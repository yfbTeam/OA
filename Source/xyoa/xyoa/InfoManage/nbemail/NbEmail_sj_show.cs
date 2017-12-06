namespace xyoa.InfoManage.nbemail
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class NbEmail_sj_show : Page
    {
        protected Button Button10;
        protected Button Button2;
        protected Button Button3;
        protected Button Button5;
        protected Button Button6;
        protected Button Button7;
        protected Button Button8;
        protected Button Button9;
        protected Label Content;
        protected HtmlForm form1;
        protected Label FsRealname;
        protected Label FsTime;
        protected Label FsUsername;
        protected Label fujian;
        protected HtmlHead Head1;
        protected Label JsRealname;
        private Db List = new Db();
        protected Label Number;
        public string pageurl;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected HtmlGenericControl tablename;
        protected Label Titles;

        protected void Button10_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=WordFile.doc");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/word";
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            this.tablename.RenderControl(writer2);
            string s = sb.ToString();
            base.Response.Write(s);
            base.Response.End();
            this.Panel1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("NbEmail_add.aspx?user=" + this.FsUsername.Text + "&backid=" + base.Request.QueryString["id"] + "");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("NbEmail_add.aspx?zfid=" + base.Request.QueryString["id"] + "");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("NbEmail_add.aspx?user=" + this.FsUsername.Text + "&tyid=" + base.Request.QueryString["id"] + "");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("NbEmail_add.aspx?user=" + this.FsUsername.Text + "&btyid=" + base.Request.QueryString["id"] + "");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "select top 1 id from qp_oa_NbEmail_sj where id<", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "   and (JsUsername='", this.Session["username"], "') and IfDel='0' order by id desc" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Redirect("NbEmail_sj_show.aspx?id=" + list["id"].ToString() + "");
            }
            else
            {
                base.Response.Write("<script language='javascript'>alert('已经是最后一封邮件了！');</script>");
            }
            list.Close();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "select top 1 id from qp_oa_NbEmail_sj where id>", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "   and (JsUsername='", this.Session["username"], "') and IfDel='0' order by id asc" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Redirect("NbEmail_sj_show.aspx?id=" + list["id"].ToString() + "");
            }
            else
            {
                base.Response.Write("<script language='javascript'>alert('已经是第一封邮件了！');</script>");
            }
            list.Close();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_NbEmail_sj  Set IfDel='1' where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('删除成功！');window.location.href='NbEmail_sj.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (base.Request.QueryString["pagemg"] != null)
                {
                    this.pageurl = "window.location.href='/main_d.aspx'";
                }
                else
                {
                    this.pageurl = "history.back()";
                }
                if (!this.Page.IsPostBack)
                {
                    this.Button9.Attributes["onclick"] = "javascript:return zx();";
                    string sql = string.Concat(new object[] { "select * from qp_oa_NbEmail_sj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "')" });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.Titles.Text = list["Titles"].ToString();
                        this.Content.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                        this.FsTime.Text = list["FsTime"].ToString();
                        this.FsRealname.Text = list["FsRealname"].ToString();
                        this.FsUsername.Text = list["FsUsername"].ToString();
                        if (list["IfRead"].ToString() != "True")
                        {
                            string str2 = "Update qp_oa_NbEmail_fj Set JsRealname=replace(JsRealname,'," + this.Session["realname"].ToString() + ",',',<font color=\"blue\">" + this.Session["realname"].ToString() + "(" + DateTime.Now.ToString() + ")</font>,')  where  Number='" + this.Number.Text + "'";
                            this.List.ExeSql(str2);
                        }
                        string str3 = "select * from qp_oa_NbEmail_fj where Number='" + this.Number.Text + "'";
                        SqlDataReader reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.JsRealname.Text = reader2["JsRealname"].ToString();
                        }
                        reader2.Close();
                        string str4 = string.Concat(new object[] { "Update qp_oa_NbEmail_sj Set IfRead='1'  where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "' or FsUsername='", this.Session["username"], "')" });
                        this.List.ExeSql(str4);
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location.href='NbEmail_sj.aspx'</script>");
                    }
                    list.Close();
                    this.pulicss.GetFile(this.Number.Text, this.fujian);
                    this.pulicss.InsertLog("查看邮件", "内部邮件");
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}


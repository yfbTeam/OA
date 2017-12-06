namespace xyoa.InfoManage.nbemail
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web;
    using System.Web.UI;

    public class NbEmail_sj_down : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.close();</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_NbEmail_sj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "' or FsUsername='", this.Session["username"], "')" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["IfRead"].ToString() != "True")
                    {
                        string str2 = string.Concat(new object[] { "Update qp_oa_NbEmail_fj Set JsRealname=replace(JsRealname,'", this.Session["realname"].ToString(), "','<font color=\"blue\">", this.Session["realname"].ToString(), "(", DateTime.Now.ToString(), ")</font>')  where  Number='", list["Number"], "'" });
                        this.List.ExeSql(str2);
                    }
                    string str3 = string.Concat(new object[] { "Update qp_oa_NbEmail_sj Set IfRead='1'  where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "' or FsUsername='", this.Session["username"], "')" });
                    this.List.ExeSql(str3);
                }
                list.Close();
                string str4 = "select * from qp_oa_fileupload   where NewName='" + base.Server.UrlDecode(base.Request.QueryString["number"]) + "'";
                SqlDataReader reader2 = this.List.GetList(str4);
                if (reader2.Read())
                {
                    string path = "/" + reader2["NewName"].ToString() + "";
                    string str = reader2["Name"].ToString();
                    base.Response.ContentType = "application/octet-stream";
                    base.Response.AddHeader("Content-Disposition", "attachment;    filename=" + HttpUtility.UrlEncode(str, Encoding.UTF8).Replace("+", "%20"));
                    string filename = base.Server.MapPath(path);
                    base.Response.TransmitFile(filename);
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('下载失败！');window.close();</script>");
                }
                reader2.Close();
            }
        }
    }
}


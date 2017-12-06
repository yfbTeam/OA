namespace xyoa
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web;
    using System.Web.UI;

    public class hyjydown : Page
    {
        private Db List = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.close();</script>");
            }
            else
            {
                string sql = "select * from qp_oa_MettingApplyFj   where NewName='" + base.Server.UrlDecode(base.Request.QueryString["number"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string path = list["NewName"].ToString();
                    string str = list["Name"].ToString();
                    base.Response.ContentType = "application/octet-stream";
                    base.Response.AddHeader("Content-Disposition", "attachment;    filename=" + HttpUtility.UrlEncode(str, Encoding.UTF8));
                    string filename = base.Server.MapPath(path);
                    base.Response.TransmitFile(filename);
                    base.Response.Write("<script language=javascript>window.close();</script>");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('下载失败！');window.close();</script>");
                }
                list.Close();
            }
        }
    }
}


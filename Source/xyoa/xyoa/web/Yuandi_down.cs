namespace xyoa.web
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web;
    using System.Web.UI;

    public class Yuandi_down : Page
    {
        private Db List = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from qp_web_Yuandi   where NewName='" + base.Server.UrlDecode(base.Request.QueryString["NewName"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string path = "Yuandi/" + list["NewName"].ToString() + "";
                    string str = list["Titles"].ToString();
                    base.Response.ContentType = "application/octet-stream";
                    base.Response.AddHeader("Content-Disposition", "attachment;    filename=" + HttpUtility.UrlEncode(str, Encoding.UTF8));
                    string filename = base.Server.MapPath(path);
                    base.Response.TransmitFile(filename);
                }
                else
                {
                    base.Response.Redirect("" + base.Request.QueryString["number"].ToString() + "");
                }
                list.Close();
            }
            catch
            {
                base.Response.Write("<script language=javascript>alert('下载失败！');window.close();</script>");
            }
        }
    }
}


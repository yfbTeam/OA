namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class AddWorkFlowSc : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select id,ScUsername from qp_oa_DIYForm where ID='" + int.Parse(base.Request.QueryString["id"]) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str5;
                string str2 = list["ScUsername"].ToString();
                string str3 = "," + str2 + ",";
                string str4 = "," + this.Session["username"].ToString() + ",";
                if (str3.IndexOf(str4) < 0)
                {
                    str5 = string.Concat(new object[] { "Update qp_oa_DIYForm  Set ScUsername=ScUsername+'", this.Session["username"], ",' where ID='", int.Parse(base.Request.QueryString["id"]), "'" });
                    this.List.ExeSql(str5);
                    base.Response.Write("<script language=javascript>alert('收藏成功！');window.opener.location.href='AddWorkFlow.aspx?id=10000';window.close();</script>");
                }
                else
                {
                    str5 = string.Concat(new object[] { "Update qp_oa_DIYForm  Set ScUsername=replace(ScUsername,'", this.Session["username"].ToString(), ",','')  where ID='", int.Parse(base.Request.QueryString["id"]), "'" });
                    this.List.ExeSql(str5);
                    base.Response.Write("<script language=javascript>alert('取消收藏成功！');window.opener.location.href='AddWorkFlow.aspx?id=10000';window.close();</script>");
                }
            }
            list.Close();
        }
    }
}


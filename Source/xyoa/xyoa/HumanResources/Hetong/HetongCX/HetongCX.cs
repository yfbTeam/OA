namespace xyoa.HumanResources.Hetong.HetongCX
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class HetongCX : Page
    {
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
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
                if (!this.Page.IsPostBack)
                {
                    string sql = "select id from qp_hr_HetongMg where datediff(dd,Endtime,getdate())>0 and Zhuangtai=1 and Qixian=1";
                    SqlDataReader list = this.List.GetList(sql);
                    while (list.Read())
                    {
                        string str2 = "Update qp_hr_HetongMg  Set Zhuangtai='2' where id='" + list["id"].ToString() + "'";
                        this.List.ExeSql(str2);
                        this.divhr.Insertlsz(list["id"].ToString(), "7", "HumanResources/Hetong/HetongMg/HetongMg_show_lsz.aspx?id=" + list["id"].ToString() + "");
                    }
                    list.Close();
                }
                if (base.Request.QueryString["p"] != null)
                {
                    this.ViewState["tableheigh"] = "80%";
                }
                else
                {
                    this.ViewState["tableheigh"] = "600px";
                }
                this.pulicss.QuanXianBack("eeee3j", this.Session["perstr"].ToString());
            }
        }
    }
}


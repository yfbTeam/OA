namespace xyoa.HumanResources.Hetong.HetongMg
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongMg_show_lsz : Page
    {
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected Label LeibieID;
        private Db List = new Db();
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected Label QdTime;
        protected Label Qixian;
        protected Label QyRealname;
        protected Label Starttime;
        protected Label Zhuangtai;

        public void BindAttribute()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                string sql = "select * from qp_hr_HetongMg where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.LeibieID.Text = this.divhr.TypeCode("Mingcheng", "qp_hr_HetongMB", list["LeibieID"].ToString());
                    this.QyRealname.Text = list["QyRealname"].ToString();
                    this.Starttime.Text = DateTime.Parse(list["Starttime"].ToString()).ToShortDateString();
                    this.Endtime.Text = DateTime.Parse(list["Endtime"].ToString()).ToShortDateString();
                    this.QdTime.Text = DateTime.Parse(list["QdTime"].ToString()).ToShortDateString();
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正常状态").Replace("2", "到期终止").Replace("3", "强行终止").Replace("4", "合同解除");
                    this.Qixian.Text = list["Qixian"].ToString().Replace("1", "固定期限").Replace("2", "无固定期限");
                    if (list["Qixian"].ToString() == "1")
                    {
                        this.Panel1.Visible = true;
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                    }
                    this.Label1.Text = list["Neirong"].ToString().Replace("disabled=\"disabled\"", "").Replace("disabled", "");
                }
                list.Close();
            }
        }
    }
}


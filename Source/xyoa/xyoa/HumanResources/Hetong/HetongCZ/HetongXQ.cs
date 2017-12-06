namespace xyoa.HumanResources.Hetong.HetongCZ
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongXQ : Page
    {
        protected TextBox Bianhao;
        protected Button Button1;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Qixian;
        protected TextBox Riqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select  id,Endtime from qp_hr_HetongMg where id in (" + base.Request.QueryString["id"] + ") order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str2 = "insert into qp_hr_HetongXQ  (HetongID,Riqi,Qixian) values ('" + list["id"].ToString() + "','" + this.pulicss.GetFormatStr(this.Riqi.Text) + "','" + this.pulicss.GetFormatStr(this.Qixian.Text) + "')";
                this.List.ExeSql(str2);
                string str3 = string.Concat(new object[] { "Update qp_hr_HetongMg  Set Endtime='", DateTime.Parse(list["Endtime"].ToString()).AddMonths(int.Parse(this.Qixian.Text)), "',QdTime='", this.pulicss.GetFormatStr(this.Riqi.Text), "',Zhuangtai='1' where id='", list["id"].ToString(), "'" });
                this.List.ExeSql(str3);
                string str4 = "select top 1 id from qp_hr_HetongXQ where  HetongID='" + list["id"].ToString() + "' order by id desc";
                SqlDataReader reader2 = this.List.GetList(str4);
                if (reader2.Read())
                {
                    this.divhr.Insertlsz(list["id"].ToString(), "3", "HumanResources/Hetong/HetongCZ/HetongXQ_show_lsz.aspx?id=" + reader2["id"].ToString() + "");
                }
                reader2.Close();
            }
            list.Close();
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'> winClose(1);</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Riqi.Text = DateTime.Now.ToShortDateString();
                this.BindAttribute();
            }
        }
    }
}


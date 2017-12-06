namespace xyoa.SystemManage.Seal
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class SealManage_show : Page
    {
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Name;
        protected Image Newname;
        protected Label Nowtimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label SpRealname;
        protected Label State;
        protected Label YxType;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SealManage.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.pulicss.QuanXianBack("iiii3", this.Session["perstr"].ToString());
                if (!this.Page.IsPostBack)
                {
                    string sql = "select * from qp_oa_YinZhang where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' ";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Newname.ImageUrl = "/seal/" + list["Newname"].ToString() + "";
                        this.Name.Text = list["Name"].ToString();
                        this.YxType.Text = list["YxType"].ToString();
                        this.Realname.Text = list["Realname"].ToString();
                        this.Nowtimes.Text = list["Nowtimes"].ToString();
                        this.SpRealname.Text = list["SpRealname"].ToString();
                        this.State.Text = list["State"].ToString();
                    }
                    list.Close();
                    this.BindAttribute();
                }
            }
        }
    }
}


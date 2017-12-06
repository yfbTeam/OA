namespace xyoa.InfoManage.messages
{
    using Ajax;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using xyoa;

    public class talk : Page
    {
        protected Label Bothday;
        protected TextBox content;
        protected Label Email;
        protected Label Fax;
        protected HtmlForm form1;
        protected Label ICQ;
        private Db List = new Db();
        protected Label LittleTel;
        protected Label MoveTel;
        protected Label Msn;
        protected Label Post;
        private publics pulicss = new publics();
        protected Label QQNum;
        protected Label Sex;
        protected Label Tel;
        protected Label Unit;
        protected Label Worknum;
        protected Label Zaixian;

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    if (base.Request.QueryString["user"].ToString() == "系统消息")
                    {
                        base.Response.Write("<script language=javascript>alert('交谈对象为“系统消息”不能进行交流。');window.close();</script>");
                        return;
                    }
                    if (base.Request.QueryString["user"].ToString() == this.Session["username"].ToString())
                    {
                        base.Response.Write("<script language=javascript>alert('不能与自己交流。');window.close();</script>");
                        return;
                    }
                    string sql = "select * from qp_oa_MyData where Username='" + base.Request.QueryString["user"].ToString() + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.ViewState["Realname"] = list["Realname"].ToString();
                        this.Worknum.Text = list["Worknum"].ToString();
                        this.Sex.Text = list["Sex"].ToString();
                        this.Bothday.Text = DateTime.Parse(list["Bothday"].ToString()).ToShortDateString().Replace("1900-1-1", "").Replace("00:00:00", "").Replace("1900-01-01", "");
                        this.Tel.Text = list["Tel"].ToString();
                        this.Fax.Text = list["Fax"].ToString();
                        this.MoveTel.Text = list["MoveTel"].ToString();
                        this.LittleTel.Text = list["LittleTel"].ToString();
                        this.Email.Text = list["Email"].ToString();
                        this.QQNum.Text = list["QQNum"].ToString();
                        this.Msn.Text = list["Msn"].ToString();
                        this.ICQ.Text = list["ICQ"].ToString();
                    }
                    list.Close();
                    string str2 = "select BuMenId,JueseId,onlinetime from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.Unit.Text = this.pulicss.TypeCode("qp_oa_Bumen", reader2["BuMenId"].ToString());
                        this.Post.Text = this.pulicss.TypeCode("qp_oa_Juese", reader2["JueseId"].ToString());
                        this.Zaixian.Text = this.pulicss.ShowDateTime(double.Parse(reader2["onlinetime"].ToString()));
                    }
                    reader2.Close();
                }
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            }
        }
    }
}


namespace xyoa
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class senduser : Page
    {
        protected Label Address;
        protected Label Bothday;
        protected Button Button1;
        protected Label Email;
        protected Label Fax;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label HomeTel;
        protected Label ICQ;
        protected LinkButton LinkButton1;
        private Db List = new Db();
        protected Label LittleTel;
        protected Label MoveTel;
        protected Label Msn;
        protected Label Post;
        private publics pulicss = new publics();
        protected Label QQNum;
        protected Label Realname;
        protected Label Sex;
        private divform showform = new divform();
        protected Label Tel;
        protected Label Unit;
        protected Image Xiangpian;
        protected Label Zaixian;
        protected Label zhishitang;
        protected Label Zhuangtai;
        protected Label ZipCode;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("senduser_update.aspx?user=" + base.Request.QueryString["user"].ToString() + "");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string str2;
            string sql = string.Concat(new object[] { "select guanzhu from qp_oa_username where Username='", base.Request.QueryString["user"].ToString(), "' and  CHARINDEX(',", this.Session["username"], ",',','+guanzhu+',')   >0" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str2 = "Update qp_oa_username  Set guanzhu='" + list["guanzhu"].ToString().Replace("" + this.Session["username"] + ",", "") + "' where Username='" + base.Request.QueryString["user"].ToString() + "'";
                this.List.ExeSql(str2);
                this.LinkButton1.Text = "[关注]";
                base.Response.Write("<script language=javascript>alert('取消关注成功，[" + this.Realname.Text + "]上线时，系统将不会通知您了。');</script>");
            }
            else
            {
                str2 = string.Concat(new object[] { "Update qp_oa_username  Set guanzhu=guanzhu+'", this.Session["username"], ",' where Username='", base.Request.QueryString["user"].ToString(), "' " });
                this.List.ExeSql(str2);
                this.LinkButton1.Text = "[取消关注]";
                base.Response.Write("<script language=javascript>alert('提交关注成功，[" + this.Realname.Text + "]上线时，系统将通知您。');</script>");
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if ((this.Session["username"].ToString() != base.Request.QueryString["user"].ToString()) && (this.Session["username"].ToString() != "admin"))
                {
                    this.Button1.Visible = false;
                }
                string sql = "select * from qp_oa_MyData where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Realname.Text = list["Realname"].ToString();
                    this.Sex.Text = list["Sex"].ToString();
                    this.Bothday.Text = list["Bothday"].ToString().Replace("1900-1-1", "").Replace("1900-01-01", "").Replace("00:00:00", "").Replace("0:00:00", "");
                    this.Tel.Text = list["Tel"].ToString();
                    this.Fax.Text = list["Fax"].ToString();
                    this.MoveTel.Text = list["MoveTel"].ToString();
                    this.LittleTel.Text = list["LittleTel"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.QQNum.Text = list["QQNum"].ToString();
                    this.Msn.Text = list["Msn"].ToString();
                    this.ICQ.Text = list["ICQ"].ToString();
                    this.Address.Text = list["Address"].ToString();
                    this.ZipCode.Text = list["ZipCode"].ToString();
                    this.HomeTel.Text = list["HomeTel"].ToString();
                }
                list.Close();
                string str2 = "select count(id) from qp_oa_username where onlinetime>(select onlinetime from qp_oa_username where username='" + base.Request.QueryString["user"].ToString() + "')";
                this.ViewState["count"] = this.List.GetCount(str2) + 1;
                string str3 = "select pic,jifen,BuMenId,Zhiweiid,onlinetime,lasttime from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    this.Xiangpian.ImageUrl = reader2["pic"].ToString();
                    this.ViewState["lasttime"] = reader2["lasttime"].ToString();
                    this.Unit.Text = this.pulicss.TypeCode("qp_oa_Bumen", reader2["BuMenId"].ToString());
                    this.Post.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", reader2["Zhiweiid"].ToString());
                    this.Zaixian.Text = this.pulicss.ShowDateTime(double.Parse(reader2["onlinetime"].ToString()));
                    DateTime time = Convert.ToDateTime(DateTime.Now.ToString());
                    DateTime time2 = Convert.ToDateTime(reader2["lasttime"].ToString());
                    TimeSpan span = (TimeSpan) (time - time2);
                    if (span.TotalSeconds < 70.0)
                    {
                        this.Zhuangtai.Text = "在线";
                    }
                    else
                    {
                        this.Zhuangtai.Text = "不在线";
                    }
                    string str4 = "select * from qp_oa_Zst_dengji where " + reader2["jifen"].ToString() + ">=Fenshu1 and " + reader2["jifen"].ToString() + "<=Fenshu2";
                    SqlDataReader reader3 = this.List.GetList(str4);
                    if (reader3.Read())
                    {
                        this.zhishitang.Text = "<img src=\"/InfoManage/zhiao/img/d_" + reader3["dengji"].ToString() + ".gif\"  alt=\"积" + reader2["jifen"].ToString() + "分\"/>，共积分：" + reader2["jifen"].ToString() + "";
                    }
                    reader3.Close();
                }
                reader2.Close();
                string str5 = "select top 1 * from qp_oa_Quxian  where Username='" + base.Request.QueryString["user"].ToString() + "' order by id desc";
                SqlDataReader reader4 = this.List.GetList(str5);
                if (reader4.Read())
                {
                    this.ViewState["dongtai"] = "" + reader4["Zhuti"].ToString() + "<font color=#666666>(" + reader4["Nowtimes"].ToString() + ")</font>";
                }
                reader4.Close();
                string str6 = string.Concat(new object[] { "select guanzhu from qp_oa_username where Username='", base.Request.QueryString["user"].ToString(), "' and  CHARINDEX(',", this.Session["username"], ",',','+guanzhu+',')   >0" });
                SqlDataReader reader5 = this.List.GetList(str6);
                if (reader5.Read())
                {
                    this.LinkButton1.Text = "[取消关注]";
                }
                else
                {
                    this.LinkButton1.Text = "[关注]";
                }
                reader5.Close();
            }
        }
    }
}


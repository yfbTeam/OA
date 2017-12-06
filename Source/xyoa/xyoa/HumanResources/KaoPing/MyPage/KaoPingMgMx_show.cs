namespace xyoa.HumanResources.KaoPing.MyPage
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoPingMgMx_show : Page
    {
        protected Button Button1;
        protected TextBox ContractContent;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Endtime;
        protected TextBox FenshuMy;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label LeixingID;
        private Db List = new Db();
        protected Label Miaoshu;
        private publics pulicss = new publics();
        protected Label QuanzhongMy;
        protected Label Starttime;
        protected TextBox TextBox1;
        protected Label Zhuti;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_KaoPingMgMx   Set NeirongMy='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',FenshuMy='", this.pulicss.GetFormatStr(this.FenshuMy.Text), "',KpZhuangtaiMy='2',KpZhuangtai1='1',Jieduan='1' where id='", int.Parse(base.Request.QueryString["id"]), "' and UsernameCy='", this.Session["Username"], "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertMessage("您有上级考评需要参加，考评主题：" + this.Zhuti.Text + "<br>生效时间：" + this.Starttime.Text + "，终止时间：" + this.Endtime.Text + "", this.ViewState["User1"].ToString(), this.ViewState["Name1"].ToString(), "/HumanResources/KaoPing/KaoPingSJ/KaoPingSJ.aspx");
            this.pulicss.InsertLog("自我考评" + this.Zhuti.Text + "", "自我考评");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KaoPingMgMx.aspx?KpZhuangtaiMy=1'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
                string sql = string.Concat(new object[] { "select User1,Name1,FenshuMy,KpZhuangtaiMy,KaopingId,NeirongMy,QuanzhongMy from qp_hr_KaoPingMgMx where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and UsernameCy='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["User1"] = list["User1"].ToString();
                    this.ViewState["Name1"] = list["Name1"].ToString();
                    this.TextBox1.Text = list["NeirongMy"].ToString().Replace("disabled=\"disabled\"", "").Replace("disabled", "");
                    this.QuanzhongMy.Text = list["QuanzhongMy"].ToString();
                    this.FenshuMy.Text = list["FenshuMy"].ToString();
                    string str2 = "select * from qp_hr_KaoPingMg where id='" + list["KaopingId"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.Zhuti.Text = reader2["Zhuti"].ToString();
                        this.LeixingID.Text = this.divhr.TypeCode("Leixing", "qp_hr_KaoPingSz", reader2["LeixingID"].ToString());
                        this.Starttime.Text = reader2["Starttime"].ToString();
                        this.Endtime.Text = reader2["Endtime"].ToString();
                        this.Miaoshu.Text = this.pulicss.TbToLb(reader2["Miaoshu"].ToString());
                        if (list["KpZhuangtaiMy"].ToString() == "2")
                        {
                            this.Button1.Enabled = false;
                            this.Button1.Text = "考评已完成，不能再进行考评";
                        }
                        else if (reader2["Zhuangtai"].ToString() == "2")
                        {
                            this.Button1.Enabled = false;
                            this.Button1.Text = "考评已停用，不能进行考评";
                        }
                        else if (reader2["Zhuangtai"].ToString() == "1")
                        {
                            TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader2["Endtime"].ToString()));
                            TimeSpan span2 = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader2["Starttime"].ToString()));
                            if ((span.TotalDays > 0.0) || (span2.TotalDays < 0.0))
                            {
                                this.Button1.Enabled = false;
                                this.Button1.Text = "未在规定的时间范围内，不能进行考评";
                            }
                        }
                    }
                    reader2.Close();
                    list.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('无相关数据！');window.location = 'KaoPingMgMx.aspx?KpZhuangtaiMy=1'</script>");
                }
            }
        }
    }
}


namespace xyoa.HumanResources.KaoPing.KaoPingSJ
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
        protected CheckBox CheckBox0;
        protected TextBox ContractContent;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Endtime;
        protected TextBox Fenshu;
        protected Label FenshuMy;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label LeixingID;
        private Db List = new Db();
        protected Label Miaoshu;
        protected Label NeirongMy;
        private publics pulicss = new publics();
        protected Label Quanzhong;
        protected Label Starttime;
        protected TextBox TextBox1;
        protected Label Zhuti;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str;
            if (int.Parse(this.ViewState["Jishu"].ToString()) > 1)
            {
                str = string.Concat(new object[] { "Update qp_hr_KaoPingMgMx  Set Neirong1='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',Fenshu1='", this.pulicss.GetFormatStr(this.Fenshu.Text), "',KpZhuangtai1='2',KpZhuangtai2='1',Jieduan='2' where id='", int.Parse(base.Request.QueryString["id"]), "' and ((KpZhuangtai1='1' and User1='", this.Session["Username"], "'))" });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage("您有上级考评需要参加，考评主题：" + this.Zhuti.Text + "<br>生效时间：" + this.Starttime.Text + "，终止时间：" + this.Endtime.Text + "", this.ViewState["User2"].ToString(), this.ViewState["Name2"].ToString(), "/HumanResources/KaoPing/KaoPingSJ/KaoPingSJ.aspx");
            }
            else
            {
                str = string.Concat(new object[] { "Update qp_hr_KaoPingMgMx  Set Neirong1='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',Fenshu1='", this.pulicss.GetFormatStr(this.Fenshu.Text), "',KpZhuangtai1='2',Jieduan='6' where id='", int.Parse(base.Request.QueryString["id"]), "' and ((KpZhuangtai1='1' and User1='", this.Session["Username"], "'))" });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage("您有考评需要签字，考评主题：" + this.Zhuti.Text + "<br>生效时间：" + this.Starttime.Text + "，终止时间：" + this.Endtime.Text + "", this.ViewState["UsernameCy"].ToString(), this.ViewState["RealnameCy"].ToString(), "/HumanResources/KaoPing/KaoPingQZ/KaoPingQZ.aspx");
            }
            this.pulicss.InsertLog("上级考评" + this.Zhuti.Text + "", "上级考评");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KaoPingSJ.aspx'</script>");
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
                string sql = string.Concat(new object[] { "select UsernameCy,RealnameCy,User2,Name2,NeirongMy,QuanzhongMy,FenshuMy,Jishu,Jieduan,Fenshu1,Quanzhong1,Neirong1,KpZhuangtai1,KaopingId from qp_hr_KaoPingMgMx as [A] where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and ((A.KpZhuangtai1='1' and A.User1='", this.Session["Username"], "'))" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["User2"] = list["User2"].ToString();
                    this.ViewState["Name2"] = list["Name2"].ToString();
                    this.ViewState["UsernameCy"] = list["UsernameCy"].ToString();
                    this.ViewState["RealnameCy"] = list["RealnameCy"].ToString();
                    this.FenshuMy.Text = "考评分数：" + list["FenshuMy"].ToString() + "分，考评权重：" + list["QuanzhongMy"].ToString() + "%";
                    this.NeirongMy.Text = list["NeirongMy"].ToString();
                    this.Quanzhong.Text = list["Quanzhong1"].ToString();
                    this.ViewState["Jieduan"] = list["Jieduan"].ToString();
                    this.ViewState["Jishu"] = list["Jishu"].ToString();
                    this.TextBox1.Text = list["Neirong1"].ToString().Replace("disabled=\"disabled\"", "").Replace("disabled", "");
                    string str2 = "select * from qp_hr_KaoPingMg where id='" + list["KaopingId"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.Zhuti.Text = reader2["Zhuti"].ToString();
                        this.LeixingID.Text = this.divhr.TypeCode("Leixing", "qp_hr_KaoPingSz", reader2["LeixingID"].ToString());
                        this.Starttime.Text = reader2["Starttime"].ToString();
                        this.Endtime.Text = reader2["Endtime"].ToString();
                        this.Miaoshu.Text = this.pulicss.TbToLb(reader2["Miaoshu"].ToString());
                        if (list["KpZhuangtai1"].ToString() == "2")
                        {
                            this.Button1.Enabled = false;
                            this.Button1.Text = "一级考评已完成，不能再进行考评";
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
                    base.Response.Write("<script language=javascript>alert('无相关数据！');window.location = 'KaoPingSJ.aspx'</script>");
                }
            }
        }
    }
}


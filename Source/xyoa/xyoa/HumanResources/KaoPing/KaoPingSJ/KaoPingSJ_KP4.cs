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

    public class KaoPingSJ_KP4 : Page
    {
        protected Button Button1;
        protected CheckBox CheckBox0;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
        protected TextBox ContractContent;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Endtime;
        protected TextBox Fenshu;
        protected Label Fenshu1;
        protected Label Fenshu2;
        protected Label Fenshu3;
        protected Label FenshuMy;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label LeixingID;
        private Db List = new Db();
        protected Label Miaoshu;
        protected Label Neirong1;
        protected Label Neirong2;
        protected Label Neirong3;
        protected Label NeirongMy;
        private publics pulicss = new publics();
        protected Label Quanzhong;
        protected Label Starttime;
        protected TextBox TextBox1;
        protected Label Zhuti;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str;
            if (int.Parse(this.ViewState["Jishu"].ToString()) > 4)
            {
                str = string.Concat(new object[] { "Update qp_hr_KaoPingMgMx  Set Neirong4='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',Fenshu4='", this.pulicss.GetFormatStr(this.Fenshu.Text), "',KpZhuangtai4='2',KpZhuangtai5='1',Jieduan='5' where id='", int.Parse(base.Request.QueryString["id"]), "' and ((KpZhuangtai4='1' and User4='", this.Session["Username"], "'))" });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage("您有上级考评需要参加，考评主题：" + this.Zhuti.Text + "<br>生效时间：" + this.Starttime.Text + "，终止时间：" + this.Endtime.Text + "", this.ViewState["User3"].ToString(), this.ViewState["Name3"].ToString(), "/HumanResources/KaoPing/KaoPingSJ/KaoPingSJ.aspx");
            }
            else
            {
                str = string.Concat(new object[] { "Update qp_hr_KaoPingMgMx  Set Neirong4='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',Fenshu4='", this.pulicss.GetFormatStr(this.Fenshu.Text), "',KpZhuangtai4='2',Jieduan='6' where id='", int.Parse(base.Request.QueryString["id"]), "' and ((KpZhuangtai4='1' and User4='", this.Session["Username"], "'))" });
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
                string sql = string.Concat(new object[] { "select * from qp_hr_KaoPingMgMx as [A] where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and ((A.KpZhuangtai4='1' and A.User4='", this.Session["Username"], "'))" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["User3"] = list["User5"].ToString();
                    this.ViewState["Name3"] = list["Name5"].ToString();
                    this.ViewState["UsernameCy"] = list["UsernameCy"].ToString();
                    this.ViewState["RealnameCy"] = list["RealnameCy"].ToString();
                    this.FenshuMy.Text = "考评分数：" + list["FenshuMy"].ToString() + "分，考评权重：" + list["QuanzhongMy"].ToString() + "%";
                    this.NeirongMy.Text = list["NeirongMy"].ToString();
                    this.Fenshu1.Text = "考评分数：" + list["Fenshu1"].ToString() + "分，考评权重：" + list["Quanzhong1"].ToString() + "%";
                    this.Neirong1.Text = list["Neirong1"].ToString();
                    this.Fenshu2.Text = "考评分数：" + list["Fenshu2"].ToString() + "分，考评权重：" + list["Quanzhong2"].ToString() + "%";
                    this.Neirong2.Text = list["Neirong2"].ToString();
                    this.Fenshu3.Text = "考评分数：" + list["Fenshu3"].ToString() + "分，考评权重：" + list["Quanzhong3"].ToString() + "%";
                    this.Neirong3.Text = list["Neirong3"].ToString();
                    this.Quanzhong.Text = list["Quanzhong4"].ToString();
                    this.ViewState["Jieduan"] = list["Jieduan"].ToString();
                    this.ViewState["Jishu"] = list["Jishu"].ToString();
                    this.TextBox1.Text = list["Neirong4"].ToString().Replace("disabled=\"disabled\"", "").Replace("disabled", "");
                    string str2 = "select * from qp_hr_KaoPingMg where id='" + list["KaopingId"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.Zhuti.Text = reader2["Zhuti"].ToString();
                        this.LeixingID.Text = this.divhr.TypeCode("Leixing", "qp_hr_KaoPingSz", reader2["LeixingID"].ToString());
                        this.Starttime.Text = reader2["Starttime"].ToString();
                        this.Endtime.Text = reader2["Endtime"].ToString();
                        this.Miaoshu.Text = this.pulicss.TbToLb(reader2["Miaoshu"].ToString());
                        if (list["KpZhuangtai4"].ToString() == "2")
                        {
                            this.Button1.Enabled = false;
                            this.Button1.Text = "四级考评已完成，不能再进行考评";
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


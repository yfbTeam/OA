namespace xyoa.HumanResources.KaoPing.KaoPingQZ
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoPingQZ_show : Page
    {
        protected Button Button1;
        protected CheckBox CheckBox0;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
        protected CheckBox CheckBox4;
        protected CheckBox CheckBox5;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Endtime;
        protected Label Fenshu1;
        protected Label Fenshu2;
        protected Label Fenshu3;
        protected Label Fenshu4;
        protected Label Fenshu5;
        protected Label FenshuMy;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label LeixingID;
        private Db List = new Db();
        protected Label Miaoshu;
        protected Label Neirong1;
        protected Label Neirong2;
        protected Label Neirong3;
        protected Label Neirong4;
        protected Label Neirong5;
        protected Label NeirongMy;
        private publics pulicss = new publics();
        protected Label Starttime;
        protected Label Zhuti;
        protected Label Zongfen;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_KaoPingMgMx  Set Jieduan='7',Queren='1',Shijian='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "' and ((Jieduan='6' or Jieduan='7') and UsernameCy='", this.Session["Username"], "')" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("员工签字" + this.Zhuti.Text + "", "员工签字");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KaoPingQZ.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.ViewState["XianshiCss1"] = "display: none";
                this.ViewState["XianshiCss2"] = "display: none";
                this.ViewState["XianshiCss3"] = "display: none";
                this.ViewState["XianshiCss4"] = "display: none";
                this.ViewState["XianshiCss5"] = "display: none";
                if (!this.Page.IsPostBack)
                {
                    this.Button1.Attributes.Add("onclick", "javascript:return zx();");
                    string sql = string.Concat(new object[] { "select * from qp_hr_KaoPingMgMx as [A] where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and ((A.Jieduan='6' or A.Jieduan='7') and A.UsernameCy='", this.Session["Username"], "')" });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.FenshuMy.Text = "考评分数：" + list["FenshuMy"].ToString() + "分，考评权重：" + list["QuanzhongMy"].ToString() + "%";
                        this.NeirongMy.Text = list["NeirongMy"].ToString();
                        if (list["KpZhuangtai1"].ToString() == "2")
                        {
                            this.Fenshu1.Text = "考评分数：" + list["Fenshu1"].ToString() + "分，考评权重：" + list["Quanzhong1"].ToString() + "%";
                            this.Neirong1.Text = list["Neirong1"].ToString();
                        }
                        if (list["KpZhuangtai2"].ToString() == "2")
                        {
                            this.Fenshu2.Text = "考评分数：" + list["Fenshu2"].ToString() + "分，考评权重：" + list["Quanzhong2"].ToString() + "%";
                            this.Neirong2.Text = list["Neirong2"].ToString();
                        }
                        if (list["KpZhuangtai3"].ToString() == "2")
                        {
                            this.Fenshu3.Text = "考评分数：" + list["Fenshu3"].ToString() + "分，考评权重：" + list["Quanzhong3"].ToString() + "%";
                            this.Neirong3.Text = list["Neirong3"].ToString();
                        }
                        if (list["KpZhuangtai4"].ToString() == "2")
                        {
                            this.Fenshu4.Text = "考评分数：" + list["Fenshu4"].ToString() + "分，考评权重：" + list["Quanzhong4"].ToString() + "%";
                            this.Neirong4.Text = list["Neirong4"].ToString();
                        }
                        if (list["KpZhuangtai5"].ToString() == "2")
                        {
                            this.Fenshu5.Text = "考评分数：" + list["Fenshu5"].ToString() + "分，考评权重：" + list["Quanzhong5"].ToString() + "%";
                            this.Neirong5.Text = list["Neirong5"].ToString();
                        }
                        if (list["Jishu"].ToString() == "5")
                        {
                            this.ViewState["XianshiCss1"] = "";
                            this.ViewState["XianshiCss2"] = "";
                            this.ViewState["XianshiCss3"] = "";
                            this.ViewState["XianshiCss4"] = "";
                            this.ViewState["XianshiCss5"] = "";
                        }
                        else if (list["Jishu"].ToString() == "4")
                        {
                            this.ViewState["XianshiCss1"] = "";
                            this.ViewState["XianshiCss2"] = "";
                            this.ViewState["XianshiCss3"] = "";
                            this.ViewState["XianshiCss4"] = "";
                            this.ViewState["XianshiCss5"] = "display: none";
                        }
                        else if (list["Jishu"].ToString() == "3")
                        {
                            this.ViewState["XianshiCss1"] = "";
                            this.ViewState["XianshiCss2"] = "";
                            this.ViewState["XianshiCss3"] = "";
                            this.ViewState["XianshiCss4"] = "display: none";
                            this.ViewState["XianshiCss5"] = "display: none";
                        }
                        else if (list["Jishu"].ToString() == "2")
                        {
                            this.ViewState["XianshiCss1"] = "";
                            this.ViewState["XianshiCss2"] = "";
                            this.ViewState["XianshiCss3"] = "display: none";
                            this.ViewState["XianshiCss4"] = "display: none";
                            this.ViewState["XianshiCss5"] = "display: none";
                        }
                        else if (list["Jishu"].ToString() == "1")
                        {
                            this.ViewState["XianshiCss1"] = "";
                            this.ViewState["XianshiCss2"] = "display: none";
                            this.ViewState["XianshiCss3"] = "display: none";
                            this.ViewState["XianshiCss4"] = "display: none";
                            this.ViewState["XianshiCss5"] = "display: none";
                        }
                        this.ViewState["Jieduan"] = list["Jieduan"].ToString();
                        this.ViewState["Jishu"] = list["Jishu"].ToString();
                        if (list["Jieduan"].ToString() != "6")
                        {
                            this.Button1.Text = "已确认签字不能重复操作";
                            this.Button1.Enabled = false;
                        }
                        string str2 = "select * from qp_hr_KaoPingMg where id='" + list["KaopingId"].ToString() + "'";
                        SqlDataReader reader2 = this.List.GetList(str2);
                        if (reader2.Read())
                        {
                            this.Zhuti.Text = reader2["Zhuti"].ToString();
                            this.LeixingID.Text = this.divhr.TypeCode("Leixing", "qp_hr_KaoPingSz", reader2["LeixingID"].ToString());
                            this.Starttime.Text = reader2["Starttime"].ToString();
                            this.Endtime.Text = reader2["Endtime"].ToString();
                            this.Miaoshu.Text = this.pulicss.TbToLb(reader2["Miaoshu"].ToString());
                        }
                        reader2.Close();
                        decimal num = (decimal.Parse(list["FenshuMy"].ToString()) * decimal.Parse(list["QuanzhongMy"].ToString())) / 100M;
                        decimal num2 = (decimal.Parse(list["Fenshu1"].ToString()) * decimal.Parse(list["Quanzhong1"].ToString())) / 100M;
                        decimal num3 = (decimal.Parse(list["Fenshu2"].ToString()) * decimal.Parse(list["Quanzhong2"].ToString())) / 100M;
                        decimal num4 = (decimal.Parse(list["Fenshu3"].ToString()) * decimal.Parse(list["Quanzhong3"].ToString())) / 100M;
                        decimal num5 = (decimal.Parse(list["Fenshu4"].ToString()) * decimal.Parse(list["Quanzhong4"].ToString())) / 100M;
                        decimal num6 = (decimal.Parse(list["Fenshu5"].ToString()) * decimal.Parse(list["Quanzhong5"].ToString())) / 100M;
                        decimal num7 = ((((num + num2) + num3) + num4) + num5) + num6;
                        this.Zongfen.Text = "" + num7 + "分";
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
}


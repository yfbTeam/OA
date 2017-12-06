namespace xyoa.HumanResources.ZhaoPin.MianShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MianShi_show : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected Button Button4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Hege;
        protected Label Lianxi;
        private Db List = new Db();
        protected Label Mianshi;
        protected Label Neirong;
        private publics pulicss = new publics();
        protected Label Xingbie;
        protected Label Xingming;
        protected Label Zhiwei;
        protected Label Zhuangtai;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_MianShi Set Hege='", this.Hege.SelectedValue, "',Beizhu='", this.pulicss.TbToLb(this.Beizhu.Text), "' where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
            this.List.ExeSql(sql);
            string str2 = "select * from qp_hr_MianShi  where XingmingId='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "' and Hege='3'";
            SqlDataReader list = this.List.GetList(str2);
            if (!list.Read())
            {
                string str4;
                string str3 = "select * from qp_hr_MianShi  where XingmingId='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "' and Hege='2'";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    str4 = "Update qp_hr_JianLi Set Zhuangtai='3' where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "'";
                    this.List.ExeSql(str4);
                }
                else
                {
                    str4 = "Update qp_hr_JianLi Set Zhuangtai='5' where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "'";
                    this.List.ExeSql(str4);
                }
                reader2.Close();
            }
            list.Close();
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MianShi.aspx?Hege=3'</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_MianShi Set Hege='", this.Hege.SelectedValue, "',Beizhu='", this.pulicss.TbToLb(this.Beizhu.Text), "' where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
            this.List.ExeSql(sql);
            string str2 = "select * from qp_hr_MianShi  where XingmingId='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "' and Hege='3'";
            SqlDataReader list = this.List.GetList(str2);
            if (!list.Read())
            {
                string str4;
                string str3 = "select * from qp_hr_MianShi  where XingmingId='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "' and Hege='2'";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    str4 = "Update qp_hr_JianLi Set Zhuangtai='3' where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "'";
                    this.List.ExeSql(str4);
                }
                else
                {
                    str4 = "Update qp_hr_JianLi Set Zhuangtai='5' where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "'";
                    this.List.ExeSql(str4);
                }
                reader2.Close();
            }
            list.Close();
            base.Response.Write("<script language=javascript>alert('保存成功，现在进入转交面试页面！');window.location.href='MianShi_zj.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_hr_JianLi where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["XingmingId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Xingbie.Text = list["Xingbie"].ToString().Replace("1", "男").Replace("2", "女");
                    this.Zhiwei.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["Zhiwei"].ToString());
                    this.Lianxi.Text = list["Lianxi"].ToString();
                    this.Neirong.Text = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "未面试").Replace("2", "合格录用").Replace("3", "未合格").Replace("4", "预约面试");
                    this.Mianshi.Text = null;
                    this.Mianshi.Text = this.Mianshi.Text + "<table align=\"center\" border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\" id=\"table1\">";
                    string str2 = "select  * from qp_hr_MianShi  where  XingmingId='" + list["id"].ToString() + "'  order by id asc";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        string text = this.Mianshi.Text;
                        this.Mianshi.Text = text + "<tr><td class=\"newtd2\" height=\"17\" nowrap=\"nowrap\"><img src=\"/oaimg/menu/arrow_down.gif\"><a href=\"javascript:void(0)\" onclick=\"senduser('" + reader2["Username"].ToString() + "')\"><b><font color=\"#FF0000\">" + reader2["Realname"].ToString() + "</font></b></a><br>预约时间：" + DateTime.Parse(reader2["Shijian"].ToString()).ToShortDateString() + "<br>是否合格：" + reader2["Hege"].ToString().Replace("1", "合格").Replace("2", "不合格").Replace("3", "未面试") + "<br>备注：" + this.pulicss.TbToLb(reader2["Beizhu"].ToString()) + "<br></td></tr>";
                    }
                    reader2.Close();
                    this.Mianshi.Text = this.Mianshi.Text + "</table>";
                }
                list.Close();
                string str3 = "select * from qp_hr_MianShi where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader reader3 = this.List.GetList(str3);
                if (reader3.Read())
                {
                    if (reader3["Hege"].ToString() == "3")
                    {
                        this.Button1.Enabled = true;
                        this.Button4.Enabled = true;
                    }
                    else
                    {
                        this.Button1.Enabled = false;
                        this.Button4.Enabled = false;
                    }
                    this.Hege.SelectedValue = reader3["Hege"].ToString();
                    this.Beizhu.Text = reader3["Beizhu"].ToString();
                }
                reader3.Close();
            }
        }
    }
}


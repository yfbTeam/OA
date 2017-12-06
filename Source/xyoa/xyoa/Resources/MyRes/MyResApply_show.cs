namespace xyoa.Resources.MyRes
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyResApply_show : Page
    {
        protected Label AllKuCun;
        protected Label BfKuCun;
        protected Button Button1;
        protected Button Button2;
        protected Label Cangku;
        protected Label Danjia;
        protected Label Danwei;
        protected HtmlForm form1;
        protected Label Gongyinshang;
        protected HtmlHead Head1;
        protected Label KuCun;
        protected Label LimitsE;
        protected Label LimitsS;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label Quyu;
        protected Image TuPian;
        protected Label Xinghao;
        protected Label YjyKuCun;
        protected Label Zhuangtai;
        protected Label ZyIntro;
        protected Label ZyLeibie;
        protected Label ZyName;
        protected Label ZyNum;
        protected Label ZyXingzhi;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (float.Parse(this.KuCun.Text) <= 0f)
            {
                base.Response.Write("<script language=javascript>alert('当前库存过小，申请失败！');</script>");
            }
            else
            {
                base.Response.Redirect("MyResApply_showJy.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (float.Parse(this.KuCun.Text) <= 0f)
            {
                base.Response.Write("<script language=javascript>alert('当前库存过小，申请失败！');</script>");
            }
            else
            {
                base.Response.Redirect("MyResApply_showApp.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_ResourcesAdd  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xinghao.Text = list["Xinghao"].ToString();
                    this.ZyNum.Text = list["ZyNum"].ToString();
                    this.ZyName.Text = list["ZyName"].ToString();
                    this.ZyIntro.Text = this.pulicss.TbToLb(list["ZyIntro"].ToString());
                    this.ZyLeibie.Text = this.pulicss.TypeCode("qp_oa_ResourcesType", list["ZyLeibie"].ToString());
                    this.Cangku.Text = this.pulicss.TypeCode("qp_oa_ResourcesCangku", list["Cangku"].ToString());
                    this.Quyu.Text = this.pulicss.TypeCode("qp_oa_ResourcesQuyu", list["Quyu"].ToString());
                    this.ZyXingzhi.Text = list["ZyXingzhi"].ToString().Replace("1", "消耗品").Replace("2", "借用品");
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正常").Replace("2", "丢失").Replace("3", "停用").Replace("4", "维修");
                    this.Danwei.Text = list["Danwei"].ToString();
                    this.Danjia.Text = list["Danjia"].ToString();
                    this.Gongyinshang.Text = list["Gongyinshang"].ToString();
                    this.KuCun.Text = list["KuCun"].ToString();
                    this.LimitsS.Text = list["LimitsS"].ToString();
                    this.LimitsE.Text = list["LimitsE"].ToString();
                    this.AllKuCun.Text = list["AllKuCun"].ToString();
                    this.BfKuCun.Text = list["BfKuCun"].ToString();
                    this.TuPian.ImageUrl = "/" + list["TuPian"].ToString();
                    decimal num = (decimal.Parse(this.AllKuCun.Text) - decimal.Parse(this.KuCun.Text)) - decimal.Parse(this.BfKuCun.Text);
                    this.YjyKuCun.Text = "" + num + "";
                    if (this.ZyXingzhi.Text == "消耗品")
                    {
                        this.Button1.Visible = false;
                        this.Button2.Visible = true;
                    }
                    else
                    {
                        this.Button1.Visible = true;
                        this.Button2.Visible = false;
                    }
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


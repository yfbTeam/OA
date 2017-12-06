namespace xyoa.HumanResources.Fenxi.RenShi
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongList_show : Page
    {
        protected Label Beizhu;
        protected Label Bianhao;
        protected Label Bumen;
        protected Label Chuanzhen;
        protected Label Chusheng;
        protected Label CjShijian;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Dizhi;
        protected HtmlForm form1;
        protected Label GzJingli;
        protected HtmlHead Head1;
        protected Label Hukou;
        protected Label Hunyin;
        protected Label Jiangcheng;
        protected Label Jiating;
        protected Label Jiguan;
        protected Label Jineng;
        protected Label JrShijian;
        protected Label Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Mianmao;
        protected Label Mingzhu;
        protected Label MSN;
        protected Label Neibu;
        private publics pulicss = new publics();
        protected Label QQ;
        protected Label Shehui;
        protected Label Shenfenzheng;
        protected Label Shouji;
        protected Label Tijian;
        protected Image Xiangpian;
        protected Label Xingbie;
        protected Label Xingming;
        protected Label Xuexi;
        protected Label XxJingli;
        protected Label Youbian;
        protected Label Youxiang;
        protected Label Yuanxiao;
        protected Label Zhicheng;
        protected Label Zhiwei;
        protected Label Zhuanye;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
                string sql = "select * from qp_hr_Yuangong  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Bianhao.Text = list["Bianhao"].ToString();
                    this.Xingbie.Text = list["Xingbie"].ToString().Replace("1", "男").Replace("2", "女");
                    this.Chusheng.Text = list["Chusheng"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Mingzhu.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Mingzhu"].ToString());
                    this.Jiguan.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Jiguan"].ToString());
                    this.Mianmao.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Mianmao"].ToString());
                    this.Hunyin.Text = list["Hunyin"].ToString().Replace("1", "已婚").Replace("2", "未婚");
                    this.Xuexi.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Xuexi"].ToString());
                    this.Yuanxiao.Text = list["Yuanxiao"].ToString();
                    this.Zhuanye.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Zhuanye"].ToString());
                    this.Shenfenzheng.Text = list["Shenfenzheng"].ToString();
                    this.Hukou.Text = list["Hukou"].ToString();
                    this.Xiangpian.ImageUrl = list["Xiangpian"].ToString();
                    this.Jiating.Text = list["Jiating"].ToString();
                    this.Youxiang.Text = list["Youxiang"].ToString();
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Bumen.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BuMen"].ToString());
                    this.Leixing.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Leixing"].ToString());
                    this.Zhiwei.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["Zhiwei"].ToString());
                    this.Zhicheng.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Zhicheng"].ToString());
                    this.CjShijian.Text = list["CjShijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.JrShijian.Text = list["JrShijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Shehui.Text = this.pulicss.TbToLb(list["Shehui"].ToString());
                    this.GzJingli.Text = this.pulicss.TbToLb(list["GzJingli"].ToString());
                    this.XxJingli.Text = this.pulicss.TbToLb(list["XxJingli"].ToString());
                    this.Jineng.Text = this.pulicss.TbToLb(list["Jineng"].ToString());
                    this.Tijian.Text = this.pulicss.TbToLb(list["Tijian"].ToString());
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                    this.Chuanzhen.Text = list["Chuanzhen"].ToString();
                    this.Shouji.Text = list["Shouji"].ToString();
                    this.QQ.Text = list["QQ"].ToString();
                    this.MSN.Text = list["MSN"].ToString();
                    this.Neibu.Text = list["Neibu"].ToString();
                    this.Youbian.Text = list["Youbian"].ToString();
                    this.Jiangcheng.Text = this.pulicss.TbToLb(list["Jiangcheng"].ToString());
                }
                list.Close();
            }
        }
    }
}


namespace xyoa.SchTable.Xueji.ZaijiSheng
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZaijiSheng_lb_show_jiben : Page
    {
        protected Label BanJi;
        protected Label Chusheng;
        protected Label Chushengdi;
        protected Label Danqinjiating;
        protected Label Dianhua;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected Label Dizhi;
        protected Label Dushengzinv;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label HukouLeixing;
        protected Label HukouXingzhi;
        protected Label Jiangkan;
        protected Label Jiaoshizinv;
        protected Label Jiguan;
        protected Label Junrenzinv;
        protected Label Kaohao;
        protected Label Laiyuanxiao;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label LiushouErtong;
        protected Label Mingzhu;
        protected TextBox NianjiName;
        protected Label Nongminggao;
        protected Label Pingkunsheng;
        private publics pulicss = new publics();
        protected Label RuxiaoChengji;
        protected Label RuxiaoShijian;
        protected Label Sancan;
        protected Label Shengfenzheng;
        protected Label Shengyuan1;
        protected Label Shengyuan2;
        protected Label Shengyuan3;
        protected Label Tongxin;
        protected Label Xingbie;
        protected Label Xingming;
        protected Label Xuehao;
        protected Label Xuejihao;
        protected Label XuejiZhuangtai;
        protected Label Youbian;
        protected Label Youxiang;
        protected Image Zhaopian;
        protected Label Zhengzhimianmhao;
        protected Label Zhiwu;
        protected Label Zhuxiao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Xuesheng where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["XsId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zhuxiao.Text = list["Zhuxiao"].ToString();
                    this.Xuejihao.Text = list["Xuejihao"].ToString();
                    this.Xuehao.Text = list["Xuehao"].ToString();
                    this.Kaohao.Text = list["Kaohao"].ToString();
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Xingbie.Text = list["Xingbie"].ToString();
                    this.Chusheng.Text = list["Chusheng"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Mingzhu.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Mingzhu"].ToString());
                    this.Jiguan.Text = list["Jiguan"].ToString();
                    this.Chushengdi.Text = list["Chushengdi"].ToString();
                    this.RuxiaoShijian.Text = list["RuxiaoShijian"].ToString();
                    this.RuxiaoChengji.Text = list["RuxiaoChengji"].ToString();
                    this.Zhaopian.ImageUrl = "" + list["Zhaopian"].ToString() + "";
                    this.Zhengzhimianmhao.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Zhengzhimianmhao"].ToString());
                    this.Laiyuanxiao.Text = list["Laiyuanxiao"].ToString();
                    this.Shengfenzheng.Text = list["Shengfenzheng"].ToString();
                    this.Jiangkan.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Jiangkan"].ToString());
                    this.Dianhua.Text = list["Dianhua"].ToString();
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Youbian.Text = list["Youbian"].ToString();
                    this.Tongxin.Text = list["Tongxin"].ToString();
                    this.Youxiang.Text = list["Youxiang"].ToString();
                    this.HukouLeixing.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["HukouLeixing"].ToString());
                    this.HukouXingzhi.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["HukouXingzhi"].ToString());
                    this.Sancan.Text = list["Sancan"].ToString().Replace("0,", "").Replace(",0", "");
                    this.LiushouErtong.Text = list["LiushouErtong"].ToString();
                    this.Nongminggao.Text = list["Nongminggao"].ToString();
                    this.Junrenzinv.Text = list["Junrenzinv"].ToString();
                    this.Jiaoshizinv.Text = list["Jiaoshizinv"].ToString();
                    this.Danqinjiating.Text = list["Danqinjiating"].ToString();
                    this.Dushengzinv.Text = list["Dushengzinv"].ToString();
                    this.Pingkunsheng.Text = list["Pingkunsheng"].ToString();
                    string str2 = "select * from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]) + "] where  XsId='" + this.pulicss.GetFormatStr(base.Request.QueryString["XsId"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.ViewState["UrlBanji"] = reader2["Banji"].ToString();
                        this.BanJi.Text = this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", reader2["Banji"].ToString());
                        this.XuejiZhuangtai.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", reader2["XuejiZhuangtai"].ToString());
                        this.Zhiwu.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", reader2["Zhiwu"].ToString());
                        string str3 = "select Mingcheng,Nianji from qp_sch_Banji  where id='" + reader2["Banji"].ToString() + "'  ";
                        SqlDataReader reader3 = this.List.GetList(str3);
                        if (reader3.Read())
                        {
                            string str4 = reader3["Nianji"].ToString();
                            if (str4.IndexOf("小") >= 0)
                            {
                                this.Shengyuan1.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Shengyuan"].ToString());
                                this.Shengyuan1.Enabled = true;
                                this.Shengyuan2.Enabled = false;
                                this.Shengyuan3.Enabled = false;
                                this.NianjiName.Text = "小学";
                            }
                            if (str4.IndexOf("初") >= 0)
                            {
                                this.Shengyuan2.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Shengyuan"].ToString());
                                this.Shengyuan1.Enabled = false;
                                this.Shengyuan2.Enabled = true;
                                this.Shengyuan3.Enabled = false;
                                this.NianjiName.Text = "初中";
                            }
                            if (str4.IndexOf("高") >= 0)
                            {
                                this.Shengyuan3.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Shengyuan"].ToString());
                                this.Shengyuan1.Enabled = false;
                                this.Shengyuan2.Enabled = false;
                                this.Shengyuan3.Enabled = true;
                                this.NianjiName.Text = "高中";
                            }
                        }
                        reader3.Close();
                    }
                    reader2.Close();
                }
                list.Close();
            }
        }
    }
}


namespace xyoa.OpenWindows
{
    using qiupeng.crm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class OpenZiChangMc : Page
    {
        protected Label AllKuCun;
        protected Label Cangku;
        protected Label Danjia;
        protected Label Danwei;
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        protected HtmlForm form1;
        protected TextBox gncdid;
        protected Label Gongyinshang;
        protected HtmlHead Head1;
        protected Label KuCun;
        protected Label Label1;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected Label Quyu;
        protected Image TuPian;
        protected Label Xinghao;
        protected Label Zhuangtai;
        protected Label ZyIntro;
        protected Label ZyLeibie;
        protected Label ZyName;
        protected Label ZyNum;
        protected Label ZyXingzhi;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Name.Attributes.Add("readonly", "readonly");
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
                    this.AllKuCun.Text = list["AllKuCun"].ToString();
                    this.TuPian.ImageUrl = "/" + list["TuPian"].ToString();
                    this.Name.Text = list["ZyName"].ToString();
                    this.gncdid.Text = list["id"].ToString();
                }
                else
                {
                    this.Label1.Text = "请在左边的树形菜单中选择产品";
                }
                list.Close();
            }
        }
    }
}


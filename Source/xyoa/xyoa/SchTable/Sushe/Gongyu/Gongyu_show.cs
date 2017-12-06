namespace xyoa.SchTable.Sushe.Gongyu
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Gongyu_show : Page
    {
        protected Label Beizhu;
        protected Label Bianhao;
        protected Button Button2;
        protected Label Caichang;
        protected Label Dianhua;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected Label Fangjianshu;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Jiegou;
        protected Label Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Loucheng;
        protected Label Mianji;
        protected Label Mingcheng;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Shijian;
        protected Label Weizhi;
        protected Label Xiaoqu;
        protected Label Yongfei;
        protected Label Yongtu;
        protected Label Zhuangtai;
        protected Label ZyMianji;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Gongyu.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Gongyu where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Mingcheng.Text = list["Mingcheng"].ToString();
                    this.Bianhao.Text = list["Bianhao"].ToString();
                    this.Leixing.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Leixing"].ToString());
                    this.Yongtu.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Yongtu"].ToString());
                    this.Zhuangtai.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Zhuangtai"].ToString());
                    this.Jiegou.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Jiegou"].ToString());
                    this.Loucheng.Text = list["Loucheng"].ToString();
                    this.Fangjianshu.Text = list["Fangjianshu"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Dianhua.Text = list["Dianhua"].ToString();
                    this.ZyMianji.Text = list["ZyMianji"].ToString();
                    this.Yongfei.Text = list["Yongfei"].ToString();
                    this.Mianji.Text = list["Mianji"].ToString();
                    this.Caichang.Text = list["Caichang"].ToString();
                    this.Xiaoqu.Text = list["Xiaoqu"].ToString();
                    this.Weizhi.Text = list["Weizhi"].ToString();
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


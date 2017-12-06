namespace xyoa.SchTable.Xueji.Xueshengxinxi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueshengxinxi_tjxx_update : Page
    {
        protected TextBox Bibing;
        protected Button Button1;
        protected TextBox Danbai;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected TextBox Fei;
        protected TextBox Feiheliang;
        protected HtmlForm form1;
        protected TextBox Ganzang;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Meibo;
        protected DropDownList Pingjia;
        private publics pulicss = new publics();
        protected TextBox Qita;
        protected TextBox Sejue;
        protected TextBox Shayan1;
        protected TextBox Shayan2;
        protected TextBox Shengao;
        protected TextBox Shijian;
        protected TextBox Shili1;
        protected TextBox Shili2;
        protected TextBox Tizhong;
        protected TextBox Xinzang;
        protected TextBox Xiongwei;
        protected Label XsId;
        protected TextBox XsIdC;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;
        protected TextBox Xueya;
        protected TextBox Zhichi;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Stu_tjxx     Set Xueqi='", this.Xueqi.SelectedValue, "',Xueduan='", this.Xueduan.SelectedValue, "',Pingjia='", this.Pingjia.SelectedValue, "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Shengao='", this.pulicss.GetFormatStr(this.Shengao.Text), "',Tizhong='", this.pulicss.GetFormatStr(this.Tizhong.Text), "',Xiongwei='", this.pulicss.GetFormatStr(this.Xiongwei.Text), "',Feiheliang='", this.pulicss.GetFormatStr(this.Feiheliang.Text), 
                "',Xueya='", this.pulicss.GetFormatStr(this.Xueya.Text), "',Meibo='", this.pulicss.GetFormatStr(this.Meibo.Text), "',Shili1='", this.pulicss.GetFormatStr(this.Shili1.Text), "',Shili2='", this.pulicss.GetFormatStr(this.Shili2.Text), "',Shayan1='", this.pulicss.GetFormatStr(this.Shayan1.Text), "',Shayan2='", this.pulicss.GetFormatStr(this.Shayan2.Text), "',Sejue='", this.pulicss.GetFormatStr(this.Sejue.Text), "',Bibing='", this.pulicss.GetFormatStr(this.Bibing.Text), 
                "',Zhichi='", this.pulicss.GetFormatStr(this.Zhichi.Text), "',Xinzang='", this.pulicss.GetFormatStr(this.Xinzang.Text), "',Fei='", this.pulicss.GetFormatStr(this.Fei.Text), "',Ganzang='", this.pulicss.GetFormatStr(this.Ganzang.Text), "',Danbai='", this.pulicss.GetFormatStr(this.Danbai.Text), "',Qita='", this.pulicss.GetFormatStr(this.Qita.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            string str2 = "Update qp_sch_Xuesheng     Set Jiangkan='" + this.Pingjia.SelectedValue + "' where   id='" + this.XsIdC.Text + "'";
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("修改体检信息[" + this.XsId.Text + "]", "体检信息");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_tjxx.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_tjxx.aspx?id=" + base.Request.QueryString["Banji"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
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
                string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                string str2 = "select id,name  from qp_sch_DataFile where type='14' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_nothing(this.Pingjia, str2, "id", "name");
                string sql = "select * from qp_sch_Stu_tjxx where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsIdC.Text = list["XsId"].ToString();
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    this.Xueduan.SelectedValue = list["Xueduan"].ToString();
                    this.Pingjia.SelectedValue = list["Pingjia"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Shengao.Text = list["Shengao"].ToString();
                    this.Tizhong.Text = list["Tizhong"].ToString();
                    this.Xiongwei.Text = list["Xiongwei"].ToString();
                    this.Feiheliang.Text = list["Feiheliang"].ToString();
                    this.Xueya.Text = list["Xueya"].ToString();
                    this.Meibo.Text = list["Meibo"].ToString();
                    this.Shili1.Text = list["Shili1"].ToString();
                    this.Shili2.Text = list["Shili2"].ToString();
                    this.Shayan1.Text = list["Shayan1"].ToString();
                    this.Shayan2.Text = list["Shayan2"].ToString();
                    this.Sejue.Text = list["Sejue"].ToString();
                    this.Bibing.Text = list["Bibing"].ToString();
                    this.Zhichi.Text = list["Zhichi"].ToString();
                    this.Xinzang.Text = list["Xinzang"].ToString();
                    this.Fei.Text = list["Fei"].ToString();
                    this.Ganzang.Text = list["Ganzang"].ToString();
                    this.Danbai.Text = list["Danbai"].ToString();
                    this.Qita.Text = list["Qita"].ToString();
                }
                list.Close();
            }
        }
    }
}


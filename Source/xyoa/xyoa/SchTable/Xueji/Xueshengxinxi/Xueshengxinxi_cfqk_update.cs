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

    public class Xueshengxinxi_cfqk_update : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected TextBox Chufa;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leibie;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Riqi;
        protected Label XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;
        protected TextBox Yuanyin;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Stu_cfqk     Set Xueqi='", this.Xueqi.SelectedValue, "',Xueduan='", this.Xueduan.SelectedValue, "',Chufa='", this.pulicss.GetFormatStr(this.Chufa.Text), "',Leibie='", this.Leibie.SelectedValue, "',Riqi='", this.pulicss.GetFormatStr(this.Riqi.Text), "',Yuanyin='", this.pulicss.GetFormatStr(this.Yuanyin.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), 
                "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改处罚情况[" + this.XsId.Text + "]", "处罚情况");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_cfqk.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_cfqk.aspx?id=" + base.Request.QueryString["Banji"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
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
                string str2 = "select id,name  from qp_sch_DataFile where type='2' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_nothing(this.Leibie, str2, "id", "name");
                string sql = "select * from qp_sch_Stu_cfqk where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    this.Xueduan.SelectedValue = list["Xueduan"].ToString();
                    this.Chufa.Text = list["Chufa"].ToString();
                    this.Leibie.SelectedValue = list["Leibie"].ToString();
                    this.Riqi.Text = list["Riqi"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Yuanyin.Text = list["Yuanyin"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
            }
        }
    }
}


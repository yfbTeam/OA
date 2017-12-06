namespace xyoa.SchTable.Houqin.Xiaofang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xiaofang_update : Page
    {
        protected TextBox Baoyan;
        protected TextBox Beizhu;
        protected Button Button1;
        protected HtmlForm form1;
        protected TextBox GmShijian;
        protected TextBox Guanliren;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Miehuoqi;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox TbShijian;
        protected TextBox Weizhi;
        protected TextBox Xiaohuoshan;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Xiaofang     Set Weizhi='", this.pulicss.GetFormatStr(this.Weizhi.Text), "',TbShijian='", this.pulicss.GetFormatStr(this.TbShijian.Text), "',GmShijian='", this.pulicss.GetFormatStr(this.GmShijian.Text), "',Miehuoqi='", this.pulicss.GetFormatStr(this.Miehuoqi.Text), "',Xiaohuoshan='", this.pulicss.GetFormatStr(this.Xiaohuoshan.Text), "',Guanliren='", this.pulicss.GetFormatStr(this.Guanliren.Text), "',Baoyan='", this.pulicss.GetFormatStr(this.Baoyan.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), 
                "',UserName='", this.Session["Username"].ToString(), "',RealName='", this.Session["Realname"].ToString(), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改消防器材登记[" + this.Weizhi.Text + "]", "消防器材登记");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xiaofang.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Xiaofang where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Weizhi.Text = list["Weizhi"].ToString();
                    this.TbShijian.Text = list["TbShijian"].ToString();
                    this.GmShijian.Text = list["GmShijian"].ToString();
                    this.Miehuoqi.Text = list["Miehuoqi"].ToString();
                    this.Xiaohuoshan.Text = list["Xiaohuoshan"].ToString();
                    this.Guanliren.Text = list["Guanliren"].ToString();
                    this.Baoyan.Text = list["Baoyan"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


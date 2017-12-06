namespace xyoa.SchTable.Houqin.Xiaofang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xiaofang_add : Page
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
            string sql = "insert into qp_sch_Xiaofang   (Weizhi,TbShijian,GmShijian,Miehuoqi,Xiaohuoshan,Guanliren,Baoyan,Beizhu,UserName,RealName) values ('" + this.pulicss.GetFormatStr(this.Weizhi.Text) + "','" + this.pulicss.GetFormatStr(this.TbShijian.Text) + "','" + this.pulicss.GetFormatStr(this.GmShijian.Text) + "','" + this.pulicss.GetFormatStr(this.Miehuoqi.Text) + "','" + this.pulicss.GetFormatStr(this.Xiaohuoshan.Text) + "','" + this.pulicss.GetFormatStr(this.Guanliren.Text) + "','" + this.pulicss.GetFormatStr(this.Baoyan.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增消防器材登记[" + this.Weizhi.Text + "]", "消防器材登记");
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
                this.BindAttribute();
            }
        }
    }
}


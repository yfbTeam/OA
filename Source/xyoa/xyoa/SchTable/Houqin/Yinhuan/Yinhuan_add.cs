namespace xyoa.SchTable.Houqin.Yinhuan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Yinhuan_add : Page
    {
        protected Button Button1;
        protected TextBox Didian;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Renyuan;
        protected TextBox Shijian;
        protected TextBox Zuzhizhe;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_sch_Yinhuan   (Zuzhizhe,Shijian,Renyuan,Neirong,Didian,UserName,RealName) values ('" + this.pulicss.GetFormatStr(this.Zuzhizhe.Text) + "','" + this.pulicss.GetFormatStr(this.Shijian.Text) + "','" + this.pulicss.GetFormatStr(this.Renyuan.Text) + "','" + this.pulicss.GetFormatStr(this.Neirong.Text) + "','" + this.pulicss.GetFormatStr(this.Didian.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增隐患整改记录[" + this.Didian.Text + "]", "隐患整改记录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Yinhuan.aspx'</script>");
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


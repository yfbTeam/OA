namespace xyoa.SchTable.Houqin.Anquan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Anquan_update : Page
    {
        protected Button Button1;
        protected TextBox Canyu;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Miaosu;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Shijian;
        protected TextBox Zhuti;
        protected TextBox Zuzhizhe;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Anquan     Set Zuzhizhe='", this.pulicss.GetFormatStr(this.Zuzhizhe.Text), "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',Canyu='", this.pulicss.GetFormatStr(this.Canyu.Text), "',Miaosu='", this.pulicss.GetFormatStr(this.Miaosu.Text), "',UserName='", this.Session["Username"].ToString(), "',RealName='", this.Session["Realname"].ToString(), "' where   id='", int.Parse(base.Request.QueryString["id"]), 
                "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改学生安全教育[" + this.Zhuti.Text + "]", "学生安全教育");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Anquan.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Anquan where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zuzhizhe.Text = list["Zuzhizhe"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Canyu.Text = list["Canyu"].ToString();
                    this.Miaosu.Text = list["Miaosu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


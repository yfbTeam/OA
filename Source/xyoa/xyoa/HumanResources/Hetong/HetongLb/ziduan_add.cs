namespace xyoa.HumanResources.Hetong.HetongLb
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ziduan_add : Page
    {
        protected TextBox Bianhao;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Leixing;
        private Db List = new Db();
        protected TextBox Mingcheng;
        private publics pulicss = new publics();
        protected RadioButtonList Xianshi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_HetongZd  (LeibieID,Bianhao,Mingcheng,Leixing,Xianshi) values ('" + base.Request.QueryString["LeibieID"] + "','" + this.pulicss.GetFormatStr(this.Bianhao.Text) + "','" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "','" + this.Leixing.SelectedValue + "','" + this.Xianshi.SelectedValue + "')";
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");
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
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Bianhao.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
            }
        }
    }
}


namespace xyoa.HumanResources.Employee.YuangongJC
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongJC_add : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox JianchengYy;
        protected TextBox JiangchengSj;
        protected DropDownList Leibie;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Neirong;
        private publics pulicss = new publics();
        protected TextBox RealnameYG;
        protected TextBox UsernameYG;

        public void BindAttribute()
        {
            this.RealnameYG.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_YuangongJC  (UsernameYG,RealnameYG,Leibie,JiangchengSj,JianchengYy,Neirong,Beizhu,Jiangcheng) values ('" + this.UsernameYG.Text + "','" + this.pulicss.GetFormatStr(this.RealnameYG.Text) + "','" + this.Leibie.SelectedValue + "','" + this.pulicss.GetFormatStr(this.JiangchengSj.Text) + "','" + this.pulicss.GetFormatStr(this.JianchengYy.Text) + "','" + this.pulicss.GetFormatStr(this.Neirong.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "','" + base.Request.QueryString["Jiangcheng"].ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增" + this.ViewState["Jiangcheng"] + "记录", "" + this.ViewState["Jiangcheng"] + "记录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongJC.aspx?Jiangcheng=" + base.Request.QueryString["Jiangcheng"].ToString() + "'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ViewState["Jiangcheng"] = base.Request.QueryString["Jiangcheng"].ToString().Replace("1", "奖励").Replace("2", "惩罚");
                this.BindAttribute();
                string sQL = "select id,Name from qp_hr_YuangongLx where Type=" + base.Request.QueryString["Jiangcheng"].ToString().Replace("1", "11").Replace("2", "12") + " order by id asc";
                this.list.Bind_DropDownList_kong(this.Leibie, sQL, "id", "Name");
                this.JiangchengSj.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
}


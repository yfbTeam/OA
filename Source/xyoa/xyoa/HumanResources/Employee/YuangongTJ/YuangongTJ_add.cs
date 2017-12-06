namespace xyoa.HumanResources.Employee.YuangongTJ
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongTJ_add : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Jieguo;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Miaoshu;
        private publics pulicss = new publics();
        protected TextBox RealnameYG;
        protected TextBox Shijian;
        protected TextBox UsernameYG;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.RealnameYG.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_YuangongTJ  (UsernameYG,RealnameYG,Zhuti,Jieguo,Shijian,Miaoshu,Beizhu) values ('" + this.UsernameYG.Text + "','" + this.pulicss.GetFormatStr(this.RealnameYG.Text) + "','" + this.Zhuti.Text + "','" + this.Jieguo.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Shijian.Text) + "','" + this.pulicss.GetFormatStr(this.Miaoshu.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增体检记录", "体检记录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongTJ.aspx'</script>");
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
                string sQL = "select id,Name from qp_hr_YuangongLx where Type=14 order by id asc";
                this.list.Bind_DropDownList_kong(this.Jieguo, sQL, "id", "Name");
                this.Shijian.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
}


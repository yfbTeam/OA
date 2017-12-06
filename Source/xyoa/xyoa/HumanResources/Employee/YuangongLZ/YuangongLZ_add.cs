namespace xyoa.HumanResources.Employee.YuangongLZ
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongLZ_add : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Quxiang;
        protected TextBox RealnameYG;
        protected TextBox Riqi;
        protected TextBox UsernameYG;
        protected TextBox Yuanying;

        public void BindAttribute()
        {
            this.RealnameYG.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_YuangongLZ  (UsernameYG,RealnameYG,Leixing,Quxiang,Yuanying,Riqi,Beizhu) values ('" + this.UsernameYG.Text + "','" + this.pulicss.GetFormatStr(this.RealnameYG.Text) + "','" + this.Leixing.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Quxiang.Text) + "','" + this.pulicss.GetFormatStr(this.Yuanying.Text) + "','" + this.pulicss.GetFormatStr(this.Riqi.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "')";
            this.List.ExeSql(sql);
            string str2 = "Update qp_oa_username  Set StardType='0',Iflogin='0'  where Username='" + this.UsernameYG.Text + "'";
            this.List.ExeSql(str2);
            string str3 = "Update qp_hr_Yuangong  Set Zaizhi='2' where Username='" + this.UsernameYG.Text + "'";
            this.List.ExeSql(str3);
            this.pulicss.InsertLog("新增员工离职", "员工离职");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongLZ.aspx'</script>");
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
                string sQL = "select id,Name from qp_hr_YuangongLx where Type=9 order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "Name");
                this.Riqi.Text = DateTime.Now.ToShortDateString();
                this.pulicss.QuanXianBack("eeee4fa", this.Session["perstr"].ToString());
            }
        }
    }
}


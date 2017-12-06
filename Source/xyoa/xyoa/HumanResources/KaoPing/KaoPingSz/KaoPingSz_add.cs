namespace xyoa.HumanResources.KaoPing.KaoPingSz
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoPingSz_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Jishu;
        protected TextBox Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name1;
        protected TextBox Name2;
        protected TextBox Name3;
        protected TextBox Name4;
        protected TextBox Name5;
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Quanzhong1;
        protected TextBox Quanzhong2;
        protected TextBox Quanzhong3;
        protected TextBox Quanzhong4;
        protected TextBox Quanzhong5;
        protected TextBox QuanzhongMy;
        protected TextBox User1;
        protected TextBox User2;
        protected TextBox User3;
        protected TextBox User4;
        protected TextBox User5;
        protected TextBox Zongfen;

        public void BindAttribute()
        {
            this.Name1.Attributes.Add("readonly", "readonly");
            this.Name2.Attributes.Add("readonly", "readonly");
            this.Name3.Attributes.Add("readonly", "readonly");
            this.Name4.Attributes.Add("readonly", "readonly");
            this.Name5.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_KaoPingSz  (Leixing,Zongfen,Jishu,Neirong,QuanzhongMy,User1,Name1,Quanzhong1,User2,Name2,Quanzhong2,User3,Name3,Quanzhong3,User4,Name4,Quanzhong4,User5,Name5,Quanzhong5) values ('" + this.pulicss.GetFormatStr(this.Leixing.Text) + "','" + this.pulicss.GetFormatStr(this.Zongfen.Text) + "','" + this.pulicss.GetFormatStr(this.Jishu.SelectedValue) + "','" + this.pulicss.GetFormatStrbjq(this.Neirong.Value) + "','" + this.pulicss.GetFormatStr(this.QuanzhongMy.Text) + "','" + this.pulicss.GetFormatStr(this.User1.Text) + "','" + this.pulicss.GetFormatStr(this.Name1.Text) + "','" + this.pulicss.GetFormatStr(this.Quanzhong1.Text) + "','" + this.pulicss.GetFormatStr(this.User2.Text) + "','" + this.pulicss.GetFormatStr(this.Name2.Text) + "','" + this.pulicss.GetFormatStr(this.Quanzhong2.Text) + "','" + this.pulicss.GetFormatStr(this.User3.Text) + "','" + this.pulicss.GetFormatStr(this.Name3.Text) + "','" + this.pulicss.GetFormatStr(this.Quanzhong3.Text) + "','" + this.pulicss.GetFormatStr(this.User4.Text) + "','" + this.pulicss.GetFormatStr(this.Name4.Text) + "','" + this.pulicss.GetFormatStr(this.Quanzhong4.Text) + "','" + this.pulicss.GetFormatStr(this.User5.Text) + "','" + this.pulicss.GetFormatStr(this.Name5.Text) + "','" + this.pulicss.GetFormatStr(this.Quanzhong5.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增考评设置", "考评设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KaoPingSz.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("KaoPingSz.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                this.BindAttribute();
            }
        }
    }
}


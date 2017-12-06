namespace xyoa.MyWork.Naozhong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Naozhong_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        private Db List = new Db();
        protected CheckBox NbSms;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected CheckBox SjSms;
        protected TextBox titles;
        protected TextBox txtime;
        protected DropDownList Types;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",1,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.SjSms, ",1,", this.pulicss.GetSms());
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_Naozhong (titles,txtime,Types,Iftx,NbSms,SjSms,Username,LjUrl) values ('", this.pulicss.GetFormatStr(this.titles.Text), "','", this.pulicss.GetFormatStr(this.txtime.Text), "','", this.Types.SelectedValue, "','0','", this.pulicss.CheckBoxChange(this.NbSms.Checked.ToString()), "','", this.pulicss.CheckBoxChange(this.SjSms.Checked.ToString()), "','", this.Session["username"], "','/MyWork/Naozhong/Naozhong.aspx')" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增电子闹钟", "电子闹钟");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Naozhong.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Naozhong.aspx");
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


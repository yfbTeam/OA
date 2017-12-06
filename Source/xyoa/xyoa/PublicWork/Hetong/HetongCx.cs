namespace xyoa.PublicWork.Hetong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongCx : Page
    {
        protected Button Button2;
        protected TextBox Danwei;
        protected TextBox DaoqiE;
        protected TextBox DaoqiS;
        protected TextBox Endtime;
        protected DropDownList fangwei;
        protected DropDownList Fenlei;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Hetonghao;
        protected TextBox Jine1;
        protected TextBox Jine2;
        protected DropDownList LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList Qixian;
        protected TextBox Realname;
        protected TextBox Starttime;
        protected TextBox Username;
        protected DropDownList Zhuangtai;
        protected TextBox Zhuti;

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("HetongCxList.aspx?fangwei=" + this.fangwei.SelectedValue + "&Username=" + this.Username.Text + "0&Zhuti=" + this.Zhuti.Text + "&Hetonghao=" + this.Hetonghao.Text + "&Zhuangtai=" + this.Zhuangtai.SelectedValue + "&Fenlei=" + this.Fenlei.SelectedValue + "&Jine1=" + this.Jine1.Text + "&Jine2=" + this.Jine2.Text + "&Danwei=" + this.Danwei.Text + "&LcZhuangtai=" + this.LcZhuangtai.SelectedValue + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "&Qixian=" + this.Qixian.SelectedValue + "&DaoqiS=" + this.DaoqiS.Text + "&DaoqiE=" + this.DaoqiE.Text + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name from qp_oa_HetongLb order by id asc";
                this.list.Bind_DropDownListmodle(this.Fenlei, sQL, "id", "name");
                this.Realname.Attributes.Add("readonly", "readonly");
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
            }
        }
    }
}


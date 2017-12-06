namespace xyoa.SchTable.Sushe.Guanliren
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Guanliren_add : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList JianzhuId;
        protected TextBox Leixing;
        protected TextBox Lianxi;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Louceng;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Shijian;
        protected TextBox Xingming;
        protected TextBox Zhiwu;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_sch_SuSheGuanli   (Xingming,Leixing,Shijian,JianzhuId,Louceng,Zhiwu,Lianxi,Beizhu) values ('" + this.pulicss.GetFormatStr(this.Xingming.Text) + "','" + this.pulicss.GetFormatStr(this.Leixing.Text) + "','" + this.pulicss.GetFormatStr(this.Shijian.Text) + "','" + this.JianzhuId.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Louceng.Text) + "','" + this.pulicss.GetFormatStr(this.Zhiwu.Text) + "','" + this.pulicss.GetFormatStr(this.Lianxi.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增管理人员[" + this.Xingming.Text + "]", "管理人员");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Guanliren.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Guanliren.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng  from qp_sch_Gongyu  order by id asc";
                this.list.Bind_DropDownList_nothing(this.JianzhuId, sQL, "id", "Mingcheng");
                this.BindAttribute();
            }
        }
    }
}


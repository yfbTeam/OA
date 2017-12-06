namespace xyoa.HumanResources.PeiXun.TiKu.WenDaTi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WenDaTi_add : Page
    {
        protected TextBox Answer;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MingchengID;
        private publics pulicss = new publics();
        protected TextBox Titles;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_WenDaTi (MingchengID,Titles,Answer) values ('" + this.MingchengID.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Titles.Text) + "','" + this.pulicss.GetFormatStr(this.Answer.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增问答题", "问答题");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WenDaTi.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng from qp_hr_TikuLb order by id asc";
                this.list.Bind_DropDownList_kong(this.MingchengID, sQL, "id", "Mingcheng");
                this.BindAttribute();
            }
        }
    }
}


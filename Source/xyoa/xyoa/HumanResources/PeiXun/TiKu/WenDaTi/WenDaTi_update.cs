namespace xyoa.HumanResources.PeiXun.TiKu.WenDaTi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WenDaTi_update : Page
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
            string sql = string.Concat(new object[] { "Update qp_hr_WenDaTi  Set MingchengID='", this.MingchengID.SelectedValue, "',Titles='", this.pulicss.GetFormatStr(this.Titles.Text), "',Answer='", this.pulicss.GetFormatStr(this.Answer.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改问答题", "问答题");
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
                string sql = "select * from qp_hr_WenDaTi where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.MingchengID.SelectedValue = list["MingchengID"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Answer.Text = list["Answer"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


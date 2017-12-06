namespace xyoa.InfoManage.toupiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class toupiaobtmanage_add : Page
    {
        protected DropDownList bigtitle;
        protected Button Button1;
        protected TextBox color;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox title;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_toupiao  (title,color,piaoshu,bigId,tprealname,TpUsername) values ('" + this.pulicss.GetFormatStr(this.title.Text) + "','" + this.color.Text + "','0','" + this.bigtitle.SelectedValue + "','','')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增投票选项[" + this.pulicss.GetFormatStr(this.title.Text) + "]", "投票管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sQL = "select * from qp_oa_toupiaobt where username='" + this.Session["username"] + "' order by id desc";
                if (!base.IsPostBack)
                {
                    this.list.Bind_DropDownList_nothing(this.bigtitle, sQL, "id", "title");
                }
                if (!this.Page.IsPostBack)
                {
                    this.bigtitle.SelectedValue = base.Request.QueryString["id"].ToString();
                    this.BindAttribute();
                }
            }
        }
    }
}


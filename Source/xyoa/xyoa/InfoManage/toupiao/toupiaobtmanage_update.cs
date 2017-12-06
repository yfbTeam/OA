namespace xyoa.InfoManage.toupiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class toupiaobtmanage_update : Page
    {
        protected DropDownList bigtitle;
        protected Button Button1;
        protected TextBox color;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label piaoshu;
        private publics pulicss = new publics();
        protected TextBox title;
        protected Label YTpRealname;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_toupiao  Set title='", this.pulicss.GetFormatStr(this.title.Text), "',color='", this.pulicss.GetFormatStr(this.color.Text), "',bigId='", this.bigtitle.SelectedValue, "' where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改投票选项[" + this.title.Text + "]", "投票管理");
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
                    string sql = "select * from qp_oa_toupiao where id='" + base.Request.QueryString["id"] + "' ";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.title.Text = list["title"].ToString();
                        this.color.Text = list["color"].ToString();
                        this.piaoshu.Text = list["piaoshu"].ToString();
                        this.YTpRealname.Text = list["TpRealname"].ToString();
                        this.bigtitle.SelectedValue = list["bigId"].ToString();
                    }
                    list.Close();
                    this.BindAttribute();
                }
            }
        }
    }
}


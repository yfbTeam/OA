namespace xyoa.HumanResources.PeiXun.ShiJuan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ShiJuan_update : Page
    {
        protected Button Button1;
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MingchengID;
        private publics pulicss = new publics();
        protected TextBox Titles;
        protected RadioButtonList Zhuangtai;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button3.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_ShiJuan  Set MingchengID='", this.MingchengID.SelectedValue, "',Titles='", this.pulicss.GetFormatStr(this.Titles.Text), "',Zhuangtai='", this.Zhuangtai.SelectedValue, "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改试卷管理", "试卷管理");
            base.Response.Redirect("ShiJuanMxSd.aspx?ShijuanID=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "&MingchengID=" + this.MingchengID.SelectedValue + "");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_ShiJuan  Set MingchengID='", this.MingchengID.SelectedValue, "',Titles='", this.pulicss.GetFormatStr(this.Titles.Text), "',Zhuangtai='", this.Zhuangtai.SelectedValue, "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改试卷管理", "试卷管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ShiJuan.aspx'</script>");
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
                string sql = "select * from qp_hr_ShiJuan where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.MingchengID.SelectedValue = list["MingchengID"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


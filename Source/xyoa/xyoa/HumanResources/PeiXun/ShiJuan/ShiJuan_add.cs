namespace xyoa.HumanResources.PeiXun.ShiJuan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ShiJuan_add : Page
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
            string sql = "insert into qp_hr_ShiJuan (MingchengID,Titles,Zhuangtai) values ('" + this.MingchengID.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Titles.Text) + "','" + this.Zhuangtai.SelectedValue + "')";
            this.List.ExeSql(sql);
            string str2 = "select top 1 id,MingchengID from qp_hr_ShiJuan  order by id desc";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                base.Response.Redirect(string.Concat(new object[] { "ShiJuanMxZd.aspx?ShijuanID=", list["id"], "&MingchengID=", list["MingchengID"], "" }));
            }
            list.Close();
            this.pulicss.InsertLog("新增试卷管理", "试卷管理");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_ShiJuan (MingchengID,Titles,Zhuangtai) values ('" + this.MingchengID.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Titles.Text) + "','" + this.Zhuangtai.SelectedValue + "')";
            this.List.ExeSql(sql);
            string str2 = "select top 1 id,MingchengID from qp_hr_ShiJuan  order by id desc";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                base.Response.Redirect(string.Concat(new object[] { "ShiJuanMxSd.aspx?ShijuanID=", list["id"], "&MingchengID=", list["MingchengID"], "" }));
            }
            list.Close();
            this.pulicss.InsertLog("新增试卷管理", "试卷管理");
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


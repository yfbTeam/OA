namespace xyoa.HumanResources.Employee.YuangongFZ
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongFZ_updatew : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label RealnameYG;
        protected TextBox Riqi;
        protected TextBox UsernameYG;
        protected TextBox Yuanying;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_YuangongFZ  Set Leixing='", this.Leixing.SelectedValue, "',Riqi='", this.pulicss.GetFormatStr(this.Riqi.Text), "',Yuanying='", this.pulicss.GetFormatStr(this.Yuanying.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改员工复职", "员工复职");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongFZ.aspx'</script>");
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
                string sQL = "select id,Name from qp_hr_YuangongLx where Type=10 order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "Name");
                string sql = "select * from qp_hr_YuangongFZ  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.UsernameYG.Text = list["UsernameYG"].ToString();
                    this.RealnameYG.Text = list["RealnameYG"].ToString();
                    this.Riqi.Text = list["Riqi"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                    this.Yuanying.Text = list["Yuanying"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
                this.pulicss.QuanXianBack("eeee4gc", this.Session["perstr"].ToString());
            }
        }
    }
}


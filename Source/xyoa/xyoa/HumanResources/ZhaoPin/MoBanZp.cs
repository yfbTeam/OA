namespace xyoa.HumanResources.ZhaoPin
{
    using FredCK.FCKeditorV2;
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MoBanZp : Page
    {
        protected Button Button1;
        protected FCKeditor Content;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.pulicss.QuanXianBack("eeee1h", this.Session["perstr"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_MoBanZp  Set  Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "'  where Types='", int.Parse(base.Request.QueryString["Types"]), "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改模版", "人力资源");
            base.Response.Write("<script language=javascript>alert('提交成功！');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ViewState["FileName"] = this.divhr.HrMoban(base.Request.QueryString["Types"].ToString());
                string sql = "select * from qp_hr_MoBanZp  where Types='" + this.pulicss.GetFormatStr(base.Request.QueryString["Types"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Content.Value = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


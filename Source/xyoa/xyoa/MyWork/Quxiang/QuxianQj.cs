namespace xyoa.MyWork.Quxiang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class QuxianQj : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Leixing;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_QuxianQj  Set Leixing='" + this.Leixing.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改全局设置", "人员去向");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='QuxianQj.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_QuxianQj";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


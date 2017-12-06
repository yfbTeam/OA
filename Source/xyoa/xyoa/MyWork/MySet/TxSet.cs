namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TxSet : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList iftx;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList Sound;
        protected DropDownList txtime;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_MyReminded  Set iftx='", this.iftx.SelectedValue, "',txtime='", this.txtime.SelectedValue, "',Sound='", this.Sound.SelectedValue, "'  where  Username='", this.Session["username"], "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置消息提醒", "消息提醒设置");
            base.Response.Write("<script language=javascript>alert('提交成功，你可以刷新页面浏览效果！');window.location.href='TxSet.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MyReminded where  Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.iftx.SelectedValue = list["iftx"].ToString();
                    this.txtime.SelectedValue = list["txtime"].ToString();
                    this.Sound.SelectedValue = list["Sound"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BaobiaoSj_update_update : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected DropDownList FormFile;
        protected TextBox Gongsi;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected HtmlInputText Number;
        private publics pulicss = new publics();
        protected HtmlInputText TextBox2;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_BaobiaoGs  Set Gongsi='" + this.Gongsi.Text + "' where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select BiaodanId from qp_oa_Baobiao  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["keyid"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string sQL = "select id,Name from qp_oa_FormFile where KeyFile in (" + this.pulicss.GetFileNameNumber(list["BiaodanId"].ToString()) + ") and (type='[数字型]')  order by id asc";
                    this.list.Bind_DropDownListFormZd(this.FormFile, sQL, "id", "Name");
                }
                list.Close();
                string str3 = "select Gongsi from qp_oa_BaobiaoGs  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    this.Gongsi.Text = reader2["Gongsi"].ToString();
                }
                reader2.Close();
            }
        }
    }
}


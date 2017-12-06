namespace xyoa.SystemManage.WorkFlow
{
    using Ajax;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using xyoa;

    public class BaobiaoSj_update_gs : Page
    {
        protected HtmlForm form1;
        protected DropDownList FormFile;
        protected TextBox Gongsi;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected HtmlInputText Number;
        private publics pulicss = new publics();
        protected HtmlInputText TextBox2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    string sql = "select BiaodanId from qp_oa_Baobiao  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        string sQL = "select id,Name from qp_oa_FormFile where KeyFile in (" + this.pulicss.GetFileNameNumber(list["BiaodanId"].ToString()) + ") and (type='[数字型]')  order by id asc";
                        this.list.Bind_DropDownListFormZd(this.FormFile, sQL, "id", "Name");
                    }
                    list.Close();
                }
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            }
        }
    }
}


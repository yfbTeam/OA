namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BeijingXt : Page
    {
        protected Button Button4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected RadioButtonList tupian;

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sql = "select geturl from qp_oa_SysBg where id='" + this.tupian.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["url"] = list["geturl"].ToString();
            }
            list.Close();
            string str2 = "select * from qp_oa_Bg where username='" + this.Session["username"] + "'";
            SqlDataReader reader2 = this.List.GetList(str2);
            if (reader2.Read())
            {
                string str3 = string.Concat(new object[] { "Update qp_oa_Bg  Set url='", this.ViewState["url"], "' where username='", this.Session["username"], "'" });
                this.List.ExeSql(str3);
            }
            else
            {
                string str4 = string.Concat(new object[] { "insert into qp_oa_Bg (url,username) values ('/Images/skin1/bg/", this.ViewState["url"], "','", this.Session["username"], "')" });
                this.List.ExeSql(str4);
            }
            reader2.Close();
            this.pulicss.InsertLog("更新桌面背景", "桌面背景");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.top.location.reload();window.top.winClose('5432185');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,'<img src=\"' + url + '\" border=0  width=80 height=80/><br>' + name + '' as Lujing  from qp_oa_SysBg order by id asc";
                this.list.Bind_DropDownList_nothing1(this.tupian, sQL, "id", "Lujing");
                if (this.tupian.Items.Count > 0)
                {
                    this.tupian.Items[0].Selected = true;
                }
            }
        }
    }
}


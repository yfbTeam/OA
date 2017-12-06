namespace xyoa.MyWork.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyMetting_qx : Page
    {
        protected Button Button1;
        protected TextBox DlRealname;
        protected TextBox DlUsername;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.DlRealname.Attributes.Add("readonly", "readonly");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str;
            if (int.Parse(this.ViewState["geshu"].ToString()) > 1)
            {
                str = "Update qp_oa_MettingApply  Set NbPeopleName=replace(NbPeopleName,'" + this.DlRealname.Text + "(代理：" + this.Session["realname"].ToString() + "),','') where ID='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                this.List.ExeSql(str);
            }
            else
            {
                str = "Update qp_oa_MettingApply  Set NbPeopleUser=replace(NbPeopleUser,'" + this.DlUsername.Text + ",',''),NbPeopleName=replace(NbPeopleName,'" + this.DlRealname.Text + "(代理：" + this.Session["realname"].ToString() + "),','') where ID='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                this.List.ExeSql(str);
            }
            string sql = string.Concat(new object[] { "  Delete from qp_oa_MettingApply_Daili  where Hyid='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("取消会议代理人", "我的会议");
            base.Response.Write("<script language=javascript>alert('取消成功！');window.dialogArguments.window.location.href='MyMetting.aspx'; window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MettingApply_Daili where Hyid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    this.DlUsername.Text = reader["DlUsername"].ToString();
                    this.DlRealname.Text = reader["DlRealname"].ToString();
                }
                reader.Close();
                string str2 = "select * from qp_oa_MettingApply where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ViewState["NbPeopleUser"] = reader2["NbPeopleUser"].ToString();
                    int num = 0;
                    ArrayList list = new ArrayList();
                    string[] strArray = reader2["NbPeopleUser"].ToString().Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].ToString() == this.DlUsername.Text)
                        {
                            num++;
                        }
                    }
                    this.ViewState["geshu"] = "" + num + "";
                }
                reader2.Close();
                this.BindAttribute();
            }
        }
    }
}


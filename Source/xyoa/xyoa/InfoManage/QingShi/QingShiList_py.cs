namespace xyoa.InfoManage.QingShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class QingShiList_py : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox C1;
        protected CheckBox CheckBox2;
        protected Label Contents;
        protected HtmlForm form1;
        protected Label fujian;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        protected Label JsRealname;
        protected TextBox JsUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList normalcontent;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label PzTime;
        protected Label Realname;
        protected TextBox SpRemark;
        protected Label State;
        protected Label Titles;
        protected Label TxTime;
        protected Label Username;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.CheckBox2, ",11,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG1, ",11,", this.pulicss.GetSms());
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.C1.Checked)
            {
                this.pulicss.InsertMessage(string.Concat(new object[] { "您的请示报告“", this.Titles.Text, "”已批阅，批阅人：", this.Session["realname"], "" }), this.Username.Text, this.Realname.Text, "/InfoManage/QingShi/MyQingShi.aspx");
            }
            if (this.CheckBox2.Checked)
            {
                string str = "select username,MoveTel from qp_oa_Username where  username='" + this.Username.Text + "' ";
                SqlDataReader list = this.List.GetList(str);
                if (list.Read())
                {
                    this.pulicss.InsertSms(list["MoveTel"].ToString(), string.Concat(new object[] { "您的请示报告“", this.Titles.Text, "”已批阅，批阅人：", this.Session["realname"], "" }));
                }
                list.Close();
            }
            string sql = string.Concat(new object[] { "Update qp_oa_QingShi  Set Pizhu='", this.pulicss.GetFormatStr(this.SpRemark.Text), "', PzTime='", DateTime.Now.ToString(), "', State='已批阅'  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and JsUsername='", this.Session["username"], "' " });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='QingShiList.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("QingShiList.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_QingShi  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and JsUsername='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Contents.Text = list["Content"].ToString();
                    this.JsUsername.Text = list["JsUsername"].ToString();
                    this.JsRealname.Text = list["JsRealname"].ToString();
                    this.State.Text = list["State"].ToString();
                    this.TxTime.Text = list["TxTime"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Username.Text = list["Username"].ToString();
                    this.SpRemark.Text = list["Pizhu"].ToString();
                    this.PzTime.Text = list["PzTime"].ToString().Replace("1900-1-1 0:00:00", "未批阅").Replace("1900-01-01 00:00:00", "未批阅");
                }
                list.Close();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id desc";
                if (!base.IsPostBack)
                {
                    this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
                }
                this.BindAttribute();
            }
        }
    }
}


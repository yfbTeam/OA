namespace xyoa.InfoManage.YjBox
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YjBoxMg_show : Page
    {
        protected Label BoxId;
        protected Button Button2;
        protected CheckBox C1;
        protected CheckBox CheckBox2;
        protected Label Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox HfCotent;
        protected Label HfRealname;
        protected Label HfTimes;
        protected HtmlImage IMG1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList normalcontent;
        private publics pulicss = new publics();
        protected Label Titles;
        protected Label TxRealname;
        protected Label TxTime;
        protected Label Username;

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.C1.Checked)
            {
                this.pulicss.InsertMessage(string.Concat(new object[] { "您的填写意见“", this.Titles.Text, "”已反馈，反馈人：", this.Session["realname"], "<br>反馈内容：", this.HfCotent.Text, "" }), this.Username.Text, this.TxRealname.Text, "/InfoManage/YjBox/MyYjBox.aspx");
            }
            if (this.CheckBox2.Checked)
            {
                string str = "select username,MoveTel from qp_oa_Username where  username='" + this.Username.Text + "' ";
                SqlDataReader list = this.List.GetList(str);
                if (list.Read())
                {
                    this.pulicss.InsertSms(list["MoveTel"].ToString(), string.Concat(new object[] { "您的填写意见“", this.Titles.Text, "”已反馈，反馈人：", this.Session["realname"], "" }));
                }
                list.Close();
            }
            string sql = string.Concat(new object[] { "Update qp_oa_YjBox  Set HfCotent='", this.pulicss.GetFormatStr(this.HfCotent.Text), "', HfTimes='", DateTime.Now.ToString(), "',HfUsername='", this.Session["username"], "',HfRealname='", this.Session["realname"], "', IfHf='已回复'  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YjBoxMg.aspx'</script>");
        }

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
                    this.pulicss.QuanXianVis(this.CheckBox2, ",22,", this.pulicss.GetSms());
                    this.pulicss.QuanXianVis(this.IMG1, ",22,", this.pulicss.GetSms());
                    this.pulicss.QuanXianBack("aaaa5bb", this.Session["perstr"].ToString());
                    string sql = "select * from qp_oa_YjBox   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.BoxId.Text = list["BoxId"].ToString();
                        this.Titles.Text = list["Titles"].ToString();
                        this.Content.Text = this.pulicss.TbToLb(list["Content"].ToString());
                        this.TxRealname.Text = list["TxRealname"].ToString();
                        this.TxTime.Text = list["TxRealname"].ToString();
                        this.HfTimes.Text = DateTime.Now.ToString();
                        this.HfRealname.Text = this.Session["realname"].ToString();
                        this.Username.Text = list["Username"].ToString();
                        this.HfCotent.Text = list["HfCotent"].ToString();
                    }
                    list.Close();
                    string str2 = string.Concat(new object[] { "select * from qp_oa_YjBox where id='", base.Request.QueryString["id"], "' and  CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   >0" });
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (!reader2.Read())
                    {
                        string str3 = string.Concat(new object[] { "Update qp_oa_YjBox  Set YdUsername=YdUsername+'", this.Session["username"], ",',YdRealname=YdRealname+'", this.Session["realname"], ",'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                        this.List.ExeSql(str3);
                    }
                    reader2.Close();
                }
                string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id desc";
                if (!base.IsPostBack)
                {
                    this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
                }
            }
        }
    }
}


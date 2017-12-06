namespace xyoa.InfoManage.Taolunzu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TaolunzuLogin : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Name;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Shuoming;
        protected Label Username;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "select * from qp_oa_TaolunzuSq where Keyid='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                list.Close();
                base.Response.Write("<script language=javascript>alert('已申请，请等待创建人确认！');window.location.href='Taolunzu.aspx'</script>");
            }
            else
            {
                list.Close();
                this.pulicss.InsertMessage(string.Concat(new object[] { "", this.Session["realname"], "申请加入讨论组：", this.Name.Text, "" }), this.Username.Text, this.Realname.Text, "/InfoManage/Taolunzu/TaolunzuMy_update.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
                string str2 = string.Concat(new object[] { "insert into qp_oa_TaolunzuSq  (Keyid,Username,Realname,Settimes) values ('", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                this.List.ExeSql(str2);
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Taolunzu.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Taolunzu.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_Taolunzu  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Username.Text = list["Username"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    if (list["Leixing"].ToString() == "2")
                    {
                        base.Response.Redirect("TaolunzuView.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
                        this.Button1.Visible = false;
                    }
                    if (list["Leixing"].ToString() == "1")
                    {
                        string str2 = string.Concat(new object[] { "select * from qp_oa_TaolunzuRy  where Keyid='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
                        SqlDataReader reader2 = this.List.GetList(str2);
                        if (reader2.Read())
                        {
                            base.Response.Redirect("TaolunzuView.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
                        }
                        reader2.Close();
                        this.Shuoming.Text = "需要申请才能加入，请点击【申请加入】按钮。";
                        this.Button1.Visible = true;
                    }
                    if (list["Leixing"].ToString() == "0")
                    {
                        this.Shuoming.Text = "此讨论组只允许参与人加入，可以联系创建人：" + list["Realname"].ToString() + "";
                        this.Button1.Visible = false;
                    }
                }
                list.Close();
            }
        }
    }
}


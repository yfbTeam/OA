namespace xyoa.MyWork.MakeTing
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MakeTing : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected TextBox content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox txtime;
        protected DropDownList Types;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_MakeTing where username='" + this.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "Update qp_oa_MakeTing  Set content='", this.content.Text, "' where username='", this.Session["username"], "'" });
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = string.Concat(new object[] { "insert into qp_oa_MakeTing (content,Username) values ('", this.pulicss.GetFormatStr(this.content.Text), "','", this.Session["username"], "')" });
                this.List.ExeSql(str3);
            }
            list.Close();
            this.pulicss.InsertLog("更新记事便签", "记事便签");
            if (this.CheckBox1.Checked)
            {
                this.pulicss.InsertNaoZhong("" + this.pulicss.GetFormatStr(this.content.Text) + "", this.txtime.Text, this.Types.SelectedValue, "1", "0", "/MyWork/MakeTing/MakeTing.aspx");
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MakeTing.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_MakeTing where username='" + this.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "Update qp_oa_MakeTing  Set content='", this.content.Text, "' where username='", this.Session["username"], "'" });
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = string.Concat(new object[] { "insert into qp_oa_MakeTing (content,Username) values ('", this.pulicss.GetFormatStr(this.content.Text), "','", this.Session["username"], "')" });
                this.List.ExeSql(str3);
            }
            list.Close();
            string str4 = string.Concat(new object[] { "insert into qp_oa_MakeListTing (content,Username) values ('", this.pulicss.GetFormatStr(this.content.Text), "','", this.Session["username"], "')" });
            this.List.ExeSql(str4);
            this.pulicss.InsertLog("更新并保存记事便签", "记事便签");
            if (this.CheckBox1.Checked)
            {
                this.pulicss.InsertNaoZhong("" + this.pulicss.GetFormatStr(this.content.Text) + "", this.txtime.Text, this.Types.SelectedValue, "1", "0", "/MyWork/MakeTing/MakeTing.aspx");
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MakeTing.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MakeTing where username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.content.Text = list["content"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


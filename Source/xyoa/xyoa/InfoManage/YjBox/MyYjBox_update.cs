namespace xyoa.InfoManage.YjBox
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyYjBox_update : Page
    {
        protected DropDownList BoxId;
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected TextBox Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Titles;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str;
            if (this.CheckBox1.Checked)
            {
                str = string.Concat(new object[] { "Update qp_oa_YjBox  Set HfCotent='未回复',HfUsername='未回复',HfRealname='未回复',HfTimes='未回复',IfHf='未回复',YdUsername='',YdRealname='',BoxId='", this.BoxId.SelectedValue, "',Titles='", this.pulicss.GetFormatStr(this.Titles.Text), "',Content='", this.pulicss.GetFormatStr(this.Content.Text), "' ,TxRealname='匿名'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                this.List.ExeSql(str);
            }
            else
            {
                str = string.Concat(new object[] { "Update qp_oa_YjBox  Set HfCotent='未回复',HfUsername='未回复',HfRealname='未回复',HfTimes='未回复',IfHf='未回复',YdUsername='',YdRealname='',BoxId='", this.BoxId.SelectedValue, "',Titles='", this.pulicss.GetFormatStr(this.Titles.Text), "',Content='", this.pulicss.GetFormatStr(this.Content.Text), "' ,TxRealname='", this.Session["realname"], "'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                this.List.ExeSql(str);
            }
            this.pulicss.InsertLog("修改意见", "我的意见");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyYjBox.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyYjBox.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Name from  qp_oa_YjBoxSz";
                this.list.Bind_DropDownList_nothing(this.BoxId, sQL, "id", "Name");
                string sql = string.Concat(new object[] { "select * from qp_oa_YjBox   where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.BoxId.SelectedValue = list["BoxId"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Content.Text = list["Content"].ToString();
                    if (list["TxRealname"].ToString() == "匿名")
                    {
                        this.CheckBox1.Checked = true;
                    }
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


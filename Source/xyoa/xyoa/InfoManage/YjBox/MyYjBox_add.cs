namespace xyoa.InfoManage.YjBox
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyYjBox_add : Page
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
                str = string.Concat(new object[] { "insert into qp_oa_YjBox  (YdUsername,YdRealname,BoxId,Titles,Content,TxRealname,TxTime,Username,HfCotent,HfUsername,HfRealname,HfTimes,IfHf) values ('','','", this.BoxId.SelectedValue, "','", this.pulicss.GetFormatStr(this.Titles.Text), "','", this.pulicss.GetFormatStr(this.Content.Text), "','匿名','", DateTime.Now.ToString(), "','", this.Session["Username"], "','未回复','未回复','未回复','未回复','未回复')" });
                this.List.ExeSql(str);
            }
            else
            {
                str = string.Concat(new object[] { "insert into qp_oa_YjBox  (YdUsername,YdRealname,BoxId,Titles,Content,TxRealname,TxTime,Username,HfCotent,HfUsername,HfRealname,HfTimes,IfHf) values ('','','", this.BoxId.SelectedValue, "','", this.pulicss.GetFormatStr(this.Titles.Text), "','", this.pulicss.GetFormatStr(this.Content.Text), "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "','", this.Session["Username"], "','未回复','未回复','未回复','未回复','未回复')" });
                this.List.ExeSql(str);
            }
            this.pulicss.InsertLog("新增意见", "我的意见");
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
                this.BindAttribute();
            }
        }
    }
}


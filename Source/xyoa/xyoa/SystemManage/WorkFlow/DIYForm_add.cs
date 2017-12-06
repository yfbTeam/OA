namespace xyoa.SystemManage.WorkFlow
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DIYForm_add : Page
    {
        protected Button Button1;
        protected Button Button5;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected FCKeditor d_content;
        protected HtmlForm form1;
        protected DropDownList FormFile;
        protected TextBox FormName;
        protected DropDownList FormType;
        protected HtmlHead Head1;
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected LinkButton LinkButton4;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected TextBox paixu;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.LinkButton2.Attributes["onclick"] = "javascript:return updatefile();";
            this.LinkButton4.Attributes["onclick"] = "javascript:return delfile();";
        }

        public void BindList()
        {
            string sQL = "select Number,Name+Type as aaa from qp_oa_FormFile where KeyFile='" + this.Number.Text + "' order by id asc";
            this.list.Bind_DropDownListForm(this.FormFile, sQL, "Number", "aaa");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select id from qp_oa_DIYForm where Number='" + this.Number.Text + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = "Update qp_oa_DIYForm  Set paixu='" + this.paixu.Text + "',TypeId='" + this.FormType.SelectedValue + "',FormName='" + this.pulicss.GetFormatStr(this.FormName.Text) + "',FormContent='" + this.pulicss.GetFormatStrbjq(this.d_content.Value) + "'  where Number='" + this.Number.Text + "'";
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = string.Concat(new object[] { "insert into qp_oa_DIYForm (ScUsername,paixu,Number,TypeId,FormName,FormContent,Username,Realname) values ('','", this.paixu.Text, "','", this.Number.Text, "','", this.FormType.SelectedValue, "','", this.pulicss.GetFormatStr(this.FormName.Text), "','", this.pulicss.GetFormatStrbjq(this.d_content.Value), "','", this.Session["Username"], "','", this.Session["Realname"], "')" });
                this.List.ExeSql(str3);
            }
            list.Close();
            this.pulicss.InsertLog("新增表单[" + this.FormName.Text + "]", "表单设计");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.nextrform.location.href='DIYForm_show.aspx?id=" + this.FormType.SelectedValue + "';window.close();</script>");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string sql = "select id from qp_oa_DIYForm where Number='" + this.Number.Text + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = "Update qp_oa_DIYForm  Set paixu='" + this.paixu.Text + "',TypeId='" + this.FormType.SelectedValue + "',FormName='" + this.pulicss.GetFormatStr(this.FormName.Text) + "',FormContent='" + this.pulicss.GetFormatStrbjq(this.d_content.Value) + "'  where Number='" + this.Number.Text + "'";
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = string.Concat(new object[] { "insert into qp_oa_DIYForm (ScUsername,paixu,Number,TypeId,FormName,FormContent,Username,Realname) values ('','", this.paixu.Text, "','", this.Number.Text, "','", this.FormType.SelectedValue, "','", this.pulicss.GetFormatStr(this.FormName.Text), "','", this.pulicss.GetFormatStrbjq(this.d_content.Value), "','", this.Session["Username"], "','", this.Session["Realname"], "')" });
                this.List.ExeSql(str3);
            }
            list.Close();
            this.pulicss.InsertLog("新增表单[" + this.FormName.Text + "]", "表单设计");
            base.Response.Write("<script language=javascript>alert('提交成功！');</script>");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.BindList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sQL = "select id,name from qp_oa_FormType order by paixun asc";
                if (!base.IsPostBack)
                {
                    this.list.Bind_DropDownList_nothing(this.FormType, sQL, "id", "name");
                    this.BindAttribute();
                }
                if (!base.IsPostBack)
                {
                    try
                    {
                        this.FormType.SelectedValue = base.Request.QueryString["FormId"].ToString();
                    }
                    catch
                    {
                    }
                    Random random = new Random();
                    string str2 = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str2 + "";
                }
                this.BindList();
            }
        }
    }
}


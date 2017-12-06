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

    public class DIYFormSj : Page
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
            string sql = string.Concat(new object[] { "Update qp_oa_DIYForm  Set paixu='", this.paixu.Text, "',TypeId='", this.FormType.SelectedValue, "',FormName='", this.pulicss.GetFormatStr(this.FormName.Text), "',FormContent='", this.pulicss.GetFormatStrbjq(this.d_content.Value), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "Update qp_oa_WorkFlowNode  Set FormName='", this.pulicss.GetFormatStr(this.FormName.Text), "' where FormId='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("修改表单[" + this.FormName.Text + "]", "表单设计");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='DIYForm_show.aspx?id=" + this.FormType.SelectedValue + "';window.close();</script>");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_DIYForm  Set paixu='", this.paixu.Text, "',TypeId='", this.FormType.SelectedValue, "',FormName='", this.pulicss.GetFormatStr(this.FormName.Text), "',FormContent='", this.pulicss.GetFormatStrbjq(this.d_content.Value), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改表单[" + this.FormName.Text + "]", "表单设计");
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
                    string sql = "select * from qp_oa_DIYForm  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.FormType.SelectedValue = list["TypeId"].ToString();
                        this.FormName.Text = list["FormName"].ToString();
                        this.d_content.Value = list["FormContent"].ToString();
                        this.paixu.Text = list["paixu"].ToString();
                    }
                    list.Close();
                }
                this.BindList();
            }
        }
    }
}


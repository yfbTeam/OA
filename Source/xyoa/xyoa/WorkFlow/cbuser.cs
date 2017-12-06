namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class cbuser : Page
    {
        protected TextBox acceptrealname;
        protected TextBox acceptusername;
        protected Button Button1;
        protected CheckBox C1;
        protected CheckBox CheckBox2;
        protected TextBox Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.CheckBox2, ",14,", this.pulicss.GetSms());
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.acceptrealname.Attributes.Add("readonly", "readonly");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            str2 = "" + this.acceptusername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + "'" + strArray[i] + "',";
            }
            str = str + "'0'";
            string sql = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str + ") ";
            SqlDataReader reader = this.List.GetList(sql);
            while (reader.Read())
            {
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage("" + this.Content.Text + "", reader["username"].ToString(), reader["realname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                }
                if (this.CheckBox2.Checked)
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), this.Content.Text);
                }
            }
            reader.Close();
            this.pulicss.InsertLog("催办工作流", "工作管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select Name from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Content.Text = "工作流程中，您有未办理待办工作“" + list["Name"].ToString() + "”，请及时办理！";
                }
                list.Close();
                this.acceptusername.Text = base.Request.QueryString["user"].ToString();
                this.acceptrealname.Text = base.Request.QueryString["name"].ToString();
                this.BindAttribute();
            }
        }
    }
}


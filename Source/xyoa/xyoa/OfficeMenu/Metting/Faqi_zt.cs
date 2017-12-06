namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Faqi_zt : Page
    {
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox3;
        protected Label Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG2;
        private Db List = new Db();
        protected Label Name;
        protected Label NbPeopleUser;
        private publics pulicss = new publics();
        protected Label Starttime;
        protected DropDownList State;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            str2 = "" + this.NbPeopleUser.Text + "";
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
                if (this.CheckBox1.Checked)
                {
                    this.pulicss.InsertMessage("您有会议需要参加：【" + this.Name.Text + "】，会议时间：" + this.Starttime.Text + "至" + this.Endtime.Text + "", reader["username"].ToString(), reader["realname"].ToString(), "/MyWork/Metting/MyMetting.aspx");
                }
                if (this.CheckBox3.Checked)
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), "您有会议室需要参加：【" + this.Name.Text + "】，会议时间：" + this.Starttime.Text + "至" + this.Endtime.Text + "");
                }
            }
            reader.Close();
            string str4 = string.Concat(new object[] { "Update qp_oa_MettingApply  Set State='", this.State.SelectedValue, "' where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
            this.List.ExeSql(str4);
            base.Response.Write("<script language=javascript>alert('设置成功！');window.dialogArguments.window.location.href='Faqi.aspx'; window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_MettingApply where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.State.SelectedValue = list["State"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.NbPeopleUser.Text = list["NbPeopleUser"].ToString();
                }
                list.Close();
                this.BindAttribute();
                this.pulicss.QuanXianVis(this.CheckBox3, ",8,", this.pulicss.GetSms());
                this.pulicss.QuanXianVis(this.IMG2, ",8,", this.pulicss.GetSms());
            }
        }
    }
}


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

    public class NetMetting_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox C1;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        protected HtmlImage IMG2;
        protected TextBox Introduction;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox MettingHeader;
        protected TextBox MettingHeaderUser;
        protected TextBox MettingIp;
        protected TextBox Name;
        protected TextBox NbPeopleName;
        protected TextBox NbPeopleUser;
        private publics pulicss = new publics();
        protected TextBox Remark;
        protected TextBox Starttime;
        protected TextBox State;
        protected TextBox Titles;
        protected TextBox WbPeople;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.CheckBox2, ",8,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG1, ",8,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.CheckBox3, ",8,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG2, ",8,", this.pulicss.GetSms());
            this.MettingHeader.Attributes.Add("readonly", "readonly");
            this.NbPeopleName.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select username,realname,MoveTel from qp_oa_Username where  username='" + this.MettingHeaderUser.Text + "' ";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的会议室需要主持：", this.Name.Text, "，申请人", this.Session["realname"], "" }), this.MettingHeaderUser.Text, this.MettingHeader.Text, "/MyWork/Metting/MyNetMettingZc.aspx");
                }
                if (this.CheckBox2.Checked)
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), string.Concat(new object[] { "您有新的网络会议室需要主持：", this.Name.Text, "，申请人", this.Session["realname"], "" }));
                }
            }
            reader.Close();
            string str2 = null;
            string str3 = null;
            str3 = "" + this.NbPeopleUser.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str3.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str2 = str2 + "'" + strArray[i] + "',";
            }
            str2 = str2 + "'0'";
            string str4 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str2 + ") ";
            SqlDataReader reader2 = this.List.GetList(str4);
            while (reader2.Read())
            {
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的网络会议室需要参加：", this.Name.Text, "，发起人", this.Session["realname"], "" }), reader2["username"].ToString(), reader2["realname"].ToString(), "/MyWork/Metting/MynetMettingWcy.aspx");
                }
                if (this.CheckBox2.Checked)
                {
                    this.pulicss.InsertSms(reader2["MoveTel"].ToString(), string.Concat(new object[] { "您有新的网络会议室需要参加：", this.Name.Text, "，发起人", this.Session["realname"], "" }));
                }
            }
            reader2.Close();
            string str5 = string.Concat(new object[] { 
                "Update qp_oa_NetMetting    Set Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Title='", this.pulicss.GetFormatStr(this.Titles.Text), "',Introduction='", this.pulicss.GetFormatStr(this.Introduction.Text), "',WbPeople='", this.pulicss.GetFormatStr(this.WbPeople.Text), "',NbPeopleUser='", this.pulicss.GetFormatStr(this.NbPeopleUser.Text), "',NbPeopleName='", this.pulicss.GetFormatStr(this.NbPeopleName.Text), "',MettingHeaderUser='", this.MettingHeaderUser.Text, "',MettingHeader='", this.MettingHeader.Text, 
                "',MettingIp='", this.MettingIp.Text, "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "',Endtime='", this.pulicss.GetFormatStr(this.Endtime.Text), "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(str5);
            if (base.Request.QueryString["back"] == "1")
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NetMetting.aspx'</script>");
            }
            if (base.Request.QueryString["back"] == "2")
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NetMettingJx.aspx'</script>");
            }
            if (base.Request.QueryString["back"] == "3")
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NetMettingJs.aspx'</script>");
            }
            this.pulicss.InsertLog("修改网络会议[" + this.Name.Text + "]", "网络会议");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["back"] == "1")
            {
                base.Response.Redirect("NetMetting.aspx");
            }
            if (base.Request.QueryString["back"] == "2")
            {
                base.Response.Redirect("NetMettingJx.aspx");
            }
            if (base.Request.QueryString["back"] == "3")
            {
                base.Response.Redirect("NetMettingJs.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_NetMetting where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Titles.Text = list["Title"].ToString();
                    this.Introduction.Text = list["Introduction"].ToString();
                    this.WbPeople.Text = list["WbPeople"].ToString();
                    this.NbPeopleUser.Text = list["NbPeopleUser"].ToString();
                    this.NbPeopleName.Text = list["NbPeopleName"].ToString();
                    this.MettingHeaderUser.Text = list["MettingHeaderUser"].ToString();
                    this.MettingHeader.Text = list["MettingHeader"].ToString();
                    this.MettingIp.Text = list["MettingIp"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.State.Text = this.pulicss.SystemCode("8", list["State"].ToString());
                    this.Remark.Text = list["Remark"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


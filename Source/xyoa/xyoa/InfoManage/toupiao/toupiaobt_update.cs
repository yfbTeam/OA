namespace xyoa.InfoManage.toupiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class toupiaobt_update : Page
    {
        protected Button Button2;
        protected Button Button5;
        protected CheckBox C1;
        protected TextBox contents;
        protected HtmlForm form1;
        protected TextBox Gkrealname;
        protected TextBox Gkusername;
        protected HtmlHead Head1;
        protected RadioButtonList ifopen;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox title;
        protected RadioButtonList type;
        protected RadioButtonList xuanze;

        public void BindAttribute()
        {
            this.Gkrealname.Attributes.Add("readonly", "readonly");
            this.Button5.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("toupiaobt.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string str4;
            SqlDataReader reader;
            string sql = string.Concat(new object[] { 
                "Update qp_oa_toupiaobt  Set contents='", this.pulicss.GetFormatStr(this.contents.Text), "',title='", this.pulicss.GetFormatStr(this.title.Text), "',xuanze='", this.xuanze.SelectedValue, "',Gkusername='", this.pulicss.GetFormatStr(this.Gkusername.Text), "',Gkrealname='", this.Gkrealname.Text, "',type='", this.type.SelectedValue, "',ifopen='", this.ifopen.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), 
                "'   and username='", this.Session["username"], "'"
             });
            this.List.ExeSql(sql);
            string str2 = null;
            string str3 = null;
            str3 = "" + this.Gkusername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str3.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str2 = str2 + "'" + strArray[i] + "',";
            }
            str2 = str2 + "'0'";
            if (this.Gkusername.Text == "0")
            {
                str4 = "select username,realname,Email,MoveTel from qp_oa_Username ";
                reader = this.List.GetList(str4);
                while (reader.Read())
                {
                    if (this.C1.Checked)
                    {
                        this.pulicss.InsertMessage("您有新的投票需要参加！", reader["username"].ToString(), reader["realname"].ToString(), "/InfoManage/toupiao/toupiao.aspx");
                    }
                }
                reader.Close();
            }
            else
            {
                str4 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str2 + ") ";
                reader = this.List.GetList(str4);
                while (reader.Read())
                {
                    if (this.C1.Checked)
                    {
                        this.pulicss.InsertMessage("您有新的投票需要参加！", reader["username"].ToString(), reader["realname"].ToString(), "/InfoManage/toupiao/toupiao.aspx");
                    }
                }
                reader.Close();
            }
            this.pulicss.InsertLog("新增投票", "投票管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='toupiaobt.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_toupiaobt where id='", base.Request.QueryString["id"], "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.title.Text = list["title"].ToString();
                    this.contents.Text = list["contents"].ToString();
                    this.xuanze.Text = list["xuanze"].ToString();
                    this.Gkusername.Text = list["Gkusername"].ToString();
                    this.Gkrealname.Text = list["Gkrealname"].ToString();
                    this.type.SelectedValue = list["type"].ToString();
                    this.ifopen.SelectedValue = list["ifopen"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


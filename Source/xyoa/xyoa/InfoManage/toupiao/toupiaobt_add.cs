namespace xyoa.InfoManage.toupiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class toupiaobt_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button5;
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
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_toupiaobt  (contents,title,xuanze,username,realname,Gkusername,Gkrealname,type,ifopen) values ('", this.pulicss.GetFormatStr(this.contents.Text), "','", this.pulicss.GetFormatStr(this.title.Text), "','", this.xuanze.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Gkusername.Text, "','", this.Gkrealname.Text, "','", this.type.SelectedValue, 
                "','", this.ifopen.SelectedValue, "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增投票[" + this.pulicss.GetFormatStr(this.title.Text) + "]", "投票管理");
            string str2 = "select top 1 id from qp_oa_toupiaobt where username='" + this.Session["username"] + "' order by id desc";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                base.Response.Redirect("toupiaobt_add_next.aspx?bigid=" + list["id"] + "");
            }
            list.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("toupiaobt.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_toupiaobt  (contents,title,xuanze,username,realname,Gkusername,Gkrealname,type,ifopen) values ('", this.pulicss.GetFormatStr(this.contents.Text), "','", this.pulicss.GetFormatStr(this.title.Text), "','", this.xuanze.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Gkusername.Text, "','", this.Gkrealname.Text, "','", this.type.SelectedValue, 
                "','", this.ifopen.SelectedValue, "')"
             });
            this.List.ExeSql(sql);
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
                this.BindAttribute();
            }
        }
    }
}


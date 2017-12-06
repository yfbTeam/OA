namespace xyoa.Resources.ResMg
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ResFp_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox C1;
        protected HtmlForm form1;
        protected TextBox GmNum;
        protected TextBox GmTime;
        protected TextBox Gongyinshang;
        protected HtmlHead Head1;
        protected TextBox JbName;
        protected TextBox JsRealname;
        protected TextBox JsUsername;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Shuoming;
        protected TextBox ZyId;
        protected TextBox ZyName;

        public void BindAttribute()
        {
            this.ZyName.Attributes.Add("readonly", "readonly");
            this.JsRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_ResFp  (States,ZyId,JsUsername,JsRealname,JbName,GmTime,GmNum,Shuoming,Username,Realname,Settime) values ('正常','", this.pulicss.GetFormatStr(this.ZyId.Text), "','", this.pulicss.GetFormatStr(this.JsUsername.Text), "','", this.pulicss.GetFormatStr(this.JsRealname.Text), "','", this.pulicss.GetFormatStr(this.JbName.Text), "','", this.pulicss.GetFormatStr(this.GmTime.Text), "','", this.pulicss.GetFormatStr(this.GmNum.Text), "','", this.pulicss.GetFormatStr(this.Shuoming.Text), "','", this.Session["username"], 
                "','", this.Session["realname"], "','", DateTime.Now.ToString(), "')"
             });
            this.List.ExeSql(sql);
            string str2 = "select top 1 id from qp_oa_ResFp  where username='" + this.Session["username"] + "' order by id desc ";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                string str3 = "insert into qp_oa_MyRes  (ZyId,shuliang,Laiyuan,KeyId,Username,Realname,Settime) values ('" + this.pulicss.GetFormatStr(this.ZyId.Text) + "','" + this.GmNum.Text + "','分配','" + list["id"].ToString() + "','" + this.JsUsername.Text + "','" + this.JsRealname.Text + "','" + DateTime.Now.ToString() + "')";
                this.List.ExeSql(str3);
            }
            list.Close();
            string str4 = "select username,realname,MoveTel from qp_oa_Username where  username='" + this.JsUsername.Text + "' ";
            SqlDataReader reader2 = this.List.GetList(str4);
            if (reader2.Read() && this.C1.Checked)
            {
                this.pulicss.InsertMessage("您有新的物品，物品名称：" + this.ZyName.Text + "，分配数量：" + this.GmNum.Text + "，经办人：" + this.JbName.Text + "", this.JsUsername.Text, this.JsRealname.Text, "/Resources/MyRes/MyResData.aspx");
            }
            reader2.Close();
            string str5 = "Update qp_oa_ResourcesAdd    Set KuCun=KuCun-" + this.GmNum.Text + " where id='" + this.ZyId.Text + "'";
            this.List.ExeSql(str5);
            this.pulicss.InsertLog("新增物品报废", "物品报废");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ResFp.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ResFp.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.JbName.Text = this.Session["realname"].ToString();
                this.GmTime.Text = DateTime.Now.ToShortDateString();
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.Resources.ResMg
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ResFp_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox C1;
        protected CheckBox CheckBox2;
        protected HtmlForm form1;
        protected TextBox GmNum;
        protected TextBox GmNums;
        protected TextBox GmTime;
        protected HtmlHead Head1;
        protected HtmlImage IMG2;
        protected TextBox JbName;
        protected TextBox JsRealname;
        protected TextBox JsUsername;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Shuoming;
        protected TextBox States;
        protected TextBox ZyId;
        protected TextBox ZyName;

        public void BindAttribute()
        {
            this.JsRealname.Attributes.Add("readonly", "readonly");
            this.ZyName.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_ResFp  Set  JbName='", this.pulicss.GetFormatStr(this.JbName.Text), "',GmTime='", this.pulicss.GetFormatStr(this.GmTime.Text), "',GmNum='", this.pulicss.GetFormatStr(this.GmNum.Text), "',JsUsername='", this.JsUsername.Text, "',JsRealname='", this.JsRealname.Text, "',Shuoming='", this.Shuoming.Text, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  and Username='", this.Session["username"], 
                "' "
             });
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "Update qp_oa_MyRes  Set  shuliang='", this.GmNum.Text, "'  where KeyId='", int.Parse(base.Request.QueryString["id"]), "' and Laiyuan='分配'  " });
            this.List.ExeSql(str2);
            string str3 = "select username,realname,MoveTel from qp_oa_Username where  username='" + this.JsUsername.Text + "' ";
            SqlDataReader list = this.List.GetList(str3);
            if (list.Read() && this.C1.Checked)
            {
                this.pulicss.InsertMessage("您有新的物品，物品名称：" + this.ZyName.Text + "，分配数量：" + this.GmNum.Text + "，经办人：" + this.JbName.Text + "", this.JsUsername.Text, this.JsRealname.Text, "/Resources/MyRes/MyResData.aspx");
            }
            list.Close();
            string str4 = "Update qp_oa_ResourcesAdd    Set KuCun=KuCun+" + this.GmNums.Text + "-" + this.GmNum.Text + " where id='" + this.ZyId.Text + "'";
            this.List.ExeSql(str4);
            this.pulicss.InsertLog("修改物品报废", "物品报废");
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
                string sql = string.Concat(new object[] { "select * from qp_oa_ResFp  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'  and Username='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ZyId.Text = list["ZyId"].ToString();
                    this.JbName.Text = list["JbName"].ToString();
                    this.GmTime.Text = DateTime.Parse(list["GmTime"].ToString()).ToShortDateString();
                    this.GmNum.Text = list["GmNum"].ToString();
                    this.GmNums.Text = list["GmNum"].ToString();
                    this.JsUsername.Text = list["JsUsername"].ToString();
                    this.JsRealname.Text = list["JsRealname"].ToString();
                    this.Shuoming.Text = list["Shuoming"].ToString();
                    this.States.Text = list["States"].ToString();
                    if (list["States"].ToString() == "正常")
                    {
                        this.Button1.Enabled = true;
                        this.Button1.Text = "提 交";
                    }
                    else
                    {
                        this.Button1.Enabled = false;
                        this.Button1.Text = "当前状态不允许修改";
                    }
                }
                list.Close();
                string str2 = "select * from qp_oa_ResourcesAdd  where id='" + this.ZyId.Text + "'  ";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ZyName.Text = reader2["ZyName"].ToString();
                }
                reader2.Close();
                this.BindAttribute();
            }
        }
    }
}


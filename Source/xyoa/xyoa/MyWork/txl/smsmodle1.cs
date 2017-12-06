namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class smsmodle1 : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox MoveTel;
        protected TextBox Msg;
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:window.close();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.pulicss.InsertSms(this.pulicss.GetFormatStr(this.MoveTel.Text), this.pulicss.GetFormatStr(this.Msg.Text));
            this.pulicss.InsertLog("发送手机短信[" + this.Name.Text + "]", "个人通讯录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.BindAttribute();
                }
                if (!this.Page.IsPostBack)
                {
                    this.pulicss.QuanXianVis(this.Button1, ",3,", this.pulicss.GetSms());
                    string sql = "select * from qp_oa_MyGroup where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Name.Text = list["Name"].ToString();
                        this.MoveTel.Text = list["HMoveTel"].ToString();
                    }
                    list.Close();
                    this.BindAttribute();
                }
            }
        }
    }
}


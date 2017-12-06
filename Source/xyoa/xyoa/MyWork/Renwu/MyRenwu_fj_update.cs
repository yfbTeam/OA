namespace xyoa.MyWork.Renwu
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRenwu_fj_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected FCKeditor Content;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox SetTime;
        protected TextBox Starttime;
        protected DropDownList State;
        protected TextBox titles;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:window.close();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_RenwuFj  Set  titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "',Endtime='", this.pulicss.GetFormatStr(this.Endtime.Text), "',State='", this.State.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改任务", "任务分解");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.reload();window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_RenwuFj  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.titles.Text = list["titles"].ToString();
                    this.Starttime.Text = DateTime.Parse(list["Starttime"].ToString()).ToShortDateString();
                    this.Endtime.Text = DateTime.Parse(list["Endtime"].ToString()).ToShortDateString();
                    this.State.SelectedValue = list["State"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Content.Value = list["Content"].ToString();
                    this.SetTime.Text = list["SetTime"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


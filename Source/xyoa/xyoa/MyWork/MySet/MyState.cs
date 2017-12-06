namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyState : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Shuoming;
        protected RadioButtonList States;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_MyState  Set States='", this.States.SelectedValue, "',Shuoming='", this.pulicss.GetFormatStr(this.Shuoming.Text), "'  where  Username='", this.Session["username"], "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置我的状态", "我的状态");
            base.Response.Write("<script language=javascript>alert('提交成功！');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MyState where  Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.States.SelectedValue = list["States"].ToString();
                    this.Shuoming.Text = list["Shuoming"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }

        protected void States_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.States.SelectedValue == "无")
            {
                this.Shuoming.Text = "";
            }
            if (this.States.SelectedValue == "在线")
            {
                this.Shuoming.Text = "您好，有事请联系我哟~!!";
            }
            if (this.States.SelectedValue == "会议")
            {
                this.Shuoming.Text = "您好，我去开会了，请稍后再联系我~!!";
            }
            if (this.States.SelectedValue == "外出")
            {
                this.Shuoming.Text = "您好，我外出办事了，请稍后再联系我~!!";
            }
            if (this.States.SelectedValue == "用餐")
            {
                this.Shuoming.Text = "您好，我外出用餐了，请稍后再联系我~!!";
            }
            if (this.States.SelectedValue == "出差")
            {
                this.Shuoming.Text = "您好，我出差了，请稍后再联系我~!!";
            }
            if (this.States.SelectedValue == "请假")
            {
                this.Shuoming.Text = "您好，我没有上班，请稍后再联系我~!!";
            }
            if (this.States.SelectedValue == "休假")
            {
                this.Shuoming.Text = "您好，我没有上班，请稍后再联系我~!!";
            }
        }
    }
}


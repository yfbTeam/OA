namespace xyoa.SchTable.SysMag.Xueqi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueqi_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Mingcheng;
        protected TextBox MingchengS;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected CheckBoxList QiyongXueduan;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.Mingcheng.SelectedValue != this.MingchengS.Text)
            {
                string str = "select * from qp_sch_Xueqi where Mingcheng='" + this.pulicss.GetFormatStr(this.Mingcheng.SelectedValue) + "'";
                SqlDataReader list = this.List.GetList(str);
                if (list.Read())
                {
                    base.Response.Write("<script language=javascript>alert('学期名称已存在！');</script>");
                    list.Close();
                    return;
                }
                list.Close();
            }
            string sql = string.Concat(new object[] { "Update qp_sch_Xueqi     Set Mingcheng='", this.pulicss.GetFormatStr(this.Mingcheng.SelectedValue), "',QiyongXueduan='", this.pulicss.GetChecked(this.QiyongXueduan), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改学期设置[" + this.Mingcheng.Text + "]", "学期设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueqi.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Xueqi.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Xueqi where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.MingchengS.Text = list["Mingcheng"].ToString();
                    this.Mingcheng.SelectedValue = list["Mingcheng"].ToString();
                    this.pulicss.SetChecked(this.QiyongXueduan, list["QiyongXueduan"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


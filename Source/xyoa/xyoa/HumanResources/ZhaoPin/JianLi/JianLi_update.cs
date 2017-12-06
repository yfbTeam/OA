namespace xyoa.HumanResources.ZhaoPin.JianLi
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class JianLi_update : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Lianxi;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected RadioButtonList Xingbie;
        protected TextBox Xingming;
        protected DropDownList Zhiwei;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_JianLi   Set Xingming='", this.pulicss.GetFormatStr(this.Xingming.Text), "',Xingbie='", this.Xingbie.SelectedValue, "',Zhiwei='", this.Zhiwei.SelectedValue, "',Lianxi='", this.pulicss.GetFormatStr(this.Lianxi.Text), "',Neirong='", this.pulicss.GetFormatStrbjq(this.Neirong.Value), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改简历", "简历管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='JianLi.aspx?Zhuangtai=1'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                string sql = "select * from qp_hr_JianLi where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Xingbie.SelectedValue = list["Xingbie"].ToString();
                    this.Zhiwei.SelectedValue = list["Zhiwei"].ToString();
                    this.Lianxi.Text = list["Lianxi"].ToString();
                    this.Neirong.Value = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


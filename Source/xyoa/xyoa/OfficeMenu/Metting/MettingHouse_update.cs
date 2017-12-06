namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingHouse_update : Page
    {
        protected TextBox Address;
        protected Button Button1;
        protected Button Button2;
        protected TextBox Equipment;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Introduction;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox PeopleNum;
        private publics pulicss = new publics();
        protected TextBox Remark;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_MettingHouse    Set Name='", this.pulicss.GetFormatStr(this.Name.Text), "',PeopleNum='", this.pulicss.GetFormatStr(this.PeopleNum.Text), "',Equipment='", this.pulicss.GetFormatStr(this.Equipment.Text), "',Introduction='", this.pulicss.GetFormatStr(this.Introduction.Text), "',Address='", this.pulicss.GetFormatStr(this.Address.Text), "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改会议室[" + this.Name.Text + "]", "会议室管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MettingHouse.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MettingHouse.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MettingHouse where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.PeopleNum.Text = list["PeopleNum"].ToString();
                    this.Equipment.Text = list["Equipment"].ToString();
                    this.Introduction.Text = list["Introduction"].ToString();
                    this.Address.Text = list["Address"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WBGroup_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox CAddress;
        protected TextBox CFax;
        protected TextBox CName;
        protected TextBox CTel;
        protected TextBox CZipCode;
        protected TextBox Email;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox HMoveTel;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox MsnNum;
        protected TextBox Name;
        protected TextBox Number;
        protected TextBox OtherName;
        protected TextBox Post;
        private publics pulicss = new publics();
        protected TextBox QQNum;
        protected TextBox Remark;
        protected DropDownList Sex;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_WBGroup     Set Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Sex='", this.pulicss.GetFormatStr(this.Sex.SelectedValue), "',OtherName='", this.pulicss.GetFormatStr(this.OtherName.Text), "',Post='", this.pulicss.GetFormatStr(this.Post.Text), "',CName='", this.pulicss.GetFormatStr(this.CName.Text), "',CAddress='", this.pulicss.GetFormatStr(this.CAddress.Text), "',CZipCode='", this.pulicss.GetFormatStr(this.CZipCode.Text), "',CTel='", this.pulicss.GetFormatStr(this.CTel.Text), 
                "',CFax='", this.pulicss.GetFormatStr(this.CFax.Text), "',HMoveTel='", this.pulicss.GetFormatStr(this.HMoveTel.Text), "',Email='", this.pulicss.GetFormatStr(this.Email.Text), "',QQNum='", this.pulicss.GetFormatStr(this.QQNum.Text), "',MsnNum='", this.pulicss.GetFormatStr(this.MsnNum.Text), "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改外部通讯录[" + this.Name.Text + "]", "外部通讯录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WBGroup.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WBGroup.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_WBGroup where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Sex.SelectedValue = list["Sex"].ToString();
                    this.OtherName.Text = list["OtherName"].ToString();
                    this.Post.Text = list["Post"].ToString();
                    this.CName.Text = list["CName"].ToString();
                    this.CAddress.Text = list["CAddress"].ToString();
                    this.CZipCode.Text = list["CZipCode"].ToString();
                    this.CTel.Text = list["CTel"].ToString();
                    this.CFax.Text = list["CFax"].ToString();
                    this.HMoveTel.Text = list["HMoveTel"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.QQNum.Text = list["QQNum"].ToString();
                    this.MsnNum.Text = list["MsnNum"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WBGroup_add : Page
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
                "insert into qp_oa_WBGroup (Name,Sex,OtherName,Post,CName,CAddress,CZipCode,CTel,CFax,HMoveTel,Email,QQNum,MsnNum,Remark,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(this.Name.Text), "','", this.pulicss.GetFormatStr(this.Sex.SelectedValue), "','", this.pulicss.GetFormatStr(this.OtherName.Text), "','", this.pulicss.GetFormatStr(this.Post.Text), "','", this.pulicss.GetFormatStr(this.CName.Text), "','", this.pulicss.GetFormatStr(this.CAddress.Text), "','", this.pulicss.GetFormatStr(this.CZipCode.Text), "','", this.pulicss.GetFormatStr(this.CTel.Text), 
                "','", this.pulicss.GetFormatStr(this.CFax.Text), "','", this.pulicss.GetFormatStr(this.HMoveTel.Text), "','", this.pulicss.GetFormatStr(this.Email.Text), "','", this.pulicss.GetFormatStr(this.QQNum.Text), "','", this.pulicss.GetFormatStr(this.MsnNum.Text), "','", this.pulicss.GetFormatStr(this.Remark.Text), "','", this.Session["Username"], "','", this.Session["Realname"], 
                "','", DateTime.Now.ToString(), "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增外部通讯录[" + this.Name.Text + "]", "外部通讯录");
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
                this.BindAttribute();
            }
        }
    }
}


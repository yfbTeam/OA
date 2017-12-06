namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyGroup_add : Page
    {
        protected TextBox BothDay;
        protected Button Button1;
        protected Button Button2;
        protected TextBox CAddress;
        protected TextBox CFax;
        protected TextBox Children;
        protected TextBox CName;
        protected TextBox CTel;
        protected TextBox CZipCode;
        protected TextBox Email;
        protected HtmlForm form1;
        protected DropDownList GroupName;
        protected TextBox HAddress;
        protected HtmlHead Head1;
        protected TextBox HMoveTel;
        protected TextBox HTel;
        protected TextBox HXiaoTel;
        protected TextBox HZipCode;
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
        protected TextBox Spouses;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_MyGroup (GroupName,Name,Sex,BothDay,OtherName,Post,Spouses,Children,CName,CAddress,CZipCode,CTel,CFax,HAddress,HZipCode,HTel,HMoveTel,HXiaoTel,Email,QQNum,MsnNum,Remark,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(this.GroupName.SelectedValue), "','", this.pulicss.GetFormatStr(this.Name.Text), "','", this.pulicss.GetFormatStr(this.Sex.SelectedValue), "','", this.pulicss.GetFormatStr(this.BothDay.Text), "','", this.pulicss.GetFormatStr(this.OtherName.Text), "','", this.pulicss.GetFormatStr(this.Post.Text), "','", this.pulicss.GetFormatStr(this.Spouses.Text), "','", this.pulicss.GetFormatStr(this.Children.Text), 
                "','", this.pulicss.GetFormatStr(this.CName.Text), "','", this.pulicss.GetFormatStr(this.CAddress.Text), "','", this.pulicss.GetFormatStr(this.CZipCode.Text), "','", this.pulicss.GetFormatStr(this.CTel.Text), "','", this.pulicss.GetFormatStr(this.CFax.Text), "','", this.pulicss.GetFormatStr(this.HAddress.Text), "','", this.pulicss.GetFormatStr(this.HZipCode.Text), "','", this.pulicss.GetFormatStr(this.HTel.Text), 
                "','", this.pulicss.GetFormatStr(this.HMoveTel.Text), "','", this.pulicss.GetFormatStr(this.HXiaoTel.Text), "','", this.pulicss.GetFormatStr(this.Email.Text), "','", this.pulicss.GetFormatStr(this.QQNum.Text), "','", this.pulicss.GetFormatStr(this.MsnNum.Text), "','", this.pulicss.GetFormatStr(this.Remark.Text), "','", this.Session["Username"], "','", this.Session["Realname"], 
                "','", DateTime.Now.ToString(), "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增个人通讯录[" + this.Name.Text + "]", "个人通讯录");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyGroup.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyGroup.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_GroupType  where username='" + this.Session["username"] + "' order by id asc";
                this.list.Bind_DropDownList_nothing(this.GroupName, sQL, "id", "name");
                this.BindAttribute();
            }
        }
    }
}


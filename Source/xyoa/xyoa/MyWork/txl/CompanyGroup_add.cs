namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CompanyGroup_add : Page
    {
        protected TextBox Address;
        protected TextBox BothDay;
        protected DropDownList BuMenId;
        protected Button Button1;
        protected Button Button2;
        protected TextBox Email;
        protected TextBox Fax;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox HomeTel;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox MoveTel;
        protected TextBox MsnNum;
        protected TextBox Name;
        protected TextBox NbNum;
        protected TextBox Number;
        protected TextBox Officetel;
        private publics pulicss = new publics();
        protected TextBox QQNum;
        protected TextBox Remark;
        protected DropDownList Sex;
        protected DropDownList Zhiweiid;
        protected TextBox ZipCode;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_CompanyGroup   (Name,BuMenId,JueseId,Zhiweiid,Sex,BothDay,Officetel,Fax,MoveTel,HomeTel,Email,QQNum,MsnNum,NbNum,Address,ZipCode,Remark,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(this.Name.Text), "','", this.BuMenId.SelectedValue, "','0','", this.Zhiweiid.SelectedValue, "','", this.pulicss.GetFormatStr(this.Sex.SelectedValue), "','", this.pulicss.GetFormatStr(this.BothDay.Text), "','", this.pulicss.GetFormatStr(this.Officetel.Text), "','", this.pulicss.GetFormatStr(this.Fax.Text), "','", this.pulicss.GetFormatStr(this.MoveTel.Text), 
                "','", this.pulicss.GetFormatStr(this.HomeTel.Text), "','", this.pulicss.GetFormatStr(this.Email.Text), "','", this.pulicss.GetFormatStr(this.QQNum.Text), "','", this.pulicss.GetFormatStr(this.MsnNum.Text), "','", this.pulicss.GetFormatStr(this.NbNum.Text), "','", this.pulicss.GetFormatStr(this.Address.Text), "','", this.pulicss.GetFormatStr(this.ZipCode.Text), "','", this.pulicss.GetFormatStr(this.Remark.Text), 
                "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增职位[" + this.Name.Text + "]", "职位管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CompanyGroup.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CompanyGroup.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListNothing("qp_oa_Bumen", this.BuMenId, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_nothing(this.Zhiweiid, sQL, "id", "name");
                this.BindAttribute();
            }
        }
    }
}


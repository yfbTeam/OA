namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CompanyGroup_update : Page
    {
        protected TextBox Address;
        protected TextBox BothDay;
        protected Label BuMenId;
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
        protected Label Name;
        protected TextBox NbNum;
        protected TextBox Number;
        protected TextBox Officetel;
        private publics pulicss = new publics();
        protected TextBox QQNum;
        protected TextBox Remark;
        protected DropDownList Sex;
        protected TextBox XtUsername;
        protected Label Zhiweiid;
        protected TextBox ZipCode;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_CompanyGroup     Set Sex='", this.Sex.SelectedValue, "',BothDay='", this.BothDay.Text, "',Officetel='", this.Officetel.Text, "',Fax='", this.Fax.Text, "',MoveTel='", this.MoveTel.Text, "',HomeTel='", this.HomeTel.Text, "',Email='", this.Email.Text, "',QQNum='", this.QQNum.Text, 
                "',MsnNum='", this.MsnNum.Text, "',NbNum='", this.NbNum.Text, "',Address='", this.Address.Text, "',ZipCode='", this.ZipCode.Text, "',Remark='", this.Remark.Text, "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            string str2 = "Update qp_oa_MyData  Set Bothday='" + this.pulicss.GetFormatStr(this.BothDay.Text) + "',ICQ='" + this.pulicss.GetFormatStr(this.NbNum.Text) + "',Sex='" + this.pulicss.GetFormatStr(this.Sex.SelectedValue) + "',Tel='" + this.pulicss.GetFormatStr(this.Officetel.Text) + "',Fax='" + this.pulicss.GetFormatStr(this.Fax.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Email='" + this.pulicss.GetFormatStr(this.Email.Text) + "',QQNum='" + this.pulicss.GetFormatStr(this.QQNum.Text) + "',Msn='" + this.pulicss.GetFormatStr(this.MsnNum.Text) + "',Address='" + this.pulicss.GetFormatStr(this.Address.Text) + "',ZipCode='" + this.pulicss.GetFormatStr(this.ZipCode.Text) + "',HomeTel='" + this.pulicss.GetFormatStr(this.HomeTel.Text) + "' where  Username='" + this.XtUsername.Text + "'";
            this.List.ExeSql(str2);
            string str3 = "Update qp_oa_username  Set Bothday='" + this.pulicss.GetFormatStr(this.BothDay.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Sex='" + this.Sex.SelectedValue + "',Email='" + this.pulicss.GetFormatStr(this.Email.Text) + "' where  Username='" + this.XtUsername.Text + "'";
            this.List.ExeSql(str3);
            string str4 = "Update qp_hr_Yuangong  Set Chusheng='" + this.pulicss.GetFormatStr(this.BothDay.Text) + "',Youbian='" + this.pulicss.GetFormatStr(this.ZipCode.Text) + "',Neibu='" + this.pulicss.GetFormatStr(this.NbNum.Text) + "',MSN='" + this.pulicss.GetFormatStr(this.MsnNum.Text) + "',QQ='" + this.pulicss.GetFormatStr(this.QQNum.Text) + "',Chuanzhen='" + this.pulicss.GetFormatStr(this.Fax.Text) + "',Dizhi='" + this.pulicss.GetFormatStr(this.Address.Text) + "',Jiating='" + this.pulicss.GetFormatStr(this.HomeTel.Text) + "',Youxiang='" + this.pulicss.GetFormatStr(this.Email.Text) + "',Shouji='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Xingbie='" + this.Sex.SelectedValue.Replace("男", "1").Replace("女", "2") + "' where Username='" + this.XtUsername.Text + "'";
            this.List.ExeSql(str4);
            this.pulicss.InsertLog("修改单位通讯录[" + this.Name.Text + "]", "单位通讯录");
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
                string sql = "select * from qp_oa_CompanyGroup where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.BuMenId.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BuMenId"].ToString());
                    this.Zhiweiid.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["Zhiweiid"].ToString());
                    this.Sex.SelectedValue = list["Sex"].ToString();
                    this.Officetel.Text = list["Officetel"].ToString();
                    this.Fax.Text = list["Fax"].ToString();
                    this.MoveTel.Text = list["MoveTel"].ToString();
                    this.HomeTel.Text = list["HomeTel"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.QQNum.Text = list["QQNum"].ToString();
                    this.MsnNum.Text = list["MsnNum"].ToString();
                    this.NbNum.Text = list["NbNum"].ToString();
                    this.Address.Text = list["Address"].ToString();
                    this.ZipCode.Text = list["ZipCode"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                    this.BothDay.Text = list["BothDay"].ToString();
                    this.XtUsername.Text = list["XtUsername"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


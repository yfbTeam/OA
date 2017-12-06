namespace xyoa.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyGroup_update : Page
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
                "Update qp_oa_MyGroup     Set GroupName='", this.pulicss.GetFormatStr(this.GroupName.SelectedValue), "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Sex='", this.pulicss.GetFormatStr(this.Sex.SelectedValue), "',BothDay='", this.pulicss.GetFormatStr(this.BothDay.Text), "',OtherName='", this.pulicss.GetFormatStr(this.OtherName.Text), "',Post='", this.pulicss.GetFormatStr(this.Post.Text), "',Spouses='", this.pulicss.GetFormatStr(this.Spouses.Text), "',Children='", this.pulicss.GetFormatStr(this.Children.Text), 
                "',CName='", this.pulicss.GetFormatStr(this.CName.Text), "',CAddress='", this.pulicss.GetFormatStr(this.CAddress.Text), "',CZipCode='", this.pulicss.GetFormatStr(this.CZipCode.Text), "',CTel='", this.pulicss.GetFormatStr(this.CTel.Text), "',CFax='", this.pulicss.GetFormatStr(this.CFax.Text), "',HAddress='", this.pulicss.GetFormatStr(this.HAddress.Text), "',HZipCode='", this.pulicss.GetFormatStr(this.HZipCode.Text), "',HTel='", this.pulicss.GetFormatStr(this.HTel.Text), 
                "',HMoveTel='", this.pulicss.GetFormatStr(this.HMoveTel.Text), "',HXiaoTel='", this.pulicss.GetFormatStr(this.HXiaoTel.Text), "',Email='", this.pulicss.GetFormatStr(this.Email.Text), "',QQNum='", this.pulicss.GetFormatStr(this.QQNum.Text), "',MsnNum='", this.pulicss.GetFormatStr(this.MsnNum.Text), "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], 
                "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改个人通讯录[" + this.Name.Text + "]", "个人通讯录");
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
                string sql = string.Concat(new object[] { "select * from qp_oa_MyGroup where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.GroupName.SelectedValue = list["GroupName"].ToString();
                    this.Sex.SelectedValue = list["Sex"].ToString();
                    this.BothDay.Text = list["BothDay"].ToString();
                    this.OtherName.Text = list["OtherName"].ToString();
                    this.Post.Text = list["Post"].ToString();
                    this.Spouses.Text = list["Spouses"].ToString();
                    this.Children.Text = list["Children"].ToString();
                    this.CName.Text = list["CName"].ToString();
                    this.CAddress.Text = list["CAddress"].ToString();
                    this.CZipCode.Text = list["CZipCode"].ToString();
                    this.CTel.Text = list["CTel"].ToString();
                    this.CFax.Text = list["CFax"].ToString();
                    this.HAddress.Text = list["HAddress"].ToString();
                    this.HZipCode.Text = list["HZipCode"].ToString();
                    this.HTel.Text = list["HTel"].ToString();
                    this.HMoveTel.Text = list["HMoveTel"].ToString();
                    this.HXiaoTel.Text = list["HXiaoTel"].ToString();
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


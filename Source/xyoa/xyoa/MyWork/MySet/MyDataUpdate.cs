namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyDataUpdate : Page
    {
        protected TextBox Address;
        protected TextBox Bothday;
        protected Button Button1;
        protected TextBox Email;
        protected TextBox Fax;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox HomeTel;
        protected TextBox ICQ;
        private Db List = new Db();
        protected TextBox LittleTel;
        protected TextBox MoveTel;
        protected TextBox Msn;
        protected Label Post;
        private publics pulicss = new publics();
        protected TextBox QQNum;
        protected Label Realname;
        protected DropDownList Sex;
        protected TextBox Tel;
        protected Label Unit;
        protected TextBox Worknum;
        protected TextBox ZipCode;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_MyData  Set Worknum='", this.pulicss.GetFormatStr(this.Worknum.Text), "',Unit='", this.pulicss.GetFormatStr(this.Unit.Text), "',Post='", this.pulicss.GetFormatStr(this.Post.Text), "',Sex='", this.pulicss.GetFormatStr(this.Sex.Text), "',Bothday='", this.pulicss.GetFormatStr(this.Bothday.Text), "',Tel='", this.pulicss.GetFormatStr(this.Tel.Text), "',Fax='", this.pulicss.GetFormatStr(this.Fax.Text), "',MoveTel='", this.pulicss.GetFormatStr(this.MoveTel.Text), 
                "',LittleTel='", this.pulicss.GetFormatStr(this.LittleTel.Text), "',Email='", this.pulicss.GetFormatStr(this.Email.Text), "',QQNum='", this.pulicss.GetFormatStr(this.QQNum.Text), "',Msn='", this.pulicss.GetFormatStr(this.Msn.Text), "',ICQ='", this.pulicss.GetFormatStr(this.ICQ.Text), "',Address='", this.pulicss.GetFormatStr(this.Address.Text), "',ZipCode='", this.pulicss.GetFormatStr(this.ZipCode.Text), "',HomeTel='", this.pulicss.GetFormatStr(this.HomeTel.Text), 
                "' where  Username='", this.Session["username"], "'"
             });
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "Update qp_oa_username  Set MoveTel='", this.pulicss.GetFormatStr(this.MoveTel.Text), "',Sex='", this.Sex.SelectedValue, "',Email='", this.pulicss.GetFormatStr(this.Email.Text), "' where  Username='", this.Session["username"], "'" });
            this.List.ExeSql(str2);
            string str3 = string.Concat(new object[] { "Update qp_hr_Yuangong  Set Chusheng='", this.pulicss.GetFormatStr(this.Bothday.Text), "',Youxiang='", this.pulicss.GetFormatStr(this.Email.Text), "',Shouji='", this.pulicss.GetFormatStr(this.MoveTel.Text), "',Xingbie='", this.Sex.SelectedValue.Replace("男", "1").Replace("女", "2"), "' where Username='", this.Session["username"], "'" });
            this.List.ExeSql(str3);
            string str4 = string.Concat(new object[] { "Update qp_oa_CompanyGroup  Set Bothday='", this.pulicss.GetFormatStr(this.Bothday.Text), "',Sex='", this.pulicss.GetFormatStr(this.Sex.SelectedValue), "',Email='", this.pulicss.GetFormatStr(this.Email.Text), "',MoveTel='", this.pulicss.GetFormatStr(this.MoveTel.Text), "' where XtUsername='", this.Session["username"], "'" });
            this.List.ExeSql(str4);
            this.pulicss.InsertLog("修改了个人资料", "个人资料");
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
                string sql = "select * from qp_oa_MyData where Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Realname.Text = list["Realname"].ToString();
                    this.Worknum.Text = list["Worknum"].ToString();
                    this.Sex.SelectedValue = list["Sex"].ToString();
                    this.Bothday.Text = DateTime.Parse(list["Bothday"].ToString()).ToShortDateString().Replace("1900-1-1", "").Replace("00:00:00", "").Replace("1900-01-01", "");
                    this.Tel.Text = list["Tel"].ToString();
                    this.Fax.Text = list["Fax"].ToString();
                    this.MoveTel.Text = list["MoveTel"].ToString();
                    this.LittleTel.Text = list["LittleTel"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.QQNum.Text = list["QQNum"].ToString();
                    this.Msn.Text = list["Msn"].ToString();
                    this.ICQ.Text = list["ICQ"].ToString();
                    this.Address.Text = list["Address"].ToString();
                    this.ZipCode.Text = list["ZipCode"].ToString();
                    this.HomeTel.Text = list["HomeTel"].ToString();
                }
                list.Close();
                string str2 = "select BuMenId,JueseId from qp_oa_username where Username='" + this.Session["username"] + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.Unit.Text = this.pulicss.TypeCode("qp_oa_Bumen", reader2["BuMenId"].ToString());
                    this.Post.Text = this.pulicss.TypeCode("qp_oa_Juese", reader2["JueseId"].ToString());
                }
                reader2.Close();
                this.BindAttribute();
            }
        }
    }
}


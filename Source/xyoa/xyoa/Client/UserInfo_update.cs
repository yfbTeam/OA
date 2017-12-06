namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class UserInfo_update : Page
    {
        protected TextBox Address;
        protected TextBox Bothday;
        protected Button Button1;
        protected Button Button2;
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
        protected HtmlInputFile uploadFile;
        protected Image Xiangpian;
        protected TextBox ZipCode;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str9;
            string str10;
            string sql = "Update qp_oa_MyData  Set Sex='" + this.pulicss.GetFormatStr(this.Sex.SelectedValue) + "',Bothday='" + this.pulicss.GetFormatStr(this.Bothday.Text) + "',Tel='" + this.pulicss.GetFormatStr(this.Tel.Text) + "',Fax='" + this.pulicss.GetFormatStr(this.Fax.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',LittleTel='" + this.pulicss.GetFormatStr(this.LittleTel.Text) + "',Email='" + this.pulicss.GetFormatStr(this.Email.Text) + "',QQNum='" + this.pulicss.GetFormatStr(this.QQNum.Text) + "',Msn='" + this.pulicss.GetFormatStr(this.Msn.Text) + "',ICQ='" + this.pulicss.GetFormatStr(this.ICQ.Text) + "',Address='" + this.pulicss.GetFormatStr(this.Address.Text) + "',ZipCode='" + this.pulicss.GetFormatStr(this.ZipCode.Text) + "',HomeTel='" + this.pulicss.GetFormatStr(this.HomeTel.Text) + "' where  Username='" + base.Request.QueryString["user"].ToString() + "'";
            this.List.ExeSql(sql);
            string str2 = base.Server.MapPath("/SystemManage/User/file/");
            string str3 = string.Empty;
            string str4 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                Random random = new Random();
                string str8 = random.Next(0x2710).ToString();
                str4 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str8;
                this.uploadFile.PostedFile.SaveAs(str2 + str4 + extension);
                str3 = str4 + extension;
                str9 = "Update qp_oa_username  Set pic='/SystemManage/User/file/" + str3 + "',MoveTel='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Sex='" + this.Sex.SelectedValue + "',Email='" + this.pulicss.GetFormatStr(this.Email.Text) + "' where  Username='" + base.Request.QueryString["user"].ToString() + "'";
                this.List.ExeSql(str9);
                str10 = "Update qp_hr_Yuangong  Set Xiangpian='/SystemManage/User/file/" + str3 + "',Chusheng='" + this.pulicss.GetFormatStr(this.Bothday.Text) + "',Youxiang='" + this.pulicss.GetFormatStr(this.Email.Text) + "',Shouji='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Xingbie='" + this.Sex.SelectedValue.Replace("男", "1").Replace("女", "2") + "' where Username='" + base.Request.QueryString["user"].ToString() + "'";
                this.List.ExeSql(str10);
            }
            else
            {
                str9 = "Update qp_oa_username  Set MoveTel='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Sex='" + this.Sex.SelectedValue + "',Email='" + this.pulicss.GetFormatStr(this.Email.Text) + "' where  Username='" + base.Request.QueryString["user"].ToString() + "'";
                this.List.ExeSql(str9);
                str10 = "Update qp_hr_Yuangong  Set Chusheng='" + this.pulicss.GetFormatStr(this.Bothday.Text) + "',Youxiang='" + this.pulicss.GetFormatStr(this.Email.Text) + "',Shouji='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Xingbie='" + this.Sex.SelectedValue.Replace("男", "1").Replace("女", "2") + "' where Username='" + base.Request.QueryString["user"].ToString() + "'";
                this.List.ExeSql(str10);
            }
            string str11 = "Update qp_oa_CompanyGroup  Set Bothday='" + this.pulicss.GetFormatStr(this.Bothday.Text) + "',Sex='" + this.pulicss.GetFormatStr(this.Sex.SelectedValue) + "',Email='" + this.pulicss.GetFormatStr(this.Email.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "'  where XtUsername='" + base.Request.QueryString["user"].ToString() + "'";
            this.List.ExeSql(str11);
            this.pulicss.InsertLog("修改了个人资料", "个人资料");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='UserInfo.aspx?user=" + base.Request.QueryString["user"].ToString() + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("UserInfo.aspx?user=" + base.Request.QueryString["user"].ToString() + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MyData where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Realname.Text = list["Realname"].ToString();
                    this.Sex.SelectedValue = list["Sex"].ToString();
                    this.Bothday.Text = DateTime.Parse(list["Bothday"].ToString()).ToShortDateString().Replace("1900-1-1", "").Replace("1900-01-01", "");
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
                string str2 = "select BuMenId,JueseId,pic from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.Xiangpian.ImageUrl = reader2["pic"].ToString();
                    this.Unit.Text = this.pulicss.TypeCode("qp_oa_Bumen", reader2["BuMenId"].ToString());
                    this.Post.Text = this.pulicss.TypeCode("qp_oa_Juese", reader2["JueseId"].ToString());
                }
                reader2.Close();
                this.BindAttribute();
            }
        }
    }
}


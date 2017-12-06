namespace xyoa.SystemManage.User
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class username_update : Page
    {
        protected TextBox Bothday;
        protected DropDownList BuMenId;
        protected Button Button1;
        protected Button Button2;
        protected TextBox Email;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Iflogin;
        protected DropDownList IfResponUpdate;
        protected TextBox jifen;
        protected DropDownList JueseId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox MoveTel;
        protected TextBox Number;
        protected TextBox paixu;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox Remark;
        protected RadioButtonList Sex;
        protected DropDownList StardType;
        protected HtmlInputFile uploadFile;
        protected Label Username;
        protected Image Xiangpian;
        protected DropDownList Zhiweiid;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str12;
            string str13;
            if (this.IfResponUpdate.SelectedValue == "1")
            {
                string str2 = "select Perstr from qp_oa_Juese where id='" + this.JueseId.SelectedValue + "'";
                SqlDataReader reader = this.List.GetList(str2);
                if (reader.Read())
                {
                    str = reader["Perstr"].ToString();
                }
                reader.Close();
            }
            else
            {
                str = "";
            }
            string str3 = null;
            string sql = "select QxString from qp_oa_Bumen where id='" + this.BuMenId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str3 = list["QxString"].ToString();
            }
            list.Close();
            string str5 = base.Server.MapPath("file/");
            string str6 = string.Empty;
            string str7 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                Random random = new Random();
                string str11 = random.Next(0x2710).ToString();
                str7 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str11;
                this.uploadFile.PostedFile.SaveAs(str5 + str7 + extension);
                str6 = str7 + extension;
                str12 = string.Concat(new object[] { 
                    "Update qp_oa_username  Set pic='/SystemManage/User/file/", str6, "',Bothday='", this.pulicss.GetFormatStr(this.Bothday.Text), "',jifen='", this.pulicss.GetFormatStr(this.jifen.Text), "',paixu='", this.pulicss.GetFormatStr(this.paixu.Text), "',Realname='", this.pulicss.GetFormatStr(this.Realname.Text), "',BuMenId='", this.BuMenId.SelectedValue, "',JueseId='", this.JueseId.SelectedValue, "',IfResponUpdate='", this.IfResponUpdate.SelectedValue, 
                    "',Zhiweiid='", this.Zhiweiid.SelectedValue, "',StardType='", this.StardType.SelectedValue, "',Email='", this.pulicss.GetFormatStr(this.Email.Text), "',MoveTel='", this.pulicss.GetFormatStr(this.MoveTel.Text), "',Iflogin='", this.Iflogin.SelectedValue, "',Sex='", this.Sex.SelectedValue, "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), "',ResponQx='", str, 
                    "',QxString='", str3, "'   where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str12);
                str13 = "Update qp_hr_Yuangong  Set Xiangpian='/SystemManage/User/file/" + str6 + "',Chusheng='" + this.pulicss.GetFormatStr(this.Bothday.Text) + "',Xingming='" + this.pulicss.GetFormatStr(this.Realname.Text) + "',Youxiang='" + this.pulicss.GetFormatStr(this.Email.Text) + "',Shouji='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Xingbie='" + this.Sex.SelectedValue.Replace("男", "1").Replace("女", "2") + "',Bumen='" + this.BuMenId.SelectedValue + "',Zhiwei='" + this.Zhiweiid.SelectedValue + "' where Username='" + this.Username.Text + "'";
                this.List.ExeSql(str13);
            }
            else
            {
                str12 = string.Concat(new object[] { 
                    "Update qp_oa_username  Set Bothday='", this.pulicss.GetFormatStr(this.Bothday.Text), "',jifen='", this.pulicss.GetFormatStr(this.jifen.Text), "',paixu='", this.pulicss.GetFormatStr(this.paixu.Text), "',Realname='", this.pulicss.GetFormatStr(this.Realname.Text), "',BuMenId='", this.BuMenId.SelectedValue, "',JueseId='", this.JueseId.SelectedValue, "',IfResponUpdate='", this.IfResponUpdate.SelectedValue, "',Zhiweiid='", this.Zhiweiid.SelectedValue, 
                    "',StardType='", this.StardType.SelectedValue, "',Email='", this.pulicss.GetFormatStr(this.Email.Text), "',MoveTel='", this.pulicss.GetFormatStr(this.MoveTel.Text), "',Iflogin='", this.Iflogin.SelectedValue, "',Sex='", this.Sex.SelectedValue, "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), "',ResponQx='", str, "',QxString='", str3, 
                    "'   where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str12);
                str13 = "Update qp_hr_Yuangong  Set Chusheng='" + this.pulicss.GetFormatStr(this.Bothday.Text) + "',Xingming='" + this.pulicss.GetFormatStr(this.Realname.Text) + "',Youxiang='" + this.pulicss.GetFormatStr(this.Email.Text) + "',Shouji='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Xingbie='" + this.Sex.SelectedValue.Replace("男", "1").Replace("女", "2") + "',Bumen='" + this.BuMenId.SelectedValue + "',Zhiwei='" + this.Zhiweiid.SelectedValue + "' where Username='" + this.Username.Text + "'";
                this.List.ExeSql(str13);
            }
            string str14 = "Update qp_oa_MyData  Set Bothday='" + this.pulicss.GetFormatStr(this.Bothday.Text) + "',Realname='" + this.pulicss.GetFormatStr(this.Realname.Text) + "',Email='" + this.pulicss.GetFormatStr(this.Email.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',Sex='" + this.Sex.SelectedValue + "' where  Username='" + this.Username.Text + "'";
            this.List.ExeSql(str14);
            string str15 = "Update qp_oa_CompanyGroup  Set Bothday='" + this.pulicss.GetFormatStr(this.Bothday.Text) + "',Name='" + this.pulicss.GetFormatStr(this.Realname.Text) + "',Sex='" + this.pulicss.GetFormatStr(this.Sex.SelectedValue) + "',Email='" + this.pulicss.GetFormatStr(this.Email.Text) + "',MoveTel='" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "',BuMenId='" + this.BuMenId.SelectedValue + "',Zhiweiid='" + this.Zhiweiid.SelectedValue + "'  where XtUsername='" + this.pulicss.GetFormatStr(this.Username.Text) + "'";
            this.List.ExeSql(str15);
            this.pulicss.InsertLog("修改用户[" + this.Realname.Text + "]", "用户管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='username.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("username.aspx");
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
                string str2 = "select id,name  from qp_oa_Juese order by id asc";
                this.list.Bind_DropDownList_nothing(this.JueseId, str2, "id", "name");
                string sql = "select * from qp_oa_username where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Username.Text = list["Username"].ToString();
                    if (list["Username"].ToString() == "admin")
                    {
                        this.Realname.CssClass = "ReadOnlyText";
                        this.Realname.Attributes.Add("readonly", "readonly");
                    }
                    this.Xiangpian.ImageUrl = list["pic"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.BuMenId.SelectedValue = list["BuMenId"].ToString();
                    this.JueseId.SelectedValue = list["JueseId"].ToString();
                    this.IfResponUpdate.SelectedValue = list["IfResponUpdate"].ToString();
                    this.Zhiweiid.SelectedValue = list["Zhiweiid"].ToString();
                    this.StardType.SelectedValue = list["StardType"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.MoveTel.Text = list["MoveTel"].ToString();
                    this.Iflogin.SelectedValue = list["Iflogin"].ToString();
                    this.Sex.SelectedValue = list["Sex"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                    this.paixu.Text = list["paixu"].ToString();
                    this.jifen.Text = list["jifen"].ToString();
                    this.Bothday.Text = list["Bothday"].ToString().Replace("1900-1-1", "").Replace("1900-01-01", "").Replace("00:00:00", "").Replace("0:00:00", "");
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


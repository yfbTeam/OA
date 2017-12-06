namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingApply_sp_fb : Page
    {
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox3;
        protected TextBox Endtime;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG2;
        protected TextBox Introduction;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MettingName;
        protected TextBox Name;
        protected TextBox NbPeopleName;
        protected TextBox NbPeopleUser;
        protected HtmlInputHidden NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Remark;
        protected TextBox Starttime;
        protected HtmlInputFile uploadFile;
        protected TextBox WbPeople;
        protected HtmlInputHidden YjbNodeId;

        public void BindAttribute()
        {
            this.NbPeopleName.Attributes.Add("readonly", "readonly");
            this.Button6.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MettingApply_sp.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                }
                else if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                }
                else
                {
                    Random random = new Random();
                    string str7 = random.Next(0x2710).ToString();
                    str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                    this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string filetype = this.pulicss.Getfiletype(extension);
                    this.pulicss.Insertfile(fileName, "OfficeMenu/Metting/file/" + str2 + "", this.Number.Text, filetype);
                    this.BindFjlbList();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string glNum = random.Next(0x989680).ToString();
            this.pulicss.SpInsertLog("直接发布会议", this.Number.Text, "直接发布会议", this.Session["username"].ToString(), this.Session["realname"].ToString(), "3", glNum, "2", DateTime.Now.ToString(), "1");
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_MettingApply (Number,DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,Name,Introduction,WbPeople,NbPeopleUser,NbPeopleName,MettingId,MettingName,CjUsername,CjRealname,Starttime,Endtime,State,Remark,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','直接发布会议','直接发布会议','3','','", glNum, "','','直接发布会议','0','','", this.pulicss.GetFormatStr(this.Name.Text), "','", this.pulicss.GetFormatStr(this.Introduction.Text), "','", this.pulicss.GetFormatStr(this.WbPeople.Text), "','", this.pulicss.GetFormatStr(this.NbPeopleUser.Text), "','", this.pulicss.GetFormatStr(this.NbPeopleName.Text), "','", this.MettingName.SelectedValue, 
                "','", this.MettingName.SelectedItem.Text, "','','','", this.pulicss.GetFormatStr(this.Starttime.Text), "','", this.Endtime.Text, "','2','", this.pulicss.GetFormatStr(this.Remark.Text), "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToShortDateString(), "')"
             });
            this.List.ExeSql(sql);
            string str3 = null;
            string str4 = null;
            str4 = "" + this.NbPeopleUser.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str4.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str3 = str3 + "'" + strArray[i] + "',";
            }
            str3 = str3 + "'0'";
            string str5 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str3 + ") ";
            SqlDataReader reader = this.List.GetList(str5);
            while (reader.Read())
            {
                if (this.CheckBox1.Checked)
                {
                    this.pulicss.InsertMessage("您有会议需要参加：【" + this.Name.Text + "】，会议时间：" + this.Starttime.Text + "至" + this.Endtime.Text + "", reader["username"].ToString(), reader["realname"].ToString(), "/MyWork/Metting/MyMetting.aspx");
                }
                if (this.CheckBox3.Checked)
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), "您有会议室需要参加：【" + this.Name.Text + "】，会议时间：" + this.Starttime.Text + "至" + this.Endtime.Text + "");
                }
            }
            reader.Close();
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Faqi.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    string sQL = "select id,name  from qp_oa_MettingHouse order by id asc";
                    this.list.Bind_DropDownList_nothing(this.MettingName, sQL, "id", "name");
                    Random random = new Random();
                    string str2 = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str2 + "";
                    this.BindAttribute();
                    this.pulicss.QuanXianVis(this.CheckBox3, ",8,", this.pulicss.GetSms());
                    this.pulicss.QuanXianVis(this.IMG2, ",8,", this.pulicss.GetSms());
                }
                this.BindFjlbList();
            }
        }
    }
}


namespace xyoa.OfficeMenu.WorkPlan
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPlan_add : Page
    {
        protected TextBox Biaoti;
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected CheckBox CheckBox1;
        protected RadioButtonList DqState;
        protected TextBox EndTime;
        protected TextBox ETime;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList Sharing;
        protected TextBox SharingNameKx;
        protected TextBox SharingNameZd;
        protected TextBox SharingUserKx;
        protected TextBox SharingUserZd;
        protected TextBox StartTime;
        protected TextBox STime;
        protected HtmlInputFile uploadFile;
        protected RadioButtonList Youxian;

        public void BindAttribute()
        {
            this.SharingNameZd.Attributes.Add("readonly", "readonly");
            this.SharingNameKx.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_MyPlan (YdUsername,YdRealname,Number,Biaoti,Leixing,Neirong,StartTime,EndTime,Youxian,DqState,Sharing,SharingNameZd,SharingUserZd,SharingNameKx,SharingUserKx,Username,Realname,SetTimes) values ('','','" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.pulicss.GetFormatStr(this.Biaoti.Text) + "','" + this.Leixing.SelectedValue + "','" + this.pulicss.GetFormatStrbjq(this.Neirong.Value) + "','" + this.StartTime.Text + "','" + this.pulicss.GetFormatStr(this.EndTime.Text) + "','" + this.Youxian.SelectedValue + "','" + this.DqState.SelectedValue + "','" + this.Sharing.SelectedValue + "','" + this.pulicss.GetFormatStr(this.SharingNameZd.Text) + "','" + this.pulicss.GetFormatStr(this.SharingUserZd.Text) + "','" + this.SharingNameKx.Text + "','" + this.SharingUserKx.Text + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增我的计划", "我的计划");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyPlan.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyPlan.aspx");
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
                    this.pulicss.Insertfile(fileName, "OfficeMenu/WorkPlan/file/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "我的计划");
                    this.BindFjlbList();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            int num = 0;
            string str = null;
            string sql = string.Concat(new object[] { "select Content,NowTimes from qp_oa_MyRizhi  where ((NowTimes between '", this.STime.Text, "'and  '", this.ETime.Text, "') or (convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('", this.STime.Text, "' as datetime),120)) or (convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('", this.ETime.Text, "' as datetime),120)) ) and username='", this.Session["username"], "' " });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                num++;
                string str3 = str;
                str = str3 + "<br><br>---------------" + DateTime.Parse(list["NowTimes"].ToString()).ToShortDateString() + "---------------<br>" + list["Content"].ToString() + "";
            }
            list.Close();
            this.Neirong.Value = this.Neirong.Value + str;
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
                    Random random = new Random();
                    string str = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                    this.BindAttribute();
                    string sQL = "select id,Leixing  from qp_oa_MyPlanLx order by id asc";
                    this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "Leixing");
                    this.STime.Text = DateTime.Now.ToShortDateString();
                    this.ETime.Text = DateTime.Now.ToShortDateString();
                }
                this.BindFjlbList();
            }
        }
    }
}


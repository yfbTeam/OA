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

    public class MyPlanGx_update : Page
    {
        protected TextBox Biaoti;
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected RadioButtonList DqState;
        protected TextBox EndTime;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox SharingUserKx;
        protected TextBox SharingUserZd;
        protected TextBox StartTime;
        protected HtmlInputFile uploadFile;
        protected RadioButtonList Youxian;

        public void BindAttribute()
        {
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
            string sql = string.Concat(new object[] { 
                "Update qp_oa_MyPlan  Set Biaoti='", this.pulicss.GetFormatStr(this.Biaoti.Text), "',Leixing='", this.Leixing.SelectedValue, "',Neirong='", this.pulicss.GetFormatStrbjq(this.Neirong.Value), "',StartTime='", this.pulicss.GetFormatStr(this.StartTime.Text), "',EndTime='", this.pulicss.GetFormatStr(this.EndTime.Text), "',Youxian='", this.Youxian.SelectedValue, "',DqState='", this.DqState.SelectedValue, "' where id='", int.Parse(base.Request.QueryString["id"]), 
                "' "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改我的计划", "我的计划");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyPlanGx.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyPlanGx.aspx");
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
                    string sQL = "select id,Leixing  from qp_oa_MyPlanLx order by id asc";
                    this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "Leixing");
                    string sql = string.Concat(new object[] { "select * from qp_oa_MyPlan  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and ((CHARINDEX(',", this.Session["username"], ",',','+SharingUserKx+',')   >   0  and Sharing=2)) " });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.Biaoti.Text = list["Biaoti"].ToString();
                        this.Leixing.SelectedValue = list["Leixing"].ToString();
                        this.Neirong.Value = list["Neirong"].ToString();
                        this.StartTime.Text = list["StartTime"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                        this.EndTime.Text = list["EndTime"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                        this.Youxian.SelectedValue = list["Youxian"].ToString();
                        this.DqState.SelectedValue = list["DqState"].ToString();
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location.href='MyPlanGx.aspx'</script>");
                    }
                    list.Close();
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}


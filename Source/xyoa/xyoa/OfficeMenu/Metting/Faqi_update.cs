namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Faqi_update : Page
    {
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected TextBox Endtime;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Introduction;
        protected Label Label1;
        protected TextBox LcZhuangtai;
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
            this.LcZhuangtai.Attributes.Add("readonly", "readonly");
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
            base.Response.Redirect("Faqi.aspx");
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
            string sql = string.Concat(new object[] { 
                "Update qp_oa_MettingApply    Set Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Introduction='", this.pulicss.GetFormatStr(this.Introduction.Text), "',WbPeople='", this.pulicss.GetFormatStr(this.WbPeople.Text), "',NbPeopleUser='", this.pulicss.GetFormatStr(this.NbPeopleUser.Text), "',NbPeopleName='", this.pulicss.GetFormatStr(this.NbPeopleName.Text), "',MettingId='", this.MettingName.SelectedValue, "',MettingName='", this.MettingName.SelectedItem.Text, "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), 
                "',Endtime='", this.pulicss.GetFormatStr(this.Endtime.Text), "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改会议[" + this.Name.Text + "]", "会议申请");
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
                    string sql = "select * from qp_oa_MettingApply   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                        this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                        this.ViewState["FormId"] = list["FormId"].ToString();
                        this.Number.Text = list["Number"].ToString();
                        this.Name.Text = list["Name"].ToString();
                        this.Introduction.Text = list["Introduction"].ToString();
                        this.WbPeople.Text = list["WbPeople"].ToString();
                        this.NbPeopleUser.Text = list["NbPeopleUser"].ToString();
                        this.NbPeopleName.Text = list["NbPeopleName"].ToString();
                        this.MettingName.SelectedValue = list["MettingId"].ToString();
                        this.Starttime.Text = list["Starttime"].ToString();
                        this.Endtime.Text = list["Endtime"].ToString();
                        this.Remark.Text = list["Remark"].ToString();
                        this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                        if ((list["LcZhuangtai"].ToString() == "1") || (list["LcZhuangtai"].ToString() == "4"))
                        {
                            this.Button6.Visible = true;
                            this.Button3.Visible = true;
                            this.Button4.Visible = true;
                            this.Button12.Visible = true;
                        }
                        else
                        {
                            this.Label1.Text = "当前状态不允许修改";
                            this.Button6.Visible = false;
                            this.Button3.Visible = false;
                            this.Button4.Visible = false;
                            this.Button12.Visible = false;
                        }
                    }
                    list.Close();
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}


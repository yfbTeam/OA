namespace xyoa.OfficeMenu.Renwu
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RenwuFp_update : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected FCKeditor Content;
        protected TextBox Endtime;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox Starttime;
        protected TextBox titles;
        protected HtmlInputFile uploadFile;
        protected TextBox Username;
        protected GridView XieBanUser;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.ZbRealname.Attributes.Add("readonly", "readonly");
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
                "Update qp_oa_Renwu  Set  titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "',Endtime='", this.pulicss.GetFormatStr(this.Endtime.Text), "',ZbUsername='", this.pulicss.GetFormatStr(this.ZbUsername.Text), "',ZbRealname='", this.pulicss.GetFormatStr(this.ZbRealname.Text), "',Leixing='", this.Leixing.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), 
                "'  and username='", this.Session["username"], "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改任务", "任务分配");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='RenwuFp.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("RenwuFp.aspx");
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
                    this.pulicss.Insertfile(fileName, "OfficeMenu/Renwu/file/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "任务分配");
                    this.BindFjlbList();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (this.Username.Text == "")
            {
                base.Response.Write("<script language=javascript>alert('添加协办人不能为空！');</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select id from qp_oa_RenwuXb where Keyid='", int.Parse(base.Request.QueryString["id"]), "' and Username='", this.Username.Text, "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    base.Response.Write("<script language=javascript>alert('任务中已经存在此协办人人！');</script>");
                }
                else
                {
                    list.Close();
                    string str2 = string.Concat(new object[] { "insert into qp_oa_RenwuXb (Keyid,Username,Realname,Zhuangtai,Neirong,Baifenbi) values ('", int.Parse(base.Request.QueryString["id"]), "','", this.Username.Text, "','", this.Realname.Text, "','1','','0')" });
                    this.List.ExeSql(str2);
                    string str3 = string.Concat(new object[] { "Update qp_oa_Renwu  Set  JbUsername=JbUsername+'", this.Username.Text, ",',JbRealname=JbRealname+'", this.Realname.Text, ",'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                    this.List.ExeSql(str3);
                    this.DataBindToGridviewXb();
                }
            }
        }

        public void DataBindToGridviewXb()
        {
            this.XieBanUser.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select * from qp_oa_RenwuXb where Keyid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.XieBanUser.DataSource = this.List.GetGrid_Pages_not(sql);
            this.XieBanUser.DataBind();
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
                    string sQL = "select id,name  from qp_oa_RenwuLx order by id asc";
                    this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "name");
                    string sql = string.Concat(new object[] { "select * from qp_oa_Renwu  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "' " });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.titles.Text = list["titles"].ToString();
                        this.Starttime.Text = list["Starttime"].ToString();
                        this.Endtime.Text = list["Endtime"].ToString();
                        this.ZbUsername.Text = list["ZbUsername"].ToString();
                        this.ZbRealname.Text = list["ZbRealname"].ToString();
                        this.Leixing.SelectedValue = list["Leixing"].ToString();
                        this.Content.Value = list["Content"].ToString();
                    }
                    list.Close();
                    this.BindAttribute();
                }
                this.BindFjlbList();
                this.DataBindToGridviewXb();
            }
        }

        protected void XieBanUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "select Username,Realname from qp_oa_RenwuXb where id='" + num + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = "  Delete from qp_oa_RenwuXb where ID='" + num + "'";
                    this.List.ExeSql(str2);
                    string str3 = string.Concat(new object[] { "Update qp_oa_Renwu  Set  JbUsername=replace(JbUsername,'", list["username"], ",',''),JbRealname=replace(JbRealname,'", list["Realname"], ",','')  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                    this.List.ExeSql(str3);
                }
                list.Close();
                this.DataBindToGridviewXb();
            }
        }

        protected void XieBanUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                button.Attributes.Add("onclick", "javascript:return confirm('确认删除此协办人[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("XiuGai");
                button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('RenwuFp_update_xb.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "','window','dialogWidth:680px;DialogHeight=380px;status:no;help=no;scroll=no');window.location='#'");
            }
        }
    }
}


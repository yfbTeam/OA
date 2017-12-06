namespace xyoa.PublicWork.BumenNewsMg
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

    public class BumenNewsMg_update : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected FCKeditor Content;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected TextBox FqBumen;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected TextBox titles;
        protected HtmlInputFile uploadFile;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.pulicss.QuanXianBack("jjjj3bc", this.Session["perstr"].ToString());
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.FqBumen.Attributes.Add("readonly", "readonly");
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
            string str2;
            SqlDataReader list;
            string str3;
            string sql = "  Delete from qp_oa_BumenNewsMgYd  where Number='" + this.Number.Text + "'";
            this.List.ExeSql(sql);
            if (this.States.SelectedValue == "1")
            {
                str2 = "select A.id,A.BumenId,A.Username, A.Realname,A.Iflogin, B.[Name] as BuMenName, C.[Name] as JueseName , D.[Name] as ZhiweiName from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0'";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    str3 = string.Concat(new object[] { "insert into qp_oa_BumenNewsMgYd  (Number,Username,Realname,YdTime,Yuedu,BumenId) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','", list["Username"], "','", list["Realname"], "','','0','", list["BumenId"], "')" });
                    this.List.ExeSql(str3);
                }
                list.Close();
            }
            if (this.States.SelectedValue == "2")
            {
                str2 = "select A.id,A.BumenId,A.Username, A.Realname,A.Iflogin, B.[Name] as BuMenName, C.[Name] as JueseName , D.[Name] as ZhiweiName from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0' and BumenId in (" + this.ZdBumenId.Text + "0)";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    str3 = string.Concat(new object[] { "insert into qp_oa_BumenNewsMgYd  (Number,Username,Realname,YdTime,Yuedu,BumenId) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','", list["Username"], "','", list["Realname"], "','','0','", list["BumenId"], "')" });
                    this.List.ExeSql(str3);
                }
                list.Close();
            }
            if (this.States.SelectedValue == "3")
            {
                str2 = "select A.id,A.BumenId,A.Username, A.Realname,A.Iflogin, B.[Name] as BuMenName, C.[Name] as JueseName , D.[Name] as ZhiweiName from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0' and CHARINDEX(','+Username+',','," + this.ZdUsername.Text + ",') > 0";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    str3 = string.Concat(new object[] { "insert into qp_oa_BumenNewsMgYd  (Number,Username,Realname,YdTime,Yuedu,BumenId) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','", list["Username"], "','", list["Realname"], "','','0','", list["BumenId"], "')" });
                    this.List.ExeSql(str3);
                }
                list.Close();
            }
            string str4 = string.Concat(new object[] { 
                "Update qp_oa_BumenNewsMg  Set  titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, "',ZdRealname='", this.ZdRealname.Text, "',Settime='", DateTime.Now.ToString(), 
                "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
             });
            this.List.ExeSql(str4);
            this.pulicss.InsertLog("修改通知公告", "通知公告");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='BumenNewsMg.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("BumenNewsMg.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("bumen/");
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
                    this.pulicss.Insertfile(fileName, "PublicWork/BumenNewsMg/bumen/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "通知公告");
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
                    string sql = "select * from qp_oa_BumenNewsMg  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.FqBumen.Text = list["FqBumen"].ToString();
                        this.titles.Text = list["titles"].ToString();
                        this.Content.Value = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                        this.States.SelectedValue = list["States"].ToString();
                        this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                        this.ZdBumen.Text = list["ZdBumen"].ToString();
                        this.ZdUsername.Text = list["ZdUsername"].ToString();
                        this.ZdRealname.Text = list["ZdRealname"].ToString();
                    }
                    list.Close();
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}


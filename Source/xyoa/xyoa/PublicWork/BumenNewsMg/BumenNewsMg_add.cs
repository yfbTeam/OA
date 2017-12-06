namespace xyoa.PublicWork.BumenNewsMg
{
    using FredCK.FCKeditorV2;
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenNewsMg_add : Page
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
        private divform showform = new divform();
        protected DropDownList States;
        protected TextBox titles;
        protected HtmlInputFile uploadFile;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.pulicss.QuanXianBack("jjjj3ba", this.Session["perstr"].ToString());
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
            string str;
            SqlDataReader list;
            string str2;
            if (this.States.SelectedValue == "1")
            {
                str = "select A.id,A.BumenId,A.Username, A.Realname,A.Iflogin, B.[Name] as BuMenName, C.[Name] as JueseName , D.[Name] as ZhiweiName from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0'";
                list = this.List.GetList(str);
                while (list.Read())
                {
                    str2 = string.Concat(new object[] { "insert into qp_oa_BumenNewsMgYd  (Number,Username,Realname,YdTime,Yuedu,BumenId) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','", list["Username"], "','", list["Realname"], "','','0','", list["BumenId"], "')" });
                    this.List.ExeSql(str2);
                }
                list.Close();
            }
            if (this.States.SelectedValue == "2")
            {
                str = "select A.id,A.BumenId,A.Username, A.Realname,A.Iflogin, B.[Name] as BuMenName, C.[Name] as JueseName , D.[Name] as ZhiweiName from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0' and BumenId in (" + this.ZdBumenId.Text + "0)";
                list = this.List.GetList(str);
                while (list.Read())
                {
                    str2 = string.Concat(new object[] { "insert into qp_oa_BumenNewsMgYd  (Number,Username,Realname,YdTime,Yuedu,BumenId) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','", list["Username"], "','", list["Realname"], "','','0','", list["BumenId"], "')" });
                    this.List.ExeSql(str2);
                }
                list.Close();
            }
            if (this.States.SelectedValue == "3")
            {
                str = "select A.id,A.BumenId,A.Username, A.Realname,A.Iflogin, B.[Name] as BuMenName, C.[Name] as JueseName , D.[Name] as ZhiweiName from [qp_oa_username] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] inner join [qp_oa_Juese] as [C] on [A].[JueseId] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiweiid] = [D].[Id] where 1=1  and  ifdel='0' and CHARINDEX(','+Username+',','," + this.ZdUsername.Text + ",') > 0";
                list = this.List.GetList(str);
                while (list.Read())
                {
                    str2 = string.Concat(new object[] { "insert into qp_oa_BumenNewsMgYd  (Number,Username,Realname,YdTime,Yuedu,BumenId) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','", list["Username"], "','", list["Realname"], "','','0','", list["BumenId"], "')" });
                    this.List.ExeSql(str2);
                }
                list.Close();
            }
            string sql = "insert into qp_oa_BumenNewsMg  (Number,titles,Content,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,YdUsername,YdRealname,Settime,Username,Realname,ScUsername,FqBumen) values ('" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.pulicss.GetFormatStr(this.titles.Text) + "','" + this.pulicss.GetFormatStrbjq(this.Content.Value) + "','" + this.States.SelectedValue + "','" + this.ZdBumenId.Text + "','" + this.ZdBumen.Text + "','" + this.ZdUsername.Text + "','" + this.ZdRealname.Text + "','','','" + DateTime.Now.ToString() + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','','" + this.FqBumen.Text + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增通知公告", "通知公告");
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
                    Random random = new Random();
                    string str = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                    this.BindAttribute();
                    string sql = "select name from qp_oa_Bumen where id='" + this.Session["BuMenId"] + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.FqBumen.Text = list["name"].ToString();
                    }
                    list.Close();
                }
                this.BindFjlbList();
            }
        }
    }
}


﻿namespace xyoa.HumanResources.PeiXun.Peixun
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Peixun_update : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected FCKeditor Content;
        protected TextBox Endtime;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leibie;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox PUsername;
        protected TextBox RealnameCj;
        protected TextBox Starttime;
        protected HtmlInputFile uploadFile;
        protected TextBox UsernameCj;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.RealnameCj.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
            this.Button2.Attributes["onclick"] = "javascript:return openzl();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_hr_PeixunFile where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "  Delete from qp_hr_PeixunXinde  where Pxid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { 
                "Update qp_hr_Peixun  Set Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',UsernameCj='", this.pulicss.GetFormatStr(this.UsernameCj.Text), "',RealnameCj='", this.pulicss.GetFormatStr(this.RealnameCj.Text), "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "',Endtime='", this.pulicss.GetFormatStr(this.Endtime.Text), "',Leibie='", this.Leibie.SelectedValue, "',Content='", this.pulicss.GetFormatStrbjq(this.Content.Value), "' where id='", int.Parse(base.Request.QueryString["id"]), 
                "' and username='", this.Session["username"], "'"
             });
            this.List.ExeSql(str2);
            string str3 = null;
            string str4 = null;
            str4 = "" + this.UsernameCj.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str4.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str3 = str3 + "'" + strArray[i] + "',";
            }
            str3 = str3 + "'0'";
            string str5 = "select username,realname from qp_oa_Username where  username in (" + str3 + ")";
            SqlDataReader reader = this.List.GetList(str5);
            while (reader.Read())
            {
                string str6 = "insert into qp_hr_PeixunXinde  (Pxid,Username,Realname,Tihui,NowTimes) values ('" + base.Request.QueryString["id"] + "','" + reader["username"].ToString() + "','" + reader["realname"].ToString() + "','','')";
                this.List.ExeSql(str6);
                this.pulicss.InsertMessage("您有培训计划需要参加，培训主题：" + this.Zhuti.Text + "", reader["username"].ToString(), reader["realname"].ToString(), "/HumanResources/PeiXun/MyPage/Peixun.aspx");
            }
            reader.Close();
            this.pulicss.InsertLog("修改培训管理", "培训管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Peixun.aspx'</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("../PeixunZl/File/");
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
                    string sql = "insert into qp_hr_PeixunFile (Name,NewName,KeyField) values ('" + fileName + "','/HumanResources/PeiXun/PeixunZl/File/" + str2 + "','" + this.Number.Text + "')";
                    this.List.ExeSql(sql);
                    this.BindFjlbList();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Peixun.aspx");
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
                    this.BindAttribute();
                    string sQL = "select id,Mingcheng from qp_hr_PeixunLb order by id asc";
                    this.list.Bind_DropDownList_kong(this.Leibie, sQL, "id", "Mingcheng");
                    string sql = string.Concat(new object[] { "select * from qp_hr_Peixun where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Number.Text = list["Number"].ToString();
                        this.Zhuti.Text = list["Zhuti"].ToString();
                        this.UsernameCj.Text = list["UsernameCj"].ToString();
                        this.RealnameCj.Text = list["RealnameCj"].ToString();
                        this.Starttime.Text = list["Starttime"].ToString();
                        this.Endtime.Text = list["Endtime"].ToString();
                        this.Leibie.SelectedValue = list["Leibie"].ToString();
                        this.Content.Value = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location = 'KaoShi.aspx'</script>");
                        return;
                    }
                    list.Close();
                }
                this.BindFjlbList();
            }
        }
    }
}


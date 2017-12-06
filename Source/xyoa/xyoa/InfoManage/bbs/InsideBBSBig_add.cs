﻿namespace xyoa.InfoManage.bbs
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class InsideBBSBig_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox BzRealname;
        protected TextBox BzUsername;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Miaosu;
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected HtmlInputFile uploadFile;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;
        protected RadioButtonList Zhuangtai;

        public void BindAttribute()
        {
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.BzRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str8;
            string str = base.Server.MapPath("tupian/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str8 = "insert into qp_oa_InsideBBSBig (Name,Miaosu,Tupian,BzUsername,BzRealname,Zhuangtai,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,Paixun) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.pulicss.GetFormatStr(this.Miaosu.Text) + "','" + str2 + "','" + this.pulicss.GetFormatStr(this.BzUsername.Text) + "','" + this.pulicss.GetFormatStr(this.BzRealname.Text) + "','" + this.Zhuangtai.SelectedValue + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + this.pulicss.GetFormatStr(this.Paixun.Text) + "')";
                this.List.ExeSql(str8);
            }
            else
            {
                str8 = "insert into qp_oa_InsideBBSBig (Name,Miaosu,Tupian,BzUsername,BzRealname,Zhuangtai,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,Paixun) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.pulicss.GetFormatStr(this.Miaosu.Text) + "','BanKuai.gif','" + this.pulicss.GetFormatStr(this.BzUsername.Text) + "','" + this.pulicss.GetFormatStr(this.BzRealname.Text) + "','" + this.Zhuangtai.SelectedValue + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + this.pulicss.GetFormatStr(this.Paixun.Text) + "')";
                this.List.ExeSql(str8);
            }
            this.pulicss.InsertLog("新增版块管理", "版块管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='InsideBBSBig.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBSBig.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
            }
        }
    }
}

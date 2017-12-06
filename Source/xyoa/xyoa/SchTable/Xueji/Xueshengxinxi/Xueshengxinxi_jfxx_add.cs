﻿namespace xyoa.SchTable.Xueji.Xueshengxinxi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueshengxinxi_jfxx_add : Page
    {
        protected DropDownList Banji;
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Shijian;
        protected DropDownList XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;
        protected TextBox Yuanyin;

        protected void Banji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select C.id,C.Xingming  from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]).Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.Banji.SelectedValue + "' order by A.id asc";
            this.list.Bind_DropDownList_nothing(this.XsId, sQL, "id", "Xingming");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_sch_Stu_jfxx   (XsId,Xueqi,Xueduan,Shijian,Yuanyin) values ('" + this.XsId.SelectedValue + "','" + this.Xueqi.SelectedValue + "','" + this.Xueduan.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Shijian.Text) + "','" + this.pulicss.GetFormatStr(this.Yuanyin.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增家访信息[" + this.XsId.SelectedItem.Text + "]", "家访信息");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_jfxx.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_jfxx.aspx?id=" + this.Banji.SelectedValue + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string str4;
                string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                this.Xueqi.SelectedValue = this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]);
                this.Xueduan.SelectedValue = this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]);
                string str2 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='", this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]), "' and ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
                this.list.Bind_DropDownList_nothing(this.Banji, str2, "id", "Mingcheng");
                if (base.Request.QueryString["XsId"] != null)
                {
                    string sql = "select * from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]) + "] where  XsId='" + this.pulicss.GetFormatStr(base.Request.QueryString["XsId"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Banji.SelectedValue = list["BanJi"].ToString();
                        str4 = "select C.id,C.Xingming  from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]).Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.Banji.SelectedValue + "' order by A.id asc";
                        this.list.Bind_DropDownList_nothing(this.XsId, str4, "id", "Xingming");
                        this.XsId.SelectedValue = list["XsId"].ToString();
                    }
                    list.Close();
                    this.Banji.Enabled = false;
                    this.XsId.Enabled = false;
                }
                else
                {
                    if ((base.Request.QueryString["Banji"] != null) && (base.Request.QueryString["Banji"].ToString() != "all"))
                    {
                        this.Banji.SelectedValue = base.Request.QueryString["Banji"].ToString();
                    }
                    str4 = "select C.id,C.Xingming  from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]).Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.Banji.SelectedValue + "' order by A.id asc";
                    this.list.Bind_DropDownList_nothing(this.XsId, str4, "id", "Xingming");
                }
            }
        }
    }
}


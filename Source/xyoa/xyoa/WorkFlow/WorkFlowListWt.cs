﻿namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListWt : Page
    {
        protected Button Button1;
        protected CheckBox C1;
        protected CheckBox C2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        private Db List = new Db();
        protected Label Name;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected TextBox Wtrealname;
        protected TextBox Wtusername;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C2, ",14,", this.pulicss.GetSms());
            this.Wtrealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.Wtusername.Text == ("" + this.Session["username"] + ""))
            {
                base.Response.Write("<script language=javascript>alert('委托失败！不能委托给自己！');</script>");
            }
            else
            {
                string sql = "select Number,UpNodeNum,UpNodeName,FormName,Name,GlNum,JbObjectId,JbObjectName from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = string.Concat(new object[] { "select id,IfZb,LcNum,GlNum from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and GlNum='", list["GlNum"], "'" });
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        string str3;
                        if (reader2["IfZb"].ToString() == "主办")
                        {
                            str3 = "Update qp_oa_AddWorkFlow  Set ZbObjectId='" + this.Wtusername.Text + "',ZbObjectName='" + this.Wtrealname.Text + "'  where id='" + base.Request.QueryString["id"] + "'";
                            this.List.ExeSql(str3);
                        }
                        else
                        {
                            string str4 = "" + list["JbObjectId"].ToString().Replace("" + this.Session["username"].ToString() + ",", "" + this.Wtusername.Text + ",") + "";
                            string str5 = "" + list["JbObjectName"].ToString().Replace("" + this.Session["realname"].ToString() + ",", "" + this.Wtrealname.Text + ",") + "";
                            str3 = "Update qp_oa_AddWorkFlow  Set JbObjectId='" + str4 + "',JbObjectName='" + str5 + "'  where id='" + base.Request.QueryString["id"] + "'";
                            this.List.ExeSql(str3);
                        }
                        string str6 = "Update qp_oa_AddWorkFlowPicRy  Set States='已委托',EndTime='" + DateTime.Now.ToString() + "',WtUsername='" + this.Wtusername.Text + "',WtRealname='" + this.Wtrealname.Text + "'  where id='" + reader2["id"].ToString() + "'";
                        this.List.ExeSql(str6);
                        string str7 = string.Concat(new object[] { 
                            "insert into qp_oa_AddWorkFlowPicRy (XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb,GlNum) values ('", list["UpNodeNum"], "','", reader2["LcNum"], "','", list["Number"], "','", this.Wtusername.Text, "','", this.Wtrealname.Text, "','", DateTime.Now.ToString(), "','','未接收','", reader2["IfZb"].ToString(), "','", reader2["GlNum"].ToString(), 
                            "')"
                         });
                        this.List.ExeSql(str7);
                        this.showform.AddWorkFlowLog("110", list["Number"].ToString(), list["FormName"].ToString(), list["UpNodeName"].ToString(), "委托工作［" + list["Name"].ToString() + "］予" + this.Wtrealname.Text + "", reader2["IfZb"].ToString());
                    }
                    reader2.Close();
                }
                list.Close();
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage(this.txtSmsContent.Text, this.Wtusername.Text, this.Wtrealname.Text, "/WorkFlow/WorkFlowList.aspx");
                }
                if (this.C2.Checked)
                {
                    string str8 = "select username,realname,MoveTel from qp_oa_Username where  username='" + this.Wtusername.Text + "' ";
                    SqlDataReader reader3 = this.List.GetList(str8);
                    if (reader3.Read())
                    {
                        this.pulicss.InsertSms(reader3["MoveTel"].ToString(), this.txtSmsContent.Text);
                    }
                    reader3.Close();
                }
                this.pulicss.InsertLog("设置工作委托", "待办工作");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkFlowList_ywt.aspx'</script>");
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
                string sql = "select * from qp_oa_MyWeituo where  Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Wtusername.Text = list["Wtusername"].ToString();
                    this.Wtrealname.Text = list["Wtrealname"].ToString();
                }
                list.Close();
                string str2 = "select Name from qp_oa_AddWorkFlow where  id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.Name.Text = reader2["Name"].ToString();
                    this.txtSmsContent.Text = string.Concat(new object[] { "您有工作委托需要办理，工作名称：", reader2["Name"].ToString(), "，委托人：", this.Session["realname"], "" });
                }
                reader2.Close();
                this.BindAttribute();
            }
        }
    }
}


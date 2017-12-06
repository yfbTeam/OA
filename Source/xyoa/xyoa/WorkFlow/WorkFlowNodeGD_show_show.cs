namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowNodeGD_show_show : Page
    {
        protected Button Button1;
        protected HtmlInputButton Button10;
        protected HtmlInputButton Button14;
        protected HtmlInputButton Button16;
        protected Button Button2;
        protected HtmlInputButton Button3;
        protected TextBox ContractContent;
        protected HtmlForm form1;
        protected Label fujian;
        protected TextBox GqUpNodeNumKey;
        protected HtmlHead Head1;
        protected Label JinJiChengDu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox TextBox1;
        protected TextBox whname;
        protected Label YiJian;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=HtmlFile.html");
            base.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            base.Response.ContentType = "application/html";
            base.Response.Write("" + this.ContractContent.Text + "" + this.YiJian.Text + "" + this.Liucheng.Text + "");
            base.Response.End();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_AddWorkFlowGd  Set Name='" + this.whname.Text + "', FileContent='" + this.pulicss.GetFormatStrbjq(this.ContractContent.Text) + "'  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('保存成功！');window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.pulicss.QuanXianBack("mmmm7", this.Session["perstr"].ToString());
                if (!this.Page.IsPostBack)
                {
                    object text;
                    this.pulicss.QuanXianVis(this.Button3, "mmmm7c", this.Session["perstr"].ToString());
                    string sql = "select * from qp_oa_AddWorkFlowGd where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.JinJiChengDu.Text = this.pulicss.SystemCode("10", list["JinJiChengDu"].ToString());
                        this.ViewState["FlowNumber"] = list["FlowNumber"].ToString();
                        this.whname.Text = list["Name"].ToString();
                        this.ViewState["ShuXing"] = list["ShuXing"].ToString();
                        this.ViewState["lshid"] = int.Parse(list["Sequence"].ToString());
                        this.Number.Text = list["Number"].ToString();
                        this.ViewState["Numbers"] = list["Number"].ToString();
                        this.ViewState["FormName"] = list["FormName"].ToString();
                        this.ViewState["FormNumber"] = list["FormNumber"].ToString();
                        this.ContractContent.Text = this.showform.FormatKjStrZh(list["FileContent"].ToString());
                        this.TextBox1.Text = this.showform.FormatKjStrZh(list["FileContent"].ToString());
                        string str2 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + this.ViewState["FormNumber"] + "'";
                        SqlDataReader reader2 = this.List.GetList(str2);
                        while (reader2.Read())
                        {
                            StateBag bag = ViewState;
                            text = bag["url"];
                            (bag = this.ViewState)["url"] = string.Concat(new object[] { text, "try{window.L", reader2["Number"], ".location.href='AddWorkFlow_spyj.aspx?Number='+num+'&Buzhou=", reader2["sqlstr"], "&key=1';}catch(err){}" });
                        }
                        reader2.Close();
                    }
                    list.Close();
                    this.pulicss.GetFile(this.Number.Text, this.fujian);
                    this.Button2.Attributes["onclick"] = "javascript:return showwait();";
                    string str3 = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + this.Number.Text + "'  order by id asc";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    this.Liucheng.Text = null;
                    int num = 1;
                    this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" width=\"100%\" class=\"nextpage\">";
                    while (reader3.Read())
                    {
                        string str4 = null;
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\">序号", reader3["XuHao"], "：", reader3["Jiedian"], "</td>" });
                        this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"60%\">";
                        str4 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader3["LcNum"].ToString() + "'  order by id asc";
                        SqlDataReader reader4 = this.List.GetList(str4);
                        while (reader4.Read())
                        {
                            TimeSpan span;
                            if (reader4["States"].ToString() == "未接收")
                            {
                                if (((((reader4["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader4["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader4["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader4["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader4["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader4["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                {
                                    span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { text, "&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>" });
                                }
                                else
                                {
                                    span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { text, "&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>" });
                                }
                            }
                            else if (reader4["States"].ToString() == "办理中")
                            {
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { text, "&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>" });
                            }
                            else if (reader4["States"].ToString() == "已委托")
                            {
                                if (((((reader4["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader4["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader4["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader4["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader4["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader4["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                {
                                    span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;→&nbsp;", reader4["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", 
                                        reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                                     });
                                }
                                else
                                {
                                    span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;→&nbsp;", reader4["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", 
                                        reader4["EndTime"], "<br>"
                                     });
                                }
                            }
                            else if (((((reader4["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader4["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader4["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader4["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader4["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader4["EndTime"].ToString() == "1900/1/1 00:00:00"))
                            {
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { text, "&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：)</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>" });
                            }
                            else
                            {
                                span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { text, "&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>" });
                            }
                        }
                        this.Liucheng.Text = this.Liucheng.Text + "</td>";
                        reader4.Close();
                        this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                        num++;
                    }
                    reader3.Close();
                    this.Liucheng.Text = this.Liucheng.Text + "</table>";
                    string str6 = "select  * from qp_oa_AddWorkFlowMessage where Number='" + this.Number.Text + "'  order by id asc";
                    SqlDataReader reader5 = this.List.GetList(str6);
                    this.YiJian.Text = null;
                    this.YiJian.Text = this.YiJian.Text + "<table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" width=\"100%\" class=\"nextpage\">";
                    while (reader5.Read())
                    {
                        text = this.YiJian.Text;
                        this.YiJian.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\"> <table border=\"0\" cellpadding=\"4\" cellspacing=\"0\"><tr> <td style=\"width: 100%\"><b>步骤名称：</b>", reader5["Buzhou"], "<b>办理人：</b>", reader5["Realname"], "(", reader5["ZbOrJb"], ")<b>时间：</b>", reader5["SetTime"], "</td> </tr> <tr> <td style=\"width: 100%\">", reader5["Content"], "<br> <br><a href=\"/AddWorkFlow_add_down.aspx?number=", reader5["NewName"], "\"target=\"_blank\">", reader5["OldName"], " </a></td> </tr> </table></td>" });
                        this.YiJian.Text = this.YiJian.Text + "</tr>";
                    }
                    reader5.Close();
                    this.YiJian.Text = this.YiJian.Text + "</table>";
                    string str7 = "select * from qp_oa_FormFile where  KeyFile='" + this.ViewState["FormNumber"] + "' and Type!='[印章域]'";
                    SqlDataReader reader6 = this.List.GetList(str7);
                    while (reader6.Read())
                    {
                        this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader6["Number"].ToString() + "", "name=" + reader6["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader6["Number"].ToString() + "\"", "name=" + reader6["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                        this.TextBox1.Text = this.ContractContent.Text;
                    }
                    reader6.Close();
                }
            }
        }
    }
}


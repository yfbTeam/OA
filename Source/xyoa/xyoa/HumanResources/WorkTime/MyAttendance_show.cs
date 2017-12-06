namespace xyoa.HumanResources.WorkTime
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAttendance_show : Page
    {
        protected Label Beizhu;
        protected HtmlInputButton Button1;
        protected Button Button3;
        protected Button Button4;
        protected Button Button5;
        protected RadioButtonList CaoZuo;
        protected CheckBox CheckBox1;
        protected Label DiffTime;
        protected Label DqNodeName1;
        protected Label EndTime;
        protected HtmlForm form1;
        protected RadioButtonList FormName;
        protected TextBox GlNum;
        protected HtmlHead Head1;
        protected TextBox JbZhuangjiao;
        protected Label Label1;
        protected Label Label2;
        protected Label LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected HtmlInputHidden NodeName;
        protected DropDownList normalcontent;
        protected Label NowTimes;
        protected TextBox Number;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label StartTime;
        protected Label Subject;
        protected TextBox TDiffTime;
        protected TextBox Username;
        protected TextBox Yijian;
        protected HtmlInputHidden YjbNodeId;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;

        public void BindLb(string str)
        {
            string sql = "select XrGuize,ZbUsername,ZbRealname,XiugaiZb,NodeSite from qp_Pro_WorkFlowNode where id='" + str + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["NodeSite"].ToString() == "1")
                {
                    this.ZbUsername.Text = "" + this.Username.Text + ",";
                    this.ZbRealname.Text = "" + this.Realname.Text + ",";
                    this.Button4.Visible = false;
                }
                else
                {
                    if (list["XrGuize"].ToString() == "1")
                    {
                        this.ZbUsername.Text = "";
                        this.ZbRealname.Text = "";
                    }
                    else if (list["XrGuize"].ToString() == "2")
                    {
                        this.ZbUsername.Text = "" + this.Username.Text + ",";
                        this.ZbRealname.Text = "" + this.Realname.Text + ",";
                    }
                    else if (list["XrGuize"].ToString() == "7")
                    {
                        this.ZbUsername.Text = "" + this.Session["Username"].ToString() + ",";
                        this.ZbRealname.Text = "" + this.Session["Realname"].ToString() + ",";
                    }
                    else
                    {
                        string str3;
                        SqlDataReader reader2;
                        if (list["XrGuize"].ToString() == "8")
                        {
                            str3 = "select Username,Realname from qp_oa_username where JueseId in (" + list["ZbUsername"].ToString() + "0)";
                            reader2 = this.List.GetList(str3);
                            while (reader2.Read())
                            {
                                this.ZbUsername.Text = this.ZbUsername.Text + "" + reader2["Username"].ToString() + ",";
                                this.ZbRealname.Text = this.ZbRealname.Text + "" + reader2["Realname"].ToString() + ",";
                            }
                            reader2.Close();
                        }
                        else if (list["XrGuize"].ToString() == "10")
                        {
                            str3 = "select Username,Realname from qp_oa_username where Zhiweiid in (" + list["ZbUsername"].ToString() + "0)";
                            reader2 = this.List.GetList(str3);
                            while (reader2.Read())
                            {
                                this.ZbUsername.Text = this.ZbUsername.Text + "" + reader2["Username"].ToString() + ",";
                                this.ZbRealname.Text = this.ZbRealname.Text + "" + reader2["Realname"].ToString() + ",";
                            }
                            reader2.Close();
                        }
                        else
                        {
                            string str4;
                            SqlDataReader reader3;
                            if (list["XrGuize"].ToString() == "3")
                            {
                                str4 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + this.Session["BuMenId"].ToString() + "'";
                                reader3 = this.List.GetList(str4);
                                if (reader3.Read())
                                {
                                    if (reader3["BmUsername"].ToString() != "")
                                    {
                                        this.ZbUsername.Text = "" + reader3["BmUsername"].ToString() + ",";
                                        this.ZbRealname.Text = "" + reader3["BmRealname"].ToString() + ",";
                                    }
                                    else
                                    {
                                        this.ZbUsername.Text = "";
                                        this.ZbRealname.Text = "";
                                    }
                                }
                                reader3.Close();
                            }
                            else if (list["XrGuize"].ToString() == "4")
                            {
                                str4 = "select ParentNodesID,BmUsername,BmRealname from qp_oa_Bumen where  id='" + this.Session["BuMenId"].ToString() + "'";
                                reader3 = this.List.GetList(str4);
                                if (reader3.Read())
                                {
                                    if (reader3["ParentNodesID"].ToString() != "0")
                                    {
                                        string str5 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + reader3["ParentNodesID"].ToString() + "'";
                                        SqlDataReader reader4 = this.List.GetList(str5);
                                        if (reader4.Read())
                                        {
                                            if (reader4["BmUsername"].ToString() != "")
                                            {
                                                this.ZbUsername.Text = "" + reader4["BmUsername"].ToString() + ",";
                                                this.ZbRealname.Text = "" + reader4["BmRealname"].ToString() + ",";
                                            }
                                            else
                                            {
                                                this.ZbUsername.Text = "";
                                                this.ZbRealname.Text = "";
                                            }
                                        }
                                        reader4.Close();
                                    }
                                    else if (reader3["BmUsername"].ToString() != "")
                                    {
                                        this.ZbUsername.Text = "" + reader3["BmUsername"].ToString() + ",";
                                        this.ZbRealname.Text = "" + reader3["BmRealname"].ToString() + ",";
                                    }
                                    else
                                    {
                                        this.ZbUsername.Text = "";
                                        this.ZbRealname.Text = "";
                                    }
                                }
                                reader3.Close();
                            }
                            else if (list["XrGuize"].ToString() == "5")
                            {
                                str4 = "select BmUsername,BmRealname from qp_oa_Bumen where   ParentNodesID='0'  and  CHARINDEX(QxString,(select QxString from qp_oa_Bumen where id='" + HttpContext.Current.Session["BuMenId"].ToString() + "')) > 0";
                                reader3 = this.List.GetList(str4);
                                if (reader3.Read())
                                {
                                    if (reader3["BmUsername"].ToString() != "")
                                    {
                                        this.ZbUsername.Text = "" + reader3["BmUsername"].ToString() + ",";
                                        this.ZbRealname.Text = "" + reader3["BmRealname"].ToString() + ",";
                                    }
                                    else
                                    {
                                        this.ZbUsername.Text = "";
                                        this.ZbRealname.Text = "";
                                    }
                                }
                                reader3.Close();
                            }
                            else
                            {
                                this.ZbUsername.Text = list["ZbUsername"].ToString();
                                this.ZbRealname.Text = list["ZbRealname"].ToString();
                            }
                        }
                    }
                    if (list["XiugaiZb"].ToString() == "1")
                    {
                        this.Button4.Visible = false;
                    }
                    else
                    {
                        this.Button4.Visible = true;
                    }
                }
            }
            list.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str;
            if (this.ShenpiShuliang() > 1)
            {
                string str2;
                str = string.Concat(new object[] { "Update qp_hr_MyAttendance  Set YjbUser=YjbUser+'", this.Session["username"], ",',DqBlUsername=replace(DqBlUsername,'", this.Session["username"].ToString(), ",','') where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str);
                if (this.Yijian.Text.Trim() != "")
                {
                    str2 = string.Concat(new object[] { 
                        "Update qp_Pro_WorkFlowMsg  Set  Yijian=Yijian+'", this.Yijian.Text, "(", HttpContext.Current.Session["realname"], "-", DateTime.Now.ToString(), ")<br>',Realname=replace(Realname,'", this.Session["realname"].ToString(), "','<font color=\"blue\">", this.Session["realname"].ToString(), "(", DateTime.Now.ToString(), ")</font>') where GlNumber='", this.Number.Text, "' and  GlNum='", this.GlNum.Text, 
                        "'"
                     });
                    this.List.ExeSql(str2);
                }
                else
                {
                    str2 = "Update qp_Pro_WorkFlowMsg  Set  Realname=replace(Realname,'" + this.Session["realname"].ToString() + "','<font color=\"blue\">" + this.Session["realname"].ToString() + "(" + DateTime.Now.ToString() + ")</font>') where GlNumber='" + this.Number.Text + "' and  GlNum='" + this.GlNum.Text + "'";
                    this.List.ExeSql(str2);
                }
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "'</script>");
            }
            else
            {
                if (this.ZbRealname.Text != "")
                {
                    Random random = new Random();
                    string glNum = random.Next(0xf4240).ToString();
                    this.pulicss.SpUpdateLog(this.Number.Text, this.Yijian.Text, "3", this.GlNum.Text, this.CaoZuo.SelectedValue, DateTime.Now.ToString());
                    this.pulicss.SpInsertLog(this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), this.Number.Text, "", this.ZbUsername.Text, this.ZbRealname.Text, "1", glNum, "1", "", "1");
                    str = string.Concat(new object[] { 
                        "Update qp_hr_MyAttendance  Set  DqNodeId='", this.FormName.SelectedValue, "',DqNodeName='", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "',YjbNodeId=YjbNodeId+'", this.YjbNodeId.Value, ",',SNodeId='", this.YjbNodeId.Value, "',DqBlUsername='", this.ZbUsername.Text, "',DqBlXinming='", this.ZbRealname.Text, "',LcZhuangtai='2',YjbUser=YjbUser+'", this.Session["username"], ",',GlNum='", glNum, 
                        "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
                     });
                    this.List.ExeSql(str);
                    string sql = "select username,realname from qp_oa_Username where  CHARINDEX(','+username+',','," + this.ZbUsername.Text + ",')   >0 ";
                    SqlDataReader list = this.List.GetList(sql);
                    while (list.Read())
                    {
                        this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的", this.ViewState["typename"], "需要审批，事由：", this.Subject.Text, "，申请人：", this.Session["realname"], "" }), list["username"].ToString(), list["realname"].ToString(), "/HumanResources/WorkTime/MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
                    }
                    list.Close();
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "'</script>");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('操作失败,未找到转交对象！');</script>");
                }
                this.pulicss.InsertLog("审批" + this.ViewState["typename"] + "", "考勤系统");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str;
            if (this.ShenpiShuliang() > 1)
            {
                string str2;
                str = string.Concat(new object[] { "Update qp_hr_MyAttendance  Set DqBlUsername=replace(DqBlUsername,'", this.Session["username"].ToString(), ",','') where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str);
                if (this.Yijian.Text.Trim() != "")
                {
                    str2 = string.Concat(new object[] { 
                        "Update qp_Pro_WorkFlowMsg  Set  Yijian=Yijian+'", this.Yijian.Text, "(", HttpContext.Current.Session["realname"], "-", DateTime.Now.ToString(), ")<br>',Realname=replace(Realname,'", this.Session["realname"].ToString(), "','<font color=\"blue\">", this.Session["realname"].ToString(), "(", DateTime.Now.ToString(), ")</font>') where GlNumber='", this.Number.Text, "' and  GlNum='", this.GlNum.Text, 
                        "'"
                     });
                    this.List.ExeSql(str2);
                }
                else
                {
                    str2 = "Update qp_Pro_WorkFlowMsg  Set  Realname=replace(Realname,'" + this.Session["realname"].ToString() + "','<font color=\"blue\">" + this.Session["realname"].ToString() + "(" + DateTime.Now.ToString() + ")</font>') where GlNumber='" + this.Number.Text + "' and  GlNum='" + this.GlNum.Text + "'";
                    this.List.ExeSql(str2);
                }
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "'</script>");
            }
            else
            {
                Random random = new Random();
                string str3 = random.Next(0xf4240).ToString();
                this.pulicss.SpUpdateLog(this.Number.Text, this.Yijian.Text, "3", this.GlNum.Text, this.CaoZuo.SelectedValue, DateTime.Now.ToString());
                str = string.Concat(new object[] { "Update qp_hr_MyAttendance  Set  DqNodeId='',DqBlUsername='已结束',DqBlXinming='已结束',LcZhuangtai='3',YjbUser=YjbUser+'", this.Session["username"], ",',GlNum='", str3, "',YjbNodeId=YjbNodeId+'", this.YjbNodeId.Value, ",',DqNodeName='已结束',SNodeId='", this.YjbNodeId.Value, "' where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage(string.Concat(new object[] { "您的", this.ViewState["typename"], "需要审批，事由：", this.Subject.Text, "，已审批完成" }), this.Username.Text, this.Realname.Text, "/MyWork/WorkTime/MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "'</script>");
            }
        }

        protected void CaoZuo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CaoZuo.SelectedValue == "3")
            {
                this.DataBindToBuZhou(this.CaoZuo.SelectedValue, this.ViewState["UpNodeNum"].ToString());
            }
            else
            {
                this.DataBindToBuZhou(this.CaoZuo.SelectedValue, this.ViewState["YjbNodeId"].ToString());
            }
        }

        public void DataBindToBuZhou(string types, string UpNodeNum)
        {
            this.FormName.Items.Clear();
            if ((this.ViewState["NodeSite"].ToString() == "3") && (types == "3"))
            {
                if (this.ShenpiShuliang() > 1)
                {
                    this.Button3.Text = "办理完毕";
                    this.Label1.Text = "<font color=red>还有其他人未办理，请点击【办理完毕】，由其他人转交</font>";
                    this.Panel1.Visible = false;
                    this.FormName.Visible = false;
                }
                else
                {
                    this.Label1.Text = "结束归档";
                    this.Button3.Visible = false;
                    this.Button4.Visible = true;
                    this.Panel1.Visible = false;
                    this.Button3.Text = "转 交";
                }
            }
            else
            {
                string str;
                this.Label1.Text = "";
                this.Button3.Visible = true;
                this.Button4.Visible = false;
                this.Panel1.Visible = true;
                if (types == "3")
                {
                    str = string.Concat(new object[] { "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+NodeName as NodeName  from qp_Pro_WorkFlowNode where NodeNum  in (", UpNodeNum, "0) and FormId='", this.ViewState["FormId"], "' order by NodeNum asc" });
                    this.list.Bind_DropDownList_nothing1(this.FormName, str, "id", "NodeName");
                    if (this.ShenpiShuliang() > 1)
                    {
                        this.Button3.Text = "办理完毕";
                        this.Label1.Text = "<font color=red>还有其他人未办理，请点击【办理完毕】，由其他人转交</font>";
                        this.Panel1.Visible = false;
                        this.FormName.Visible = false;
                    }
                    else
                    {
                        this.Button3.Text = "转 交";
                    }
                }
                else
                {
                    str = string.Concat(new object[] { "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+NodeName as NodeName  from qp_Pro_WorkFlowNode where id  in (", UpNodeNum, "0) and FormId='", this.ViewState["FormId"], "' order by NodeNum asc" });
                    this.list.Bind_DropDownList_nothing1(this.FormName, str, "id", "NodeName");
                    this.Button3.Text = "转 交";
                    this.Label1.Text = "";
                    this.Panel1.Visible = true;
                    this.FormName.Visible = true;
                }
            }
            if (this.FormName.Items.Count > 0)
            {
                this.FormName.Items[0].Selected = true;
            }
            this.BindLb(this.FormName.SelectedValue);
        }

        protected void FormName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindLb(this.FormName.SelectedValue);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ZbRealname.Attributes.Add("readonly", "readonly");
                if (base.Request.QueryString["type"].ToString() == "1")
                {
                    this.ViewState["typename"] = "出差审批";
                    this.ViewState["diffname"] = "出差天数";
                    this.TDiffTime.Text = "出差天数";
                }
                if (base.Request.QueryString["type"].ToString() == "2")
                {
                    this.ViewState["typename"] = "休假审批";
                    this.ViewState["diffname"] = "休假天数";
                    this.TDiffTime.Text = "休假天数";
                }
                if (base.Request.QueryString["type"].ToString() == "3")
                {
                    this.ViewState["typename"] = "加班审批";
                    this.ViewState["diffname"] = "加班小时";
                    this.TDiffTime.Text = "加班小时";
                }
                string sql = string.Concat(new object[] { "select * from qp_hr_MyAttendance  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'  and CHARINDEX(',", this.Session["username"], ",',','+DqBlUsername+',')   >0" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NowTimes.Text = DateTime.Parse(list["NowTimes"].ToString()).ToShortDateString();
                    this.DqNodeName1.Text = list["DqNodeName"].ToString();
                    this.Label2.Text = list["Realname"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["YjbNodeId"] = list["YjbNodeId"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.Subject.Text = list["Subject"].ToString();
                    this.StartTime.Text = list["StartTime"].ToString();
                    this.EndTime.Text = list["EndTime"].ToString();
                    this.DiffTime.Text = list["DiffTime"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Username.Text = list["Username"].ToString();
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('无相关数据！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "'</script>");
                }
                list.Close();
                this.pulicss.SpUpdateLog(this.Number.Text, "", "2", this.GlNum.Text, "1", "");
                string str2 = "select  * from qp_Pro_WorkFlowMsg where GlNumber='" + this.Number.Text + "'  order by id asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                while (reader2.Read())
                {
                    object text;
                    string str3 = null;
                    if (reader2["GlNum"].ToString() == this.GlNum.Text)
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"18%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>第<font color=red><b>", num, "</b></font>步(当前步骤)</td>" });
                    }
                    else
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"18%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>第<font color=red><b>", num, "</b></font>步</td>" });
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"42%\" style=\"line-height: 150%\">";
                    str3 = "select  * from qp_Pro_WorkFlowMsg  where  GlNum='" + reader2["GlNum"].ToString() + "'  order by id asc";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    while (reader3.Read())
                    {
                        TimeSpan span;
                        string str4 = "";
                        if (reader3["Zhuangtai"].ToString() == "1")
                        {
                            str4 = "flow_close.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str4, "\"  title=\"", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader3["BuZhouName"], "</font></b><font color=#008000>(", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader3["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>意见备注：", reader3["Yijian"], "<br>操作人员：", reader3["Realname"], "<br>"
                             });
                        }
                        else if (reader3["Zhuangtai"].ToString() == "2")
                        {
                            str4 = "flow_open.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str4, "\"  title=\"", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader3["BuZhouName"], "</font></b><font color=#008000>(", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader3["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>意见备注：", reader3["Yijian"], "<br>操作人员：", reader3["Realname"], "<br>"
                             });
                        }
                        else
                        {
                            str4 = "workflow_query.gif";
                            span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str4, "\"  title=\"", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader3["BuZhouName"], "</font></b></font><font color=#008000>(", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader3["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>意见备注：", reader3["Yijian"], "<br>操作人员：", reader3["Realname"], "<br>"
                             });
                        }
                    }
                    reader3.Close();
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader2.Close();
                if (this.LcZhuangtai.Text == "通过审批")
                {
                    this.Liucheng.Text = this.Liucheng.Text + "<tr><td class=\"newtd2\" width=\"100%\" colspan=\"3\" align=\"center\"><font color=red><b>已通过审批</b></font></td>";
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                }
                if (this.LcZhuangtai.Text == "终止审批")
                {
                    this.Liucheng.Text = this.Liucheng.Text + "<tr><td class=\"newtd2\" width=\"100%\" colspan=\"3\" align=\"center\"><font color=red><b>已终止审批</b></font></td>";
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                }
                this.Liucheng.Text = this.Liucheng.Text + "</table>";
                string str5 = "select id,UpNodeNum,NodeName,Huitui,NodeSite,JbZhuangjiao from qp_Pro_WorkFlowNode where  id='" + this.ViewState["DqNodeId"] + "'";
                SqlDataReader reader4 = this.List.GetList(str5);
                if (reader4.Read())
                {
                    this.YjbNodeId.Value = reader4["id"].ToString();
                    this.NodeName.Value = reader4["NodeName"].ToString();
                    this.ViewState["Huitui"] = reader4["Huitui"].ToString();
                    this.ViewState["UpNodeNum"] = reader4["UpNodeNum"].ToString();
                    this.ViewState["NodeSite"] = reader4["NodeSite"].ToString();
                    if (this.ViewState["Huitui"].ToString() == "1")
                    {
                        this.CaoZuo.Enabled = false;
                    }
                    else
                    {
                        this.CaoZuo.Enabled = true;
                    }
                    this.JbZhuangjiao.Text = reader4["JbZhuangjiao"].ToString();
                    this.DataBindToBuZhou("3", reader4["UpNodeNum"].ToString());
                }
                reader4.Close();
                string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
            }
        }

        public int ShenpiShuliang()
        {
            int num = 0;
            string sql = "select DqBlUsername from qp_hr_MyAttendance   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                num = list["DqBlUsername"].ToString().Length - list["DqBlUsername"].ToString().Replace(",", string.Empty).Length;
            }
            list.Close();
            if (this.JbZhuangjiao.Text == "1")
            {
                num = 0;
            }
            return num;
        }
    }
}


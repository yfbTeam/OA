namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingApply_sp_show : Page
    {
        protected Button Button1;
        protected Button Button3;
        protected Button Button4;
        protected HtmlInputButton Button9;
        protected RadioButtonList CaoZuo;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
        protected TextBox chongtu;
        protected Label DqNodeName1;
        protected Label Endtime;
        protected HtmlForm form1;
        protected RadioButtonList FormName;
        protected Label fujian;
        protected TextBox GlNum;
        protected HtmlHead Head1;
        protected HtmlImage IMG2;
        protected Label Introduction;
        protected TextBox JbZhuangjiao;
        protected Label Label1;
        protected Label LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected Label MettingName;
        protected Label Name;
        protected Label NbPeopleName;
        protected TextBox NbPeopleUser;
        protected HtmlInputHidden NodeName;
        protected DropDownList normalcontent;
        protected Label NowTimes;
        protected TextBox Number;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Remark;
        protected Label Starttime;
        protected TextBox Username;
        protected Label WbPeople;
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
                    this.Button9.Visible = false;
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
                        this.Button9.Visible = false;
                    }
                    else
                    {
                        this.Button9.Visible = true;
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
                str = string.Concat(new object[] { "Update qp_oa_MettingApply  Set YjbUser=YjbUser+'", this.Session["username"], ",',DqBlUsername=replace(DqBlUsername,'", this.Session["username"].ToString(), ",','') where id='", int.Parse(base.Request.QueryString["id"]), "'" });
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
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MettingApply_sp.aspx'</script>");
            }
            else if (this.ZbRealname.Text != "")
            {
                Random random = new Random();
                string glNum = random.Next(0xf4240).ToString();
                this.pulicss.SpUpdateLog(this.Number.Text, this.Yijian.Text, "3", this.GlNum.Text, this.CaoZuo.SelectedValue, DateTime.Now.ToString());
                this.pulicss.SpInsertLog(this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), this.Number.Text, "", this.ZbUsername.Text, this.ZbRealname.Text, "1", glNum, "1", "", "1");
                str = string.Concat(new object[] { 
                    "Update qp_oa_MettingApply  Set  DqNodeId='", this.FormName.SelectedValue, "',DqNodeName='", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "',YjbNodeId=YjbNodeId+'", this.YjbNodeId.Value, ",',SNodeId='", this.YjbNodeId.Value, "',DqBlUsername='", this.ZbUsername.Text, "',DqBlXinming='", this.ZbRealname.Text, "',LcZhuangtai='2',YjbUser=YjbUser+'", this.Session["username"], ",',GlNum='", glNum, 
                    "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str);
                string sql = "select username,realname from qp_oa_Username where  CHARINDEX(','+username+',','," + this.ZbUsername.Text + ",')   >0 ";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    this.pulicss.InsertMessage("您有会议需要审批，会议名称：" + this.Name.Text + "", list["username"].ToString(), list["realname"].ToString(), "/OfficeMenu/Metting/MettingApply_sp.aspx");
                }
                list.Close();
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MettingApply_sp.aspx'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('操作失败,未找到转交对象！');</script>");
            }
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            base.Response.Redirect("MettingApply_sp.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str;
            if (this.ShenpiShuliang() > 1)
            {
                string str2;
                str = string.Concat(new object[] { "Update qp_oa_MettingApply  Set DqBlUsername=replace(DqBlUsername,'", this.Session["username"].ToString(), ",','') where id='", int.Parse(base.Request.QueryString["id"]), "'" });
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
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MettingApply_sp.aspx'</script>");
            }
            else
            {
                string str3 = null;
                string str4 = null;
                str4 = "" + this.NbPeopleUser.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = str4.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    str3 = str3 + "'" + strArray[i] + "',";
                }
                str3 = str3 + "'0'";
                string sql = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str3 + ") ";
                SqlDataReader reader = this.List.GetList(sql);
                while (reader.Read())
                {
                    if (this.CheckBox2.Checked)
                    {
                        this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的会议需要参加：", this.Name.Text, "，发起人：", this.Session["realname"], "" }), reader["username"].ToString(), reader["realname"].ToString(), "/MyWork/Metting/MyMetting.aspx");
                    }
                    if (this.CheckBox3.Checked)
                    {
                        this.pulicss.InsertSms(reader["MoveTel"].ToString(), string.Concat(new object[] { "您有新的会议室需要参加：", this.Name.Text, "，发起人：", this.Session["realname"], "" }));
                    }
                }
                reader.Close();
                Random random = new Random();
                string str6 = random.Next(0xf4240).ToString();
                this.pulicss.SpUpdateLog(this.Number.Text, this.Yijian.Text, "3", this.GlNum.Text, this.CaoZuo.SelectedValue, DateTime.Now.ToString());
                str = string.Concat(new object[] { "Update qp_oa_MettingApply  Set  State='6',DqNodeId='',DqBlUsername='已结束',DqBlXinming='已结束',LcZhuangtai='3',YjbUser=YjbUser+'", this.Session["username"], ",',GlNum='", str6, "',YjbNodeId=YjbNodeId+'", this.YjbNodeId.Value, ",',DqNodeName='已结束',SNodeId='", this.YjbNodeId.Value, "' where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage("您有会议，主题[" + this.Name.Text + "]已审批完成", this.Username.Text, this.Realname.Text, "/OfficeMenu/Metting/Faqi.aspx");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MettingApply_sp.aspx'</script>");
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
                    this.Panel2.Visible = false;
                    this.FormName.Visible = false;
                }
                else
                {
                    this.Label1.Text = "结束归档";
                    this.Button3.Visible = false;
                    this.Button4.Visible = true;
                    this.Panel1.Visible = false;
                    this.Panel2.Visible = true;
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
                this.Panel2.Visible = false;
                if (types == "3")
                {
                    str = string.Concat(new object[] { "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+NodeName as NodeName  from qp_Pro_WorkFlowNode where NodeNum  in (", UpNodeNum, "0) and FormId='", this.ViewState["FormId"], "' order by NodeNum asc" });
                    this.list.Bind_DropDownList_nothing1(this.FormName, str, "id", "NodeName");
                    if (this.ShenpiShuliang() > 1)
                    {
                        this.Button3.Text = "办理完毕";
                        this.Label1.Text = "<font color=red>还有其他人未办理，请点击【办理完毕】，由其他人转交</font>";
                        this.Panel1.Visible = false;
                        this.Panel2.Visible = false;
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
                this.pulicss.QuanXianVis(this.CheckBox3, ",8,", this.pulicss.GetSms());
                this.pulicss.QuanXianVis(this.IMG2, ",8,", this.pulicss.GetSms());
                this.ZbRealname.Attributes.Add("readonly", "readonly");
                string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
                string sql = "select * from qp_oa_MettingApply   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NowTimes.Text = DateTime.Parse(list["NowTimes"].ToString()).ToShortDateString();
                    this.DqNodeName1.Text = list["DqNodeName"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    this.Username.Text = list["Username"].ToString();
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["YjbNodeId"] = list["YjbNodeId"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.Introduction.Text = this.pulicss.TbToLb(list["Introduction"].ToString());
                    this.WbPeople.Text = list["WbPeople"].ToString();
                    this.NbPeopleUser.Text = list["NbPeopleUser"].ToString();
                    this.NbPeopleName.Text = list["NbPeopleName"].ToString();
                    this.MettingName.Text = list["MettingName"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    this.GlNum.Text = list["GlNum"].ToString();
                    string str3 = string.Concat(new object[] { "select  * from qp_oa_MettingApply where id!='", base.Request.QueryString["id"], "' and (State!='4' and State!='5') and  (MettingId='", list["MettingId"], "')  and   ((Starttime >= '", list["Starttime"], "' and Endtime < '", list["Endtime"], "') or (Endtime > '", list["Starttime"], "' and Starttime <= '", list["Endtime"], "'))" });
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        this.chongtu.Text = "1";
                        this.ViewState["ctstr"] = "有冲突，点击";
                    }
                    else
                    {
                        this.chongtu.Text = "2";
                        this.ViewState["ctstr"] = "";
                    }
                    reader2.Close();
                }
                list.Close();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                this.pulicss.SpUpdateLog(this.Number.Text, "", "2", this.GlNum.Text, "1", "");
                string str4 = "select  * from qp_Pro_WorkFlowMsg where GlNumber='" + this.Number.Text + "'  order by id asc";
                SqlDataReader reader3 = this.List.GetList(str4);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                while (reader3.Read())
                {
                    object text;
                    string str5 = null;
                    if (reader3["GlNum"].ToString() == this.GlNum.Text)
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
                    str5 = "select  * from qp_Pro_WorkFlowMsg  where  GlNum='" + reader3["GlNum"].ToString() + "'  order by id asc";
                    SqlDataReader reader4 = this.List.GetList(str5);
                    while (reader4.Read())
                    {
                        TimeSpan span;
                        string str6 = "";
                        if (reader4["Zhuangtai"].ToString() == "1")
                        {
                            str6 = "flow_close.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader4["BuZhouName"], "</font></b><font color=#008000>(", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader4["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>意见备注：", reader4["Yijian"], "<br>操作人员：", reader4["Realname"], "<br>"
                             });
                        }
                        else if (reader4["Zhuangtai"].ToString() == "2")
                        {
                            str6 = "flow_open.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader4["BuZhouName"], "</font></b><font color=#008000>(", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader4["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>意见备注：", reader4["Yijian"], "<br>操作人员：", reader4["Realname"], "<br>"
                             });
                        }
                        else
                        {
                            str6 = "workflow_query.gif";
                            span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader4["BuZhouName"], "</font></b></font><font color=#008000>(", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader4["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>意见备注：", reader4["Yijian"], "<br>操作人员：", reader4["Realname"], "<br>"
                             });
                        }
                    }
                    reader4.Close();
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader3.Close();
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
                string str7 = "select id,UpNodeNum,NodeName,Huitui,NodeSite,JbZhuangjiao from qp_Pro_WorkFlowNode where  id='" + this.ViewState["DqNodeId"] + "'";
                SqlDataReader reader5 = this.List.GetList(str7);
                if (reader5.Read())
                {
                    this.YjbNodeId.Value = reader5["id"].ToString();
                    this.NodeName.Value = reader5["NodeName"].ToString();
                    this.ViewState["Huitui"] = reader5["Huitui"].ToString();
                    this.ViewState["UpNodeNum"] = reader5["UpNodeNum"].ToString();
                    this.ViewState["NodeSite"] = reader5["NodeSite"].ToString();
                    if (this.ViewState["Huitui"].ToString() == "1")
                    {
                        this.CaoZuo.Enabled = false;
                    }
                    else
                    {
                        this.CaoZuo.Enabled = true;
                    }
                    this.JbZhuangjiao.Text = reader5["JbZhuangjiao"].ToString();
                    this.DataBindToBuZhou("3", reader5["UpNodeNum"].ToString());
                }
                reader5.Close();
            }
        }

        public int ShenpiShuliang()
        {
            int num = 0;
            string sql = "select DqBlUsername from qp_oa_MettingApply   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
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


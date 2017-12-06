namespace xyoa.pda.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListSp_Next : Page
    {
        protected Button Button1;
        protected Button Button5;
        protected CheckBox C1;
        protected CheckBox C2;
        protected CheckBox C3;
        protected CheckBox C4;
        protected CheckBox C5;
        protected CheckBox C6;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected RadioButtonList FormName;
        protected TextBox GlNum;
        protected TextBox GlNum1;
        protected HtmlHead Head1;
        protected ImageButton ImageButton4;
        protected HtmlImage IMG1;
        protected HtmlImage IMG2;
        protected HtmlImage IMG3;
        protected TextBox JbGuanlianID;
        protected TextBox JbGuanlianName;
        protected TextBox JbRealname;
        protected TextBox JbUsername;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected TextBox OpenBack;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected TextBox ZbGuanlianID;
        protected TextBox ZbGuanlianName;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;
        protected TextBox ZbUsername6;

        public void BindLb(string str)
        {
            this.ZbUsername.Text = null;
            this.ZbRealname.Text = null;
            this.JbUsername.Text = null;
            this.JbRealname.Text = null;
            string sql = "select ZbUsername,ZbRealname,JbUsername,JbRealname,XrGuize,GlGuize,ZbGuanlianID,ZbGuanlianName,JbGuanlianID,JbGuanlianName from qp_oa_WorkFlowNode where id='" + str + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ZbGuanlianID.Text = list["ZbGuanlianID"].ToString();
                this.ZbGuanlianName.Text = list["ZbGuanlianName"].ToString();
                this.JbGuanlianID.Text = list["JbGuanlianID"].ToString();
                this.JbGuanlianName.Text = list["JbGuanlianName"].ToString();
                if (list["XrGuize"].ToString() == "1")
                {
                    this.ZbUsername.Text = "";
                    this.ZbRealname.Text = "";
                    this.JbUsername.Text = "";
                    this.JbRealname.Text = "";
                }
                else
                {
                    string str3;
                    SqlDataReader reader2;
                    if (list["XrGuize"].ToString() == "2")
                    {
                        str3 = "select FqUsername,FqRealname from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.ZbUsername.Text = reader2["FqUsername"].ToString();
                            this.ZbRealname.Text = reader2["FqRealname"].ToString();
                            this.JbUsername.Text = "" + reader2["FqUsername"].ToString() + ",";
                            this.JbRealname.Text = "" + reader2["FqRealname"].ToString() + ",";
                        }
                        reader2.Close();
                    }
                    else if (list["XrGuize"].ToString() == "7")
                    {
                        this.ZbUsername.Text = this.Session["Username"].ToString();
                        this.ZbRealname.Text = this.Session["Realname"].ToString();
                        this.JbUsername.Text = "" + this.Session["Username"].ToString() + ",";
                        this.JbRealname.Text = "" + this.Session["Realname"].ToString() + ",";
                    }
                    else
                    {
                        string str4;
                        SqlDataReader reader3;
                        string str5;
                        SqlDataReader reader4;
                        if (list["XrGuize"].ToString() == "8")
                        {
                            str4 = "select Username,Realname from qp_oa_username where JueseId='" + this.ZbGuanlianID.Text + "'";
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                this.ZbUsername.Text = reader3["Username"].ToString();
                                this.ZbRealname.Text = reader3["Realname"].ToString();
                            }
                            reader3.Close();
                            str5 = "select Username,Realname from qp_oa_username where JueseId in (" + this.JbGuanlianID.Text + "0)";
                            reader4 = this.List.GetList(str5);
                            while (reader4.Read())
                            {
                                this.JbUsername.Text = this.JbUsername.Text + "" + reader4["Username"].ToString() + ",";
                                this.JbRealname.Text = this.JbRealname.Text + "" + reader4["Realname"].ToString() + ",";
                            }
                            reader4.Close();
                        }
                        else if (list["XrGuize"].ToString() == "10")
                        {
                            str4 = "select Username,Realname from qp_oa_username where Zhiweiid='" + this.ZbGuanlianID.Text + "'";
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                this.ZbUsername.Text = reader3["Username"].ToString();
                                this.ZbRealname.Text = reader3["Realname"].ToString();
                            }
                            reader3.Close();
                            str5 = "select Username,Realname from qp_oa_username where Zhiweiid in (" + this.JbGuanlianID.Text + "0)";
                            reader4 = this.List.GetList(str5);
                            while (reader4.Read())
                            {
                                this.JbUsername.Text = this.JbUsername.Text + "" + reader4["Username"].ToString() + ",";
                                this.JbRealname.Text = this.JbRealname.Text + "" + reader4["Realname"].ToString() + ",";
                            }
                            reader4.Close();
                        }
                        else if (list["XrGuize"].ToString() == "13")
                        {
                            str4 = "select Username,Realname from qp_oa_username where BuMenId='" + this.ZbGuanlianID.Text + "'";
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                this.ZbUsername.Text = reader3["Username"].ToString();
                                this.ZbRealname.Text = reader3["Realname"].ToString();
                            }
                            reader3.Close();
                            str5 = "select Username,Realname from qp_oa_username where BuMenId in (" + this.JbGuanlianID.Text + "0)";
                            reader4 = this.List.GetList(str5);
                            while (reader4.Read())
                            {
                                this.JbUsername.Text = this.JbUsername.Text + "" + reader4["Username"].ToString() + ",";
                                this.JbRealname.Text = this.JbRealname.Text + "" + reader4["Realname"].ToString() + ",";
                            }
                            reader4.Close();
                        }
                        else if (list["XrGuize"].ToString() == "3")
                        {
                            str3 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + this.Session["BuMenId"].ToString() + "'";
                            reader2 = this.List.GetList(str3);
                            if (reader2.Read())
                            {
                                this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                if (reader2["BmUsername"].ToString() != "")
                                {
                                    this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                    this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                }
                                else
                                {
                                    this.JbUsername.Text = "";
                                    this.JbRealname.Text = "";
                                }
                            }
                            reader2.Close();
                        }
                        else
                        {
                            string str6;
                            SqlDataReader reader5;
                            if (list["XrGuize"].ToString() == "4")
                            {
                                str3 = "select ParentNodesID,BmUsername,BmRealname from qp_oa_Bumen where  id='" + this.Session["BuMenId"].ToString() + "'";
                                reader2 = this.List.GetList(str3);
                                if (reader2.Read())
                                {
                                    if (reader2["ParentNodesID"].ToString() != "0")
                                    {
                                        str6 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + reader2["ParentNodesID"].ToString() + "'";
                                        reader5 = this.List.GetList(str6);
                                        if (reader5.Read())
                                        {
                                            this.ZbUsername.Text = reader5["BmUsername"].ToString();
                                            this.ZbRealname.Text = reader5["BmRealname"].ToString();
                                            if (reader5["BmUsername"].ToString() != "")
                                            {
                                                this.JbUsername.Text = "" + reader5["BmUsername"].ToString() + ",";
                                                this.JbRealname.Text = "" + reader5["BmRealname"].ToString() + ",";
                                            }
                                            else
                                            {
                                                this.JbUsername.Text = "";
                                                this.JbRealname.Text = "";
                                            }
                                        }
                                        reader5.Close();
                                    }
                                    else
                                    {
                                        this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                        this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                        if (reader2["BmUsername"].ToString() != "")
                                        {
                                            this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                            this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                        }
                                        else
                                        {
                                            this.JbUsername.Text = "";
                                            this.JbRealname.Text = "";
                                        }
                                    }
                                }
                                reader2.Close();
                            }
                            else if (list["XrGuize"].ToString() == "5")
                            {
                                str3 = "select BmUsername,BmRealname from qp_oa_Bumen where   ParentNodesID='0'  and  CHARINDEX(QxString,(select QxString from qp_oa_Bumen where id='" + HttpContext.Current.Session["BuMenId"].ToString() + "')) > 0";
                                reader2 = this.List.GetList(str3);
                                if (reader2.Read())
                                {
                                    this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                    this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                    if (reader2["BmUsername"].ToString() != "")
                                    {
                                        this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                        this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                    }
                                    else
                                    {
                                        this.JbUsername.Text = "";
                                        this.JbRealname.Text = "";
                                    }
                                }
                                reader2.Close();
                            }
                            else
                            {
                                string str7;
                                SqlDataReader reader6;
                                if (list["XrGuize"].ToString() == "11")
                                {
                                    str7 = "select FqUsername,FqRealname from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                                    reader6 = this.List.GetList(str7);
                                    if (reader6.Read())
                                    {
                                        str3 = "select BmUsername,BmRealname from qp_oa_Bumen where   id=(select BuMenId from qp_oa_username where username='" + reader6["FqUsername"].ToString() + "')";
                                        reader2 = this.List.GetList(str3);
                                        if (reader2.Read())
                                        {
                                            this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                            this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                            if (reader2["BmUsername"].ToString() != "")
                                            {
                                                this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                                this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                            }
                                            else
                                            {
                                                this.JbUsername.Text = "";
                                                this.JbRealname.Text = "";
                                            }
                                        }
                                        reader2.Close();
                                    }
                                    reader6.Close();
                                }
                                else if (list["XrGuize"].ToString() == "12")
                                {
                                    str7 = "select FqUsername,FqRealname from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                                    reader6 = this.List.GetList(str7);
                                    if (reader6.Read())
                                    {
                                        str3 = "select ParentNodesID,BmUsername,BmRealname from qp_oa_Bumen where  id=(select BuMenId from qp_oa_username where username='" + reader6["FqUsername"].ToString() + "')";
                                        reader2 = this.List.GetList(str3);
                                        if (reader2.Read())
                                        {
                                            if (reader2["ParentNodesID"].ToString() != "0")
                                            {
                                                str6 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + reader2["ParentNodesID"].ToString() + "'";
                                                reader5 = this.List.GetList(str6);
                                                if (reader5.Read())
                                                {
                                                    this.ZbUsername.Text = reader5["BmUsername"].ToString();
                                                    this.ZbRealname.Text = reader5["BmRealname"].ToString();
                                                    if (reader5["BmUsername"].ToString() != "")
                                                    {
                                                        this.JbUsername.Text = "" + reader5["BmUsername"].ToString() + ",";
                                                        this.JbRealname.Text = "" + reader5["BmRealname"].ToString() + ",";
                                                    }
                                                    else
                                                    {
                                                        this.JbUsername.Text = "";
                                                        this.JbRealname.Text = "";
                                                    }
                                                }
                                                reader5.Close();
                                            }
                                            else
                                            {
                                                this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                                this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                                if (reader2["BmUsername"].ToString() != "")
                                                {
                                                    this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                                    this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                                }
                                                else
                                                {
                                                    this.JbUsername.Text = "";
                                                    this.JbRealname.Text = "";
                                                }
                                            }
                                        }
                                        reader2.Close();
                                    }
                                    reader6.Close();
                                }
                                else
                                {
                                    this.ZbUsername.Text = list["ZbUsername"].ToString();
                                    this.ZbUsername6.Text = list["JbUsername"].ToString();
                                    this.ZbRealname.Text = list["ZbRealname"].ToString();
                                    this.JbUsername.Text = list["JbUsername"].ToString();
                                    this.JbRealname.Text = list["JbRealname"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            list.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListAll.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (this.JbUsername.Text.Trim() == "")
            {
                this.Label1.Text = "经办人为空，转交失败";
            }
            else
            {
                int num;
                string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.ViewState["WfNumber"], "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' and States!='已委托'" });
                this.List.ExeSql(sql);
                string str2 = null;
                string str3 = null;
                str3 = "" + this.JbUsername.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = str3.Split(new char[] { ',' });
                for (num = 0; num < strArray.Length; num++)
                {
                    str2 = str2 + "'" + strArray[num] + "',";
                }
                str2 = str2 + "'0'";
                string str4 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str2 + ") ";
                SqlDataReader reader = this.List.GetList(str4);
                while (reader.Read())
                {
                    if (this.C1.Checked)
                    {
                        this.pulicss.InsertMessage("" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text + "", reader["username"].ToString(), reader["realname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                    }
                    if (this.C2.Checked)
                    {
                        this.pulicss.InsertSms(reader["MoveTel"].ToString(), "" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "");
                    }
                }
                reader.Close();
                if (this.C3.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text, "" }), this.ViewState["FqUsername"].ToString(), this.ViewState["FqRealname"].ToString(), "#");
                }
                if (this.C4.Checked)
                {
                    string str5 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"].ToString() + "' ";
                    SqlDataReader reader2 = this.List.GetList(str5);
                    if (reader2.Read())
                    {
                        this.pulicss.InsertSms(reader2["MoveTel"].ToString(), string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "" }));
                    }
                    reader2.Close();
                }
                string str6 = null;
                string str7 = null;
                str7 = "" + this.ViewState["JbObjectId"] + "";
                ArrayList list2 = new ArrayList();
                string[] strArray2 = str7.Split(new char[] { ',' });
                for (num = 0; num < strArray2.Length; num++)
                {
                    str6 = str6 + "'" + strArray2[num] + "',";
                }
                str6 = str6 + "'0'";
                string str8 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str6 + ") ";
                SqlDataReader reader3 = this.List.GetList(str8);
                while (reader3.Read())
                {
                    if (this.C5.Checked)
                    {
                        this.pulicss.InsertMessage(string.Concat(new object[] { "等待您办理的工作", this.ViewState["Name"], "已转交到：", this.FormName.SelectedItem.Text, "" }), reader3["username"].ToString(), reader3["realname"].ToString(), "#");
                    }
                    if (this.C6.Checked)
                    {
                        this.pulicss.InsertSms(reader3["MoveTel"].ToString(), string.Concat(new object[] { "等待您办理的工作", this.ViewState["Name"], "已转交到：", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "" }));
                    }
                }
                reader3.Close();
                string str9 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "' and States!='已委托'";
                this.List.ExeSql(str9);
                string str10 = "select * from qp_oa_WorkFlowNode where id='" + this.FormName.SelectedValue + "'";
                SqlDataReader reader4 = this.List.GetList(str10);
                if (reader4.Read())
                {
                    string str19;
                    string str11 = string.Concat(new object[] { 
                        "Update qp_oa_AddWorkFlow  Set GlNum='", this.GlNum.Text, "',YJBNodeNum=YJBNodeNum+',", this.ViewState["UpNodeNum"], "',State='正在办理',ZbObjectId='", this.ZbUsername.Text, "',ZbObjectName='", this.ZbRealname.Text, "',JbObjectId='", this.JbUsername.Text, "',JbObjectName='", this.JbRealname.Text, "',UpNodeNumber='", reader4["NodeNumber"], "',UpNodeId='", reader4["id"], 
                        "',UpNodeNum='", reader4["NodeNum"], "',UpNodeName='", reader4["NodeName"], "',UpTimeSet='", DateTime.Now.ToString(), "'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'"
                     });
                    this.List.ExeSql(str11);
                    string str12 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and id='", base.Request.QueryString["id"], "'" });
                    SqlDataReader reader5 = this.List.GetList(str12);
                    if (!reader5.Read())
                    {
                        string str13 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                        this.List.ExeSql(str13);
                    }
                    reader5.Close();
                    string str14 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPic (GlNum,LcNum,KeyFile,XuHao,Jiedian) values ('", this.GlNum.Text, "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader4["NodeNum"], "','", reader4["NodeName"], "')" });
                    this.List.ExeSql(str14);
                    if (this.ZbUsername.Text != "")
                    {
                        string str15 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader4["NodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','", DateTime.Now.ToString(), "','','未接收','主办')" });
                        this.List.ExeSql(str15);
                    }
                    string str16 = null;
                    string str17 = null;
                    if (this.ZbUsername.Text != "")
                    {
                        str17 = "" + this.JbUsername.Text.Replace("" + this.ZbUsername.Text + ",", "") + "";
                    }
                    else
                    {
                        str17 = "" + this.JbUsername.Text + "";
                    }
                    ArrayList list3 = new ArrayList();
                    string[] strArray3 = str17.Split(new char[] { ',' });
                    for (num = 0; num < strArray3.Length; num++)
                    {
                        str16 = str16 + "'" + strArray3[num] + "',";
                    }
                    str16 = str16 + "'0'";
                    string str18 = "select username,realname from qp_oa_Username where  username in (" + str16 + ") ";
                    SqlDataReader reader6 = this.List.GetList(str18);
                    while (reader6.Read())
                    {
                        str19 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader4["NodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader6["username"], "','", reader6["realname"], "','", DateTime.Now.ToString(), "','','未接收','经办')" });
                        this.List.ExeSql(str19);
                    }
                    reader6.Close();
                    string str20 = "select A.id as Aid,A.GlNum,A.IfZb,A.LcNum,A.KeyFile,A.XuHao,A.KeyFile,A.BLusername,A.BLrealname,B.* from [qp_oa_AddWorkFlowPicRy] as [A] inner join [qp_oa_MyWeituo] as [B] on [A].[BLusername] = [B].Username and [B].[States] = '1' and [A].KeyFile='" + base.Request.QueryString["Number"] + "' and [A].GlNum='" + this.GlNum.Text + "' ";
                    SqlDataReader reader7 = this.List.GetList(str20);
                    while (reader7.Read())
                    {
                        string str21 = "select id,Number,UpNodeNum,UpNodeName,FormName,Name,JbObjectId,JbObjectName from qp_oa_AddWorkFlow where Number='" + reader7["KeyFile"] + "'";
                        SqlDataReader reader8 = this.List.GetList(str21);
                        if (reader8.Read())
                        {
                            string str22;
                            string str23;
                            string str24;
                            if (reader7["IfZb"].ToString() == "主办")
                            {
                                str22 = "" + reader8["JbObjectId"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtUsername"].ToString() + ",") + "";
                                str23 = "" + reader8["JbObjectName"].ToString().Replace("" + reader7["BLrealname"].ToString() + ",", "" + reader7["WtRealname"].ToString() + ",") + "";
                                str24 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set ZbObjectId='", reader7["WtUsername"], "',ZbObjectName='", reader7["WtRealname"], "',JbObjectId='", str22, "',JbObjectName='", str23, "'  where id='", reader8["id"].ToString(), "'" });
                                this.List.ExeSql(str24);
                            }
                            else
                            {
                                str22 = "" + reader8["JbObjectId"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtUsername"].ToString() + ",") + "";
                                str23 = "" + reader8["JbObjectName"].ToString().Replace("" + reader7["BLrealname"].ToString() + ",", "" + reader7["WtRealname"].ToString() + ",") + "";
                                str24 = "Update qp_oa_AddWorkFlow  Set JbObjectId='" + str22 + "',JbObjectName='" + str23 + "'  where id='" + reader8["id"].ToString() + "'";
                                this.List.ExeSql(str24);
                            }
                        }
                        reader8.Close();
                        if (this.C1.Checked)
                        {
                            this.pulicss.InsertMessage("" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text + "", reader7["WtUsername"].ToString(), reader7["WtRealname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                        }
                        if (this.C2.Checked)
                        {
                            string str25 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + reader7["WtUsername"].ToString() + "' ";
                            SqlDataReader reader9 = this.List.GetList(str25);
                            if (reader9.Read())
                            {
                                this.pulicss.InsertSms(reader9["MoveTel"].ToString(), "" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "");
                            }
                            reader9.Close();
                        }
                        string str26 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已委托',EndTime='", DateTime.Now.ToString(), "',WtUsername='", reader7["WtUsername"], "',WtRealname='", reader7["WtRealname"], "'   where id='", reader7["Aid"], "' " });
                        this.List.ExeSql(str26);
                        str19 = string.Concat(new object[] { 
                            "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", reader7["GlNum"], "','", reader7["XuHao"], "','", reader7["LcNum"], "','", reader7["KeyFile"], "','", reader7["WtUsername"], "','", reader7["WtRealname"], "','", DateTime.Now.ToString(), "','','未接收','", reader7["IfZb"], 
                            "')"
                         });
                        this.List.ExeSql(str19);
                    }
                    reader7.Close();
                    this.showform.AddWorkFlowLog("110", base.Request.QueryString["Number"].ToString(), this.ViewState["FormNames"].ToString(), this.ViewState["NodeName"].ToString(), "转交工作" + this.ViewState["Name"] + "", this.ViewState["IfZb"].ToString());
                }
                else
                {
                    reader4.Close();
                    base.Response.Write("<script language=javascript>alert('未找到下一步骤！');</script>");
                    return;
                }
                reader4.Close();
                base.Response.Write("<script language=javascript>alert('转交成功！');window.location.href='WorkFlowListAll.aspx'</script>");
            }
        }

        protected void FormName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindLb(this.FormName.SelectedValue);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.JbRealname.Attributes.Add("readonly", "readonly");
                this.ZbRealname.Attributes.Add("readonly", "readonly");
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.ViewState["pdauer"] = this.pulicss.pdauser();
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                this.GlNum.Text = "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                string sql = "select * from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["FormNames"] = list["FormName"].ToString();
                    this.ViewState["Sequence"] = list["Sequence"].ToString();
                    this.ViewState["Name"] = list["Name"].ToString();
                    this.ViewState["NodeName"] = list["UpNodeName"].ToString();
                    this.ViewState["UpNodeNum"] = list["UpNodeNum"].ToString();
                    this.txtSmsContent.Text = "工作流转交提醒：" + list["Name"].ToString() + "";
                    this.ViewState["FqUsername"] = list["FqUsername"].ToString();
                    this.ViewState["FqRealname"] = list["FqRealname"].ToString();
                    this.ViewState["JbObjectId"] = list["JbObjectId"].ToString();
                    this.ViewState["JbObjectName"] = list["JbObjectName"].ToString();
                    this.ViewState["FlowNumber"] = list["FlowNumber"].ToString();
                    this.GlNum1.Text = list["GlNum"].ToString();
                    this.ViewState["WfNumber"] = list["Number"].ToString();
                }
                list.Close();
                string sQL = "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+NodeName as NodeName  from qp_oa_WorkFlowNode where  NodeNum  in (" + base.Request.QueryString["UpNodeNum"] + "0) and FlowNumber='" + base.Request.QueryString["FlowNumber"] + "' order by NodeNum asc";
                if (!base.IsPostBack)
                {
                    this.list.Bind_DropDownList_nothing1(this.FormName, sQL, "id", "NodeName");
                }
                if (this.FormName.Items.Count > 0)
                {
                    this.FormName.Items[0].Selected = true;
                }
                this.BindLb(this.FormName.SelectedValue);
                this.ViewState["ZjBLrealname"] = "";
                string str4 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' order by id asc" });
                SqlDataReader reader2 = this.List.GetList(str4);
                while (reader2.Read())
                {
                    StateBag bag = ViewState;
                    object obj2 = bag["ZjBLrealname"];
                    (bag = this.ViewState)["ZjBLrealname"] = string.Concat(new object[] { obj2, "", reader2["BLrealname"], "(", reader2["States"], ")，" });
                }
                reader2.Close();
                string str5 = string.Concat(new object[] { "select  IfZb from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and BLusername='", this.Session["username"], "' and GlNum='", this.GlNum1.Text, "' " });
                SqlDataReader reader3 = this.List.GetList(str5);
                if (reader3.Read())
                {
                    this.ViewState["IfZb"] = reader3["IfZb"].ToString();
                }
                reader3.Close();
            }
        }
    }
}


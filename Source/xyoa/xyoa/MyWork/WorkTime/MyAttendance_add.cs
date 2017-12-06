﻿namespace xyoa.MyWork.WorkTime
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAttendance_add : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected HtmlInputButton Button4;
        protected TextBox DiffTime;
        protected DropDownList DropDownList1;
        protected TextBox EndTime;
        protected HtmlForm form1;
        protected DropDownList FormId;
        protected RadioButtonList FormName;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected HtmlInputHidden NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Panel PWorkFlowQy;
        protected TextBox Realname;
        protected TextBox StartTime;
        protected TextBox Subject;
        protected TextBox TDiffTime;
        protected TextBox WorkFlowQy;
        protected TextBox Yijian;
        protected HtmlInputHidden YjbNodeId;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.Realname.Attributes.Add("readonly", "readonly");
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindLb(string str)
        {
            string sql = "select XrGuize,ZbUsername,ZbRealname,XiugaiZb from qp_Pro_WorkFlowNode where id='" + str + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["XrGuize"].ToString() == "1")
                {
                    this.ZbUsername.Text = "";
                    this.ZbRealname.Text = "";
                }
                else if (list["XrGuize"].ToString() == "2")
                {
                    this.ZbUsername.Text = "" + this.Session["Username"].ToString() + ",";
                    this.ZbRealname.Text = "" + this.Session["Realname"].ToString() + ",";
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
            list.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random random;
            string str;
            string str2;
            string str3;
            if (this.WorkFlowQy.Text == "1")
            {
                if (this.FormName.Items.Count < 1)
                {
                    base.Response.Write("<script language=javascript>alert('操作失败,未找到转交步骤！');</script>");
                }
                else if (this.ZbRealname.Text != "")
                {
                    random = new Random();
                    str = random.Next(0xf4240).ToString();
                    str2 = random.Next(0x989680).ToString();
                    this.pulicss.SpInsertLog(this.NodeName.Value, this.Number.Text, this.Yijian.Text, this.Session["username"].ToString(), this.Session["realname"].ToString(), "3", str2, "2", DateTime.Now.ToString(), "1");
                    this.pulicss.SpInsertLog(this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), this.Number.Text, "", this.ZbUsername.Text, this.ZbRealname.Text, "1", str, "1", "", "1");
                    str3 = "insert into qp_hr_MyAttendance (FormId,Number,DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,Type,Subject,StartTime,EndTime,DiffTime,Username,Realname,NowTimes,Beizhu) values ('" + this.FormId.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.ZbUsername.Text + "','" + this.ZbRealname.Text + "','1','','" + str + "','" + this.FormName.SelectedValue + "','" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "','" + this.YjbNodeId.Value + ",','" + this.YjbNodeId.Value + "','" + base.Request.QueryString["type"].ToString() + "','" + this.pulicss.GetFormatStr(this.Subject.Text) + "','" + this.pulicss.GetFormatStr(this.StartTime.Text) + "','" + this.EndTime.Text + "','" + this.pulicss.GetFormatStr(this.DiffTime.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "')";
                    this.List.ExeSql(str3);
                    string sql = "select username,realname from qp_oa_Username where  CHARINDEX(','+username+',','," + this.ZbUsername.Text + ",')   >0 ";
                    SqlDataReader list = this.List.GetList(sql);
                    while (list.Read())
                    {
                        this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的", this.ViewState["typename"], "需要审批，事由：", this.Subject.Text, "，申请人：", this.Session["realname"], "" }), list["username"].ToString(), list["realname"].ToString(), "/HumanResources/WorkTime/MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
                    }
                    list.Close();
                    this.pulicss.InsertLog("新增" + this.ViewState["typename"] + "", "个人考勤");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "'</script>");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('操作失败,未找到转交对象！');</script>");
                }
            }
            else
            {
                random = new Random();
                str = random.Next(0xf4240).ToString();
                str2 = random.Next(0x989680).ToString();
                this.pulicss.SpInsertLog(this.NodeName.Value, this.Number.Text, this.Yijian.Text, this.Session["username"].ToString(), this.Session["realname"].ToString(), "3", str2, "2", DateTime.Now.ToString(), "1");
                str3 = "insert into qp_hr_MyAttendance (FormId,Number,DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,Type,Subject,StartTime,EndTime,DiffTime,Username,Realname,NowTimes,Beizhu) values ('" + this.FormId.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.ZbUsername.Text + "','" + this.ZbRealname.Text + "','1','','" + str + "','" + this.FormName.SelectedValue + "','" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "','" + this.YjbNodeId.Value + ",','" + this.YjbNodeId.Value + "','" + base.Request.QueryString["type"].ToString() + "','" + this.pulicss.GetFormatStr(this.Subject.Text) + "','" + this.pulicss.GetFormatStr(this.StartTime.Text) + "','" + this.EndTime.Text + "','" + this.pulicss.GetFormatStr(this.DiffTime.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "')";
                this.List.ExeSql(str3);
                string str5 = string.Concat(new object[] { "Update qp_hr_MyAttendance  Set  DqNodeId='',DqBlUsername='已结束',DqBlXinming='已结束',LcZhuangtai='3',YjbUser=YjbUser+'", this.Session["username"], ",',GlNum='", str2, "',YjbNodeId=YjbNodeId+'", this.YjbNodeId.Value, ",',DqNodeName='已结束',SNodeId='", this.YjbNodeId.Value, "' where Number='", this.Number.Text, "' " });
                this.List.ExeSql(str5);
                this.pulicss.InsertLog("新增" + this.ViewState["typename"] + "", "个人考勤");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "'</script>");
            }
        }

        public void DataBindBuzhou(string str)
        {
            string sql = "select id,UpNodeNum,NodeName from qp_Pro_WorkFlowNode where  NodeSite='1' and FormId='" + str + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.YjbNodeId.Value = list["id"].ToString();
                this.ViewState["DqNodeId"] = list["id"].ToString();
                this.NodeName.Value = list["NodeName"].ToString();
                this.ViewState["DqNodeName"] = list["NodeName"].ToString();
                string sQL = string.Concat(new object[] { "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+NodeName as NodeName  from qp_Pro_WorkFlowNode where NodeNum  in (", list["UpNodeNum"], "0) and FormId='", str, "' order by NodeNum asc" });
                this.list.Bind_DropDownList_nothing1(this.FormName, sQL, "id", "NodeName");
            }
            list.Close();
            if (this.FormName.Items.Count > 0)
            {
                this.FormName.Items[0].Selected = true;
            }
            this.BindLb(this.FormName.SelectedValue);
        }

        protected void FormId_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindBuzhou(this.FormId.SelectedValue);
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
                string str2;
                string str3;
                SqlDataReader list;
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                if (base.Request.QueryString["type"].ToString() == "1")
                {
                    this.ViewState["typename"] = "出差管理";
                    this.ViewState["diffname"] = "出差天数";
                    this.TDiffTime.Text = "出差天数";
                    str2 = string.Concat(new object[] { "select id,Name from qp_pro_WorkFlow where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') and FormId='16'" });
                    this.list.Bind_DropDownList_nothing(this.FormId, str2, "id", "Name");
                    str3 = "select * from qp_pro_WorkFlowQy  where FormId='16'  ";
                    list = this.List.GetList(str3);
                    if (list.Read())
                    {
                        this.WorkFlowQy.Text = list["Zhuangtai"].ToString();
                    }
                    list.Close();
                    if (this.WorkFlowQy.Text == "1")
                    {
                        this.PWorkFlowQy.Visible = true;
                    }
                    else
                    {
                        this.PWorkFlowQy.Visible = false;
                    }
                }
                if (base.Request.QueryString["type"].ToString() == "2")
                {
                    this.ViewState["typename"] = "休假管理";
                    this.ViewState["diffname"] = "休假天数";
                    this.TDiffTime.Text = "休假天数";
                    str2 = string.Concat(new object[] { "select id,Name from qp_pro_WorkFlow where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') and FormId='17'" });
                    this.list.Bind_DropDownList_nothing(this.FormId, str2, "id", "Name");
                    str3 = "select * from qp_pro_WorkFlowQy  where FormId='17'  ";
                    list = this.List.GetList(str3);
                    if (list.Read())
                    {
                        this.WorkFlowQy.Text = list["Zhuangtai"].ToString();
                    }
                    list.Close();
                    if (this.WorkFlowQy.Text == "1")
                    {
                        this.PWorkFlowQy.Visible = true;
                    }
                    else
                    {
                        this.PWorkFlowQy.Visible = false;
                    }
                }
                if (base.Request.QueryString["type"].ToString() == "3")
                {
                    this.ViewState["typename"] = "加班管理";
                    this.ViewState["diffname"] = "加班小时";
                    this.TDiffTime.Text = "加班小时";
                    str2 = string.Concat(new object[] { "select id,Name from qp_pro_WorkFlow where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') and FormId='18'" });
                    this.list.Bind_DropDownList_nothing(this.FormId, str2, "id", "Name");
                    str3 = "select * from qp_pro_WorkFlowQy  where FormId='18'  ";
                    list = this.List.GetList(str3);
                    if (list.Read())
                    {
                        this.WorkFlowQy.Text = list["Zhuangtai"].ToString();
                    }
                    list.Close();
                    if (this.WorkFlowQy.Text == "1")
                    {
                        this.PWorkFlowQy.Visible = true;
                    }
                    else
                    {
                        this.PWorkFlowQy.Visible = false;
                    }
                }
                this.Realname.Text = this.Session["Realname"].ToString();
                string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                this.list.Bind_DropDownList(this.DropDownList1, sQL, "Content", "Content");
                this.DataBindBuzhou(this.FormId.SelectedValue);
                this.BindAttribute();
            }
        }
    }
}


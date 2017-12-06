namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Faqi_add : Page
    {
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected HtmlInputButton Button9;
        protected DropDownList DropDownList1;
        protected TextBox Endtime;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected DropDownList FormId;
        protected RadioButtonList FormName;
        protected HtmlHead Head1;
        protected TextBox Introduction;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MettingName;
        protected TextBox Name;
        protected TextBox NbPeopleName;
        protected TextBox NbPeopleUser;
        protected HtmlInputHidden NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Panel PWorkFlowQy;
        protected TextBox Remark;
        protected TextBox Starttime;
        protected HtmlInputFile uploadFile;
        protected TextBox WbPeople;
        protected TextBox WorkFlowQy;
        protected TextBox Yijian;
        protected HtmlInputHidden YjbNodeId;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.NbPeopleName.Attributes.Add("readonly", "readonly");
            this.Button6.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
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
                    this.Button9.Visible = false;
                }
                else
                {
                    this.Button9.Visible = true;
                }
            }
            list.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Faqi.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
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
                    this.pulicss.Insertfile(fileName, "OfficeMenu/Metting/file/" + str2 + "", this.Number.Text, filetype);
                    this.BindFjlbList();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
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
                    str3 = string.Concat(new object[] { 
                        "insert into qp_oa_MettingApply (FormId,Number,DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,Name,Introduction,WbPeople,NbPeopleUser,NbPeopleName,MettingId,MettingName,CjUsername,CjRealname,Starttime,Endtime,State,Remark,Username,Realname,NowTimes) values ('", this.FormId.SelectedValue, "','", this.pulicss.GetFormatStr(this.Number.Text), "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','1','','", str, "','", this.FormName.SelectedValue, "','", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "','", this.YjbNodeId.Value, 
                        ",','", this.YjbNodeId.Value, "','", this.pulicss.GetFormatStr(this.Name.Text), "','", this.pulicss.GetFormatStr(this.Introduction.Text), "','", this.pulicss.GetFormatStr(this.WbPeople.Text), "','", this.pulicss.GetFormatStr(this.NbPeopleUser.Text), "','", this.pulicss.GetFormatStr(this.NbPeopleName.Text), "','", this.MettingName.SelectedValue, "','", this.MettingName.SelectedItem.Text, 
                        "','','','", this.pulicss.GetFormatStr(this.Starttime.Text), "','", this.Endtime.Text, "','1','", this.pulicss.GetFormatStr(this.Remark.Text), "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToShortDateString(), "')"
                     });
                    this.List.ExeSql(str3);
                    string sql = "select username,realname from qp_oa_Username where  CHARINDEX(','+username+',','," + this.ZbUsername.Text + ",')   >0 ";
                    SqlDataReader list = this.List.GetList(sql);
                    while (list.Read())
                    {
                        this.pulicss.InsertMessage("您有会议需要审批，会议名称：" + this.Name.Text + "", list["username"].ToString(), list["realname"].ToString(), "/OfficeMenu/Metting/MettingApply_sp.aspx");
                    }
                    list.Close();
                    this.pulicss.InsertLog("新增会议[" + this.Name.Text + "]", "会议申请");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Faqi.aspx'</script>");
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
                str3 = string.Concat(new object[] { 
                    "insert into qp_oa_MettingApply (FormId,Number,DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,Name,Introduction,WbPeople,NbPeopleUser,NbPeopleName,MettingId,MettingName,CjUsername,CjRealname,Starttime,Endtime,State,Remark,Username,Realname,NowTimes) values ('", this.FormId.SelectedValue, "','", this.pulicss.GetFormatStr(this.Number.Text), "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','1','','", str, "','", this.FormName.SelectedValue, "','", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "','", this.YjbNodeId.Value, 
                    ",','", this.YjbNodeId.Value, "','", this.pulicss.GetFormatStr(this.Name.Text), "','", this.pulicss.GetFormatStr(this.Introduction.Text), "','", this.pulicss.GetFormatStr(this.WbPeople.Text), "','", this.pulicss.GetFormatStr(this.NbPeopleUser.Text), "','", this.pulicss.GetFormatStr(this.NbPeopleName.Text), "','", this.MettingName.SelectedValue, "','", this.MettingName.SelectedItem.Text, 
                    "','','','", this.pulicss.GetFormatStr(this.Starttime.Text), "','", this.Endtime.Text, "','1','", this.pulicss.GetFormatStr(this.Remark.Text), "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToShortDateString(), "')"
                 });
                this.List.ExeSql(str3);
                string str5 = string.Concat(new object[] { "Update qp_oa_MettingApply  Set  State='6',DqNodeId='',DqBlUsername='已结束',DqBlXinming='已结束',LcZhuangtai='3',YjbUser=YjbUser+'", this.Session["username"], ",',GlNum='", str2, "',YjbNodeId=YjbNodeId+'", this.YjbNodeId.Value, ",',DqNodeName='已结束',SNodeId='", this.YjbNodeId.Value, "' where Number='", this.pulicss.GetFormatStr(this.Number.Text), "'  " });
                this.List.ExeSql(str5);
                this.pulicss.InsertLog("新增会议[" + this.Name.Text + "]", "会议申请");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Faqi.aspx'</script>");
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
            else
            {
                if (!this.Page.IsPostBack)
                {
                    string sql = "select * from qp_pro_WorkFlowQy  where FormId='8'  ";
                    SqlDataReader list = this.List.GetList(sql);
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
                    string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                    this.list.Bind_DropDownList(this.DropDownList1, sQL, "Content", "Content");
                    string str3 = "select id,name  from qp_oa_MettingHouse order by id asc";
                    this.list.Bind_DropDownList_nothing(this.MettingName, str3, "id", "name");
                    string str4 = string.Concat(new object[] { "select id,Name from qp_pro_WorkFlow where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') and FormId='8'" });
                    this.list.Bind_DropDownList_nothing(this.FormId, str4, "id", "Name");
                    Random random = new Random();
                    string str5 = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str5 + "";
                    this.DataBindBuzhou(this.FormId.SelectedValue);
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}


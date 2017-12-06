namespace xyoa.Resources.ResSet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyResApply_showJy : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlInputButton Button9;
        protected Label Cangku;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected DropDownList FormId;
        protected RadioButtonList FormName;
        protected HtmlHead Head1;
        protected Label KuCun;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Liyou;
        protected HtmlInputHidden NodeName;
        protected DropDownList normalcontent;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Panel PWorkFlowQy;
        protected Label Quyu;
        protected TextBox Shuliang;
        protected TextBox Starttime;
        protected TextBox WorkFlowQy;
        protected Label Xinghao;
        protected TextBox Yijian;
        protected HtmlInputHidden YjbNodeId;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;
        protected TextBox ZyId;
        protected Label ZyIntro;
        protected Label ZyName;
        protected Label ZyNum;

        public void BindAttribute()
        {
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        public void BindDroList()
        {
            string sql = "select * from qp_oa_ResourcesAdd  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ZyNum.Text = list["ZyNum"].ToString();
                this.Xinghao.Text = list["Xinghao"].ToString();
                this.ZyId.Text = list["id"].ToString();
                this.ZyName.Text = list["ZyName"].ToString();
                this.ZyIntro.Text = this.pulicss.TbToLb(list["ZyIntro"].ToString());
                this.KuCun.Text = list["KuCun"].ToString();
                this.Cangku.Text = this.pulicss.TypeCode("qp_oa_ResourcesCangku", list["Cangku"].ToString());
                this.Quyu.Text = this.pulicss.TypeCode("qp_oa_ResourcesQuyu", list["Quyu"].ToString());
            }
            list.Close();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            decimal num;
            decimal num2;
            Random random;
            string str;
            string str2;
            string str3;
            if (this.WorkFlowQy.Text == "1")
            {
                num = decimal.Parse(this.KuCun.Text);
                num2 = decimal.Parse(this.Shuliang.Text);
                if (num2 > num)
                {
                    base.Response.Write(string.Concat(new object[] { "<script language=javascript>alert('提交失败，失败原因：申请数量(", num2, ")>已有库存(", num, ")!');</script>" }));
                }
                else if (this.FormName.Items.Count < 1)
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
                        "insert into qp_oa_ResAppJy  (FormId,Starttime,Endtime,WpStates,Number,DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,ZyId,Shuliang,Liyou,Username,Realname,NowTimes) values ('", this.FormId.SelectedValue, "','", this.Starttime.Text, "','", this.Endtime.Text, "','1','", this.Number.Text, "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','1','','", str, "','", this.FormName.SelectedValue, 
                        "','", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "','", this.YjbNodeId.Value, ",','", this.YjbNodeId.Value, "','", this.pulicss.GetFormatStr(this.ZyId.Text), "','", this.pulicss.GetFormatStr(this.Shuliang.Text), "','", this.pulicss.GetFormatStr(this.Liyou.Text), "','", this.Session["username"], "','", this.Session["realname"], 
                        "','", DateTime.Now.ToString(), "')"
                     });
                    this.List.ExeSql(str3);
                    string sql = "select username,realname from qp_oa_Username where  CHARINDEX(','+username+',','," + this.ZbUsername.Text + ",')   >0 ";
                    SqlDataReader list = this.List.GetList(sql);
                    while (list.Read())
                    {
                        this.pulicss.InsertMessage("您有物品借用需要审批，对应物品[" + this.ZyName.Text + "]", list["username"].ToString(), list["realname"].ToString(), "/Resources/ResMg/MyResJyApply.aspx");
                    }
                    list.Close();
                    this.pulicss.InsertLog("申请借用物品[" + this.ZyName.Text + "]", "物品申请");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.parent.location.href='MyResJy.aspx'</script>");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('操作失败,未找到转交对象！');</script>");
                }
            }
            else
            {
                num = decimal.Parse(this.KuCun.Text);
                num2 = decimal.Parse(this.Shuliang.Text);
                if (num2 > num)
                {
                    base.Response.Write(string.Concat(new object[] { "<script language=javascript>alert('提交失败，失败原因：申请数量(", num2, ")>已有库存(", num, ")!');</script>" }));
                }
                else if (this.FormName.Items.Count < 1)
                {
                    base.Response.Write("<script language=javascript>alert('操作失败,未找到转交步骤！');</script>");
                }
                else
                {
                    random = new Random();
                    str = random.Next(0xf4240).ToString();
                    str2 = random.Next(0x989680).ToString();
                    this.pulicss.SpInsertLog(this.NodeName.Value, this.Number.Text, this.Yijian.Text, this.Session["username"].ToString(), this.Session["realname"].ToString(), "3", str2, "2", DateTime.Now.ToString(), "1");
                    str3 = string.Concat(new object[] { 
                        "insert into qp_oa_ResAppJy  (FormId,Starttime,Endtime,WpStates,Number,DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,ZyId,Shuliang,Liyou,Username,Realname,NowTimes) values ('", this.FormId.SelectedValue, "','", this.Starttime.Text, "','", this.Endtime.Text, "','1','", this.Number.Text, "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','1','','", str, "','", this.FormName.SelectedValue, 
                        "','", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "','", this.YjbNodeId.Value, ",','", this.YjbNodeId.Value, "','", this.pulicss.GetFormatStr(this.ZyId.Text), "','", this.pulicss.GetFormatStr(this.Shuliang.Text), "','", this.pulicss.GetFormatStr(this.Liyou.Text), "','", this.Session["username"], "','", this.Session["realname"], 
                        "','", DateTime.Now.ToString(), "')"
                     });
                    this.List.ExeSql(str3);
                    string str5 = string.Concat(new object[] { "Update qp_oa_ResAppJy  Set  WpStates='2',DqNodeId='',DqBlUsername='已结束',DqBlXinming='已结束',LcZhuangtai='3',YjbUser=YjbUser+'", this.Session["username"], ",',GlNum='", str2, "',YjbNodeId=YjbNodeId+'", this.YjbNodeId.Value, ",',DqNodeName='已结束',SNodeId='", this.YjbNodeId.Value, "' where Number='", this.Number.Text, "'  " });
                    this.List.ExeSql(str5);
                    string str6 = "Update qp_oa_ResourcesAdd    Set KuCun=KuCun-" + this.Shuliang.Text + " where id='" + this.ZyId.Text + "'";
                    this.List.ExeSql(str6);
                    string str7 = string.Concat(new object[] { "insert into qp_oa_MyRes  (ZyId,shuliang,Laiyuan,KeyId,Username,Realname,Settime) values ('", this.pulicss.GetFormatStr(this.ZyId.Text), "','", this.Shuliang.Text, "','借用','", base.Request.QueryString["id"], "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                    this.List.ExeSql(str7);
                    this.pulicss.InsertLog("申请借用物品[" + this.ZyName.Text + "]", "物品申请");
                    base.Response.Write("<script language=javascript>alert('提交成功！');window.parent.location.href='MyResJy.aspx'</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyResApply_show.aspx?id=" + base.Request.QueryString["id"] + "");
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
                string sql = "select * from qp_pro_WorkFlowQy  where FormId='13'  ";
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
                Random random = new Random();
                string str2 = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str2 + "";
                string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
                string str4 = string.Concat(new object[] { "select id,Name from qp_pro_WorkFlow where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') and FormId='13'" });
                this.list.Bind_DropDownList_nothing(this.FormId, str4, "id", "Name");
                this.DataBindBuzhou(this.FormId.SelectedValue);
                this.BindDroList();
                this.BindAttribute();
            }
        }
    }
}


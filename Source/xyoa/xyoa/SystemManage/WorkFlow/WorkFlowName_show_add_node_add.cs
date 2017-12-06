namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_node_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected DropDownList Chuanyue;
        protected TextBox FlowId;
        protected TextBox FlowName;
        protected TextBox FlowNumber;
        protected HtmlForm form1;
        protected TextBox FormId;
        protected TextBox FormName;
        protected TextBox FormNumber;
        protected DropDownList GlGuize;
        protected HtmlHead Head1;
        protected TextBox JbGuanlianID;
        protected TextBox JbGuanlianName;
        protected DropDownList JbHuitui;
        protected CheckBoxList JbQuanxian;
        protected TextBox JbRealname;
        protected TextBox JbUsername;
        protected DropDownList JcZhuanjiao;
        protected DropDownList Jiankong;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox NodeName;
        protected TextBox NodeNum;
        protected TextBox NodeNumber;
        protected DropDownList NodeSite;
        private publics pulicss = new publics();
        protected ListBox SourceListBox;
        public string str;
        public string str1;
        public string strlist;
        public string strname;
        public string struser;
        protected ListBox TargetListBox;
        public string tqp;
        protected DropDownList WhJbSet;
        protected DropDownList WhZbSet;
        protected TextBox XbTimes;
        protected DropDownList XrGuize;
        protected DropDownList YijianJb;
        protected DropDownList YijianZb;
        protected TextBox YjRealname;
        protected TextBox YjUsername;
        protected DropDownList YjXiugai;
        protected CheckBoxList YoujianXm;
        protected TextBox ZbGuanlianID;
        protected TextBox ZbGuanlianName;
        protected DropDownList ZbHuitui;
        protected CheckBoxList ZbQuanxian;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;
        protected DropDownList ZbZhuanjiao;

        public void BindAttribute()
        {
            this.YjRealname.Attributes.Add("readonly", "readonly");
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.JbRealname.Attributes.Add("readonly", "readonly");
            this.ZbGuanlianName.Attributes.Add("readonly", "readonly");
            this.JbGuanlianName.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select  id from qp_oa_WorkFlowNode where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "' and NodeNum='" + this.NodeNum.Text + "' ";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                base.Response.Write("<script language=javascript>alert('序号重复！');</script>");
            }
            else
            {
                int num3;
                int num4;
                string str7;
                reader.Close();
                if (this.NodeSite.SelectedValue == "开始")
                {
                    string str2 = "select top 1 id from qp_oa_WorkFlowNode where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "' and NodeSite='开始' ";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        base.Response.Write("<script language=javascript>alert('“开始”步骤已经存在！');</script>");
                        return;
                    }
                    reader2.Close();
                }
                int num5 = int.Parse(this.NodeNum.Text) + 1;
                string str3 = null;
                string str4 = null;
                string str5 = "select top 1 * from qp_oa_WorkFlowNode where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "' and NodeNum<'" + this.NodeNum.Text + "' order by NodeNum desc";
                SqlDataReader reader3 = this.List.GetList(str5);
                if (reader3.Read())
                {
                    if (int.Parse(reader3["SETTOP"].ToString()) == 20)
                    {
                        num4 = 200;
                    }
                    else
                    {
                        num4 = 20;
                    }
                    if ((int.Parse(reader3["NodeNum"].ToString()) % 2) == 0)
                    {
                        num3 = int.Parse(reader3["SETLEFT"].ToString()) + 180;
                    }
                    else
                    {
                        num3 = int.Parse(reader3["SETLEFT"].ToString());
                    }
                }
                else
                {
                    num3 = 20;
                    num4 = 20;
                }
                reader3.Close();
                if (this.TargetListBox.Items.Count > 0)
                {
                    for (int i = 0; i <= (this.TargetListBox.Items.Count - 1); i++)
                    {
                        this.str = "" + this.TargetListBox.Items[i].Value + ",";
                        this.tqp = this.str.Remove(this.str.LastIndexOf(","), 1);
                        ArrayList list = new ArrayList();
                        string[] strArray = this.tqp.Split(new char[] { ',' });
                        for (int j = 0; j < strArray.Length; j++)
                        {
                            list.Add(strArray[j].ToString());
                            str3 = "<vml:line title=\"\" style=\"DISPLAY: none; Z-INDEX: 2; POSITION: absolute\" to=\"0,0\" from=\"0,0\" coordsize=\"21600,21600\" arcsize=\"4321f\" object=\"" + strArray[j] + "\" source=\"" + this.NodeNum.Text + "\" mfrID=\"" + this.NodeNum.Text + "\"><vml:stroke endarrow=\"block\"></vml:stroke><vml:shadow offset=\"1px,1px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow></vml:line>";
                            string str6 = "insert into qp_oa_WorkFlowNodeLine (Source,Object,LineContent,NodeNumber,FlowNumber) values ('" + this.NodeNum.Text + "','" + strArray[j] + "','" + str3 + "','" + this.pulicss.GetFormatStr(this.NodeNumber.Text) + "','" + this.pulicss.GetFormatStr(this.FlowNumber.Text) + "')";
                            this.List.ExeSql(str6);
                            str4 = str4 + "" + strArray[j] + ",";
                        }
                    }
                    str7 = string.Concat(new object[] { 
                        "insert into qp_oa_WorkFlowNode (YjXiugai,Chuanyue,YjUsername,YjRealname,YoujianXm,Jiankong,ZbGuanlianID,ZbGuanlianName,JbGuanlianID,JbGuanlianName,XbTimes,YijianZb,YijianJb,WhJbSet,WhZbSet,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,SETLEFT,SETTOP,GlGuize,XrGuize,JcZhuanjiao,ZbZhuanjiao,ZbHuitui,JbHuitui,ZbQuanxian,JbQuanxian,ZbUsername,ZbRealname,JbUsername,JbRealname,UpNodeNum,NodeSite,WriteFileID,WriteFileName,SecFileID,SecFileName) values ('", this.YjXiugai.SelectedValue, "','", this.Chuanyue.SelectedValue, "','", this.YjUsername.Text, "','", this.YjRealname.Text, "','", this.pulicss.GetChecked(this.YoujianXm), "','", this.Jiankong.SelectedValue, "','", this.ZbGuanlianID.Text, "','", this.ZbGuanlianName.Text, 
                        "','", this.JbGuanlianID.Text, "','", this.JbGuanlianName.Text, "','", this.XbTimes.Text, "','", this.YijianZb.SelectedValue, "','", this.YijianJb.SelectedValue, "','", this.WhJbSet.SelectedValue, "','", this.WhZbSet.SelectedValue, "','", this.FormId.Text, 
                        "','", this.FormNumber.Text, "','", this.pulicss.GetFormatStr(this.FormName.Text), "','", this.pulicss.GetFormatStr(this.FlowId.Text), "','", this.pulicss.GetFormatStr(this.FlowNumber.Text), "','", this.pulicss.GetFormatStr(this.FlowName.Text), "','", this.pulicss.GetFormatStr(this.NodeNumber.Text), "','", this.pulicss.GetFormatStr(this.NodeNum.Text), "','", this.pulicss.GetFormatStr(this.NodeName.Text), 
                        "','", num3, "','", num4, "','", this.GlGuize.SelectedValue, "','", this.XrGuize.SelectedValue, "','", this.JcZhuanjiao.SelectedValue, "','", this.ZbZhuanjiao.SelectedValue, "','", this.ZbHuitui.SelectedValue, "','", this.JbHuitui.SelectedValue, 
                        "','", this.pulicss.GetChecked(this.ZbQuanxian), "','", this.pulicss.GetChecked(this.JbQuanxian), "','", this.pulicss.GetFormatStr(this.ZbUsername.Text), "','", this.pulicss.GetFormatStr(this.ZbRealname.Text), "','", this.pulicss.GetFormatStr(this.JbUsername.Text), "','", this.pulicss.GetFormatStr(this.JbRealname.Text), "','", str4, "','", this.NodeSite.SelectedValue, 
                        "','','','','')"
                     });
                    this.List.ExeSql(str7);
                }
                else
                {
                    str7 = string.Concat(new object[] { 
                        "insert into qp_oa_WorkFlowNode (YjXiugai,Chuanyue,YjUsername,YjRealname,YoujianXm,Jiankong,ZbGuanlianID,ZbGuanlianName,JbGuanlianID,JbGuanlianName,XbTimes,YijianZb,YijianJb,WhJbSet,WhZbSet,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,SETLEFT,SETTOP,GlGuize,XrGuize,JcZhuanjiao,ZbZhuanjiao,ZbHuitui,JbHuitui,ZbQuanxian,JbQuanxian,ZbUsername,ZbRealname,JbUsername,JbRealname,UpNodeNum,NodeSite,WriteFileID,WriteFileName,SecFileID,SecFileName) values ('", this.YjXiugai.SelectedValue, "','", this.Chuanyue.SelectedValue, "','", this.YjUsername.Text, "','", this.YjRealname.Text, "','", this.pulicss.GetChecked(this.YoujianXm), "','", this.Jiankong.SelectedValue, "','", this.ZbGuanlianID.Text, "','", this.ZbGuanlianName.Text, 
                        "','", this.JbGuanlianID.Text, "','", this.JbGuanlianName.Text, "','", this.XbTimes.Text, "','", this.YijianZb.SelectedValue, "','", this.YijianJb.SelectedValue, "','", this.WhJbSet.SelectedValue, "','", this.WhZbSet.SelectedValue, "','", this.FormId.Text, 
                        "','", this.FormNumber.Text, "','", this.pulicss.GetFormatStr(this.FormName.Text), "','", this.pulicss.GetFormatStr(this.FlowId.Text), "','", this.pulicss.GetFormatStr(this.FlowNumber.Text), "','", this.pulicss.GetFormatStr(this.FlowName.Text), "','", this.pulicss.GetFormatStr(this.NodeNumber.Text), "','", this.pulicss.GetFormatStr(this.NodeNum.Text), "','", this.pulicss.GetFormatStr(this.NodeName.Text), 
                        "','", num3, "','", num4, "','", this.GlGuize.SelectedValue, "','", this.XrGuize.SelectedValue, "','", this.JcZhuanjiao.SelectedValue, "','", this.ZbZhuanjiao.SelectedValue, "','", this.ZbHuitui.SelectedValue, "','", this.JbHuitui.SelectedValue, 
                        "','", this.pulicss.GetChecked(this.ZbQuanxian), "','", this.pulicss.GetChecked(this.JbQuanxian), "','", this.pulicss.GetFormatStr(this.ZbUsername.Text), "','", this.pulicss.GetFormatStr(this.ZbRealname.Text), "','", this.pulicss.GetFormatStr(this.JbUsername.Text), "','", this.pulicss.GetFormatStr(this.JbRealname.Text), "','','", this.NodeSite.SelectedValue, "','','','','')"
                     });
                    this.List.ExeSql(str7);
                }
                this.pulicss.InsertLog("新增工作流步骤[" + this.NodeName.Text + "]", "工作流步骤");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int num = 0;
            while (num <= (this.SourceListBox.Items.Count - 1))
            {
                if (this.SourceListBox.Items[num].Selected)
                {
                    if (this.TargetListBox.Items.IndexOf(this.SourceListBox.Items[num]) >= 0)
                    {
                        base.Response.Write("<script language=javascript>alert('此项已经存在！');</script>");
                        break;
                    }
                    this.TargetListBox.Items.Add(new ListItem(this.SourceListBox.Items[num].Text, this.SourceListBox.Items[num].Value));
                    this.SourceListBox.Items.Remove(this.SourceListBox.Items[num]);
                }
                else
                {
                    num++;
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int num = 0;
            while (num <= (this.TargetListBox.Items.Count - 1))
            {
                if (this.TargetListBox.Items[num].Selected)
                {
                    this.SourceListBox.Items.Add(new ListItem(this.TargetListBox.Items[num].Text, this.TargetListBox.Items[num].Value));
                    this.TargetListBox.Items.Remove(this.TargetListBox.Items[num]);
                }
                else
                {
                    num++;
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (this.SourceListBox.Items.Count > 0)
            {
                foreach (ListItem item in this.SourceListBox.Items)
                {
                    this.TargetListBox.Items.Add(item);
                }
                this.SourceListBox.Items.Clear();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (this.TargetListBox.Items.Count > 0)
            {
                foreach (ListItem item in this.TargetListBox.Items)
                {
                    this.SourceListBox.Items.Add(item);
                }
                this.TargetListBox.Items.Clear();
            }
        }

        public void DataBindToDownList()
        {
            string sQL = "select NodeNum,NodeName from qp_oa_WorkFlowNode  where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "'";
            this.list.Bind_DropDownList_ListBox(this.SourceListBox, sQL, "NodeNum", "NodeName");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select top 1 *  from qp_oa_WorkFlowNode where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "' order by NodeNum desc";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NodeSite.SelectedValue = "中间段";
                    this.NodeNum.Text = this.NodeNum.Text + (int.Parse(list["NodeNum"].ToString()) + 1);
                    this.FormId.Text = list["FormId"].ToString();
                    this.FormNumber.Text = list["FormNumber"].ToString();
                    this.FormName.Text = list["FormName"].ToString();
                    this.FlowId.Text = list["FlowId"].ToString();
                    this.FlowNumber.Text = list["FlowNumber"].ToString();
                    this.FlowName.Text = list["FlowName"].ToString();
                }
                else
                {
                    this.NodeSite.SelectedValue = "开始";
                    this.NodeNum.Text = "1";
                    string str2 = "select  *  from qp_oa_WorkFlowName where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.FormId.Text = reader2["FormId"].ToString();
                        string str3 = "select  Number,FormName  from qp_oa_DIYForm where id='" + this.FormId.Text + "'";
                        SqlDataReader reader3 = this.List.GetList(str3);
                        if (reader3.Read())
                        {
                            this.FormNumber.Text = reader3["Number"].ToString();
                            this.FormName.Text = reader3["FormName"].ToString();
                        }
                        reader3.Close();
                        this.FlowId.Text = reader2["id"].ToString();
                        this.FlowNumber.Text = reader2["FlowNumber"].ToString();
                        this.FlowName.Text = reader2["FlowName"].ToString();
                        this.GlGuize.SelectedValue = "5";
                        this.XrGuize.SelectedValue = "1";
                    }
                    reader2.Close();
                }
                list.Close();
                this.DataBindToDownList();
                this.BindAttribute();
                Random random = new Random();
                string str4 = random.Next(0x2710).ToString();
                this.NodeNumber.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str4 + "";
            }
        }
    }
}


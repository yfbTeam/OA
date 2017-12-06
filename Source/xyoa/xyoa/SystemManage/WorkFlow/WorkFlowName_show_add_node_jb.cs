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

    public class WorkFlowName_show_add_node_jb : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected DropDownList Chuanyue;
        protected TextBox FlowNumber;
        protected HtmlForm form1;
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
        protected TextBox UpNodeNum;
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
            string str = null;
            string str2 = null;
            string str5;
            string sql = " Delete from qp_oa_WorkFlowNodeLine where Source='" + this.NodeNum.Text + "' and FlowNumber='" + this.FlowNumber.Text + "'";
            this.List.ExeSql(sql);
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
                        str = "<vml:line title=\"\" style=\"DISPLAY: none; Z-INDEX: 2; POSITION: absolute\" to=\"0,0\" from=\"0,0\" coordsize=\"21600,21600\" arcsize=\"4321f\" object=\"" + strArray[j] + "\" source=\"" + this.NodeNum.Text + "\" mfrID=\"" + this.NodeNum.Text + "\"><vml:stroke endarrow=\"block\"></vml:stroke><vml:shadow offset=\"1px,1px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow></vml:line>";
                        string str4 = "insert into qp_oa_WorkFlowNodeLine (Source,Object,LineContent,NodeNumber,FlowNumber) values ('" + this.NodeNum.Text + "','" + strArray[j] + "','" + str + "','" + this.pulicss.GetFormatStr(this.NodeNumber.Text) + "','" + this.pulicss.GetFormatStr(this.FlowNumber.Text) + "')";
                        this.List.ExeSql(str4);
                        str2 = str2 + "" + strArray[j] + ",";
                    }
                }
                str5 = string.Concat(new object[] { 
                    "Update qp_oa_WorkFlowNode  Set YjXiugai='", this.YjXiugai.SelectedValue, "',Chuanyue='", this.Chuanyue.SelectedValue, "',YjRealname='", this.YjRealname.Text, "',YjUsername='", this.YjUsername.Text, "',YoujianXm='", this.pulicss.GetChecked(this.YoujianXm), "',Jiankong='", this.Jiankong.SelectedValue, "',ZbGuanlianID='", this.ZbGuanlianID.Text, "',ZbGuanlianName='", this.ZbGuanlianName.Text, 
                    "',JbGuanlianID='", this.JbGuanlianID.Text, "',JbGuanlianName='", this.JbGuanlianName.Text, "',XbTimes='", this.XbTimes.Text, "',YijianZb='", this.YijianZb.SelectedValue, "',YijianJb='", this.YijianJb.SelectedValue, "',WhJbSet='", this.WhJbSet.SelectedValue, "',WhZbSet='", this.WhZbSet.SelectedValue, "',NodeName='", this.pulicss.GetFormatStr(this.NodeName.Text), 
                    "',GlGuize='", this.GlGuize.SelectedValue, "',XrGuize='", this.XrGuize.SelectedValue, "',JcZhuanjiao='", this.JcZhuanjiao.SelectedValue, "',ZbZhuanjiao='", this.ZbZhuanjiao.SelectedValue, "',ZbHuitui='", this.ZbHuitui.SelectedValue, "',JbHuitui='", this.JbHuitui.SelectedValue, "',ZbQuanxian='", this.pulicss.GetChecked(this.ZbQuanxian), "',JbQuanxian='", this.pulicss.GetChecked(this.JbQuanxian), 
                    "',ZbUsername='", this.ZbUsername.Text, "',ZbRealname='", this.ZbRealname.Text, "',JbUsername='", this.JbUsername.Text, "',JbRealname='", this.JbRealname.Text, "',UpNodeNum='", str2, "',NodeSite='", this.NodeSite.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str5);
            }
            else
            {
                str5 = string.Concat(new object[] { 
                    "Update qp_oa_WorkFlowNode  Set  YjXiugai='", this.YjXiugai.SelectedValue, "',Chuanyue='", this.Chuanyue.SelectedValue, "',YjRealname='", this.YjRealname.Text, "',YjUsername='", this.YjUsername.Text, "',YoujianXm='", this.pulicss.GetChecked(this.YoujianXm), "',Jiankong='", this.Jiankong.SelectedValue, "',ZbGuanlianID='", this.ZbGuanlianID.Text, "',ZbGuanlianName='", this.ZbGuanlianName.Text, 
                    "',JbGuanlianID='", this.JbGuanlianID.Text, "',JbGuanlianName='", this.JbGuanlianName.Text, "',XbTimes='", this.XbTimes.Text, "',YijianZb='", this.YijianZb.SelectedValue, "',YijianJb='", this.YijianJb.SelectedValue, "',WhJbSet='", this.WhJbSet.SelectedValue, "',WhZbSet='", this.WhZbSet.SelectedValue, "',NodeName='", this.pulicss.GetFormatStr(this.NodeName.Text), 
                    "',GlGuize='", this.GlGuize.SelectedValue, "',XrGuize='", this.XrGuize.SelectedValue, "',JcZhuanjiao='", this.JcZhuanjiao.SelectedValue, "',ZbZhuanjiao='", this.ZbZhuanjiao.SelectedValue, "',ZbHuitui='", this.ZbHuitui.SelectedValue, "',JbHuitui='", this.JbHuitui.SelectedValue, "',ZbQuanxian='", this.pulicss.GetChecked(this.ZbQuanxian), "',JbQuanxian='", this.pulicss.GetChecked(this.JbQuanxian), 
                    "',ZbUsername='", this.ZbUsername.Text, "',ZbRealname='", this.ZbRealname.Text, "',JbUsername='", this.JbUsername.Text, "',JbRealname='", this.JbRealname.Text, "',UpNodeNum='',NodeSite='", this.NodeSite.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str5);
            }
            this.pulicss.InsertLog("修改工作流步骤[" + this.NodeName.Text + "]", "工作流步骤");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
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
            string str = null;
            string str2 = null;
            str2 = "" + this.UpNodeNum.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + "'" + strArray[i] + "',";
            }
            str = str + "'0'";
            string sQL = "select NodeNum,NodeName from qp_oa_WorkFlowNode   where  NodeNum in (" + str + ")  and FlowNumber='" + this.FlowNumber.Text + "'";
            this.list.Bind_DropDownList_ListBox(this.TargetListBox, sQL, "NodeNum", "NodeName");
            string str4 = "select NodeNum,NodeName from qp_oa_WorkFlowNode   where  NodeNum not in (" + str + ") and FlowNumber='" + this.FlowNumber.Text + "'";
            this.list.Bind_DropDownList_ListBox(this.SourceListBox, str4, "NodeNum", "NodeName");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select  *  from qp_oa_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Jiankong.SelectedValue = list["Jiankong"].ToString();
                    this.UpNodeNum.Text = list["UpNodeNum"].ToString();
                    this.XbTimes.Text = list["XbTimes"].ToString();
                    this.FlowNumber.Text = list["FlowNumber"].ToString();
                    this.NodeNumber.Text = list["NodeNumber"].ToString();
                    this.NodeNum.Text = list["NodeNum"].ToString();
                    this.NodeName.Text = list["NodeName"].ToString();
                    this.GlGuize.SelectedValue = list["GlGuize"].ToString();
                    this.XrGuize.SelectedValue = list["XrGuize"].ToString();
                    this.JcZhuanjiao.SelectedValue = list["JcZhuanjiao"].ToString();
                    this.ZbZhuanjiao.SelectedValue = list["ZbZhuanjiao"].ToString();
                    this.ZbHuitui.SelectedValue = list["ZbHuitui"].ToString();
                    this.JbHuitui.SelectedValue = list["JbHuitui"].ToString();
                    this.pulicss.SetChecked(this.ZbQuanxian, "," + list["ZbQuanxian"].ToString() + ",");
                    this.pulicss.SetChecked(this.JbQuanxian, "," + list["JbQuanxian"].ToString() + ",");
                    this.ZbUsername.Text = list["ZbUsername"].ToString();
                    this.ZbRealname.Text = list["ZbRealname"].ToString();
                    this.JbUsername.Text = list["JbUsername"].ToString();
                    this.JbRealname.Text = list["JbRealname"].ToString();
                    this.NodeSite.SelectedValue = list["NodeSite"].ToString();
                    this.WhZbSet.SelectedValue = list["WhZbSet"].ToString();
                    this.WhJbSet.SelectedValue = list["WhJbSet"].ToString();
                    this.YijianZb.SelectedValue = list["YijianZb"].ToString();
                    this.YijianJb.SelectedValue = list["YijianJb"].ToString();
                    this.ZbGuanlianID.Text = list["ZbGuanlianID"].ToString();
                    this.ZbGuanlianName.Text = list["ZbGuanlianName"].ToString();
                    this.JbGuanlianID.Text = list["JbGuanlianID"].ToString();
                    this.JbGuanlianName.Text = list["JbGuanlianName"].ToString();
                    this.Chuanyue.SelectedValue = list["Chuanyue"].ToString();
                    this.YjRealname.Text = list["YjRealname"].ToString();
                    this.YjUsername.Text = list["YjUsername"].ToString();
                    this.pulicss.SetChecked(this.YoujianXm, "," + list["YoujianXm"].ToString() + ",");
                    this.YjXiugai.SelectedValue = list["YjXiugai"].ToString();
                }
                list.Close();
                this.BindAttribute();
                this.DataBindToDownList();
            }
        }
    }
}


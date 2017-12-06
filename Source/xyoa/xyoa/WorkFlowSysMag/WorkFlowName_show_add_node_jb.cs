namespace xyoa.WorkFlowSysMag
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
        protected HtmlForm form1;
        protected TextBox FormId;
        protected HtmlHead Head1;
        protected DropDownList Huitui;
        protected DropDownList JbZhuangjiao;
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
        protected DropDownList XiugaiZb;
        protected DropDownList XrGuize;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.NodeNum.Attributes.Add("readonly", "readonly");
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            string str5;
            string sql = " Delete from qp_Pro_WorkFlowNodeLine where Source='" + this.NodeNum.Text + "' and FormId='" + this.FormId.Text + "'";
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
                        string str4 = "insert into qp_Pro_WorkFlowNodeLine (Source,Object,LineContent,NodeNumber,FormId) values ('" + this.NodeNum.Text + "','" + strArray[j] + "','" + str + "','" + this.pulicss.GetFormatStr(this.NodeNumber.Text) + "','" + this.FormId.Text + "')";
                        this.List.ExeSql(str4);
                        str2 = str2 + "" + strArray[j] + ",";
                    }
                }
                str5 = string.Concat(new object[] { 
                    "Update qp_Pro_WorkFlowNode  Set JbZhuangjiao='", this.JbZhuangjiao.SelectedValue, "',XrGuize='", this.XrGuize.SelectedValue, "',XiugaiZb='", this.XiugaiZb.SelectedValue, "',NodeName='", this.NodeName.Text, "',ZbUsername='", this.ZbUsername.Text, "',ZbRealname='", this.ZbRealname.Text, "',UpNodeNum='", str2, "',NodeSite='", this.NodeSite.SelectedValue, 
                    "',Huitui='", this.Huitui.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str5);
            }
            else
            {
                str5 = string.Concat(new object[] { 
                    "Update qp_Pro_WorkFlowNode  Set JbZhuangjiao='", this.JbZhuangjiao.SelectedValue, "',XrGuize='", this.XrGuize.SelectedValue, "',XiugaiZb='", this.XiugaiZb.SelectedValue, "',NodeName='", this.NodeName.Text, "',ZbUsername='", this.ZbUsername.Text, "',ZbRealname='", this.ZbRealname.Text, "',NodeSite='", this.NodeSite.SelectedValue, "',Huitui='", this.Huitui.SelectedValue, 
                    "'  where id='", int.Parse(base.Request.QueryString["id"]), "'"
                 });
                this.List.ExeSql(str5);
            }
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
            string sQL = "select NodeNum,NodeName from qp_Pro_WorkFlowNode   where  NodeNum in (" + str + ")  and FormId='" + this.FormId.Text + "'";
            this.list.Bind_DropDownList_ListBox(this.TargetListBox, sQL, "NodeNum", "NodeName");
            string str4 = "select NodeNum,NodeName from qp_Pro_WorkFlowNode   where  NodeNum not in (" + str + ") and FormId='" + this.FormId.Text + "' and id!='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
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
                string sql = "select  *  from qp_Pro_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NodeNum.Text = list["NodeNum"].ToString();
                    this.FormId.Text = list["FormId"].ToString();
                    this.UpNodeNum.Text = list["UpNodeNum"].ToString();
                    this.NodeNumber.Text = list["NodeNumber"].ToString();
                    this.NodeName.Text = list["NodeName"].ToString();
                    this.NodeSite.SelectedValue = list["NodeSite"].ToString();
                    this.ZbUsername.Text = list["ZbUsername"].ToString();
                    this.ZbRealname.Text = list["ZbRealname"].ToString();
                    this.Huitui.SelectedValue = list["Huitui"].ToString();
                    this.XiugaiZb.SelectedValue = list["XiugaiZb"].ToString();
                    this.XrGuize.SelectedValue = list["XrGuize"].ToString();
                    this.JbZhuangjiao.SelectedValue = list["JbZhuangjiao"].ToString();
                }
                list.Close();
                this.BindAttribute();
                this.DataBindToDownList();
            }
        }
    }
}


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

    public class WorkFlowName_show_add_node_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected HtmlForm form1;
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
        protected DropDownList XiugaiZb;
        protected DropDownList XrGuize;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select  id from qp_Pro_WorkFlowNode where FormId='" + this.pulicss.GetFormatStr(base.Request.QueryString["FormId"]) + "' and NodeNum='" + this.NodeNum.Text + "' ";
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
                    string str2 = "select top 1 id from qp_Pro_WorkFlowNode where FormId='" + this.pulicss.GetFormatStr(base.Request.QueryString["FormId"]) + "' and NodeSite='开始' ";
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
                string str5 = "select top 1 * from qp_Pro_WorkFlowNode where FormId='" + this.pulicss.GetFormatStr(base.Request.QueryString["FormId"]) + "' and NodeNum<'" + this.NodeNum.Text + "' order by NodeNum desc";
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
                            string str6 = "insert into qp_Pro_WorkFlowNodeLine (Source,Object,LineContent,NodeNumber,FormId) values ('" + this.NodeNum.Text + "','" + strArray[j] + "','" + str3 + "','" + this.pulicss.GetFormatStr(this.NodeNumber.Text) + "','" + base.Request.QueryString["FormId"] + "')";
                            this.List.ExeSql(str6);
                            str4 = str4 + "" + strArray[j] + ",";
                        }
                    }
                    str7 = string.Concat(new object[] { 
                        "insert into qp_Pro_WorkFlowNode (JbZhuangjiao,XrGuize,XiugaiZb,FormId,NodeNum,NodeName,SETLEFT,SETTOP,ZbUsername,ZbRealname,UpNodeNum,NodeSite,Huitui,NodeNumber) values ('", this.JbZhuangjiao.SelectedValue, "','", this.XrGuize.SelectedValue, "','", this.XiugaiZb.SelectedValue, "','", base.Request.QueryString["FormId"], "','", this.NodeNum.Text, "','", this.NodeName.Text, "','", num3, "','", num4, 
                        "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','", str4, "','", this.NodeSite.SelectedValue, "','", this.Huitui.SelectedValue, "','", this.pulicss.GetFormatStr(this.NodeNumber.Text), "')"
                     });
                    this.List.ExeSql(str7);
                }
                else
                {
                    str7 = string.Concat(new object[] { 
                        "insert into qp_Pro_WorkFlowNode (JbZhuangjiao,XrGuize,XiugaiZb,FormId,NodeNum,NodeName,SETLEFT,SETTOP,ZbUsername,ZbRealname,UpNodeNum,NodeSite,Huitui,NodeNumber) values ('", this.JbZhuangjiao.SelectedValue, "','", this.XrGuize.SelectedValue, "','", this.XiugaiZb.SelectedValue, "','", base.Request.QueryString["FormId"], "','", this.NodeNum.Text, "','", this.NodeName.Text, "','", num3, "','", num4, 
                        "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','','", this.NodeSite.SelectedValue, "','", this.Huitui.SelectedValue, "','", this.pulicss.GetFormatStr(this.NodeNumber.Text), "')"
                     });
                    this.List.ExeSql(str7);
                }
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
            string sQL = "select NodeNum,NodeName from qp_Pro_WorkFlowNode  where FormId='" + this.pulicss.GetFormatStr(base.Request.QueryString["FormId"]) + "'";
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
                string sql = "select top 1 *  from qp_Pro_WorkFlowNode where FormId='" + this.pulicss.GetFormatStr(base.Request.QueryString["FormId"]) + "' order by NodeNum desc";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NodeSite.SelectedValue = "2";
                    this.NodeNum.Text = this.NodeNum.Text + (int.Parse(list["NodeNum"].ToString()) + 1);
                }
                else
                {
                    this.NodeSite.SelectedValue = "1";
                    this.NodeNum.Text = "1";
                }
                list.Close();
                this.DataBindToDownList();
                this.BindAttribute();
                Random random = new Random();
                string str2 = random.Next(0x2710).ToString();
                this.NodeNumber.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str2 + "";
            }
        }
    }
}


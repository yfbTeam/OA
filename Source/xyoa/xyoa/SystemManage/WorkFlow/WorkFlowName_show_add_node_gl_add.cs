﻿namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_node_gl_add : Page
    {
        protected TextBox BmGuoLvName;
        protected TextBox BmGuoLvUser;
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected TextBox FlowName;
        protected TextBox FlowNumber;
        protected HtmlForm form1;
        protected TextBox FormId;
        protected TextBox FormName;
        protected TextBox FormNumber;
        protected HtmlHead Head1;
        protected TextBox KxGuoLvName;
        protected TextBox KxGuoLvUser;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox NodeName;
        protected TextBox NodeNum;
        protected TextBox NodeNumber;
        private publics pulicss = new publics();
        protected TextBox SecFileID;
        protected ListBox SourceListBox;
        public string str;
        public string str1;
        public string strlist;
        public string strname;
        public string struser;
        protected ListBox TargetListBox;
        public string tqp;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
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
                        string str3 = "select  *  from qp_oa_FormFile  where id='" + strArray[j] + "'";
                        SqlDataReader reader = this.List.GetList(str3);
                        if (reader.Read())
                        {
                            str = str + "" + reader["id"].ToString() + ",";
                            str2 = str2 + "" + reader["name"].ToString() + ",";
                        }
                        reader.Close();
                    }
                }
                string sql = "insert into qp_oa_WorkFlowNodeGuolv (GuolvFileID,GuolvFileName,KxGuoLvUser,KxGuoLvName,BmGuoLvUser,BmGuoLvName,NodeId) values ('" + str + "','" + str2 + "','" + this.pulicss.GetFormatStr(this.KxGuoLvUser.Text) + "','" + this.pulicss.GetFormatStr(this.KxGuoLvName.Text) + "','" + this.pulicss.GetFormatStr(this.BmGuoLvUser.Text) + "','" + this.pulicss.GetFormatStr(this.BmGuoLvName.Text) + "','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "')";
                this.List.ExeSql(sql);
                this.pulicss.InsertLog("修改工作流过滤[" + this.NodeName.Text + "]", "工作流步骤");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请选择字段！');</script>");
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
            string sQL = "select id,Name from qp_oa_FormFile   where  KeyFile='" + this.FormNumber.Text + "' and (type='[常规型]' or type='[数字型]' or type='[列表]' or type='[单选框列表]' or type='[复选框列表]' or type='[表单域]')";
            this.list.Bind_DropDownList_ListBox(this.SourceListBox, sQL, "id", "Name");
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
                    this.FormNumber.Text = list["FormNumber"].ToString();
                    this.NodeNum.Text = list["NodeNum"].ToString();
                    this.NodeName.Text = list["NodeName"].ToString();
                }
                list.Close();
                this.DataBindToDownList();
                this.NodeNum.Attributes.Add("readonly", "readonly");
                this.NodeName.Attributes.Add("readonly", "readonly");
                this.KxGuoLvName.Attributes.Add("readonly", "readonly");
                this.BmGuoLvName.Attributes.Add("readonly", "readonly");
            }
        }
    }
}

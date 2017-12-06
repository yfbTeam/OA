namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_div_yjbuser : Page
    {
        protected Button Button5;
        protected Button Button6;
        protected Button Button7;
        protected Button Button8;
        protected HtmlForm Form1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox requeststr;
        protected ListBox SourceListBox;
        protected ListBox TargetListBox;
        protected TextBox TextBox1;
        protected TextBox TextBox2;

        protected void Button1_Click(object sender, EventArgs e)
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

        public string CreateMidSql()
        {
            string str5;
            string str = string.Empty;
            if (base.Request.QueryString["lcid"] != null)
            {
                string str2 = null;
                string str3 = null;
                string sql = "select YJBObjectId from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["lcid"] + "'";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    str3 = "" + reader["YJBObjectId"].ToString() + "";
                    ArrayList list = new ArrayList();
                    string[] strArray = str3.Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        str2 = str2 + "'" + strArray[i] + "',";
                    }
                    str2 = str2 + "'0'";
                }
                else
                {
                    str2 = "'0'";
                }
                reader.Close();
                str5 = " and username in (" + str2 + ")";
                return (str + str5);
            }
            str5 = "";
            return (str + str5);
        }

        public void DataBindToGridview(string Sqlsort, string Sqlstr)
        {
            string str = "select username, Realname  from qp_oa_username  where 1=1 and  ifdel='0'  ";
            string sQL = str + Sqlstr + Sqlsort;
            this.list.Bind_DropDownList_ListBox(this.SourceListBox, sQL, "Username", "Realname");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.DataBindToGridview("order by paixu asc", this.CreateMidSql());
            }
        }
    }
}


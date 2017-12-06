namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_wbuser_list : Page
    {
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected Button Button7;
        protected Button Button8;
        protected HtmlForm Form1;
        protected DropDownList GroupName;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Realname;
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

        protected void Button4_Click1(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by id desc", this.CreateMidSql());
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
            string str = string.Empty;
            if (this.Realname.Text != "")
            {
                str = str + " and Name like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.Realname.Text)) + "%'";
            }
            if (this.GroupName.SelectedValue != "")
            {
                str = str + " and GroupName = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.GroupName.SelectedValue)) + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string Sqlstr)
        {
            string str2;
            if (base.Request.QueryString["requeststr"] != null)
            {
                str2 = string.Concat(new object[] { "select HMoveTel,Name  from qp_oa_MyGroup  where 1=1  and username='", this.Session["username"], "' and HMoveTel not in (", this.ViewState["strlist"], ")" }) + Sqlstr;
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, str2, "HMoveTel", "Name");
            }
            else
            {
                str2 = ("select HMoveTel,Name  from qp_oa_MyGroup  where  and username='" + this.Session["username"] + "' ") + Sqlstr;
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, str2, "HMoveTel", "Name");
            }
        }

        protected void ListChangedBind(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by id desc", this.CreateMidSql());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                StateBag bag = ViewState;
                this.requeststr.Text = base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString());
                string str = null;
                str = "" + this.requeststr.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = str.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    object obj2 = bag["strlist"];
                    (bag = this.ViewState)["strlist"] = string.Concat(new object[] { obj2, "'", strArray[i], "'," });
                }
                (bag = this.ViewState)["strlist"] = bag["strlist"] + "'0'";
                if (!this.Page.IsPostBack)
                {
                    string sQL = "select id,name  from qp_oa_GroupType where username='" + this.Session["username"] + "' order by id asc";
                    this.list.Bind_DropDownList_kong(this.GroupName, sQL, "id", "name");
                    if (base.Request.QueryString["requeststr"] != null)
                    {
                        string str3 = null;
                        str3 = string.Concat(new object[] { "select HMoveTel,Name from qp_oa_MyGroup  where HMoveTel in (", this.ViewState["strlist"], ") and username='", this.Session["username"], "'" });
                        this.TargetListBox.Items.Clear();
                        this.list.Bind_DropDownList_ListBox(this.TargetListBox, str3, "HMoveTel", "Name");
                    }
                    this.DataBindToGridview("order by id desc", this.CreateMidSql());
                }
            }
        }
    }
}


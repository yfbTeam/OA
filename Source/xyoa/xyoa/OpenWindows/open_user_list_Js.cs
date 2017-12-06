namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_user_list_Js : Page
    {
        protected DropDownList BuMenId;
        protected Button Button10;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected Button Button7;
        protected Button Button8;
        protected HtmlForm Form1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox requeststr;
        protected ListBox SourceListBox;
        protected ListBox TargetListBox;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected DropDownList Zhiweiid;

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

        protected void Button10_Click(object sender, EventArgs e)
        {
            this.BuMenId.SelectedValue = "";
            this.Zhiweiid.SelectedValue = "";
            this.Realname.Text = "";
            if (base.Request.QueryString["requeststr"] != null)
            {
                string sQL = null;
                sQL = "select * from qp_oa_Username  where username in (" + this.ViewState["strlist"] + ") and  ifdel='0'  order by paixu asc";
                this.TargetListBox.Items.Clear();
                this.list.Bind_DropDownList_ListBox(this.TargetListBox, sQL, "Username", "Realname");
            }
            this.DataBindToGridview("order by paixu asc", this.CreateMidSql());
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
            this.DataBindToGridview("order by paixu asc", this.CreateMidSql());
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
                str = str + " and Realname like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.Realname.Text)) + "%'";
            }
            if (this.Zhiweiid.SelectedValue != "")
            {
                str = str + " and Zhiweiid = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.Zhiweiid.SelectedValue)) + "'";
            }
            if (this.BuMenId.SelectedValue != "")
            {
                str = str + " and BuMenId = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.BuMenId.SelectedValue)) + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string Sqlstr)
        {
            string str2;
            if (base.Request.QueryString["requeststr"] != null)
            {
                str2 = string.Concat(new object[] { "select username, Realname  from qp_oa_username  where  JueseId = '", base.Request.QueryString["JueseId"], "' and  ifdel='0'  and username not in (", this.ViewState["strlist"], ")" }) + Sqlstr + Sqlsort;
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, str2, "Username", "Realname");
            }
            else
            {
                str2 = ("select username, Realname  from qp_oa_username  where JueseId = '" + base.Request.QueryString["JueseId"] + "' and  ifdel='0'  ") + Sqlstr + Sqlsort;
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, str2, "Username", "Realname");
            }
        }

        protected void ListChangedBind(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by paixu asc", this.CreateMidSql());
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
                    this.pulicss.BindListkong("qp_oa_Bumen", this.BuMenId, "", "order by Bianhao asc");
                    string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                    this.list.Bind_DropDownList_kong(this.Zhiweiid, sQL, "id", "name");
                    if (base.Request.QueryString["requeststr"] != null)
                    {
                        string str3 = null;
                        str3 = "select * from qp_oa_Username  where username in (" + this.ViewState["strlist"] + ") and  ifdel='0' order by paixu asc ";
                        this.TargetListBox.Items.Clear();
                        this.list.Bind_DropDownList_ListBox(this.TargetListBox, str3, "Username", "Realname");
                    }
                    this.DataBindToGridview("order by paixu asc", this.CreateMidSql());
                }
            }
        }
    }
}


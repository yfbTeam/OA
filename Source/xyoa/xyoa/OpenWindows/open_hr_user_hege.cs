namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_hr_user_hege : Page
    {
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
        protected TextBox requeststr;
        protected ListBox SourceListBox;
        protected ListBox TargetListBox;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected TextBox Xingming;

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
            this.Xingming.Text = "";
            if (base.Request.QueryString["requeststr"] != null)
            {
                string sQL = null;
                sQL = "select id, Xingming  from qp_hr_JianLi  where 1=1 and id in (" + this.requeststr.Text + "0)";
                this.TargetListBox.Items.Clear();
                this.list.Bind_DropDownList_ListBox(this.TargetListBox, sQL, "id", "Xingming");
            }
            this.DataBindToGridview("order by id desc", this.CreateMidSql());
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
            if (this.Xingming.Text != "")
            {
                str = str + " and Xingming like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(this.Xingming.Text)) + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string Sqlstr)
        {
            string str2;
            if (base.Request.QueryString["requeststr"] != null)
            {
                str2 = ("select id, Xingming  from qp_hr_JianLi  where Zhuangtai=5 and id not in (" + this.requeststr.Text + "0)") + Sqlstr;
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, str2, "id", "Xingming");
            }
            else
            {
                string str = "select id, Xingming  from qp_hr_JianLi  where Zhuangtai=5";
                str2 = str + Sqlstr;
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, str2, "id", "Xingming");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.requeststr.Text = base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString());
                if (!this.Page.IsPostBack)
                {
                    string sQL = "select id, Xingming  from qp_hr_JianLi  where id in (" + this.requeststr.Text + "0)";
                    this.TargetListBox.Items.Clear();
                    this.list.Bind_DropDownList_ListBox(this.TargetListBox, sQL, "id", "Xingming");
                    this.DataBindToGridview("order by id desc", this.CreateMidSql());
                }
            }
        }
    }
}


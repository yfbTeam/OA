namespace xyoa.OpenWindows
{
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_zhiwei_list : Page
    {
        protected Button Button1;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected HtmlForm Form1;
        protected TextBox KeyBox;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox requeststr;
        protected ListBox SourceListBox;
        public string str;
        public string str1;
        public string strlist;
        public string strname;
        public string struser;
        protected ListBox TargetListBox;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        public string tqp;

        public void BindAttribute()
        {
        }

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

        public void DataBindToDownList()
        {
            if (base.Request.QueryString["requeststr"] != null)
            {
                string sQL = "select * from qp_oa_Zhiwei where id not in (" + this.strlist + ")";
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, sQL, "id", "name");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.BindAttribute();
                this.requeststr.Text = base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString());
                this.str1 = "" + this.requeststr.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = this.str1.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    this.strlist = this.strlist + "'" + strArray[i] + "',";
                }
                this.strlist = this.strlist + "'0'";
                if (base.Request.QueryString["requeststr"] != null)
                {
                    string sQL = "select * from qp_oa_Zhiwei  where id in (" + this.strlist + ")";
                    this.list.Bind_DropDownList_ListBox(this.TargetListBox, sQL, "id", "name");
                }
                this.DataBindToDownList();
            }
        }
    }
}


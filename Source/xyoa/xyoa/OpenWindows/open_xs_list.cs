namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_xs_list : Page
    {
        protected DropDownList Banji;
        protected Button Button10;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected Button Button7;
        protected Button Button8;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm Form1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Nianji;
        private publics pulicss = new publics();
        protected TextBox requeststr;
        protected ListBox SourceListBox;
        protected ListBox TargetListBox;
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected TextBox Xingming;
        protected Label Xueduan;
        protected Label Xueqi;

        protected void Banji_ListChanged(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by A.Banji asc", this.CreateMidSql());
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

        protected void Button10_Click(object sender, EventArgs e)
        {
            this.Nianji.SelectedValue = "";
            this.Banji.SelectedValue = "";
            this.Xingming.Text = "";
            if (base.Request.QueryString["requeststr"] != "")
            {
                string sQL = null;
                sQL = "select '" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,B.Nianji,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming+'('+B.[Mingcheng]+')' as Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.Text + "_" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where C.id not in (" + this.requeststr.Text + ") and C.Zhuxiao = '是' order by A.Banji asc";
                this.TargetListBox.Items.Clear();
                this.list.Bind_DropDownList_ListBox(this.TargetListBox, sQL, "id", "Xingming");
            }
            this.DataBindToGridview("order by A.Banji asc", this.CreateMidSql());
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
            this.DataBindToGridview("order by A.Banji asc", this.CreateMidSql());
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
                str = str + " and C.Xingming like '%" + this.pulicss.GetFormatStr(this.Xingming.Text) + "%'";
            }
            if (this.Nianji.SelectedValue != "")
            {
                str = str + " and B.Nianji = '" + this.Nianji.SelectedValue + "'";
            }
            if (this.Banji.SelectedValue != "")
            {
                str = str + " and A.BanJi = '" + this.Banji.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string Sqlstr)
        {
            string str2;
            if (base.Request.QueryString["requeststr"] != "")
            {
                str2 = ("select '" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,B.Nianji,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming+'('+B.[Mingcheng]+')' as Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.Text + "_" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and C.id not in (" + this.requeststr.Text + ")  and C.Zhuxiao = '是'") + Sqlstr + Sqlsort;
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, str2, "id", "Xingming");
            }
            else
            {
                str2 = ("select '" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,B.Nianji,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming+'('+B.[Mingcheng]+')' as Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.Text + "_" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1  and C.Zhuxiao = '是'") + Sqlstr + Sqlsort;
                this.list.Bind_DropDownList_ListBox(this.SourceListBox, str2, "id", "Xingming");
            }
        }

        protected void Nianji_ListChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='" + this.Xueqi.Text + "' and A.Nianji='" + this.Nianji.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_kong(this.Banji, sQL, "id", "Mingcheng");
            this.DataBindToGridview("order by A.Banji asc", this.CreateMidSql());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.requeststr.Text = "0," + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "0";
                this.Xueqi.Text = this.divsch.GetXueqi();
                this.Xueduan.Text = this.divsch.GetXueduan();
                string sQL = "select A.id,A.NianjiMc from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.Text + "' order by Num asc";
                this.list.Bind_DropDownList_nothing(this.Nianji, sQL, "NianjiMc", "NianjiMc");
                string str2 = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='" + this.Xueqi.Text + "' and A.Nianji='" + this.Nianji.SelectedValue + "' order by Num asc";
                this.list.Bind_DropDownList_kong(this.Banji, str2, "id", "Mingcheng");
                if (base.Request.QueryString["requeststr"].ToString() != "")
                {
                    string str3 = null;
                    str3 = "select '" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,B.Nianji,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming+'('+B.[Mingcheng]+')' as Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.Text + "_" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and  C.id  in (" + this.requeststr.Text + ") and C.Zhuxiao = '是'  order by A.Banji asc";
                    this.TargetListBox.Items.Clear();
                    this.list.Bind_DropDownList_ListBox(this.TargetListBox, str3, "id", "Xingming");
                }
                this.DataBindToGridview("order by A.Banji asc", this.CreateMidSql());
            }
        }
    }
}


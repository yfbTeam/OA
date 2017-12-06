namespace xyoa.SchTable.Chengji.Zongxiang
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Zongxiang_Mc : Page
    {
        protected DropDownList BanJi;
        protected HtmlButton Button1;
        protected HtmlButton Button2;
        protected HtmlButton Button3;
        protected Button Button6;
        protected Button Button7;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected CheckBoxList Kemu;
        protected Label Label1;
        protected CheckBoxList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label LTongji;
        protected DropDownList Nianji;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected DropDownList XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        protected void BanJi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.BanJi.SelectedValue + "' order by A.id asc";
            this.list.Bind_DropDownList_nothing(this.XsId, sQL, "id", "Xingming");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            this.DataBindToGridview();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Leixing.SelectedItem.Text + "个人名次追踪");
        }

        public void DataBindLx()
        {
            string sql = "select * from qp_sch_Nianji where  NianjiMc='" + this.Nianji.SelectedValue + "' and Xueqi='" + this.Xueqi.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2;
                if (this.Xueduan.SelectedValue == "上学期")
                {
                    str2 = "select id,Name  from qp_sch_Kecheng where id in (" + list["Kecheng"].ToString() + ") order by id asc";
                    this.list.Bind_DropDownList_CheckBoxList(this.Kemu, str2, "id", "Name");
                }
                else
                {
                    str2 = "select id,Name  from qp_sch_Kecheng where id in (" + list["KechengX"].ToString() + ") order by id asc";
                    this.list.Bind_DropDownList_CheckBoxList(this.Kemu, str2, "id", "Name");
                }
                string sQL = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ") order by id asc";
                this.list.Bind_DropDownList_CheckBoxList(this.Leixing, sQL, "id", "name");
            }
            list.Close();
        }

        public void DataBindToGridview()
        {
            this.LTongji.Text = null;
            int num = 0;
            string sql = "select count(id) from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ")";
            num = this.List.GetCount(sql) + 1;
            object text = this.LTongji.Text;
            this.LTongji.Text = string.Concat(new object[] { text, " <table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\"><tr align=\"center\"><td colspan=\"", num, "\">" });
            string str10 = this.LTongji.Text;
            this.LTongji.Text = str10 + "<font style='font-weight: bold; color: red'>" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.XsId.SelectedItem.Text + "个人名次追踪  名次：班级/年级</font></td></tr>";
            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
            this.LTongji.Text = this.LTongji.Text + @"<td>科目\类型</td>";
            string str2 = "select id,Name from qp_sch_DataFile  where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ") order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", list["Name"], "</td>" });
            }
            list.Close();
            this.LTongji.Text = this.LTongji.Text + "</tr>";
            string str3 = "select id,Name  from qp_sch_Kecheng where id in (" + this.pulicss.GetChecked(this.Kemu) + ") order by id asc";
            SqlDataReader reader2 = this.List.GetList(str3);
            while (reader2.Read())
            {
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                this.LTongji.Text = this.LTongji.Text + "<td>" + reader2["Name"].ToString() + "</td>";
                string str4 = "select id,Name from qp_sch_DataFile  where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ") order by id asc";
                SqlDataReader reader3 = this.List.GetList(str4);
                while (reader3.Read())
                {
                    int num2 = 0;
                    int num3 = 0;
                    string str5 = "select sum(Chengji) as Mark,[A].[XsId] from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu='" + reader2["id"].ToString() + "' and A.Leixing='" + reader3["id"].ToString() + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and D.Nianji='" + this.Nianji.SelectedValue + "'  group by [A].[XsId] order by Mark desc";
                    SqlDataReader reader4 = this.List.GetList(str5);
                    while (reader4.Read())
                    {
                        num3++;
                        if (reader4["XsId"].ToString() == this.XsId.SelectedValue)
                        {
                            num2 = num3;
                        }
                    }
                    reader4.Close();
                    int num4 = 0;
                    int num5 = 0;
                    string str6 = "select sum(Chengji) as Mark,[A].[XsId] from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu='" + reader2["id"].ToString() + "' and A.Leixing='" + reader3["id"].ToString() + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and C.BanJi='" + this.BanJi.SelectedValue + "'  group by [A].[XsId] order by Mark desc";
                    SqlDataReader reader5 = this.List.GetList(str6);
                    while (reader5.Read())
                    {
                        num5++;
                        if (reader5["XsId"].ToString() == this.XsId.SelectedValue)
                        {
                            num4 = num5;
                        }
                    }
                    reader5.Close();
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num4, "/", num2, "</td>" });
                }
                reader3.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
            }
            reader2.Close();
            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
            this.LTongji.Text = this.LTongji.Text + "<td>总分排名</td>";
            string str7 = "select id,Name from qp_sch_DataFile  where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ") order by id asc";
            SqlDataReader reader6 = this.List.GetList(str7);
            while (reader6.Read())
            {
                int num6 = 0;
                int num7 = 0;
                string str8 = "select sum(Chengji) as Mark,[A].[XsId] from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu in (" + this.pulicss.GetChecked(this.Kemu) + ") and A.Leixing='" + reader6["id"].ToString() + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and D.Nianji='" + this.Nianji.SelectedValue + "'  group by [A].[XsId] order by Mark desc";
                SqlDataReader reader7 = this.List.GetList(str8);
                while (reader7.Read())
                {
                    num7++;
                    if (reader7["XsId"].ToString() == this.XsId.SelectedValue)
                    {
                        num6 = num7;
                    }
                }
                reader7.Close();
                int num8 = 0;
                int num9 = 0;
                string str9 = "select sum(Chengji) as Mark,[A].[XsId] from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu in (" + this.pulicss.GetChecked(this.Kemu) + ") and A.Leixing='" + reader6["id"].ToString() + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and C.BanJi='" + this.BanJi.SelectedValue + "'  group by [A].[XsId] order by Mark desc";
                SqlDataReader reader8 = this.List.GetList(str9);
                while (reader8.Read())
                {
                    num9++;
                    if (reader8["XsId"].ToString() == this.XsId.SelectedValue)
                    {
                        num8 = num9;
                    }
                }
                reader8.Close();
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num8, "/", num6, "</td>" });
            }
            reader6.Close();
            this.LTongji.Text = this.LTongji.Text + "</tr>";
            this.LTongji.Text = this.LTongji.Text + "</table>";
        }

        protected void Nianji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   Xueqi='" + this.Xueqi.SelectedValue + "' and Nianji='" + this.Nianji.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_nothing(this.BanJi, sQL, "id", "Mingcheng");
            string str2 = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.BanJi.SelectedValue + "' order by A.id asc";
            this.list.Bind_DropDownList_nothing(this.XsId, str2, "id", "Xingming");
            this.DataBindLx();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (base.Request.QueryString["p"] != null)
                {
                    this.ViewState["tableheigh"] = "80%";
                }
                else
                {
                    this.ViewState["tableheigh"] = "600px";
                }
                if (!this.Page.IsPostBack)
                {
                    this.Button6.Attributes["onclick"] = "javascript:return chknull();";
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                    string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                    this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                    this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                    this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                    string str2 = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  Xueqi='" + this.Xueqi.SelectedValue + "' order by Num asc";
                    this.list.Bind_DropDownList_nothing(this.Nianji, str2, "NianjiMc", "NianjiMc");
                    string str3 = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') and Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", this.Nianji.SelectedValue, "' order by Num asc" });
                    this.list.Bind_DropDownList_nothing(this.BanJi, str3, "id", "Mingcheng");
                    string str4 = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.BanJi.SelectedValue + "' order by A.id asc";
                    this.list.Bind_DropDownList_nothing(this.XsId, str4, "id", "Xingming");
                    this.DataBindLx();
                }
            }
        }

        protected void Xueduan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindLx();
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  Xueqi='" + this.Xueqi.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_nothing(this.Nianji, sQL, "NianjiMc", "NianjiMc");
            string str2 = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') and Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", this.Nianji.SelectedValue, "' order by Num asc" });
            this.list.Bind_DropDownList_nothing(this.BanJi, str2, "id", "Mingcheng");
            string str3 = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.BanJi.SelectedValue + "' order by A.id asc";
            this.list.Bind_DropDownList_nothing(this.XsId, str3, "id", "Xingming");
            this.DataBindLx();
        }
    }
}


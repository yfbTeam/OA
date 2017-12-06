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

    public class Zongxiang_Bj : Page
    {
        protected CheckBoxList BanJi;
        protected HtmlButton Button1;
        protected HtmlButton Button2;
        protected HtmlButton Button3;
        protected Button Button6;
        protected Button Button7;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
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
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        protected void Button6_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            this.DataBindToGridview();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Leixing.SelectedItem.Text + "班级质量追踪");
        }

        public string ChengJiCode(string Banji, string Leixing)
        {
            string str = null;
            string sql = "select sum(Chengji) as Chengji from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu in (" + this.pulicss.GetChecked(this.Kemu) + ") and A.Leixing='" + Leixing + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and C.BanJi='" + Banji + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["Chengji"].ToString() == "")
                {
                    str = "0";
                }
                else
                {
                    str = list["Chengji"].ToString();
                }
            }
            else
            {
                str = "0";
            }
            list.Close();
            return str;
        }

        public string ChengJiCodeSum(string Leixing)
        {
            string str = null;
            string sql = "select sum(Chengji) as Chengji from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu in (" + this.pulicss.GetChecked(this.Kemu) + ") and A.Leixing='" + Leixing + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and D.Nianji='" + this.Nianji.SelectedValue + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["Chengji"].ToString() == "")
                {
                    str = "0";
                }
                else
                {
                    str = list["Chengji"].ToString();
                }
            }
            else
            {
                str = "0";
            }
            list.Close();
            return str;
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
            string sql = "select count(id) from qp_sch_Banji where id in (" + this.pulicss.GetChecked(this.BanJi) + ")";
            num = this.List.GetCount(sql) + 1;
            object text = this.LTongji.Text;
            this.LTongji.Text = string.Concat(new object[] { text, " <table id=\"showinfo\" style=\"width: 730px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\"><tr align=\"center\"><td colspan=\"", num, "\">" });
            string str9 = this.LTongji.Text;
            this.LTongji.Text = str9 + "<font style='font-weight: bold; color: red'>" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.pulicss.GetCheckedText(this.Kemu) + "班级追踪</font><br><font style='font-weight: bold; color: blue'>分析系数=班级平均分/年级平均分</font></td></tr>";
            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
            this.LTongji.Text = this.LTongji.Text + @"<td>类型\班级</td>";
            string str2 = "select id,Mingcheng from qp_sch_Banji  where id in (" + this.pulicss.GetChecked(this.BanJi) + ") order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", list["Mingcheng"], "</td>" });
            }
            list.Close();
            this.LTongji.Text = this.LTongji.Text + "</tr>";
            string str3 = "select id,Name from qp_sch_DataFile  where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ") order by id asc";
            SqlDataReader reader2 = this.List.GetList(str3);
            while (reader2.Read())
            {
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                this.LTongji.Text = this.LTongji.Text + "<td>" + reader2["Name"].ToString() + "</td>";
                string str4 = "select id,Mingcheng  from qp_sch_Banji where id in (" + this.pulicss.GetChecked(this.BanJi) + ") order by id asc";
                SqlDataReader reader3 = this.List.GetList(str4);
                while (reader3.Read())
                {
                    string s = this.ChengJiCodeSum(reader2["id"].ToString());
                    string str6 = this.ChengJiCode(reader3["id"].ToString(), reader2["id"].ToString());
                    string str7 = "select count(A.id) from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and B.Nianji = '" + this.Nianji.SelectedValue + "'";
                    int count = this.List.GetCount(str7);
                    string str8 = "select count(A.id) from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and B.id = '" + reader3["id"].ToString() + "'";
                    int num3 = this.List.GetCount(str8);
                    decimal num4 = 0M;
                    decimal num5 = 0M;
                    if (count == 0)
                    {
                        num4 = 0M;
                    }
                    else
                    {
                        num4 = decimal.Parse(s) / count;
                    }
                    if (num3 == 0)
                    {
                        num5 = 0M;
                    }
                    else
                    {
                        num5 = decimal.Parse(str6) / num3;
                    }
                    decimal d = 0M;
                    if (num4 == 0M)
                    {
                        d = 0M;
                    }
                    else
                    {
                        d = num5 / num4;
                    }
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", decimal.Round(d, 4), "</td>" });
                }
                reader3.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
            }
            reader2.Close();
            this.LTongji.Text = this.LTongji.Text + "</table>";
        }

        protected void Nianji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   Xueqi='" + this.Xueqi.SelectedValue + "' and Nianji='" + this.Nianji.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_CheckBoxList(this.BanJi, sQL, "id", "Mingcheng");
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
                    this.list.Bind_DropDownList_CheckBoxList(this.BanJi, str3, "id", "Mingcheng");
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
            this.list.Bind_DropDownList_CheckBoxList(this.BanJi, str2, "id", "Mingcheng");
            this.DataBindLx();
        }
    }
}


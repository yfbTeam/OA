namespace xyoa.SchTable.Chengji.Pinggu
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Pinggu : Page
    {
        protected DropDownList BanJi;
        protected HtmlButton Button1;
        protected HtmlButton Button2;
        protected Button Button6;
        protected Button Button7;
        protected CheckBox CheckBox2;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Kemu;
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
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Kemu.SelectedItem.Text + "学生实力评估");
        }

        public string ChengJiCode(string Leixing)
        {
            string str = null;
            string sql = "select sum(Chengji) as Chengji from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu='" + this.Kemu.SelectedValue + "' and A.Leixing='" + Leixing + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and C.BanJi='" + this.BanJi.SelectedValue + "'  ";
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

        public string ChengJiCodeGr(string Leixing, string XsId)
        {
            string str = null;
            string sql = "select Chengji,id from qp_sch_Chengji  where Kemu='" + this.Kemu.SelectedValue + "' and Leixing='" + Leixing + "'  and XsId='" + XsId + "'  and Xueqi='" + this.Xueqi.SelectedValue + "'  and Xueduan='" + this.Xueduan.SelectedValue + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Chengji"].ToString();
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
            string sql = "select sum(Chengji) as Chengji from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu='" + this.Kemu.SelectedValue + "' and A.Leixing='" + Leixing + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and D.Nianji='" + this.Nianji.SelectedValue + "'  ";
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
                    this.list.Bind_DropDownList_nothing(this.Kemu, str2, "id", "Name");
                }
                else
                {
                    str2 = "select id,Name  from qp_sch_Kecheng where id in (" + list["KechengX"].ToString() + ") order by id asc";
                    this.list.Bind_DropDownList_nothing(this.Kemu, str2, "id", "Name");
                }
                string sQL = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ") order by id asc";
                this.list.Bind_DropDownList_CheckBoxList(this.Leixing, sQL, "id", "name");
            }
            list.Close();
        }

        public void DataBindToGridview()
        {
            this.LTongji.Text = null;
            string sql = "select count(A.id) from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and B.Nianji = '" + this.Nianji.SelectedValue + "'";
            int count = this.List.GetCount(sql);
            string str2 = "select count(A.id) from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and B.id = '" + this.BanJi.SelectedValue + "'";
            int num2 = this.List.GetCount(str2);
            int num3 = 0;
            string str3 = "select count(id)  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ")";
            num3 = (this.List.GetCount(str3) * 3) + 4;
            object text = this.LTongji.Text;
            this.LTongji.Text = string.Concat(new object[] { text, " <table id=\"showinfo\" style=\"width: 830px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\"><tr align=\"center\"><td colspan=\"", num3, "\">" });
            string str11 = this.LTongji.Text;
            this.LTongji.Text = str11 + "<font style='font-weight: bold; color: red'>" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Kemu.SelectedItem.Text + "学生实力评估</font></td></tr>";
            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
            this.LTongji.Text = this.LTongji.Text + "<td rowspan=\"2\">序号</td>";
            this.LTongji.Text = this.LTongji.Text + "<td rowspan=\"2\">姓名</td>";
            this.LTongji.Text = this.LTongji.Text + "<td rowspan=\"2\">学籍号</td>";
            this.LTongji.Text = this.LTongji.Text + "<td rowspan=\"2\">学号</td>";
            string str4 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ") order by id asc";
            SqlDataReader list = this.List.GetList(str4);
            while (list.Read())
            {
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td colspan=\"3\">", list["Name"], "</td>" });
            }
            list.Close();
            this.LTongji.Text = this.LTongji.Text + "</tr>";
            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
            string str5 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ") order by id asc";
            SqlDataReader reader2 = this.List.GetList(str5);
            while (reader2.Read())
            {
                this.LTongji.Text = this.LTongji.Text + "<td>分数</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>班级比值</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>年级比值</td>";
            }
            reader2.Close();
            this.LTongji.Text = this.LTongji.Text + "</tr>";
            int num4 = 0;
            string str6 = "select C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and A.BanJi='" + this.BanJi.SelectedValue + "' order by A.BanJi asc";
            SqlDataReader reader3 = this.List.GetList(str6);
            while (reader3.Read())
            {
                num4++;
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num4, "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Xingming"], "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Xuejihao"], "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Xuehao"], "</td>" });
                string str7 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + this.pulicss.GetChecked(this.Leixing) + ") order by id asc";
                SqlDataReader reader4 = this.List.GetList(str7);
                while (reader4.Read())
                {
                    string s = this.ChengJiCodeGr(reader4["id"].ToString(), reader3["id"].ToString());
                    this.LTongji.Text = this.LTongji.Text + "<td>" + s + "</td>";
                    string str9 = this.ChengJiCodeSum(reader4["id"].ToString());
                    string str10 = this.ChengJiCode(reader4["id"].ToString());
                    decimal num5 = 0M;
                    decimal num6 = 0M;
                    if (count == 0)
                    {
                        num5 = 0M;
                    }
                    else
                    {
                        num5 = decimal.Parse(str9) / count;
                    }
                    if (num2 == 0)
                    {
                        num6 = 0M;
                    }
                    else
                    {
                        num6 = decimal.Parse(str10) / num2;
                    }
                    decimal d = 0M;
                    decimal num8 = 0M;
                    if (num5 == 0M)
                    {
                        d = 0M;
                    }
                    else
                    {
                        d = decimal.Parse(s) / num5;
                    }
                    if (num6 == 0M)
                    {
                        num8 = 0M;
                    }
                    else
                    {
                        num8 = decimal.Parse(s) / num6;
                    }
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", decimal.Round(num8, 4), "</td>" });
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", decimal.Round(d, 4), "</td>" });
                }
                reader4.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
            }
            reader3.Close();
            text = this.LTongji.Text;
            this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num3, "\"><font color='red'>*注解：<br>1.班级比值=个人成绩/班级平均分<br>2.年级比值=个人成绩/年级平均分</font></td></tr>" });
            this.LTongji.Text = this.LTongji.Text + "</table>";
        }

        protected void Nianji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   Xueqi='" + this.Xueqi.SelectedValue + "' and Nianji='" + this.Nianji.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_nothing(this.BanJi, sQL, "id", "Mingcheng");
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
            this.DataBindLx();
        }
    }
}


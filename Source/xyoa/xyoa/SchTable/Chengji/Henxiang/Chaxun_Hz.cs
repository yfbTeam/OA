namespace xyoa.SchTable.Chengji.Henxiang
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Chaxun_Hz : Page
    {
        protected CheckBoxList BanJi;
        protected HtmlButton Button1;
        protected HtmlButton Button2;
        protected Button Button6;
        protected Button Button7;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected CheckBoxList Kemu;
        protected Label Label1;
        protected DropDownList Leixing;
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
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Leixing.SelectedItem.Text + "学生名次表");
        }

        public string ChengJiCode(string Kemu, string Leixing, string XsId)
        {
            string str = null;
            string sql = "select Chengji,id from qp_sch_Chengji  where Kemu='" + Kemu + "' and Leixing='" + Leixing + "'  and XsId='" + XsId + "'  and Xueqi='" + this.Xueqi.SelectedValue + "'  and Xueduan='" + this.Xueduan.SelectedValue + "'  ";
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
                this.list.Bind_DropDownList_nothing(this.Leixing, sQL, "id", "name");
            }
            list.Close();
        }

        public void DataBindToGridview()
        {
            this.LTongji.Text = null;
            int num = 0;
            string sql = "select count(id) from qp_sch_Kecheng  where id in (" + this.pulicss.GetChecked(this.Kemu) + ")";
            num = this.List.GetCount(sql) + 8;
            this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 830px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
            object text = this.LTongji.Text;
            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"> <font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedItem.Text, "&nbsp;&nbsp;考试类型:", this.Leixing.SelectedItem.Text, "学生名次表</font></td> </tr>" });
            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
            this.LTongji.Text = this.LTongji.Text + "<td>序号</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>班级</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>姓名</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>学籍号</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>学号</td>";
            string str2 = "select id,Name,Dengji from qp_sch_Kecheng  where id in (" + this.pulicss.GetChecked(this.Kemu) + ") order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", list["Name"], "</td>" });
            }
            list.Close();
            this.LTongji.Text = this.LTongji.Text + "<td>总分</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>班级排名</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>年级排名</td></tr>";
            int num2 = 0;
            string str3 = "select C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and A.BanJi in (" + this.pulicss.GetChecked(this.BanJi) + ") order by A.BanJi asc";
            SqlDataReader reader2 = this.List.GetList(str3);
            while (reader2.Read())
            {
                num2++;
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num2, "</td>" });
                decimal num3 = 0M;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader2["BanJiName"], "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader2["Xingming"], "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader2["Xuejihao"], "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader2["Xuehao"], "</td>" });
                string str4 = "select id,Name,Dengji from qp_sch_Kecheng  where id in (" + this.pulicss.GetChecked(this.Kemu) + ") order by id asc";
                SqlDataReader reader3 = this.List.GetList(str4);
                while (reader3.Read())
                {
                    string s = this.ChengJiCode(reader3["id"].ToString(), this.Leixing.SelectedValue, reader2["id"].ToString());
                    this.LTongji.Text = this.LTongji.Text + "<td>" + s + "</td>";
                    num3 += decimal.Parse(s);
                }
                reader3.Close();
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num3, "</td>" });
                int num4 = 0;
                int num5 = 0;
                string str6 = "select sum(Chengji) as Mark,[A].[XsId] from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu in (" + this.pulicss.GetChecked(this.Kemu) + ") and A.Leixing='" + this.Leixing.SelectedValue + "'    and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  and D.Nianji='" + this.Nianji.SelectedValue + "'  group by [A].[XsId] order by Mark desc";
                SqlDataReader reader4 = this.List.GetList(str6);
                while (reader4.Read())
                {
                    num5++;
                    if (reader4["XsId"].ToString() == reader2["id"].ToString())
                    {
                        num4 = num5;
                    }
                }
                reader4.Close();
                int num6 = 0;
                int num7 = 0;
                string str7 = string.Concat(new object[] { "select sum(Chengji) as Mark,[A].[XsId] from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu in (", this.pulicss.GetChecked(this.Kemu), ") and A.Leixing='", this.Leixing.SelectedValue, "'    and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  and C.BanJi='", reader2["BanJi"], "'  group by [A].[XsId] order by Mark desc" });
                SqlDataReader reader5 = this.List.GetList(str7);
                while (reader5.Read())
                {
                    num7++;
                    if (reader5["XsId"].ToString() == reader2["id"].ToString())
                    {
                        num6 = num7;
                    }
                }
                reader5.Close();
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num4, "</td>" });
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


namespace xyoa.SchTable.Chengji.Chaxun
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Chaxun_ListJb : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected DropDownList ChaxuLx;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected CheckBoxList Kemu;
        protected Label Label1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label LTongji;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected DropDownList XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindXqXsiD()
        {
            string sql = "select C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["Nianji"] = this.divsch.TypeCode("Nianji", "qp_sch_Banji", list["BanJi"].ToString());
                this.ViewState["BanJi"] = list["BanJi"].ToString();
            }
            list.Close();
            string sQL = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.XsId='" + base.Request.QueryString["XsId"] + "' order by A.id asc";
            this.list.Bind_DropDownList_nothing(this.XsId, sQL, "id", "Xingming");
            string str3 = string.Concat(new object[] { "select * from qp_sch_Nianji where  NianjiMc='", this.ViewState["Nianji"], "' and Xueqi='", this.Xueqi.SelectedValue, "'" });
            SqlDataReader reader2 = this.List.GetList(str3);
            if (reader2.Read())
            {
                string str4;
                if (this.ChaxuLx.SelectedValue == "组合成绩")
                {
                    if (this.Xueduan.SelectedValue == "上学期")
                    {
                        str4 = "select id,Name  from qp_sch_Kecheng where id in (" + reader2["Kecheng"].ToString() + ") order by id asc";
                        this.list.Bind_DropDownList_CheckBoxList(this.Kemu, str4, "id", "Name");
                    }
                    else
                    {
                        str4 = "select id,Name  from qp_sch_Kecheng where id in (" + reader2["KechengX"].ToString() + ") order by id asc";
                        this.list.Bind_DropDownList_CheckBoxList(this.Kemu, str4, "id", "Name");
                    }
                    this.Kemu.Visible = true;
                }
                if (this.ChaxuLx.SelectedValue == "成绩总分")
                {
                    if (this.Xueduan.SelectedValue == "上学期")
                    {
                        str4 = "select id,Name  from qp_sch_Kecheng where id in (" + reader2["Kecheng"].ToString() + ") order by id asc";
                        this.list.Bind_DropDownList_CheckBoxList(this.Kemu, str4, "id", "Name");
                    }
                    else
                    {
                        str4 = "select id,Name  from qp_sch_Kecheng where id in (" + reader2["KechengX"].ToString() + ") order by id asc";
                        this.list.Bind_DropDownList_CheckBoxList(this.Kemu, str4, "id", "Name");
                    }
                    this.Kemu.Visible = true;
                }
                string str5 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + reader2["Kaoshilx"].ToString() + ") order by id asc";
                this.list.Bind_DropDownList_nothing(this.Leixing, str5, "id", "name");
            }
            reader2.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "学生" + this.XsId.SelectedItem.Text + "成绩表");
        }

        public string ChengJiBjAsc(string Kemu, string Leixing)
        {
            string str = null;
            string sql = string.Concat(new object[] { "select top 1 Chengji from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu='", Kemu, "' and A.Leixing='", Leixing, "'  and C.BanJi='", this.ViewState["BanJi"], "'  and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  order by convert(float(8),Chengji,8) asc" });
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

        public string ChengJiBjDesc(string Kemu, string Leixing)
        {
            string str = null;
            string sql = string.Concat(new object[] { "select top 1 Chengji from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu='", Kemu, "' and A.Leixing='", Leixing, "'  and C.BanJi='", this.ViewState["BanJi"], "'  and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  order by convert(float(8),Chengji,8) desc" });
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

        public string ChengJiCode(string Kemu, string Leixing)
        {
            string str = null;
            string sql = "select Chengji,id from qp_sch_Chengji  where Kemu='" + Kemu + "' and Leixing='" + Leixing + "'  and XsId='" + this.XsId.SelectedValue + "'  and Xueqi='" + this.Xueqi.SelectedValue + "'  and Xueduan='" + this.Xueduan.SelectedValue + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["id"].ToString();
            }
            else
            {
                str = "0";
            }
            list.Close();
            return str;
        }

        public string ChengJiCodeFenShu(string Kemu, string Leixing)
        {
            string str = null;
            string sql = "select Chengji,id from qp_sch_Chengji  where Kemu='" + Kemu + "' and Leixing='" + Leixing + "'  and XsId='" + this.XsId.SelectedValue + "'  and Xueqi='" + this.Xueqi.SelectedValue + "'  and Xueduan='" + this.Xueduan.SelectedValue + "'  ";
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

        public void DataBindToGridview()
        {
            string str;
            SqlDataReader list;
            int num;
            int num2;
            decimal num3;
            decimal num4;
            string str4;
            SqlDataReader reader2;
            int num5;
            decimal num6;
            decimal num7;
            int num8;
            string str5;
            SqlDataReader reader3;
            object text;
            if (this.ChaxuLx.SelectedValue == "组合成绩")
            {
                this.LTongji.Visible = true;
                this.LTongji.Text = null;
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 730px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"10\"> <font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedItem.Text, "&nbsp;&nbsp;班级:", this.ViewState["Nianji"], "&nbsp;&nbsp;姓名:", this.XsId.SelectedItem.Text, "&nbsp;&nbsp;考试类型:", this.Leixing.SelectedItem.Text, "</font></td> </tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\"><td>科目</td><td> 分数</td><td> 班级最高分数</td><td>班级最低分数</td><td>班级平均分</td><td>班级名次</td><td>年级平均分</td><td>年级名次</td><td>班级考试人数</td><td>年级考试人数</td></tr>";
                str = "select id,Name,Dengji from qp_sch_Kecheng  where id in (" + this.pulicss.GetChecked(this.Kemu) + ") order by id asc";
                list = this.List.GetList(str);
                while (list.Read())
                {
                    string str2 = "0";
                    string str3 = this.ChengJiCode(list["id"].ToString(), this.Leixing.SelectedValue);
                    num = 0;
                    num2 = 0;
                    num3 = 0M;
                    num4 = 0M;
                    str4 = string.Concat(new object[] { "select Chengji,A.id from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu='", list["id"].ToString(), "' and A.Leixing='", this.Leixing.SelectedValue, "'  and C.BanJi='", this.ViewState["BanJi"], "'  and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  order by convert(float(8),Chengji,8) desc" });
                    reader2 = this.List.GetList(str4);
                    while (reader2.Read())
                    {
                        num2++;
                        if (reader2["id"].ToString() == str3)
                        {
                            num = num2;
                            str2 = reader2["Chengji"].ToString();
                        }
                        num3 += decimal.Parse(reader2["Chengji"].ToString());
                    }
                    reader2.Close();
                    if (num2 == 0)
                    {
                        num4 = 0M;
                    }
                    else
                    {
                        num4 = num3 / num2;
                    }
                    num5 = 0;
                    num6 = 0M;
                    num7 = 0M;
                    num8 = 0;
                    str5 = string.Concat(new object[] { "select Chengji,A.id from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu='", list["id"].ToString(), "' and A.Leixing='", this.Leixing.SelectedValue, "'   and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  and D.Nianji='", this.ViewState["Nianji"], "'  order by convert(float(8),Chengji,8) desc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num5++;
                        if (reader3["id"].ToString() == str3)
                        {
                            num8 = num5;
                        }
                        num6 += decimal.Parse(reader3["Chengji"].ToString());
                    }
                    reader3.Close();
                    if (num5 == 0)
                    {
                        num7 = 0M;
                    }
                    else
                    {
                        num7 = num6 / num5;
                    }
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                    this.LTongji.Text = this.LTongji.Text + "<td>" + str2 + "</td>";
                    this.LTongji.Text = this.LTongji.Text + "<td>" + this.ChengJiBjDesc(list["id"].ToString(), this.Leixing.SelectedValue) + "</td>";
                    this.LTongji.Text = this.LTongji.Text + "<td>" + this.ChengJiBjAsc(list["id"].ToString(), this.Leixing.SelectedValue) + "</td>";
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", decimal.Round(num4, 2), "</td>" });
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num, "</td>" });
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", decimal.Round(num7, 2), "</td>" });
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num8, "</td>" });
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num2, "</td>" });
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr><td colspan=\"10\"><font color='red'>*注解：考试人数=已录入的成绩的参考人数。</font></td></tr></table>";
            }
            if (this.ChaxuLx.SelectedValue == "成绩总分")
            {
                this.LTongji.Visible = true;
                this.LTongji.Text = null;
                int num9 = 0;
                string sql = "select count(id) from qp_sch_Kecheng  where id in (" + this.pulicss.GetChecked(this.Kemu) + ")";
                num9 = this.List.GetCount(sql) + 9;
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 830px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num9, "\"> <font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedItem.Text, "&nbsp;&nbsp;班级:", this.ViewState["Nianji"], "&nbsp;&nbsp;姓名:", this.XsId.SelectedItem.Text, "&nbsp;&nbsp;考试类型:", this.Leixing.SelectedItem.Text, "</font></td> </tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
                string str7 = "select id,Name,Dengji from qp_sch_Kecheng  where id in (" + this.pulicss.GetChecked(this.Kemu) + ") order by id asc";
                SqlDataReader reader4 = this.List.GetList(str7);
                while (reader4.Read())
                {
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader4["Name"], "</td>" });
                }
                reader4.Close();
                this.LTongji.Text = this.LTongji.Text + "<td>总分</td><td>班级最高分数</td><td>班级最低分数</td><td>班级平均分</td><td>班级名次</td><td>年级平均分</td><td>年级名次</td><td>班级考试人数</td><td>年级考试人数</td></tr>";
                decimal num10 = 0M;
                string kemu = "0,";
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                str = "select id,Name,Dengji from qp_sch_Kecheng  where id in (" + this.pulicss.GetChecked(this.Kemu) + ") order by id asc";
                list = this.List.GetList(str);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + this.ChengJiCodeFenShu(list["id"].ToString(), this.Leixing.SelectedValue) + "</td>";
                    num10 += decimal.Parse(this.ChengJiCodeFenShu(list["id"].ToString(), this.Leixing.SelectedValue));
                    kemu = kemu + "" + list["id"].ToString() + ",";
                }
                list.Close();
                kemu = kemu + "0";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num10, "</td>" });
                this.LTongji.Text = this.LTongji.Text + "<td>" + this.ZF_ChengJiBjDesc(kemu, this.Leixing.SelectedValue) + "</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>" + this.ZF_ChengJiBjAsc(kemu, this.Leixing.SelectedValue) + "</td>";
                num = 0;
                num2 = 0;
                num3 = 0M;
                num4 = 0M;
                str4 = string.Concat(new object[] { "select sum(Chengji) as Mark,[A].[XsId] from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu in (", kemu, ") and A.Leixing='", this.Leixing.SelectedValue, "'  and C.BanJi='", this.ViewState["BanJi"], "'  and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  group by [A].[XsId] order by Mark desc" });
                reader2 = this.List.GetList(str4);
                while (reader2.Read())
                {
                    num2++;
                    if (reader2["XsId"].ToString() == this.XsId.SelectedValue)
                    {
                        num = num2;
                    }
                    num3 += decimal.Parse(reader2["Mark"].ToString());
                }
                reader2.Close();
                if (num2 == 0)
                {
                    num4 = 0M;
                }
                else
                {
                    num4 = num3 / num2;
                }
                num5 = 0;
                num6 = 0M;
                num7 = 0M;
                num8 = 0;
                str5 = string.Concat(new object[] { "select sum(Chengji) as Mark,[A].[XsId] from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId] inner join qp_sch_Banji as [D] on [D].[id] = [C].[BanJi]  where A.Kemu in (", kemu, ") and A.Leixing='", this.Leixing.SelectedValue, "'   and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  and D.Nianji='", this.ViewState["Nianji"], "'  group by [A].[XsId] order by Mark desc" });
                reader3 = this.List.GetList(str5);
                while (reader3.Read())
                {
                    num5++;
                    if (reader3["XsId"].ToString() == this.XsId.SelectedValue)
                    {
                        num8 = num5;
                    }
                    num6 += decimal.Parse(reader3["Mark"].ToString());
                }
                reader3.Close();
                if (num5 == 0)
                {
                    num7 = 0M;
                }
                else
                {
                    num7 = num6 / num5;
                }
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", decimal.Round(num4, 2), "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num, "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", decimal.Round(num7, 2), "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num8, "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num2, "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num9, "\"><font color='red'>*注解：考试人数=已录入的成绩的参考人数。</font></td></tr></table>" });
            }
        }

        protected void Miankao_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LTongji.Visible = false;
            this.BindXqXsiD();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianVis(this.Button1, "pppp3b", this.Session["perstr"].ToString());
                if (base.Request.QueryString["XsId"] != null)
                {
                    this.Panel1.Visible = false;
                    this.Panel2.Visible = true;
                    string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                    this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                    this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                    this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                    this.BindXqXsiD();
                }
                this.BindAttribute();
            }
        }

        protected void Xueduan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindXqXsiD();
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindXqXsiD();
        }

        public string ZF_ChengJiBjAsc(string Kemu, string Leixing)
        {
            string str = null;
            string sql = string.Concat(new object[] { "select TOP 1 sum(Chengji) as Mark from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu in (", Kemu, ") and A.Leixing='", Leixing, "'  and C.BanJi='", this.ViewState["BanJi"], "'  and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  group by [A].[XsId] order by Mark asc" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Mark"].ToString();
            }
            else
            {
                str = "0";
            }
            list.Close();
            return str;
        }

        public string ZF_ChengJiBjDesc(string Kemu, string Leixing)
        {
            string str = null;
            string sql = string.Concat(new object[] { "select TOP 1 sum(Chengji) as Mark from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu in (", Kemu, ") and A.Leixing='", Leixing, "'  and C.BanJi='", this.ViewState["BanJi"], "'  and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "'  group by [A].[XsId] order by Mark desc" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Mark"].ToString();
            }
            list.Close();
            return str;
        }
    }
}


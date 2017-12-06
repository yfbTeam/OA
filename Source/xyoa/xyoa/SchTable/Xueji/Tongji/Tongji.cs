namespace xyoa.SchTable.Xueji.Tongji
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Tongji : Page
    {
        protected HtmlButton Button1;
        protected Button Button4;
        protected Button Button5;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected RadioButtonList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label LTongji;
        protected DropDownList Nianji;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            this.DataBindToGridview();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "学生" + this.Leixing.SelectedItem.Text + "统计情况表");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Nianji.SelectedValue != "")
            {
                str = str + " and B.Name = '" + this.Nianji.SelectedValue + "'";
            }
            return str;
        }

        public string CreateMidSqlHeji()
        {
            string str = string.Empty;
            if (this.Nianji.SelectedValue != "")
            {
                str = str + " and D.Nianji = '" + this.Nianji.SelectedValue + "'";
            }
            return str;
        }

        public string CreateMidSqlZt()
        {
            string str = string.Empty;
            string str2 = this.divsch.TypeCodeDrLx("Name", "qp_sch_DataFile", "在校", "20");
            if ((((((this.Leixing.SelectedValue == "2") || (this.Leixing.SelectedValue == "3")) || ((this.Leixing.SelectedValue == "4") || (this.Leixing.SelectedValue == "5"))) || (((this.Leixing.SelectedValue == "6") || (this.Leixing.SelectedValue == "7")) || ((this.Leixing.SelectedValue == "8") || (this.Leixing.SelectedValue == "9")))) || (this.Leixing.SelectedValue == "10")) || (this.Leixing.SelectedValue == "11"))
            {
                return (str + " and A.XuejiZhuangtai='" + str2 + "'");
            }
            return (str + " and A.XuejiZhuangtai!='" + str2 + "'");
        }

        public string CreateNianJi()
        {
            string str = string.Empty;
            if (this.Xueqi.SelectedValue != "")
            {
                str = str + " and A.Xueqi = '" + this.Xueqi.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string str;
            int num;
            string str2;
            SqlDataReader list;
            string str3;
            SqlDataReader reader2;
            string str4;
            int num2;
            int num3;
            string str5;
            SqlDataReader reader3;
            string str6;
            SqlDataReader reader4;
            string str7;
            int count;
            string str8;
            SqlDataReader reader5;
            string str9;
            int num5;
            string str10;
            SqlDataReader reader6;
            string str11;
            int num6;
            object text;
            this.LTongji.Text = null;
            if (this.Leixing.SelectedValue == "1")
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                str = "select count(id) from  qp_sch_DataFile where type='20' and ifdel=0";
                num = this.List.GetCount(str) + 2;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_DataFile  where type='20' and ifdel=0 order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='20' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and A.XuejiZhuangtai='", reader4["id"], "'" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='20' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and A.XuejiZhuangtai='", reader4["id"], "'" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_DataFile  where type='20' and ifdel=0 order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  A.XuejiZhuangtai='", reader5["id"], "' and D.Nianji='", reader2["NianjiMc"], "'" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_DataFile  where type='20' and ifdel=0 order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  A.XuejiZhuangtai='", reader6["id"], "'  ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "2") || (this.Leixing.SelectedValue == "12"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                str = "select count(id) from  qp_sch_DataFile where type='15' and ifdel=0";
                num = this.List.GetCount(str) + 2;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_DataFile  where type='15' and ifdel=0 order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='15' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.HukouLeixing='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='15' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.HukouLeixing='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_DataFile  where type='15' and ifdel=0 order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.HukouLeixing='", reader5["id"], "' and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_DataFile  where type='15' and ifdel=0 order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.HukouLeixing='", reader6["id"], "'  ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "3") || (this.Leixing.SelectedValue == "13"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                num = 4;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_Tongji  where type='1' order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_Tongji  where type='1' order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.Xingbie='", reader4["Name"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_Tongji  where type='1' order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.Xingbie='", reader4["Name"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_Tongji  where type='1' order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.Xingbie='", reader5["Name"], "' and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_Tongji  where type='1' order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.Xingbie='", reader6["Name"], "'  ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "5") || (this.Leixing.SelectedValue == "15"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                num = 5;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_Tongji  where type='2' order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_Tongji  where type='2' order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and (CHARINDEX(',", reader4["Name"], ",',','+C.Sancan+',') > 0) ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_Tongji  where type='2' order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and (CHARINDEX(',", reader4["Name"], ",',','+C.Sancan+',') > 0) ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_Tongji  where type='2' order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  (CHARINDEX(',", reader5["Name"], ",',','+C.Sancan+',') > 0) and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_Tongji  where type='2' order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  (CHARINDEX(',", reader6["Name"], ",',','+C.Sancan+',') > 0) ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "6") || (this.Leixing.SelectedValue == "16"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                str = "select count(id) from  qp_sch_DataFile where type='16' and ifdel=0";
                num = this.List.GetCount(str) + 2;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_DataFile  where type='16' and ifdel=0 order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='16' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.HukouXingzhi='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='16' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.HukouXingzhi='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_DataFile  where type='16' and ifdel=0 order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.HukouXingzhi='", reader5["id"], "' and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_DataFile  where type='16' and ifdel=0 order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.HukouXingzhi='", reader6["id"], "'  ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "7") || (this.Leixing.SelectedValue == "17"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                str = "select count(id) from  qp_sch_DataFile where type='17' and ifdel=0";
                num = this.List.GetCount(str) + 2;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_DataFile  where type='17' and ifdel=0 order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='17' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.Mingzhu='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='17' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.Mingzhu='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_DataFile  where type='17' and ifdel=0 order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.Mingzhu='", reader5["id"], "' and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_DataFile  where type='17' and ifdel=0 order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.Mingzhu='", reader6["id"], "'  ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "8") || (this.Leixing.SelectedValue == "18"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                str = "select count(id) from  qp_sch_DataFile where type='18' and ifdel=0";
                num = this.List.GetCount(str) + 2;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_DataFile  where type='18' and ifdel=0 order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='18' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.Zhengzhimianmhao='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='18' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.Zhengzhimianmhao='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_DataFile  where type='18' and ifdel=0 order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.Zhengzhimianmhao='", reader5["id"], "' and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_DataFile  where type='18' and ifdel=0 order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.Zhengzhimianmhao='", reader6["id"], "'  ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "9") || (this.Leixing.SelectedValue == "19"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 730px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                str = "select count(id) from  qp_sch_DataFile where type='1' and ifdel=0";
                num = this.List.GetCount(str) + 2;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_DataFile  where type='1' and ifdel=0 order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='1' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and A.Zhiwu='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='1' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and A.Zhiwu='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_DataFile  where type='1' and ifdel=0 order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  A.Zhiwu='", reader5["id"], "' and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_DataFile  where type='1' and ifdel=0 order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  A.Zhiwu='", reader6["id"], "'  ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "10") || (this.Leixing.SelectedValue == "20"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 730px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                str = "select count(id) from  qp_sch_DataFile where type='14' and ifdel=0";
                num = this.List.GetCount(str) + 2;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_DataFile  where type='14' and ifdel=0 order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='14' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.Jiangkan='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id from qp_sch_DataFile  where type='14' and ifdel=0 order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.Jiangkan='", reader4["id"], "' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id from qp_sch_DataFile  where type='14' and ifdel=0 order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.Jiangkan='", reader5["id"], "' and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id from qp_sch_DataFile  where type='14' and ifdel=0 order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.Jiangkan='", reader6["id"], "'  ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
            if ((this.Leixing.SelectedValue == "11") || (this.Leixing.SelectedValue == "21"))
            {
                this.LTongji.Text = this.LTongji.Text + "<table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\">";
                num = 9;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\"> <td colspan=\"", num, "\"><font style='font-weight: bold; color: red'>", this.Xueqi.SelectedValue, "", this.Xueduan.SelectedValue, "&nbsp;&nbsp;学生", this.Leixing.SelectedItem.Text, "统计情况表</font></td></tr>" });
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" ><td>年级</td><td>班级</td>";
                str2 = "select Name from qp_sch_Tongji  where type='3' order by id asc";
                list = this.List.GetList(str2);
                while (list.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + list["Name"].ToString() + "</td>";
                }
                list.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                str3 = "select NianjiMc,RuxueBiye from qp_sch_Nianji as [A] inner join [qp_sch_SetSclClass] as [B] on [A].[NianjiMc] = [B].[Name] where  A.Xueqi='" + this.Xueqi.SelectedValue + "' " + this.CreateMidSql() + " order by Num asc";
                reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    str4 = string.Concat(new object[] { "select count(A.id) from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "'" });
                    num2 = this.List.GetCount(str4) + 1;
                    num3 = 0;
                    str5 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng  from [qp_sch_Banji] as [A] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", reader2["NianjiMc"], "' order by Mingcheng asc" });
                    reader3 = this.List.GetList(str5);
                    while (reader3.Read())
                    {
                        num3++;
                        if (num3 == 1)
                        {
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"", num2, "\">", reader2["NianjiMc"], "</td>" });
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id,FileName from qp_sch_Tongji  where type='3' order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.", reader4["FileName"], "='是' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        else
                        {
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                            text = this.LTongji.Text;
                            this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Mingcheng"], "</td>" });
                            str6 = "select Name,id,FileName from qp_sch_Tongji  where type='3' order by id asc";
                            reader4 = this.List.GetList(str6);
                            while (reader4.Read())
                            {
                                str7 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='", reader3["id"], "' and C.", reader4["FileName"], "='是' ", this.CreateMidSqlZt(), "" });
                                count = this.List.GetCount(str7);
                                text = this.LTongji.Text;
                                this.LTongji.Text = string.Concat(new object[] { text, "<td>", count, "</td>" });
                            }
                            reader4.Close();
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                    }
                    reader3.Close();
                    this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td>小计</td>";
                    str8 = "select Name,id,FileName from qp_sch_Tongji  where type='3' order by id asc";
                    reader5 = this.List.GetList(str8);
                    while (reader5.Read())
                    {
                        str9 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.", reader5["FileName"], "='是' and D.Nianji='", reader2["NianjiMc"], "' ", this.CreateMidSqlZt(), "" });
                        num5 = this.List.GetCount(str9);
                        text = this.LTongji.Text;
                        this.LTongji.Text = string.Concat(new object[] { text, "<td>", num5, "</td>" });
                    }
                    reader5.Close();
                    this.LTongji.Text = this.LTongji.Text + "</tr>";
                }
                reader2.Close();
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\" onclick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td  colspan=\"2\">合计</td>";
                str10 = "select Name,id,FileName from qp_sch_Tongji  where type='3' order by id asc";
                reader6 = this.List.GetList(str10);
                while (reader6.Read())
                {
                    str11 = string.Concat(new object[] { "select count(A.id) from  [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [D] on [D].[Id] = [A].[BanJi] where  C.", reader6["FileName"], "='是'  ", this.CreateMidSqlZt(), " ", this.CreateMidSqlHeji(), "" });
                    num6 = this.List.GetCount(str11);
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", num6, "</td>" });
                }
                reader6.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<tr><td colspan=\"", num, "\"><font color='red'>*注解：<br>1、在校学生数=软件内学籍状态为“在校”的学生数。<br>2、在籍学生数=软件内学籍状态不为“在校”的学生数。</font></td></tr></table>" });
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pulicss.QuanXianVis(this.Button1, "pppp2d", this.Session["perstr"].ToString());
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
                    this.Button4.Attributes["onclick"] = "javascript:return showwait();";
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                    string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                    this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                    this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                    this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                    string str2 = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  1=1 " + this.CreateNianJi() + " order by Num asc";
                    this.list.Bind_DropDownList_kong(this.Nianji, str2, "NianjiMc", "NianjiMc");
                }
            }
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  1=1 " + this.CreateNianJi() + " order by Num asc";
            this.list.Bind_DropDownList_kong(this.Nianji, sQL, "NianjiMc", "NianjiMc");
        }
    }
}


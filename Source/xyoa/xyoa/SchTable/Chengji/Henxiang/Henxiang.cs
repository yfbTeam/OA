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

    public class Henxiang : Page
    {
        protected CheckBoxList BanJi;
        protected HtmlButton Button1;
        protected HtmlButton Button2;
        protected Button Button6;
        protected Button Button7;
        protected CheckBox CheckBox1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Kemu;
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
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Leixing.SelectedItem.Text + "成绩表");
        }

        public string ChengJiBjAsc(string Kemu, string Leixing, string BanJi)
        {
            string str = null;
            string sql = "select top 1 Chengji from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu='" + Kemu + "' and A.Leixing='" + Leixing + "'  and C.BanJi='" + BanJi + "'  and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  order by convert(float(8),Chengji,8) asc";
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

        public string ChengJiBjDesc(string Kemu, string Leixing, string BanJi)
        {
            string str = null;
            string sql = "select top 1 Chengji from qp_sch_Chengji as [A] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu='" + Kemu + "' and A.Leixing='" + Leixing + "'  and C.BanJi='" + BanJi + "'  and A.Xueqi='" + this.Xueqi.SelectedValue + "'  and A.Xueduan='" + this.Xueduan.SelectedValue + "'  order by convert(float(8),Chengji,8) desc";
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
                    this.list.Bind_DropDownList_nothing(this.Kemu, str2, "id", "Name");
                }
                else
                {
                    str2 = "select id,Name  from qp_sch_Kecheng where id in (" + list["KechengX"].ToString() + ") order by id asc";
                    this.list.Bind_DropDownList_nothing(this.Kemu, str2, "id", "Name");
                }
                string sQL = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ") order by id asc";
                this.list.Bind_DropDownList_nothing(this.Leixing, sQL, "id", "name");
            }
            list.Close();
        }

        public void DataBindToGridview()
        {
            object obj2;
            string sql = "select * from qp_sch_Kecheng where id='" + this.Kemu.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["Youxiu1"] = list["Youxiu1"].ToString();
                this.ViewState["Youxiu2"] = list["Youxiu2"].ToString();
                this.ViewState["Lianghao1"] = list["Lianghao1"].ToString();
                this.ViewState["Lianghao2"] = list["Lianghao2"].ToString();
                this.ViewState["Hege1"] = list["Hege1"].ToString();
                this.ViewState["Hege2"] = list["Hege2"].ToString();
                this.ViewState["Bujige1"] = list["Bujige1"].ToString();
                this.ViewState["Bujige2"] = list["Bujige2"].ToString();
                this.ViewState["Jicha1"] = list["Jicha1"].ToString();
                this.ViewState["Jicha2"] = list["Jicha2"].ToString();
            }
            list.Close();
            this.LTongji.Text = null;
            this.LTongji.Text = this.LTongji.Text + " <table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\"><tr align=\"center\"><td colspan=\"11\">";
            string text = this.LTongji.Text;
            this.LTongji.Text = text + "<font style='font-weight: bold; color: red'>" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Leixing.SelectedItem.Text + "" + this.Kemu.SelectedItem.Text + "质量分析</font></td></tr>";
            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
            this.LTongji.Text = this.LTongji.Text + "<td>班级</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>班主任</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>实考人数</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>最高分</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>最低分</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>平均分</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>优秀人数</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>良好人数</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>合格人数</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>不及格人数</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>极差人数</td>";
            this.LTongji.Text = this.LTongji.Text + "</tr>";
            string str2 = "";
            string str3 = "select * from [qp_sch_Banji] as [A] where Xueqi='" + this.Xueqi.SelectedValue + "' and id in (" + this.pulicss.GetChecked(this.BanJi) + ")";
            SqlDataReader reader2 = this.List.GetList(str3);
            while (reader2.Read())
            {
                int count = 0;
                string str4 = string.Concat(new object[] { "select count(A.id) from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId]  where A.Kemu='", this.Kemu.SelectedValue, "' and A.Leixing='", this.Leixing.SelectedValue, "'  and C.BanJi='", reader2["Id"], "'  and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "' and Miankao='否' and Quekao='否'" });
                count = this.List.GetCount(str4);
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", reader2["Mingcheng"], "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", reader2["BzRealname"], "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", count, "</td>" });
                this.LTongji.Text = this.LTongji.Text + "<td>" + this.ChengJiBjDesc(this.Kemu.SelectedValue, this.Leixing.SelectedValue, reader2["id"].ToString()) + "</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>" + this.ChengJiBjAsc(this.Kemu.SelectedValue, this.Leixing.SelectedValue, reader2["id"].ToString()) + "</td>";
                decimal num2 = 0M;
                decimal d = 0M;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                int num7 = 0;
                int num8 = 0;
                string str5 = "";
                string str6 = "";
                string str7 = "";
                string str8 = "";
                string str9 = "";
                string str10 = string.Concat(new object[] { "select Chengji,A.id,D.Xingming from qp_sch_Chengji as [A] inner join [stu_table_", this.Xueqi.SelectedValue, "_", this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2"), "] as [C] on [A].[XsId] = [C].[XsId] inner join [qp_sch_Xuesheng] as [D] on [A].[XsId] = [D].[Id]  where A.Kemu='", this.Kemu.SelectedValue, "' and A.Leixing='", this.Leixing.SelectedValue, "'  and C.BanJi='", reader2["Id"], "'  and A.Xueqi='", this.Xueqi.SelectedValue, "'  and A.Xueduan='", this.Xueduan.SelectedValue, "' and Miankao='否' and Quekao='否'  order by convert(float(8),Chengji,8) desc" });
                SqlDataReader reader3 = this.List.GetList(str10);
                while (reader3.Read())
                {
                    if ((decimal.Parse(reader3["Chengji"].ToString()) >= decimal.Parse(this.ViewState["Youxiu1"].ToString())) && (decimal.Parse(reader3["Chengji"].ToString()) <= decimal.Parse(this.ViewState["Youxiu2"].ToString())))
                    {
                        num4++;
                        obj2 = str5;
                        str5 = string.Concat(new object[] { obj2, "", reader3["Xingming"], "(", reader3["Chengji"], ")," });
                    }
                    if ((decimal.Parse(reader3["Chengji"].ToString()) >= decimal.Parse(this.ViewState["Lianghao1"].ToString())) && (decimal.Parse(reader3["Chengji"].ToString()) <= decimal.Parse(this.ViewState["Lianghao2"].ToString())))
                    {
                        num5++;
                        obj2 = str6;
                        str6 = string.Concat(new object[] { obj2, "", reader3["Xingming"], "(", reader3["Chengji"], ")," });
                    }
                    if ((decimal.Parse(reader3["Chengji"].ToString()) >= decimal.Parse(this.ViewState["Hege1"].ToString())) && (decimal.Parse(reader3["Chengji"].ToString()) <= decimal.Parse(this.ViewState["Hege2"].ToString())))
                    {
                        num6++;
                        obj2 = str7;
                        str7 = string.Concat(new object[] { obj2, "", reader3["Xingming"], "(", reader3["Chengji"], ")," });
                    }
                    if ((decimal.Parse(reader3["Chengji"].ToString()) >= decimal.Parse(this.ViewState["Bujige1"].ToString())) && (decimal.Parse(reader3["Chengji"].ToString()) <= decimal.Parse(this.ViewState["Bujige2"].ToString())))
                    {
                        num7++;
                        obj2 = str8;
                        str8 = string.Concat(new object[] { obj2, "", reader3["Xingming"], "(", reader3["Chengji"], ")," });
                    }
                    if ((decimal.Parse(reader3["Chengji"].ToString()) >= decimal.Parse(this.ViewState["Jicha1"].ToString())) && (decimal.Parse(reader3["Chengji"].ToString()) <= decimal.Parse(this.ViewState["Jicha2"].ToString())))
                    {
                        num8++;
                        obj2 = str9;
                        str9 = string.Concat(new object[] { obj2, "", reader3["Xingming"], "(", reader3["Chengji"], ")," });
                    }
                    num2 += decimal.Parse(reader3["Chengji"].ToString());
                }
                reader3.Close();
                if (count == 0)
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>0</td>";
                }
                else
                {
                    d = num2 / count;
                    obj2 = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", decimal.Round(d, 2), "</td>" });
                }
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", num4, "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", num5, "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", num6, "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", num7, "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", num8, "</td>" });
                this.LTongji.Text = this.LTongji.Text + "</tr>";
                obj2 = str2;
                str2 = string.Concat(new object[] { obj2, "<tr onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td rowspan=\"5\">", reader2["Mingcheng"], "</td><td colspan=\"10\"><font color='red'>优秀：</font>", str5, "</td></tr><tr onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td colspan=\"10\"><font color='red'>良好：</font>", str6, "</td></tr><tr onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td colspan=\"10\"><font color='red'>合格：</font>", str7, "</td></tr><tr onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td colspan=\"10\"><font color='red'>不及格：</font>", str8, "</td></tr><tr onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\"><td colspan=\"10\"><font color='red'>极差：</font>", str9, "</td></tr>" });
            }
            reader2.Close();
            obj2 = this.LTongji.Text;
            this.LTongji.Text = string.Concat(new object[] { 
                obj2, "<tr><td colspan=\"11\"><font color='red'>*注解：<br>1.实考人数=已录入的成绩的参考人数，不含缺考和免考。<br>2.平均分=总分/实考人数<br>3.优秀:", this.ViewState["Youxiu1"], "-", this.ViewState["Youxiu2"], "&nbsp;&nbsp;良好:", this.ViewState["Lianghao1"], "-", this.ViewState["Lianghao2"], "&nbsp;&nbsp;合格:", this.ViewState["Hege1"], "-", this.ViewState["Hege2"], "&nbsp;&nbsp;不及格:", this.ViewState["Bujige1"], "-", 
                this.ViewState["Bujige2"], "&nbsp;&nbsp;极差:", this.ViewState["Jicha1"], "-", this.ViewState["Jicha2"], "</font></td></tr>"
             });
            this.LTongji.Text = this.LTongji.Text + str2;
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


namespace xyoa.SchTable.Xueji.Xuejika
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xuejika : Page
    {
        protected DropDownList BanJi;
        protected HtmlButton Button1;
        protected Button Button2;
        protected Button Button4;
        protected Button Button5;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
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
            this.list.Bind_DropDownList_kong(this.XsId, sQL, "id", "Xingming");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.pulicss.ToWordChe(this.GridView1, "学生学籍卡");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            this.DataBindToGridview();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            this.pulicss.ToExcelChe(this.GridView1, "学生学籍卡");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.XsId.SelectedValue != "")
            {
                str = str + " and A.XsId = '" + this.XsId.SelectedValue + "'";
            }
            if (this.BanJi.SelectedValue != "")
            {
                str = str + " and A.BanJi = '" + this.BanJi.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string str = "select A.XsId from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1";
            string sql = "" + str + " " + this.CreateMidSql() + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str4;
                Label label = (Label) e.Row.FindControl("GrXsId");
                Label label2 = (Label) e.Row.FindControl("Xingming");
                Label label3 = (Label) e.Row.FindControl("Xingbie");
                Label label4 = (Label) e.Row.FindControl("Chusheng");
                Image image = (Image) e.Row.FindControl("Zhaopian");
                Label label5 = (Label) e.Row.FindControl("Mingzhu");
                Label label6 = (Label) e.Row.FindControl("Jiguan");
                Label label7 = (Label) e.Row.FindControl("Chushengdi");
                Label label8 = (Label) e.Row.FindControl("Zhengzhimianmhao");
                Label label9 = (Label) e.Row.FindControl("Laiyuanxiao");
                Label label10 = (Label) e.Row.FindControl("Shengfenzheng");
                Label label11 = (Label) e.Row.FindControl("Jiangkan");
                Label label12 = (Label) e.Row.FindControl("Dianhua");
                Label label13 = (Label) e.Row.FindControl("Dizhi");
                Label label14 = (Label) e.Row.FindControl("Youbian");
                Label label15 = (Label) e.Row.FindControl("Tongxin");
                Label label16 = (Label) e.Row.FindControl("Youxiang");
                string sql = "select * from qp_sch_Xuesheng where  id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    label2.Text = list["Xingming"].ToString();
                    label3.Text = list["Xingbie"].ToString();
                    label4.Text = list["Chusheng"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    label5.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Mingzhu"].ToString());
                    label6.Text = list["Jiguan"].ToString();
                    label7.Text = list["Chushengdi"].ToString();
                    image.ImageUrl = "http://" + base.Request.Url.Authority + "" + list["Zhaopian"].ToString() + "";
                    label8.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Zhengzhimianmhao"].ToString());
                    label9.Text = list["Laiyuanxiao"].ToString();
                    label10.Text = list["Shengfenzheng"].ToString();
                    label11.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Jiangkan"].ToString());
                    label12.Text = list["Dianhua"].ToString();
                    label13.Text = list["Dizhi"].ToString();
                    label14.Text = list["Youbian"].ToString();
                    label15.Text = list["Tongxin"].ToString();
                    label16.Text = list["Youxiang"].ToString();
                }
                list.Close();
                Label label17 = (Label) e.Row.FindControl("JiaTingXinxi");
                label17.Text = "";
                label17.Text = label17.Text + "<table align=\"center\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\" style=\"width: 100%; border-collapse: collapse\"><tr><td colspan=\"7\"   style=\"height: 26px\">  <b>家庭信息</b></td> </tr>";
                label17.Text = label17.Text + " <tr bgcolor=\"#CBF1C7\">";
                label17.Text = label17.Text + "<td align=\"center\"  height=\"17\" width=\"15%\">成员姓名</td><td align=\"center\"  height=\"17\" width=\"15%\">关系</td><td align=\"center\"  height=\"17\" width=\"15%\">联系电话</td><td align=\"center\"  height=\"17\" width=\"15%\">电子信箱</td><td align=\"center\"  height=\"17\" width=\"15%\">联系地址</td><td align=\"center\"  height=\"17\" width=\"15%\">工作单位</td><td align=\"center\"  height=\"17\" width=\"10%\">休息日</td></tr>";
                string str2 = "select * from qp_sch_Stu_jtxx where  XsId='" + label.Text + "' order by id asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    label17.Text = label17.Text + " <tr>";
                    label17.Text = label17.Text + "<td>" + reader2["Xingming"].ToString() + "</td> ";
                    label17.Text = label17.Text + "<td>" + reader2["Guanxi"].ToString() + "</td> ";
                    label17.Text = label17.Text + "<td>" + reader2["Dianhua"].ToString() + "</td> ";
                    label17.Text = label17.Text + "<td>" + reader2["Xinxiang"].ToString() + "</td> ";
                    label17.Text = label17.Text + "<td>" + reader2["Dizhi"].ToString() + "</td> ";
                    label17.Text = label17.Text + "<td>" + reader2["Danwei"].ToString() + "</td> ";
                    label17.Text = label17.Text + "<td>" + reader2["Xiuxiri"].ToString() + "</td> ";
                    label17.Text = label17.Text + " </tr>";
                }
                reader2.Close();
                label17.Text = label17.Text + "</table>";
                Label label18 = (Label) e.Row.FindControl("Pingyu");
                label18.Text = "";
                label18.Text = label18.Text + "<table align=\"center\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\" style=\"width: 100%; border-collapse: collapse\"><tr><td  colspan=\"6\" style=\"height: 26px\"><b>学生评语</b></td></tr>";
                label18.Text = label18.Text + "<tr bgcolor=\"#CBF1C7\"><td align=\"center\"  height=\"17\" width=\"16%\">学期</td><td align=\"center\"  height=\"17\" width=\"16%\">学段</td> <td align=\"center\"  height=\"17\" width=\"16%\">班级</td><td align=\"center\"  height=\"17\" width=\"20%\">品德总评等第</td><td align=\"center\"  height=\"17\" width=\"16%\">评语</td><td align=\"center\"  height=\"17\" width=\"16%\">录入人</td></tr>";
                string str3 = "select * from qp_sch_Stu_jspy where  XsId='" + label.Text + "' order by id asc";
                SqlDataReader reader3 = this.List.GetList(str3);
                while (reader3.Read())
                {
                    str4 = "";
                    string str5 = "select BanJi from [stu_table_" + reader3["Xueqi"].ToString() + "_" + reader3["Xueduan"].ToString().Replace("上学期", "1").Replace("下学期", "2") + "] where  id='" + label.Text + "'";
                    SqlDataReader reader4 = this.List.GetList(str5);
                    if (reader4.Read())
                    {
                        str4 = this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", reader4["BanJi"].ToString());
                    }
                    reader4.Close();
                    label18.Text = label18.Text + " <tr>";
                    label18.Text = label18.Text + "<td >" + reader3["Xueqi"].ToString() + "</td> ";
                    label18.Text = label18.Text + "<td >" + reader3["Xueduan"].ToString() + "</td> ";
                    label18.Text = label18.Text + "<td >" + str4 + "</td> ";
                    label18.Text = label18.Text + "<td >" + this.divsch.TypeCode("Name", "qp_sch_DataFile", reader3["Zongpin"].ToString()) + "</td> ";
                    label18.Text = label18.Text + "<td >" + reader3["Pingyu"].ToString().Replace("\n", "<br>").Replace(" ", "&nbsp;&nbsp;") + "</td> ";
                    label18.Text = label18.Text + "<td >" + reader3["Realname"].ToString() + "</td> ";
                    label18.Text = label18.Text + " </tr>";
                }
                reader3.Close();
                label18.Text = label18.Text + "</table>";
                Label label19 = (Label) e.Row.FindControl("Chengji");
                label19.Text = "";
                label19.Text = label19.Text + "<table align=\"center\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\" style=\"width: 100%; border-collapse: collapse\"><tr><td  colspan=\"12\" style=\"height: 26px\"><b>成绩汇总</b></td></tr>";
                label19.Text = label19.Text + "<tr bgcolor=\"#CBF1C7\"><td align=\"center\"  height=\"17\" width=\"8%\">学期</td><td align=\"center\"  height=\"17\" width=\"8%\">学段</td><td align=\"center\"  height=\"17\" width=\"8%\">班级</td><td align=\"center\"  height=\"17\" width=\"10%\">考试科目</td><td align=\"center\"  height=\"17\" width=\"8%\">成绩</td><td align=\"center\"  height=\"17\" width=\"8%\">考试日期</td><td align=\"center\"  height=\"17\" width=\"10%\">考试类型</td><td align=\"center\"  height=\"17\" width=\"8%\">是否免考</td><td align=\"center\"  height=\"17\" width=\"8%\">是否缺考</td><td align=\"center\"  height=\"17\" width=\"8%\">是否补考</td><td align=\"center\"  height=\"17\" width=\"8%\">补考成绩</td><td align=\"center\"  height=\"17\" width=\"8%\">态度</td></tr>";
                string str6 = "select * from qp_sch_Chengji where  XsId='" + label.Text + "' order by id asc";
                SqlDataReader reader5 = this.List.GetList(str6);
                while (reader5.Read())
                {
                    str4 = "";
                    string str7 = "select BanJi from [stu_table_" + reader5["Xueqi"].ToString() + "_" + reader5["Xueduan"].ToString().Replace("上学期", "1").Replace("下学期", "2") + "] where  id='" + label.Text + "'";
                    SqlDataReader reader6 = this.List.GetList(str7);
                    if (reader6.Read())
                    {
                        str4 = this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", reader6["BanJi"].ToString());
                    }
                    reader6.Close();
                    label19.Text = label19.Text + " <tr>";
                    label19.Text = label19.Text + "<td >" + reader5["Xueqi"].ToString() + "</td> ";
                    label19.Text = label19.Text + "<td >" + reader5["Xueduan"].ToString() + "</td> ";
                    label19.Text = label19.Text + "<td >" + str4 + "</td> ";
                    label19.Text = label19.Text + "<td >" + this.divsch.TypeCode("Name", "qp_sch_Kecheng", reader5["Kemu"].ToString()) + "</td> ";
                    label19.Text = label19.Text + "<td >" + reader5["Chengji"].ToString() + "</td> ";
                    label19.Text = label19.Text + "<td >" + reader5["Riqi"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "") + "</td> ";
                    label19.Text = label19.Text + "<td >" + this.divsch.TypeCode("Name", "qp_sch_DataFile", reader5["Leixing"].ToString()) + "</td> ";
                    label19.Text = label19.Text + "<td >" + reader5["Miankao"].ToString() + "</td> ";
                    label19.Text = label19.Text + "<td >" + reader5["Quekao"].ToString() + "</td> ";
                    label19.Text = label19.Text + "<td >" + reader5["Bukao"].ToString() + "</td> ";
                    label19.Text = label19.Text + "<td >" + reader5["BukaoCj"].ToString() + "</td> ";
                    label19.Text = label19.Text + "<td >" + reader5["Taidu"].ToString() + "</td> ";
                    label19.Text = label19.Text + " </tr>";
                }
                reader3.Close();
                label19.Text = label19.Text + "</table>";
            }
        }

        protected void Nianji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
            this.list.Bind_DropDownList_nothing(this.BanJi, sQL, "id", "Mingcheng");
            string str2 = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.BanJi.SelectedValue + "' order by A.id asc";
            this.list.Bind_DropDownList_kong(this.XsId, str2, "id", "Xingming");
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
                    this.Button4.Attributes["onclick"] = "javascript:return showwait();";
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                    string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                    this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                    this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                    this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                    string str2 = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  1=1  order by Num asc";
                    this.list.Bind_DropDownList_nothing(this.Nianji, str2, "NianjiMc", "NianjiMc");
                    string str3 = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
                    this.list.Bind_DropDownList_nothing(this.BanJi, str3, "id", "Mingcheng");
                    string str4 = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.BanJi.SelectedValue + "' order by A.id asc";
                    this.list.Bind_DropDownList_kong(this.XsId, str4, "id", "Xingming");
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  1=1  order by Num asc";
            this.list.Bind_DropDownList_nothing(this.Nianji, sQL, "NianjiMc", "NianjiMc");
            string str2 = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
            this.list.Bind_DropDownList_nothing(this.BanJi, str2, "id", "Mingcheng");
            string str3 = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.BanJi.SelectedValue + "' order by A.id asc";
            this.list.Bind_DropDownList_kong(this.XsId, str3, "id", "Xingming");
        }
    }
}


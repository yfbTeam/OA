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

    public class Chaxun_Zh : Page
    {
        protected DropDownList BanJi;
        protected Button Button4;
        protected Button Button5;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected TextBox Endtime;
        protected HtmlButton FONT1;
        protected HtmlButton FONT2;
        protected HtmlButton FONT3;
        protected HtmlButton FONT4;
        protected HtmlButton FONT5;
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
        protected TextBox Startime;
        protected TextBox Xingming;
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
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Leixing.SelectedItem.Text + "成绩表");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Nianji.SelectedValue != "")
            {
                str = str + " and B.Nianji = '" + this.Nianji.SelectedValue + "'";
            }
            if (this.BanJi.SelectedValue != "")
            {
                str = str + " and A.BanJi = '" + this.BanJi.SelectedValue + "'";
            }
            if (this.Xingming.Text != "")
            {
                str = str + " and C.Xingming like '%" + this.pulicss.GetFormatStr(this.Xingming.Text) + "%'";
            }
            if ((this.Startime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and (E.Riqi between '" + this.Startime.Text + "'and  '" + this.Endtime.Text + "' or convert(char(10),cast(E.Riqi as datetime),120)=convert(char(10),cast('" + this.Startime.Text + "' as datetime),120) or convert(char(10),cast(E.Riqi as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120) ) ";
            }
            if (this.Leixing.SelectedValue != "")
            {
                str = str + " and E.Leixing = '" + this.Leixing.SelectedValue + "'";
            }
            if (this.Kemu.SelectedValue != "")
            {
                str = str + " and E.Kemu = '" + this.Kemu.SelectedValue + "'";
            }
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
                    this.list.Bind_DropDownList_kong(this.Kemu, str2, "id", "Name");
                }
                else
                {
                    str2 = "select id,Name  from qp_sch_Kecheng where id in (" + list["KechengX"].ToString() + ") order by id asc";
                    this.list.Bind_DropDownList_kong(this.Kemu, str2, "id", "Name");
                }
                string sQL = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ") order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "name");
            }
            list.Close();
        }

        public void DataBindToGridview()
        {
            this.LTongji.Text = null;
            this.LTongji.Text = this.LTongji.Text + " <table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\"><tr align=\"center\"><td colspan=\"9\">";
            string text = this.LTongji.Text;
            this.LTongji.Text = text + "<font style='font-weight: bold; color: red'>" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.Leixing.SelectedItem.Text + "成绩表综合查询</font></td></tr>";
            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
            this.LTongji.Text = this.LTongji.Text + "<td>序号</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>姓名</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>学籍号</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>学号</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>班级</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>考试时间</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>课程</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>考试类型</td>";
            this.LTongji.Text = this.LTongji.Text + "<td>成绩</td>";
            int num = 0;
            SqlDataReader list = this.List.GetList(("select E.Leixing,E.Riqi,E.Kemu,E.Chengji,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] inner join [qp_sch_Chengji] as [E] on [E].[XsId] = [A].[XsId] where 1=1") + this.CreateMidSql());
            while (list.Read())
            {
                num++;
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                object obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", num, "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", list["Xingming"], "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", list["Xuejihao"], "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", list["Xuehao"], "</td>" });
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", list["BanJiName"], "</td>" });
                this.LTongji.Text = this.LTongji.Text + "<td>" + DateTime.Parse(list["Riqi"].ToString()).ToShortDateString() + "</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_Kecheng", list["Kemu"].ToString()) + "</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Leixing"].ToString()) + "</td>";
                obj2 = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { obj2, "<td>", list["Chengji"], "</td>" });
                this.LTongji.Text = this.LTongji.Text + "</tr>";
            }
            list.Close();
            this.LTongji.Text = this.LTongji.Text + "</table>";
        }

        protected void Nianji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   Xueqi='" + this.Xueqi.SelectedValue + "' and Nianji='" + this.Nianji.SelectedValue + "' order by Num asc";
            this.list.Bind_DropDownList_kong(this.BanJi, sQL, "id", "Mingcheng");
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
                    this.Button4.Attributes["onclick"] = "javascript:return chknull();";
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                    string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                    this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                    this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                    this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                    string str2 = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  Xueqi='" + this.Xueqi.SelectedValue + "' order by Num asc";
                    this.list.Bind_DropDownList_nothing(this.Nianji, str2, "NianjiMc", "NianjiMc");
                    string str3 = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where   ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') and Xueqi='", this.Xueqi.SelectedValue, "' and Nianji='", this.Nianji.SelectedValue, "' order by Num asc" });
                    this.list.Bind_DropDownList_kong(this.BanJi, str3, "id", "Mingcheng");
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
            this.list.Bind_DropDownList_kong(this.BanJi, str2, "id", "Mingcheng");
            this.DataBindLx();
        }
    }
}


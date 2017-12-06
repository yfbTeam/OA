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

    public class Chaxun_Hz : Page
    {
        protected DropDownList BanJi;
        protected Button Button4;
        protected Button Button5;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlButton FONT1;
        protected HtmlButton FONT2;
        protected HtmlButton FONT3;
        protected HtmlButton FONT4;
        protected HtmlButton FONT5;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Kemu;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label LTongji;
        protected DropDownList Nianji;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
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
            this.pulicss.ToExcelChe(this.LTongji, "" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.BanJi.SelectedItem.Text + "" + this.Kemu.SelectedItem.Text + "成绩汇总");
        }

        public string ChengJiCode(string Leixing, string XsId)
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
            }
            list.Close();
        }

        public void DataBindToGridview()
        {
            object text;
            this.LTongji.Text = null;
            string str = "";
            string sql = "select * from qp_sch_Nianji where  NianjiMc='" + this.Nianji.SelectedValue + "' and Xueqi='" + this.Xueqi.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                int num = 0;
                string str3 = "select count(id) from qp_sch_DataFile  where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ")";
                num = this.List.GetCount(str3) + 4;
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, " <table id=\"showinfo\" style=\"width: 630px; border-collapse: collapse\" border=\"1\" bordercolor=\"black\" cellpadding=\"4\" cellspacing=\"0\"><tr align=\"center\"><td colspan=\"", num, "\">" });
                string str7 = this.LTongji.Text;
                this.LTongji.Text = str7 + "<font style='font-weight: bold; color: red'>" + this.Xueqi.SelectedValue + "" + this.Xueduan.SelectedValue + "" + this.BanJi.SelectedItem.Text + "" + this.Kemu.SelectedItem.Text + "成绩汇总</font></td></tr>";
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" bgcolor=\"#CBF1C7\">";
                this.LTongji.Text = this.LTongji.Text + "<td>序号</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>姓名</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>学籍号</td>";
                this.LTongji.Text = this.LTongji.Text + "<td>学号</td>";
                string str4 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ") order by id asc";
                SqlDataReader reader2 = this.List.GetList(str4);
                while (reader2.Read())
                {
                    text = this.LTongji.Text;
                    this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader2["Name"], "</td>" });
                }
                reader2.Close();
                str = list["Kaoshilx"].ToString();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
            }
            list.Close();
            int num2 = 0;
            SqlDataReader reader3 = this.List.GetList(("select C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1") + this.CreateMidSql());
            while (reader3.Read())
            {
                num2++;
                this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" onClick=\"if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this\">";
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", num2, "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Xingming"], "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Xuejihao"], "</td>" });
                text = this.LTongji.Text;
                this.LTongji.Text = string.Concat(new object[] { text, "<td>", reader3["Xuehao"], "</td>" });
                string str6 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + str + ") order by id asc";
                SqlDataReader reader4 = this.List.GetList(str6);
                while (reader4.Read())
                {
                    this.LTongji.Text = this.LTongji.Text + "<td>" + this.ChengJiCode(reader4["id"].ToString(), reader3["id"].ToString()) + "</td>";
                }
                reader4.Close();
                this.LTongji.Text = this.LTongji.Text + "</tr>";
            }
            reader3.Close();
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


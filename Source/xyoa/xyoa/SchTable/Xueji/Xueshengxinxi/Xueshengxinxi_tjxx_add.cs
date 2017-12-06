namespace xyoa.SchTable.Xueji.Xueshengxinxi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueshengxinxi_tjxx_add : Page
    {
        protected DropDownList Banji;
        protected TextBox Bibing;
        protected Button Button1;
        protected TextBox Danbai;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected TextBox Fei;
        protected TextBox Feiheliang;
        protected HtmlForm form1;
        protected TextBox Ganzang;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Meibo;
        protected DropDownList Pingjia;
        private publics pulicss = new publics();
        protected TextBox Qita;
        protected TextBox Sejue;
        protected TextBox Shayan1;
        protected TextBox Shayan2;
        protected TextBox Shengao;
        protected TextBox Shijian;
        protected TextBox Shili1;
        protected TextBox Shili2;
        protected TextBox Tizhong;
        protected TextBox Xinzang;
        protected TextBox Xiongwei;
        protected DropDownList XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;
        protected TextBox Xueya;
        protected TextBox Zhichi;

        protected void Banji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select C.id,C.Xingming  from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]).Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.Banji.SelectedValue + "' order by A.id asc";
            this.list.Bind_DropDownList_nothing(this.XsId, sQL, "id", "Xingming");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_sch_Stu_tjxx   (XsId,Xueqi,Xueduan,Pingjia,Shijian,Shengao,Tizhong,Xiongwei,Feiheliang,Xueya,Meibo,Shili1,Shili2,Shayan1,Shayan2,Sejue,Bibing,Zhichi,Xinzang,Fei,Ganzang,Danbai,Qita) values ('" + this.XsId.SelectedValue + "','" + this.Xueqi.SelectedValue + "','" + this.Xueduan.SelectedValue + "','" + this.Pingjia.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Shijian.Text) + "','" + this.pulicss.GetFormatStr(this.Shengao.Text) + "','" + this.pulicss.GetFormatStr(this.Tizhong.Text) + "','" + this.pulicss.GetFormatStr(this.Xiongwei.Text) + "','" + this.pulicss.GetFormatStr(this.Feiheliang.Text) + "','" + this.pulicss.GetFormatStr(this.Xueya.Text) + "','" + this.pulicss.GetFormatStr(this.Meibo.Text) + "','" + this.pulicss.GetFormatStr(this.Shili1.Text) + "','" + this.pulicss.GetFormatStr(this.Shili2.Text) + "','" + this.pulicss.GetFormatStr(this.Shayan1.Text) + "','" + this.pulicss.GetFormatStr(this.Shayan2.Text) + "','" + this.pulicss.GetFormatStr(this.Sejue.Text) + "','" + this.pulicss.GetFormatStr(this.Bibing.Text) + "','" + this.pulicss.GetFormatStr(this.Zhichi.Text) + "','" + this.pulicss.GetFormatStr(this.Xinzang.Text) + "','" + this.pulicss.GetFormatStr(this.Fei.Text) + "','" + this.pulicss.GetFormatStr(this.Ganzang.Text) + "','" + this.pulicss.GetFormatStr(this.Danbai.Text) + "','" + this.pulicss.GetFormatStr(this.Qita.Text) + "')";
            this.List.ExeSql(sql);
            string str2 = "Update qp_sch_Xuesheng     Set Jiangkan='" + this.Pingjia.SelectedValue + "' where   id='" + this.XsId.SelectedValue + "'";
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("新增体检信息[" + this.XsId.SelectedItem.Text + "]", "体检信息");
            if (base.Request.QueryString["XsId"] != null)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_tjxx.aspx?XsId=" + base.Request.QueryString["XsId"] + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xueshengxinxi_tjxx.aspx?id=" + this.Banji.SelectedValue + "&Xueduan=" + base.Request.QueryString["Xueduan"] + "&Xueqi=" + base.Request.QueryString["Xueqi"] + "'</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string str5;
                this.Shijian.Text = DateTime.Now.ToShortDateString();
                string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                string str2 = "select id,name  from qp_sch_DataFile where type='14' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_nothing(this.Pingjia, str2, "id", "name");
                this.Xueqi.SelectedValue = this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]);
                this.Xueduan.SelectedValue = this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]);
                string str3 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='", this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]), "' and ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
                this.list.Bind_DropDownList_nothing(this.Banji, str3, "id", "Mingcheng");
                if (base.Request.QueryString["XsId"] != null)
                {
                    string sql = "select * from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]) + "] where  XsId='" + this.pulicss.GetFormatStr(base.Request.QueryString["XsId"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Banji.SelectedValue = list["BanJi"].ToString();
                        str5 = "select C.id,C.Xingming  from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]).Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.Banji.SelectedValue + "' order by A.id asc";
                        this.list.Bind_DropDownList_nothing(this.XsId, str5, "id", "Xingming");
                        this.XsId.SelectedValue = list["XsId"].ToString();
                    }
                    list.Close();
                    this.Banji.Enabled = false;
                    this.XsId.Enabled = false;
                }
                else
                {
                    if ((base.Request.QueryString["Banji"] != null) && (base.Request.QueryString["Banji"].ToString() != "all"))
                    {
                        this.Banji.SelectedValue = base.Request.QueryString["Banji"].ToString();
                    }
                    str5 = "select C.id,C.Xingming  from [stu_table_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueqi"]) + "_" + this.pulicss.GetFormatStr(base.Request.QueryString["Xueduan"]).Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + this.Banji.SelectedValue + "' order by A.id asc";
                    this.list.Bind_DropDownList_nothing(this.XsId, str5, "id", "Xingming");
                }
            }
        }
    }
}


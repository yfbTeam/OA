namespace xyoa.SchTable.Xueji.ZaijiSheng
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZaijiSheng_dc : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected Label Label2;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label LTongji;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.pulicss.ToExcelChe(this.LTongji, "" + this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", base.Request.QueryString["id"].ToString()) + "学生信息");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if (base.Request.QueryString["id"] != null)
                {
                    if (base.Request.QueryString["id"].ToString() == "0")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                        this.Panel2.Visible = true;
                        this.Label2.Text = this.Label2.Text + "" + this.divsch.TypeCode("Mingcheng", "qp_sch_Banji", base.Request.QueryString["id"].ToString()) + "";
                        this.LTongji.Text = "";
                        this.LTongji.Text = this.LTongji.Text + "<table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" bordercolor=\"#000000\" style=\"border-collapse: collapse\"  id=\"oTable\">";
                        this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" height=\"18\" bgcolor=\"#CBF1C7\">";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\" height=\"18\">学生姓名</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">学籍号</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">学号</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">考号</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">是否住校</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">性别</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">出生日期</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">民族</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">籍贯</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">出生地</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">入校时间</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">入学成绩</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">政治面貌</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">来源校(园)</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">学籍状态</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">职务</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">身份证号</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">健康状况</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">生源类别</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">联系电话</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">家庭住址</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">邮编</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">通信地址</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">电子邮箱</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">户口类型</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">户口性质</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">三残</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">留守儿童</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">农民工子女</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">军人子女</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">教师子女</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">单亲家庭</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">独生子女</td>";
                        this.LTongji.Text = this.LTongji.Text + "<td width=\"86\">贫困生</td>";
                        this.LTongji.Text = this.LTongji.Text + "</tr>";
                        string sql = "select top 10 B.Nianji as BNianji,A.XuejiZhuangtai as AXuejiZhuangtai,A.Zhiwu as AZhiwu,C.* from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and A.BanJi='" + base.Request.QueryString["id"].ToString() + "'";
                        SqlDataReader list = this.List.GetList(sql);
                        while (list.Read())
                        {
                            string str2 = "";
                            if (list["BNianji"].ToString().IndexOf("小") >= 0)
                            {
                                str2 = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Shengyuan"].ToString());
                            }
                            if (list["BNianji"].ToString().IndexOf("初") >= 0)
                            {
                                str2 = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Shengyuan"].ToString());
                            }
                            if (list["BNianji"].ToString().IndexOf("高") >= 0)
                            {
                                str2 = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Shengyuan"].ToString());
                            }
                            this.LTongji.Text = this.LTongji.Text + "<tr align=\"center\" height=\"18\">";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Xingming"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Xuejihao"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Xuehao"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Kaohao"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Zhuxiao"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Xingbie"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Chusheng"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "") + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Mingzhu"].ToString()) + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Jiguan"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Chushengdi"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["RuxiaoShijian"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["RuxiaoChengji"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Zhengzhimianmhao"].ToString()) + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Laiyuanxiao"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_DataFile", list["AXuejiZhuangtai"].ToString()) + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_DataFile", list["AZhiwu"].ToString()) + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Shengfenzheng"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Jiangkan"].ToString()) + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + str2 + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Dianhua"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Dizhi"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Youbian"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Tongxin"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Youxiang"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_DataFile", list["HukouLeixing"].ToString()) + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + this.divsch.TypeCode("Name", "qp_sch_DataFile", list["HukouXingzhi"].ToString()) + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Sancan"].ToString().Replace("0,", "").Replace(",0", "") + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["LiushouErtong"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Nongminggao"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Junrenzinv"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Jiaoshizinv"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Danqinjiating"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Dushengzinv"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "<td>" + list["Pingkunsheng"].ToString() + "</td>";
                            this.LTongji.Text = this.LTongji.Text + "</tr>";
                        }
                        list.Close();
                        this.LTongji.Text = this.LTongji.Text + "</table>";
                    }
                }
                else
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                }
            }
        }
    }
}


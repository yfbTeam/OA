namespace xyoa.SchTable.Sushe.Chaxun
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Chaxun_Ss : Page
    {
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected Label Label2;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected Label Xueduan;
        protected Label Xueqi;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Xueqi.Text = this.divsch.GetXueqi();
                this.Xueduan.Text = this.divsch.GetXueduan();
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
                        this.Label2.Text = null;
                        int num = 0;
                        this.Label2.Text = this.Label2.Text + " <table border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                        this.Label2.Text = this.Label2.Text + "<tr>";
                        string sql = "select '" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,C.Zhaopian,C.Dianhua,C.id,C.Sushe,C.Xingming,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.Text + "_" + this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where C.Sushe='" + base.Request.QueryString["id"] + "'";
                        SqlDataReader list = this.List.GetList(sql);
                        while (list.Read())
                        {
                            this.Label2.Text = this.Label2.Text + "<td><table width=\"313\" height=\"100\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\" bgcolor=\"#0000FF\"><tr><td bgcolor=\"#FFFFFF\">";
                            this.Label2.Text = this.Label2.Text + "<table width=\"313\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr><td width=\"84\" rowspan=\"3\"><img src=\"" + list["Zhaopian"].ToString() + "\" width=\"84\" height=\"100\" /></td>";
                            object text = this.Label2.Text;
                            this.Label2.Text = string.Concat(new object[] { text, "<td width=\"229\" valign=\"top\"><a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"/SchTable/Xueji/ZaijiSheng/ZaijiSheng_lb_show.aspx?id=", list["id"], "&Xueduan=", this.Xueduan.Text.Replace("上学期", "1").Replace("下学期", "2"), "&Xueqi=", this.Xueqi.Text, "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'><font color=\"#008000\"><b>姓名：", list["Xingming"], "</b></font></a></td></tr>" });
                            text = this.Label2.Text;
                            this.Label2.Text = string.Concat(new object[] { text, "<tr><td valign=\"top\"><font color=\"#FF0000\"><b>班级：", list["BanJiName"], "</b></font></td></tr><tr>" });
                            text = this.Label2.Text;
                            this.Label2.Text = string.Concat(new object[] { text, "<td valign=\"top\"><font color=\"#008000\"><b>电话：", list["Dianhua"], "</b></font></td></tr></table></td>" });
                            this.Label2.Text = this.Label2.Text + "</tr></table></td>";
                            num++;
                            if (num == 2)
                            {
                                this.Label2.Text = this.Label2.Text + " </tr><tr>";
                                num = 0;
                            }
                        }
                        this.Label2.Text = this.Label2.Text + " </table>";
                        list.Close();
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


namespace xyoa.PublicWork.BumenPage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Zhuye_list : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected GridView GridView2;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label mx;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                this.pulicss.QuanXianBack("jjjja2a", this.Session["perstr"].ToString());
                string sql = "select A.id,B.[Name] as BuMenName from [qp_oa_BumenZy] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] where  A.id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["BuMenName"] = list["BuMenName"].ToString();
                }
                list.Close();
                this.mx.Text = null;
                string str2 = string.Concat(new object[] { "select A.id,A.Leixing from [qp_oa_BumenWzLb] as [A] inner join [qp_oa_BumenZy] as [B] on [A].[LeibieId] = [B].[Id] where  A.LeibieId='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId1+',') > 0 and States1='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername1+',') > 0 and States1='3') or (States1='1')) order by A.paixun asc" });
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    this.mx.Text = this.mx.Text + "<table cellspacing=\"1\" cellpadding=\"4\" border=\"0\" id=\"GridView1\" style=\"background-color: #E0E0E0; border-color: #4D77B1; border-width: 1px; border-style: None; width: 100%; font-size: 12px\">";
                    object text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<tr  style=\"color: #E7E7FF; background-color: #4A3C8C; font-weight: bold; white-space: nowrap;\"><td class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\"><a  href='Zhuye_lb_list.aspx?WzLeibie=", reader2["id"], "&ZhuyeId=", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'><font color=", this.pulicss.GetHeadBackColor(), ">", reader2["Leixing"], "..</font></a></td>" });
                    string str3 = "select top 7 A.id,A.ZhuyeId,A.titles,A.Settime,A.Username,A.Realname,B.[Name] as BuMenName from [qp_oa_BumenWz] as [A] inner join [qp_oa_BumenZy] as [C] on [A].[ZhuyeId] = [C].[Id] inner join [qp_oa_Bumen] as [B] on [C].[BuMenId] = [B].[Id] inner join [qp_oa_BumenWzLb] as [D] on [A].[WzLeibie] = [D].[Id]  where WzLeibie='" + reader2["id"] + "' order by A.id desc";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    while (reader3.Read())
                    {
                        text = this.mx.Text;
                        this.mx.Text = string.Concat(new object[] { text, "<tr style=\"color: Black; background-color: #FBFCFE;\"><td style=\"white-space: nowrap;\"><img src=\"/oaimg/point.gif\" />&nbsp;<a  href='Zhuye_show.aspx?key=2&id=", reader3["id"], "&ZhuyeId=", reader3["ZhuyeId"], "'>", reader3["Titles"], "&nbsp;(", reader3["BuMenName"], " → ", reader3["Realname"], "  ", DateTime.Parse(reader3["Settime"].ToString()).ToShortDateString(), ")</a></td>" });
                    }
                    reader3.Close();
                    this.mx.Text = this.mx.Text + "</table><br>";
                }
                reader2.Close();
                this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
                string str4 = string.Concat(new object[] { "select top 7 A.id,A.ZhuyeId,A.titles,A.Settime,A.Username,A.Realname,B.[Name] as BuMenName from [qp_oa_BumenWz] as [A] inner join [qp_oa_BumenZy] as [C] on [A].[ZhuyeId] = [C].[Id] inner join [qp_oa_Bumen] as [B] on [C].[BuMenId] = [B].[Id] inner join [qp_oa_BumenWzLb] as [D] on [A].[WzLeibie] = [D].[Id]  where datediff(dd,getdate(),Settime)=0 and  A.ZhuyeId='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+C.ZdBumenId1+',') > 0 and C.States1='2') or (CHARINDEX(',", this.Session["username"], ",',','+C.ZdUsername1+',') > 0 and C.States1='3') or (C.States1='1')) order by A.id desc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
                this.GridView1.DataBind();
                this.GridView2.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
                string str5 = string.Concat(new object[] { "select top 7 A.id,A.ZhuyeId,A.titles,A.Settime,A.Username,A.Realname,B.[Name] as BuMenName from [qp_oa_BumenWz] as [A] inner join [qp_oa_BumenZy] as [C] on [A].[ZhuyeId] = [C].[Id] inner join [qp_oa_Bumen] as [B] on [C].[BuMenId] = [B].[Id] inner join [qp_oa_BumenWzLb] as [D] on [A].[WzLeibie] = [D].[Id]  where datediff(dd,Settime,getdate())<=10  and datediff(dd,Settime,getdate())>=0 and  A.ZhuyeId='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+C.ZdBumenId1+',') > 0 and C.States1='2') or (CHARINDEX(',", this.Session["username"], ",',','+C.ZdUsername1+',') > 0 and C.States1='3') or (C.States1='1')) order by A.id desc" });
                this.GridView2.DataSource = this.List.GetGrid_Pages_not(str5);
                this.GridView2.DataBind();
            }
        }
    }
}


﻿namespace xyoa.PublicWork.BumenPage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenWh : Page
    {
        protected HtmlForm form1;
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
                this.pulicss.QuanXianBack("jjjja2b", this.Session["perstr"].ToString());
                this.mx.Text = null;
                string sql = string.Concat(new object[] { "select id,Leixing from qp_oa_BumenZyLb where  (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by paixun asc" });
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    this.mx.Text = this.mx.Text + "<table cellspacing=\"1\" cellpadding=\"5\" border=\"0\" id=\"GridView1\" style=\"background-color: #E0E0E0; border-color: #4D77B1; border-width: 1px; border-style: None; width: 100%; font-size: 12px\">";
                    object text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<tr onmouseover=\"javascript:setMouseOverColor(this);\" onmouseout=\"javascript:setMouseOutColor(this);\"  style=\"color: #E7E7FF; background-color: #4A3C8C; font-weight: bold; white-space: nowrap;\"><td class=\"newtitle\" scope=\"col\" style=\"color: ", this.pulicss.GetHeadBackColor(), "; white-space: nowrap;\">", list["Leixing"], "</td>" });
                    string str2 = string.Concat(new object[] { "select A.id,B.[Name] as BuMenName from [qp_oa_BumenZy] as [A] inner join [qp_oa_Bumen] as [B] on [A].[BuMenId] = [B].[Id] where LeibieId='", list["id"], "' and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) order by A.paixun asc" });
                    SqlDataReader reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        text = this.mx.Text;
                        this.mx.Text = string.Concat(new object[] { text, "<tr onmouseover=\"javascript:setMouseOverColor(this);\" onmouseout=\"javascript:setMouseOutColor(this);\"  style=\"color: Black; background-color: #FBFCFE;\"><td style=\"white-space: nowrap;\"><img src=\"/oaimg/point.gif\" />&nbsp;", reader2["BuMenName"], "&nbsp;&nbsp;&nbsp;&nbsp; [<a href=BumenWzLb_wh.aspx?id=", reader2["id"], ">文章类别</a> ， <a href=BumenWz_wh.aspx?id=", reader2["id"], ">管理文章</a>]</td>" });
                    }
                    reader2.Close();
                    this.mx.Text = this.mx.Text + "</table><br><br>";
                }
                list.Close();
            }
        }
    }
}


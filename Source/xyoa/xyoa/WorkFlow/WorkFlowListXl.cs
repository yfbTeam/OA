namespace xyoa.WorkFlow
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListXl : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label mx;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=ExcelFile.xls");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/excel";
            base.Response.Write(this.mx.Text);
            base.Response.End();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListXlSearch.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if ((base.Request.QueryString["Starttime"].ToString() != "") && (base.Request.QueryString["Endtime"].ToString() != ""))
            {
                str = str + " and (NowTimes between '" + base.Request.QueryString["Starttime"].ToString() + "'and  '" + base.Request.QueryString["Endtime"].ToString() + "' or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Starttime"].ToString() + "' as datetime),120) or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Endtime"].ToString() + "' as datetime),120) ) ";
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                object text;
                string str = null;
                string sql = "select username  from qp_oa_username where id in (" + base.Request.QueryString["UserId"] + ")";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    text = str;
                    str = string.Concat(new object[] { text, "'", list["username"], "'," });
                }
                list.Close();
                str = str + "'0'";
                this.mx.Text = null;
                this.mx.Text = this.mx.Text + "<table cellspacing=\"1\" cellpadding=\"5\" border=\"0\" id=\"GridView1\" style=\"background-color: #4D77B1; border-color: #4D77B1; border-width: 1px; border-style: None; width: 100%; font-size: 12px\">";
                this.mx.Text = this.mx.Text + "<tr onmouseover=\"javascript:setMouseOverColor(this);\" onmouseout=\"javascript:setMouseOutColor(this);\"style=\"color: #E7E7FF; background-color: #4A3C8C; font-weight: bold; white-space: nowrap;\"><th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">姓名</th>";
                string str3 = "select FlowName  from qp_oa_WorkFlowName where id in (" + base.Request.QueryString["FlowId"] + ") order by Paixun asc";
                SqlDataReader reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    this.mx.Text = this.mx.Text + "<th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">" + reader2["FlowName"].ToString() + "</th>";
                }
                reader2.Close();
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">小计</th></tr>";
                string str4 = "select username,realname from qp_oa_username where id in (" + base.Request.QueryString["UserId"] + ") order by id desc";
                SqlDataReader reader3 = this.List.GetList(str4);
                while (reader3.Read())
                {
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<tr onmouseover=\"javascript:setMouseOverColor(this);\" onmouseout=\"javascript:setMouseOutColor(this);\"  style=\"color: Black; background-color: #FBFCFE;\"><td align=\"center\" style=\"white-space: nowrap;\">", reader3["realname"], "</td>" });
                    string str5 = "select id  from qp_oa_WorkFlowName where id in (" + base.Request.QueryString["FlowId"] + ") order by Paixun asc";
                    SqlDataReader reader4 = this.List.GetList(str5);
                    while (reader4.Read())
                    {
                        decimal num = 0M;
                        string str6 = string.Concat(new object[] { "select C.id,C.StartTime,C.EndTime,B.XbTimes  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile inner join [qp_oa_WorkFlowNode] as [B] on [B].NodeNum=[C].[XuHao] and [B].FlowNumber=[A].[FlowNumber]  where A.FlowId ='", reader4["id"], "' ", this.CreateMidSql(), " and [C].BLusername='", reader3["username"], "' and A.Shuxing='固定流程' and (C.States='已委托' or C.States='已办结') and C.EndTime!='1900-1-1' group by C.id,C.StartTime,C.EndTime,B.XbTimes" });
                        SqlDataReader reader5 = this.List.GetList(str6);
                        while (reader5.Read())
                        {
                            TimeSpan span = (TimeSpan) (DateTime.Parse(reader5["StartTime"].ToString()).AddHours(double.Parse(reader5["XbTimes"].ToString())) - DateTime.Parse(reader5["EndTime"].ToString()));
                            string s = "" + Math.Round((double) (span.TotalSeconds / 3600.0), 2) + "";
                            num += decimal.Parse(s);
                        }
                        reader5.Close();
                        text = this.mx.Text;
                        this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\"><a href='javascript:void(0)' onclick='window.open (\"WorkFlowListXl_show.aspx?FlowIdAll=", base.Request.QueryString["FlowId"], "&UserId=", base.Request.QueryString["UserId"], "&Starttime=", base.Request.QueryString["Starttime"], "&Endtime=", base.Request.QueryString["Endtime"], "&key=1&user=", reader3["username"], "&FlowId=", reader4["id"], "\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>", num, "</a></td>" });
                    }
                    decimal num2 = 0M;
                    string str8 = string.Concat(new object[] { "select C.id,C.StartTime,C.EndTime,B.XbTimes  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile inner join [qp_oa_WorkFlowNode] as [B] on [B].NodeNum=[C].[XuHao] and [B].FlowNumber=[A].[FlowNumber]  where A.FlowId  in (", base.Request.QueryString["FlowId"], ") ", this.CreateMidSql(), " and [C].BLusername='", reader3["username"], "' and A.Shuxing='固定流程' and (C.States='已委托' or C.States='已办结') and C.EndTime!='1900-1-1' group by C.id,C.StartTime,C.EndTime,B.XbTimes" });
                    SqlDataReader reader6 = this.List.GetList(str8);
                    while (reader6.Read())
                    {
                        TimeSpan span2 = (TimeSpan) (DateTime.Parse(reader6["StartTime"].ToString()).AddHours(double.Parse(reader6["XbTimes"].ToString())) - DateTime.Parse(reader6["EndTime"].ToString()));
                        string str9 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                        num2 += decimal.Parse(str9);
                    }
                    reader6.Close();
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\"><b><a href='javascript:void(0)' onclick='window.open (\"WorkFlowListXl_showLc.aspx?FlowIdAll=", base.Request.QueryString["FlowId"], "&UserId=", base.Request.QueryString["UserId"], "&Starttime=", base.Request.QueryString["Starttime"], "&Endtime=", base.Request.QueryString["Endtime"], "&key=1&user=", reader3["username"], "&FlowId=0\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>", num2, "</a></b></td></tr>" });
                }
                reader3.Close();
                this.mx.Text = this.mx.Text + "<tr onmouseover=\"javascript:setMouseOverColor(this);\" onmouseout=\"javascript:setMouseOutColor(this);\"  style=\"color: Black; background-color: #FBFCFE;\"><td align=\"center\" style=\"white-space: nowrap;\"><b><font color=red>合计</font></b></td>";
                string str10 = "select id  from qp_oa_WorkFlowName where id in (" + base.Request.QueryString["FlowId"] + ") order by Paixun asc";
                SqlDataReader reader7 = this.List.GetList(str10);
                while (reader7.Read())
                {
                    decimal num3 = 0M;
                    string str11 = string.Concat(new object[] { "select C.id,C.StartTime,C.EndTime,B.XbTimes  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile inner join [qp_oa_WorkFlowNode] as [B] on [B].NodeNum=[C].[XuHao] and [B].FlowNumber=[A].[FlowNumber]  where A.FlowId ='", reader7["id"], "' ", this.CreateMidSql(), " and [C].BLusername  in (", str, ") and A.Shuxing='固定流程' and (C.States='已委托' or C.States='已办结') and C.EndTime!='1900-1-1' group by C.id,C.StartTime,C.EndTime,B.XbTimes" });
                    SqlDataReader reader8 = this.List.GetList(str11);
                    while (reader8.Read())
                    {
                        TimeSpan span3 = (TimeSpan) (DateTime.Parse(reader8["StartTime"].ToString()).AddHours(double.Parse(reader8["XbTimes"].ToString())) - DateTime.Parse(reader8["EndTime"].ToString()));
                        string str12 = "" + Math.Round((double) (span3.TotalSeconds / 3600.0), 2) + "";
                        num3 += decimal.Parse(str12);
                    }
                    reader8.Close();
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\"><a href='javascript:void(0)' onclick='window.open (\"WorkFlowListXl_showAll.aspx?FlowIdAll=", base.Request.QueryString["FlowId"], "&UserId=", base.Request.QueryString["UserId"], "&Starttime=", base.Request.QueryString["Starttime"], "&Endtime=", base.Request.QueryString["Endtime"], "&key=2&FlowId=", reader7["id"], "\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'><b><font color=red>", num3, "</font></b></a></td>" });
                }
                reader7.Close();
                decimal num4 = 0M;
                string str13 = "select C.id,C.StartTime,C.EndTime,B.XbTimes  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile inner join [qp_oa_WorkFlowNode] as [B] on [B].NodeNum=[C].[XuHao] and [B].FlowNumber=[A].[FlowNumber]  where A.FlowId  in (" + base.Request.QueryString["FlowId"] + ") " + this.CreateMidSql() + " and [C].BLusername  in (" + str + ") and A.Shuxing='固定流程' and (C.States='已委托' or C.States='已办结') and C.EndTime!='1900-1-1' group by C.id,C.StartTime,C.EndTime,B.XbTimes";
                SqlDataReader reader9 = this.List.GetList(str13);
                while (reader9.Read())
                {
                    TimeSpan span4 = (TimeSpan) (DateTime.Parse(reader9["StartTime"].ToString()).AddHours(double.Parse(reader9["XbTimes"].ToString())) - DateTime.Parse(reader9["EndTime"].ToString()));
                    string str14 = "" + Math.Round((double) (span4.TotalSeconds / 3600.0), 2) + "";
                    num4 += decimal.Parse(str14);
                }
                reader9.Close();
                text = this.mx.Text;
                this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\"><a href='javascript:void(0)' onclick='window.open (\"WorkFlowListXl_showA.aspx?FlowIdAll=", base.Request.QueryString["FlowId"], "&UserId=", base.Request.QueryString["UserId"], "&Starttime=", base.Request.QueryString["Starttime"], "&Endtime=", base.Request.QueryString["Endtime"], "&key=2&FlowId=0\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'><b><font color=red>", num4, "</font></b></a></td></tr>" });
                this.mx.Text = this.mx.Text + "</table>";
            }
        }
    }
}


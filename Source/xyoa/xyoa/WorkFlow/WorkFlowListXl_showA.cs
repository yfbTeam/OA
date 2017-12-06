namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListXl_showA : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label mx;
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=ExcelFile.xls");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/excel";
            base.Response.Write(this.mx.Text);
            base.Response.End();
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
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
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
                this.mx.Text = this.mx.Text + "<tr onmouseover=\"javascript:setMouseOverColor(this);\" onmouseout=\"javascript:setMouseOutColor(this);\"style=\"color: #E7E7FF; background-color: #4A3C8C; font-weight: bold; white-space: nowrap;\">";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">流水号</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">工作名称/文号</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">办理人</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">步骤名称</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">步骤状态</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">开始于</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">结束于</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">用时</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">限办完成时间</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">步骤办理效率</th>";
                this.mx.Text = this.mx.Text + " <th class=\"newtitle\" scope=\"col\" style=\"color: White; white-space: nowrap;\">效率值</th>";
                this.mx.Text = this.mx.Text + " </tr>";
                this.mx.Text = this.mx.Text + "<tr onmouseover=\"javascript:setMouseOverColor(this);\" onmouseout=\"javascript:setMouseOutColor(this);\"  style=\"color: Black; background-color: #FBFCFE;\">";
                string str3 = "select A.Sequence, A.Name as AName,C.BLrealname,B.NodeName,C.States as CStates,C.StartTime,C.EndTime,B.XbTimes  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile inner join [qp_oa_WorkFlowNode] as [B] on [B].NodeNum=[C].[XuHao] and [B].FlowNumber=[A].[FlowNumber]  where A.FlowId  in (" + base.Request.QueryString["FlowIdAll"] + ") " + this.CreateMidSql() + " and [C].BLusername  in (" + str + ") and A.Shuxing='固定流程' and (C.States='已委托' or C.States='已办结') group by A.Sequence, A.Name,C.BLrealname,B.NodeName,C.States,C.StartTime,C.EndTime,B.XbTimes";
                SqlDataReader reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    TimeSpan span = (TimeSpan) (DateTime.Parse(reader2["EndTime"].ToString()) - DateTime.Parse(reader2["StartTime"].ToString()));
                    TimeSpan span2 = (TimeSpan) (DateTime.Parse(reader2["StartTime"].ToString()).AddHours(double.Parse(reader2["XbTimes"].ToString())) - DateTime.Parse(reader2["EndTime"].ToString()));
                    string str4 = "" + span2.TotalSeconds + "";
                    string str5 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                    this.mx.Text = this.mx.Text + "<tr onmouseover=\"javascript:setMouseOverColor(this);\" onmouseout=\"javascript:setMouseOutColor(this);\"  style=\"color: Black; background-color: #FBFCFE;\">";
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\"><b>", reader2["Sequence"], "</b></td>" });
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<td align=\"left\" style=\"white-space: nowrap;\">", reader2["AName"], "</td>" });
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", reader2["BLrealname"], "</td>" });
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", reader2["NodeName"], "</td>" });
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", reader2["CStates"], "</td>" });
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", reader2["StartTime"], "</td>" });
                    if ((reader2["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader2["EndTime"].ToString() == "1900-01-01 00:00:00"))
                    {
                        this.mx.Text = this.mx.Text + "<td align=\"center\" style=\"white-space: nowrap;\">未办理</td>";
                        this.mx.Text = this.mx.Text + "<td align=\"center\" style=\"white-space: nowrap;\">未办理</td>";
                        text = this.mx.Text;
                        this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", DateTime.Parse(reader2["StartTime"].ToString()).AddHours(double.Parse(reader2["XbTimes"].ToString())), "</td>" });
                        this.mx.Text = this.mx.Text + "<td align=\"left\" style=\"white-space: nowrap;\">未接收办理，由其他人员直接转交</td>";
                        this.mx.Text = this.mx.Text + "<td align=\"center\" style=\"white-space: nowrap;\">0</td>";
                    }
                    else if (span2.TotalSeconds >= 0.0)
                    {
                        text = this.mx.Text;
                        this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", reader2["EndTime"], "</td>" });
                        this.mx.Text = this.mx.Text + "<td align=\"center\" style=\"white-space: nowrap;\">" + this.pulicss.ShowDateTime(span.TotalSeconds) + "</td>";
                        text = this.mx.Text;
                        this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", DateTime.Parse(reader2["StartTime"].ToString()).AddHours(double.Parse(reader2["XbTimes"].ToString())), "</td>" });
                        this.mx.Text = this.mx.Text + "<td align=\"left\" style=\"white-space: nowrap;\">提前： " + this.pulicss.ShowDateTime(double.Parse(str4.Replace("-", ""))) + "</td>";
                        this.mx.Text = this.mx.Text + "<td align=\"center\" style=\"white-space: nowrap;\">" + str5 + "</td>";
                    }
                    else
                    {
                        text = this.mx.Text;
                        this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", reader2["EndTime"], "</td>" });
                        this.mx.Text = this.mx.Text + "<td align=\"center\" style=\"white-space: nowrap;\">" + this.pulicss.ShowDateTime(span.TotalSeconds) + "</td>";
                        text = this.mx.Text;
                        this.mx.Text = string.Concat(new object[] { text, "<td align=\"center\" style=\"white-space: nowrap;\">", DateTime.Parse(reader2["StartTime"].ToString()).AddHours(double.Parse(reader2["XbTimes"].ToString())), "</td>" });
                        this.mx.Text = this.mx.Text + "<td align=\"left\" style=\"white-space: nowrap;\">超时： " + this.pulicss.ShowDateTime(double.Parse(str4.Replace("-", ""))) + "</td>";
                        this.mx.Text = this.mx.Text + "<td align=\"center\" style=\"white-space: nowrap;\">" + str5 + "</td>";
                    }
                    this.mx.Text = this.mx.Text + " </tr>";
                }
                reader2.Close();
                this.mx.Text = this.mx.Text + "</table>";
            }
        }
    }
}


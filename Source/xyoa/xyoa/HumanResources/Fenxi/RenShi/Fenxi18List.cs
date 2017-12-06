namespace xyoa.HumanResources.Fenxi.RenShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Fenxi18List : Page
    {
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Fenxi18.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
                try
                {
                    this.ViewState["Starttime"] = "" + base.Request.QueryString["SYear"].ToString() + "-" + base.Request.QueryString["SMonth"].ToString() + "-01";
                    this.ViewState["Endtime"] = "" + DateTime.Parse("" + base.Request.QueryString["EYear"].ToString() + "-" + base.Request.QueryString["EMonth"].ToString() + "-01").AddMonths(1).AddDays(-1.0) + "";
                    string sql = string.Concat(new object[] { "select count(A.id) from [qp_hr_YuangongDD] as [A]  inner join [qp_oa_Bumen] as [B] on [A].[BumenQ] = [B].[Id] inner join [qp_oa_Bumen] as [C] on [A].[BumenE] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[ZhiweiQ] = [D].[id]  inner join [qp_oa_Zhiwei] as [E] on [A].[ZhiweiE] = [E].[id]   inner join [qp_hr_YuangongLx] as [F] on [A].[Leixing] = [F].[id] where ((Riqi between '", this.ViewState["Starttime"], "'and  '", this.ViewState["Endtime"], "') or datediff(dd,Riqi,'", this.ViewState["Starttime"], "')=0 or datediff(dd,Riqi,'", this.ViewState["Endtime"], "')=0)" });
                    string s = "" + this.List.GetCount(sql) + "";
                    if (s == "0")
                    {
                        this.ViewState["showlb"] = "<tr><td class=\"newtd2\" colspan=\"4\"><div align=\"center\"><font color=red>无相关数据</font></div></td> </tr>";
                    }
                    else
                    {
                        string str3 = "select * from qp_crm_FenxiMonth where id<=(select id from qp_crm_FenxiMonth where ProMonth='" + base.Request.QueryString["EMonth"].ToString() + "' and ProYear='" + base.Request.QueryString["EYear"].ToString() + "')  and  id>=(select id from qp_crm_FenxiMonth where ProMonth='" + base.Request.QueryString["SMonth"].ToString() + "' and ProYear='" + base.Request.QueryString["SYear"].ToString() + "')   order by id asc";
                        int num = 1;
                        SqlDataReader list = this.List.GetList(str3);
                        while (list.Read())
                        {
                            StateBag bag = ViewState;
                            object obj2;
                            string str4 = string.Concat(new object[] { "select count(A.id) from [qp_hr_YuangongDD] as [A]  inner join [qp_oa_Bumen] as [B] on [A].[BumenQ] = [B].[Id] inner join [qp_oa_Bumen] as [C] on [A].[BumenE] = [C].[Id] inner join [qp_oa_Zhiwei] as [D] on [A].[ZhiweiQ] = [D].[id]  inner join [qp_oa_Zhiwei] as [E] on [A].[ZhiweiE] = [E].[id]   inner join [qp_hr_YuangongLx] as [F] on [A].[Leixing] = [F].[id] where Year(Riqi)='", list["ProYear"], "' and  Month(Riqi)='", list["ProMonth"], "' " });
                            string str5 = "" + this.List.GetCount(str4) + "";
                            num++;
                            if (str5 != "0")
                            {
                                string str6 = "select  * from qp_crm_Fenxi  where id='" + num + "' order by id asc";
                                SqlDataReader reader2 = this.List.GetList(str6);
                                if (reader2.Read())
                                {
                                    obj2 = bag["showjg"];
                                    (bag = this.ViewState)["showjg"] = string.Concat(new object[] { obj2, "<set name='", list["ProYear"].ToString(), "年", list["ProMonth"].ToString(), "月(", str5, ")' value='", str5, "' color='", reader2["color"].ToString(), "'/>" });
                                }
                                reader2.Close();
                            }
                            decimal num2 = decimal.Round(decimal.Parse(str5) / decimal.Parse(s), 2) * 100M;
                            obj2 = bag["showlb"];
                            (bag = this.ViewState)["showlb"] = string.Concat(new object[] { obj2, "<tr><td class=\"newtd2\"><div align=\"center\">", list["ProYear"].ToString(), "年", list["ProMonth"].ToString(), "月</div></td><td class=\"newtd2\"><div align=\"center\">", str5, "</div></td> <td align=left class=\"newtd2\"> <img src=\"/oaimg/bar2.gif\" width=\"", num2, " * 2\" height=\"11\"/>", num2, "%</td><td class=\"newtd2\"><div align=\"center\"><a href='javascript:void(0)' onclick='var num=Math.random();loc_x=(screen.availWidth-877)/2;loc_y=(screen.availHeight-600)/2;window.open (\"YuangongDDList.aspx?tmp=\"+num+\"&Key=18&Year=", list["ProYear"], "&Month=", list["ProMonth"], "\", \"_blank\", \"height=600, width=877,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\"+loc_y+\",left=\"+loc_x+\"\")'>详情</a></div></td> </tr>" });
                        }
                        list.Close();
                    }
                }
                catch
                {
                }
            }
        }
    }
}


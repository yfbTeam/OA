namespace xyoa.HumanResources.Fenxi.RenShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Fenxi28 : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

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
                    string sql = "select count(A.id) from  [qp_hr_YuangongTJ] as [A]  where 1=1";
                    string s = "" + this.List.GetCount(sql) + "";
                    if (s == "0")
                    {
                        this.ViewState["showlb"] = "<tr><td class=\"newtd2\" colspan=\"4\"><div align=\"center\"><font color=red>无相关数据</font></div></td> </tr>";
                    }
                    else
                    {
                        StateBag bag = ViewState;
                        object obj2;
                        string str3 = "select id,name from qp_hr_YuangongLx where type='14'  order by id asc";
                        int num = 1;
                        SqlDataReader list = this.List.GetList(str3);
                        while (list.Read())
                        {
                            string str4 = "select count(A.id) from  [qp_hr_YuangongTJ] as [A] where A.Jieguo='" + list["id"] + "'";
                            string str5 = "" + this.List.GetCount(str4) + "";
                            num++;
                            if (str5 != "0")
                            {
                                string str6 = "select  * from qp_crm_Fenxi  where id='" + num + "' order by id asc";
                                SqlDataReader reader2 = this.List.GetList(str6);
                                if (reader2.Read())
                                {
                                    obj2 = bag["showjg"];
                                    (bag = this.ViewState)["showjg"] = string.Concat(new object[] { obj2, "<set name='", list["name"].ToString(), "(", str5, ")' value='", str5, "' color='", reader2["color"].ToString(), "'/>" });
                                }
                                reader2.Close();
                            }
                            decimal num2 = decimal.Round(decimal.Parse(str5) / decimal.Parse(s), 2) * 100M;
                            obj2 = bag["showlb"];
                            (bag = this.ViewState)["showlb"] = string.Concat(new object[] { obj2, "<tr><td class=\"newtd2\"><div align=\"center\">", list["name"].ToString(), "</div></td><td class=\"newtd2\"><div align=\"center\">", str5, "</div></td> <td align=left class=\"newtd2\"> <img src=\"/oaimg/bar2.gif\" width=\"", num2, " * 2\" height=\"11\"/>", num2, "%</td><td class=\"newtd2\"><div align=\"center\"><a href='javascript:void(0)' onclick='var num=Math.random();loc_x=(screen.availWidth-877)/2;loc_y=(screen.availHeight-600)/2;window.open (\"YuangongTJ.aspx?tmp=\"+num+\"&Key=1&Jieguo=", list["id"], "\", \"_blank\", \"height=600, width=877,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\"+loc_y+\",left=\"+loc_x+\"\")'>详情</a></div></td></tr>" });
                        }
                        list.Close();
                        string str7 = "select count(A.id) from  [qp_hr_YuangongTJ] as [A] where A.Leibie=''";
                        string str8 = "" + this.List.GetCount(str7) + "";
                        if (str8 != "0")
                        {
                            decimal num3 = decimal.Round(decimal.Parse(str8) / decimal.Parse(s), 2) * 100M;
                            obj2 = bag["showjg"];
                            (bag = this.ViewState)["showjg"] = string.Concat(new object[] { obj2, "<set name='未分类(", str8, ")' value='", str8, "' color='#9999CC'/>" });
                            obj2 = bag["showlb"];
                            (bag = this.ViewState)["showlb"] = string.Concat(new object[] { obj2, "<tr><td class=\"newtd2\"><div align=\"center\">未分类</div></td><td class=\"newtd2\"><div align=\"center\">", str8, "</div></td><td align=left class=\"newtd2\"> <img src=\"/oaimg/bar2.gif\" width=\"", num3, " * 2\" height=\"11\"/>", num3, "%</td><td class=\"newtd2\"><div align=\"center\"><a href='javascript:void(0)' onclick='var num=Math.random();loc_x=(screen.availWidth-877)/2;loc_y=(screen.availHeight-600)/2;window.open (\"YuangongTJ.aspx?tmp=\"+num+\"&Key=1&Jieguo=\", \"_blank\", \"height=600, width=877,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\"+loc_y+\",left=\"+loc_x+\"\")'>详情</a></div></td></tr>" });
                        }
                    }
                }
                catch
                {
                }
            }
        }
    }
}


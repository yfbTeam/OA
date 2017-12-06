namespace xyoa.Resources.ResReport
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class ResCkFx : Page
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
                this.pulicss.QuanXianBack("bbbb3g", this.Session["perstr"].ToString());
                try
                {
                    string sql = "select count(id) from qp_oa_ResourcesAdd";
                    string s = "" + this.List.GetCount(sql) + "";
                    if (s == "0")
                    {
                        this.ViewState["showlb"] = "<tr><td class=\"newtd2\" colspan=\"4\"><div align=\"center\"><font color=red>无相关数据</font></div></td> </tr>";
                    }
                    else
                    {
                        string str3 = "select id,Name from qp_oa_ResourcesCangKu  order by id asc";
                        int num = 1;
                        SqlDataReader list = this.List.GetList(str3);
                        while (list.Read())
                        {
                            StateBag bag = ViewState;
                            object obj2;
                            string str4 = "select count(id) from qp_oa_ResourcesAdd where Cangku='" + list["id"].ToString() + "'";
                            string str5 = "" + this.List.GetCount(str4) + "";
                            num++;
                            if (str5 != "0")
                            {
                                string str6 = "select  * from qp_crm_Fenxi   where id='" + num + "' order by id asc";
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
                            (bag = this.ViewState)["showlb"] = string.Concat(new object[] { obj2, "<tr><td class=\"newtd2\"><div align=\"center\">", list["name"].ToString(), "</div></td><td class=\"newtd2\"><div align=\"center\">", str5, "</div></td> <td align=left class=\"newtd2\"> <img src=\"/oaimg/bar2.gif\" width=\"", num2, " * 2\" height=\"11\"/>", num2, "%</td><td class=\"newtd2\"><div align=\"center\"><a href=\"javascript:void(0)\" onclick=\"openfrom('Cangku=", list["id"].ToString(), "')\">详情</a></div></td> </tr>" });
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


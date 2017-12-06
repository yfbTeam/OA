namespace xyoa.InfoManage.bbs
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class InsideBBSListShow : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBSListShowBack.aspx?step=0&id=" + base.Request.QueryString["id"] + "&BigId=" + base.Request.QueryString["BigId"] + "");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBSList.aspx?id=" + base.Request.QueryString["BigId"] + "");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBSList.aspx?id=" + base.Request.QueryString["BigId"] + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string str3;
                string str4;
                string sql = "select Name,BzUsername from qp_oa_InsideBBSBig where id='" + base.Request.QueryString["BigId"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Name"] = list["Name"].ToString();
                    this.ViewState["BzUsername"] = list["BzUsername"].ToString();
                }
                list.Close();
                string str2 = "select * from qp_oa_InsideBBS where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    str3 = "," + this.ViewState["BzUsername"] + ",";
                    str4 = "," + this.Session["username"] + ",";
                    this.ViewState["Titles"] = reader2["Titles"].ToString();
                    if ((reader2["Username"].ToString() == this.Session["username"].ToString()) || (str3.IndexOf(str4) >= 0))
                    {
                        this.ViewState["Content"] = string.Concat(new object[] { 
                            "<table style=\"width: 100%\" bgcolor=\"#999999\" border=\"0\" cellpadding=\"2\" cellspacing=\"1\"><tr><td align=\"center\" valign=\"top\" style=\"width: 170px; height: 25px; background-color: #ffffff\"><br><a href='javascript:void(0)' onclick='senduser(\"", reader2["Username"].ToString(), "\")'><font color=\"#0066CC\"><b>", reader2["Realname"].ToString(), "</b></font></a><br></td><td style=\"padding-left: 5px; background-color: #ffffff\" rowspan=\"2\" valign=\"top\">", reader2["Content"].ToString(), "<br>", this.pulicss.GetFileBBS(reader2["Number"].ToString()), "</td></tr><tr><td align=\"center\" valign=\"top\" style=\"width: 170px; height: 25px; background-color: #ffffff\"><br>", reader2["Settime"].ToString(), "<br><hr style=\"height: 1px; color: #004210\"><font color=\"#BD9999\">1楼</font> <a href='InsideBBSListShowBack.aspx?step=1&id=", base.Request.QueryString["id"], "&BigId=", base.Request.QueryString["BigId"], "'><font color=\"#0066CC\">回复</font></a> <a href='InsideBBSListShowBj.aspx?id=", reader2["id"], 
                            "&Backid=", base.Request.QueryString["id"], "&BigId=", base.Request.QueryString["BigId"], "'><font color=\"#0066CC\">编辑</font></a> <a href='javascript:void(0)' onclick='window.open (\"InsideBBSListShowDel.aspx?id=", reader2["id"], "&Backid=", base.Request.QueryString["id"], "&BigId=", base.Request.QueryString["BigId"], "\", \"_blank\", \"height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=110,left=110\")'><font color=\"#0066CC\">删除</font></a></td></tr></table><br>"
                         });
                    }
                    else
                    {
                        this.ViewState["Content"] = "<table style=\"width: 100%\" bgcolor=\"#999999\" border=\"0\" cellpadding=\"2\" cellspacing=\"1\"><tr><td align=\"center\" valign=\"top\" style=\"width: 170px; height: 25px; background-color: #ffffff\"><br><a href='javascript:void(0)' onclick='senduser(\"" + reader2["Username"].ToString() + "\")'><font color=\"#0066CC\"><b>" + reader2["Realname"].ToString() + "</b></font></a><br></td><td style=\"padding-left: 5px; background-color: #ffffff\" rowspan=\"2\" valign=\"top\">" + reader2["Content"].ToString() + "<br>" + this.pulicss.GetFileBBS(reader2["Number"].ToString()) + "</td></tr><tr><td align=\"center\" valign=\"top\" style=\"width: 170px; height: 25px; background-color: #ffffff\"><br>" + reader2["Settime"].ToString() + "<br><hr style=\"height: 1px; color: #004210\"><font color=\"#BD9999\">1楼</font> <a href='InsideBBSListShowBack.aspx?step=1&id=" + base.Request.QueryString["id"] + "&BigId=" + base.Request.QueryString["BigId"] + "'><font color=\"#0066CC\">回复</font></a></td></tr></table><br>";
                    }
                }
                reader2.Close();
                int num = 1;
                string str5 = "select * from qp_oa_InsideBBS where ParentNodesID='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' order by id asc";
                SqlDataReader reader3 = this.List.GetList(str5);
                while (reader3.Read())
                {
                    StateBag bag = ViewState;
                    object obj2;
                    str3 = "," + this.ViewState["BzUsername"] + ",";
                    str4 = "," + this.Session["username"] + ",";
                    num++;
                    if ((reader3["Username"].ToString() == this.Session["username"].ToString()) || (str3.IndexOf(str4) >= 0))
                    {
                        obj2 = bag["Content_list"];
                        (bag = this.ViewState)["Content_list"] = string.Concat(new object[] { 
                            obj2, "<table style=\"width: 100%\" bgcolor=\"#999999\" border=\"0\" cellpadding=\"2\" cellspacing=\"1\"><tr><td align=\"center\" valign=\"top\" style=\"width: 170px; height: 25px; background-color: #ffffff\"><br><a href='javascript:void(0)' onclick='senduser(\"", reader3["Username"].ToString(), "\")'><font color=\"#0066CC\"><b>", reader3["Realname"].ToString(), "</b></font></a><br></td><td style=\"padding-left: 5px; background-color: #ffffff\" rowspan=\"2\" valign=\"top\">", reader3["Content"].ToString(), "<br>", this.pulicss.GetFileBBS(reader3["Number"].ToString()), "</td></tr><tr><td align=\"center\" valign=\"top\" style=\"width: 170px; height: 25px; background-color: #ffffff\"><br>", reader3["Settime"].ToString(), "<br><hr style=\"height: 1px; color: #004210\"><font color=\"#BD9999\">", num, "楼</font> <a href='InsideBBSListShowBack.aspx?step=", num, "&id=", 
                            base.Request.QueryString["id"], "&BigId=", base.Request.QueryString["BigId"], "'><font color=\"#0066CC\">回复</font></a> <a href='InsideBBSListShowBj.aspx?id=", reader3["id"], "&Backid=", base.Request.QueryString["id"], "&BigId=", base.Request.QueryString["BigId"], "'><font color=\"#0066CC\">编辑</font></a> <a href='javascript:void(0)' onclick='window.open (\"InsideBBSListShowDel.aspx?id=", reader3["id"], "&Backid=", base.Request.QueryString["id"], "&BigId=", base.Request.QueryString["BigId"], "\", \"_blank\", \"height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=110,left=110\")'><font color=\"#0066CC\">删除</font></a></td></tr></table><br>"
                         });
                    }
                    else
                    {
                        obj2 = bag["Content_list"];
                        (bag = this.ViewState)["Content_list"] = string.Concat(new object[] { 
                            obj2, "<table style=\"width: 100%\" bgcolor=\"#999999\" border=\"0\" cellpadding=\"2\" cellspacing=\"1\"><tr><td align=\"center\" valign=\"top\" style=\"width: 170px; height: 25px; background-color: #ffffff\"><br><a href='javascript:void(0)' onclick='senduser(\"", reader3["Username"].ToString(), "\")'><font color=\"#0066CC\"><b>", reader3["Realname"].ToString(), "</b></font></a><br></td><td style=\"padding-left: 5px; background-color: #ffffff\" rowspan=\"2\" valign=\"top\">", reader3["Content"].ToString(), "<br>", this.pulicss.GetFileBBS(reader3["Number"].ToString()), "</td></tr><tr><td align=\"center\" valign=\"top\" style=\"width: 170px; height: 25px; background-color: #ffffff\"><br>", reader3["Settime"].ToString(), "<br><hr style=\"height: 1px; color: #004210\"><font color=\"#BD9999\">", num, "楼</font> <a href='InsideBBSListShowBack.aspx?step=", num, "&id=", 
                            base.Request.QueryString["id"], "&BigId=", base.Request.QueryString["BigId"], "'><font color=\"#0066CC\">回复</font></a></td></tr></table><br>"
                         });
                    }
                }
                reader3.Close();
                string str6 = "Update qp_oa_InsideBBS  Set PointNum=PointNum+1  where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                this.List.ExeSql(str6);
            }
        }
    }
}


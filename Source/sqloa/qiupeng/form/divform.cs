namespace qiupeng.form
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI.WebControls;

    public class divform
    {
        public string bmstr = null;
        private Db List = new Db();

        public void AddWorkFlowLog(string Email, string Number, string FormName, string Buzhou, string Contents, string ZbOrJb)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_AddWorkFlowLog (Email,Number,FormName,Buzhou,Contents,ZbOrJb,Username,Realname,Settime) values ('", Email, "','", Number, "','", FormName, "','", Buzhou, "','", Contents, "','", ZbOrJb, "','", HttpContext.Current.Session["Username"], "','", HttpContext.Current.Session["Realname"], 
                "','", DateTime.Now.ToString(), "')"
             });
            this.List.ExeSql(sql);
        }

        private void BindChildDz(Label _Label, string ParentID)
        {
            string sql = "select * from qp_oa_Bumen where id=" + ParentID + "";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                _Label.Text = "" + list["Name"].ToString() + "/" + _Label.Text + "";
                if (list["ParentNodesID"].ToString() != "0")
                {
                    this.BindChildDz(_Label, list["ParentNodesID"].ToString());
                }
            }
            list.Close();
        }

        public void BindListDz(Label _Label, string NodeId)
        {
            string sql = "select * from qp_oa_Bumen where id='" + NodeId + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                _Label.Text = "" + list["Name"].ToString();
                this.BindChildDz(_Label, list["ParentNodesID"].ToString());
            }
            list.Close();
        }

        public string BumenBh(string id)
        {
            string str = null;
            string sql = "select Bianhao from qp_oa_Bumen where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Bianhao"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        public string BumenName(string id)
        {
            string str = null;
            string sql = "select Name from qp_oa_Bumen where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Name"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        public string BumenZgA(string id)
        {
            string str = null;
            string sql = "select BmRealname from qp_oa_Bumen where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["BmRealname"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        public string BumenZgB(string id)
        {
            string str = null;
            string sql = "select ParentNodesID from qp_oa_Bumen where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str3 = "select BmRealname from qp_oa_Bumen where  id='" + list["ParentNodesID"].ToString() + "'";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    str = reader2["BmRealname"].ToString();
                }
                else
                {
                    str = "";
                }
                reader2.Close();
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        public string BumenZgC()
        {
            string str = null;
            string sql = "select BmRealname from qp_oa_Bumen where  ParentNodesID='0' and  CHARINDEX(QxString,(select QxString from qp_oa_Bumen where id='" + HttpContext.Current.Session["BuMenId"].ToString() + "')) > 0";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["BmRealname"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        public string FlowJbr(string id)
        {
            string str = null;
            string sql = "select JbObjectName from qp_oa_AddWorkFlow where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["JbObjectName"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        public string FlowYbr(string id)
        {
            string str = null;
            string sql = "select YJBObjecName from qp_oa_AddWorkFlow where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["YJBObjecName"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        public string FlowZbr(string id)
        {
            string str = null;
            string sql = "select ZbObjectName from qp_oa_AddWorkFlow where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["ZbObjectName"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        public string FormatKjStrH(string num, string lcid, string AStr, string bdmc, string mcwh, string lcksrq, string lckssj, int lsh)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("datafld=\"SYS_realname_" + num + "\"", string.Concat(new object[] { " datafld=\"SYS_realname_", num, "\" value=\"", HttpContext.Current.Session["realname"], "\"" }));
            AStr = AStr.Replace("datafld=\"SYS_Unit_" + num + "\"", "  datafld=\"SYS_Unit_" + num + "\" value=\"" + this.BumenName(HttpContext.Current.Session["BuMenId"].ToString()) + "\"");
            AStr = AStr.Replace("datafld=\"SYS_Respon_" + num + "\"", "  datafld=\"SYS_Respon_" + num + "\" value=\"" + this.JueseName(HttpContext.Current.Session["JueseId"].ToString()) + "\"");
            AStr = AStr.Replace("datafld=\"SYS_Post_" + num + "\"", "  datafld=\"SYS_Post_" + num + "\" value=\"" + this.ZhiweiName(HttpContext.Current.Session["Zhiweiid"].ToString()) + "\"");
            AStr = AStr.Replace("datafld=\"SYS_UnitZgA_" + num + "\"", "  datafld=\"SYS_UnitZgA_" + num + "\" value=\"" + this.BumenZgA(HttpContext.Current.Session["BuMenId"].ToString()) + "\"");
            AStr = AStr.Replace("datafld=\"SYS_UnitZgB_" + num + "\"", "  datafld=\"SYS_UnitZgB_" + num + "\" value=\"" + this.BumenZgB(HttpContext.Current.Session["BuMenId"].ToString()) + "\"");
            AStr = AStr.Replace("datafld=\"SYS_UnitZgC_" + num + "\"", "  datafld=\"SYS_UnitZgC_" + num + "\" value=\"" + this.BumenZgC() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateTime_" + num + "\"", "  datafld=\"SYS_DateTime_" + num + "\" value=\"" + DateTime.Now.ToShortDateString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateYear_" + num + "\"", "  datafld=\"SYS_DateYear_" + num + "\" value=\"" + DateTime.Now.Year.ToString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateMonth_" + num + "\"", "  datafld=\"SYS_DateMonth_" + num + "\" value=\"" + DateTime.Now.Month.ToString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateDate_" + num + "\"", "  datafld=\"SYS_DateDate_" + num + "\" value=\"" + DateTime.Now.Day.ToString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateHour_" + num + "\"", "  datafld=\"SYS_DateHour_" + num + "\" value=\"" + DateTime.Now.Hour.ToString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateMinute_" + num + "\"", "  datafld=\"SYS_DateMinute_" + num + "\" value=\"" + DateTime.Now.Minute.ToString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateSecond_" + num + "\"", "  datafld=\"SYS_DateSecond_" + num + "\" value=\"" + DateTime.Now.Second.ToString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateDayOfWeek_" + num + "\"", "  datafld=\"SYS_DateDayOfWeek_" + num + "\" value=\"" + this.GetWeekDay() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateATime_" + num + "\"", "  datafld=\"SYS_DateATime_" + num + "\" value=\"" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日\"");
            AStr = AStr.Replace("datafld=\"SYS_DateBTime_" + num + "\"", "  datafld=\"SYS_DateBTime_" + num + "\" value=\"" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月\"");
            AStr = AStr.Replace("datafld=\"SYS_DateCTime_" + num + "\"", "  datafld=\"SYS_DateCTime_" + num + "\" value=\"" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日\"");
            AStr = AStr.Replace("datafld=\"SYS_DateDTime_" + num + "\"", "  datafld=\"SYS_DateDTime_" + num + "\" value=\"" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_DateETime_" + num + "\"", "  datafld=\"SYS_DateETime_" + num + "\" value=\"" + DateTime.Now.ToShortDateString() + "　" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "\"");
            AStr = AStr.Replace("datafld=\"SYS_username_" + num + "\"", string.Concat(new object[] { "  datafld=\"SYS_username_", num, "\" value=\"", HttpContext.Current.Session["username"], "\"" }));
            AStr = AStr.Replace("datafld=\"SYS_RRDateDate_" + num + "\"", string.Concat(new object[] { "  datafld=\"SYS_RRDateDate_", num, "\" value=\"", HttpContext.Current.Session["realname"], "", DateTime.Now.ToShortDateString(), "\"" }));
            AStr = AStr.Replace("datafld=\"SYS_RRDateTime_" + num + "\"", string.Concat(new object[] { "  datafld=\"SYS_RRDateTime_", num, "\" value=\"", HttpContext.Current.Session["realname"], "", DateTime.Now.ToString(), "\"" }));
            AStr = AStr.Replace("datafld=\"SYS_IpAddress_" + num + "\"", "  datafld=\"SYS_IpAddress_" + num + "\" value=\"" + HttpContext.Current.Request.UserHostAddress + "\"");
            AStr = AStr.Replace("datafld=\"SYS_bdmc_" + num + "\"", "  datafld=\"SYS_bdmc_" + num + "\" value=\"" + bdmc + "\"");
            AStr = AStr.Replace("datafld=\"SYS_mcwh_" + num + "\"", "  datafld=\"SYS_mcwh_" + num + "\" value=\"" + mcwh + "\"");
            AStr = AStr.Replace("datafld=\"SYS_lcksrq_" + num + "\"", "  datafld=\"SYS_lcksrq_" + num + "\" value=\"" + lcksrq + "\"");
            AStr = AStr.Replace("datafld=\"SYS_lckssj_" + num + "\"", "  datafld=\"SYS_lckssj_" + num + "\" value=\"" + lckssj + "\"");
            AStr = AStr.Replace("datafld=\"SYS_lsh_" + num + "\"", string.Concat(new object[] { "  datafld=\"SYS_lsh_", num, "\" value=\"", lsh, "\"" }));
            AStr = AStr.Replace("datafld=\"SYS_AllJbrA_" + num + "\"", "  datafld=\"SYS_AllJbrA_" + num + "\" value=\"" + this.FlowZbr(lcid) + "\"");
            AStr = AStr.Replace("datafld=\"SYS_AllJbrB_" + num + "\"", "  datafld=\"SYS_AllJbrB_" + num + "\" value=\"" + this.FlowJbr(lcid) + "\"");
            AStr = AStr.Replace("datafld=\"SYS_AllYbr_" + num + "\"", "  datafld=\"SYS_AllYbr_" + num + "\" value=\"" + this.FlowYbr(lcid) + "\"");
            AStr = AStr.Replace("{宏}部门列表_" + num + "", "" + this.SysBumenLb(num, 0, "|-") + "");
            AStr = AStr.Replace("{宏}用户列表_" + num + "", "" + this.SysRenyuanLb() + "");
            AStr = AStr.Replace("{宏}职位列表_" + num + "", "" + this.SysZhiweiLb() + "");
            AStr = AStr.Replace("{宏}角色列表_" + num + "", "" + this.SysJueseLb() + "");
            AStr = AStr.Replace("datafld=SYS_realname_" + num + "", string.Concat(new object[] { " datafld=SYS_realname_", num, " value=", HttpContext.Current.Session["realname"], "" }));
            AStr = AStr.Replace("datafld=SYS_Unit_" + num + "", "  datafld=SYS_Unit_" + num + " value=" + this.BumenName(HttpContext.Current.Session["BuMenId"].ToString()) + "");
            AStr = AStr.Replace("datafld=SYS_Respon_" + num + "", "  datafld=SYS_Respon_" + num + " value=" + this.JueseName(HttpContext.Current.Session["JueseId"].ToString()) + "");
            AStr = AStr.Replace("datafld=SYS_Post_" + num + "", "  datafld=SYS_Post_" + num + " value=" + this.ZhiweiName(HttpContext.Current.Session["Zhiweiid"].ToString()) + "");
            AStr = AStr.Replace("datafld=SYS_UnitZgA_" + num + "", "  datafld=SYS_UnitZgA_" + num + " value=" + this.BumenZgA(HttpContext.Current.Session["BuMenId"].ToString()) + "");
            AStr = AStr.Replace("datafld=SYS_UnitZgB_" + num + "", "  datafld=SYS_UnitZgB_" + num + " value=" + this.BumenZgB(HttpContext.Current.Session["BuMenId"].ToString()) + "");
            AStr = AStr.Replace("datafld=SYS_UnitZgC_" + num + "", "  datafld=SYS_UnitZgC_" + num + " value=" + this.BumenZgC() + "");
            AStr = AStr.Replace("datafld=SYS_DateTime_" + num + "", "  datafld=SYS_DateTime_" + num + " value=" + DateTime.Now.ToShortDateString() + "");
            AStr = AStr.Replace("datafld=SYS_DateYear_" + num + "", "  datafld=SYS_DateYear_" + num + " value=" + DateTime.Now.Year.ToString() + "");
            AStr = AStr.Replace("datafld=SYS_DateMonth_" + num + "", "  datafld=SYS_DateMonth_" + num + " value=" + DateTime.Now.Month.ToString() + "");
            AStr = AStr.Replace("datafld=SYS_DateDate_" + num + "", "  datafld=SYS_DateDate_" + num + " value=" + DateTime.Now.Day.ToString() + "");
            AStr = AStr.Replace("datafld=SYS_DateHour_" + num + "", "  datafld=SYS_DateHour_" + num + " value=" + DateTime.Now.Hour.ToString() + "");
            AStr = AStr.Replace("datafld=SYS_DateMinute_" + num + "", "  datafld=SYS_DateMinute_" + num + " value=" + DateTime.Now.Minute.ToString() + "");
            AStr = AStr.Replace("datafld=SYS_DateSecond_" + num + "", "  datafld=SYS_DateSecond_" + num + " value=" + DateTime.Now.Second.ToString() + "");
            AStr = AStr.Replace("datafld=SYS_DateDayOfWeek_" + num + "", "  datafld=SYS_DateDayOfWeek_" + num + " value=" + this.GetWeekDay() + "");
            AStr = AStr.Replace("datafld=SYS_DateATime_" + num + "", "  datafld=SYS_DateATime_" + num + " value=" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日");
            AStr = AStr.Replace("datafld=SYS_DateBTime_" + num + "", "  datafld=SYS_DateBTime_" + num + " value=" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月");
            AStr = AStr.Replace("datafld=SYS_DateCTime_" + num + "", "  datafld=SYS_DateCTime_" + num + " value=" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日");
            AStr = AStr.Replace("datafld=SYS_DateDTime_" + num + "", "  datafld=SYS_DateDTime_" + num + " value=" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "");
            AStr = AStr.Replace("datafld=SYS_DateETime_" + num + "", "  datafld=SYS_DateETime_" + num + " value=" + DateTime.Now.ToShortDateString() + "　" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "");
            AStr = AStr.Replace("datafld=SYS_username_" + num + "", string.Concat(new object[] { "  datafld=SYS_username_", num, " value=", HttpContext.Current.Session["username"], "" }));
            AStr = AStr.Replace("datafld=SYS_RRDateDate_" + num + "", string.Concat(new object[] { "  datafld=SYS_RRDateDate_", num, " value=", HttpContext.Current.Session["realname"], "", DateTime.Now.ToShortDateString(), "" }));
            AStr = AStr.Replace("datafld=SYS_RRDateTime_" + num + "", string.Concat(new object[] { "  datafld=SYS_RRDateTime_", num, " value=", HttpContext.Current.Session["realname"], "", DateTime.Now.ToString(), "" }));
            AStr = AStr.Replace("datafld=SYS_IpAddress_" + num + "", "  datafld=SYS_IpAddress_" + num + " value=" + HttpContext.Current.Request.UserHostAddress + "");
            AStr = AStr.Replace("datafld=SYS_bdmc_" + num + "", "  datafld=SYS_bdmc_" + num + " value=" + bdmc + "");
            AStr = AStr.Replace("datafld=SYS_mcwh_" + num + "", "  datafld=SYS_mcwh_" + num + " value=" + mcwh + "");
            AStr = AStr.Replace("datafld=SYS_lcksrq_" + num + "", "  datafld=SYS_lcksrq_" + num + " value=" + lcksrq + "");
            AStr = AStr.Replace("datafld=SYS_lckssj_" + num + "", "  datafld=SYS_lckssj_" + num + " value=" + lckssj + "");
            AStr = AStr.Replace("datafld=SYS_lsh_" + num + "", string.Concat(new object[] { "  datafld=SYS_lsh_", num, " value=", lsh, "" }));
            AStr = AStr.Replace("datafld=SYS_AllJbrA_" + num + "", "  datafld=SYS_AllJbrA_" + num + " value=" + this.FlowZbr(lcid) + "");
            AStr = AStr.Replace("datafld=SYS_AllJbrB_" + num + "", "  datafld=SYS_AllJbrB_" + num + " value=" + this.FlowJbr(lcid) + "");
            AStr = AStr.Replace("datafld=SYS_AllYbr_" + num + "", "  datafld=SYS_AllYbr_" + num + " value=" + this.FlowYbr(lcid) + "");
            AStr = AStr.Replace("dataFld=SYS_realname_" + num + "", string.Concat(new object[] { " dataFld=SYS_realname_", num, " value=", HttpContext.Current.Session["realname"], "" }));
            AStr = AStr.Replace("dataFld=SYS_Unit_" + num + "", "  dataFld=SYS_Unit_" + num + " value=" + this.BumenName(HttpContext.Current.Session["BuMenId"].ToString()) + "");
            AStr = AStr.Replace("dataFld=SYS_Respon_" + num + "", "  dataFld=SYS_Respon_" + num + " value=" + this.JueseName(HttpContext.Current.Session["JueseId"].ToString()) + "");
            AStr = AStr.Replace("dataFld=SYS_Post_" + num + "", "  dataFld=SYS_Post_" + num + " value=" + this.ZhiweiName(HttpContext.Current.Session["Zhiweiid"].ToString()) + "");
            AStr = AStr.Replace("dataFld=SYS_UnitZgA_" + num + "", "  dataFld=SYS_UnitZgA_" + num + " value=" + this.BumenZgA(HttpContext.Current.Session["BuMenId"].ToString()) + "");
            AStr = AStr.Replace("dataFld=SYS_UnitZgB_" + num + "", "  dataFld=SYS_UnitZgB_" + num + " value=" + this.BumenZgB(HttpContext.Current.Session["BuMenId"].ToString()) + "");
            AStr = AStr.Replace("dataFld=SYS_UnitZgC_" + num + "", "  dataFld=SYS_UnitZgC_" + num + " value=" + this.BumenZgC() + "");
            AStr = AStr.Replace("dataFld=SYS_DateTime_" + num + "", "  dataFld=SYS_DateTime_" + num + " value=" + DateTime.Now.ToShortDateString() + "");
            AStr = AStr.Replace("dataFld=SYS_DateYear_" + num + "", "  dataFld=SYS_DateYear_" + num + " value=" + DateTime.Now.Year.ToString() + "");
            AStr = AStr.Replace("dataFld=SYS_DateMonth_" + num + "", "  dataFld=SYS_DateMonth_" + num + " value=" + DateTime.Now.Month.ToString() + "");
            AStr = AStr.Replace("dataFld=SYS_DateDate_" + num + "", "  dataFld=SYS_DateDate_" + num + " value=" + DateTime.Now.Day.ToString() + "");
            AStr = AStr.Replace("dataFld=SYS_DateHour_" + num + "", "  dataFld=SYS_DateHour_" + num + " value=" + DateTime.Now.Hour.ToString() + "");
            AStr = AStr.Replace("dataFld=SYS_DateMinute_" + num + "", "  dataFld=SYS_DateMinute_" + num + " value=" + DateTime.Now.Minute.ToString() + "");
            AStr = AStr.Replace("dataFld=SYS_DateSecond_" + num + "", "  dataFld=SYS_DateSecond_" + num + " value=" + DateTime.Now.Second.ToString() + "");
            AStr = AStr.Replace("dataFld=SYS_DateDayOfWeek_" + num + "", "  dataFld=SYS_DateDayOfWeek_" + num + " value=" + this.GetWeekDay() + "");
            AStr = AStr.Replace("dataFld=SYS_DateATime_" + num + "", "  dataFld=SYS_DateATime_" + num + " value=" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日");
            AStr = AStr.Replace("dataFld=SYS_DateBTime_" + num + "", "  dataFld=SYS_DateBTime_" + num + " value=" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月");
            AStr = AStr.Replace("dataFld=SYS_DateCTime_" + num + "", "  dataFld=SYS_DateCTime_" + num + " value=" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日");
            AStr = AStr.Replace("dataFld=SYS_DateDTime_" + num + "", "  dataFld=SYS_DateDTime_" + num + " value=" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "");
            AStr = AStr.Replace("dataFld=SYS_DateETime_" + num + "", "  dataFld=SYS_DateETime_" + num + " value=" + DateTime.Now.ToShortDateString() + "　" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "");
            AStr = AStr.Replace("dataFld=SYS_username_" + num + "", string.Concat(new object[] { "  dataFld=SYS_username_", num, " value=", HttpContext.Current.Session["username"], "" }));
            AStr = AStr.Replace("dataFld=SYS_RRDateDate_" + num + "", string.Concat(new object[] { "  dataFld=SYS_RRDateDate_", num, " value=", HttpContext.Current.Session["realname"], "", DateTime.Now.ToShortDateString(), "" }));
            AStr = AStr.Replace("dataFld=SYS_RRDateTime_" + num + "", string.Concat(new object[] { "  dataFld=SYS_RRDateTime_", num, " value=", HttpContext.Current.Session["realname"], "", DateTime.Now.ToString(), "" }));
            AStr = AStr.Replace("dataFld=SYS_IpAddress_" + num + "", "  dataFld=SYS_IpAddress_" + num + " value=" + HttpContext.Current.Request.UserHostAddress + "");
            AStr = AStr.Replace("dataFld=SYS_bdmc_" + num + "", "  dataFld=SYS_bdmc_" + num + " value=" + bdmc + "");
            AStr = AStr.Replace("dataFld=SYS_mcwh_" + num + "", "  dataFld=SYS_mcwh_" + num + " value=" + mcwh + "");
            AStr = AStr.Replace("dataFld=SYS_lcksrq_" + num + "", "  dataFld=SYS_lcksrq_" + num + " value=" + lcksrq + "");
            AStr = AStr.Replace("dataFld=SYS_lckssj_" + num + "", "  dataFld=SYS_lckssj_" + num + " value=" + lckssj + "");
            AStr = AStr.Replace("dataFld=SYS_lsh_" + num + "", string.Concat(new object[] { "  dataFld=SYS_lsh_", num, " value=", lsh, "" }));
            AStr = AStr.Replace("dataFld=SYS_AllJbrA_" + num + "", "  dataFld=SYS_AllJbrA_" + num + " value=" + this.FlowZbr(lcid) + "");
            AStr = AStr.Replace("dataFld=SYS_AllJbrB_" + num + "", "  dataFld=SYS_AllJbrB_" + num + " value=" + this.FlowJbr(lcid) + "");
            AStr = AStr.Replace("dataFld=SYS_AllYbr_" + num + "", "  dataFld=SYS_AllYbr_" + num + " value=" + this.FlowYbr(lcid) + "");
            AStr = AStr.Replace(" =\"\"", "");
            return AStr;
        }

        public string FormatKjStrZh(string AStr)
        {
            AStr = AStr.Replace("’", "'").Replace("display:none", "").Replace("DISPLAY: none", "").Replace("background-color: #f9f9f9", "").Replace("BACKGROUND-COLOR: #f9f9f9", "").Replace("BACKGROUND-COLOR: #F9F9F9", "").Replace("BACKGROUND-COLOR: #F9FBD5", "").Replace("dragAble", "dragLCAble").Replace("disabled", "").Replace("readonly", "").Replace("readOnly", "").Replace("{宏}用户姓名", "").Replace("{宏}用户部门短名称", "").Replace("{宏}用户部门长名称", "").Replace("{宏}用户角色", "").Replace("{宏}用户职位", "").Replace("{宏}用户部门主管(本部门)", "").Replace("{宏}用户部门主管(上级部门)", "").Replace("{宏}用户部门主管(一级部门)", "").Replace("{宏}当前日期(形如2009-1-1)", "").Replace("{宏}当前日期(年)", "").Replace("{宏}当前日期(月)", "").Replace("{宏}当前日期(日)", "").Replace("{宏}当前日期(时)", "").Replace("{宏}当前日期(分)", "").Replace("{宏}当前日期(秒)", "").Replace("{宏}当前日期(星期)", "").Replace("{宏}当前日期(形如2009年1月1日)", "").Replace("{宏}当前日期(形如2009年1月)", "").Replace("{宏}当前日期(形如1月1日)", "").Replace("{宏}当前时间(形如12:12:12)", "").Replace("{宏}当前时间(形如2009-12-12 12:12:12)", "").Replace("{宏}用户ID", "").Replace("{宏}用户的姓名+日期", "").Replace("{宏}用户的姓名+具体日期时间", "").Replace("{宏}经办人IP", "").Replace("{宏}表单名称", "").Replace("{宏}名称/文号", "").Replace("{宏}流程开始日期", "").Replace("{宏}流程开始的日期+时间", "").Replace("{宏}流水号", "").Replace("{宏}当前步骤主办人", "").Replace("{宏}当前步骤所有经办人", "").Replace("{宏}所有已经办人员", "");
            return AStr;
        }

        public string FormatWh(string AStr, string LcNameId, string BianhaoWs, string FlowName)
        {
            if ("" == AStr)
            {
                return "";
            }
            AStr = AStr.Replace("{Y}", DateTime.Now.Year.ToString());
            AStr = AStr.Replace("{M}", DateTime.Now.Month.ToString());
            AStr = AStr.Replace("{D}", DateTime.Now.Day.ToString());
            AStr = AStr.Replace("{H}", DateTime.Now.Hour.ToString());
            AStr = AStr.Replace("{I}", DateTime.Now.Minute.ToString());
            AStr = AStr.Replace("{S}", DateTime.Now.Second.ToString());
            AStr = AStr.Replace("{F}", FlowName);
            AStr = AStr.Replace("{U}", HttpContext.Current.Session["realname"].ToString());
            AStr = AStr.Replace("{DN}", this.BumenBh(HttpContext.Current.Session["BuMenId"].ToString()));
            AStr = AStr.Replace("{SD}", this.BumenName(HttpContext.Current.Session["BuMenId"].ToString()));
            AStr = AStr.Replace("{R}", this.JueseName(HttpContext.Current.Session["JueseId"].ToString()));
            AStr = AStr.Replace("{N}", "" + LcNameId + "");
            AStr = AStr.Replace("{W}", this.GetWeekDay());
            return AStr;
        }

        private string GetWeekDay()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "星期日";

                case DayOfWeek.Monday:
                    return "星期一";

                case DayOfWeek.Tuesday:
                    return "星期二";

                case DayOfWeek.Wednesday:
                    return "星期三";

                case DayOfWeek.Thursday:
                    return "星期四";

                case DayOfWeek.Friday:
                    return "星期五";

                case DayOfWeek.Saturday:
                    return "星期六";
            }
            return "";
        }

        public string JueseName(string id)
        {
            string str = null;
            string sql = "select Name from qp_oa_Juese where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Name"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }

        private string SysBumenLb(string num, int IDStr, string line)
        {
            string str = null;
            this.SysBumenLbC(IDStr, line);
            return (str + this.bmstr);
        }

        private void SysBumenLbC(int IDStr, string line)
        {
            string sql = "select id,Name,ParentNodesID from qp_oa_bumen where ParentNodesID=" + IDStr.ToString() + "";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                int num;
                string bmstr;
                if (IDStr == 0)
                {
                    bmstr = this.bmstr;
                    this.bmstr = bmstr + "<option value=\"" + list["Name"].ToString() + "\">|-" + list["Name"].ToString() + "</option>";
                    num = int.Parse(list["ID"].ToString());
                    this.SysBumenLbC(num, "|-");
                }
                else
                {
                    string str2 = "" + line + "--";
                    bmstr = this.bmstr;
                    this.bmstr = bmstr + "<option value=\"" + list["Name"].ToString() + "\">" + str2 + "" + list["Name"].ToString() + "</option>";
                    num = int.Parse(list["ID"].ToString());
                    this.SysBumenLbC(num, str2);
                }
            }
            list.Close();
        }

        private string SysJueseLb()
        {
            string str = null;
            string sql = "select name from qp_oa_Juese";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str4 = str;
                str = str4 + "<option value=\"" + list["name"].ToString() + "\">" + list["name"].ToString() + "</option>";
            }
            list.Close();
            return str;
        }

        private string SysRenyuanLb()
        {
            string str = null;
            string sql = "select Realname from qp_oa_Username where   Iflogin='1' and StardType='1' and ifdel='0'";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str4 = str;
                str = str4 + "<option value=\"" + list["Realname"].ToString() + "\">" + list["Realname"].ToString() + "</option>";
            }
            list.Close();
            return str;
        }

        private string SysZhiweiLb()
        {
            string str = null;
            string sql = "select name from qp_oa_Zhiwei";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str4 = str;
                str = str4 + "<option value=\"" + list["name"].ToString() + "\">" + list["name"].ToString() + "</option>";
            }
            list.Close();
            return str;
        }

        public string ZhiweiName(string id)
        {
            string str = null;
            string sql = "select Name from qp_oa_Zhiwei where  id='" + id + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Name"].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            if (str.Trim() == "")
            {
                str = "　";
            }
            return str;
        }
    }
}


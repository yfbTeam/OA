namespace qiupeng.hr
{
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web;

    public class divhr
    {
        private Db List = new Db();

        public string AllDataFile(string CodeId, string TypeId)
        {
            string str = null;
            string sql = "select Name from qp_crm_AllDataFile where id='" + CodeId + "' and type='" + TypeId + "'";
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
            return str;
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

        public string HrMoban(string str)
        {
            if (str == "1")
            {
                str = "用人申请";
            }
            if (str == "2")
            {
                str = "简历管理";
            }
            if (str == "3")
            {
                str = "正式录用";
            }
            return str;
        }

        public string HRSType(string str)
        {
            if (str == "1")
            {
                str = "民族";
            }
            if (str == "2")
            {
                str = "籍贯";
            }
            if (str == "3")
            {
                str = "政治面貌";
            }
            if (str == "4")
            {
                str = "学历";
            }
            if (str == "5")
            {
                str = "专业";
            }
            if (str == "6")
            {
                str = "职称";
            }
            if (str == "7")
            {
                str = "员工类型";
            }
            if (str == "8")
            {
                str = "调动类型";
            }
            if (str == "9")
            {
                str = "离职类型";
            }
            if (str == "10")
            {
                str = "复职类型";
            }
            if (str == "11")
            {
                str = "奖励类型";
            }
            if (str == "12")
            {
                str = "惩罚类型";
            }
            if (str == "13")
            {
                str = "技能分类";
            }
            if (str == "14")
            {
                str = "体检结果";
            }
            return str;
        }

        public void Insertlsz(string HetongID, string Leixing, string Xiangqing)
        {
            string sql = string.Concat(new object[] { "insert into qp_hr_Hetongls (HetongID,Leixing,Username,Realname,SetTimes,Xiangqing) values ('", HetongID, "','", Leixing, "','", HttpContext.Current.Session["Username"], "','", HttpContext.Current.Session["Realname"], "','", DateTime.Now.ToString(), "','", Xiangqing, "')" });
            this.List.ExeSql(sql);
        }

        public string SaleUser()
        {
            string str = null;
            string sql = "select contentuser from qp_crm_SaleUser";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                string str3 = null;
                string str4 = "" + reader["contentuser"].ToString() + "";
                ArrayList list = new ArrayList();
                string[] strArray = str4.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    str3 = str3 + "'" + strArray[i] + "',";
                }
                str = str3 + "'0'";
            }
            reader.Close();
            return str;
        }

        public string TypeCode(string FileName, string Table, string CodeId)
        {
            string str = null;
            string sql = "select " + FileName + " from " + Table + " where id='" + CodeId + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["" + FileName + ""].ToString();
            }
            else
            {
                str = "";
            }
            list.Close();
            return str;
        }

        public string TypeCodeFX(string FileName, string Table, string CodeId)
        {
            string str = null;
            string sql = "select " + FileName + " from " + Table + " where id='" + CodeId + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["" + FileName + ""].ToString();
            }
            else
            {
                str = "未分类";
            }
            list.Close();
            return str;
        }
    }
}


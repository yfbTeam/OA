namespace qiupeng.crm
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;

    public class divcrm
    {
        private Db List = new Db();
        private publics pulicss = new publics();

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

        public string TypeCodeDr(string FileName, string Table, string CodeName)
        {
            string str = null;
            string sql = "select id from " + Table + " where " + FileName + "='" + CodeName + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["id"].ToString();
            }
            else
            {
                str = "0";
            }
            list.Close();
            return str;
        }
    }
}


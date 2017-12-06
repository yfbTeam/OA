namespace qiupeng.pm
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;

    public class divpm
    {
        private Db List = new Db();

        public string ChlidQX()
        {
            return "";
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

        public string TypeCodeAll(string FileName, string Table, string CodeId, string KeyId)
        {
            string str = null;
            string sql = "select " + FileName + " from " + Table + " where " + KeyId + "='" + CodeId + "' ";
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
    }
}


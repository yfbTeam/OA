namespace qiupeng.sch
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web;

    public class divsch
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        public string AllDataFile(string CodeId, string TypeId)
        {
            string str = null;
            string sql = "select Name from qp_sch_DataFile where id='" + CodeId + "' and type='" + TypeId + "'";
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

        public string GetXueduan()
        {
            string str = null;
            string sql = "select * from qp_sch_Chushihua";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Xueduan"].ToString();
            }
            list.Close();
            return str;
        }

        public string GetXueqi()
        {
            string str = null;
            string sql = "select * from qp_sch_Chushihua";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str = list["Xueqi"].ToString();
            }
            list.Close();
            return str;
        }

        public void InsertLog(string XsId, string Xueqi, string Xueduan, string Xiangmu, string Miaosu, string Fenlei)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_sch_Rizhi (XsId,Xueqi,Xueduan,Xiangmu,Miaosu,Username,Realname,Nowtimes,Fenlei) values ('", XsId, "','", Xueqi, "','", Xueduan, "','", Xiangmu, "','", Miaosu, "','", HttpContext.Current.Session["username"], "','", HttpContext.Current.Session["realname"], "','", DateTime.Now.ToString(), 
                "','", Fenlei, "')"
             });
            this.List.ExeSql(sql);
        }

        public string SchType(string str)
        {
            if (str == "1")
            {
                str = "学生职务";
            }
            if (str == "2")
            {
                str = "处罚类别";
            }
            if (str == "3")
            {
                str = "获奖类别";
            }
            if (str == "4")
            {
                str = "评语词库";
            }
            if (str == "5")
            {
                str = "日常学习";
            }
            if (str == "6")
            {
                str = "生源类别(小学)";
            }
            if (str == "7")
            {
                str = "生源类别(初中)";
            }
            if (str == "8")
            {
                str = "生源类别(高中)";
            }
            if (str == "9")
            {
                str = "建筑类型";
            }
            if (str == "10")
            {
                str = "建筑用途";
            }
            if (str == "11")
            {
                str = "房屋状态";
            }
            if (str == "12")
            {
                str = "房屋结构";
            }
            if (str == "13")
            {
                str = "信息类别设置";
            }
            if (str == "14")
            {
                str = "健康状况";
            }
            if (str == "15")
            {
                str = "学生户口类型";
            }
            if (str == "16")
            {
                str = "学生户口性质";
            }
            if (str == "17")
            {
                str = "民族设置";
            }
            if (str == "18")
            {
                str = "政治面貌";
            }
            if (str == "19")
            {
                str = "考试类型";
            }
            if (str == "20")
            {
                str = "学籍状态";
            }
            if (str == "21")
            {
                str = "品德总评等第";
            }
            if (str == "22")
            {
                str = "缴费类型";
            }
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

        public string TypeCodeDrLx(string FileName, string Table, string CodeName, string type)
        {
            string str = null;
            string sql = "select id from " + Table + " where " + FileName + "='" + CodeName + "' and type='" + type + "'";
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


namespace xyoa
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class CountMessagejs : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public int HeightStr;
        public string iftx;
        private Db List = new Db();
        public string Sound;
        public string txtime;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_MyReminded where username='" + this.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.iftx = list["iftx"].ToString();
                this.txtime = list["txtime"].ToString();
                this.Sound = list["Sound"].ToString();
            }
            list.Close();
        }
    }
}


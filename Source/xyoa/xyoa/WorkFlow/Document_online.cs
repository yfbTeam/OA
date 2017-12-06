namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class Document_online : Page
    {
        public string data;
        public string docid;
        public string fenlei;
        public string filename;
        public string fljs;
        public string htmlfile;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        public string richeng;
        public string shuqian;
        public string URL;
        public string yzlist;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sql = "select Newname,Name+'('+YxType+')' as Name  from qp_oa_YinZhang where Username='" + this.Session["Username"] + "' and  State='正常'";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    string yzlist = this.yzlist;
                    this.yzlist = yzlist + "<option value=\"" + list["Newname"].ToString() + "\">" + list["Name"].ToString() + "</option>";
                }
                list.Close();
                this.filename = base.Request.QueryString["file"];
                if ((this.filename != null) && (this.filename.Length != 0))
                {
                    this.URL = "/" + this.filename;
                    this.docid = "";
                    this.data = "";
                }
            }
        }
    }
}


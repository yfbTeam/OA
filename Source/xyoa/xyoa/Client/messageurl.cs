namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;

    public class messageurl : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string str = FormsAuthentication.HashPasswordForStoringInConfigFile(base.Request.QueryString["pwd"].ToString(), "MD5");
            string sql = "select Username,Password,Iflogin,Realname,BuMenId,ResponQx,MoveTel,Zhiweiid,JueseId  from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "' and Password='" + str + "'and Iflogin='1'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.Session["Username"] = list["Username"].ToString();
                this.Session["Realname"] = list["Realname"].ToString();
                this.Session["Zhiweiid"] = list["Zhiweiid"].ToString();
                this.Session["JueseId"] = list["JueseId"].ToString();
                this.Session["BuMenId"] = list["BuMenId"].ToString();
                this.Session["perstr"] = list["ResponQx"].ToString();
                this.Session["MoveTel"] = list["MoveTel"].ToString();
                this.Session["yangshi"] = this.pulicss.Getyangshi();
                string str3 = "select Logos,Titles from qp_oa_FaceMade";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    this.Session["Titles"] = reader2["Titles"].ToString();
                }
                reader2.Close();
                string str4 = "select * from qp_oa_FjKey";
                SqlDataReader reader3 = this.List.GetList(str4);
                if (reader3.Read())
                {
                    this.Session["FjKey"] = reader3["content"].ToString();
                }
                reader3.Dispose();
                Random random = new Random();
                string str5 = random.Next(0x2710).ToString();
                base.Response.Redirect("" + base.Server.UrlDecode(base.Request.QueryString["url"]) + "&rad=" + str5 + "");
            }
            else
            {
                base.Response.Redirect("LoginMenu.aspx");
                return;
            }
            list.Close();
        }
    }
}


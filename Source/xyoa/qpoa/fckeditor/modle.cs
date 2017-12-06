namespace qpoa.fckeditor
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class modle : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        public string ModelContent;
        protected DropDownList typename;

        public void DataBindToGridview(string StrCheck)
        {
            string str;
            SqlDataReader list;
            int num;
            string str2;
            object modelContent;
            if (StrCheck == "0")
            {
                this.ModelContent = "";
                str = string.Concat(new object[] { "select  * from qp_oa_OftenModle  where (Username='", this.Session["Username"], "') or ( CHARINDEX(',", this.Session["Username"], ",',','+SharingUsername+',')   >   0  and Sharing='是') order by id desc" });
                list = this.List.GetList(str);
                num = 0;
                while (list.Read())
                {
                    str2 = string.Empty;
                    str2 = list["content"].ToString();
                    modelContent = this.ModelContent;
                    this.ModelContent = string.Concat(new object[] { modelContent, "  <tr class=\"TableControl\">  <td align=\"middle\" class=\"menulines\" onclick=\"javascript:window.opener.qiupengmodel('", str2, "');window.close()\" style=\"cursor: hand\">", list["name"], "</td> </tr>" });
                    num++;
                    if (num == 1)
                    {
                        num = 0;
                    }
                }
                list.Close();
            }
            else
            {
                this.ModelContent = "";
                str = string.Concat(new object[] { "select  * from qp_oa_OftenModle  where (Username='", this.Session["Username"], "' and typeid='", StrCheck, "') or ( CHARINDEX(',", this.Session["Username"], ",',','+SharingUsername+',')   >   0  and  Sharing='是'  and typeid='", StrCheck, "') order by id desc" });
                list = this.List.GetList(str);
                num = 0;
                while (list.Read())
                {
                    str2 = string.Empty;
                    str2 = list["content"].ToString();
                    modelContent = this.ModelContent;
                    this.ModelContent = string.Concat(new object[] { modelContent, "  <tr class=\"TableControl\">  <td align=\"middle\" class=\"menulines\" onclick=\"javascript:window.opener.qiupengmodel('", str2, "');window.close()\" style=\"cursor: hand\">", list["name"], "</td> </tr>" });
                    num++;
                    if (num == 1)
                    {
                        num = 0;
                    }
                }
                list.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_OftenModleType where username='" + this.Session["username"] + "' order by id asc";
                this.list.Bind_DropDownListmodle(this.typename, sQL, "id", "name");
            }
            this.DataBindToGridview(this.typename.SelectedValue);
        }
    }
}


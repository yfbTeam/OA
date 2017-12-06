namespace xyoa.fckeditor
{
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open : Page
    {
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        public string ModelContent;
        protected DropDownList typename;

        public void DataBindToGridview(string StrCheck)
        {
            string str;
            if (StrCheck == "0")
            {
                str = string.Concat(new object[] { "select  * from qp_oa_OftenModle  where (Username='", this.Session["Username"], "') or ( CHARINDEX(',", this.Session["Username"], ",',','+SharingUsername+',')   >   0  and Sharing='是') order by id desc" });
                this.list.Bind_DropDownList_nothing(this.DropDownList1, str, "Content", "name");
            }
            else
            {
                str = string.Concat(new object[] { "select  * from qp_oa_OftenModle  where (Username='", this.Session["Username"], "' and typeid='", StrCheck, "') or ( CHARINDEX(',", this.Session["Username"], ",',','+SharingUsername+',')   >   0  and  Sharing='是'  and typeid='", StrCheck, "') order by id desc" });
                this.list.Bind_DropDownList_nothing(this.DropDownList1, str, "Content", "name");
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


namespace xyoa.SystemManage.anquan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class card : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label xulie;

        public string GetInterIDList(string strfile)
        {
            string str = "";
            if (!File.Exists(HttpContext.Current.Server.MapPath(strfile)))
            {
                return str;
            }
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(strfile), Encoding.Default);
            string str2 = reader.ReadToEnd();
            reader.Close();
            return str2;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                base.Response.Write("<!--\n当前合法单位：" + this.Session["cdk1"].ToString() + " \n-->");
                this.Label1.Text = this.Session["cdk1"].ToString();
                if (this.Session["cdk3"].ToString() == "1900-01-01")
                {
                    this.Label2.Text = "无限期";
                }
                else
                {
                    this.Label2.Text = this.Session["cdk3"].ToString();
                }
                if (int.Parse(this.Session["cdk4"].ToString()) >= 500)
                {
                    this.Label3.Text = "无限制";
                }
                else
                {
                    this.Label3.Text = this.Session["cdk4"].ToString();
                }
                this.Label4.Text = this.Session["cdk2"].ToString();
                this.xulie.Text = this.Session["cdk5"].ToString();
                this.Label5.Text = this.GetInterIDList("/update.txt");
            }
        }
    }
}


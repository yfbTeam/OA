namespace xyoa.HumanResources.PeiXun.PeixunZl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class PeixunZl_update : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MingchengID;
        private publics pulicss = new publics();
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str8;
            string str = base.Server.MapPath("File/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str8 = string.Concat(new object[] { "Update qp_hr_PeixunZl  Set MingchengID='", this.MingchengID.SelectedValue, "',[Name]='", fileName, "',[Newname]='HumanResources/PeiXun/PeixunZl/File/", str2, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str8);
            }
            else
            {
                str8 = string.Concat(new object[] { "Update qp_hr_PeixunZl  Set MingchengID='", this.MingchengID.SelectedValue, "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str8);
            }
            this.pulicss.InsertLog("新增培训资料", "培训资料");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='PeixunZl.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng from qp_hr_PeixunLb order by id asc";
                this.list.Bind_DropDownList_kong(this.MingchengID, sQL, "id", "Mingcheng");
                this.BindAttribute();
                string sql = "select * from qp_hr_PeixunZl where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.MingchengID.SelectedValue = list["MingchengID"].ToString();
                }
                list.Close();
            }
        }
    }
}


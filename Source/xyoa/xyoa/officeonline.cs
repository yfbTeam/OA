namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class officeonline : Page
    {
        protected Button Button1;
        protected HtmlInputButton Button10;
        protected HtmlInputButton Button3;
        protected HtmlInputButton Button6;
        protected HtmlInputButton Button8;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.ViewState["realname"] = this.Session["realname"].ToString();
                this.Button1.Attributes.Add("onclick", "javascript: SaveToWeb();");
                if (!base.IsPostBack)
                {
                    this.ViewState["number"] = base.Request.QueryString["number"].ToString();
                    string s = "select * from qp_oa_fileupload  where Newname='" + base.Request.QueryString["file"] + "'";
                    base.Response.Write(s);
                    SqlDataReader list = this.List.GetList(s);
                    if (list.Read())
                    {
                        this.ViewState["forname"] = list["Name"].ToString();
                        this.ViewState["forfile"] = list["NewName"].ToString();
                        this.ViewState["updatefilname"] = list["filetype"].ToString();
                    }
                    list.Close();
                    if ((this.ViewState["updatefilname"].ToString() == "doc") || (this.ViewState["updatefilname"].ToString() == "DOC"))
                    {
                        this.Button6.Visible = true;
                        this.Button8.Visible = true;
                        this.DropDownList1.Visible = true;
                        this.Button3.Visible = true;
                        this.Button10.Visible = true;
                    }
                    if ((this.ViewState["updatefilname"].ToString() == "xls") || (this.ViewState["updatefilname"].ToString() == "XLS"))
                    {
                        this.Button6.Visible = false;
                        this.Button8.Visible = false;
                        this.DropDownList1.Visible = false;
                        this.Button3.Visible = false;
                        this.Button10.Visible = false;
                    }
                    if ((this.ViewState["updatefilname"].ToString() == "ppt") || (this.ViewState["updatefilname"].ToString() == "PPT"))
                    {
                        this.Button6.Visible = true;
                        this.Button8.Visible = false;
                        this.DropDownList1.Visible = false;
                        this.Button3.Visible = false;
                        this.Button10.Visible = false;
                    }
                }
                string sQL = string.Concat(new object[] { "select * from qp_oa_DocumentModle where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by paixun asc" });
                if (!base.IsPostBack)
                {
                    this.list.Bind_DropDownList(this.DropDownList1, sQL, "Newname", "Name");
                }
            }
        }
    }
}


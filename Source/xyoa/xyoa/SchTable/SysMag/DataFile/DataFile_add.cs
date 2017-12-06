namespace xyoa.SchTable.SysMag.DataFile
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DataFile_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_sch_DataFile (Name,type,ifdel) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + base.Request.QueryString["type"].ToString() + "','0')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增" + this.ViewState["FileName"] + "", "教务系统数据字典");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='DataFile.aspx?type=" + base.Request.QueryString["type"].ToString() + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("DataFile.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ViewState["FileName"] = this.divsch.SchType(base.Request.QueryString["type"].ToString());
                this.BindAttribute();
            }
        }
    }
}


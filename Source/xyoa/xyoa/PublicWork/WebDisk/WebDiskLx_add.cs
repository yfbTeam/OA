namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WebDiskLx_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public string LineW;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        public string QxString;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_WebDiskLx (Name,Paixun,States,SetUsername,SetRealname,ParentNodesID) values ('", this.pulicss.GetFormatStr(this.Name.Text), "','", this.pulicss.GetFormatStr(this.Paixun.Text), "','1','", this.Session["username"], "','", this.Session["realname"], "','0')" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增硬盘目录", "网络硬盘目录");
            string str2 = "select top 1 * from qp_oa_WebDiskLx where ParentNodesID='0' and SetUsername='" + this.Session["username"] + "' order by id desc";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                string str3 = "insert into qp_oa_WebDiskLxQx  (name,nameid,FLiulang,FXinzeng,FXiugai,FShanchu,FQuanXian,BLiulang,BXinzeng,BXiugai,BShanchu,KeyId,Types,PiZhu,RiZhi) values ('创建人','2','1','1','1','1','1','1','1','1','1','" + list["id"].ToString() + "','1','允许查看全部','允许查看全部')";
                this.List.ExeSql(str3);
                string str4 = "insert into qp_oa_WebDiskLxQx  (name,nameid,FLiulang,FXinzeng,FXiugai,FShanchu,FQuanXian,BLiulang,BXinzeng,BXiugai,BShanchu,KeyId,Types,PiZhu,RiZhi) values ('系统管理员','admin','1','1','1','1','1','1','1','1','1','" + list["id"].ToString() + "','3','允许查看全部','允许查看全部')";
                this.List.ExeSql(str4);
                base.Response.Redirect("WebDiskLx_qx.aspx?id=" + list["id"].ToString() + "");
            }
            list.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WebDiskLx.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("jjjja1c", this.Session["perstr"].ToString());
                this.BindAttribute();
            }
        }
    }
}


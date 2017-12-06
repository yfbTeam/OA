namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_show_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public string LineW;
        public string LineWSta;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        protected TextBox Paixun;
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();
        public string QxString;
        public string QxStringSta;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_WebDiskLx (Name,Paixun,States,SetUsername,SetRealname,ParentNodesID) values ('", this.pulicss.GetFormatStr(this.Name.Text), "','", this.pulicss.GetFormatStr(this.Paixun.Text), "','0','", this.Session["username"], "','", this.Session["realname"], "','", this.pulicss.GetFormatStr(this.ParentNodesID.SelectedValue), "')" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增目录[" + this.Name.Text + "]", "硬盘浏览");
            string str2 = "select top 1 * from qp_oa_WebDiskLx where SetUsername='" + this.Session["username"] + "' order by id desc";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                string str3 = "insert into qp_oa_WebDiskLxQx  (name,nameid,FLiulang,FXinzeng,FXiugai,FShanchu,FQuanXian,BLiulang,BXinzeng,BXiugai,BShanchu,KeyId,Types,PiZhu,RiZhi) values ('创建人','2','1','1','1','1','1','1','1','1','1','" + list["id"].ToString() + "','1','允许查看全部','允许查看全部')";
                this.List.ExeSql(str3);
                string str4 = "insert into qp_oa_WebDiskLxQx  (name,nameid,FLiulang,FXinzeng,FXiugai,FShanchu,FQuanXian,BLiulang,BXinzeng,BXiugai,BShanchu,KeyId,Types,PiZhu,RiZhi) values ('系统管理员','admin','1','1','1','1','1','1','1','1','1','" + list["id"].ToString() + "','3','允许查看全部','允许查看全部')";
                this.List.ExeSql(str4);
                if (this.CheckBox2.Checked)
                {
                    string str5 = "select * from qp_oa_WebDiskLxQx  where KeyId=(select ParentNodesID from qp_oa_WebDiskLx  where id='" + list["id"] + "') and (name!='创建人' and name!='系统管理员')";
                    SqlDataReader reader2 = this.List.GetList(str5);
                    while (reader2.Read())
                    {
                        string str6 = string.Concat(new object[] { 
                            "insert into qp_oa_WebDiskLxQx  (name,nameid,FLiulang,FXinzeng,FXiugai,FShanchu,FQuanXian,BLiulang,BXinzeng,BXiugai,BShanchu,KeyId,Types,PiZhu,RiZhi) values ('", reader2["name"], "','", reader2["nameid"], "','", reader2["FLiulang"], "','", reader2["FXinzeng"], "','", reader2["FXiugai"], "','", reader2["FShanchu"], "','", reader2["FQuanXian"], "','", reader2["BLiulang"], 
                            "','", reader2["BXinzeng"], "','", reader2["BXiugai"], "','", reader2["BShanchu"], "','", list["id"], "','", reader2["Types"], "','", reader2["PiZhu"], "','", reader2["RiZhi"], "')"
                         });
                        this.List.ExeSql(str6);
                    }
                    reader2.Close();
                }
                base.Response.Redirect("MyWebDisk_show_qx.aspx?id=" + list["id"].ToString() + "&key=1");
            }
            list.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyWebDisk_show.aspx?id=" + base.Request.QueryString["id"].ToString() + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                string sql = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  and ((B.[Types]='1' and nameid='1' and FXinzeng='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FXinzeng='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FXinzeng='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FXinzeng='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FXinzeng='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    base.Response.Write("<script language=javascript>alert('不允许新建此文件夹！');window.location ='MyWebDisk_show.aspx?id=" + base.Request.QueryString["id"].ToString() + "'</script>");
                }
                list.Close();
                this.pulicss.BindListNothingDisk("[qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]", this.ParentNodesID, string.Concat(new object[] { " and ((B.[Types]='1' and nameid='1' and FLiulang='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FLiulang='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FLiulang='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FLiulang='1'))" }), " group by A.[Name],A.[id] order by A.id asc");
                if (base.Request.QueryString["id"] != null)
                {
                    this.ParentNodesID.SelectedValue = base.Request.QueryString["id"].ToString();
                }
            }
        }
    }
}


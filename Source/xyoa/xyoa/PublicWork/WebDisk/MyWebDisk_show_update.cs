namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_show_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public string LineW;
        protected TextBox Linew1;
        public string LineWSta;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        protected TextBox Paixun;
        protected TextBox ParentNodes;
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();
        public string QxString;
        protected TextBox QxString1;
        public string QxStringSta;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_WebDiskLx  Set ParentNodesID='", this.ParentNodesID.SelectedValue, "',Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Paixun='", this.pulicss.GetFormatStr(this.Paixun.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改硬盘目录[" + this.Name.Text + "]", "硬盘浏览");
            base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.nexthead.location = 'MyWebDisk_left.aspx'</script>");
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
                string sql = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  and ((B.[Types]='1' and nameid='1' and FXiugai='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FXiugai='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FXiugai='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FXiugai='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FXiugai='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    base.Response.Write("<script language=javascript>alert('不允许修改此文件夹！');window.location = 'MyWebDisk_show.aspx?id=" + base.Request.QueryString["id"].ToString() + "'</script>");
                }
                list.Close();
                this.pulicss.BindListBmDisk("[qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]", this.ParentNodesID, string.Concat(new object[] { " and ((B.[Types]='1' and nameid='1' and FLiulang='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FLiulang='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FLiulang='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FLiulang='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FLiulang='1'))" }), " group by A.[Name],A.[id] order by A.id asc");
                string str2 = "select * from qp_oa_WebDiskLx where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.Name.Text = reader2["Name"].ToString();
                    this.ParentNodesID.SelectedValue = reader2["ParentNodesID"].ToString();
                    this.Paixun.Text = reader2["Paixun"].ToString();
                    this.ParentNodes.Text = reader2["ParentNodesID"].ToString();
                    this.QxString1.Text = reader2["QxString"].ToString();
                    this.Linew1.Text = reader2["Linew"].ToString();
                    reader2.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到对应数据！');window.parent.location = 'MyWebDisk.aspx'</script>");
                }
            }
        }
    }
}


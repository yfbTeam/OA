namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_show_qx : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected GridView GridView2;
        protected GridView GridView3;
        protected GridView GridView4;
        protected HtmlHead Head1;
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected LinkButton LinkButton3;
        protected LinkButton LinkButton4;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Name.Attributes.Add("readonly", "readonly");
            this.LinkButton1.Attributes["onclick"] = "javascript:return openqx1();";
            this.LinkButton2.Attributes["onclick"] = "javascript:return openqx2();";
            this.LinkButton3.Attributes["onclick"] = "javascript:return openqx3();";
            this.LinkButton4.Attributes["onclick"] = "javascript:return openqx4();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_WebDiskLx  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["ParentNodesID"].ToString() == "0")
                {
                    base.Response.Write("<script language=javascript>alert('此目录为根目录，不存在上级目录权限！');</script>");
                    return;
                }
                string str2 = "delete from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                this.List.ExeSql(str2);
                string str3 = "select * from qp_oa_WebDiskLxQx  where KeyId=(select ParentNodesID from qp_oa_WebDiskLx  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "')";
                SqlDataReader reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    string str4 = string.Concat(new object[] { 
                        "insert into qp_oa_WebDiskLxQx  (name,nameid,FLiulang,FXinzeng,FXiugai,FShanchu,FQuanXian,BLiulang,BXinzeng,BXiugai,BShanchu,KeyId,Types,PiZhu,RiZhi) values ('", reader2["name"], "','", reader2["nameid"], "','", reader2["FLiulang"], "','", reader2["FXinzeng"], "','", reader2["FXiugai"], "','", reader2["FShanchu"], "','", reader2["FQuanXian"], "','", reader2["BLiulang"], 
                        "','", reader2["BXinzeng"], "','", reader2["BXiugai"], "','", reader2["BShanchu"], "','", base.Request.QueryString["id"], "','", reader2["Types"], "','", reader2["PiZhu"], "','", reader2["RiZhi"], "')"
                     });
                    this.List.ExeSql(str4);
                }
                reader2.Close();
                this.DataBindToGridview("order by id desc");
            }
            list.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.pulicss.InsertLog("设置硬盘目录权限", "硬盘浏览");
            base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'MyWebDisk.aspx'</script>");
        }

        public void DataBindToGridview(string Sqlsort)
        {
            string sql = "select * from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Types='1' " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str2 = "select * from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Types='2' " + Sqlsort + "";
            this.GridView2.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView2.DataBind();
            string str3 = "select * from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Types='3' " + Sqlsort + "";
            this.GridView3.DataSource = this.List.GetGrid_Pages_not(str3);
            this.GridView3.DataBind();
            string str4 = "select * from qp_oa_WebDiskLxQx where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Types='4' " + Sqlsort + "";
            this.GridView4.DataSource = this.List.GetGrid_Pages_not(str4);
            this.GridView4.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView2.PageIndex = e.NewPageIndex;
            this.GridView3.PageIndex = e.NewPageIndex;
            this.GridView4.PageIndex = e.NewPageIndex;
            this.DataBindToGridview("order by id desc");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "delete from qp_oa_WebDiskLxQx where id='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview("order by id desc");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button;
                LinkButton button2;
                if ((e.Row.Cells[0].Text.ToString() == "系统管理员") || (e.Row.Cells[0].Text.ToString() == "创建人"))
                {
                    button = (LinkButton) e.Row.FindControl("ShanChu");
                    button2 = (LinkButton) e.Row.FindControl("XiuGai");
                    button.Enabled = false;
                    button2.Enabled = false;
                }
                else
                {
                    button = (LinkButton) e.Row.FindControl("ShanChu");
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除[" + e.Row.Cells[0].Text.ToString() + "]吗')");
                    button2 = (LinkButton) e.Row.FindControl("XiuGai");
                    button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('WebDiskLx_qx_update.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "&KeyId=" + base.Request.QueryString["id"] + "','window','dialogWidth:680px;DialogHeight=280px;status:no;help=no;scroll=no');window.location='#'");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.Button1.Attributes.Add("onclick", "javascript:return zx();");
                    this.pulicss.QuanXianBack("jjjja1b", this.Session["perstr"].ToString());
                    string sql = "select * from qp_oa_WebDiskLx  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Name.Text = list["Name"].ToString();
                        if ((list["SetUsername"].ToString() != this.Session["username"].ToString()) || (base.Request.QueryString["key"] == null))
                        {
                            string str2 = string.Concat(new object[] { "select A.[Name],A.[id],A.[SetRealname] from [qp_oa_WebDiskLx] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[id] = [B].[KeyId]  and ((B.[Types]='1' and nameid='1' and FQuanXian='1') or (B.[Types]='1' and A.SetUsername='", this.Session["username"], "' and nameid='2' and FQuanXian='1') or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and FQuanXian='1') or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and FQuanXian='1') or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and FQuanXian='1')) and A.id='", base.Request.QueryString["id"], "'  group by A.[Name],A.[id],A.[SetRealname]" });
                            SqlDataReader reader2 = this.List.GetList(str2);
                            if (!reader2.Read())
                            {
                                base.Response.Write("<script language=javascript>alert('不允许设置此文件夹！');window.location = 'MyWebDisk_show.aspx?id=" + base.Request.QueryString["id"].ToString() + "'</script>");
                            }
                            reader2.Close();
                        }
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('未找到对应数据！');window.parent.location = 'MyWebDisk.aspx'</script>");
                        return;
                    }
                    list.Close();
                    this.BindAttribute();
                }
                this.DataBindToGridview("order by id desc");
            }
        }
    }
}


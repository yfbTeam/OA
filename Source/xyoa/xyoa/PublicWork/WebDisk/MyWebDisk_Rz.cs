namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_Rz : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
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
                string sql = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (RiZhi='只允许查看用户个人的' or RiZhi='只允许查看用户直属部门的' or RiZhi='允许查看全部')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (RiZhi='只允许查看用户个人的' or RiZhi='只允许查看用户直属部门的' or RiZhi='允许查看全部')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (RiZhi='只允许查看用户个人的' or RiZhi='只允许查看用户直属部门的' or RiZhi='允许查看全部')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (RiZhi='只允许查看用户个人的' or RiZhi='只允许查看用户直属部门的' or RiZhi='允许查看全部'))  or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (RiZhi='只允许查看用户个人的' or RiZhi='只允许查看用户直属部门的' or RiZhi='允许查看全部'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    base.Response.Write("<script language=javascript>alert('不允许查看此文件的操作日志！');window.close()</script>");
                }
                else
                {
                    string str3;
                    list.Close();
                    string str2 = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (RiZhi='允许查看全部')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (RiZhi='允许查看全部')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (RiZhi='允许查看全部')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (RiZhi='允许查看全部'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        str3 = "select * from qp_oa_MyWebDiskLog  where KeyId='" + base.Request.QueryString["KeyId"] + "' order by id desc";
                        this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                        this.GridView1.DataBind();
                    }
                    else
                    {
                        string str4 = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (RiZhi='只允许查看用户直属部门的')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (RiZhi='只允许查看用户直属部门的')) or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and (RiZhi='只允许查看用户直属部门的')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (RiZhi='只允许查看用户直属部门的')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (RiZhi='只允许查看用户直属部门的'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                        SqlDataReader reader3 = this.List.GetList(str4);
                        if (reader3.Read())
                        {
                            str3 = string.Concat(new object[] { "select * from qp_oa_MyWebDiskLog  where KeyId='", base.Request.QueryString["KeyId"], "' and BuMenId='", this.Session["BuMenId"], "' order by id desc" });
                            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                            this.GridView1.DataBind();
                        }
                        else
                        {
                            string str5 = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (RiZhi='只允许查看用户个人的')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (RiZhi='只允许查看用户个人的')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (RiZhi='只允许查看用户个人的')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (RiZhi='只允许查看用户个人的'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                            SqlDataReader reader4 = this.List.GetList(str5);
                            if (reader4.Read())
                            {
                                str3 = string.Concat(new object[] { "select * from qp_oa_MyWebDiskLog  where KeyId='", base.Request.QueryString["KeyId"], "' and Username='", this.Session["Username"], "' order by id desc" });
                                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                                this.GridView1.DataBind();
                            }
                            else
                            {
                                base.Response.Write("<script language=javascript>alert('不允许查看此文件的操作日志！');window.close()</script>");
                                return;
                            }
                            reader4.Close();
                        }
                        reader3.Close();
                    }
                    reader2.Close();
                }
            }
        }
    }
}


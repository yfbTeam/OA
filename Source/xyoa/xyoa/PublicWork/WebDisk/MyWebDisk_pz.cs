namespace xyoa.PublicWork.WebDisk
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyWebDisk_pz : Page
    {
        protected Button Button2;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        public string QxStringStr;
        protected TextBox TextBox2;

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (this.TextBox2.Text.Trim() != "")
            {
                string sql = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部'))  or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = string.Concat(new object[] { "insert into qp_oa_MyWebDiskPz  (KeyId,Username,Realname,SetTime,Contents,BuMenId) values ('", base.Request.QueryString["KeyId"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','", this.TextBox2.Text, "','", this.Session["BuMenId"], "')" });
                    this.List.ExeSql(str2);
                    string str3 = string.Concat(new object[] { "insert into qp_oa_MyWebDiskLog  (KeyId,Username,Realname,SetTime,Contents,BuMenId) values ('", base.Request.QueryString["KeyId"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','填写批注信息','", this.Session["BuMenId"], "')" });
                    this.List.ExeSql(str3);
                    base.Response.Write("<script language=javascript>alert('提交批注成功！');window.location.href='MyWebDisk_pz.aspx?KeyId=" + base.Request.QueryString["KeyId"] + "'</script>");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('提交批注失败！');window.close()</script>");
                    return;
                }
                list.Close();
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('批注内容不能为空！');</script>");
            }
        }

        public void DataBindToGridview()
        {
            string str2;
            string sql = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (PiZhu='允许查看全部')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (PiZhu='允许查看全部')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (PiZhu='允许查看全部')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (PiZhu='允许查看全部'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                str2 = "select * from qp_oa_MyWebDiskPz  where KeyId='" + base.Request.QueryString["KeyId"] + "' order by id desc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                this.GridView1.DataBind();
            }
            else
            {
                string str3 = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (PiZhu='只允许查看用户直属部门的')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (PiZhu='只允许查看用户直属部门的')) or (B.[Types]='2' and [B].[nameid]='", this.Session["BuMenId"], "' and (PiZhu='只允许查看用户直属部门的')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (PiZhu='只允许查看用户直属部门的')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (PiZhu='只允许查看用户直属部门的'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    str2 = string.Concat(new object[] { "select * from qp_oa_MyWebDiskPz  where KeyId='", base.Request.QueryString["KeyId"], "' and BuMenId='", this.Session["BuMenId"], "' order by id desc" });
                    this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                    this.GridView1.DataBind();
                }
                else
                {
                    string str4 = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (PiZhu='只允许查看用户个人的')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (PiZhu='只允许查看用户个人的')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (PiZhu='只允许查看用户个人的')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (PiZhu='只允许查看用户个人的'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                    SqlDataReader reader3 = this.List.GetList(str4);
                    if (reader3.Read())
                    {
                        str2 = string.Concat(new object[] { "select * from qp_oa_MyWebDiskPz  where KeyId='", base.Request.QueryString["KeyId"], "' and Username='", this.Session["Username"], "' order by id desc" });
                        this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                        this.GridView1.DataBind();
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('不允许进行文件批注操作！');window.close()</script>");
                        return;
                    }
                    reader3.Close();
                }
                reader2.Close();
            }
            list.Close();
        }

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
                this.TextBox2.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button2.click(); return false;}";
                string sql = string.Concat(new object[] { "select A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId] from [qp_oa_MyWebDiskFile] as [A] inner join [qp_oa_WebDiskLxQx] as [B] on [A].[TypeId] = [B].[KeyId] and ((B.[Types]='1' and nameid='1' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部')) or (B.[Types]='1' and A.Username='", this.Session["username"], "' and nameid='2' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部')) or (B.[Types]='3' and [B].[nameid]='", this.Session["username"], "' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部')) or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部'))  or (B.[Types]='4' and [B].[nameid]='", this.Session["Zhiweiid"], "' and (PiZhu='只允许查看用户个人的' or PiZhu='只允许查看用户直属部门的' or PiZhu='允许查看全部'))) and A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["KeyId"]), "' group by A.[OldName],A.[NewName],A.[Fjtype],A.[id],A.[TypeId]" });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    base.Response.Write("<script language=javascript>alert('不允许进行文件批注操作！');window.close()</script>");
                }
                else
                {
                    list.Close();
                    this.DataBindToGridview();
                }
            }
        }
    }
}


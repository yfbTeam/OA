namespace xyoa.SystemManage.Seal
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class SealManagePb_gl : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        protected System.Web.UI.WebControls.Image Newname;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox Username;

        public void BindAttribute()
        {
            this.Realname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chksyr();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_YinZhangPb where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "select * from qp_oa_YinZhang where Number='", list["Number"], "' and Username='", this.Username.Text, "' and YxType='公章' " });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    base.Response.Write("<script language=javascript>alert('此印章已经存在此使用人！');</script>");
                    return;
                }
                reader2.Close();
                string str3 = string.Concat(new object[] { 
                    "insert into qp_oa_YinZhang  (Number,Name,Oldname,Newname,Password,YxType,State,Username,Realname,Nowtimes) values ('", list["Number"], "','", list["Name"], "','", list["Oldname"], "','", list["Newname"], "','", list["Password"], "','公章','正常','", this.Username.Text, "','", this.Realname.Text, "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(str3);
            }
            list.Close();
            this.DataBindToGridview("order by id desc");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            base.Response.Redirect("SealManagePb.aspx");
        }

        public void DataBindToGridview(string Sqlsort)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select * from qp_oa_YinZhang where YxType='公章' and Number='" + base.Request.QueryString["Number"] + "'  " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int num;
            string str;
            SqlDataReader list;
            string str3;
            if (e.CommandName == "ShanChu")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select * from qp_oa_YinZhang where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您的印章[", list["Name"], "]被删除，操作人[", this.Session["realname"], "]请注意查看！" }), list["username"].ToString(), list["realname"].ToString(), "/MyWork/YinZhang/MyYinZhang.aspx");
                    string sql = "  Delete from qp_oa_YinZhang where ID='" + num + "'";
                    this.List.ExeSql(sql);
                    this.DataBindToGridview("order by id desc");
                    this.pulicss.InsertLog("删除印章[" + list["Name"] + "]", "公章维护");
                }
                list.Close();
            }
            if (e.CommandName == "Tingzhi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select * from qp_oa_YinZhang where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    if (list["State"].ToString() == "停止")
                    {
                        this.pulicss.InsertMessage(string.Concat(new object[] { "您的印章[", list["Name"], "]被重新启用，操作人[", this.Session["realname"], "]请注意查看！" }), list["username"].ToString(), list["realname"].ToString(), "/MyWork/YinZhang/MyYinZhang.aspx");
                        str3 = "Update qp_oa_YinZhang    Set State='正常' where id='" + num + "'";
                        this.List.ExeSql(str3);
                        this.pulicss.InsertLog("启用印章[" + list["Name"] + "]", "公章维护");
                    }
                    else
                    {
                        this.pulicss.InsertMessage(string.Concat(new object[] { "您的印章[", list["Name"], "]被停止使用，操作人[", this.Session["realname"], "]请注意查看！" }), list["username"].ToString(), list["realname"].ToString(), "/MyWork/YinZhang/MyYinZhang.aspx");
                        str3 = "Update qp_oa_YinZhang    Set State='停止' where id='" + num + "'";
                        this.List.ExeSql(str3);
                        this.pulicss.InsertLog("停止印章[" + list["Name"] + "]", "公章维护");
                    }
                    this.DataBindToGridview("order by id desc");
                }
                list.Close();
            }
            if (e.CommandName == "Chongzhi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select * from qp_oa_YinZhang where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    string str4 = string.Concat(new object[] { 
                        "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您的印章[", list["Name"], "]密码被重置，重置后密码为：666666。操作人[", this.Session["realname"], "]请注意查看！','您的印章[", list["Name"], "]密码被重置，重置后密码为：666666。操作人[", this.Session["realname"], "]请注意查看！','", DateTime.Now.ToString(), "','", list["Username"], "','", list["Realname"], "','系统消息','系统消息','0','WorkFlow/YinZhang.aspx','", DateTime.Now.Year.ToString(), 
                        "", DateTime.Now.Month.ToString(), "", DateTime.Now.Day.ToString(), "", DateTime.Now.Second.ToString(), "", DateTime.Now.Millisecond.ToString(), "')"
                     });
                    this.List.ExeSql(str4);
                    string str5 = FormsAuthentication.HashPasswordForStoringInConfigFile("666666", "MD5");
                    str3 = string.Concat(new object[] { "Update qp_oa_YinZhang  Set Password='", str5, "' where id='", num, "'" });
                    this.List.ExeSql(str3);
                    this.DataBindToGridview("order by id desc");
                    this.pulicss.InsertLog("印章密码重置[" + list["Name"] + "]", "公章维护");
                }
                list.Close();
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
                LinkButton button2;
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                button.Attributes.Add("onclick", "javascript:return confirm('确认删除印章[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                if (e.Row.Cells[1].Text.ToString() == "停止")
                {
                    button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                    button2.Text = "启用";
                    button2.Attributes.Add("onclick", "javascript:return confirm('确认启用印章[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                }
                else
                {
                    button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                    button2.Text = "停止";
                    button2.Attributes.Add("onclick", "javascript:return confirm('确认停止印章[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                }
                LinkButton button3 = (LinkButton) e.Row.FindControl("LinkButton3");
                button3.Attributes.Add("onclick", "javascript:return confirm('确认密码重置印章[" + e.Row.Cells[0].Text.ToString() + "]吗？重置后面密码为：666666')");
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sqlsort = "";
            if ((this.ViewState["SortDirection"] == null) || (this.ViewState["SortDirection"].ToString().CompareTo("") == 0))
            {
                this.ViewState["SortDirection"] = " desc";
            }
            else
            {
                this.ViewState["SortDirection"] = "";
            }
            sqlsort = " order by " + e.SortExpression + this.ViewState["SortDirection"];
            this.DataBindToGridview(sqlsort);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.pulicss.QuanXianBack("iiii3", this.Session["perstr"].ToString());
                if (!this.Page.IsPostBack)
                {
                    string sql = "select * from qp_oa_YinZhangPb where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' ";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Name.Text = list["Name"].ToString();
                        this.Newname.ImageUrl = "/seal/" + list["Newname"].ToString() + "";
                    }
                    list.Close();
                    this.DataBindToGridview("order by id desc");
                    this.BindAttribute();
                }
            }
        }
    }
}


namespace xyoa.SystemManage.Bumen
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Bumen_show : Page
    {
        protected Label Bianhao;
        protected Label BmPeople;
        protected Label BmRealname;
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label remark;

        public void BindAttribute()
        {
            this.Button3.Attributes["onclick"] = "javascript:return deltree();";
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                base.Response.Redirect("Bumen_update.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
            }
            else
            {
                base.Response.Redirect("Bumen_update.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["id"] != null)
            {
                base.Response.Redirect("Bumen_add.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
            }
            else
            {
                base.Response.Redirect("Bumen_add.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_username  where   BuMenId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('删除失败，其中存在正在使用的部门，请在用户管理中查看！');</script>");
            }
            else
            {
                list.Close();
                this.DelNode(base.Request.QueryString["id"], base.Request.QueryString["id"]);
                base.Response.Write("<script language=javascript>alert('删除成功！'); window.parent.location = 'Bumen.aspx'</script>");
            }
        }

        private void DelNode(string IDStr, string PID)
        {
            string sql = "  Delete from qp_oa_Bumen  where id='" + IDStr + "'";
            this.List.ExeSql(sql);
            string str2 = "select * from qp_oa_Bumen where (ParentNodesID=" + IDStr.ToString() + ")  order by id asc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                string str3 = "  Delete from qp_oa_Bumen  where id='" + list["ID"].ToString() + "'";
                this.List.ExeSql(str3);
                string str4 = "select * from qp_oa_Bumen where ParentNodesID=" + list["id"] + " ";
                SqlDataReader reader2 = this.List.GetList(str4);
                if (reader2.Read())
                {
                    string iDStr = list["ID"].ToString();
                    string pID = list["ParentNodesID"].ToString();
                    this.DelNode(iDStr, pID);
                }
                reader2.Close();
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianVis(this.Button3, "iiii7d", this.Session["perstr"].ToString());
                this.pulicss.QuanXianVis(this.Button1, "iiii7c", this.Session["perstr"].ToString());
                this.pulicss.QuanXianVis(this.Button2, "iiii7a", this.Session["perstr"].ToString());
                this.BindAttribute();
                if (base.Request.QueryString["id"] != null)
                {
                    string sql = "select * from qp_oa_Bumen where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.ViewState["showtitle"] = "";
                        this.Bianhao.Text = list["Bianhao"].ToString();
                        this.Name.Text = list["name"].ToString();
                        this.remark.Text = list["remark"].ToString();
                        this.BmRealname.Text = list["BmRealname"].ToString();
                        string str2 = "select realname from qp_oa_username where BuMenId='" + base.Request.QueryString["id"] + "'";
                        SqlDataReader reader2 = this.List.GetList(str2);
                        while (reader2.Read())
                        {
                            this.BmPeople.Text = this.BmPeople.Text + "" + reader2["realname"].ToString() + ",";
                        }
                        reader2.Close();
                        this.pulicss.InsertLog("查看部门信息[" + this.Name.Text + "]", "部门管理");
                    }
                    else
                    {
                        this.ViewState["showtitle"] = "<font color=red>无部门信息，请点击左边树型菜单</font>";
                        this.Button3.Visible = false;
                        this.Button1.Visible = false;
                    }
                    list.Close();
                }
                else
                {
                    this.ViewState["showtitle"] = "<font color=red>无部门信息，请点击左边树型菜单</font>";
                    this.Button3.Visible = false;
                    this.Button1.Visible = false;
                }
            }
        }
    }
}


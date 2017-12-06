namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_Username_two_zz : Page
    {
        protected Button Button4;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MyUserList;
        protected TextBox name;
        private publics pulicss = new publics();
        protected TextBox requeststr;
        protected DropDownList Unit;

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("open_Username_two_zz.aspx?key=1&name=" + this.name.Text + "&Unit=" + this.Unit.SelectedValue + "&yhz=" + this.MyUserList.SelectedValue + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if ((base.Request.QueryString["key"] != null) && (base.Request.QueryString["Name"].ToString() != ""))
            {
                str = str + " and Realname like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Name"])) + "%'";
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string str4;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string str = string.Concat(new object[] { "select id,Username,QxString,Realname from  qp_oa_username where StardType='1' and  ifdel='0'  ", this.ViewState["keystr"], "", this.ViewState["yhzstr"], "  " });
            string str2 = string.Empty;
            str2 = this.CreateMidSql();
            string str3 = str + str2 + " order by paixu asc";
            if (base.Request.QueryString["key"] != null)
            {
                str4 = "" + str3 + " ";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
                this.GridView1.DataBind();
            }
            else
            {
                str4 = string.Concat(new object[] { "select * from qp_oa_username where StardType='1'  and  ifdel='0' ", this.ViewState["keystr"], "", this.ViewState["yhzstr"], "  order by paixu asc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.DataBindToGridview();
            this.GridView1.DataBind();
        }

        protected void ListChangedBind(object sender, EventArgs e)
        {
            base.Response.Redirect("open_Username_two_zz.aspx?key=1&name=" + this.name.Text + "&Unit=" + this.Unit.SelectedValue + "&yhz=" + this.MyUserList.SelectedValue + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
                this.requeststr.Text = base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString());
            }
            if ((base.Request.QueryString["Unit"] != null) && (base.Request.QueryString["Unit"].ToString() != ""))
            {
                this.ViewState["keystr"] = " and BuMenId=" + base.Request.QueryString["Unit"].ToString() + "";
            }
            else
            {
                this.ViewState["keystr"] = "";
            }
            if ((base.Request.QueryString["yhz"] != null) && (base.Request.QueryString["yhz"].ToString() != ""))
            {
                string str = null;
                string str2 = null;
                string sql = "select GlUsername from qp_oa_MyUserList where id='" + base.Request.QueryString["yhz"] + "'";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    str2 = "" + reader["GlUsername"].ToString() + "";
                    ArrayList list = new ArrayList();
                    string[] strArray = str2.Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        str = str + "'" + strArray[i] + "',";
                    }
                    str = str + "'0'";
                }
                else
                {
                    str = "'0'";
                }
                reader.Close();
                this.ViewState["yhzstr"] = " and username in (" + str + ")";
            }
            else
            {
                this.ViewState["yhzstr"] = "";
            }
            if (!base.IsPostBack)
            {
                this.pulicss.BindListkong("qp_oa_Bumen", this.Unit, "", "order by Bianhao asc");
                string sQL = "select id,Name  from qp_oa_MyUserList where username='" + this.Session["username"] + "' order by Paixun asc";
                this.list.Bind_DropDownList_kong(this.MyUserList, sQL, "id", "Name");
                if (base.Request.QueryString["Unit"] != null)
                {
                    this.Unit.SelectedValue = base.Request.QueryString["Unit"].ToString();
                }
                if (base.Request.QueryString["yhz"] != null)
                {
                    this.MyUserList.SelectedValue = base.Request.QueryString["yhz"].ToString();
                }
            }
            this.DataBindToGridview();
        }
    }
}


namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_AddWorkFlow_add_Next_Zb : Page
    {
        protected Button Button4;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox name;
        private publics pulicss = new publics();
        protected TextBox requeststr;
        protected DropDownList Unit;

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("open_AddWorkFlow_add_Next_Zb.aspx?key=1&name=" + this.name.Text + "&Unit=" + this.Unit.SelectedValue + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "&user=" + base.Server.UrlDecode(base.Request.QueryString["user"].ToString()) + "");
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
            string str5;
            StateBag bag = ViewState;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string str = null;
            str = "" + base.Server.UrlDecode(base.Request.QueryString["user"].ToString()) + "";
            ArrayList list = new ArrayList();
            string[] strArray = str.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                object obj2 = bag["strlist"];
                (bag = this.ViewState)["strlist"] = string.Concat(new object[] { obj2, "'", strArray[i], "'," });
            }
            (bag = this.ViewState)["strlist"] = bag["strlist"] + "'0'";
            string str2 = "";
            if (base.Request.QueryString["user"].ToString() != "")
            {
                str2 = string.Concat(new object[] { "select id,Username,QxString,Realname from  qp_oa_username where username in (", this.ViewState["strlist"], ")  and  ifdel='0'  ", this.ViewState["keystr"], "" });
            }
            else
            {
                str2 = "select id,Username,QxString,Realname from  qp_oa_username where 1=1   and  ifdel='0' " + this.ViewState["keystr"] + "";
            }
            string str3 = string.Empty;
            str3 = this.CreateMidSql();
            string str4 = str2 + str3;
            if (base.Request.QueryString["key"] != null)
            {
                str5 = "" + str4 + " order by paixu asc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str5);
                this.GridView1.DataBind();
            }
            else
            {
                str5 = null;
                if (base.Request.QueryString["user"].ToString() != "")
                {
                    str5 = string.Concat(new object[] { "select * from qp_oa_username where username in (", this.ViewState["strlist"], ") and  ifdel='0' ", this.ViewState["keystr"], " order by paixu asc" });
                }
                else
                {
                    str5 = "select * from qp_oa_username where 1=1 and  ifdel='0' " + this.ViewState["keystr"] + " order by paixu asc";
                }
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str5);
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
            base.Response.Redirect("open_AddWorkFlow_add_Next_Zb.aspx?key=1&name=" + this.name.Text + "&Unit=" + this.Unit.SelectedValue + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "&user=" + base.Server.UrlDecode(base.Request.QueryString["user"].ToString()) + "");
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
            if (!base.IsPostBack)
            {
                this.pulicss.BindListkong("qp_oa_Bumen", this.Unit, "", "order by Bianhao asc");
                if (base.Request.QueryString["Unit"] != null)
                {
                    this.Unit.SelectedValue = base.Request.QueryString["Unit"].ToString();
                }
            }
            this.DataBindToGridview();
        }
    }
}


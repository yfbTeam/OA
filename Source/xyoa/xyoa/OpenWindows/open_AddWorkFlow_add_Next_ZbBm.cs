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

    public class open_AddWorkFlow_add_Next_ZbBm : Page
    {
        protected Button Button4;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox name;
        private publics pulicss = new publics();
        protected TextBox requeststr;

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("open_AddWorkFlow_add_Next_ZbBm.aspx?key=1&name=" + this.name.Text + "&Unit=" + base.Request.QueryString["Unit"].ToString() + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "&user=" + base.Server.UrlDecode(base.Request.QueryString["user"].ToString()) + "");
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
            string str6;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string str = null;
            string str2 = null;
            str2 = "" + base.Server.UrlDecode(base.Request.QueryString["user"].ToString()) + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + "'" + strArray[i] + "',";
            }
            str = str + "'0'";
            string str3 = "";
            if (base.Request.QueryString["user"].ToString() != "")
            {
                str3 = "select id,Username,QxString,Realname from  qp_oa_username where (username in (" + str + ") and  ifdel='0')";
            }
            else
            {
                str3 = "select id,Username,QxString,Realname from  qp_oa_username where 1=1  and  ifdel='0' " + this.ViewState["keystr"] + "";
            }
            string str4 = string.Empty;
            str4 = this.CreateMidSql();
            string str5 = str3 + str4;
            if (base.Request.QueryString["key"] != null)
            {
                str6 = "" + str5 + " ";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str6);
                this.GridView1.DataBind();
            }
            else
            {
                str6 = null;
                if (base.Request.QueryString["user"].ToString() != "")
                {
                    str6 = "select * from qp_oa_username where (username in (" + str + ") and  ifdel='0')";
                }
                else
                {
                    str6 = "select * from qp_oa_username where 1=1  and  ifdel='0' " + this.ViewState["keystr"] + "";
                }
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str6);
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.DataBindToGridview();
            this.GridView1.DataBind();
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
            this.DataBindToGridview();
        }
    }
}


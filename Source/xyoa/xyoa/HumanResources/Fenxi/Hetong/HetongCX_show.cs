namespace xyoa.HumanResources.Fenxi.Hetong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongCX_show : Page
    {
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected DropDownList DQtime;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected DropDownList LeibieID;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected TextBox QyRealname;
        protected TextBox QyUsername;
        protected TextBox Starttime;
        protected DropDownList Zhuangtai;

        public void BindAttribute()
        {
            this.QyRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.CheckBox1.Checked)
            {
                string sql = "select  LeibieID from qp_hr_HetongMB where id='" + base.Request.QueryString["id"].ToString() + "' ";
                SqlDataReader list = this.List.GetList(sql);
                string str2 = null;
                str2 = str2 + "(1!=1)";
                if (list.Read())
                {
                    string str3 = "select  * from qp_hr_HetongZd where LeibieID='" + list["LeibieID"].ToString() + "' order by id asc";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    while (reader2.Read())
                    {
                        if (base.Request.Form["" + reader2["Bianhao"] + ""] != "")
                        {
                            object obj2 = str2;
                            str2 = string.Concat(new object[] { obj2, " or ([A].[id] = [E].HetongID and [E].Neirong like '%", base.Request.Form["" + reader2["Bianhao"] + ""], "%' and [E].ZdBianhao='", reader2["Bianhao"], "')" });
                        }
                    }
                    reader2.Close();
                    this.Label1.Text = this.Label1.Text + "</table>";
                }
                list.Close();
                this.Session["searchurl"] = str2;
            }
            else
            {
                this.Session["searchurl"] = "";
            }
            base.Response.Write("<script language=javascript>window.parent.location.href='HetongCX_SearchList.aspx?LeibieID=" + this.LeibieID.SelectedValue + "&Zhuangtai=" + this.Zhuangtai.SelectedValue + "&QyUsername=" + this.QyUsername.Text + "&DQtime=" + this.DQtime.SelectedValue + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
                string sQL = "select id,Mingcheng from qp_hr_HetongMB where Zhuangtai=1 order by id asc";
                this.list.Bind_DropDownListHeTong(this.LeibieID, sQL, "id", "Mingcheng");
                this.LeibieID.SelectedValue = base.Request.QueryString["id"].ToString();
                if (base.Request.QueryString["id"].ToString() == "0")
                {
                    this.Panel1.Visible = false;
                }
                else
                {
                    string sql = "select  LeibieID from qp_hr_HetongMB where id='" + base.Request.QueryString["id"].ToString() + "' ";
                    SqlDataReader list = this.List.GetList(sql);
                    this.Label1.Text = null;
                    if (list.Read())
                    {
                        this.Label1.Text = this.Label1.Text + "<table align=\"center\" border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                        string str3 = "select  * from qp_hr_HetongZd where LeibieID='" + list["LeibieID"].ToString() + "' order by id asc";
                        SqlDataReader reader2 = this.List.GetList(str3);
                        while (reader2.Read())
                        {
                            object text = this.Label1.Text;
                            this.Label1.Text = string.Concat(new object[] { text, " <tr><td align=right class=newtd1 width=17%>", reader2["Mingcheng"], "：</td><td  class=newtd2 height=17 width=83% colspan=3><input id=\"", reader2["Bianhao"], "\"  name=\"", reader2["Bianhao"], "\" type=\"text\" size=\"50\" /></td></tr>" });
                        }
                        reader2.Close();
                        this.Label1.Text = this.Label1.Text + "</table>";
                    }
                    list.Close();
                    this.Panel1.Visible = true;
                }
                this.BindAttribute();
            }
        }
    }
}


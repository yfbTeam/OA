namespace xyoa.Resources.MyRes
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyResApply_Search : Page
    {
        protected Button Button1;
        protected DropDownList Cangku;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList ZyLeibie;
        protected TextBox ZyName;
        protected TextBox ZyNum;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindDroList()
        {
            string sQL = "select *  from qp_oa_ResourcesType";
            this.list.Bind_DropDownList_kong(this.ZyLeibie, sQL, "id", "Name");
            string str2 = string.Concat(new object[] { "select *  from qp_oa_ResourcesCangKu where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by Paixun asc" });
            this.list.Bind_DropDownList_kong(this.ZyLeibie, str2, "id", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script language=javascript>window.parent.location.href='MyResApply_SearchList.aspx?ZyNum=" + this.ZyNum.Text + "&ZyName=" + this.ZyName.Text + "&Cangku=" + this.ZyLeibie.SelectedValue + "'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindDroList();
                if (base.Request.QueryString["id"].ToString() == "0")
                {
                    this.ZyLeibie.SelectedValue = "";
                }
                else
                {
                    this.ZyLeibie.SelectedValue = base.Request.QueryString["id"].ToString();
                }
                this.BindAttribute();
            }
        }
    }
}


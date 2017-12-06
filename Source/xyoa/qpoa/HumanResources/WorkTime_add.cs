namespace qpoa.HumanResources
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkTime_add : Page
    {
        protected Button Button2;
        protected DropDownList DjType_1;
        protected DropDownList DjType_2;
        protected DropDownList DjType_3;
        protected DropDownList DjType_4;
        protected DropDownList DjType_5;
        protected DropDownList DjType_6;
        protected HtmlForm form1;
        protected DropDownList h1;
        protected DropDownList h2;
        protected DropDownList h3;
        protected DropDownList h4;
        protected DropDownList h5;
        protected DropDownList h6;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList m1;
        protected DropDownList m2;
        protected DropDownList m3;
        protected DropDownList m4;
        protected DropDownList m5;
        protected DropDownList m6;
        protected TextBox Number;
        protected TextBox PbType;
        private publics pulicss = new publics();
        protected DropDownList QyType;
        protected TextBox Riqi;
        protected TextBox SyRealname;
        protected TextBox SyUsername;
        protected CheckBoxList Xingqi;

        public void BindAttribute()
        {
            this.SyRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindDrop()
        {
            this.list.Bind_DropDownList_Hour(this.h1);
            this.list.Bind_DropDownList_Hour(this.h2);
            this.list.Bind_DropDownList_Hour(this.h3);
            this.list.Bind_DropDownList_Hour(this.h4);
            this.list.Bind_DropDownList_Hour(this.h5);
            this.list.Bind_DropDownList_Hour(this.h6);
            this.list.Bind_DropDownList_Mini(this.m1);
            this.list.Bind_DropDownList_Mini(this.m2);
            this.list.Bind_DropDownList_Mini(this.m3);
            this.list.Bind_DropDownList_Mini(this.m4);
            this.list.Bind_DropDownList_Mini(this.m5);
            this.list.Bind_DropDownList_Mini(this.m6);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_WorkTime  where QyType='" + this.pulicss.GetFormatStr(this.PbType.Text) + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('排班类型名重复！');</script>");
            }
            else
            {
                list.Close();
                string str2 = "insert into qp_WorkTime values('" + this.pulicss.GetFormatStr(this.PbType.Text) + "','" + this.DjType_1.SelectedValue + "','" + this.h1.SelectedValue + ":" + this.m1.SelectedValue + "','" + this.DjType_2.SelectedValue + "','" + this.h2.SelectedValue + ":" + this.m2.SelectedValue + "','" + this.DjType_3.SelectedValue + "','" + this.h3.SelectedValue + ":" + this.m3.SelectedValue + "','" + this.DjType_4.SelectedValue + "','" + this.h4.SelectedValue + ":" + this.m4.SelectedValue + "','" + this.DjType_5.SelectedValue + "','" + this.h5.SelectedValue + ":" + this.m5.SelectedValue + "','" + this.DjType_6.SelectedValue + "','" + this.h6.SelectedValue + ":" + this.m6.SelectedValue + "','" + this.QyType.SelectedValue + "','" + this.SyUsername.Text + "','" + this.SyRealname.Text + "','" + this.pulicss.GetChecked(this.Xingqi) + "','" + this.pulicss.GetFormatStr(this.Riqi.Text) + "')";
                this.List.ExeSql(str2);
                this.pulicss.InsertLog("新增上下班时间", "上下班时间");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkTime.aspx'</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkTime.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindDrop();
                this.BindAttribute();
            }
        }
    }
}


namespace qpoa.HumanResources
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkTime_update : Page
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
            string sql = string.Concat(new object[] { 
                "Update qp_WorkTime Set Riqi='", this.Riqi.Text, "', Xingqi='", this.pulicss.GetChecked(this.Xingqi), "', SyUsername='", this.SyUsername.Text, "', SyRealname='", this.SyRealname.Text, "',PbType='", this.pulicss.GetFormatStr(this.PbType.Text), "',QyType='", this.QyType.SelectedValue, "',DjType_1='", this.DjType_1.SelectedValue, "',DjType_2='", this.DjType_2.SelectedValue, 
                "',DjType_3='", this.DjType_3.SelectedValue, "',DjType_4='", this.DjType_4.SelectedValue, "',DjType_5='", this.DjType_5.SelectedValue, "',DjType_6='", this.DjType_6.SelectedValue, "',DjTime_1='", this.h1.SelectedValue, ":", this.m1.SelectedValue, "',DjTime_2='", this.h2.SelectedValue, ":", this.m2.SelectedValue, 
                "',DjTime_3='", this.h3.SelectedValue, ":", this.m3.SelectedValue, "',DjTime_4='", this.h4.SelectedValue, ":", this.m4.SelectedValue, "',DjTime_5='", this.h5.SelectedValue, ":", this.m5.SelectedValue, "',DjTime_6='", this.h6.SelectedValue, ":", this.m6.SelectedValue, 
                "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改上下班时间", "上下班时间");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkTime.aspx'</script>");
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
                string sql = "select * from qp_WorkTime   where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.SyUsername.Text = list["SyUsername"].ToString();
                    this.SyRealname.Text = list["SyRealname"].ToString();
                    this.PbType.Text = list["PbType"].ToString();
                    this.QyType.SelectedValue = list["QyType"].ToString();
                    this.DjType_1.SelectedValue = list["DjType_1"].ToString();
                    this.DjType_2.SelectedValue = list["DjType_2"].ToString();
                    this.DjType_3.SelectedValue = list["DjType_3"].ToString();
                    this.DjType_4.SelectedValue = list["DjType_4"].ToString();
                    this.DjType_5.SelectedValue = list["DjType_5"].ToString();
                    this.DjType_6.SelectedValue = list["DjType_6"].ToString();
                    this.h1.SelectedValue = DateTime.Parse(list["DjTime_1"].ToString()).Hour.ToString();
                    this.h2.SelectedValue = DateTime.Parse(list["DjTime_2"].ToString()).Hour.ToString();
                    this.h3.SelectedValue = DateTime.Parse(list["DjTime_3"].ToString()).Hour.ToString();
                    this.h4.SelectedValue = DateTime.Parse(list["DjTime_4"].ToString()).Hour.ToString();
                    this.h5.SelectedValue = DateTime.Parse(list["DjTime_5"].ToString()).Hour.ToString();
                    this.h6.SelectedValue = DateTime.Parse(list["DjTime_6"].ToString()).Hour.ToString();
                    this.m1.SelectedValue = DateTime.Parse(list["DjTime_1"].ToString()).Minute.ToString();
                    this.m2.SelectedValue = DateTime.Parse(list["DjTime_2"].ToString()).Minute.ToString();
                    this.m3.SelectedValue = DateTime.Parse(list["DjTime_3"].ToString()).Minute.ToString();
                    this.m4.SelectedValue = DateTime.Parse(list["DjTime_4"].ToString()).Minute.ToString();
                    this.m5.SelectedValue = DateTime.Parse(list["DjTime_5"].ToString()).Minute.ToString();
                    this.m6.SelectedValue = DateTime.Parse(list["DjTime_6"].ToString()).Minute.ToString();
                    this.pulicss.SetChecked(this.Xingqi, "," + list["Xingqi"].ToString() + ",");
                    this.Riqi.Text = list["Riqi"].ToString();
                }
            }
        }
    }
}


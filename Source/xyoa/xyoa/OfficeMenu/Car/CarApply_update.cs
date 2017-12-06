namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarApply_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected DropDownList CarId;
        protected TextBox Carpeople;
        protected TextBox CarpeopleUser;
        protected TextBox Destination;
        protected DropDownList Drivers;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected HtmlInputHidden NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Remark;
        protected TextBox Starttime;
        protected TextBox State;
        protected TextBox Subject;
        protected DropDownList UnitId;
        protected HtmlInputHidden YjbNodeId;

        public void BindAttribute()
        {
            this.Carpeople.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_CarApply    Set CarId='", this.CarId.SelectedValue, "',Drivers='", this.Drivers.SelectedValue, "',Carpeople='", this.pulicss.GetFormatStr(this.Carpeople.Text), "',CarpeopleUser='", this.pulicss.GetFormatStr(this.CarpeopleUser.Text), "',UnitId='", this.UnitId.SelectedValue, "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "',Endtime='", this.Endtime.Text, "',Destination='", this.Destination.Text, 
                "',Subject='", this.pulicss.GetFormatStr(this.Subject.Text), "',Remark='", this.pulicss.GetFormatStr(this.Remark.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改用车申请[" + this.CarId.SelectedValue + "]", "用车申请");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarApply.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarApply.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,CarName from qp_oa_CarInfo order by id asc";
                this.list.Bind_DropDownList_nothing(this.CarId, sQL, "id", "CarName");
                this.pulicss.BindListNothing("qp_oa_Bumen", this.UnitId, "", "order by Bianhao asc");
                string str2 = "select Realname from  qp_oa_DriverManager";
                this.list.Bind_DropDownList_nothing(this.Drivers, str2, "Realname", "Realname");
                string sql = "select * from qp_oa_CarApply  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.CarId.SelectedValue = list["CarId"].ToString();
                    this.Drivers.SelectedValue = list["Drivers"].ToString();
                    this.Carpeople.Text = list["Carpeople"].ToString();
                    this.UnitId.SelectedValue = list["UnitId"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Destination.Text = list["Destination"].ToString();
                    this.Subject.Text = list["Subject"].ToString();
                    this.State.Text = list["State"].ToString().Replace("1", "待审批").Replace("2", "已通过").Replace("3", "未通过").Replace("4", "使用中").Replace("5", "已结束");
                    this.Remark.Text = list["Remark"].ToString();
                    this.CarpeopleUser.Text = list["CarpeopleUser"].ToString();
                    this.Carpeople.Text = list["Carpeople"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


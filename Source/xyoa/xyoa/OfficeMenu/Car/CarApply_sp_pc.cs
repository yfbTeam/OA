namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarApply_sp_pc : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected DropDownList CarId;
        protected TextBox Carpeople;
        protected TextBox CarpeopleUser;
        protected CheckBox CheckBox3;
        protected TextBox Destination;
        protected DropDownList Drivers;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG2;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Remark;
        protected TextBox Starttime;
        protected TextBox Subject;
        protected DropDownList UnitId;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.CheckBox3, ",9,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG2, ",9,", this.pulicss.GetSms());
            this.Carpeople.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select Realname,MoveTel from qp_oa_DriverManager where  Realname='" + this.Drivers.SelectedValue + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read() && this.CheckBox3.Checked)
            {
                this.pulicss.InsertSms(list["MoveTel"].ToString(), string.Concat(new object[] { "您有新的车辆需要出行：", this.CarId.SelectedValue, "，用车人", this.Session["realname"], "" }));
            }
            list.Close();
            Random random = new Random();
            string glNum = random.Next(0x989680).ToString();
            this.pulicss.SpInsertLog("直接派车", this.Number.Text, "直接派车", this.Session["username"].ToString(), this.Session["realname"].ToString(), "3", glNum, "2", DateTime.Now.ToString(), "1");
            string str3 = string.Concat(new object[] { 
                "insert into qp_oa_CarApply (DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,CarId,Drivers,CarpeopleUser,Carpeople,UnitId,Starttime,Endtime,Destination,Subject,State,Remark,Miles,GhBeizhu,GhShijian,Username,Realname,NowTimes,Number) values ('直接派车','直接派车','3','','", glNum, "','','直接派车','0','','", this.CarId.SelectedValue, "','", this.Drivers.SelectedValue, "','", this.pulicss.GetFormatStr(this.CarpeopleUser.Text), "','", this.pulicss.GetFormatStr(this.Carpeople.Text), "','", this.UnitId.SelectedValue, "','", this.pulicss.GetFormatStr(this.Starttime.Text), "','", this.Endtime.Text, 
                "','", this.Destination.Text, "','", this.Subject.Text, "','2','", this.pulicss.GetFormatStr(this.Remark.Text), "','0','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToShortDateString(), "','", this.Number.Text, "')"
             });
            this.List.ExeSql(str3);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarApply.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (base.Request.QueryString["back"] == "1")
            {
                base.Response.Redirect("CarApply_sp.aspx");
            }
            if (base.Request.QueryString["back"] == "2")
            {
                base.Response.Redirect("CarApply_ysp.aspx");
            }
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
                Random random = new Random();
                string str3 = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str3 + "";
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.SchTable.Chengji.Luru
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Luru_PlSdlt_update : Page
    {
        protected DropDownList Bukao;
        protected TextBox BukaoCj;
        protected Button Button1;
        protected TextBox Chengji;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Kemu;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Miankao;
        private publics pulicss = new publics();
        protected DropDownList Quekao;
        protected TextBox Riqi;
        protected DropDownList Taidu;
        protected Label XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Chengji  Set  Riqi='", this.pulicss.GetFormatStr(this.Riqi.Text), "',Leixing='", this.Leixing.SelectedValue, "',Kemu='", this.Kemu.SelectedValue, "',Chengji='", this.pulicss.GetFormatStr(this.Chengji.Text), "',Miankao='", this.Miankao.SelectedValue, "',Quekao='", this.Quekao.SelectedValue, "',Bukao='", this.Bukao.SelectedValue, "',BukaoCj='", this.pulicss.GetFormatStr(this.BukaoCj.Text), 
                "',Taidu='", this.Taidu.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  "
             });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                string sql = "select * from qp_sch_Chengji  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    this.Xueduan.SelectedValue = list["Xueduan"].ToString();
                    string str3 = "select * from qp_sch_Nianji where  NianjiMc='" + this.divsch.TypeCode("Nianji", "qp_sch_Banji", this.pulicss.GetFormatStr(base.Request.QueryString["Njid"])) + "' and Xueqi='" + this.Xueqi.SelectedValue + "'";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        string str4;
                        if (this.Xueduan.SelectedValue == "上学期")
                        {
                            str4 = "select id,Name  from qp_sch_Kecheng where id in (" + reader2["Kecheng"].ToString() + ") order by id asc";
                            this.list.Bind_DropDownList_kong(this.Kemu, str4, "id", "Name");
                        }
                        else
                        {
                            str4 = "select id,Name  from qp_sch_Kecheng where id in (" + reader2["KechengX"].ToString() + ") order by id asc";
                            this.list.Bind_DropDownList_kong(this.Kemu, str4, "id", "Name");
                        }
                        string str5 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + reader2["Kaoshilx"].ToString() + ") order by id asc";
                        this.list.Bind_DropDownList_kong(this.Leixing, str5, "id", "name");
                    }
                    reader2.Close();
                    this.Riqi.Text = DateTime.Parse(list["Riqi"].ToString()).ToShortDateString();
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                    this.Kemu.SelectedValue = list["Kemu"].ToString();
                    this.Chengji.Text = list["Chengji"].ToString();
                    this.Miankao.SelectedValue = list["Miankao"].ToString();
                    this.Quekao.SelectedValue = list["Quekao"].ToString();
                    this.Bukao.SelectedValue = list["Bukao"].ToString();
                    this.BukaoCj.Text = list["BukaoCj"].ToString();
                    this.Taidu.SelectedValue = list["Taidu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


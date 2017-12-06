namespace xyoa.HumanResources.PeiXun.KaoShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoShi_update : Page
    {
        protected Button Button1;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox PRealname;
        private publics pulicss = new publics();
        protected TextBox PUsername;
        protected TextBox RealnameCj;
        protected TextBox Shijian;
        protected DropDownList Shijuan;
        protected TextBox Starttime;
        protected TextBox UsernameCj;
        protected RadioButtonList Zhuangtai;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.RealnameCj.Attributes.Add("readonly", "readonly");
            this.PRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "  Delete from qp_hr_MyKaoShi where KaoShiID='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { 
                "Update qp_hr_KaoShi   Set PUsername='", this.pulicss.GetFormatStr(this.PUsername.Text), "',PRealname='", this.pulicss.GetFormatStr(this.PRealname.Text), "',Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',ShijuanID='", this.Shijuan.SelectedValue, "',UsernameCj='", this.pulicss.GetFormatStr(this.UsernameCj.Text), "',RealnameCj='", this.pulicss.GetFormatStr(this.RealnameCj.Text), "',Starttime='", this.pulicss.GetFormatStr(this.Starttime.Text), "',Endtime='", this.pulicss.GetFormatStr(this.Endtime.Text), 
                "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Zhuangtai='", this.Zhuangtai.SelectedValue, "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(str2);
            string str3 = null;
            string str4 = null;
            str4 = "" + this.UsernameCj.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str4.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str3 = str3 + "'" + strArray[i] + "',";
            }
            str3 = str3 + "'0'";
            string str5 = "select username,realname from qp_oa_Username where  username in (" + str3 + ") ";
            SqlDataReader reader = this.List.GetList(str5);
            while (reader.Read())
            {
                string str6 = "insert into qp_hr_MyKaoShi  (Fenshu,KaoShiID,Starttime,Endtime,Zhuangtai,Username,Realname) values ('1.19','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','','','1','" + reader["username"].ToString() + "','" + reader["realname"].ToString() + "')";
                this.List.ExeSql(str6);
                this.pulicss.InsertMessage("您有在线考试需要参加，考试主题：" + this.Zhuti.Text + "<br>生效时间：" + this.Starttime.Text + "，终止时间：" + this.Endtime.Text + "<br>答题时间：" + this.Shijian.Text + "", reader["username"].ToString(), reader["realname"].ToString(), "/HumanResources/PeiXun/MyPage/KaoShi.aspx?Zhuangtai=1");
            }
            reader.Close();
            this.pulicss.InsertLog("发布网上考试", "网上考试");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KaoShi.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                string sQL = "select id,Titles from qp_hr_ShiJuan order by id asc";
                this.list.Bind_DropDownList_kong(this.Shijuan, sQL, "id", "Titles");
                string sql = string.Concat(new object[] { "select * from qp_hr_KaoShi where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Shijuan.SelectedValue = list["ShijuanID"].ToString();
                    this.UsernameCj.Text = list["UsernameCj"].ToString();
                    this.RealnameCj.Text = list["RealnameCj"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                    TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(this.Starttime.Text));
                    if (span.TotalDays > 0.0)
                    {
                        this.Button1.Enabled = false;
                        this.Button1.Text = "已超过生效时间，不能再修改";
                    }
                    this.PUsername.Text = list["PUsername"].ToString();
                    this.PRealname.Text = list["PRealname"].ToString();
                    list.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location = 'KaoShi.aspx'</script>");
                }
            }
        }
    }
}


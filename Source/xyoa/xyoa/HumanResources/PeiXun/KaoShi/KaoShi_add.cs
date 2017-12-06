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

    public class KaoShi_add : Page
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
            string sql = string.Concat(new object[] { 
                "insert into qp_hr_KaoShi  (Username,Realname,PUsername,PRealname,Zhuti,ShijuanID,UsernameCj,RealnameCj,Starttime,Endtime,Shijian,Zhuangtai) values ('", this.Session["Username"], "','", this.Session["Realname"], "','", this.pulicss.GetFormatStr(this.PUsername.Text), "','", this.pulicss.GetFormatStr(this.PRealname.Text), "','", this.pulicss.GetFormatStr(this.Zhuti.Text), "','", this.Shijuan.SelectedValue, "','", this.pulicss.GetFormatStr(this.UsernameCj.Text), "','", this.pulicss.GetFormatStr(this.RealnameCj.Text), 
                "','", this.pulicss.GetFormatStr(this.Starttime.Text), "','", this.pulicss.GetFormatStr(this.Endtime.Text), "','", this.pulicss.GetFormatStr(this.Shijian.Text), "','", this.Zhuangtai.SelectedValue, "')"
             });
            this.List.ExeSql(sql);
            string str2 = "select top 1 id from qp_hr_KaoShi order by id desc";
            SqlDataReader reader = this.List.GetList(str2);
            if (reader.Read())
            {
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
                SqlDataReader reader2 = this.List.GetList(str5);
                while (reader2.Read())
                {
                    string str6 = "insert into qp_hr_MyKaoShi  (Fenshu,KaoShiID,Starttime,Endtime,Zhuangtai,Username,Realname) values ('1.19','" + reader["id"].ToString() + "','','','1','" + reader2["username"].ToString() + "','" + reader2["realname"].ToString() + "')";
                    this.List.ExeSql(str6);
                    this.pulicss.InsertMessage("您有在线考试需要参加，考试主题：" + this.Zhuti.Text + "<br>生效时间：" + this.Starttime.Text + "，终止时间：" + this.Endtime.Text + "<br>答题时间：" + this.Shijian.Text + "", reader2["username"].ToString(), reader2["realname"].ToString(), "/HumanResources/PeiXun/MyPage/KaoShi.aspx?Zhuangtai=1");
                }
                reader2.Close();
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
                this.Starttime.Text = DateTime.Now.ToString();
            }
        }
    }
}


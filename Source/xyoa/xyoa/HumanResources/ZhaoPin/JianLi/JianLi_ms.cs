namespace xyoa.HumanResources.ZhaoPin.JianLi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class JianLi_ms : Page
    {
        protected TextBox acceptrealname;
        protected TextBox acceptusername;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Shijian;
        protected TextBox Xingming;

        public void BindAttribute()
        {
            this.Xingming.Attributes.Add("readonly", "readonly");
            this.acceptrealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            str2 = "" + this.acceptusername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + "'" + strArray[i] + "',";
            }
            str = str + "'0'";
            string sql = "select username,realname from qp_oa_Username where  username in (" + str + ") ";
            SqlDataReader reader = this.List.GetList(sql);
            while (reader.Read())
            {
                string str4 = "select id from qp_hr_JianLi where  id in (" + base.Request.QueryString["id"].ToString() + ",0) ";
                SqlDataReader reader2 = this.List.GetList(str4);
                while (reader2.Read())
                {
                    string str5 = "insert into qp_hr_MianShi  (XingmingId,Shijian,Hege,Beizhu,Username,Realname,SetTimes) values ('" + reader2["id"].ToString() + "','" + this.Shijian.Text + "','3','','" + reader["username"].ToString() + "','" + reader["realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
                    this.List.ExeSql(str5);
                    string str6 = "Update qp_hr_JianLi Set Zhuangtai='4' where id='" + reader2["id"].ToString() + "'";
                    this.List.ExeSql(str6);
                }
                reader2.Close();
                this.pulicss.InsertMessage("您有预约面试，预约时间：" + this.Shijian.Text + "", reader["username"].ToString(), reader["realname"].ToString(), "/HumanResources/ZhaoPin/MianShi/MianShi.aspx?Hege=3");
            }
            reader.Close();
            this.pulicss.InsertLog("发布预约面试", "预约面试");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='JianLi.aspx?Zhuangtai=4'</script>");
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
                string sql = "select Xingming from qp_hr_JianLi where  id in (" + base.Request.QueryString["id"].ToString() + ",0) ";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    this.Xingming.Text = this.Xingming.Text + "" + list["Xingming"].ToString() + ",";
                }
                list.Close();
            }
        }
    }
}


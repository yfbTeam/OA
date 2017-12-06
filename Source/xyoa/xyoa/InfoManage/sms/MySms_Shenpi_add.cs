namespace xyoa.InfoManage.sms
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MySms_Shenpi_add : Page
    {
        protected TextBox acceptrealname;
        protected TextBox acceptusername;
        protected Button Button1;
        protected Button Button2;
        protected TextBox Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected TextBox wbRealname;
        protected TextBox wbUsername;

        public void BindAttribute()
        {
            this.acceptrealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string glNum = random.Next(0x989680).ToString();
            this.pulicss.SpInsertLog("直接发送短信", this.Number.Text, "直接发送短信", this.Session["username"].ToString(), this.Session["realname"].ToString(), "3", glNum, "2", DateTime.Now.ToString(), "1");
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_shouji (Number,DqBlUsername,DqBlXinming,LcZhuangtai,YjbUser,GlNum,DqNodeId,DqNodeName,YjbNodeId,SNodeId,acceptusername,acceptrealname,wbUsername,wbRealname,Content,Starttime,Username,Realname,NowTimes) values ('", this.pulicss.GetFormatStr(this.Number.Text), "','直接发送','直接发送','3','','", glNum, "','','直接发送','0','','", this.pulicss.GetFormatStr(this.acceptusername.Text), "','", this.pulicss.GetFormatStr(this.acceptrealname.Text), "','", this.pulicss.GetFormatStr(this.wbUsername.Text), "','", this.pulicss.GetFormatStr(this.wbRealname.Text), "','", this.pulicss.GetFormatStr(this.Content.Text), "','", this.Starttime.Text, 
                "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
             });
            this.List.ExeSql(sql);
            if (this.acceptusername.Text.Trim() != "")
            {
                string str5;
                SqlDataReader reader;
                string str3 = null;
                string str4 = null;
                str4 = "" + this.acceptusername.Text + "";
                ArrayList list = new ArrayList();
                string[] strArray = str4.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    str3 = str3 + "'" + strArray[i] + "',";
                }
                str3 = str3 + "'0'";
                if (this.acceptusername.Text == "0")
                {
                    str5 = "select MoveTel from qp_oa_Username";
                    reader = this.List.GetList(str5);
                    while (reader.Read())
                    {
                        this.pulicss.InsertSmsSjUser(reader["MoveTel"].ToString(), this.Content.Text, this.Starttime.Text, this.Session["username"].ToString(), this.Session["realname"].ToString());
                    }
                    reader.Close();
                }
                else
                {
                    str5 = "select MoveTel from qp_oa_Username where  username in (" + str3 + ") ";
                    reader = this.List.GetList(str5);
                    while (reader.Read())
                    {
                        this.pulicss.InsertSmsSjUser(reader["MoveTel"].ToString(), this.Content.Text, this.Starttime.Text, this.Session["username"].ToString(), this.Session["realname"].ToString());
                    }
                    reader.Close();
                }
            }
            if (this.wbUsername.Text.Trim() != "")
            {
                string str6 = null;
                str6 = "" + this.wbUsername.Text + "";
                ArrayList list2 = new ArrayList();
                string[] strArray2 = str6.Split(new char[] { ',' });
                for (int j = 0; j < strArray2.Length; j++)
                {
                    this.pulicss.InsertSmsSjUser(strArray2[j], this.Content.Text, this.Starttime.Text, this.Session["username"].ToString(), this.Session["realname"].ToString());
                }
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MySms_Shenqing.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MySms_Shenpi.aspx");
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
                this.Starttime.Text = DateTime.Now.ToString();
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
            }
        }
    }
}


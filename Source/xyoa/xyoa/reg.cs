namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class reg : Page
    {
        protected Button Button3;
        protected Button Button4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox TextBox1;
        protected TextBox TextBox2;

        protected void Button3_Click1(object sender, EventArgs e)
        {
            string sql = "select reg from qp_oa_filemain ";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read() && (reader["reg"].ToString() == "5"))
            {
                base.Response.Write("<script>alert('软件信息出现异常，请重新获取软件激活码！');window.location.href='jihuo.aspx'</Script>");
            }
            else
            {
                reader.Close();
                try
                {
                    string str2 = null;
                    str2 = this.pulicss.DESDecrypt(this.TextBox1.Text, "5", "6");
                    ArrayList list = new ArrayList();
                    string[] strArray = str2.Split(new char[] { '^' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string str3 = "" + strArray[0] + "";
                        string str4 = "" + strArray[1] + "";
                        string str5 = "" + strArray[2] + "";
                        string str6 = "" + strArray[3] + "";
                        string str7 = "Update qp_oa_filemain set cdkstr='" + this.TextBox1.Text + "',reg='2'";
                        this.List.ExeSql(str7);
                    }
                    base.Response.Write("<script language=javascript>alert('恭喜您，注册成功！');window.parent.location = '/default.aspx'</script>");
                }
                catch
                {
                    base.Response.Write("<script>alert('注册失败，请检查序列号是否有效！');</Script>");
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script language=javascript>window.top.location = 'default.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.TextBox2.Text = "" + this.pulicss.GetMAC() + "";
            }
            this.Button3.Attributes["onclick"] = "javascript:return CheckForm();";
        }
    }
}


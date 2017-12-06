namespace xyoa.SystemManage.anquan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class egview : Page
    {
        protected Button Button3;
        protected Label duanxin;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label3;
        protected Label Label4;
        protected Label Label5;
        protected Label Label6;
        protected Label Label8;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox TextBox1;
        protected TextBox TextBox2;
        protected Label xulie;
        protected Label yidong;
        protected Label zcsj;
        protected Label zhushou;

        protected void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("/reg.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.TextBox1.Attributes.Add("readonly", "readonly");
                this.TextBox2.Attributes.Add("readonly", "readonly");
                string sql = "select count(id) from  qp_oa_username where Iflogin='1'";
                int count = this.List.GetCount(sql);
                string str2 = "select count(id) from  qp_oa_username where Iflogin='0'";
                int num2 = this.List.GetCount(str2);
                int num3 = count + num2;
                this.Label3.Text = null;
                this.Label4.Text = null;
                this.Label5.Text = null;
                this.Label6.Text = null;
                this.Label8.Text = null;
                this.Label3.Visible = true;
                this.Label4.Visible = true;
                this.Label5.Visible = true;
                this.Label6.Visible = true;
                this.Label8.Visible = true;
                this.Label6.Text = string.Concat(new object[] { "允许登陆用户数：", count, "，禁止登陆用户数：", num2, "，合计：", num3, "(禁止登陆用户不计算进限制人数)" });
                string str3 = "select * from qp_oa_filemain where reg='0' or reg='1' or reg='2'";
                SqlDataReader list = this.List.GetList(str3);
                if (list.Read())
                {
                    if (list["reg"].ToString() == "1")
                    {
                        this.Label8.Text = "试用版";
                        this.Label3.Text = "" + this.Session["cdk1"].ToString() + "，使用期：" + this.Session["cdk3"].ToString() + "";
                        this.Button3.Text = "软件注册";
                    }
                    else if (list["reg"].ToString() == "2")
                    {
                        this.Label8.Text = "正式版";
                        this.Label3.Text = "" + this.Session["cdk1"].ToString() + "";
                        this.Button3.Text = "重新注册软件信息";
                    }
                    else
                    {
                        this.Label8.Text = "未登记，系统错误，请联系软件供应商";
                    }
                    this.TextBox1.Text = list["cdkstr"].ToString();
                    list.Close();
                    this.TextBox2.Text = "" + this.pulicss.GetMAC() + "";
                    if (("" + this.pulicss.GetMAC() + "") != this.Session["cdk2"].ToString())
                    {
                        base.Response.Write("<script>alert('软件绑定的机器码不正确，请联系开发商！');window.location.href='Default.aspx'</Script>");
                    }
                    else
                    {
                        if (this.Session["cdk3"].ToString() == "1900-01-01")
                        {
                            this.Label4.Text = "无限期";
                        }
                        else
                        {
                            this.Label4.Text = this.Session["cdk3"].ToString();
                        }
                        if (int.Parse(this.Session["cdk4"].ToString()) >= 500)
                        {
                            this.Label5.Text = "无限制";
                        }
                        else
                        {
                            this.Label5.Text = this.Session["cdk4"].ToString();
                        }
                        this.yidong.Text = this.Session["yidong"].ToString().Replace("1", "开启").Replace("2", "关闭");
                        this.duanxin.Text = this.Session["duanxin"].ToString().Replace("1", "开启").Replace("2", "关闭");
                        this.zhushou.Text = this.Session["zhushou"].ToString().Replace("1", "开启").Replace("2", "关闭");
                        this.xulie.Text = this.Session["cdk5"].ToString();
                        this.zcsj.Text = this.Session["zcsj"].ToString();
                    }
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('您的注册码无效！');window.parent.location = '/default.aspx'</script>");
                }
            }
        }
    }
}


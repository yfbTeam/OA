namespace xyoa.HumanResources.ZhaoPin.ZhaopinJhMG
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZhaopinJhMG_show : Page
    {
        protected Label Bumen;
        protected Button Button1;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList JieGuo;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Neirong;
        protected DropDownList normalcontent;
        private publics pulicss = new publics();
        protected Label Qixian;
        protected Label Realname;
        protected Label Renshu;
        protected Label SetTimes;
        protected TextBox SpContent;
        protected Label SpRealname;
        protected Label SpRemark;
        protected TextBox Username;
        protected Label Zhiwei;
        protected Label Zhuangtai;
        protected Label Zhuti;
        protected TextBox ZjRealname;
        protected TextBox ZjUsername;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str;
            if (this.JieGuo.SelectedValue == "1")
            {
                str = string.Concat(new object[] { "Update qp_hr_ZhaopinJh  Set  SpUsername='通过审批',SpRealname='通过审批',Zhuangtai='2',SpRemark=SpRemark+'<b>审批人：</b>", this.Session["Realname"], "<br><b>审批结果：</b>", this.JieGuo.SelectedItem.Text, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>审批时间：</b>", DateTime.Now.ToString(), "<br><b>审批意见：</b>", this.SpContent.Text, "<hr>',YspUsername=YspUsername+'", this.Session["Username"], ",'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage(string.Concat(new object[] { "您的用人申请[", this.Zhuti.Text, "]已通过审批，审批人：", this.Session["realname"], "" }), this.Username.Text, this.Realname.Text, "/HumanResources/ZhaoPin/ZhaopinJh/ZhaopinJh.aspx?Zhuangtai=2");
            }
            if (this.JieGuo.SelectedValue == "2")
            {
                str = string.Concat(new object[] { 
                    "Update qp_hr_ZhaopinJh  Set  SpUsername='", this.pulicss.GetFormatStr(this.ZjUsername.Text), "',SpRealname='", this.pulicss.GetFormatStr(this.ZjRealname.Text), "',SpRemark=SpRemark+'<b>审批人：</b>", this.Session["Realname"], "<br><b>审批结果：</b>", this.JieGuo.SelectedItem.Text, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>审批时间：</b>", DateTime.Now.ToString(), "<br><b>审批意见：</b>", this.SpContent.Text, "<hr>',YspUsername=YspUsername+'", this.Session["Username"], ",'  where id='", int.Parse(base.Request.QueryString["id"]), 
                    "' "
                 });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage(string.Concat(new object[] { "您的用人申请[", this.Zhuti.Text, "]已转交给[", this.ZjRealname.Text, "]审批，审批人：", this.Session["realname"], "" }), this.Username.Text, this.Realname.Text, "/HumanResources/ZhaoPin/ZhaopinJh/ZhaopinJh.aspx?Zhuangtai=1");
                this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的用人申请需要审批，主题：", this.Zhuti.Text, "，转交人：", this.Session["realname"], "" }), this.ZjUsername.Text, this.ZjRealname.Text, "/HumanResources/ZhaoPin/ZhaopinJhMG/ZhaopinJhMG.aspx?Zhuangtai=1");
            }
            if (this.JieGuo.SelectedValue == "3")
            {
                str = string.Concat(new object[] { "Update qp_hr_ZhaopinJh  Set  SpUsername='拒绝审批',SpRealname='拒绝审批',Zhuangtai='3',SpRemark=SpRemark+'<b>审批人：</b>", this.Session["Realname"], "<br><b>审批结果：</b>", this.JieGuo.SelectedItem.Text, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>审批时间：</b>", DateTime.Now.ToString(), "<br><b>审批意见：</b>", this.SpContent.Text, "<hr>',YspUsername=YspUsername+'", this.Session["Username"], ",'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
                this.List.ExeSql(str);
                this.pulicss.InsertMessage(string.Concat(new object[] { "您的用人申请[", this.Zhuti.Text, "]已被拒绝审批，审批人：", this.Session["realname"], "" }), this.Username.Text, this.Realname.Text, "/HumanResources/ZhaoPin/ZhaopinJh/ZhaopinJh.aspx?Zhuangtai=3");
            }
            this.pulicss.InsertLog("审批用人申请", "用人申请管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ZhaopinJhMG.aspx?Zhuangtai=1'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_hr_ZhaopinJh where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and SpUsername='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["Zhuangtai"].ToString() == "4")
                    {
                        string str2 = "Update qp_hr_ZhaopinJh  Set  Zhuangtai='1'  where id='" + int.Parse(base.Request.QueryString["id"]) + "' ";
                        this.List.ExeSql(str2);
                    }
                    this.Bumen.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["Bumen"].ToString());
                    this.Zhiwei.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["Zhiwei"].ToString());
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Renshu.Text = list["Renshu"].ToString();
                    this.Qixian.Text = DateTime.Parse(list["Qixian"].ToString()).ToShortDateString();
                    this.Neirong.Text = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                    this.SpRemark.Text = list["SpRemark"].ToString();
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正在审批").Replace("2", "通过审批").Replace("3", "拒绝审批").Replace("4", "等待审批");
                    this.SetTimes.Text = list["SetTimes"].ToString();
                    this.SpRealname.Text = list["SpRealname"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Username.Text = list["Username"].ToString();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('无相关数据！');window.location.href='ZhaopinJhMG.aspx?Zhuangtai=1'</script>");
                }
                list.Close();
                string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
            }
        }
    }
}


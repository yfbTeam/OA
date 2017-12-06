namespace xyoa.HumanResources.ZhaoPin.ZhaopinJh
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZhaopinJh_add : Page
    {
        protected DropDownList Bumen;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Qixian;
        protected TextBox Renshu;
        protected TextBox SpRealname;
        protected TextBox SpUsername;
        protected DropDownList Zhiwei;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.SpRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_ZhaopinJh  (Jieshu,SpRemark,SpUsername,SpRealname,YspUsername,Zhuti,Bumen,Zhiwei,Renshu,Qixian,Neirong,Zhuangtai,Username,Realname,SetTimes) values ('1','','" + this.SpUsername.Text + "','" + this.SpRealname.Text + "','','" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "','" + this.Bumen.SelectedValue + "','" + this.Zhiwei.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Renshu.Text) + "','" + this.pulicss.GetFormatStr(this.Qixian.Text) + "','" + this.pulicss.GetFormatStrbjq(this.Neirong.Value) + "','4','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertMessage(string.Concat(new object[] { "您有新的用人申请需要审批，主题：", this.Zhuti.Text, "，申请人：", this.Session["realname"], "" }), this.SpUsername.Text, this.SpRealname.Text, "/HumanResources/ZhaoPin/ZhaopinJhMG/ZhaopinJhMG.aspx?Zhuangtai=1");
            this.pulicss.InsertLog("新增用人申请", "用人申请");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ZhaopinJh.aspx?Zhuangtai=4'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListkong("qp_oa_Bumen", this.Bumen, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                string sql = "select * from qp_hr_MoBanZp  where Types='1'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Neirong.Value = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


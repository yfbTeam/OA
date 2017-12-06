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

    public class ZhaopinJh_update : Page
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
            string sql = string.Concat(new object[] { 
                "Update qp_hr_ZhaopinJh   Set SpUsername='", this.pulicss.GetFormatStr(this.SpUsername.Text), "',SpRealname='", this.pulicss.GetFormatStr(this.SpRealname.Text), "',Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',Bumen='", this.Bumen.SelectedValue, "',Zhiwei='", this.Zhiwei.SelectedValue, "',Renshu='", this.pulicss.GetFormatStr(this.Renshu.Text), "',Qixian='", this.pulicss.GetFormatStr(this.Qixian.Text), "',Neirong='", this.pulicss.GetFormatStrbjq(this.Neirong.Value), 
                "'  where id='", int.Parse(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改用人申请", "用人申请");
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
                string sql = string.Concat(new object[] { "select * from qp_hr_ZhaopinJh where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Bumen.SelectedValue = list["Bumen"].ToString();
                    this.Zhiwei.SelectedValue = list["Zhiwei"].ToString();
                    this.Renshu.Text = list["Renshu"].ToString();
                    this.Qixian.Text = DateTime.Parse(list["Qixian"].ToString()).ToShortDateString();
                    this.Neirong.Value = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                    this.SpUsername.Text = list["SpUsername"].ToString();
                    this.SpRealname.Text = list["SpRealname"].ToString();
                    if (list["Zhuangtai"].ToString() != "4")
                    {
                        this.Button1.Enabled = false;
                    }
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


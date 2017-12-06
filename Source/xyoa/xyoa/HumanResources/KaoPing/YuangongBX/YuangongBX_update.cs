namespace xyoa.HumanResources.KaoPing.YuangongBX
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongBX_update : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Riqi;
        protected TextBox SjRealname;
        protected TextBox SjUsername;

        public void BindAttribute()
        {
            this.SjRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_YuangongBX  Set Riqi='", this.pulicss.GetFormatStr(this.Riqi.Text), "',SjUsername='", this.pulicss.GetFormatStr(this.SjUsername.Text), "',Neirong='", this.pulicss.GetFormatStrbjq(this.Neirong.Value), "',SjRealname='", this.pulicss.GetFormatStr(this.SjRealname.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改[" + this.pulicss.GetFormatStr(this.SjRealname.Text) + "]员工表现", "员工表现");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongBX.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_hr_YuangongBX where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Riqi.Text = DateTime.Parse(list["Riqi"].ToString()).ToShortDateString();
                    this.SjUsername.Text = list["SjUsername"].ToString();
                    this.SjRealname.Text = list["SjRealname"].ToString();
                    this.Neirong.Value = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


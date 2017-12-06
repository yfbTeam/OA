namespace xyoa.SystemManage.Seal
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class SealSp_sp : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        protected Image Newname;
        protected TextBox Nowtimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox YxType;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button3.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_YinZhang  Set State='正常',SpRealname='", this.Session["realname"], "'   where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("审批印章[" + this.Name.Text + "]", "印章审批");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SealWSp.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SealSp.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_YinZhang  Set State='拒绝审批',SpRealname='", this.Session["realname"], "'   where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("审批印章[" + this.Name.Text + "]", "印章审批");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SealWSp.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.pulicss.QuanXianBack("iiii3", this.Session["perstr"].ToString());
                if (!this.Page.IsPostBack)
                {
                    string sql = "select * from qp_oa_YinZhang where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Newname.ImageUrl = "/seal/" + list["Newname"].ToString() + "";
                        this.Name.Text = list["Name"].ToString();
                        this.YxType.Text = list["YxType"].ToString();
                        this.Realname.Text = list["Realname"].ToString();
                        this.Nowtimes.Text = list["Nowtimes"].ToString();
                    }
                    list.Close();
                    this.BindAttribute();
                }
            }
        }
    }
}


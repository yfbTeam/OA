namespace xyoa.MyWork.Naozhong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Naozhong_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        private Db List = new Db();
        protected CheckBox NbSms;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected CheckBox SjSms;
        protected TextBox titles;
        protected TextBox txtime;
        protected DropDownList Types;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",1,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.SjSms, ",1,", this.pulicss.GetSms());
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_Naozhong  Set titles='", this.pulicss.GetFormatStr(this.titles.Text), "',Types='", this.Types.SelectedValue, "',txtime='", this.pulicss.GetFormatStr(this.txtime.Text), "',NbSms='", this.pulicss.CheckBoxChange(this.NbSms.Checked.ToString()), "',SjSms='", this.pulicss.CheckBoxChange(this.SjSms.Checked.ToString()), "',Iftx='0'   where id='", int.Parse(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], "' " });
            this.List.ExeSql(sql);
            string str2 = "  Delete from qp_oa_NaozhongRz  where Dyid = '" + int.Parse(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("修改电子闹钟", "电子闹钟");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Naozhong.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Naozhong.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_Naozhong where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.titles.Text = list["titles"].ToString();
                    this.Types.SelectedValue = list["Types"].ToString();
                    this.txtime.Text = list["txtime"].ToString();
                    if (list["NbSms"].ToString() == "1")
                    {
                        this.NbSms.Checked = true;
                    }
                    else
                    {
                        this.NbSms.Checked = false;
                    }
                    if (list["SjSms"].ToString() == "1")
                    {
                        this.SjSms.Checked = true;
                    }
                    else
                    {
                        this.SjSms.Checked = false;
                    }
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


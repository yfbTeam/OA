namespace xyoa.HumanResources.PeiXun.MyPage
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Peixun_show : Page
    {
        protected Label _Label;
        protected Button Button1;
        protected Label Content;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Leibie;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox PUsername;
        protected Label RealnameCj;
        protected Label Starttime;
        protected TextBox Tihui;
        protected TextBox UsernameCj;
        protected Label Zhuti;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_PeixunXinde  Set Tihui='", this.pulicss.GetFormatStr(this.Tihui.Text), "',NowTimes='", DateTime.Now.ToString(), "' where Pxid='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Peixun.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
                string sql = string.Concat(new object[] { "select * from qp_hr_Peixun where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (CHARINDEX(',", this.Session["username"], ",',','+UsernameCj+',') > 0)" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.UsernameCj.Text = list["UsernameCj"].ToString();
                    this.RealnameCj.Text = list["RealnameCj"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Leibie.Text = this.divhr.TypeCode("Mingcheng", "qp_hr_PeixunLb", list["Leibie"].ToString());
                    this.Content.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                }
                list.Close();
                string str2 = string.Concat(new object[] { "select * from qp_hr_PeixunXinde where Pxid='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.Tihui.Text = reader2["Tihui"].ToString();
                }
                reader2.Close();
                string str3 = "select  * from qp_hr_PeixunFile where KeyField='" + this.Number.Text + "' order by id desc";
                SqlDataReader reader3 = this.List.GetList(str3);
                this._Label.Text = null;
                int num = 0;
                this._Label.Text = this._Label.Text + "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                this._Label.Text = this._Label.Text + "<tr>";
                while (reader3.Read())
                {
                    string text = this._Label.Text;
                    this._Label.Text = text + " <td width=100% >\x00b7<a href=/file_down.aspx?number=" + reader3["NewName"].ToString() + "  target=_blank>" + reader3["Name"].ToString() + "</a></td>";
                    num++;
                    if (num == 1)
                    {
                        this._Label.Text = this._Label.Text + "</tr><TR>";
                        num = 0;
                    }
                }
                this._Label.Text = this._Label.Text + " </table>";
                reader3.Close();
            }
        }
    }
}


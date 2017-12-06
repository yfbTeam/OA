namespace xyoa.HumanResources.Fenxi.ZhaoPin
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
        protected CheckBox CheckBox1;
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
        protected TextBox UsernameCj;
        protected Label Xinde;
        protected Label Zhuti;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
                string sql = "select * from qp_hr_Peixun where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string text;
                    this.Number.Text = list["Number"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.UsernameCj.Text = list["UsernameCj"].ToString();
                    this.RealnameCj.Text = list["RealnameCj"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Leibie.Text = this.divhr.TypeCode("Mingcheng", "qp_hr_PeixunLb", list["Leibie"].ToString());
                    this.Content.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                    list.Close();
                    string str2 = "select  * from qp_hr_PeixunFile where KeyField='" + this.Number.Text + "' order by id desc";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    this._Label.Text = null;
                    int num = 0;
                    this._Label.Text = this._Label.Text + "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                    this._Label.Text = this._Label.Text + "<tr>";
                    while (reader2.Read())
                    {
                        text = this._Label.Text;
                        this._Label.Text = text + " <td width=100% >\x00b7<a href=/file_down.aspx?number=" + reader2["NewName"].ToString() + "  target=_blank>" + reader2["Name"].ToString() + "</a></td>";
                        num++;
                        if (num == 1)
                        {
                            this._Label.Text = this._Label.Text + "</tr><TR>";
                            num = 0;
                        }
                    }
                    this._Label.Text = this._Label.Text + " </table>";
                    reader2.Close();
                    string str3 = "select  * from qp_hr_PeixunXinde where Pxid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' order by id asc";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    this.Xinde.Text = null;
                    while (reader3.Read())
                    {
                        if ((reader3["NowTimes"].ToString() == "1900-1-1 0:00:00") || (reader3["NowTimes"].ToString() == "1900-01-01 00:00:00"))
                        {
                            this.Xinde.Text = this.Xinde.Text + "<b>" + reader3["Realname"].ToString() + "</b>：未填写<hr>";
                        }
                        else
                        {
                            text = this.Xinde.Text;
                            this.Xinde.Text = text + "<b>" + reader3["Realname"].ToString() + "</b>：" + this.pulicss.TbToLb(reader3["Tihui"].ToString()) + "<font color=666666>(" + reader3["NowTimes"].ToString() + ")</font><hr>";
                        }
                    }
                    reader3.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location = 'Fenxi1.aspx'</script>");
                }
            }
        }
    }
}


namespace xyoa.Resources.ResReport
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ResFpR_show : Page
    {
        protected Label Cangku;
        protected HtmlForm form1;
        protected Label GmNum;
        protected TextBox GmNums;
        protected Label GmTime;
        protected HtmlHead Head1;
        protected Label JbName;
        protected Label JsRealname;
        protected TextBox JsUsername;
        protected Label KuCun;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label Quyu;
        protected Label Shuoming;
        protected Label States;
        protected Label Xinghao;
        protected TextBox ZyId;
        protected Label ZyIntro;
        protected Label ZyName;
        protected Label ZyNum;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_ResFp  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ZyId.Text = list["ZyId"].ToString();
                    this.JbName.Text = list["JbName"].ToString();
                    this.GmTime.Text = DateTime.Parse(list["GmTime"].ToString()).ToShortDateString();
                    this.GmNum.Text = list["GmNum"].ToString();
                    this.GmNums.Text = list["GmNum"].ToString();
                    this.JsUsername.Text = list["JsUsername"].ToString();
                    this.JsRealname.Text = list["JsRealname"].ToString();
                    this.Shuoming.Text = this.pulicss.TbToLb(list["Shuoming"].ToString());
                    this.States.Text = list["States"].ToString();
                }
                list.Close();
                string str2 = "select * from qp_oa_ResourcesAdd  where id='" + this.ZyId.Text + "'  ";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ZyNum.Text = reader2["ZyNum"].ToString();
                    this.Xinghao.Text = reader2["Xinghao"].ToString();
                    this.ZyId.Text = reader2["id"].ToString();
                    this.ZyName.Text = reader2["ZyName"].ToString();
                    this.ZyIntro.Text = this.pulicss.TbToLb(reader2["ZyIntro"].ToString());
                    this.KuCun.Text = reader2["KuCun"].ToString();
                    this.Cangku.Text = this.pulicss.TypeCode("qp_oa_ResourcesCangku", reader2["Cangku"].ToString());
                    this.Quyu.Text = this.pulicss.TypeCode("qp_oa_ResourcesQuyu", reader2["Quyu"].ToString());
                }
                reader2.Close();
            }
        }
    }
}


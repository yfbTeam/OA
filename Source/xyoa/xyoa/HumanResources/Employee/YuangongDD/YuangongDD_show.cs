﻿namespace xyoa.HumanResources.Employee.YuangongDD
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongDD_show : Page
    {
        protected Label Beizhu;
        protected Label BumenE;
        protected Label BumenQ;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Leixing;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label RealnameYG;
        protected Label Riqi;
        protected TextBox UsernameYG;
        protected Label ZhiweiE;
        protected Label ZhiweiQ;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_hr_YuangongDD  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.UsernameYG.Text = list["UsernameYG"].ToString();
                    this.RealnameYG.Text = list["RealnameYG"].ToString();
                    this.Riqi.Text = list["Riqi"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                    this.BumenQ.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BumenQ"].ToString());
                    this.ZhiweiQ.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["ZhiweiQ"].ToString());
                    this.BumenE.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BumenE"].ToString());
                    this.ZhiweiE.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["ZhiweiE"].ToString());
                    this.Leixing.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Leixing"].ToString());
                }
                list.Close();
                this.pulicss.QuanXianBack("eeee4eb", this.Session["perstr"].ToString());
            }
        }
    }
}


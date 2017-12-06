﻿namespace xyoa.pda.MyWork.txl
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CompanyGroup_show : Page
    {
        protected Label Address;
        protected Label BothDay;
        protected Label BuMenId;
        protected Button Button1;
        protected Label Email;
        protected Label Fax;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label HomeTel;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label MoveTel;
        protected Label MsnNum;
        protected Label Name;
        protected Label NbNum;
        protected Label Officetel;
        private publics pulicss = new publics();
        protected Label QQNum;
        protected Label Remark;
        protected Label Sex;
        protected Label Zhiweiid;
        protected Label ZipCode;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CompanyGroup.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = "select * from qp_oa_CompanyGroup where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.BuMenId.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BuMenId"].ToString());
                    this.Zhiweiid.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["Zhiweiid"].ToString());
                    this.Sex.Text = list["Sex"].ToString();
                    this.Officetel.Text = list["Officetel"].ToString();
                    this.Fax.Text = list["Fax"].ToString();
                    this.MoveTel.Text = list["MoveTel"].ToString();
                    this.HomeTel.Text = list["HomeTel"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.QQNum.Text = list["QQNum"].ToString();
                    this.MsnNum.Text = list["MsnNum"].ToString();
                    this.NbNum.Text = list["NbNum"].ToString();
                    this.Address.Text = list["Address"].ToString();
                    this.ZipCode.Text = list["ZipCode"].ToString();
                    this.Remark.Text = this.pulicss.TbToLb(list["Remark"].ToString());
                    this.BothDay.Text = list["BothDay"].ToString();
                }
                list.Close();
            }
        }
    }
}

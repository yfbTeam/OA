﻿namespace xyoa.pda.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarApply_sp : Page
    {
        protected Button btnFirst;
        protected Button btnLast;
        protected Button btnNext;
        protected Button btnPrev;
        protected Button Button1;
        protected Button Button4;
        protected DropDownList CarId;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Starttime;

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((Button) sender).CommandName) - 1;
                this.DataBindToGridview();
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("/pda/Main.aspx?leixing=1");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.CarId.SelectedValue != "")
            {
                str = str + " and CarId = '" + this.CarId.SelectedValue + "'";
            }
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and ((Starttime between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)) )";
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string sql = string.Concat(new object[] { "select A.*, C.CarName from [qp_oa_CarApply] as [A] join [qp_oa_CarInfo] as [C] on [A].[CarId] = [C].id where CHARINDEX(',", this.Session["username"], ",',','+DqBlUsername+',')   >0 and (LcZhuangtai='1' or LcZhuangtai='2') ", this.CreateMidSql(), " order by A.id desc" });
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,CarName from qp_oa_CarInfo order by id asc";
                this.list.Bind_DropDownList_kong(this.CarId, sQL, "id", "CarName");
                this.Starttime.Attributes.Add("readonly", "readonly");
                this.Endtime.Attributes.Add("readonly", "readonly");
                this.btnFirst.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnPrev.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnNext.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnLast.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button4.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.DataBindToGridview();
            }
        }
    }
}

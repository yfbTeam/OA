namespace xyoa.pda.PublicWork.BumenNewsMg
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenNewsMgList : Page
    {
        protected Button btnFirst;
        protected Button btnLast;
        protected Button btnNext;
        protected Button btnPrev;
        protected Button Button1;
        protected Button Button4;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList IfRead;
        protected ImageButton ImageButton1;
        protected ImageButton ImageButton3;
        protected ImageButton ImageButton4;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Startime;
        protected TextBox titles;

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
            if (this.titles.Text != "")
            {
                str = str + " and titles like '%" + this.pulicss.GetFormatStr(this.titles.Text) + "%'";
            }
            if ((this.Startime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and (Settime between '" + this.Startime.Text + "'and  '" + this.Endtime.Text + "' or convert(char(10),cast(Settime as datetime),120)=convert(char(10),cast('" + this.Startime.Text + "' as datetime),120) or convert(char(10),cast(Settime as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120) ) ";
            }
            if (this.IfRead.SelectedValue != "")
            {
                if (this.IfRead.SelectedValue == "未读")
                {
                    str = string.Concat(new object[] { str, " and CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   =0" });
                }
                if (this.IfRead.SelectedValue == "已读")
                {
                    str = string.Concat(new object[] { str, " and CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')  >0" });
                }
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string sql = string.Concat(new object[] { "select id,titles,Settime,Username,Realname,FqBumen,ScUsername from qp_oa_BumenNewsMg where ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) ", this.CreateMidSql(), " order by id desc" });
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("BumenNewsMgList.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            this.IfRead.SelectedValue = "未读";
            this.DataBindToGridview();
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            this.IfRead.SelectedValue = "已读";
            this.DataBindToGridview();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Startime.Attributes.Add("readonly", "readonly");
                this.Endtime.Attributes.Add("readonly", "readonly");
                this.ImageButton1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ImageButton3.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ImageButton4.Attributes["onclick"] = "javascript:return LoadingShow();";
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


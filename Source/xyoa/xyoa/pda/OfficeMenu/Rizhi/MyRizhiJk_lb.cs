namespace xyoa.pda.OfficeMenu.Rizhi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRizhiJk_lb : Page
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
        protected ImageButton ImageButton1;
        protected ImageButton ImageButton2;
        protected ImageButton ImageButton4;
        protected DropDownList LeiBie;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Pizhu;
        private publics pulicss = new publics();
        protected TextBox Realname;
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
            if (this.Realname.Text != "")
            {
                str = str + " and A.Realname like '%" + this.pulicss.GetFormatStr(this.Realname.Text) + "%'";
            }
            if (this.titles.Text != "")
            {
                str = str + " and A.titles like '%" + this.pulicss.GetFormatStr(this.titles.Text) + "%'";
            }
            if ((this.Startime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and (NowTimes between '" + this.Startime.Text + "'and  '" + this.Endtime.Text + "' or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + this.Startime.Text + "' as datetime),120) or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120) ) ";
            }
            if (this.LeiBie.SelectedValue != "")
            {
                str = str + " and A.LeiBie = '" + this.LeiBie.SelectedValue + "'";
            }
            if (!(this.Pizhu.SelectedValue != ""))
            {
                return str;
            }
            if (this.Pizhu.SelectedValue == "未阅读")
            {
                return string.Concat(new object[] { str, " and CHARINDEX(',", this.Session["username"], ",',','+A.YdUsername+',')   =0" });
            }
            return string.Concat(new object[] { str, " and CHARINDEX(',", this.Session["username"], ",',','+A.YdUsername+',')   >0" });
        }

        public void DataBindToGridview()
        {
            string sql = string.Concat(new object[] { "select A.id,A.titles,A.NowTimes,A.Username,A.Realname,A.LeiBie, B.[name] as LeiBieName from [qp_oa_MyRizhi] as [A] inner join [qp_oa_RizhiLx] as [B] on [A].[LeiBie] = [B].[Id]  where CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_Rizhisz where ZgUsername='", this.Session["username"], "')+',') > 0 ", this.CreateMidSql(), " order by A.id desc" });
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.Pizhu.SelectedValue = "未阅读";
            this.DataBindToGridview();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.Pizhu.SelectedValue = "已阅读";
            this.DataBindToGridview();
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("MyRizhiJk_lb.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ImageButton1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ImageButton2.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ImageButton4.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Startime.Attributes.Add("readonly", "readonly");
                this.Endtime.Attributes.Add("readonly", "readonly");
                string sQL = "select id,name  from qp_oa_RizhiLx order by id asc";
                this.list.Bind_DropDownList_kong(this.LeiBie, sQL, "id", "name");
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


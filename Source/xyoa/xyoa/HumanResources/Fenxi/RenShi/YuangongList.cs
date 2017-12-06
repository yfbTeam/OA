namespace xyoa.HumanResources.Fenxi.RenShi
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongList : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;

        public void BindAttribute()
        {
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "eeee8", this.Session["perstr"].ToString());
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (this.GoPage.Text.Trim().ToString() == "")
                {
                    base.Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
                }
                else if ((this.GoPage.Text.Trim().ToString() == "0") || (Convert.ToInt32(this.GoPage.Text.Trim().ToString()) > this.GridView1.PageCount))
                {
                    base.Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
                }
                else if (this.GoPage.Text.Trim() != "")
                {
                    int num = int.Parse(this.GoPage.Text.Trim()) - 1;
                    if ((num >= 0) && (num < this.GridView1.PageCount))
                    {
                        this.GridView1.PageIndex = num;
                    }
                }
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            catch
            {
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                base.Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["Key"].ToString() == "2")
            {
                str = str + " and Zaizhi='1' and A.Xingbie='" + this.pulicss.GetFormatStr(base.Request.QueryString["fenlei"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>性别比例分析，</font><font color=blue>性别：" + base.Request.QueryString["Fenlei"].ToString().Replace("1", "男").Replace("2", "女") + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "3")
            {
                if (base.Request.QueryString["years_f"].ToString() == "")
                {
                    str = str + " and Zaizhi='1' and A.Chusheng='1900-1-1'";
                    this.ViewState["Title"] = "<font color=red>年龄分析，</font><font color=blue>未填写生日，</font>";
                }
                else
                {
                    str = str + " and Zaizhi='1' and datediff(yy,ChuSheng,getdate())<=" + base.Request.QueryString["years_l"].ToString() + " and datediff(yy,ChuSheng,getdate())>=" + base.Request.QueryString["years_f"].ToString() + "";
                    this.ViewState["Title"] = "<font color=red>年龄分析，</font><font color=blue>年龄段：" + base.Request.QueryString["years_f"].ToString() + "岁—" + base.Request.QueryString["years_l"].ToString() + "岁，</font>";
                }
            }
            if (base.Request.QueryString["Key"].ToString() == "4")
            {
                str = str + " and Zaizhi='1' and A.Mingzhu='" + this.pulicss.GetFormatStr(base.Request.QueryString["Mingzhu"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>民族比例分析，</font><font color=blue>民族：" + this.divhr.TypeCodeFX("Name", "qp_hr_YuangongLx", base.Request.QueryString["Mingzhu"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "5")
            {
                str = str + " and Zaizhi='1' and A.Jiguan='" + this.pulicss.GetFormatStr(base.Request.QueryString["Jiguan"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>籍贯比例分析，</font><font color=blue>籍贯：" + this.divhr.TypeCodeFX("Name", "qp_hr_YuangongLx", base.Request.QueryString["Jiguan"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "6")
            {
                str = str + " and Zaizhi='1' and A.Mianmao='" + this.pulicss.GetFormatStr(base.Request.QueryString["Mianmao"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>政治面貌分析，</font><font color=blue>政治面貌：" + this.divhr.TypeCodeFX("Name", "qp_hr_YuangongLx", base.Request.QueryString["Mianmao"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "7")
            {
                str = str + " and Zaizhi='1' and A.Hunyin='" + this.pulicss.GetFormatStr(base.Request.QueryString["Hunyin"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>婚姻状况分析，</font><font color=blue>婚姻状况：" + base.Request.QueryString["Hunyin"].ToString().Replace("1", "已婚").Replace("2", "未婚") + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "9")
            {
                str = str + " and Zaizhi='1' and A.Xuexi='" + this.pulicss.GetFormatStr(base.Request.QueryString["Xuexi"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>学历分析，</font><font color=blue>学历：" + this.divhr.TypeCodeFX("Name", "qp_hr_YuangongLx", base.Request.QueryString["Xuexi"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "10")
            {
                str = str + " and Zaizhi='1' and A.Zhuanye='" + this.pulicss.GetFormatStr(base.Request.QueryString["Zhuanye"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>专业分析，</font><font color=blue>专业：" + this.divhr.TypeCodeFX("Name", "qp_hr_YuangongLx", base.Request.QueryString["Zhuanye"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "12")
            {
                str = str + " and Zaizhi='1' and A.Leixing='" + this.pulicss.GetFormatStr(base.Request.QueryString["Leixing"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>员工类型分析，</font><font color=blue>员工类型：" + this.divhr.TypeCodeFX("Name", "qp_hr_YuangongLx", base.Request.QueryString["Leixing"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "13")
            {
                str = str + " and Zaizhi='1' and A.Zhiwei='" + this.pulicss.GetFormatStr(base.Request.QueryString["Zhiwei"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>职位分析，</font><font color=blue>职位：" + this.divhr.TypeCodeFX("Name", "qp_oa_Zhiwei", base.Request.QueryString["Zhiwei"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "14")
            {
                str = str + " and Zaizhi='1' and A.Zhicheng='" + this.pulicss.GetFormatStr(base.Request.QueryString["Zhicheng"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>职称分析，</font><font color=blue>职称分析：" + this.divhr.TypeCodeFX("Name", "qp_hr_YuangongLx", base.Request.QueryString["Zhicheng"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "15")
            {
                if (base.Request.QueryString["years_f"].ToString() == "")
                {
                    str = str + " and Zaizhi='1' and A.CjShijian='1900-1-1'";
                    this.ViewState["Title"] = "<font color=red>总工龄分析，</font><font color=blue>未填写参加工作时间，</font>";
                }
                else
                {
                    str = str + " and Zaizhi='1' and datediff(yy,CjShijian,getdate())<=" + base.Request.QueryString["years_l"].ToString() + " and datediff(yy,CjShijian,getdate())>=" + base.Request.QueryString["years_f"].ToString() + "";
                    this.ViewState["Title"] = "<font color=red>总工龄分析，</font><font color=blue>工龄段：" + base.Request.QueryString["years_f"].ToString() + "年—" + base.Request.QueryString["years_l"].ToString() + "年，</font>";
                }
            }
            if (base.Request.QueryString["Key"].ToString() == "16")
            {
                if (base.Request.QueryString["years_f"].ToString() == "")
                {
                    str = str + " and Zaizhi='1' and A.JrShijian='1900-1-1'";
                    this.ViewState["Title"] = "<font color=red>本单位工龄分析，</font><font color=blue>未填写进入单位时间，</font>";
                }
                else
                {
                    str = str + " and Zaizhi='1' and datediff(yy,JrShijian,getdate())<=" + base.Request.QueryString["years_l"].ToString() + " and datediff(yy,JrShijian,getdate())>=" + base.Request.QueryString["years_f"].ToString() + "";
                    this.ViewState["Title"] = "<font color=red>本单位工龄分析，</font><font color=blue>工龄段：" + base.Request.QueryString["years_f"].ToString() + "年—" + base.Request.QueryString["years_l"].ToString() + "年，</font>";
                }
            }
            if (base.Request.QueryString["Key"].ToString() == "11")
            {
                str = str + " and Zaizhi='1' and A.Bumen='" + this.pulicss.GetFormatStr(base.Request.QueryString["Bumen"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>部门编制分析(在职)，</font><font color=blue>部门：" + this.divhr.TypeCodeFX("Name", "qp_oa_Bumen", base.Request.QueryString["Bumen"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Key"].ToString() == "21")
            {
                str = str + " and Zaizhi='2' and A.Bumen='" + this.pulicss.GetFormatStr(base.Request.QueryString["Bumen"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>部门编制分析(离职)，</font><font color=blue>部门：" + this.divhr.TypeCodeFX("Name", "qp_oa_Bumen", base.Request.QueryString["Bumen"].ToString()) + "，</font>";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.id,A.Xingming,A.Xingbie,A.Zhiwei,A.Chusheng,A.Xuexi,A.Zaizhi,D.[Name] as ZhiweiName ,B.[Name] as BumenName from [qp_hr_Yuangong] as [A]  inner join [qp_oa_Bumen] as [B] on [A].[Bumen] = [B].[Id]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id]  where 1=1";
            string str2 = "select count(A.id) from [qp_hr_Yuangong] as [A]  inner join [qp_oa_Bumen] as [B] on [A].[Bumen] = [B].[Id]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id]  where 1=1";
            string str3 = str + SqlCreate;
            string str4 = str2 + SqlCreate;
            string sql = "" + str3 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str6 = str4;
            this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
            this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
            this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pulicss.addfenye(this.DropDownList1.SelectedValue);
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sqlsort = "";
            if ((this.ViewState["SortDirection"] == null) || (this.ViewState["SortDirection"].ToString().CompareTo("") == 0))
            {
                this.ViewState["SortDirection"] = " desc";
            }
            else
            {
                this.ViewState["SortDirection"] = "";
            }
            sqlsort = " order by " + e.SortExpression + this.ViewState["SortDirection"];
            this.DataBindToGridview(sqlsort, this.CreateMidSql());
            this.SortText.Value = sqlsort;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
            }
        }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((LinkButton) sender).CommandName) - 1;
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }
    }
}


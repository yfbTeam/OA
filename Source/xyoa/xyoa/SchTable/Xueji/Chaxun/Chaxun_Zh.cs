namespace xyoa.SchTable.Xueji.Chaxun
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Chaxun_Zh : Page
    {
        protected Label AllPageLabel;
        protected DropDownList BanJi;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected HtmlButton Button1;
        protected HtmlButton Button2;
        protected HtmlButton Button3;
        protected Button Button4;
        protected Button Button6;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList Danqinjiating;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected DropDownList DropDownList1;
        protected DropDownList Dushengzinv;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList HukouLeixing;
        protected DropDownList HukouXingzhi;
        protected DropDownList Jiangkan;
        protected DropDownList Jiaoshizinv;
        protected DropDownList Junrenzinv;
        protected Label Label1;
        protected TextBox Laiyuanxiao;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList LiushouErtong;
        protected DropDownList Mingzhu;
        protected DropDownList Nianji;
        protected DropDownList Nongminggao;
        protected Panel Panel1;
        protected Panel Panel2;
        protected DropDownList Pingkunsheng;
        private publics pulicss = new publics();
        protected DropDownList Sancan;
        protected DropDownList Shengyuan;
        protected HtmlInputHidden SortText;
        protected DropDownList Xingbie;
        protected TextBox Xingming;
        protected DropDownList Xueduan;
        protected DropDownList XuejiZhuangtai;
        protected DropDownList Xueqi;
        protected DropDownList Zhengzhimianmhao;
        protected DropDownList Zhiwu;

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

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        public string CreateBanJi()
        {
            string str = string.Empty;
            if (this.Xueqi.SelectedValue != "")
            {
                str = str + " and A.Xueqi = '" + this.Xueqi.SelectedValue + "'";
            }
            if (this.Nianji.SelectedValue != "")
            {
                str = str + " and A.Nianji = '" + this.Nianji.SelectedItem.Text + "'";
            }
            return str;
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Xingming.Text != "")
            {
                str = str + " and C.Xingming like '%" + this.pulicss.GetFormatStr(this.Xingming.Text) + "%'";
            }
            if (this.Nianji.SelectedValue != "")
            {
                str = str + " and B.Nianji = '" + this.Nianji.SelectedItem.Text + "'";
            }
            if (this.BanJi.SelectedValue != "")
            {
                str = str + " and A.BanJi = '" + this.BanJi.SelectedValue + "'";
            }
            if (this.Xingbie.SelectedValue != "")
            {
                str = str + " and C.Xingbie = '" + this.Xingbie.SelectedValue + "'";
            }
            if (this.Zhengzhimianmhao.SelectedValue != "")
            {
                str = str + " and C.Zhengzhimianmhao = '" + this.Zhengzhimianmhao.SelectedValue + "'";
            }
            if (this.Laiyuanxiao.Text != "")
            {
                str = str + " and C.Laiyuanxiao like '%" + this.pulicss.GetFormatStr(this.Laiyuanxiao.Text) + "%'";
            }
            if (this.XuejiZhuangtai.SelectedValue != "")
            {
                str = str + " and A.XuejiZhuangtai = '" + this.XuejiZhuangtai.SelectedValue + "'";
            }
            if (this.Zhiwu.SelectedValue != "")
            {
                str = str + " and A.Zhiwu = '" + this.Zhiwu.SelectedValue + "'";
            }
            if (this.Jiangkan.SelectedValue != "")
            {
                str = str + " and C.Jiangkan = '" + this.Jiangkan.SelectedValue + "'";
            }
            if (this.Shengyuan.SelectedValue != "")
            {
                str = str + " and C.Shengyuan = '" + this.Shengyuan.SelectedValue + "'";
            }
            if (this.HukouLeixing.SelectedValue != "")
            {
                str = str + " and C.HukouLeixing = '" + this.HukouLeixing.SelectedValue + "'";
            }
            if (this.HukouXingzhi.SelectedValue != "")
            {
                str = str + " and C.HukouXingzhi = '" + this.HukouXingzhi.SelectedValue + "'";
            }
            if (this.Sancan.SelectedValue != "")
            {
                str = str + " and (CHARINDEX('," + this.Sancan.SelectedValue + ",',','+C.Sancan+',') > 0)";
            }
            if (this.LiushouErtong.SelectedValue != "")
            {
                str = str + " and C.LiushouErtong = '" + this.LiushouErtong.SelectedValue + "'";
            }
            if (this.Nongminggao.SelectedValue != "")
            {
                str = str + " and C.Nongminggao = '" + this.Nongminggao.SelectedValue + "'";
            }
            if (this.Junrenzinv.SelectedValue != "")
            {
                str = str + " and C.Junrenzinv = '" + this.Junrenzinv.SelectedValue + "'";
            }
            if (this.Jiaoshizinv.SelectedValue != "")
            {
                str = str + " and C.Jiaoshizinv = '" + this.Jiaoshizinv.SelectedValue + "'";
            }
            if (this.Danqinjiating.SelectedValue != "")
            {
                str = str + " and C.Danqinjiating = '" + this.Danqinjiating.SelectedValue + "'";
            }
            if (this.Dushengzinv.SelectedValue != "")
            {
                str = str + " and C.Dushengzinv = '" + this.Dushengzinv.SelectedValue + "'";
            }
            if (this.Pingkunsheng.SelectedValue != "")
            {
                str = str + " and C.Pingkunsheng = '" + this.Pingkunsheng.SelectedValue + "'";
            }
            return str;
        }

        public string CreateNianJi()
        {
            string str = string.Empty;
            if (this.Xueqi.SelectedValue != "")
            {
                str = str + " and A.Xueqi = '" + this.Xueqi.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select '" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,B.Nianji,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1";
            string str2 = "select count(A.id) from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1";
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Mingzhu");
                Label label2 = (Label) e.Row.FindControl("LMingzhu");
                Label label3 = (Label) e.Row.FindControl("XuejiZhuangtai");
                Label label4 = (Label) e.Row.FindControl("LXuejiZhuangtai");
                Label label5 = (Label) e.Row.FindControl("HukouLeixing");
                Label label6 = (Label) e.Row.FindControl("LHukouLeixing");
                label2.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label.Text);
                label4.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label3.Text);
                label6.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label5.Text);
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

        protected void Nianji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') ", this.CreateBanJi(), " order by Num asc" });
            this.list.Bind_DropDownList_kong(this.BanJi, sQL, "id", "Mingcheng");
            if (this.Nianji.SelectedValue == "小学")
            {
                string str2 = "select id,name  from qp_sch_DataFile where type='6' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Shengyuan, str2, "id", "name");
            }
            if (this.Nianji.SelectedValue == "初中")
            {
                string str3 = "select id,name  from qp_sch_DataFile where type='7' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Shengyuan, str3, "id", "name");
            }
            if (this.Nianji.SelectedValue == "高中")
            {
                string str4 = "select id,name  from qp_sch_DataFile where type='8' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Shengyuan, str4, "id", "name");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pulicss.QuanXianVis(this.Button1, "pppp2d", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.Button2, "pppp2d", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.Button3, "pppp2d", this.Session["perstr"].ToString());
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (base.Request.QueryString["p"] != null)
                {
                    this.ViewState["tableheigh"] = "80%";
                }
                else
                {
                    this.ViewState["tableheigh"] = "600px";
                }
                if (!this.Page.IsPostBack)
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                    string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                    this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                    this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                    this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                    string str2 = "select A.id,A.NianjiMc,C.Xueduan  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  1=1 " + this.CreateNianJi() + " order by Num asc";
                    this.list.Bind_DropDownList_nothing(this.Nianji, str2, "Xueduan", "NianjiMc");
                    string str3 = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') ", this.CreateBanJi(), " order by Num asc" });
                    this.list.Bind_DropDownList_kong(this.BanJi, str3, "id", "Mingcheng");
                    string str4 = "select id,name  from qp_sch_DataFile where type='17' and ifdel=0 order by id asc";
                    this.list.Bind_DropDownList_kong(this.Mingzhu, str4, "id", "name");
                    string str5 = "select id,name  from qp_sch_DataFile where type='18' and ifdel=0 order by id asc";
                    this.list.Bind_DropDownList_kong(this.Zhengzhimianmhao, str5, "id", "name");
                    string str6 = "select id,name  from qp_sch_DataFile where type='20' and ifdel=0 order by id asc";
                    this.list.Bind_DropDownList_kong(this.XuejiZhuangtai, str6, "id", "name");
                    string str7 = "select id,name  from qp_sch_DataFile where type='1' and ifdel=0 order by id asc";
                    this.list.Bind_DropDownList_kong(this.Zhiwu, str7, "id", "name");
                    string str8 = "select id,name  from qp_sch_DataFile where type='14' and ifdel=0 order by id asc";
                    this.list.Bind_DropDownList_kong(this.Jiangkan, str8, "id", "name");
                    string str9 = "select id,name  from qp_sch_DataFile where type='15' and ifdel=0 order by id asc";
                    this.list.Bind_DropDownList_kong(this.HukouLeixing, str9, "id", "name");
                    string str10 = "select id,name  from qp_sch_DataFile where type='16' and ifdel=0 order by id asc";
                    this.list.Bind_DropDownList_kong(this.HukouXingzhi, str10, "id", "name");
                    if (this.Nianji.SelectedValue == "小学")
                    {
                        string str11 = "select id,name  from qp_sch_DataFile where type='6' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Shengyuan, str11, "id", "name");
                    }
                    if (this.Nianji.SelectedValue == "初中")
                    {
                        string str12 = "select id,name  from qp_sch_DataFile where type='7' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Shengyuan, str12, "id", "name");
                    }
                    if (this.Nianji.SelectedValue == "高中")
                    {
                        string str13 = "select id,name  from qp_sch_DataFile where type='8' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_kong(this.Shengyuan, str13, "id", "name");
                    }
                }
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

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select A.id,A.NianjiMc  from [qp_sch_Nianji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[NianjiMc] = [C].[Name] where  1=1 " + this.CreateNianJi() + " order by Num asc";
            this.list.Bind_DropDownList_nothing(this.Nianji, sQL, "NianjiMc", "NianjiMc");
            string str2 = string.Concat(new object[] { "select A.id,Mingcheng from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') ", this.CreateBanJi(), " order by Num asc" });
            this.list.Bind_DropDownList_kong(this.BanJi, str2, "id", "Mingcheng");
        }
    }
}


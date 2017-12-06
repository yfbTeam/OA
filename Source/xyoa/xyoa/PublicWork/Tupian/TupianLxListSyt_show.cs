namespace xyoa.PublicWork.Tupian
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TupianLxListSyt_show : Page
    {
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label listall;
        protected Label Namefile;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected TextBox Titles;

        public void BindAttribute()
        {
            this.Titles.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("TupianLxListSyt_show.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Titles.Text != "")
            {
                str = str + " and A.OldName like '%" + this.pulicss.GetFormatStr(this.Titles.Text) + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str = null;
            if (base.Request.QueryString["id"].ToString() == "0")
            {
                str = string.Concat(new object[] { "select A.* from [qp_oa_TupianMg] as [A] join [qp_oa_TupianLx] as [C] on [A].[TypeId] = [C].id  and   ((CHARINDEX(',", this.Session["BuMenId"], ",',','+[C].ZdBumenId+',') > 0 and [C].States='2') or (CHARINDEX(',", this.Session["username"], ",',','+[C].ZdUsername+',') > 0 and [C].States='3') or ([C].States='1'))" });
            }
            else
            {
                str = string.Concat(new object[] { "select A.* from [qp_oa_TupianMg] as [A] join [qp_oa_TupianLx] as [C] on [A].[TypeId] = [C].id  and   ((CHARINDEX(',", this.Session["BuMenId"], ",',','+[C].ZdBumenId+',') > 0 and [C].States='2') or (CHARINDEX(',", this.Session["username"], ",',','+[C].ZdUsername+',') > 0 and [C].States='3') or ([C].States='1')) and A.TypeId='", base.Request.QueryString["id"], "'" });
            }
            string sql = str + SqlCreate;
            if (this.List.GetList(sql).Read())
            {
                string str3 = "" + sql + " " + Sqlsort + "";
                SqlDataReader list = this.List.GetList(str3);
                this.listall.Text = null;
                this.listall.Text = "<table width=\"540\" height=\"134\"  border=\"0\" align=\"center\" cellpadding=\"4\" cellspacing=\"0\">";
                this.listall.Text = this.listall.Text + "<tr>";
                int num = 0;
                while (list.Read())
                {
                    string text;
                    if (list["OldName"].ToString().Length > 13)
                    {
                        text = this.listall.Text;
                        this.listall.Text = text + " <td width=\"180\" height=\"119\" align=\"center\">  <table width=\"164\" height=\"119\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\" bgcolor=\"#999999\"> <tr>  <td align=\"center\" bgcolor=\"#FFFFFF\"><a href=\"/Tupiansdown.aspx?number=" + list["NewName"].ToString() + "\"  target=_blank><img src=\"/" + list["NewName"].ToString() + "\" width=\"164\" height=\"112\" border=\"0\" title=\"拍摄日期：" + list["PsShijian"].ToString() + "  拍摄地点：" + list["PsDidian"].ToString() + "\"></a></td></tr> </table><font color=\"#333333\"><strong><a href=\"/Tupiansdown.aspx?number=" + list["NewName"].ToString() + "\"  target=_blank>" + list["OldName"].ToString().Substring(0, 13) + "...</a></strong></font><a href='javascript:void(0)' onclick='window.open (\"/tpaddfolder.aspx?newname=" + list["NewName"].ToString() + "\", \"_blank\", \"height=400, width=500,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=220,left=370\")'  class=zccss>[转存]</a>  <br> <br> </td>";
                    }
                    else
                    {
                        text = this.listall.Text;
                        this.listall.Text = text + " <td width=\"180\" height=\"119\" align=\"center\">  <table width=\"164\" height=\"119\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\" bgcolor=\"#999999\"> <tr>  <td align=\"center\" bgcolor=\"#FFFFFF\"><a href=\"/Tupiansdown.aspx?number=" + list["NewName"].ToString() + "\"  target=_blank><img src=\"/" + list["NewName"].ToString() + "\" width=\"164\" height=\"112\" border=\"0\" title=\"拍摄日期：" + list["PsShijian"].ToString() + "  拍摄地点：" + list["PsDidian"].ToString() + "\"></a></td></tr> </table><font color=\"#333333\"><strong><a href=\"/Tupiansdown.aspx?number=" + list["NewName"].ToString() + "\"  target=_blank>" + list["OldName"].ToString() + "</a></strong></font> <a href='javascript:void(0)' onclick='window.open (\"/tpaddfolder.aspx?newname=" + list["NewName"].ToString() + "\", \"_blank\", \"height=400, width=500,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=220,left=370\")'  class=zccss>[转存]</a> <br> <br> </td>";
                    }
                    num++;
                    if (num == 3)
                    {
                        this.listall.Text = this.listall.Text + " <tr></tr>";
                        num = 0;
                    }
                }
                this.listall.Text = this.listall.Text + " </table>";
                list.Close();
            }
            else
            {
                this.listall.Text = "<div  align=\"center\"><b>无相关数据</b></div>";
            }
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
                this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
                string sql = "select * from qp_oa_TupianLx  where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Namefile.Text = list["name"].ToString();
                }
                else
                {
                    this.Namefile.Text = "请选择左边菜单目录筛选";
                }
                list.Close();
            }
        }

        protected void SearchData_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
        }
    }
}


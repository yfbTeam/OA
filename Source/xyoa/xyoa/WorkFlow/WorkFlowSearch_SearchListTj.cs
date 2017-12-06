namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowSearch_SearchListTj : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button5;
        protected HtmlForm form1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        public void Bindquanxian()
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=ExcelFile.xls");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/excel";
            base.Response.Write(this.Label1.Text);
            base.Response.End();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=WordFile.doc");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/word";
            base.Response.Write(this.Label1.Text);
            base.Response.End();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=PPTFile.ppt");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/ppt";
            base.Response.Write(this.Label1.Text);
            base.Response.End();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=HtmlFile.html");
            base.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            base.Response.ContentType = "application/html";
            base.Response.Write(this.Label1.Text);
            base.Response.End();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowSearch.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["FlowId"] != "0")
            {
                str = str + " and A.FlowId = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["FlowId"])) + "'";
            }
            if (base.Request.QueryString["State"] != "0")
            {
                str = str + " and A.State = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["State"])) + "'";
            }
            if (base.Request.QueryString["Fangwei"] != "0")
            {
                if (base.Request.QueryString["Fangwei"] == "1")
                {
                    str = str + " and A.FqUsername= '" + this.Session["username"].ToString() + "'";
                }
                if (base.Request.QueryString["Fangwei"] == "3")
                {
                    str = string.Concat(new object[] { str, " and ((CHARINDEX(',", this.Session["username"], ",',','+JkUsername+',') > 0) or JkUsername='0')" });
                }
            }
            else
            {
                str = string.Concat(new object[] { str, " and (A.FqUsername= '", this.Session["username"].ToString(), "' or ((CHARINDEX(',", this.Session["username"], ",',','+JkUsername+',') > 0) or JkUsername='0'))" });
            }
            if (base.Request.QueryString["FqUsername"] != "")
            {
                str = str + " and FqUsername = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["FqUsername"])) + "'";
            }
            if (base.Request.QueryString["Name"] != "")
            {
                str = str + " and Name like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Name"])) + "%'";
            }
            if ((base.Request.QueryString["Starttime"] != "") && (base.Request.QueryString["Endtime"] != ""))
            {
                str = str + " and (NowTimes between '" + base.Request.QueryString["Starttime"] + "'and  '" + base.Request.QueryString["Endtime"] + "' or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Starttime"] + "' as datetime),120) or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Endtime"] + "' as datetime),120) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            object obj2;
            this.Label1.Text = null;
            string str = null;
            string str2 = null;
            string str3 = null;
            str = str + "<table cellspacing='0' width='100%' style='border-collapse: collapse' border=\"1\" cellpadding=\"3\" bordercolor='#000000'> <tr bgcolor=\"#EEF6FB\"> <td nowrap class='TableControl' align='center'> <b>名称/文号</b></td><td nowrap align='center'> <b>流程状态</b></td><td nowrap align='center'> <b>流程发起人</b></td><td nowrap align='center'> <b>开始时间</b></td>";
            string sql = "select * from qp_oa_FormFile where KeyFile=(select Number from qp_oa_DIYForm where id='" + base.Request.QueryString["id"] + "') and (type='[常规型]' or type='[数字型]')  order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                if ((list["name"].ToString() != null) && (list["name"].ToString() != ""))
                {
                    obj2 = str;
                    str = string.Concat(new object[] { obj2, "<td nowrap align='center'><b>", list["name"], "</b>&nbsp;</td>" });
                }
                else
                {
                    str = str + "<td nowrap align='center'>&nbsp;</td>";
                }
            }
            str = str + "</tr>";
            list.Close();
            string str6 = string.Concat(new object[] { "select distinct A.id,A.Name,A.State,A.NowTimes,A.Number,A.FqRealname from [qp_oa_AddWorkFlow] as [A] ", this.ViewState["strurl"], "", this.ViewState["strurl1"], " where Ifdel='0'" }) + SqlCreate;
            SqlDataReader reader2 = this.List.GetList(str6);
            while (reader2.Read())
            {
                obj2 = str3;
                str3 = string.Concat(new object[] { obj2, "<tr><td nowrap align='center'>", reader2["Name"], "</td><td nowrap align='center'>", reader2["State"], "</td><td nowrap align='center'>", reader2["FqRealname"], "</td><td nowrap align='center'>", reader2["NowTimes"], "</td>" });
                string str7 = "select * from qp_oa_FormFile where KeyFile=(select Number from qp_oa_DIYForm where id='" + base.Request.QueryString["id"] + "') and (type='[常规型]' or type='[数字型]')  order by id asc";
                SqlDataReader reader3 = this.List.GetList(str7);
                while (reader3.Read())
                {
                    string str8 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowFileKey where AddNumber='", reader2["Number"], "' and Number='", reader3["Number"], "' order by keyid asc" });
                    SqlDataReader reader4 = this.List.GetList(str8);
                    if (reader4.Read())
                    {
                        if ((reader4["Content"].ToString() != null) && (reader4["Content"].ToString() != ""))
                        {
                            obj2 = str3;
                            str3 = string.Concat(new object[] { obj2, "<td nowrap align='center'>", reader4["Content"], "&nbsp;</td>" });
                        }
                        else
                        {
                            str3 = str3 + "<td nowrap align='center'>&nbsp;</td>";
                        }
                    }
                    else
                    {
                        str3 = str3 + "<td nowrap align='center'>&nbsp;</td>";
                    }
                    reader4.Close();
                }
                reader3.Close();
                str3 = str3 + "</tr>";
            }
            reader2.Close();
            str2 = str2 + "<tr>" + "<td align='center' colspan=\"4\"> <b>合计</b></td>";
            string str9 = null;
            SqlDataReader reader5 = this.List.GetList(str6);
            while (reader5.Read())
            {
                obj2 = str9;
                str9 = string.Concat(new object[] { obj2, "'", reader5["Number"], "'," });
            }
            reader5.Close();
            str9 = str9 + "'0'";
            string str10 = "select * from qp_oa_FormFile where KeyFile=(select Number from qp_oa_DIYForm where id='" + base.Request.QueryString["id"] + "') and (type='[常规型]' or type='[数字型]')  order by id asc";
            SqlDataReader reader6 = this.List.GetList(str10);
            while (reader6.Read())
            {
                try
                {
                    string str11 = string.Concat(new object[] { "select sum(cast(Content as numeric(10,0))) as cout  from qp_oa_AddWorkFlowFileKey where number='", reader6["Number"], "' and AddNumber in (", str9, ")" });
                    SqlDataReader reader7 = this.List.GetList(str11);
                    if (reader7.Read())
                    {
                        obj2 = str2;
                        str2 = string.Concat(new object[] { obj2, "<td nowrap align='center'><b>", reader7["cout"], "</b>&nbsp;</td>" });
                    }
                    reader7.Close();
                }
                catch
                {
                    str2 = str2 + "<td nowrap align='center'><b>--</b>&nbsp;</td>";
                }
            }
            reader6.Close();
            str2 = str2 + "</tr>" + "</table>";
            this.Label1.Text = str + str3 + str2;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if (base.Request.QueryString["Fujian"] != "")
                {
                    this.ViewState["strurl"] = " inner join [qp_oa_fileupload] as [C] on [A].[Number] = [C].KeyField and [C].Name like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Fujian"])) + "%'";
                }
                else
                {
                    this.ViewState["strurl"] = "";
                }
                this.ViewState["strurl1"] = "";
                if ((this.Session["searchurl"] != null) && (this.Session["searchurl"].ToString() != ""))
                {
                    this.ViewState["strurl1"] = "inner join [qp_oa_AddWorkFlowFileKey] as [B] on" + this.Session["searchurl"].ToString() + "";
                }
                this.Bindquanxian();
                this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
            }
        }
    }
}


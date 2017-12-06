namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BaobiaoList : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button5;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

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

        protected void Button5_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Baobiao.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["FlowId"] != "0")
            {
                str = str + " and B.FlowId = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["FlowId"])) + "'";
            }
            if (base.Request.QueryString["State"] != "0")
            {
                str = str + " and B.State = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["State"])) + "'";
            }
            if (base.Request.QueryString["FqUsername"] != "")
            {
                str = str + " and B.FqUsername = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["FqUsername"])) + "'";
            }
            if (base.Request.QueryString["Name"] != "")
            {
                str = str + " and B.Name like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Name"])) + "%'";
            }
            if ((base.Request.QueryString["Starttime"] != "") && (base.Request.QueryString["Endtime"] != ""))
            {
                str = str + " and (B.NowTimes between '" + base.Request.QueryString["Starttime"] + "'and  '" + base.Request.QueryString["Endtime"] + "' or convert(char(10),cast(B.NowTimes as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Starttime"] + "' as datetime),120) or convert(char(10),cast(B.NowTimes as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Endtime"] + "' as datetime),120) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.Label1.Text = null;
            string sql = "select A.Neirong,A.Ziduan,A.BiaodanId from qp_oa_Baobiao  as [A]  where A.id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["Ziduan"] = list["Ziduan"].ToString();
                this.ViewState["BiaodanId"] = list["BiaodanId"].ToString();
                this.ViewState["Neirong"] = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                this.ViewState["BiaodanId"] = list["BiaodanId"].ToString();
            }
            list.Close();
            this.ViewState["AAA"] = null;
            this.ViewState["BBB"] = null;
            string str2 = "select id,Gongsi from qp_oa_BaobiaoGs where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' order by id asc ";
            SqlDataReader reader2 = this.List.GetList(str2);
            while (reader2.Read())
            {
                this.ViewState["AAA"] = reader2["Gongsi"].ToString();
                this.ViewState["Gongsi"] = null;
                string str3 = "select id,Name,Number from qp_oa_FormFile where  KeyFile in (" + this.pulicss.GetFileNameNumber(this.ViewState["BiaodanId"].ToString()) + ") and (type='[数字型]')  order by id asc ";
                SqlDataReader reader3 = this.List.GetList(str3);
                while (reader3.Read())
                {
                    this.ViewState["CCC"] = reader3["Name"].ToString();
                    try
                    {
                        SqlDataReader reader4 = this.List.GetList(("select sum(cast(A.content   as   decimal)) as AllShuliang from  qp_oa_AddWorkFlowFileKey as [A] inner join [qp_oa_AddWorkFlow] as [B] on [A].[AddNumber] = [B].[Number]   where A.number='" + reader3["Number"] + "'") + SqlCreate);
                        if (reader4.Read())
                        {
                            if (reader4["AllShuliang"].ToString() == "")
                            {
                                this.ViewState["Gongsi"] = "0";
                            }
                            else
                            {
                                this.ViewState["Gongsi"] = reader4["AllShuliang"].ToString();
                            }
                        }
                        else
                        {
                            this.ViewState["Gongsi"] = "0";
                        }
                        reader4.Close();
                    }
                    catch
                    {
                        this.ViewState["Gongsi"] = "--";
                    }
                    this.ViewState["AAA"] = this.ViewState["AAA"].ToString().Replace("[" + this.ViewState["CCC"] + "]", "" + this.ViewState["Gongsi"] + "");
                }
                reader3.Close();
                try
                {
                    decimal num = Convert.ToDecimal(this.Eval(this.ViewState["AAA"].ToString()));
                    this.ViewState["var1a1"] = "" + num + "";
                }
                catch
                {
                    this.ViewState["var1a1"] = "--";
                }
                this.ViewState["Neirong"] = this.ViewState["Neirong"].ToString().Replace("#" + reader2["Gongsi"].ToString() + "#", "" + this.ViewState["var1a1"] + "");
            }
            reader2.Close();
            this.Label1.Text = this.ViewState["Neirong"].ToString();
        }

        public object Eval(string expression)
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn("col1 ", typeof(string), expression);
            table.Columns.Add(column);
            table.Rows.Add(new object[] { " " });
            return table.Rows[0][0];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
            }
        }
    }
}


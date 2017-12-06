namespace xyoa.SchTable.Sushe.Fenpei
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Fenpei_Ss_Wfp : Page
    {
        protected TextBox acceptrealname;
        protected TextBox acceptusername;
        protected Label Bianhao;
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Louceng;
        protected Label Mianji;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected Label Zaiyong;
        protected Label Zuowei;

        public void BindAttribute()
        {
            this.acceptrealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select id,Sushe from qp_sch_Xuesheng where  id in (0," + this.acceptusername.Text + "0)";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str2 = "Update qp_sch_Sushe    Set Yiyong=Yiyong-1 where  id='" + list["Sushe"].ToString() + "'";
                this.List.ExeSql(str2);
                string str3 = "Update qp_sch_Sushe    Set Yiyong=Yiyong+1 where  id='" + base.Request.QueryString["id"] + "'";
                this.List.ExeSql(str3);
                string str4 = "Update qp_sch_Xuesheng    Set Sushe='" + base.Request.QueryString["id"] + "' where  id='" + list["id"].ToString() + "'";
                this.List.ExeSql(str4);
            }
            list.Close();
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Fenpei_Xx_Wfp.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
        }

        public void DataBindToGridview()
        {
            string sql = "select A.*,C.Xingming from qp_sch_SuSheXiDj as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where A.id='" + base.Request.QueryString["id"] + "' order by A.id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianVis(this.Button1, "pppp5c", this.Session["perstr"].ToString());
                if (base.Request.QueryString["id"] != null)
                {
                    if (base.Request.QueryString["id"].ToString() == "0")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                        this.Panel2.Visible = true;
                        string sql = "select * from qp_sch_Sushe   where id='" + base.Request.QueryString["id"] + "'";
                        SqlDataReader list = this.List.GetList(sql);
                        if (list.Read())
                        {
                            this.Bianhao.Text = list["Bianhao"].ToString();
                            this.Louceng.Text = list["Louceng"].ToString();
                            this.Mianji.Text = list["Mianji"].ToString();
                            this.Zuowei.Text = list["Zuowei"].ToString();
                            this.Zaiyong.Text = list["Zaiyong"].ToString();
                        }
                        list.Close();
                        string str2 = "select '" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,C.id,C.Sushe,C.Xingming,B.[Mingcheng] as BanJiName from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where C.Sushe='" + base.Request.QueryString["id"] + "'";
                        SqlDataReader reader2 = this.List.GetList(str2);
                        while (reader2.Read())
                        {
                            string text = this.acceptrealname.Text;
                            this.acceptrealname.Text = text + "" + reader2["Xingming"].ToString() + "(" + reader2["BanJiName"].ToString() + "),";
                            this.acceptusername.Text = this.acceptusername.Text + "" + reader2["id"].ToString() + ",";
                        }
                        reader2.Close();
                        this.DataBindToGridview();
                    }
                }
                else
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                }
                this.BindAttribute();
            }
        }
    }
}


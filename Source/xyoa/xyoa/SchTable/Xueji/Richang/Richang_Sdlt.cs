namespace xyoa.SchTable.Xueji.Richang
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Richang_Sdlt : Page
    {
        protected DropDownList BanJi;
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox NianjiName;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected DropDownList XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 id  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]  where XsId='" + this.XsId.SelectedValue + "' order by id desc ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = "Update [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]     Set BanJi='" + this.BanJi.SelectedValue + "' where   XsId='" + this.XsId.SelectedValue + "'";
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = "insert into [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   (Xueqi,BanJi,XsId,Zhiwu,XuejiZhuangtai) values ('" + this.Xueqi.SelectedValue + "','" + this.BanJi.SelectedValue + "','" + this.XsId.SelectedValue + "','','" + this.divsch.TypeCodeDrLx("Name", "qp_sch_DataFile", "在校", "20") + "')";
                this.List.ExeSql(str3);
            }
            list.Close();
            this.divsch.InsertLog(this.XsId.SelectedValue, this.divsch.GetXueqi(), this.divsch.GetXueduan(), this.Leixing.SelectedValue, "“" + this.XsId.SelectedItem.Text + "”进行“" + this.Leixing.SelectedValue + "”操作，生效学期：“" + this.Xueqi.SelectedValue + "”，生效学期段：“" + this.Xueduan.SelectedValue + "”，变化后班级：“" + this.BanJi.SelectedItem.Text + "”", "1");
            this.pulicss.InsertLog("" + this.Leixing.SelectedValue + "[" + this.XsId.SelectedItem.Text + "]", "学生日常管理");
            this.DataBindToGridview();
            base.Response.Write("<script language=javascript>alert('提交成功！');</script>");
        }

        public void DataBindToGridview()
        {
            string sql = "select * from qp_sch_Rizhi   where XsId='" + this.XsId.SelectedValue + "' order by id desc";
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
                string str;
                string str2;
                string str3;
                string str4;
                SqlDataReader list;
                this.pulicss.QuanXianVis(this.Button1, "pppp2f", this.Session["perstr"].ToString());
                if (base.Request.QueryString["XsId"] != null)
                {
                    this.Panel1.Visible = false;
                    this.Panel2.Visible = true;
                    str = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                    this.list.Bind_DropDownList_nothing(this.Xueqi, str, "Mingcheng", "Mingcheng");
                    this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                    this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                    str2 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
                    this.list.Bind_DropDownList_nothing(this.BanJi, str2, "id", "Mingcheng");
                    str3 = "select C.id,C.Xingming  from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.XsId='" + base.Request.QueryString["XsId"] + "' order by A.id asc";
                    this.list.Bind_DropDownList_nothing(this.XsId, str3, "id", "Xingming");
                    str4 = "select BanJi from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   where XsId='" + this.XsId.SelectedValue + "'";
                    list = this.List.GetList(str4);
                    if (list.Read())
                    {
                        this.BanJi.SelectedValue = list["BanJi"].ToString().Replace(".", "");
                    }
                    list.Close();
                    this.DataBindToGridview();
                }
                else if (base.Request.QueryString["id"] != null)
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
                        str = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                        this.list.Bind_DropDownList_nothing(this.Xueqi, str, "Mingcheng", "Mingcheng");
                        this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                        this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                        str2 = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
                        this.list.Bind_DropDownList_nothing(this.BanJi, str2, "id", "Mingcheng");
                        str3 = "select C.id,C.Xingming  from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + base.Request.QueryString["id"] + "' order by A.id asc";
                        this.list.Bind_DropDownList_nothing(this.XsId, str3, "id", "Xingming");
                        str4 = "select BanJi from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   where XsId='" + this.XsId.SelectedValue + "'";
                        list = this.List.GetList(str4);
                        if (list.Read())
                        {
                            this.BanJi.SelectedValue = list["BanJi"].ToString().Replace(".", "");
                        }
                        list.Close();
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

        protected void XsId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select BanJi from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   where XsId='" + this.XsId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.BanJi.SelectedValue = list["BanJi"].ToString().Replace(".", "");
            }
            list.Close();
            this.DataBindToGridview();
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
            this.list.Bind_DropDownList_nothing(this.BanJi, sQL, "id", "Mingcheng");
            string sql = "select BanJi from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   where XsId='" + this.XsId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.BanJi.SelectedValue = list["BanJi"].ToString().Replace(".", "");
            }
            list.Close();
        }
    }
}


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

    public class Richang_PlSdlt : Page
    {
        protected Button Button1;
        protected TextBox Count;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Panel Panel1;
        protected Panel Panel2;
        protected DropDownList PlBanji;
        private publics pulicss = new publics();
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "pppp2f", this.Session["perstr"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("XsId");
                DropDownList list = (DropDownList) row.FindControl("Banji");
                Label label2 = (Label) row.FindControl("Xingming");
                if (box.Checked)
                {
                    string sql = "select top 1 id  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]  where XsId='" + label.Text + "' order by id desc ";
                    SqlDataReader reader = this.List.GetList(sql);
                    if (reader.Read())
                    {
                        string str2 = "Update [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]     Set BanJi='" + list.SelectedValue + "' where   XsId='" + label.Text + "'";
                        this.List.ExeSql(str2);
                    }
                    else
                    {
                        string str3 = "insert into [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]   (Xueqi,BanJi,XsId,Zhiwu,XuejiZhuangtai) values ('" + this.Xueqi.SelectedValue + "','" + list.SelectedValue + "','" + label.Text + "','','" + this.divsch.TypeCodeDrLx("Name", "qp_sch_DataFile", "在校", "20") + "')";
                        this.List.ExeSql(str3);
                    }
                    reader.Close();
                    this.divsch.InsertLog(label.Text, this.divsch.GetXueqi(), this.divsch.GetXueduan(), this.Leixing.SelectedValue, "“" + label2.Text + "”进行“" + this.Leixing.SelectedValue + "”操作，生效学期：“" + this.Xueqi.SelectedValue + "”，生效学期段：“" + this.Xueduan.SelectedValue + "”，变化后班级：“" + list.SelectedItem.Text + "”", "1");
                }
            }
            this.pulicss.InsertLog("" + this.Leixing.SelectedValue + "批量执行", "学生日常管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Richang_PlSdlt.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
        }

        public void DataBindToGridview()
        {
            string sQL = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
            this.list.Bind_DropDownList_kong(this.PlBanji, sQL, "id", "Mingcheng");
            string sql = "select '" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and A.BanJi='" + base.Request.QueryString["id"].ToString() + "'";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            int num = this.GridView1.Rows.Count + 2;
            this.Count.Text = "" + num + "";
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
                Label label = (Label) e.Row.FindControl("XuejiZhuangtai");
                Label label2 = (Label) e.Row.FindControl("LXuejiZhuangtai");
                label2.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label.Text);
                DropDownList myDropDownList = (DropDownList) e.Row.FindControl("Banji");
                string sQL = string.Concat(new object[] { "select A.id,A.Nianji,Mingcheng,BzUsername,RkUsername,XldUsername  from [qp_sch_Banji] as [A] inner join [qp_sch_SetSclClass] as [C] on [A].[Nianji] = [C].[Name] where  A.Xueqi='", this.Xueqi.SelectedValue, "' and ((CHARINDEX(',", this.Session["username"], ",',','+A.RkUsername+',') > 0) or (CHARINDEX(',", this.Session["username"], ",',','+A.XldUsername+',') > 0) or BzUsername='", this.Session["username"], "') order by Num asc" });
                this.list.Bind_DropDownList_nothing(myDropDownList, sQL, "id", "Mingcheng");
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
                this.Button1.Attributes["onclick"] = "javascript:return sendfile();";
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
                        string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                        this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                        this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                        this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                        this.DataBindToGridview();
                    }
                }
                else
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                }
                this.Bindquanxian();
            }
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }
    }
}


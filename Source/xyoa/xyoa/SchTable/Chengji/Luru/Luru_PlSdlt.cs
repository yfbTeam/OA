namespace xyoa.SchTable.Chengji.Luru
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Luru_PlSdlt : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList Kemu;
        protected Label Label1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected TextBox Riqi;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.Button1, "pppp3aa", this.Session["perstr"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                Label label = (Label) row.FindControl("XsId");
                TextBox box = (TextBox) row.FindControl("Chengji");
                DropDownList list = (DropDownList) row.FindControl("Miankao");
                DropDownList list2 = (DropDownList) row.FindControl("Quekao");
                DropDownList list3 = (DropDownList) row.FindControl("Bukao");
                TextBox box2 = (TextBox) row.FindControl("BukaoCj");
                DropDownList list4 = (DropDownList) row.FindControl("Taidu");
                string sql = "select id from qp_sch_Chengji  where Kemu='" + this.Kemu.SelectedValue + "' and Leixing='" + this.Leixing.SelectedValue + "'  and XsId='" + label.Text + "'  and Xueqi='" + this.Xueqi.SelectedValue + "'  and Xueduan='" + this.Xueduan.SelectedValue + "'  ";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    string str2 = string.Concat(new object[] { 
                        "Update qp_sch_Chengji  Set  Riqi='", this.pulicss.GetFormatStr(this.Riqi.Text), "',Leixing='", this.Leixing.SelectedValue, "',Kemu='", this.Kemu.SelectedValue, "',Chengji='", this.pulicss.GetFormatStr(box.Text), "',Miankao='", list.SelectedValue, "',Quekao='", list2.SelectedValue, "',Bukao='", list3.SelectedValue, "',BukaoCj='", this.pulicss.GetFormatStr(box2.Text), 
                        "',Taidu='", list4.SelectedValue, "'  where id='", reader["id"], "'  "
                     });
                    this.List.ExeSql(str2);
                }
                else
                {
                    string str3 = string.Concat(new object[] { 
                        "insert into qp_sch_Chengji  (XsId,Xueqi,Xueduan,Riqi,Leixing,Kemu,Chengji,Miankao,Quekao,Bukao,BukaoCj,Taidu,UserName,RealName) values ('", this.pulicss.GetFormatStr(label.Text), "','", this.Xueqi.SelectedValue, "','", this.Xueduan.SelectedValue, "','", this.pulicss.GetFormatStr(this.Riqi.Text), "','", this.Leixing.SelectedValue, "','", this.Kemu.SelectedValue, "','", this.pulicss.GetFormatStr(box.Text), "','", list.SelectedValue, 
                        "','", list2.SelectedValue, "','", list3.SelectedValue, "','", this.pulicss.GetFormatStr(box2.Text), "','", list4.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "')"
                     });
                    this.List.ExeSql(str3);
                }
                reader.Close();
            }
            this.pulicss.InsertLog("" + this.Leixing.SelectedValue + "批量执行", "成绩录入");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Luru_PlSdlt.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
        }

        public void DataBindToGridview()
        {
            string sql = "select '" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and A.BanJi='" + base.Request.QueryString["id"].ToString() + "'";
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("XuejiZhuangtai");
                Label label2 = (Label) e.Row.FindControl("LXuejiZhuangtai");
                label2.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label.Text);
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
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
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
                        string sql = "select * from qp_sch_Nianji where  NianjiMc='" + this.divsch.TypeCode("Nianji", "qp_sch_Banji", this.pulicss.GetFormatStr(base.Request.QueryString["Id"])) + "' and Xueqi='" + this.Xueqi.SelectedValue + "'";
                        SqlDataReader list = this.List.GetList(sql);
                        if (list.Read())
                        {
                            string str3;
                            if (this.Xueduan.SelectedValue == "上学期")
                            {
                                str3 = "select id,Name  from qp_sch_Kecheng where id in (" + list["Kecheng"].ToString() + ") order by id asc";
                                this.list.Bind_DropDownList_kong(this.Kemu, str3, "id", "Name");
                            }
                            else
                            {
                                str3 = "select id,Name  from qp_sch_Kecheng where id in (" + list["KechengX"].ToString() + ") order by id asc";
                                this.list.Bind_DropDownList_kong(this.Kemu, str3, "id", "Name");
                            }
                            string str4 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ") order by id asc";
                            this.list.Bind_DropDownList_kong(this.Leixing, str4, "id", "name");
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
                this.Bindquanxian();
            }
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }
    }
}


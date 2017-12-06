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

    public class Luru_Sdlt : Page
    {
        protected DropDownList Bukao;
        protected TextBox BukaoCj;
        protected Button Button1;
        protected TextBox Chengji;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList Kemu;
        protected Label Label1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Miankao;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected DropDownList Quekao;
        protected TextBox Riqi;
        protected DropDownList Taidu;
        protected DropDownList XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_sch_Chengji  (XsId,Xueqi,Xueduan,Riqi,Leixing,Kemu,Chengji,Miankao,Quekao,Bukao,BukaoCj,Taidu,UserName,RealName) values ('", this.XsId.SelectedValue, "','", this.Xueqi.SelectedValue, "','", this.Xueduan.SelectedValue, "','", this.pulicss.GetFormatStr(this.Riqi.Text), "','", this.Leixing.SelectedValue, "','", this.Kemu.SelectedValue, "','", this.pulicss.GetFormatStr(this.Chengji.Text), "','", this.Miankao.SelectedValue, 
                "','", this.Quekao.SelectedValue, "','", this.Bukao.SelectedValue, "','", this.pulicss.GetFormatStr(this.BukaoCj.Text), "','", this.Taidu.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("成绩录入[" + this.XsId.SelectedItem.Text + "]", "成绩录入");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Luru_Sdlt.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
        }

        public void DataBindToGridview()
        {
            string sql = "select * from qp_sch_Chengji   where XsId='" + this.XsId.SelectedValue + "' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XiuGai")
            {
                this.DataBindToGridview();
            }
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "delete from qp_sch_Chengji where id='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview();
            }
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
                Label label = (Label) e.Row.FindControl("Leixing");
                Label label2 = (Label) e.Row.FindControl("LLeixing");
                Label label3 = (Label) e.Row.FindControl("Kemu");
                Label label4 = (Label) e.Row.FindControl("LKemu");
                label2.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label.Text);
                label4.Text = this.divsch.TypeCode("Name", "qp_sch_Kecheng", label3.Text);
                LinkButton ctl = (LinkButton) e.Row.FindControl("ShanChu");
                ctl.Attributes.Add("onclick", "javascript:return confirm('确认删除吗')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("XiuGai");
                button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('Luru_PlSdlt_update.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "&Njid=" + base.Request.QueryString["id"] + "','window','dialogWidth:680px;DialogHeight=380px;status:no;help=no;scroll=no');window.location='#'");
                this.pulicss.QuanXianVis(ctl, "pppp3ad", this.Session["perstr"].ToString());
                this.pulicss.QuanXianVis(button2, "pppp3ac", this.Session["perstr"].ToString());
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
                this.pulicss.QuanXianVis(this.Button1, "pppp3aa", this.Session["perstr"].ToString());
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
                        string str2 = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + base.Request.QueryString["id"] + "' order by A.id asc";
                        this.list.Bind_DropDownList_nothing(this.XsId, str2, "id", "Xingming");
                        string sql = "select * from qp_sch_Nianji where  NianjiMc='" + this.divsch.TypeCode("Nianji", "qp_sch_Banji", this.pulicss.GetFormatStr(base.Request.QueryString["Id"])) + "' and Xueqi='" + this.Xueqi.SelectedValue + "'";
                        SqlDataReader list = this.List.GetList(sql);
                        if (list.Read())
                        {
                            string str4;
                            if (this.Xueduan.SelectedValue == "上学期")
                            {
                                str4 = "select id,Name  from qp_sch_Kecheng where id in (" + list["Kecheng"].ToString() + ") order by id asc";
                                this.list.Bind_DropDownList_kong(this.Kemu, str4, "id", "Name");
                            }
                            else
                            {
                                str4 = "select id,Name  from qp_sch_Kecheng where id in (" + list["KechengX"].ToString() + ") order by id asc";
                                this.list.Bind_DropDownList_kong(this.Kemu, str4, "id", "Name");
                            }
                            string str5 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ") order by id asc";
                            this.list.Bind_DropDownList_kong(this.Leixing, str5, "id", "name");
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
            this.DataBindToGridview();
        }
    }
}


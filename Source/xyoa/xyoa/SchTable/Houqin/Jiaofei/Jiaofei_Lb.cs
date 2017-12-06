namespace xyoa.SchTable.Houqin.Jiaofei
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Jiaofei_Lb : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected TextBox Jine;
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
            string sql = string.Concat(new object[] { 
                "insert into qp_sch_Jiaofei   (XsId,Leixing,Jine,Xueqi,Xueduan,Username,Realname,Nowtimes) values ('", this.XsId.SelectedValue, "','", this.Leixing.SelectedValue, "','", this.pulicss.GetFormatStr(this.Jine.Text), "','", this.Xueqi.SelectedValue, "','", this.Xueduan.SelectedValue, "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("[" + this.XsId.SelectedItem.Text + "]缴费管理", "缴费管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Jiaofei_Lb.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
        }

        public void DataBindToGridview()
        {
            string sql = "select A.*,C.Name as LeixingName from qp_sch_Jiaofei as [A] inner join [qp_sch_DataFile] as [C] on [A].[Leixing] = [C].[Id]   where A.XsId='" + this.XsId.SelectedValue + "' order by A.id desc";
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
                string sql = "delete from qp_sch_Jiaofei where id='" + num + "'";
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
                LinkButton ctl = (LinkButton) e.Row.FindControl("ShanChu");
                ctl.Attributes.Add("onclick", "javascript:return confirm('确认删除吗')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("XiuGai");
                button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('Jiaofei_Lb_update.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "','window','dialogWidth:680px;DialogHeight=380px;status:no;help=no;scroll=no');window.location='#'");
                this.pulicss.QuanXianVis(ctl, "pppp6ad", this.Session["perstr"].ToString());
                this.pulicss.QuanXianVis(button2, "pppp6ac", this.Session["perstr"].ToString());
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
                this.pulicss.QuanXianVis(this.Button1, "pppp6aa", this.Session["perstr"].ToString());
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
                        string str3 = "select id,name  from qp_sch_DataFile where type='22' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_nothing(this.Leixing, str3, "id", "name");
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


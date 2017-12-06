namespace xyoa.SchTable.Xueji.Biangeng
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Biangeng_PlBg : Page
    {
        protected Button Button1;
        protected TextBox Count;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Panel Panel1;
        protected Panel Panel2;
        protected DropDownList PlXuejiZhuangtai;
        private publics pulicss = new publics();
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "pppp2c", this.Session["perstr"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("XsId");
                Label label2 = (Label) row.FindControl("LXuejiZhuangtai");
                DropDownList list = (DropDownList) row.FindControl("XuejiZhuangtai");
                Label label3 = (Label) row.FindControl("Xingming");
                if (box.Checked)
                {
                    string sql = "Update [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]     Set XuejiZhuangtai='" + list.SelectedValue + "' where   XsId='" + label.Text + "'";
                    this.List.ExeSql(sql);
                    string str2 = string.Concat(new object[] { 
                        "insert into qp_sch_Biangeng_Rz   (XsId,Xueqi,Xueduan,QZhuangtai,HZhuangtai,Username,Realname,Nowtimes) values ('", label.Text, "','", this.Xueqi.SelectedValue, "','", this.Xueduan.SelectedValue, "','", this.pulicss.GetFormatStr(label2.Text), "','", list.SelectedItem.Text, "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), 
                        "')"
                     });
                    this.List.ExeSql(str2);
                }
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Biangeng_PlBg.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
        }

        public void DataBindToGridview()
        {
            string sQL = "select id,name  from qp_sch_DataFile where type='20' and ifdel=0 order by id asc";
            this.list.Bind_DropDownList_kong(this.PlXuejiZhuangtai, sQL, "id", "name");
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
                Label label = (Label) e.Row.FindControl("IdXuejiZhuangtai");
                Label label2 = (Label) e.Row.FindControl("LXuejiZhuangtai");
                label2.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label.Text);
                DropDownList myDropDownList = (DropDownList) e.Row.FindControl("XuejiZhuangtai");
                string sQL = "select id,name  from qp_sch_DataFile where type='20' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_nothing(myDropDownList, sQL, "id", "name");
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


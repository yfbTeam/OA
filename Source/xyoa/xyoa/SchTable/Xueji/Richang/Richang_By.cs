namespace xyoa.SchTable.Xueji.Richang
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Richang_By : Page
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
        private publics pulicss = new publics();

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
                Label label2 = (Label) row.FindControl("Xingming");
                TextBox box2 = (TextBox) row.FindControl("Quxiang");
                TextBox box3 = (TextBox) row.FindControl("Beizhu");
                if (box.Checked)
                {
                    string sql = "Update [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "]     Set XuejiZhuangtai='" + this.divsch.TypeCodeDrLx("Name", "qp_sch_DataFile", "毕业", "20") + "' where   XsId='" + label.Text + "'";
                    this.List.ExeSql(sql);
                    string str2 = "Update qp_sch_Xuesheng     Set ByQuxiang='" + this.pulicss.GetFormatStr(box2.Text) + "',ByBeizhu='" + this.pulicss.GetFormatStr(box3.Text) + "',XuejiZhuangtai='" + this.divsch.TypeCodeDrLx("Name", "qp_sch_DataFile", "毕业", "20") + "' where   id='" + label.Text + "'";
                    this.List.ExeSql(str2);
                    this.divsch.InsertLog(label.Text, this.divsch.GetXueqi(), this.divsch.GetXueduan(), "毕业", "“" + label2.Text + "”进行“毕业”操作，生效学期：“" + this.divsch.GetXueqi() + "”，生效学期段：“" + this.divsch.GetXueduan() + "”，毕业去向：“" + box2.Text + "”，备注：“" + box3.Text + "”", "1");
                }
            }
            this.pulicss.InsertLog("学生毕业", "学生日常管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Richang_By.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
        }

        public void DataBindToGridview()
        {
            string sql = "select '" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1 and A.BanJi='" + base.Request.QueryString["id"].ToString() + "'";
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


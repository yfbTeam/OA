namespace xyoa.SchTable.Xueji.Biangeng
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Biangeng_Bg : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList HZhuangtai;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox NianjiName;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected Label QZhuangtai;
        protected DropDownList XsId;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "]     Set XuejiZhuangtai='" + this.HZhuangtai.SelectedValue + "' where   XsId='" + this.XsId.SelectedValue + "'";
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { 
                "insert into qp_sch_Biangeng_Rz   (XsId,Xueqi,Xueduan,QZhuangtai,HZhuangtai,Username,Realname,Nowtimes) values ('", this.XsId.SelectedValue, "','", this.Xueqi.SelectedValue, "','", this.Xueduan.SelectedValue, "','", this.pulicss.GetFormatStr(this.QZhuangtai.Text), "','", this.HZhuangtai.SelectedItem.Text, "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("[" + this.XsId.SelectedItem.Text + "]" + this.HZhuangtai.SelectedItem.Text + "", "学籍变更");
            this.DataBindToGridview();
            base.Response.Write("<script language=javascript>alert('提交成功！');</script>");
        }

        public void DataBindToGridview()
        {
            string sql = "select * from qp_sch_Biangeng_Rz   where XsId='" + this.XsId.SelectedValue + "' order by id desc";
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
                this.pulicss.QuanXianVis(this.Button1, "pppp2c", this.Session["perstr"].ToString());
                if (base.Request.QueryString["XsId"] != null)
                {
                    this.Panel1.Visible = false;
                    this.Panel2.Visible = true;
                    str = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                    this.list.Bind_DropDownList_nothing(this.Xueqi, str, "Mingcheng", "Mingcheng");
                    this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                    this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                    str2 = "select C.id,C.Xingming  from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.XsId='" + base.Request.QueryString["XsId"] + "' order by A.id asc";
                    this.list.Bind_DropDownList_nothing(this.XsId, str2, "id", "Xingming");
                    str3 = "select id,name  from qp_sch_DataFile where type='20' and ifdel=0 order by id asc";
                    this.list.Bind_DropDownList_nothing(this.HZhuangtai, str3, "id", "name");
                    str4 = "select XuejiZhuangtai from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "]   where XsId='" + this.XsId.SelectedValue + "'";
                    list = this.List.GetList(str4);
                    if (list.Read())
                    {
                        this.QZhuangtai.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["XuejiZhuangtai"].ToString());
                        this.HZhuangtai.SelectedValue = list["XuejiZhuangtai"].ToString();
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
                        str2 = "select C.id,C.Xingming  from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + base.Request.QueryString["id"] + "' order by A.id asc";
                        this.list.Bind_DropDownList_nothing(this.XsId, str2, "id", "Xingming");
                        str3 = "select id,name  from qp_sch_DataFile where type='20' and ifdel=0 order by id asc";
                        this.list.Bind_DropDownList_nothing(this.HZhuangtai, str3, "id", "name");
                        str4 = "select XuejiZhuangtai from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "]   where XsId='" + this.XsId.SelectedValue + "'";
                        list = this.List.GetList(str4);
                        if (list.Read())
                        {
                            this.QZhuangtai.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["XuejiZhuangtai"].ToString());
                            this.HZhuangtai.SelectedValue = list["XuejiZhuangtai"].ToString();
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
            string sql = "select XuejiZhuangtai from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "]   where XsId='" + this.XsId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.QZhuangtai.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["XuejiZhuangtai"].ToString());
                this.HZhuangtai.SelectedValue = list["XuejiZhuangtai"].ToString();
            }
            list.Close();
            this.DataBindToGridview();
        }
    }
}


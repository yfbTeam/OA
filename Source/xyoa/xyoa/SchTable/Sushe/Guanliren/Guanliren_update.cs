namespace xyoa.SchTable.Sushe.Guanliren
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Guanliren_update : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList JianzhuId;
        protected TextBox Leixing;
        protected TextBox Lianxi;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Louceng;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Shijian;
        protected TextBox Xingming;
        protected TextBox Zhiwu;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_SuSheGuanli     Set Xingming='", this.pulicss.GetFormatStr(this.Xingming.Text), "',Leixing='", this.pulicss.GetFormatStr(this.Leixing.Text), "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',JianzhuId='", this.JianzhuId.SelectedValue, "',Louceng='", this.pulicss.GetFormatStr(this.Louceng.Text), "',Zhiwu='", this.pulicss.GetFormatStr(this.Zhiwu.Text), "',Lianxi='", this.pulicss.GetFormatStr(this.Lianxi.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), 
                "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改宿舍管理人员[" + this.Xingming.Text + "]", "宿舍管理人员");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Guanliren.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Guanliren.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng  from qp_sch_Gongyu  order by id asc";
                this.list.Bind_DropDownList_nothing(this.JianzhuId, sQL, "id", "Mingcheng");
                string sql = "select * from qp_sch_SuSheGuanli where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Leixing.Text = list["Leixing"].ToString();
                    this.JianzhuId.SelectedValue = list["JianzhuId"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Louceng.Text = list["Louceng"].ToString();
                    this.Zhiwu.Text = list["Zhiwu"].ToString();
                    this.Lianxi.Text = list["Lianxi"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


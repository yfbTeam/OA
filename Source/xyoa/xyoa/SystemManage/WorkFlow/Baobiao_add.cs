namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Baobiao_add : Page
    {
        protected TextBox BiaodanId;
        protected TextBox BiaodanName;
        protected Button Button1;
        protected Button Button2;
        protected Button Button4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Mingcheng;
        protected TextBox Paixun;
        private publics pulicss = new publics();
        protected DropDownList States;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.BiaodanName.Attributes.Add("readonly", "readonly");
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Baobiao (Mingcheng,BiaodanId,Leixing,Paixun,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,Neirong,Ziduan) values ('" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "','" + this.BiaodanId.Text + "','1','" + this.pulicss.GetFormatStr(this.Paixun.Text) + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','','')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("创建报表", "报表设计");
            string str2 = "select top 1 id  from qp_oa_Baobiao where Mingcheng='" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "' order by id desc";
            SqlDataReader list = this.List.GetList(str2);
            if (list.Read())
            {
                base.Response.Redirect("BaobiaoSj_update.aspx?id=" + list["id"].ToString() + "");
            }
            list.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Baobiao (Mingcheng,BiaodanId,Leixing,Paixun,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,Neirong,Ziduan) values ('" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "','" + this.BiaodanId.Text + "','1','" + this.pulicss.GetFormatStr(this.Paixun.Text) + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','','')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("创建报表", "报表设计");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Baobiao.aspx';</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Baobiao.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
            }
        }
    }
}


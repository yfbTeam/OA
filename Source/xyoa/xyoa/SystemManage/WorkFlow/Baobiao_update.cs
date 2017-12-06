namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Baobiao_update : Page
    {
        protected TextBox BiaodanId;
        protected TextBox BiaodanName;
        protected Button Button2;
        protected Button Button4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
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
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_oa_Baobiao  Set  Mingcheng='", this.pulicss.GetFormatStr(this.Mingcheng.Text), "',BiaodanId='", this.BiaodanId.Text, "',Leixing='", this.Leixing.SelectedValue, "',Paixun='", this.Paixun.Text, "',States='", this.States.SelectedValue, "',ZdBumenId='", this.ZdBumenId.Text, "',ZdBumen='", this.ZdBumen.Text, "',ZdUsername='", this.ZdUsername.Text, 
                "',ZdRealname='", this.ZdRealname.Text, "' where id='", int.Parse(base.Request.QueryString["id"]), "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改报表属性", "报表设计");
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
                string sql = "select * from qp_oa_Baobiao  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Mingcheng.Text = list["Mingcheng"].ToString();
                    this.BiaodanName.Text = this.pulicss.GetFileNameName(list["BiaodanId"].ToString());
                    this.BiaodanId.Text = list["BiaodanId"].ToString();
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                    this.States.SelectedValue = list["States"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.Paixun.Text = list["Paixun"].ToString();
                }
                list.Close();
            }
        }
    }
}


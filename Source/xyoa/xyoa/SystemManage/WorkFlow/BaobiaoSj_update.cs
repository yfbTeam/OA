namespace xyoa.SystemManage.WorkFlow
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BaobiaoSj_update : Page
    {
        protected Label Biaodan;
        protected Button Button1;
        protected Button Button4;
        protected FCKeditor Content;
        protected HtmlForm form1;
        protected DropDownList FormFile;
        protected HtmlHead Head1;
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected LinkButton LinkButton4;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Mingcheng;
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.LinkButton2.Attributes["onclick"] = "javascript:return updatefile();";
            this.LinkButton4.Attributes["onclick"] = "javascript:return delfile();";
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
        }

        public void BindList()
        {
            string sQL = "select id,Gongsi from qp_oa_BaobiaoGs where KeyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' order by id asc";
            this.list.Bind_DropDownListFormCh(this.FormFile, sQL, "id", "Gongsi");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_Baobiao  Set Neirong='", this.pulicss.GetFormatStrbjq(this.Content.Value), "' where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设计报表", "报表设计");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Baobiao.aspx';</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Baobiao.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.BindList();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string sql = " Delete from qp_oa_BaobiaoGs where id='" + this.FormFile.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.BindList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                this.BindList();
                if (!this.Page.IsPostBack)
                {
                    string sql = "select id,Mingcheng,BiaodanId,Neirong from qp_oa_Baobiao  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.Content.Value = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                        this.Mingcheng.Text = list["Mingcheng"].ToString();
                        this.Biaodan.Text = this.pulicss.GetFileNameName(list["BiaodanId"].ToString());
                    }
                    list.Close();
                    this.BindAttribute();
                }
            }
        }
    }
}


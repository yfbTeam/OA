namespace xyoa.SchTable.Houqin.Jiaofei
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Jiaofei_Lb_update : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Jine;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label XsId;
        protected Label Xueduan;
        protected Label Xueqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_sch_Jiaofei  Set  Jine='", this.pulicss.GetFormatStr(this.Jine.Text), "',Leixing='", this.Leixing.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_sch_DataFile where type='22' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_nothing(this.Leixing, sQL, "id", "name");
                string sql = "select * from qp_sch_Jiaofei  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.Text = list["Xueqi"].ToString();
                    this.Xueduan.Text = list["Xueduan"].ToString();
                    this.Jine.Text = list["Jine"].ToString();
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.HumanResources.PeiXun.TiKu.DuoXuanTi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DuoXuanTi_update : Page
    {
        protected TextBox AnswerA;
        protected TextBox AnswerB;
        protected TextBox AnswerC;
        protected TextBox AnswerD;
        protected Button Button1;
        protected CheckBoxList cblAnswer;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MingchengID;
        private publics pulicss = new publics();
        protected TextBox Titles;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_hr_DuoXuanTi  Set MingchengID='", this.MingchengID.SelectedValue, "',Titles='", this.pulicss.GetFormatStr(this.Titles.Text), "',AnswerA='", this.pulicss.GetFormatStr(this.AnswerA.Text), "',AnswerB='", this.pulicss.GetFormatStr(this.AnswerB.Text), "',AnswerC='", this.pulicss.GetFormatStr(this.AnswerC.Text), "',AnswerD='", this.pulicss.GetFormatStr(this.AnswerD.Text), "',Answer='", this.pulicss.GetChecked(this.cblAnswer), "'  where id='", int.Parse(base.Request.QueryString["id"]), 
                "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改多选题", "多选题");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='DuoXuanTi.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng from qp_hr_TikuLb order by id asc";
                this.list.Bind_DropDownList_kong(this.MingchengID, sQL, "id", "Mingcheng");
                string sql = "select * from qp_hr_DuoXuanTi where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.MingchengID.SelectedValue = list["MingchengID"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.AnswerA.Text = list["AnswerA"].ToString();
                    this.AnswerB.Text = list["AnswerB"].ToString();
                    this.AnswerC.Text = list["AnswerC"].ToString();
                    this.AnswerD.Text = list["AnswerD"].ToString();
                    this.pulicss.SetChecked(this.cblAnswer, "," + list["Answer"].ToString() + ",");
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


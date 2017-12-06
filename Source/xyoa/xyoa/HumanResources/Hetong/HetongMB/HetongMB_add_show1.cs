namespace xyoa.HumanResources.Hetong.HetongMB
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongMB_add_show1 : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList LeibieID;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Mingcheng;
        protected FCKeditor Neirong;
        private publics pulicss = new publics();
        protected RadioButtonList Zhuangtai;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_HetongMB  Set Mingcheng='", this.pulicss.GetFormatStr(this.Mingcheng.Text), "',LeibieID='", this.LeibieID.SelectedValue, "',Zhuangtai='", this.Zhuangtai.SelectedValue, "',Neirong='", this.pulicss.GetFormatStrbjq(this.Neirong.Value), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改合同模版", "合同模版");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.parent.location.href='HetongMB.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script language=javascript>window.parent.location.href='HetongMB.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng  from qp_hr_HetongLb order by id asc";
                this.list.Bind_DropDownList_nothing(this.LeibieID, sQL, "id", "Mingcheng");
                string sql = "select * from qp_hr_HetongMB where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Mingcheng.Text = list["Mingcheng"].ToString();
                    this.LeibieID.SelectedValue = list["LeibieID"].ToString();
                    this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                    this.Neirong.Value = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


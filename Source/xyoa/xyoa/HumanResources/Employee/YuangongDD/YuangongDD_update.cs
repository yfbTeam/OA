namespace xyoa.HumanResources.Employee.YuangongDD
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongDD_update : Page
    {
        protected TextBox Beizhu;
        protected DropDownList BumenE;
        protected Label BumenQ;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label RealnameYG;
        protected TextBox Riqi;
        protected TextBox UsernameYG;
        protected DropDownList ZhiweiE;
        protected Label ZhiweiQ;

        public void BindAttribute()
        {
            this.RealnameYG.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_YuangongDD  Set BumenE='", this.BumenE.SelectedValue, "',ZhiweiE='", this.ZhiweiE.SelectedValue, "',Leixing='", this.Leixing.SelectedValue, "',Riqi='", this.pulicss.GetFormatStr(this.Riqi.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'  " });
            this.List.ExeSql(sql);
            string str2 = "Update qp_oa_username  Set BuMenId='" + this.BumenE.SelectedValue + "',Zhiweiid='" + this.ZhiweiE.SelectedValue + "' where Username='" + this.UsernameYG.Text + "'";
            this.List.ExeSql(str2);
            string str3 = "Update qp_hr_Yuangong  Set Bumen='" + this.BumenE.SelectedValue + "',Zhiwei='" + this.ZhiweiE.SelectedValue + "' where Username='" + this.UsernameYG.Text + "'";
            this.List.ExeSql(str3);
            this.pulicss.InsertLog("修改员工调动", "员工调动");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongDD.aspx'</script>");
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
                string sQL = "select id,Name from qp_hr_YuangongLx where Type=8 order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "Name");
                this.pulicss.BindListkong("qp_oa_Bumen", this.BumenE, "", "order by Bianhao asc");
                string str2 = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.ZhiweiE, str2, "id", "name");
                string sql = "select * from qp_hr_YuangongDD  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.UsernameYG.Text = list["UsernameYG"].ToString();
                    this.RealnameYG.Text = list["RealnameYG"].ToString();
                    this.Riqi.Text = list["Riqi"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                    this.BumenQ.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BumenQ"].ToString());
                    this.ZhiweiQ.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["ZhiweiQ"].ToString());
                    this.BumenE.SelectedValue = list["BumenE"].ToString();
                    this.ZhiweiE.SelectedValue = list["ZhiweiE"].ToString();
                }
                list.Close();
                this.pulicss.QuanXianBack("eeee4ec", this.Session["perstr"].ToString());
            }
        }
    }
}


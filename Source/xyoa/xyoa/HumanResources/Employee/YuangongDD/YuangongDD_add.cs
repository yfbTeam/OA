namespace xyoa.HumanResources.Employee.YuangongDD
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongDD_add : Page
    {
        protected TextBox Beizhu;
        protected DropDownList BumenE;
        protected Label BumenQ;
        protected Button Button1;
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected ImageButton ImageButton1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox RealnameYG;
        protected TextBox Riqi;
        protected TextBox UsernameYG;
        protected DropDownList ZhiweiE;
        protected Label ZhiweiQ;

        public void BindAttribute()
        {
            this.RealnameYG.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.ImageButton1.Attributes["onclick"] = "javascript:return openuser();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select BuMenId,Zhiweiid from qp_oa_username  where Username='" + this.UsernameYG.Text + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = "insert into qp_hr_YuangongDD  (UsernameYG,RealnameYG,BumenQ,BumenE,ZhiweiQ,ZhiweiE,Leixing,Riqi,Beizhu) values ('" + this.UsernameYG.Text + "','" + this.pulicss.GetFormatStr(this.RealnameYG.Text) + "','" + list["BuMenId"].ToString() + "','" + this.BumenE.SelectedValue + "','" + list["Zhiweiid"].ToString() + "','" + this.ZhiweiE.SelectedValue + "','" + this.Leixing.SelectedValue + "','" + this.Riqi.Text + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "')";
                this.List.ExeSql(str2);
                string str3 = "Update qp_oa_username  Set BuMenId='" + this.BumenE.SelectedValue + "',Zhiweiid='" + this.ZhiweiE.SelectedValue + "' where Username='" + this.UsernameYG.Text + "'";
                this.List.ExeSql(str3);
                string str4 = "Update qp_hr_Yuangong  Set Bumen='" + this.BumenE.SelectedValue + "',Zhiwei='" + this.ZhiweiE.SelectedValue + "' where Username='" + this.UsernameYG.Text + "'";
                this.List.ExeSql(str4);
            }
            list.Close();
            this.pulicss.InsertLog("新增员工调动", "员工调动");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongDD.aspx'</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("YuangongDD.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.BindAttribute();
                    string sQL = "select id,Name from qp_hr_YuangongLx where Type=8 order by id asc";
                    this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "Name");
                    this.pulicss.BindListkong("qp_oa_Bumen", this.BumenE, "", "order by Bianhao asc");
                    string str2 = "select id,name  from qp_oa_Zhiwei order by id asc";
                    this.list.Bind_DropDownList_kong(this.ZhiweiE, str2, "id", "name");
                    this.Riqi.Text = DateTime.Now.ToShortDateString();
                    this.pulicss.QuanXianBack("eeee4ea", this.Session["perstr"].ToString());
                }
                string sql = "select BuMenId,Zhiweiid from qp_oa_username  where Username='" + this.UsernameYG.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.BumenQ.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["BuMenId"].ToString());
                    this.ZhiweiQ.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["Zhiweiid"].ToString());
                }
                else
                {
                    this.BumenQ.Text = "请选择员工";
                    this.ZhiweiQ.Text = "请选择员工";
                }
                list.Close();
            }
        }
    }
}


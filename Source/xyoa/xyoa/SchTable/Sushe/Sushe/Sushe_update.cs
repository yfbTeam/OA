namespace xyoa.SchTable.Sushe.Sushe
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Sushe_update : Page
    {
        protected TextBox Bianhao;
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList JianzhuId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Louceng;
        protected TextBox Mianji;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected RadioButtonList Zaiyong;
        protected TextBox Zuowei;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_sch_Sushe     Set JianzhuId='", this.JianzhuId.SelectedValue, "',Louceng='", this.Louceng.SelectedValue, "',Bianhao='", this.pulicss.GetFormatStr(this.Bianhao.Text), "',Mianji='", this.pulicss.GetFormatStr(this.Mianji.Text), "',Zuowei='", this.pulicss.GetFormatStr(this.Zuowei.Text), "',Zaiyong='", this.Zaiyong.SelectedValue, "' where   id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改宿舍管理[" + this.Bianhao.Text + "]", "宿舍管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Sushe.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Sushe.aspx");
        }

        protected void JianzhuId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select Bianhao,Loucheng from qp_sch_Gongyu where  id='" + this.JianzhuId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.list.Bind_DropDownList_YearForSa(this.Louceng, 1, int.Parse(list["Loucheng"].ToString()));
                string str2 = "select count(A.id) from qp_sch_Sushe as [A] where JianzhuId='" + this.JianzhuId.SelectedValue + "' and Louceng='" + this.Louceng.SelectedValue + "'";
                int num = this.List.GetCount(str2) + 1;
                this.Bianhao.Text = "" + list["Bianhao"].ToString() + "-" + this.Louceng.SelectedValue + "" + num.ToString().PadLeft(2, '0') + "";
            }
            list.Close();
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
                string sql = "select * from qp_sch_Sushe where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.JianzhuId.SelectedValue = list["JianzhuId"].ToString();
                    this.Louceng.SelectedValue = list["Louceng"].ToString();
                    this.Bianhao.Text = list["Bianhao"].ToString();
                    this.Mianji.Text = list["Mianji"].ToString();
                    this.Zuowei.Text = list["Zuowei"].ToString();
                    this.Zaiyong.SelectedValue = list["Zaiyong"].ToString();
                    string str3 = "select Bianhao,Loucheng from qp_sch_Gongyu where  id='" + this.JianzhuId.SelectedValue + "'";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        this.list.Bind_DropDownList_YearForSa(this.Louceng, 1, int.Parse(reader2["Loucheng"].ToString()));
                    }
                    reader2.Close();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


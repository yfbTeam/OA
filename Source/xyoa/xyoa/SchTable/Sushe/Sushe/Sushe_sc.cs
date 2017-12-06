namespace xyoa.SchTable.Sushe.Sushe
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Sushe_sc : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox Fangjianshu;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList JianzhuId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Louceng;
        protected TextBox Mianji;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Zuowei;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select Bianhao,Loucheng,Fangjianshu from qp_sch_Gongyu where  id='" + this.JianzhuId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                for (int i = 1; i <= int.Parse(list["Loucheng"].ToString()); i++)
                {
                    for (int j = 1; j <= int.Parse(list["Fangjianshu"].ToString()); j++)
                    {
                        string str2 = string.Concat(new object[] { "insert into qp_sch_Sushe   (Yiyong,JianzhuId,Louceng,Bianhao,Mianji,Zuowei,Zaiyong) values ('0','", this.JianzhuId.SelectedValue, "','", i, "','", list["Bianhao"].ToString(), "-", i, "", j.ToString().PadLeft(2, '0'), "','", this.pulicss.GetFormatStr(this.Mianji.Text), "','", this.pulicss.GetFormatStr(this.Zuowei.Text), "','在用')" });
                        this.List.ExeSql(str2);
                    }
                }
            }
            list.Close();
            this.pulicss.InsertLog("生成房间" + this.JianzhuId.SelectedItem.Text + "", "宿舍管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Sushe.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Sushe.aspx");
        }

        protected void JianzhuId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select Bianhao,Loucheng,Fangjianshu from qp_sch_Gongyu where  id='" + this.JianzhuId.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.Louceng.Text = list["Loucheng"].ToString();
                this.Fangjianshu.Text = list["Fangjianshu"].ToString();
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
                string sql = "select Bianhao,Loucheng,Fangjianshu from qp_sch_Gongyu where  id='" + this.JianzhuId.SelectedValue + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Louceng.Text = list["Loucheng"].ToString();
                    this.Fangjianshu.Text = list["Fangjianshu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


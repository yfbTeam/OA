namespace xyoa.SchTable.Sushe.Fenpei
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Fenpei_Xx_Wfp_Fp : Page
    {
        protected Button Button1;
        protected Button Button2;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected Label FbName;
        protected HtmlForm form1;
        protected TextBox Geshu;
        protected DropDownList Gongyu;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Shenyu;
        protected DropDownList Sushe;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.Geshu.Text) > int.Parse(this.Shenyu.Text))
            {
                base.Response.Write("<script language=javascript>alert('提交失败，分配数大于座位数');</script>");
            }
            else
            {
                string sql = "Update qp_sch_Xuesheng    Set Sushe='" + this.Sushe.SelectedValue + "' where  id in (" + base.Request.QueryString["XsId"] + ")";
                this.List.ExeSql(sql);
                string str2 = "Update qp_sch_Sushe    Set Yiyong='" + this.Geshu.Text + "' where  id='" + this.Sushe.SelectedValue + "'";
                this.List.ExeSql(str2);
                this.pulicss.InsertLog("宿舍分配", "宿舍分配");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Fenpei_Xx_Wfp.aspx?id=" + base.Request.QueryString["id"] + "'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Fenpei_Xx_Wfp.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        protected void Gongyu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select id,Bianhao+'(剩'+convert(varchar(10),Zuowei-Yiyong)+')' as Bianhao  from qp_sch_Sushe where JianzhuId='" + this.Gongyu.SelectedValue + "' and Zuowei>Yiyong order by id asc";
            this.list.Bind_DropDownList_nothing(this.Sushe, sQL, "id", "Bianhao");
            string sql = "select Zuowei-Yiyong as Shenyu from qp_sch_Sushe where  id='" + this.Sushe.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.Label1.Text = string.Concat(new object[] { "分配学生数：", this.Geshu.Text, "，宿舍剩余座位数：", list["Shenyu"], "" });
                this.Shenyu.Text = list["Shenyu"].ToString();
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
                this.FbName.Text = base.Request.QueryString["Name"].ToString();
                this.pulicss.QuanXianVis(this.Button1, "pppp5c", this.Session["perstr"].ToString());
                string sQL = "select id,Mingcheng  from qp_sch_Gongyu  order by id asc";
                this.list.Bind_DropDownList_nothing(this.Gongyu, sQL, "id", "Mingcheng");
                string str2 = "select id,Bianhao+'(剩'+convert(varchar(10),Zuowei-Yiyong)+')' as Bianhao  from qp_sch_Sushe where JianzhuId='" + this.Gongyu.SelectedValue + "' and Zuowei>Yiyong order by id asc";
                this.list.Bind_DropDownList_nothing(this.Sushe, str2, "id", "Bianhao");
                string str3 = null;
                str3 = "" + base.Request.QueryString["XsId"] + "";
                ArrayList list = new ArrayList();
                string[] strArray = str3.Split(new char[] { ',' });
                this.Geshu.Text = "" + strArray.Length + "";
                string sql = "select Zuowei-Yiyong as Shenyu from qp_sch_Sushe where  id='" + this.Sushe.SelectedValue + "'";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    this.Label1.Text = string.Concat(new object[] { "分配学生数：", this.Geshu.Text, "，宿舍剩余座位数：", reader["Shenyu"], "" });
                    this.Shenyu.Text = reader["Shenyu"].ToString();
                }
                reader.Close();
                this.BindAttribute();
            }
        }

        protected void Sushe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select Zuowei-Yiyong as Shenyu from qp_sch_Sushe where  id='" + this.Sushe.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.Label1.Text = string.Concat(new object[] { "分配学生数：", this.Geshu.Text, "，宿舍剩余座位数：", list["Shenyu"], "" });
                this.Shenyu.Text = list["Shenyu"].ToString();
            }
            list.Close();
        }
    }
}


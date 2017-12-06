namespace xyoa.SchTable.Sushe.Dengji
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Dengji_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList JianzhuId;
        protected TextBox Jingbanren;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Miaosu;
        protected TextBox Number;
        protected TextBox Peichang;
        private publics pulicss = new publics();
        protected TextBox Shijian;
        protected DropDownList SsId;
        protected DropDownList XsId;
        protected TextBox Yijian;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_sch_SuSheXiDj     Set XsId='", this.XsId.SelectedValue, "',SsId='", this.SsId.SelectedValue, "',JianzhuId='", this.JianzhuId.SelectedValue, "',Leixing='", this.Leixing.SelectedValue, "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Miaosu='", this.pulicss.GetFormatStr(this.Miaosu.Text), "',Yijian='", this.pulicss.GetFormatStr(this.Yijian.Text), "',Peichang='", this.pulicss.GetFormatStr(this.Peichang.Text), 
                "',Jingbanren='", this.pulicss.GetFormatStr(this.Jingbanren.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改信息登记[" + this.XsId.SelectedItem.Text + "]", "信息登记");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Dengji.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Dengji.aspx");
        }

        protected void JianzhuId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select id,Bianhao  from qp_sch_Sushe where JianzhuId='" + this.JianzhuId.SelectedValue + "'  order by id asc";
            this.list.Bind_DropDownList_nothing(this.SsId, sQL, "id", "Bianhao");
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
                string str2 = "select id,name  from qp_sch_DataFile where type='13' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_nothing(this.Leixing, str2, "id", "name");
                string sql = "select * from qp_sch_SuSheXiDj where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.JianzhuId.SelectedValue = list["JianzhuId"].ToString();
                    string str4 = "select id,Bianhao  from qp_sch_Sushe where JianzhuId='" + this.JianzhuId.SelectedValue + "'  order by id asc";
                    this.list.Bind_DropDownList_nothing(this.SsId, str4, "id", "Bianhao");
                    string str5 = "select id,Xingming  from qp_sch_Xuesheng where Sushe='" + this.SsId.SelectedValue + "'  order by id asc";
                    this.list.Bind_DropDownList_nothing(this.XsId, str5, "id", "Xingming");
                    this.SsId.SelectedValue = list["SsId"].ToString();
                    this.XsId.SelectedValue = list["XsId"].ToString();
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Miaosu.Text = list["Miaosu"].ToString();
                    this.Yijian.Text = list["Yijian"].ToString();
                    this.Peichang.Text = list["Peichang"].ToString();
                    this.Jingbanren.Text = list["Jingbanren"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }

        protected void SsId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQL = "select id,Xingming  from qp_sch_Xuesheng where Sushe='" + this.SsId.SelectedValue + "'  order by id asc";
            this.list.Bind_DropDownList_nothing(this.XsId, sQL, "id", "Xingming");
        }
    }
}


namespace xyoa.SchTable.Sushe.Dengji
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Dengji_add : Page
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
            string sql = "insert into qp_sch_SuSheXiDj   (XsId,SsId,Shijian,Miaosu,Yijian,Peichang,Jingbanren,JianzhuId,Leixing) values ('" + this.XsId.SelectedValue + "','" + this.SsId.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Shijian.Text) + "','" + this.pulicss.GetFormatStr(this.Miaosu.Text) + "','" + this.pulicss.GetFormatStr(this.Yijian.Text) + "','" + this.pulicss.GetFormatStr(this.Peichang.Text) + "','" + this.pulicss.GetFormatStr(this.Jingbanren.Text) + "','" + this.JianzhuId.SelectedValue + "','" + this.Leixing.SelectedValue + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增信息登记[" + this.XsId.SelectedItem.Text + "]", "信息登记");
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
                string str2 = "select id,Bianhao  from qp_sch_Sushe where JianzhuId='" + this.JianzhuId.SelectedValue + "'  order by id asc";
                this.list.Bind_DropDownList_nothing(this.SsId, str2, "id", "Bianhao");
                string str3 = "select id,Xingming  from qp_sch_Xuesheng where Sushe='" + this.SsId.SelectedValue + "'  order by id asc";
                this.list.Bind_DropDownList_nothing(this.XsId, str3, "id", "Xingming");
                string str4 = "select id,name  from qp_sch_DataFile where type='13' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, str4, "id", "name");
                this.Shijian.Text = DateTime.Now.ToString();
                this.Jingbanren.Text = this.Session["Realname"].ToString();
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


namespace xyoa.SchTable.Sushe.Gongyu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Gongyu_add : Page
    {
        protected TextBox Beizhu;
        protected TextBox Bianhao;
        protected Button Button1;
        protected Button Button2;
        protected TextBox Caichang;
        protected TextBox Dianhua;
        protected TextBox Fangjianshu;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Jiegou;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Loucheng;
        protected TextBox Mianji;
        protected TextBox Mingcheng;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Shijian;
        protected TextBox Weizhi;
        protected TextBox Xiaoqu;
        protected TextBox Yongfei;
        protected DropDownList Yongtu;
        protected DropDownList Zhuangtai;
        protected TextBox ZyMianji;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_sch_Gongyu   (Mingcheng,Bianhao,Leixing,Yongtu,Zhuangtai,Jiegou,Loucheng,Fangjianshu,Shijian,Dianhua,ZyMianji,Yongfei,Mianji,Caichang,Xiaoqu,Weizhi,Beizhu) values ('" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "','" + this.pulicss.GetFormatStr(this.Bianhao.Text) + "','" + this.pulicss.GetFormatStr(this.Leixing.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.Yongtu.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.Zhuangtai.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.Jiegou.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.Loucheng.Text) + "','" + this.pulicss.GetFormatStr(this.Fangjianshu.Text) + "','" + this.pulicss.GetFormatStr(this.Shijian.Text) + "','" + this.pulicss.GetFormatStr(this.Dianhua.Text) + "','" + this.pulicss.GetFormatStr(this.ZyMianji.Text) + "','" + this.pulicss.GetFormatStr(this.Yongfei.Text) + "','" + this.pulicss.GetFormatStr(this.Mianji.Text) + "','" + this.pulicss.GetFormatStr(this.Caichang.Text) + "','" + this.pulicss.GetFormatStr(this.Xiaoqu.Text) + "','" + this.pulicss.GetFormatStr(this.Weizhi.Text) + "','" + this.pulicss.GetFormatStr(this.Beizhu.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增公寓信息[" + this.Mingcheng.Text + "]", "公寓信息");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Gongyu.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Gongyu.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_sch_DataFile where type='9' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, sQL, "id", "name");
                string str2 = "select id,name  from qp_sch_DataFile where type='10' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Yongtu, str2, "id", "name");
                string str3 = "select id,name  from qp_sch_DataFile where type='11' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhuangtai, str3, "id", "name");
                string str4 = "select id,name  from qp_sch_DataFile where type='12' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Jiegou, str4, "id", "name");
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.SchTable.Sushe.Gongyu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Gongyu_update : Page
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
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Gongyu     Set Mingcheng='", this.pulicss.GetFormatStr(this.Mingcheng.Text), "',Bianhao='", this.pulicss.GetFormatStr(this.Bianhao.Text), "',Leixing='", this.Leixing.SelectedValue, "',Yongtu='", this.Yongtu.SelectedValue, "',Zhuangtai='", this.Zhuangtai.SelectedValue, "',Jiegou='", this.Jiegou.SelectedValue, "',Loucheng='", this.pulicss.GetFormatStr(this.Loucheng.Text), "',Fangjianshu='", this.pulicss.GetFormatStr(this.Fangjianshu.Text), 
                "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Dianhua='", this.pulicss.GetFormatStr(this.Dianhua.Text), "',ZyMianji='", this.pulicss.GetFormatStr(this.ZyMianji.Text), "',Yongfei='", this.pulicss.GetFormatStr(this.Yongfei.Text), "',Mianji='", this.pulicss.GetFormatStr(this.Mianji.Text), "',Caichang='", this.pulicss.GetFormatStr(this.Caichang.Text), "',Xiaoqu='", this.pulicss.GetFormatStr(this.Xiaoqu.Text), "',Weizhi='", this.pulicss.GetFormatStr(this.Weizhi.Text), 
                "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改公寓信息[" + this.Mingcheng.Text + "]", "公寓信息");
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
                string sql = "select * from qp_sch_Gongyu where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Mingcheng.Text = list["Mingcheng"].ToString();
                    this.Bianhao.Text = list["Bianhao"].ToString();
                    this.Leixing.SelectedValue = list["Leixing"].ToString();
                    this.Yongtu.SelectedValue = list["Yongtu"].ToString();
                    this.Zhuangtai.SelectedValue = list["Zhuangtai"].ToString();
                    this.Jiegou.SelectedValue = list["Jiegou"].ToString();
                    this.Loucheng.Text = list["Loucheng"].ToString();
                    this.Fangjianshu.Text = list["Fangjianshu"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Dianhua.Text = list["Dianhua"].ToString();
                    this.ZyMianji.Text = list["ZyMianji"].ToString();
                    this.Yongfei.Text = list["Yongfei"].ToString();
                    this.Mianji.Text = list["Mianji"].ToString();
                    this.Caichang.Text = list["Caichang"].ToString();
                    this.Xiaoqu.Text = list["Xiaoqu"].ToString();
                    this.Weizhi.Text = list["Weizhi"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.HumanResources.Employee.YuangongCX
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongCX : Page
    {
        protected TextBox Bianhao;
        protected TextBox Bumen;
        protected TextBox BumenId;
        protected Button Button2;
        protected TextBox Chusheng1;
        protected TextBox Chusheng2;
        protected TextBox CjShijian1;
        protected TextBox CjShijian2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected RadioButtonList Hunyin;
        protected DropDownList Jiguan;
        protected TextBox JrShijian1;
        protected TextBox JrShijian2;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Mianmao;
        protected DropDownList Mingzhu;
        protected TextBox Nianling1;
        protected TextBox Nianling2;
        private publics pulicss = new publics();
        protected RadioButtonList Xingbie;
        protected TextBox Xingming;
        protected DropDownList Xuexi;
        protected TextBox Yuanxiao;
        protected DropDownList Zhicheng;
        protected DropDownList Zhiwei;
        protected DropDownList Zhuanye;

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Session["YuangongCX"] = this.CreateMidSql();
            base.Response.Redirect("YuangongCXList.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.BumenId.Text != "")
            {
                str = str + " and A.Bumen in (" + this.BumenId.Text + "0)";
            }
            if (this.Xingming.Text != "")
            {
                str = str + " and A.Xingming like '%" + this.pulicss.GetFormatStr(this.Xingming.Text) + "%'";
            }
            if (this.Bianhao.Text != "")
            {
                str = str + " and A.Bianhao like '%" + this.pulicss.GetFormatStr(this.Bianhao.Text) + "%'";
            }
            if (this.Xingbie.SelectedValue != "0")
            {
                str = str + " and A.Xingbie = '" + this.Xingbie.SelectedValue + "'";
            }
            if ((this.Nianling1.Text != "") && (this.Nianling2.Text != ""))
            {
                str = str + " and datediff(yy,Chusheng,getdate())<=" + this.Nianling2.Text + " and datediff(yy,Chusheng,getdate())>=" + this.Nianling1.Text + "";
            }
            if (this.Mingzhu.SelectedValue != "")
            {
                str = str + " and A.Mingzhu = '" + this.Mingzhu.SelectedValue + "'";
            }
            if (this.Jiguan.SelectedValue != "")
            {
                str = str + " and A.Jiguan = '" + this.Jiguan.SelectedValue + "'";
            }
            if (this.Mianmao.SelectedValue != "")
            {
                str = str + " and A.Mianmao = '" + this.Mianmao.SelectedValue + "'";
            }
            if (this.Hunyin.SelectedValue != "0")
            {
                str = str + " and A.Hunyin = '" + this.Hunyin.SelectedValue + "'";
            }
            if (this.Xuexi.SelectedValue != "")
            {
                str = str + " and A.Xuexi = '" + this.Xuexi.SelectedValue + "'";
            }
            if (this.Yuanxiao.Text != "")
            {
                str = str + " and A.Yuanxiao like '%" + this.pulicss.GetFormatStr(this.Yuanxiao.Text) + "%'";
            }
            if (this.Zhuanye.SelectedValue != "")
            {
                str = str + " and A.Zhuanye = '" + this.Zhuanye.SelectedValue + "'";
            }
            if (this.Leixing.SelectedValue != "")
            {
                str = str + " and A.Leixing = '" + this.Leixing.SelectedValue + "'";
            }
            if (this.Zhiwei.SelectedValue != "")
            {
                str = str + " and Zhiwei = '" + this.Zhiwei.SelectedValue + "'";
            }
            if (this.Zhicheng.SelectedValue != "")
            {
                str = str + " and Zhicheng = '" + this.Zhicheng.SelectedValue + "'";
            }
            if ((this.Chusheng1.Text != "") && (this.Chusheng2.Text != ""))
            {
                str = str + " and ((Chusheng between '" + this.Chusheng1.Text + "'and  '" + this.Chusheng2.Text + "') or (convert(char(10),cast(Chusheng as datetime),120)=convert(char(10),cast('" + this.Chusheng1.Text + "' as datetime),120)) or (convert(char(10),cast(Chusheng as datetime),120)=convert(char(10),cast('" + this.Chusheng2.Text + "' as datetime),120)))";
            }
            if ((this.CjShijian1.Text != "") && (this.CjShijian2.Text != ""))
            {
                str = str + " and ((CjShijian between '" + this.CjShijian1.Text + "'and  '" + this.CjShijian2.Text + "') or (convert(char(10),cast(CjShijian as datetime),120)=convert(char(10),cast('" + this.CjShijian1.Text + "' as datetime),120)) or (convert(char(10),cast(CjShijian as datetime),120)=convert(char(10),cast('" + this.CjShijian2.Text + "' as datetime),120)))";
            }
            if ((this.JrShijian1.Text != "") && (this.JrShijian2.Text != ""))
            {
                str = str + " and ((JrShijian between '" + this.JrShijian1.Text + "'and  '" + this.JrShijian2.Text + "') or (convert(char(10),cast(JrShijian as datetime),120)=convert(char(10),cast('" + this.JrShijian1.Text + "' as datetime),120)) or (convert(char(10),cast(JrShijian as datetime),120)=convert(char(10),cast('" + this.JrShijian2.Text + "' as datetime),120)))";
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee4d", this.Session["perstr"].ToString());
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                string str2 = "select id,Name from qp_hr_YuangongLx where Type=1 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Mingzhu, str2, "id", "Name");
                string str3 = "select id,Name from qp_hr_YuangongLx where Type=2 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Jiguan, str3, "id", "Name");
                string str4 = "select id,Name from qp_hr_YuangongLx where Type=3 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Mianmao, str4, "id", "Name");
                string str5 = "select id,Name from qp_hr_YuangongLx where Type=4 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Xuexi, str5, "id", "Name");
                string str6 = "select id,Name from qp_hr_YuangongLx where Type=5 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhuanye, str6, "id", "Name");
                string str7 = "select id,Name from qp_hr_YuangongLx where Type=6 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhicheng, str7, "id", "Name");
                string str8 = "select id,Name from qp_hr_YuangongLx where Type=7 and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_kong(this.Leixing, str8, "id", "Name");
                this.Bumen.Attributes.Add("readonly", "readonly");
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
            }
        }
    }
}


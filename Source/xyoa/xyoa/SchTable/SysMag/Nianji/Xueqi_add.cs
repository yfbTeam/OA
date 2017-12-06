namespace xyoa.SchTable.SysMag.Nianji
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueqi_add : Page
    {
        protected Button Button1;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected CheckBoxList Kaoshilx;
        protected CheckBoxList Kecheng;
        protected CheckBoxList KechengX;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList NianjiMc;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList Richeng1;
        protected DropDownList Richeng2;
        protected DropDownList Richeng3;
        protected RadioButtonList RuxueBiye;
        protected DropDownList Tianshu;
        protected DropDownList Xueqi;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_sch_Nianji where Xueqi='" + this.Xueqi.SelectedValue + "' and NianjiMc='" + this.pulicss.GetFormatStr(this.NianjiMc.Text) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                base.Response.Write("<script language=javascript>alert('在" + this.Xueqi.SelectedValue + "学期中，年级名称已存在！');</script>");
                list.Close();
            }
            else
            {
                list.Close();
                string str2 = "insert into qp_sch_Nianji  (Tianshu,Richeng1,Richeng2,Richeng3,Xueqi,NianjiMc,RuxueBiye,Kecheng,KechengX,Kaoshilx) values ('" + this.pulicss.GetFormatStr(this.Tianshu.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.Richeng1.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.Richeng2.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.Richeng3.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.Xueqi.SelectedValue) + "','" + this.pulicss.GetFormatStr(this.NianjiMc.Text) + "','" + this.pulicss.GetFormatStr(this.RuxueBiye.SelectedValue) + "','" + this.pulicss.GetChecked(this.Kecheng) + "','" + this.pulicss.GetChecked(this.KechengX) + "','" + this.pulicss.GetChecked(this.Kaoshilx) + "')";
                this.List.ExeSql(str2);
                this.pulicss.InsertLog("新增年级设置[" + this.NianjiMc.SelectedValue + "]", "年级设置");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Nianji.aspx'</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                string str2 = "select id,Name  from qp_sch_Kecheng order by id asc";
                this.list.Bind_DropDownList_CheckBoxList(this.Kecheng, str2, "id", "Name");
                string str3 = "select id,Name  from qp_sch_Kecheng order by id asc";
                this.list.Bind_DropDownList_CheckBoxList(this.KechengX, str3, "id", "Name");
                string str4 = "select id,Name  from qp_sch_DataFile where type='19' and ifdel=0 order by id asc";
                this.list.Bind_DropDownList_CheckBoxList(this.Kaoshilx, str4, "id", "Name");
                this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                string sql = "select QiyongXueduan from qp_sch_Xueqi where  Mingcheng='" + this.Xueqi.SelectedValue + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str6 = "select id,Name  from qp_sch_SetSclClass where '" + list["QiyongXueduan"].ToString() + "' like '%'+Xueduan+'%'  order by Num asc";
                    this.list.Bind_DropDownList_nothing(this.NianjiMc, str6, "Name", "Name");
                }
                list.Close();
                this.BindAttribute();
            }
        }

        protected void Xueqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select QiyongXueduan from qp_sch_Xueqi where  Mingcheng='" + this.Xueqi.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string sQL = "select id,Name  from qp_sch_SetSclClass where '" + list["QiyongXueduan"].ToString() + "' like '%'+Xueduan+'%'  order by Num asc";
                this.list.Bind_DropDownList_nothing(this.NianjiMc, sQL, "Name", "Name");
            }
            list.Close();
        }
    }
}


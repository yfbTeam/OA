namespace xyoa.SchTable.SysMag.Nianji
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Nianji_update : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected CheckBoxList Kaoshilx;
        protected CheckBoxList Kecheng;
        protected CheckBoxList KechengX;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList NianjiMc;
        protected TextBox NianjiMcC;
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
            if (this.NianjiMc.SelectedValue != this.NianjiMcC.Text)
            {
                string str = "select * from qp_sch_Nianji where Xueqi='" + this.Xueqi.SelectedValue + "' and NianjiMc='" + this.pulicss.GetFormatStr(this.NianjiMc.Text) + "'";
                SqlDataReader list = this.List.GetList(str);
                if (list.Read())
                {
                    base.Response.Write("<script language=javascript>alert('在" + this.Xueqi.SelectedValue + "学期中，年级名称已存在！');</script>");
                    list.Close();
                    return;
                }
                list.Close();
            }
            string sql = string.Concat(new object[] { 
                "Update qp_sch_Nianji     Set Tianshu='", this.pulicss.GetFormatStr(this.Tianshu.SelectedValue), "',Richeng1='", this.pulicss.GetFormatStr(this.Richeng1.SelectedValue), "',Richeng2='", this.pulicss.GetFormatStr(this.Richeng2.SelectedValue), "',Richeng3='", this.pulicss.GetFormatStr(this.Richeng3.SelectedValue), "',Xueqi='", this.pulicss.GetFormatStr(this.Xueqi.SelectedValue), "',NianjiMc='", this.pulicss.GetFormatStr(this.NianjiMc.Text), "',RuxueBiye='", this.pulicss.GetFormatStr(this.RuxueBiye.SelectedValue), "',Kecheng='", this.pulicss.GetChecked(this.Kecheng), 
                "',KechengX='", this.pulicss.GetChecked(this.KechengX), "',Kaoshilx='", this.pulicss.GetChecked(this.Kaoshilx), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改年级设置[" + this.NianjiMc.SelectedValue + "]", "年级设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Nianji.aspx'</script>");
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
                string sql = "select * from qp_sch_Nianji where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xueqi.SelectedValue = list["Xueqi"].ToString();
                    this.NianjiMc.SelectedValue = list["NianjiMc"].ToString();
                    this.NianjiMcC.Text = list["NianjiMc"].ToString();
                    this.RuxueBiye.SelectedValue = list["RuxueBiye"].ToString();
                    this.pulicss.SetChecked(this.Kecheng, list["Kecheng"].ToString());
                    this.pulicss.SetChecked(this.KechengX, list["KechengX"].ToString());
                    this.pulicss.SetChecked(this.Kaoshilx, list["Kaoshilx"].ToString());
                    this.Richeng1.SelectedValue = list["Richeng1"].ToString();
                    this.Richeng2.SelectedValue = list["Richeng2"].ToString();
                    this.Richeng3.SelectedValue = list["Richeng3"].ToString();
                    this.Tianshu.SelectedValue = list["Tianshu"].ToString();
                }
                list.Close();
                string str6 = "select QiyongXueduan from qp_sch_Xueqi where  Mingcheng='" + this.Xueqi.SelectedValue + "'";
                SqlDataReader reader2 = this.List.GetList(str6);
                if (reader2.Read())
                {
                    string str7 = "select id,Name  from qp_sch_SetSclClass where '" + reader2["QiyongXueduan"].ToString() + "' like '%'+Xueduan+'%'  order by Num asc";
                    this.list.Bind_DropDownList_nothing(this.NianjiMc, str7, "Name", "Name");
                }
                reader2.Close();
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


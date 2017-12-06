namespace xyoa.HumanResources.KaoPing.KaoPingSz
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoPingSz_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Jishu;
        protected TextBox Leixing;
        private Db List = new Db();
        protected TextBox Name1;
        protected TextBox Name2;
        protected TextBox Name3;
        protected TextBox Name4;
        protected TextBox Name5;
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Quanzhong1;
        protected TextBox Quanzhong2;
        protected TextBox Quanzhong3;
        protected TextBox Quanzhong4;
        protected TextBox Quanzhong5;
        protected TextBox QuanzhongMy;
        protected TextBox User1;
        protected TextBox User2;
        protected TextBox User3;
        protected TextBox User4;
        protected TextBox User5;
        protected TextBox Zongfen;

        public void BindAttribute()
        {
            this.Name1.Attributes.Add("readonly", "readonly");
            this.Name2.Attributes.Add("readonly", "readonly");
            this.Name3.Attributes.Add("readonly", "readonly");
            this.Name4.Attributes.Add("readonly", "readonly");
            this.Name5.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_hr_KaoPingSz  Set Leixing='", this.pulicss.GetFormatStr(this.Leixing.Text), "',Zongfen='", this.pulicss.GetFormatStr(this.Zongfen.Text), "',Jishu='", this.Jishu.SelectedValue, "',Neirong='", this.pulicss.GetFormatStrbjq(this.Neirong.Value), "',QuanzhongMy='", this.pulicss.GetFormatStr(this.QuanzhongMy.Text), "',User1='", this.pulicss.GetFormatStr(this.User1.Text), "',Name1='", this.pulicss.GetFormatStr(this.Name1.Text), "',Quanzhong1='", this.pulicss.GetFormatStr(this.Quanzhong1.Text), 
                "',User2='", this.pulicss.GetFormatStr(this.User2.Text), "',Name2='", this.pulicss.GetFormatStr(this.Name2.Text), "',Quanzhong2='", this.pulicss.GetFormatStr(this.Quanzhong2.Text), "',User3='", this.pulicss.GetFormatStr(this.User3.Text), "',Name3='", this.pulicss.GetFormatStr(this.Name3.Text), "',Quanzhong3='", this.pulicss.GetFormatStr(this.Quanzhong3.Text), "',User4='", this.pulicss.GetFormatStr(this.User4.Text), "',Name4='", this.pulicss.GetFormatStr(this.Name4.Text), 
                "',Quanzhong4='", this.pulicss.GetFormatStr(this.Quanzhong4.Text), "',User5='", this.pulicss.GetFormatStr(this.User5.Text), "',Name5='", this.pulicss.GetFormatStr(this.Name5.Text), "',Quanzhong5='", this.pulicss.GetFormatStr(this.Quanzhong5.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改考评设置", "考评设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KaoPingSz.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("KaoPingSz.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                string sql = "select * from qp_hr_KaoPingSz where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Leixing.Text = list["Leixing"].ToString();
                    this.Zongfen.Text = list["Zongfen"].ToString();
                    this.Jishu.Text = list["Jishu"].ToString();
                    this.Neirong.Value = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                    this.QuanzhongMy.Text = list["QuanzhongMy"].ToString();
                    this.User1.Text = list["User1"].ToString();
                    this.Name1.Text = list["Name1"].ToString();
                    this.Quanzhong1.Text = list["Quanzhong1"].ToString();
                    this.User2.Text = list["User2"].ToString();
                    this.Name2.Text = list["Name2"].ToString();
                    this.Quanzhong2.Text = list["Quanzhong2"].ToString();
                    this.User3.Text = list["User3"].ToString();
                    this.Name3.Text = list["Name3"].ToString();
                    this.Quanzhong3.Text = list["Quanzhong3"].ToString();
                    this.User4.Text = list["User4"].ToString();
                    this.Name4.Text = list["Name4"].ToString();
                    this.Quanzhong4.Text = list["Quanzhong4"].ToString();
                    this.User5.Text = list["User5"].ToString();
                    this.Name5.Text = list["Name5"].ToString();
                    this.Quanzhong5.Text = list["Quanzhong5"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}


namespace xyoa.HumanResources.PeiXun.ShiJuan
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ShiJuanMxZd : Page
    {
        protected Button Button1;
        protected Button Button2;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected TextBox Fenzhi1;
        protected TextBox Fenzhi2;
        protected TextBox Fenzhi3;
        protected TextBox Fenzhi4;
        protected TextBox Fenzhi5;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label MingchengID;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label ShijuanID;
        protected TextBox Shumu1;
        protected TextBox Shumu2;
        protected TextBox Shumu3;
        protected TextBox Shumu4;
        protected TextBox Shumu5;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.Shumu1.Text) > int.Parse(this.ViewState["DanXuanTi"].ToString()))
            {
                base.Response.Write("<script language=javascript>alert('单选题数目大于题库现有数目！');</script>");
            }
            else if (int.Parse(this.Shumu2.Text) > int.Parse(this.ViewState["DuoXuanTi"].ToString()))
            {
                base.Response.Write("<script language=javascript>alert('多选题数目大于题库现有数目！');</script>");
            }
            else if (int.Parse(this.Shumu3.Text) > int.Parse(this.ViewState["PanDuanTi"].ToString()))
            {
                base.Response.Write("<script language=javascript>alert('判断题数目大于题库现有数目！');</script>");
            }
            else if (int.Parse(this.Shumu4.Text) > int.Parse(this.ViewState["TianKongTi"].ToString()))
            {
                base.Response.Write("<script language=javascript>alert('填空题数目大于题库现有数目！');</script>");
            }
            else if (int.Parse(this.Shumu5.Text) > int.Parse(this.ViewState["WenDaTi"].ToString()))
            {
                base.Response.Write("<script language=javascript>alert('问答题数目大于题库现有数目！');</script>");
            }
            else
            {
                string sql = "select top " + this.Shumu1.Text + " id from qp_hr_DanXuanTi where  MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + " order by newid()";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    string str2 = "insert into qp_hr_ShiJuanMx (ShijuanID,Leixing,TiMuID,Fenshu) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "','1','" + list["id"].ToString() + "','" + this.Fenzhi1.Text + "')";
                    this.List.ExeSql(str2);
                }
                list.Close();
                string str3 = "select top " + this.Shumu2.Text + " id from qp_hr_DuoXuanTi where  MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "  order by newid()";
                SqlDataReader reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    string str4 = "insert into qp_hr_ShiJuanMx (ShijuanID,Leixing,TiMuID,Fenshu) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "','2','" + reader2["id"].ToString() + "','" + this.Fenzhi2.Text + "')";
                    this.List.ExeSql(str4);
                }
                reader2.Close();
                string str5 = "select top " + this.Shumu3.Text + " id from qp_hr_PanDuanTi where  MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "  order by newid()";
                SqlDataReader reader3 = this.List.GetList(str5);
                while (reader3.Read())
                {
                    string str6 = "insert into qp_hr_ShiJuanMx (ShijuanID,Leixing,TiMuID,Fenshu) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "','3','" + reader3["id"].ToString() + "','" + this.Fenzhi3.Text + "')";
                    this.List.ExeSql(str6);
                }
                reader3.Close();
                string str7 = "select top " + this.Shumu4.Text + " id from qp_hr_TianKongTi where  MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "  order by newid()";
                SqlDataReader reader4 = this.List.GetList(str7);
                while (reader4.Read())
                {
                    string str8 = "insert into qp_hr_ShiJuanMx (ShijuanID,Leixing,TiMuID,Fenshu) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "','4','" + reader4["id"].ToString() + "','" + this.Fenzhi4.Text + "')";
                    this.List.ExeSql(str8);
                }
                reader4.Close();
                string str9 = "select top " + this.Shumu5.Text + " id from qp_hr_WenDaTi where  MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "  order by newid()";
                SqlDataReader reader5 = this.List.GetList(str9);
                while (reader5.Read())
                {
                    string str10 = "insert into qp_hr_ShiJuanMx (ShijuanID,Leixing,TiMuID,Fenshu) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "','5','" + reader5["id"].ToString() + "','" + this.Fenzhi5.Text + "')";
                    this.List.ExeSql(str10);
                }
                reader5.Close();
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ShiJuan.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShiJuan.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_hr_ShiJuan where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["ShijuanID"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.MingchengID.Text = this.divhr.TypeCode("Mingcheng", "qp_hr_TikuLb", list["MingchengID"].ToString());
                    this.ShijuanID.Text = this.divhr.TypeCode("Titles", "qp_hr_ShiJuan", list["id"].ToString());
                }
                list.Close();
                string str2 = "select count(id) from qp_hr_DanXuanTi where MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "";
                this.ViewState["DanXuanTi"] = "" + this.List.GetCount(str2) + "";
                string str3 = "select count(id) from qp_hr_DuoXuanTi where MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "";
                this.ViewState["DuoXuanTi"] = "" + this.List.GetCount(str3) + "";
                string str4 = "select count(id) from qp_hr_PanDuanTi where MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "";
                this.ViewState["PanDuanTi"] = "" + this.List.GetCount(str4) + "";
                string str5 = "select count(id) from qp_hr_TianKongTi where MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "";
                this.ViewState["TianKongTi"] = "" + this.List.GetCount(str5) + "";
                string str6 = "select count(id) from qp_hr_WenDaTi where MingchengID=" + this.pulicss.GetFormatStr(base.Request.QueryString["MingchengID"]) + "";
                this.ViewState["WenDaTi"] = "" + this.List.GetCount(str6) + "";
                this.BindAttribute();
            }
        }
    }
}


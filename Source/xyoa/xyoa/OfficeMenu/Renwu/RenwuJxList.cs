namespace xyoa.OfficeMenu.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RenwuJxList : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private Db List = new Db();
        protected Label mx;
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=ExcelFile.xls");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/excel";
            base.Response.Write(this.mx.Text);
            base.Response.End();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("RenwuJx.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            base.Response.AddHeader("content-disposition", "attachment; filename=ExcelFile.xls");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            base.Response.ContentType = "application/excel";
            base.Response.Write(this.Label1.Text);
            base.Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                object text;
                if ((base.Request.QueryString["Startime"] != "") && (base.Request.QueryString["Endtime"] != ""))
                {
                    this.ViewState["shijian"] = " and (SetTime between '" + base.Request.QueryString["Startime"] + "'and  '" + base.Request.QueryString["Endtime"] + "' or convert(char(10),cast(SetTime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Startime"] + "' as datetime),120) or convert(char(10),cast(SetTime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Endtime"] + "' as datetime),120) ) ";
                }
                this.pulicss.QuanXianBack("kkkk7d", this.Session["perstr"].ToString());
                this.mx.Text = null;
                this.mx.Text = this.mx.Text + "<table width=\"647\" height=\"78\" border=\"1\" cellpadding=\"4\" cellspacing=\"0\" bordercolor=\"#000000\"><tr><td colspan=\"8\" align=\"center\"><strong>主办任务</strong></td></tr><tr><td width=\"73\" align=\"center\"><strong>姓名</strong></td><td width=\"77\" align=\"center\"><strong>总任务</strong></td><td width=\"67\" align=\"center\"><strong>已完成</strong></td><td width=\"75\" align=\"center\"><strong>提前完成</strong></td><td width=\"75\" align=\"center\"><strong>延迟完成</strong></td><td width=\"72\" align=\"center\"><strong>进行中</strong></td><td width=\"63\" align=\"center\"><strong>已暂停</strong></td><td width=\"63\" align=\"center\"><strong>强行停止</strong></td></tr>";
                string sql = "select username,realname from qp_oa_username where id in (" + base.Request.QueryString["FqUsername"] + ") order by id desc";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    string str2 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where ZbUsername='", list["username"], "' ", this.ViewState["shijian"], "" });
                    string str3 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='4' and ZbUsername='", list["username"], "' ", this.ViewState["shijian"], "" });
                    string str4 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='4' and datediff(ss,Endtime,WcTime)<0 and ZbUsername='", list["username"], "' ", this.ViewState["shijian"], "" });
                    string str5 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='4' and datediff(ss,Endtime,WcTime)>0  and ZbUsername='", list["username"], "' ", this.ViewState["shijian"], "" });
                    string str6 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='1' and ZbUsername='", list["username"], "' ", this.ViewState["shijian"], "" });
                    string str7 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='2' and ZbUsername='", list["username"], "' ", this.ViewState["shijian"], "" });
                    string str8 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='3' and ZbUsername='", list["username"], "' ", this.ViewState["shijian"], "" });
                    text = this.mx.Text;
                    this.mx.Text = string.Concat(new object[] { 
                        text, "<tr><td align=\"center\">", list["realname"], "&nbsp;</td><td align=\"center\">", this.List.GetCount(str2), "</td><td align=\"center\">", this.List.GetCount(str3), "&nbsp;</td><td align=\"center\">", this.List.GetCount(str4), "&nbsp;</td><td align=\"center\">", this.List.GetCount(str5), "&nbsp;</td><td align=\"center\">", this.List.GetCount(str6), "&nbsp;</td><td align=\"center\">", this.List.GetCount(str7), "&nbsp;</td><td align=\"center\">", 
                        this.List.GetCount(str8), "&nbsp;</td></tr>"
                     });
                }
                list.Close();
                this.mx.Text = this.mx.Text + "</table>";
                this.Label1.Text = null;
                this.Label1.Text = this.Label1.Text + "<table width=\"647\" height=\"78\" border=\"1\" cellpadding=\"4\" cellspacing=\"0\" bordercolor=\"#000000\"><tr><td colspan=\"8\" align=\"center\"><strong>协办任务</strong></td></tr><tr><td width=\"73\" align=\"center\"><strong>姓名</strong></td><td width=\"77\" align=\"center\"><strong>总任务</strong></td><td width=\"67\" align=\"center\"><strong>已完成</strong></td><td width=\"75\" align=\"center\"><strong>提前完成</strong></td><td width=\"75\" align=\"center\"><strong>延迟完成</strong></td><td width=\"72\" align=\"center\"><strong>进行中</strong></td><td width=\"63\" align=\"center\"><strong>已暂停</strong></td><td width=\"63\" align=\"center\"><strong>强行停止</strong></td></tr>";
                string str9 = "select username,realname from qp_oa_username where id in (" + base.Request.QueryString["FqUsername"] + ") order by id desc";
                SqlDataReader reader2 = this.List.GetList(str9);
                while (reader2.Read())
                {
                    string str10 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where (CHARINDEX(',", reader2["username"], ",',','+JbUsername+',')   >   0 ) ", this.ViewState["shijian"], "" });
                    string str11 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='4' and (CHARINDEX(',", reader2["username"], ",',','+JbUsername+',')   >   0 ) ", this.ViewState["shijian"], "" });
                    string str12 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='4' and datediff(ss,Endtime,WcTime)<0 and (CHARINDEX(',", reader2["username"], ",',','+JbUsername+',')   >   0 ) ", this.ViewState["shijian"], "" });
                    string str13 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='4' and datediff(ss,Endtime,WcTime)>0  and (CHARINDEX(',", reader2["username"], ",',','+JbUsername+',')   >   0 ) ", this.ViewState["shijian"], "" });
                    string str14 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='1' and (CHARINDEX(',", reader2["username"], ",',','+JbUsername+',')   >   0 ) ", this.ViewState["shijian"], "" });
                    string str15 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='2' and (CHARINDEX(',", reader2["username"], ",',','+JbUsername+',')   >   0 ) ", this.ViewState["shijian"], "" });
                    string str16 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Renwu] as [A] inner join [qp_oa_RenwuLx] as [B] on [A].[Leixing] = [B].[Id]  where State='3' and (CHARINDEX(',", reader2["username"], ",',','+JbUsername+',')   >   0 ) ", this.ViewState["shijian"], "" });
                    text = this.Label1.Text;
                    this.Label1.Text = string.Concat(new object[] { 
                        text, "<tr><td align=\"center\">", reader2["realname"], "&nbsp;</td><td align=\"center\">", this.List.GetCount(str10), "</td><td align=\"center\">", this.List.GetCount(str11), "&nbsp;</td><td align=\"center\">", this.List.GetCount(str12), "&nbsp;</td><td align=\"center\">", this.List.GetCount(str13), "&nbsp;</td><td align=\"center\">", this.List.GetCount(str14), "&nbsp;</td><td align=\"center\">", this.List.GetCount(str15), "&nbsp;</td><td align=\"center\">", 
                        this.List.GetCount(str16), "&nbsp;</td></tr>"
                     });
                }
                reader2.Close();
                this.Label1.Text = this.Label1.Text + "</table>";
            }
        }
    }
}


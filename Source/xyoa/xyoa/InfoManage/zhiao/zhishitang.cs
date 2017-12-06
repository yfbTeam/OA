namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class zhishitang : Page
    {
        protected Label daijiejuewenti;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected right Right1;
        protected taitou Taitou1;
        protected Label tuijianwenti;
        protected Label tuijianziliao;
        protected Label wtfenlei;
        protected Label yijiejuewenti;
        protected Label zlfenlei;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string str4;
                SqlDataReader reader2;
                int num;
                object text;
                string sql = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Zst_wenti] as [A] inner join [qp_oa_Zst_leibie_wt] as [B] on [A].[Leibie] = [B].[Id]  where  jiejue='2' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+B.ZdBumenId+',') > 0 and B.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+B.ZdUsername+',') > 0 and B.States='3') or (B.States='1'))" });
                this.ViewState["wjjcount"] = "" + this.List.GetCount(sql) + "";
                string str2 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Zst_wenti] as [A] inner join [qp_oa_Zst_leibie_wt] as [B] on [A].[Leibie] = [B].[Id]  where  jiejue='1' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+B.ZdBumenId+',') > 0 and B.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+B.ZdUsername+',') > 0 and B.States='3') or (B.States='1'))" });
                this.ViewState["yjjcount"] = "" + this.List.GetCount(str2) + "";
                this.tuijianwenti.Text = null;
                this.tuijianwenti.Text = this.tuijianwenti.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                string str3 = string.Concat(new object[] { "select top 5 A.id,A.tuijian,A.Dianji,A.Huida,A.jiejue,A.Leibie, A.Zhuti, A.Settimes,A.Username,A.Realname, B.[Name] as LeibieName from [qp_oa_Zst_wenti] as [A] inner join [qp_oa_Zst_leibie_wt] as [B] on [A].[Leibie] = [B].[Id] where  tuijian='1' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+B.ZdBumenId+',') > 0 and B.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+B.ZdUsername+',') > 0 and B.States='3') or (B.States='1'))" });
                SqlDataReader list = this.List.GetList(str3);
                while (list.Read())
                {
                    str4 = "select id,Name,ParentNodesID from qp_oa_Zst_leibie_wt where  id='" + list["Leibie"].ToString() + "'";
                    reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        text = this.tuijianwenti.Text;
                        this.tuijianwenti.Text = string.Concat(new object[] { 
                            text, "<tr><td width=\"2%\">&nbsp;</td><td width=\"89%\"><font color=\"#393939\">[</font><a href=\"wenti_xiaolei_tj.aspx?ParentNodesID=", reader2["ParentNodesID"], "&id=", reader2["id"], "\" title=\"", this.pulicss.TypeCode("qp_oa_Zst_leibie_wt", reader2["ParentNodesID"].ToString()), " >> ", reader2["Name"], "\"><font  color=\"#393939\">", reader2["Name"], "</font></a><font color=\"#393939\">]</font><a href='javascript:void(0)' onclick='w_show(\"", list["id"].ToString(), "\")'>", list["Zhuti"].ToString(), "</a></td><td width=\"9%\"><font color=\"#676767\">", 
                            list["Huida"].ToString(), "回答</font></td></tr>"
                         });
                    }
                    reader2.Close();
                }
                list.Close();
                this.tuijianwenti.Text = this.tuijianwenti.Text + "</table>";
                this.daijiejuewenti.Text = null;
                this.daijiejuewenti.Text = this.daijiejuewenti.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                string str5 = string.Concat(new object[] { "select top 7 A.id,A.tuijian,A.Dianji,A.Huida,A.jiejue,A.Leibie, A.Zhuti, A.Settimes,A.Username,A.Realname, B.[Name] as LeibieName from [qp_oa_Zst_wenti] as [A] inner join [qp_oa_Zst_leibie_wt] as [B] on [A].[Leibie] = [B].[Id] where  jiejue='2' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+B.ZdBumenId+',') > 0 and B.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+B.ZdUsername+',') > 0 and B.States='3') or (B.States='1'))" });
                SqlDataReader reader3 = this.List.GetList(str5);
                while (reader3.Read())
                {
                    str4 = "select id,Name,ParentNodesID from qp_oa_Zst_leibie_wt where  id='" + reader3["Leibie"].ToString() + "'";
                    reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        text = this.daijiejuewenti.Text;
                        this.daijiejuewenti.Text = string.Concat(new object[] { 
                            text, "<tr><td width=\"2%\">&nbsp;</td><td width=\"89%\"><font color=\"#393939\">[</font><a href=\"wenti_xiaolei_wjj.aspx?ParentNodesID=", reader2["ParentNodesID"], "&id=", reader2["id"], "\" title=\"", this.pulicss.TypeCode("qp_oa_Zst_leibie_wt", reader2["ParentNodesID"].ToString()), " >> ", reader2["Name"], "\"><font  color=\"#393939\">", reader2["Name"], "</font></a><font color=\"#393939\">]</font><a href='javascript:void(0)' onclick='w_show(\"", reader3["id"].ToString(), "\")'>", reader3["Zhuti"].ToString(), "</a></td><td width=\"9%\"><font color=\"#676767\">", 
                            reader3["Huida"].ToString(), "回答</font></td></tr>"
                         });
                    }
                    reader2.Close();
                }
                reader3.Close();
                this.daijiejuewenti.Text = this.daijiejuewenti.Text + "</table>";
                this.yijiejuewenti.Text = null;
                this.yijiejuewenti.Text = this.yijiejuewenti.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                string str6 = string.Concat(new object[] { "select top 7 A.id,A.tuijian,A.Dianji,A.Huida,A.jiejue,A.Leibie, A.Zhuti, A.Settimes,A.Username,A.Realname, B.[Name] as LeibieName from [qp_oa_Zst_wenti] as [A] inner join [qp_oa_Zst_leibie_wt] as [B] on [A].[Leibie] = [B].[Id] where  jiejue='1' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+B.ZdBumenId+',') > 0 and B.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+B.ZdUsername+',') > 0 and B.States='3') or (B.States='1'))" });
                SqlDataReader reader4 = this.List.GetList(str6);
                while (reader4.Read())
                {
                    str4 = "select id,Name,ParentNodesID from qp_oa_Zst_leibie_wt where  id='" + reader4["Leibie"].ToString() + "'";
                    reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        text = this.yijiejuewenti.Text;
                        this.yijiejuewenti.Text = string.Concat(new object[] { 
                            text, "<tr><td width=\"2%\">&nbsp;</td><td width=\"89%\"><font color=\"#393939\">[</font><a href=\"wenti_xiaolei_yjj.aspx?ParentNodesID=", reader2["ParentNodesID"], "&id=", reader2["id"], "\" title=\"", this.pulicss.TypeCode("qp_oa_Zst_leibie_wt", reader2["ParentNodesID"].ToString()), " >> ", reader2["Name"], "\"><font  color=\"#393939\">", reader2["Name"], "</font></a><font color=\"#393939\">]</font><a href='javascript:void(0)' onclick='w_show(\"", reader4["id"].ToString(), "\")'>", reader4["Zhuti"].ToString(), "</a></td><td width=\"9%\"><font color=\"#676767\">", 
                            reader4["Huida"].ToString(), "回答</font></td></tr>"
                         });
                    }
                    reader2.Close();
                }
                reader4.Close();
                this.yijiejuewenti.Text = this.yijiejuewenti.Text + "</table>";
                this.tuijianziliao.Text = null;
                this.tuijianziliao.Text = this.tuijianziliao.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                string str7 = string.Concat(new object[] { "select top 6 * from qp_oa_Zst_ziliao  where Tuijian='1'  and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) " });
                SqlDataReader reader5 = this.List.GetList(str7);
                while (reader5.Read())
                {
                    str4 = string.Concat(new object[] { "select id,Name,ParentNodesID from qp_oa_Zst_leibie_zl where  id='", reader5["Leibie"].ToString(), "'  and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) " });
                    reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        text = this.tuijianziliao.Text;
                        this.tuijianziliao.Text = string.Concat(new object[] { 
                            text, "<tr><td width=\"2%\">&nbsp;</td><td width=\"3%\"><img src=\"/oaimg/filetype/", reader5["Filetype"].ToString(), ".gif\" border=0/></td><td width=\"86%\"><font color=\"#3333CC\"><a href='javascript:void(0)' onclick='m_show(\"", reader5["id"].ToString(), "\")'><font color=\"#3333CC\">", reader5["Name"].ToString(), "</font></a>[</font><a href=\"ziliao_xiaolei_tj.aspx?ParentNodesID=", reader2["ParentNodesID"], "&id=", reader2["id"], "\" title=\"", this.pulicss.TypeCode("qp_oa_Zst_leibie_zl", reader2["ParentNodesID"].ToString()), " >> ", reader2["Name"], "\"><font  color=\"#3333CC\">", 
                            reader2["Name"], "</font></a><font color=\"#3333CC\">]</font></td><td width=\"9%\"> <font color=\"#3333CC\">", reader5["cishu"].ToString(), "下载</font></td> </tr>"
                         });
                    }
                    reader2.Close();
                }
                reader5.Close();
                this.tuijianziliao.Text = this.tuijianziliao.Text + "</table>";
                this.zlfenlei.Text = null;
                this.zlfenlei.Text = this.zlfenlei.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\">";
                string str8 = string.Concat(new object[] { "select  id,Name,ParentNodesID from qp_oa_Zst_leibie_zl  where ParentNodesID='0'  and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))   order by Paixun asc" });
                SqlDataReader reader6 = this.List.GetList(str8);
                while (reader6.Read())
                {
                    text = this.zlfenlei.Text;
                    this.zlfenlei.Text = string.Concat(new object[] { text, "<tr><td><a href=\"ziliao_xiaolei.aspx?ParentNodesID=", reader6["id"], "&id=0\" class=\"LinkLine\"><font color=\"#3332CB\" style=\"font-size: 13px;\"><b>", reader6["Name"], "</b></font></a></td></tr>" });
                    num = 0;
                    this.zlfenlei.Text = this.zlfenlei.Text + "<tr><td valign=\"top\"> ";
                    str4 = string.Concat(new object[] { "select id,Name,ParentNodesID from qp_oa_Zst_leibie_zl where  ParentNodesID='", reader6["id"].ToString(), "'  and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))  order by Paixun asc" });
                    reader2 = this.List.GetList(str4);
                    while (reader2.Read())
                    {
                        text = this.zlfenlei.Text;
                        this.zlfenlei.Text = string.Concat(new object[] { text, "<a href=\"ziliao_xiaolei.aspx?ParentNodesID=", reader2["ParentNodesID"], "&id=", reader2["id"], "\" class=\"LinkLine\">", reader2["Name"], "</a>&nbsp;" });
                        num++;
                        if (num == 3)
                        {
                            this.zlfenlei.Text = this.zlfenlei.Text + "<br></td></tr><tr><td valign=\"top\">";
                            num = 0;
                        }
                    }
                    reader2.Close();
                }
                reader6.Close();
                this.zlfenlei.Text = this.zlfenlei.Text + "</table>";
                this.wtfenlei.Text = null;
                this.wtfenlei.Text = this.wtfenlei.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"3\">";
                string str9 = string.Concat(new object[] { "select  id,Name,ParentNodesID from qp_oa_Zst_leibie_wt  where ParentNodesID='0'  and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))   order by Paixun asc" });
                SqlDataReader reader7 = this.List.GetList(str9);
                while (reader7.Read())
                {
                    text = this.wtfenlei.Text;
                    this.wtfenlei.Text = string.Concat(new object[] { text, "<tr><td><a href=\"wenti_xiaolei.aspx?ParentNodesID=", reader7["id"], "&id=0\" class=\"LinkLine\"><font color=\"#3332CB\" style=\"font-size: 13px;\"><b>", reader7["Name"], "</b></font></a></td></tr>" });
                    num = 0;
                    this.wtfenlei.Text = this.wtfenlei.Text + "<tr><td valign=\"top\"> ";
                    str4 = string.Concat(new object[] { "select id,Name,ParentNodesID from qp_oa_Zst_leibie_wt where  ParentNodesID='", reader7["id"].ToString(), "'  and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))  order by Paixun asc" });
                    reader2 = this.List.GetList(str4);
                    while (reader2.Read())
                    {
                        text = this.wtfenlei.Text;
                        this.wtfenlei.Text = string.Concat(new object[] { text, "<a href=\"wenti_xiaolei.aspx?ParentNodesID=", reader2["ParentNodesID"], "&id=", reader2["id"], "\" class=\"LinkLine\">", reader2["Name"], "</a>&nbsp;" });
                        num++;
                        if (num == 3)
                        {
                            this.wtfenlei.Text = this.wtfenlei.Text + "<br></td></tr><tr><td valign=\"top\">";
                            num = 0;
                        }
                    }
                    reader2.Close();
                }
                reader7.Close();
                this.wtfenlei.Text = this.wtfenlei.Text + "</table>";
            }
        }
    }
}


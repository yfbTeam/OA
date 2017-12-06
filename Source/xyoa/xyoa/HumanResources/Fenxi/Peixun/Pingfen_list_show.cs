namespace xyoa.HumanResources.Fenxi.Peixun
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Pingfen_list_show : Page
    {
        protected Label Endtime;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected GridView GridView2;
        protected GridView GridView3;
        protected GridView GridView4;
        protected GridView GridView5;
        protected HtmlHead Head1;
        protected Label Label14;
        protected Label Label15;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label Starttime;
        protected Label Zhuangtai;
        protected Label Zhuti;

        public void DataBindToGridview()
        {
            string sql = "select A.id,A.Fenshu,B.Titles as TitlesC,B.AnswerA,B.AnswerB,B.AnswerC,B.AnswerD,B.Answer from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_DanXuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=1";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str2 = "select A.id,A.Fenshu,B.Titles as TitlesC,B.AnswerA,B.AnswerB,B.AnswerC,B.AnswerD,B.Answer from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_DuoXuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=2";
            this.GridView2.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView2.DataBind();
            string str3 = "select A.id,A.Fenshu,B.Titles as TitlesC,B.Answer from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_PanDuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=3";
            this.GridView3.DataSource = this.List.GetGrid_Pages_not(str3);
            this.GridView3.DataBind();
            string str4 = "select A.id,A.Fenshu,B.FrontTitle,B.BackTitle,B.Answer from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_TianKongTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=4";
            this.GridView4.DataSource = this.List.GetGrid_Pages_not(str4);
            this.GridView4.DataBind();
            string str5 = "select A.id,A.Fenshu,B.Titles as TitlesC,B.Answer from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_WenDaTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=5";
            this.GridView5.DataSource = this.List.GetGrid_Pages_not(str5);
            this.GridView5.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label3");
                Label label2 = (Label) e.Row.FindControl("Label201");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=1 and Username='", this.ViewState["UsernameS"], "' and TitleID='", label.Text, "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["UserAnswer"].ToString() == "A")
                    {
                        ((RadioButton) e.Row.FindControl("RadioButton1")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "B")
                    {
                        ((RadioButton) e.Row.FindControl("RadioButton2")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "C")
                    {
                        ((RadioButton) e.Row.FindControl("RadioButton3")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "D")
                    {
                        ((RadioButton) e.Row.FindControl("RadioButton4")).Checked = true;
                    }
                    label2.Text = list["UserAnswer"].ToString();
                }
                else
                {
                    this.ViewState["sinScore"] = "0";
                }
                list.Close();
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label6");
                Label label2 = (Label) e.Row.FindControl("Label202");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=2 and Username='", this.ViewState["UsernameS"], "' and TitleID='", label.Text, "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["UserAnswer"].ToString() == "A,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox1")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "B,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox2")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "C,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox3")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "D,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox4")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "A,B,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox1")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox2")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "A,C,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox1")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox3")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "A,D,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox1")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox4")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "B,C,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox2")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox3")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "B,C,D,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox2")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox3")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox4")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "B,D,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox2")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox4")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "C,D,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox3")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox4")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "A,B,C,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox1")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox2")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox3")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "A,B,D,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox1")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox2")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox4")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "A,C,D,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox1")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox3")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox4")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "A,B,C,D,0")
                    {
                        ((CheckBox) e.Row.FindControl("CheckBox1")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox2")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox3")).Checked = true;
                        ((CheckBox) e.Row.FindControl("CheckBox4")).Checked = true;
                    }
                    label2.Text = list["UserAnswer"].ToString();
                }
                list.Close();
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label7");
                Label label2 = (Label) e.Row.FindControl("Label203");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=3 and Username='", this.ViewState["UsernameS"], "' and TitleID='", label.Text, "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["UserAnswer"].ToString() == "1")
                    {
                        ((RadioButton) e.Row.FindControl("RadioButton5")).Checked = true;
                    }
                    if (list["UserAnswer"].ToString() == "2")
                    {
                        ((RadioButton) e.Row.FindControl("RadioButton6")).Checked = true;
                    }
                    label2.Text = list["UserAnswer"].ToString();
                }
                list.Close();
            }
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label8");
                Label label2 = (Label) e.Row.FindControl("Label204");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=4 and Username='", this.ViewState["UsernameS"], "' and TitleID='", label.Text, "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    ((TextBox) e.Row.FindControl("TextBox1")).Text = list["UserAnswer"].ToString();
                    label2.Text = list["UserAnswer"].ToString();
                }
                list.Close();
            }
        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label23");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=5 and Username='", this.ViewState["UsernameS"], "' and TitleID='", label.Text, "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    ((TextBox) e.Row.FindControl("txtAnswer")).Text = list["UserAnswer"].ToString();
                }
                list.Close();
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
                this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
                string sql = "select A.*,B.Zhuti as ZhutiS,B.Starttime as StarttimeS,B.Endtime as EndtimeS,B.Zhuangtai as ZhuangtaiS,B.Shijian as ShijianS,B.ShijuanID as ShijuanIDS from [qp_hr_MyKaoShi] as [A]  inner join [qp_hr_KaoShi] as [B] on [A].[KaoShiID] = [B].[Id] where A.id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["Fenshu"].ToString() != "1.19")
                    {
                        this.Label14.Text = "考试评分：" + list["Fenshu"].ToString() + "，评分人：" + list["PRealname"].ToString() + "<br>评语：" + list["Pingyu"].ToString() + "";
                        this.ViewState["Fenshu"] = "1";
                    }
                    else
                    {
                        this.Label14.Text = "未能获取考试结果";
                        this.ViewState["Fenshu"] = "2";
                    }
                    this.ViewState["UsernameS"] = list["Username"].ToString();
                    this.ViewState["ShijuanID"] = list["ShijuanIDS"].ToString();
                    this.ViewState["Shijian"] = list["ShijianS"].ToString();
                    this.Label15.Text = list["Realname"].ToString();
                    this.Zhuti.Text = list["ZhutiS"].ToString();
                    if (list["Zhuangtai"].ToString() == "1")
                    {
                        this.Zhuangtai.Text = "未参与";
                        this.Starttime.Text = "未参与";
                        this.Endtime.Text = "未参与";
                    }
                    else if (list["Zhuangtai"].ToString() == "2")
                    {
                        this.Zhuangtai.Text = "正在考试";
                        this.Starttime.Text = list["Starttime"].ToString();
                        this.Endtime.Text = list["Endtime"].ToString();
                    }
                    else
                    {
                        this.Zhuangtai.Text = "考试结束";
                        this.Starttime.Text = list["Starttime"].ToString();
                        this.Endtime.Text = list["Endtime"].ToString();
                    }
                    string str2 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=1";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.ViewState["Fenzhi1"] = reader2["Fenshu"].ToString();
                    }
                    reader2.Close();
                    string str3 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=2";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    if (reader3.Read())
                    {
                        this.ViewState["Fenzhi2"] = reader3["Fenshu"].ToString();
                    }
                    reader3.Close();
                    string str4 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=3";
                    SqlDataReader reader4 = this.List.GetList(str4);
                    if (reader4.Read())
                    {
                        this.ViewState["Fenzhi3"] = reader4["Fenshu"].ToString();
                    }
                    reader4.Close();
                    string str5 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=4";
                    SqlDataReader reader5 = this.List.GetList(str5);
                    if (reader5.Read())
                    {
                        this.ViewState["Fenzhi4"] = reader5["Fenshu"].ToString();
                    }
                    reader5.Close();
                    string str6 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=5";
                    SqlDataReader reader6 = this.List.GetList(str6);
                    if (reader6.Read())
                    {
                        this.ViewState["Fenzhi5"] = reader6["Fenshu"].ToString();
                    }
                    reader6.Close();
                    list.Close();
                    this.DataBindToGridview();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.location.href='Fenxi2.aspx'</script>");
                }
            }
        }
    }
}


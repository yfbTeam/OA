namespace xyoa.HumanResources.Employee.YuangongLL
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoShi_show : Page
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
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label Starttime;
        protected Label Zhuangtai;
        protected Label Zhuti;

        public void DataBindToGridview()
        {
            string sql = "select A.id,A.Fenshu,B.Titles as TitlesC,B.AnswerA,B.AnswerB,B.AnswerC,B.AnswerD from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_DanXuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=1";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str2 = "select A.id,A.Fenshu,B.Titles as TitlesC,B.AnswerA,B.AnswerB,B.AnswerC,B.AnswerD from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_DuoXuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=2";
            this.GridView2.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView2.DataBind();
            string str3 = "select A.id,A.Fenshu,B.Titles as TitlesC from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_PanDuanTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=3";
            this.GridView3.DataSource = this.List.GetGrid_Pages_not(str3);
            this.GridView3.DataBind();
            string str4 = "select A.id,A.Fenshu,B.FrontTitle,B.BackTitle,B.Answer from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_TianKongTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=4";
            this.GridView4.DataSource = this.List.GetGrid_Pages_not(str4);
            this.GridView4.DataBind();
            string str5 = "select A.id,A.Fenshu,B.Titles as TitlesC from [qp_hr_ShiJuanMx] as [A] inner join [qp_hr_WenDaTi] as [B] on [A].[TiMuID] = [B].[id] where A.ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=5";
            this.GridView5.DataSource = this.List.GetGrid_Pages_not(str5);
            this.GridView5.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label3");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=1 and Username='", this.ViewState["Username"], "' and TitleID='", label.Text, "'" });
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
                }
                list.Close();
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label6");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=2 and Username='", this.ViewState["Username"], "' and TitleID='", label.Text, "'" });
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
                }
                list.Close();
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label7");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=3 and Username='", this.ViewState["Username"], "' and TitleID='", label.Text, "'" });
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
                }
                list.Close();
            }
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label8");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=4 and Username='", this.ViewState["Username"], "' and TitleID='", label.Text, "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    ((TextBox) e.Row.FindControl("TextBox1")).Text = list["UserAnswer"].ToString();
                }
                list.Close();
            }
        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Label23");
                string sql = string.Concat(new object[] { "select UserAnswer from qp_hr_KaoShiDT where KaoShiID='", base.Request.QueryString["id"], "' and Leixing=5 and Username='", this.ViewState["Username"], "' and TitleID='", label.Text, "'" });
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
                string sql = "select Username from qp_hr_Yuangong  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["ygid"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Username"] = list["Username"].ToString();
                }
                list.Close();
                string str2 = string.Concat(new object[] { "select A.*,B.Zhuti as ZhutiS,B.Starttime as StarttimeS,B.Endtime as EndtimeS,B.Zhuangtai as ZhuangtaiS,B.Shijian as ShijianS,B.ShijuanID as ShijuanIDS from [qp_hr_MyKaoShi] as [A]  inner join [qp_hr_KaoShi] as [B] on [A].[KaoShiID] = [B].[Id] where A.id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and A.Username='", this.ViewState["Username"], "'" });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    TimeSpan span;
                    if (reader2["Fenshu"].ToString() != "1.19")
                    {
                        this.Label14.Text = "考试评分：" + reader2["Fenshu"].ToString() + "，评分人：" + reader2["PRealname"].ToString() + "<br>评语：" + reader2["Pingyu"].ToString() + "";
                    }
                    else
                    {
                        this.Label14.Text = "未能获取考试结果";
                    }
                    this.ViewState["ShijuanID"] = reader2["ShijuanIDS"].ToString();
                    this.ViewState["Shijian"] = reader2["ShijianS"].ToString();
                    this.Zhuti.Text = reader2["ZhutiS"].ToString();
                    if (reader2["Zhuangtai"].ToString() == "1")
                    {
                        if (reader2["ZhuangtaiS"].ToString() == "停用")
                        {
                            this.Zhuangtai.Text = "考试已停用，不能进行考试";
                            this.Starttime.Text = "考试已停用，不能进行考试";
                            this.Endtime.Text = "考试已停用，不能进行考试";
                        }
                        else
                        {
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader2["EndtimeS"].ToString()));
                            TimeSpan span2 = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader2["StarttimeS"].ToString()));
                            if ((span.TotalDays > 0.0) || (span2.TotalDays < 0.0))
                            {
                                this.Zhuangtai.Text = "未在规定的时间范围内，不能进行考试";
                                this.Starttime.Text = "未在规定的时间范围内，不能进行考试";
                                this.Endtime.Text = "未在规定的时间范围内，不能进行考试";
                            }
                            else
                            {
                                this.Starttime.Text = DateTime.Now.ToString();
                                this.Endtime.Text = DateTime.Now.AddMinutes(double.Parse(this.ViewState["Shijian"].ToString())).ToString();
                                this.Zhuangtai.Text = "正在考试";
                            }
                        }
                    }
                    else if (reader2["Zhuangtai"].ToString() == "2")
                    {
                        span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader2["Endtime"].ToString()));
                        if (span.TotalDays > 0.0)
                        {
                            this.Zhuangtai.Text = "考试结束";
                            this.Starttime.Text = reader2["Starttime"].ToString();
                            this.Endtime.Text = reader2["Endtime"].ToString();
                        }
                        else
                        {
                            this.Zhuangtai.Text = "正在考试";
                            this.Starttime.Text = reader2["Starttime"].ToString();
                            this.Endtime.Text = reader2["Endtime"].ToString();
                        }
                    }
                    else
                    {
                        this.Zhuangtai.Text = "考试结束";
                        this.Starttime.Text = reader2["Starttime"].ToString();
                        this.Endtime.Text = reader2["Endtime"].ToString();
                    }
                    string str3 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=1";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    if (reader3.Read())
                    {
                        this.ViewState["Fenzhi1"] = reader3["Fenshu"].ToString();
                    }
                    reader3.Close();
                    string str4 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=2";
                    SqlDataReader reader4 = this.List.GetList(str4);
                    if (reader4.Read())
                    {
                        this.ViewState["Fenzhi2"] = reader4["Fenshu"].ToString();
                    }
                    reader4.Close();
                    string str5 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=3";
                    SqlDataReader reader5 = this.List.GetList(str5);
                    if (reader5.Read())
                    {
                        this.ViewState["Fenzhi3"] = reader5["Fenshu"].ToString();
                    }
                    reader5.Close();
                    string str6 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=4";
                    SqlDataReader reader6 = this.List.GetList(str6);
                    if (reader6.Read())
                    {
                        this.ViewState["Fenzhi4"] = reader6["Fenshu"].ToString();
                    }
                    reader6.Close();
                    string str7 = "select Fenshu from qp_hr_ShiJuanMx where ShijuanID='" + this.ViewState["ShijuanID"] + "' and Leixing=5";
                    SqlDataReader reader7 = this.List.GetList(str7);
                    if (reader7.Read())
                    {
                        this.ViewState["Fenzhi5"] = reader7["Fenshu"].ToString();
                    }
                    reader7.Close();
                    reader2.Close();
                    this.DataBindToGridview();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到相关数据！');window.close();</script>");
                }
            }
        }
    }
}

